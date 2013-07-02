using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using Microsoft.CSharp;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using MorseCode.CsJs.Net;
using MorseCode.CsJs.Tools.VSIXExtension.ServiceReferenceGeneratorPackage.XmlSchema;

namespace MorseCode.CsJs.Tools.VSIXExtension.ServiceReferenceGeneratorPackage
{
    internal class ServiceReferenceGenerator : IVsSingleFileGenerator
    {
        private readonly List<ITypeDefinition> _typeDefinitions = new List<ITypeDefinition>();
        private readonly List<OperationDefinition> _operationDefinitions = new List<OperationDefinition>();

        public int DefaultExtension(out string pbstrDefaultExtension)
        {
            pbstrDefaultExtension = ".generated.cs";
            return VSConstants.S_OK;
        }

        public int Generate(string wszInputFilePath, string bstrInputFileContents, string wszDefaultNamespace, IntPtr[] rgbOutputFileContents, out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
        {
            _typeDefinitions.Clear();
            _operationDefinitions.Clear();

            string contentsString = GetContents(wszInputFilePath, bstrInputFileContents, wszDefaultNamespace, pGenerateProgress);
            byte[] contents = Encoding.UTF8.GetBytes(contentsString);
            int contentsLength = contents.Length;
            pcbOutput = Convert.ToUInt32(contentsLength);
            rgbOutputFileContents[0] = Marshal.AllocCoTaskMem(contentsLength);
            Marshal.Copy(contents, 0, rgbOutputFileContents[0], contentsLength);
            return VSConstants.S_OK;
        }

        private string GetContents(string inputFilePath, string inputFileContents, string defaultNamespace, IVsGeneratorProgress progress)
        {
            progress.Progress(0, 100);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(inputFileContents);
            XmlElement serviceReferenceElement = null;
            if (doc.DocumentElement != null && doc.DocumentElement.Name == "serviceReference")
            {
                serviceReferenceElement = doc.DocumentElement;
            }
            if (serviceReferenceElement == null)
            {
                throw new InvalidOperationException("Service Reference must be an XML file containing a root node with name serviceReference.");
            }
            XmlAttribute namespaceAttribute = serviceReferenceElement.Attributes["namespace"];
            if (namespaceAttribute == null)
            {
                throw new InvalidOperationException("The namespace attribute is required.");
            }
            string ns = namespaceAttribute.Value;
            XmlAttribute urlAttribute = serviceReferenceElement.Attributes["url"];
            if (urlAttribute == null)
            {
                throw new InvalidOperationException("The url attribute is required.");
            }
            string url = urlAttribute.Value;
            XmlAttribute clientClassAttribute = serviceReferenceElement.Attributes["clientClass"];
            if (clientClassAttribute == null)
            {
                throw new InvalidOperationException("The clientClass attribute is required.");
            }
            string clientClass = clientClassAttribute.Value;

            ClientTypeDefinition clientTypeDefinition = new ClientTypeDefinition(GetUniqueTypeName(clientClass));
            _typeDefinitions.Add(clientTypeDefinition);

            WebRequest request = WebRequest.Create(url + "?singleWsdl");
            WebResponse response = request.GetResponse();
            XmlDocument wsdl = new XmlDocument();
            wsdl.Load(new XmlTextReader(response.GetResponseStream()));
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(wsdl.NameTable);
            namespaceManager.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
            namespaceManager.AddNamespace("wsdl", "http://schemas.xmlsoap.org/wsdl/");
            namespaceManager.AddNamespace("soap", "http://schemas.xmlsoap.org/wsdl/soap/");
            XmlNodeList operationNodes = wsdl.SelectNodes(".//wsdl:binding/wsdl:operation[soap:operation/@soapAction]", namespaceManager);
            Dictionary<string, string> soapActionByOperationName = new Dictionary<string, string>();
            if (operationNodes != null)
            {
                foreach (XmlNode operationNode in operationNodes)
                {
                    string operationName = operationNode.Attributes["name"].Value;
                    if (!soapActionByOperationName.ContainsKey(operationName))
                    {
                        string soapAction = operationNode.SelectSingleNode("./soap:operation/@soapAction", namespaceManager).Value;
                        soapActionByOperationName.Add(operationName, soapAction);
                    }
                }
            }

            string enumConvertersTypeName = GetUniqueTypeName("EnumConverters");

            foreach (KeyValuePair<string, string> soapActionByOperationNamePair in soapActionByOperationName)
            {
                string inputMessageName = wsdl.SelectNodes(".//wsdl:portType/wsdl:operation[@name='" + soapActionByOperationNamePair.Key + "']/wsdl:input/@message", namespaceManager)[0].Value;
                if (inputMessageName.Contains(":"))
                {
                    inputMessageName = inputMessageName.Substring(inputMessageName.IndexOf(':') + 1);
                }
                IXmlSchemaElementDefinition inputElementDefinition = GetElementDefinitionForMessage(wsdl, namespaceManager, inputMessageName);
                string outputMessageName = wsdl.SelectNodes(".//wsdl:portType/wsdl:operation[@name='" + soapActionByOperationNamePair.Key + "']/wsdl:output/@message", namespaceManager)[0].Value;
                if (outputMessageName.Contains(":"))
                {
                    outputMessageName = outputMessageName.Substring(outputMessageName.IndexOf(':') + 1);
                }
                IXmlSchemaElementDefinition outputElementDefinition = GetElementDefinitionForMessage(wsdl, namespaceManager, outputMessageName);
                if (outputElementDefinition.Type is IXmlSchemaComplexTypeDefinition && ((IXmlSchemaComplexTypeDefinition)outputElementDefinition.Type).Elements.Count == 1 && ((IXmlSchemaComplexTypeDefinition)outputElementDefinition.Type).Elements[0].Name == soapActionByOperationNamePair.Key + "Result")
                {
                    outputElementDefinition = ((IXmlSchemaComplexTypeDefinition)outputElementDefinition.Type).Elements[0];
                }
                List<ParameterDefinition> parameterDefinitions = new List<ParameterDefinition>();
                if (inputElementDefinition.Type.GetTypeName() == soapActionByOperationNamePair.Key && inputElementDefinition.Type is IXmlSchemaComplexTypeDefinition)
                {
                    parameterDefinitions.AddRange(((IXmlSchemaComplexTypeDefinition)inputElementDefinition.Type).Elements.Select(childElementDefinition =>
                        {
                            IXmlSchemaElementDefinition effectiveChildElementDefinition = GetEffectiveElementDefinition(childElementDefinition);
                            return new ParameterDefinition(childElementDefinition.Name, AddTypeDefinition(effectiveChildElementDefinition.Type), effectiveChildElementDefinition.IsArray, effectiveChildElementDefinition.IsNullable);
                        }));
                }
                else
                {
                    IXmlSchemaElementDefinition effectiveInputElementDefinition = GetEffectiveElementDefinition(inputElementDefinition);
                    parameterDefinitions.Add(new ParameterDefinition("p", AddTypeDefinition(effectiveInputElementDefinition.Type), effectiveInputElementDefinition.IsArray, effectiveInputElementDefinition.IsNullable));
                }
                IXmlSchemaElementDefinition effectiveOutputElementDefinition = GetEffectiveElementDefinition(outputElementDefinition);
                _operationDefinitions.Add(new OperationDefinition(soapActionByOperationNamePair.Key, soapActionByOperationNamePair.Value, parameterDefinitions, new ResultDefinition(AddTypeDefinition(effectiveOutputElementDefinition.Type), effectiveOutputElementDefinition.IsArray, effectiveOutputElementDefinition.IsNullable)));
            }

            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(ns);
            compileUnit.Namespaces.Add(codeNamespace);

            CodeTypeDeclaration clientType = new CodeTypeDeclaration(clientClass);
            codeNamespace.Types.Add(clientType);

            clientType.BaseTypes.Add(new CodeTypeReference(typeof(SoapClient)));

            foreach (OperationDefinition operationDefinition in _operationDefinitions)
            {
                CodeTypeReference resultCodeTypeReference = GetTypeReference(operationDefinition.ResultDefinition.TypeDefinition, operationDefinition.ResultDefinition.IsArray, operationDefinition.ResultDefinition.IsNullable);

                CodeVariableReferenceExpression parametersVariable;
                CodeStatement[] createParameters = CreateParameters(operationDefinition, out parametersVariable, enumConvertersTypeName);

                CodeMemberMethod getParametersMethod = CreateBaseOperationMethod(operationDefinition);
                getParametersMethod.Attributes = MemberAttributes.Private | MemberAttributes.Final;
                getParametersMethod.Name = "GetParametersFor" + operationDefinition.OperationName;
                getParametersMethod.Statements.AddRange(createParameters);
                getParametersMethod.Statements.Add(new CodeMethodReturnStatement(parametersVariable));
                getParametersMethod.ReturnType = new CodeTypeReference(typeof(Dictionary<string, object>));
                clientType.Members.Add(getParametersMethod);

                getParametersMethod.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, operationDefinition.OperationName + " Method"));

                CodeMemberMethod convertReturnValueMethod = new CodeMemberMethod();
                convertReturnValueMethod.Attributes = MemberAttributes.Private | MemberAttributes.Final;
                convertReturnValueMethod.Name = "ConvertReturnValueFor" + operationDefinition.OperationName;
                CodeParameterDeclarationExpression valueParameter = new CodeParameterDeclarationExpression(typeof(object), "value");
                convertReturnValueMethod.Parameters.Add(valueParameter);
                convertReturnValueMethod.ReturnType = resultCodeTypeReference;
                clientType.Members.Add(convertReturnValueMethod);

                ISchemaTypeDefinition schemaTypeDefinition = operationDefinition.ResultDefinition.TypeDefinition;
                CodeTypeReference codeTypeReference = GetTypeReference(schemaTypeDefinition, operationDefinition.ResultDefinition.IsArray, operationDefinition.ResultDefinition.IsNullable);

                CodeTypeReference jsDictionaryCodeTypeReference = new CodeTypeReference("System.Collections.JsDictionary");
                if (operationDefinition.ResultDefinition.IsArray)
                {
                    CodeTypeReference nonArrayCodeTypeReference = GetTypeReference(schemaTypeDefinition, false, operationDefinition.ResultDefinition.IsNullable);

                    CodeVariableDeclarationStatement returnValueVariable = new CodeVariableDeclarationStatement(resultCodeTypeReference, "returnValue", new CodeObjectCreateExpression(resultCodeTypeReference));
                    convertReturnValueMethod.Statements.Add(returnValueVariable);
                    CodeIterationStatement fromJsDictionaryForLoopStatement = new CodeIterationStatement(new CodeVariableDeclarationStatement(typeof(int), "i", new CodePrimitiveExpression(0)), new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression("i"), CodeBinaryOperatorType.LessThan, new CodePropertyReferenceExpression(CallScriptReinterpret(new CodeTypeReference(typeof(Array)), new CodeVariableReferenceExpression(valueParameter.Name)), "Length")), new CodeAssignStatement(new CodeVariableReferenceExpression("i"), new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression("i"), CodeBinaryOperatorType.Add, new CodePrimitiveExpression(1))));
                    CodeExpression accessFromJsDictionaryValue = new CodeArrayIndexerExpression(CallScriptReinterpret(new CodeTypeReference(typeof(Array)), new CodeVariableReferenceExpression(valueParameter.Name)), new CodeVariableReferenceExpression("i"));
                    CodeExpression fromJsDictionaryValueToAssign = GetFromJsDictionaryValueToAssign(schemaTypeDefinition, nonArrayCodeTypeReference, enumConvertersTypeName, operationDefinition.ResultDefinition.IsNullable, accessFromJsDictionaryValue, jsDictionaryCodeTypeReference);
                    fromJsDictionaryForLoopStatement.Statements.Add(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeVariableReferenceExpression(returnValueVariable.Name), "Add"), fromJsDictionaryValueToAssign));
                    convertReturnValueMethod.Statements.Add(new CodeConditionStatement(new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(valueParameter.Name), CodeBinaryOperatorType.IdentityInequality, new CodePrimitiveExpression(null)), fromJsDictionaryForLoopStatement));
                    convertReturnValueMethod.Statements.Add(new CodeMethodReturnStatement(new CodeVariableReferenceExpression(returnValueVariable.Name)));
                }
                else
                {
                    CodeExpression accessFromJsDictionaryValue = new CodeVariableReferenceExpression(valueParameter.Name);
                    CodeExpression fromJsDictionaryValueToAssign = GetFromJsDictionaryValueToAssign(schemaTypeDefinition, codeTypeReference, enumConvertersTypeName, operationDefinition.ResultDefinition.IsNullable, accessFromJsDictionaryValue, jsDictionaryCodeTypeReference);
                    convertReturnValueMethod.Statements.Add(new CodeMethodReturnStatement(fromJsDictionaryValueToAssign));
                }


                CodeMethodInvokeExpression callGetParameters = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), getParametersMethod.Name), getParametersMethod.Parameters.Cast<CodeParameterDeclarationExpression>().Select(p => (CodeExpression)new CodeVariableReferenceExpression(p.Name)).ToArray());

                CodeMemberMethod method = CreateBaseOperationMethod(operationDefinition);
                method.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(Action<>).FullName, resultCodeTypeReference), "successCallback"));
                method.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(Action<,,>).FullName, new CodeTypeReference("jQueryApi.jQueryXmlHttpRequest"), new CodeTypeReference(typeof(string)), new CodeTypeReference(typeof(string))), "errorCallback"));
                method.Statements.Add(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), "Invoke"), new CodePrimitiveExpression(operationDefinition.OperationName), callGetParameters, new CodeSnippetExpression("o => successCallback(" + convertReturnValueMethod.Name + "(o))"), new CodeVariableReferenceExpression("errorCallback")));
                clientType.Members.Add(method);

                CodeMemberMethod method2 = CreateBaseOperationMethod(operationDefinition);
                method2.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(Action<,,>).FullName, GetTypeReference(operationDefinition.ResultDefinition.TypeDefinition, operationDefinition.ResultDefinition.IsArray, operationDefinition.ResultDefinition.IsNullable), new CodeTypeReference(typeof(string)), new CodeTypeReference("jQueryApi.jQueryXmlHttpRequest")), "successCallback"));
                method2.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(Action<,,>).FullName, new CodeTypeReference("jQueryApi.jQueryXmlHttpRequest"), new CodeTypeReference(typeof(string)), new CodeTypeReference(typeof(string))), "errorCallback"));
                method2.Statements.Add(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), "Invoke"), new CodePrimitiveExpression(operationDefinition.OperationName), callGetParameters, new CodeSnippetExpression("(o,e,r) => successCallback(" + convertReturnValueMethod.Name + "(o),e,r)"), new CodeVariableReferenceExpression("errorCallback")));
                clientType.Members.Add(method2);

                CodeMemberMethod method3 = CreateBaseOperationMethod(operationDefinition);
                method3.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(Action<>).FullName, GetTypeReference(operationDefinition.ResultDefinition.TypeDefinition, operationDefinition.ResultDefinition.IsArray, operationDefinition.ResultDefinition.IsNullable)), "successCallback"));
                method3.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(Action<,,>).FullName, new CodeTypeReference("jQueryApi.jQueryXmlHttpRequest"), new CodeTypeReference(typeof(string)), new CodeTypeReference(typeof(string))), "errorCallback"));
                method3.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(Action<,,>).FullName, new CodeTypeReference("jQueryApi.jQueryXmlHttpRequest"), new CodeTypeReference(typeof(string)), new CodeTypeReference(typeof(string))), "wsdlErrorCallback"));
                method3.Statements.Add(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), "Invoke"), new CodePrimitiveExpression(operationDefinition.OperationName), callGetParameters, new CodeSnippetExpression("(o) => successCallback(" + convertReturnValueMethod.Name + "(o))"), new CodeVariableReferenceExpression("errorCallback"), new CodeVariableReferenceExpression("wsdlErrorCallback")));
                clientType.Members.Add(method3);

                CodeMemberMethod method4 = CreateBaseOperationMethod(operationDefinition);
                method4.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(Action<,,>).FullName, GetTypeReference(operationDefinition.ResultDefinition.TypeDefinition, operationDefinition.ResultDefinition.IsArray, operationDefinition.ResultDefinition.IsNullable), new CodeTypeReference(typeof(string)), new CodeTypeReference("jQueryApi.jQueryXmlHttpRequest")), "successCallback"));
                method4.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(Action<,,>).FullName, new CodeTypeReference("jQueryApi.jQueryXmlHttpRequest"), new CodeTypeReference(typeof(string)), new CodeTypeReference(typeof(string))), "errorCallback"));
                method4.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(Action<,,>).FullName, new CodeTypeReference("jQueryApi.jQueryXmlHttpRequest"), new CodeTypeReference(typeof(string)), new CodeTypeReference(typeof(string))), "wsdlErrorCallback"));
                method4.Statements.Add(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), "Invoke"), new CodePrimitiveExpression(operationDefinition.OperationName), callGetParameters, new CodeSnippetExpression("(o,e,r) => successCallback(" + convertReturnValueMethod.Name + "(o),e,r)"), new CodeVariableReferenceExpression("errorCallback"), new CodeVariableReferenceExpression("wsdlErrorCallback")));
                clientType.Members.Add(method4);

                method4.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, operationDefinition.OperationName + " Method"));
            }

            CodeTypeDeclaration enumConvertersType = new CodeTypeDeclaration(enumConvertersTypeName);
            codeNamespace.Types.Add(enumConvertersType);

            enumConvertersType.TypeAttributes = TypeAttributes.Public | TypeAttributes.Abstract;

            enumConvertersType.Members.Add(new CodeConstructor { Attributes = MemberAttributes.Private });

            foreach (ITypeDefinition typeDefinition in _typeDefinitions)
            {
                SchemaEnumTypeDefinition enumTypeDefinition = typeDefinition as SchemaEnumTypeDefinition;
                if (enumTypeDefinition != null)
                {
                    CodeTypeDeclaration enumType = new CodeTypeDeclaration(enumTypeDefinition.TypeName);
                    codeNamespace.Types.Add(enumType);

                    enumType.IsEnum = true;

                    enumType.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference("System.Runtime.CompilerServices.PreserveMemberCase")));

                    CodeMemberMethod convertToMethod = new CodeMemberMethod();
                    convertToMethod.Name = "Convert" + enumTypeDefinition.TypeName + "ToString";
                    convertToMethod.Attributes = MemberAttributes.Public | MemberAttributes.Static;
                    CodeParameterDeclarationExpression convertToValue = new CodeParameterDeclarationExpression(enumTypeDefinition.TypeName, "value");
                    convertToMethod.Parameters.Add(convertToValue);
                    convertToMethod.ReturnType = new CodeTypeReference(typeof(string));
                    enumConvertersType.Members.Add(convertToMethod);

                    CodeMemberMethod nullableConvertToMethod = new CodeMemberMethod();
                    nullableConvertToMethod.Name = "ConvertNullable" + enumTypeDefinition.TypeName + "ToString";
                    nullableConvertToMethod.Attributes = MemberAttributes.Public | MemberAttributes.Static;
                    CodeParameterDeclarationExpression nullableConvertToValue = new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(Nullable<>).FullName, new CodeTypeReference(enumTypeDefinition.TypeName)), "value");
                    nullableConvertToMethod.Parameters.Add(nullableConvertToValue);
                    nullableConvertToMethod.ReturnType = new CodeTypeReference(typeof(string));
                    nullableConvertToMethod.Statements.Add(new CodeConditionStatement(new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(nullableConvertToValue.Name), CodeBinaryOperatorType.IdentityEquality, new CodePrimitiveExpression(null)), new CodeStatement[] { new CodeMethodReturnStatement(new CodePrimitiveExpression(null)) }, new CodeStatement[] { new CodeMethodReturnStatement(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeTypeReferenceExpression(enumConvertersTypeName), convertToMethod.Name), new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(nullableConvertToValue.Name), "Value"))) }));
                    enumConvertersType.Members.Add(nullableConvertToMethod);

                    CodeMemberMethod convertFromMethod = new CodeMemberMethod();
                    convertFromMethod.Name = "ConvertStringTo" + enumTypeDefinition.TypeName;
                    convertFromMethod.Attributes = MemberAttributes.Public | MemberAttributes.Static;
                    CodeParameterDeclarationExpression convertFromValue = new CodeParameterDeclarationExpression(typeof(string), "value");
                    convertFromMethod.Parameters.Add(convertFromValue);
                    convertFromMethod.ReturnType = new CodeTypeReference(enumTypeDefinition.TypeName);
                    enumConvertersType.Members.Add(convertFromMethod);

                    CodeMemberMethod nullableConvertFromMethod = new CodeMemberMethod();
                    nullableConvertFromMethod.Name = "ConvertStringToNullable" + enumTypeDefinition.TypeName;
                    nullableConvertFromMethod.Attributes = MemberAttributes.Public | MemberAttributes.Static;
                    CodeParameterDeclarationExpression nullableConvertFromValue = new CodeParameterDeclarationExpression(typeof(string), "value");
                    nullableConvertFromMethod.Parameters.Add(nullableConvertFromValue);
                    nullableConvertFromMethod.ReturnType = new CodeTypeReference(typeof(Nullable<>).FullName, new CodeTypeReference(enumTypeDefinition.TypeName));
                    nullableConvertFromMethod.Statements.Add(new CodeConditionStatement(new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(nullableConvertFromValue.Name), CodeBinaryOperatorType.IdentityEquality, new CodePrimitiveExpression(null)), new CodeStatement[] { new CodeMethodReturnStatement(new CodePrimitiveExpression(null)) }, new CodeStatement[] { new CodeMethodReturnStatement(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeTypeReferenceExpression(enumConvertersTypeName), convertFromMethod.Name), new CodeVariableReferenceExpression(nullableConvertFromValue.Name))) }));
                    enumConvertersType.Members.Add(nullableConvertFromMethod);

                    foreach (string value in enumTypeDefinition.XmlSchemaTypeDefinition.EnumValues)
                    {
                        enumType.Members.Add(new CodeMemberField(enumTypeDefinition.TypeName, value));

                        convertToMethod.Statements.Add(new CodeConditionStatement(new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(convertToValue.Name), CodeBinaryOperatorType.ValueEquality, new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(enumTypeDefinition.TypeName), value)), new CodeMethodReturnStatement(new CodePrimitiveExpression(value))));
                        convertFromMethod.Statements.Add(new CodeConditionStatement(new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(convertFromValue.Name), CodeBinaryOperatorType.ValueEquality, new CodePrimitiveExpression(value)), new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(enumTypeDefinition.TypeName), value))));
                    }

                    convertToMethod.Statements.Add(new CodeThrowExceptionStatement(new CodeObjectCreateExpression(new CodeTypeReference(typeof(Exception)), new CodeBinaryOperatorExpression(new CodePrimitiveExpression("Could not convert " + enumTypeDefinition.TypeName + " value "), CodeBinaryOperatorType.Add, new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(convertToValue.Name), CodeBinaryOperatorType.Add, new CodePrimitiveExpression(" to string."))))));
                    convertFromMethod.Statements.Add(new CodeThrowExceptionStatement(new CodeObjectCreateExpression(new CodeTypeReference(typeof(Exception)), new CodeBinaryOperatorExpression(new CodePrimitiveExpression("Could not convert string value "), CodeBinaryOperatorType.Add, new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(convertFromValue.Name), CodeBinaryOperatorType.Add, new CodePrimitiveExpression(" to " + enumTypeDefinition.TypeName + "."))))));
                }

                SchemaLocalTypeDefinition localTypeDefinition = typeDefinition as SchemaLocalTypeDefinition;
                if (localTypeDefinition != null)
                {
                    CodeTypeDeclaration localType = new CodeTypeDeclaration(localTypeDefinition.TypeName);
                    codeNamespace.Types.Add(localType);

                    localType.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference("System.Runtime.CompilerServices.PreserveMemberCase")));

                    CodeMemberMethod fromJsDictionaryMethod = new CodeMemberMethod();
                    fromJsDictionaryMethod.Name = "FromJsDictionary";
                    fromJsDictionaryMethod.Attributes = MemberAttributes.Public | MemberAttributes.Static;
                    CodeTypeReference jsDictionaryCodeTypeReference = new CodeTypeReference("System.Collections.JsDictionary");
                    CodeParameterDeclarationExpression fromJsDictionaryValue = new CodeParameterDeclarationExpression(jsDictionaryCodeTypeReference, "value");
                    fromJsDictionaryMethod.Parameters.Add(fromJsDictionaryValue);
                    CodeTypeReference localTypeCodeTypeReference = new CodeTypeReference(localTypeDefinition.TypeName);
                    fromJsDictionaryMethod.ReturnType = localTypeCodeTypeReference;
                    fromJsDictionaryMethod.Statements.Add(new CodeConditionStatement(new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(fromJsDictionaryValue.Name), CodeBinaryOperatorType.IdentityEquality, new CodePrimitiveExpression(null)), new CodeMethodReturnStatement(new CodePrimitiveExpression(null))));
                    CodeVariableDeclarationStatement fromJsDictionaryReturnValue = new CodeVariableDeclarationStatement(localTypeCodeTypeReference, "returnValue", new CodeObjectCreateExpression(localTypeCodeTypeReference));
                    fromJsDictionaryMethod.Statements.Add(fromJsDictionaryReturnValue);

                    CodeMemberMethod toJsDictionaryMethod = new CodeMemberMethod();
                    toJsDictionaryMethod.Name = "ToJsDictionary";
                    toJsDictionaryMethod.Attributes = MemberAttributes.Public | MemberAttributes.Static;
                    CodeParameterDeclarationExpression toJsDictionaryValue = new CodeParameterDeclarationExpression(localTypeCodeTypeReference, "value");
                    toJsDictionaryMethod.Parameters.Add(toJsDictionaryValue);
                    toJsDictionaryMethod.ReturnType = jsDictionaryCodeTypeReference;
                    toJsDictionaryMethod.Statements.Add(new CodeConditionStatement(new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(toJsDictionaryValue.Name), CodeBinaryOperatorType.IdentityEquality, new CodePrimitiveExpression(null)), new CodeMethodReturnStatement(new CodePrimitiveExpression(null))));
                    CodeVariableDeclarationStatement toJsDictionaryReturnValue = new CodeVariableDeclarationStatement(jsDictionaryCodeTypeReference, "returnValue", new CodeObjectCreateExpression(jsDictionaryCodeTypeReference));
                    toJsDictionaryMethod.Statements.Add(toJsDictionaryReturnValue);

                    foreach (IXmlSchemaElementDefinition element in localTypeDefinition.XmlSchemaTypeDefinition.Elements)
                    {
                        string name = element.Name;
                        string fieldName = "_" + name[0].ToString(CultureInfo.InvariantCulture).ToLowerInvariant() + name.Substring(1);
                        string propertyName = name[0].ToString(CultureInfo.InvariantCulture).ToUpperInvariant() + name.Substring(1);

                        IXmlSchemaElementDefinition elementToUse = GetEffectiveElementDefinition(element);
                        ISchemaTypeDefinition schemaTypeDefinition = GetTypeDefinition(elementToUse.Type);
                        CodeTypeReference codeTypeReference = GetTypeReference(schemaTypeDefinition, elementToUse.IsArray, elementToUse.IsNullable);

                        CodeMemberField field = new CodeMemberField(codeTypeReference, fieldName) { Attributes = MemberAttributes.Private };
                        if (elementToUse.IsArray)
                        {
                            field.InitExpression = new CodeObjectCreateExpression(codeTypeReference);
                        }
                        localType.Members.Add(field);

                        CodeMemberProperty property = new CodeMemberProperty();
                        property.Type = codeTypeReference;
                        property.Name = propertyName;
                        property.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                        property.HasGet = true;
                        property.HasSet = !elementToUse.IsArray;
                        property.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName)));
                        if (!elementToUse.IsArray)
                        {
                            property.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName), new CodePropertySetValueReferenceExpression()));
                        }
                        localType.Members.Add(property);

                        if (elementToUse.IsArray)
                        {
                            CodeTypeReference nonArrayCodeTypeReference = GetTypeReference(schemaTypeDefinition, false, elementToUse.IsNullable);

                            toJsDictionaryMethod.Statements.Add(new CodeAssignStatement(new CodeArrayIndexerExpression(new CodeVariableReferenceExpression(toJsDictionaryReturnValue.Name), new CodePrimitiveExpression(name)), new CodeObjectCreateExpression(typeof(Array))));
                            CodeIterationStatement fromJsDictionaryForLoopStatement = new CodeIterationStatement(new CodeVariableDeclarationStatement(typeof(int), "i", new CodePrimitiveExpression(0)), new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression("i"), CodeBinaryOperatorType.LessThan, new CodePropertyReferenceExpression(CallScriptReinterpret(new CodeTypeReference(typeof(Array)), new CodeArrayIndexerExpression(new CodeVariableReferenceExpression(fromJsDictionaryValue.Name), new CodePrimitiveExpression(name))), "Length")), new CodeAssignStatement(new CodeVariableReferenceExpression("i"), new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression("i"), CodeBinaryOperatorType.Add, new CodePrimitiveExpression(1))));
                            CodeIterationStatement toJsDictionaryForLoopStatement = new CodeIterationStatement(new CodeVariableDeclarationStatement(typeof(int), "i", new CodePrimitiveExpression(0)), new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression("i"), CodeBinaryOperatorType.LessThan, new CodePropertyReferenceExpression(new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(toJsDictionaryValue.Name), propertyName), "Count")), new CodeAssignStatement(new CodeVariableReferenceExpression("i"), new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression("i"), CodeBinaryOperatorType.Add, new CodePrimitiveExpression(1))));
                            CodeExpression accessFromJsDictionaryValue = new CodeArrayIndexerExpression(CallScriptReinterpret(new CodeTypeReference(typeof(Array)), new CodeArrayIndexerExpression(new CodeVariableReferenceExpression(fromJsDictionaryValue.Name), new CodePrimitiveExpression(name))), new CodeVariableReferenceExpression("i"));
                            CodeExpression accessToJsDictionaryValue = new CodeArrayIndexerExpression(new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(toJsDictionaryValue.Name), propertyName), new CodeVariableReferenceExpression("i"));
                            CodeExpression fromJsDictionaryValueToAssign = GetFromJsDictionaryValueToAssign(schemaTypeDefinition, nonArrayCodeTypeReference, enumConvertersTypeName, elementToUse.IsNullable, accessFromJsDictionaryValue, jsDictionaryCodeTypeReference);
                            CodeExpression toJsDictionaryValueToAssign = GetToJsDictionaryValueToAssign(schemaTypeDefinition, nonArrayCodeTypeReference, enumConvertersTypeName, elementToUse.IsNullable, accessToJsDictionaryValue);
                            fromJsDictionaryForLoopStatement.Statements.Add(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(fromJsDictionaryReturnValue.Name), propertyName), "Add"), fromJsDictionaryValueToAssign));
                            toJsDictionaryForLoopStatement.Statements.Add(new CodeAssignStatement(new CodeArrayIndexerExpression(CallScriptReinterpret(new CodeTypeReference(typeof(Array)), new CodeArrayIndexerExpression(new CodeVariableReferenceExpression(toJsDictionaryReturnValue.Name), new CodePrimitiveExpression(name))), new CodeVariableReferenceExpression("i")), toJsDictionaryValueToAssign));
                            fromJsDictionaryMethod.Statements.Add(fromJsDictionaryForLoopStatement);
                            toJsDictionaryMethod.Statements.Add(toJsDictionaryForLoopStatement);
                        }
                        else
                        {
                            CodeExpression accessFromJsDictionaryValue = new CodeArrayIndexerExpression(new CodeVariableReferenceExpression(fromJsDictionaryValue.Name), new CodePrimitiveExpression(name));
                            CodeExpression accessToJsDictionaryValue = new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(toJsDictionaryValue.Name), propertyName);
                            CodeExpression fromJsDictionaryValueToAssign = GetFromJsDictionaryValueToAssign(schemaTypeDefinition, codeTypeReference, enumConvertersTypeName, elementToUse.IsNullable, accessFromJsDictionaryValue, jsDictionaryCodeTypeReference);
                            CodeExpression toJsDictionaryValueToAssign = GetToJsDictionaryValueToAssign(schemaTypeDefinition, codeTypeReference, enumConvertersTypeName, elementToUse.IsNullable, accessToJsDictionaryValue);
                            fromJsDictionaryMethod.Statements.Add(new CodeAssignStatement(new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(fromJsDictionaryReturnValue.Name), propertyName), fromJsDictionaryValueToAssign));
                            toJsDictionaryMethod.Statements.Add(new CodeAssignStatement(new CodeArrayIndexerExpression(new CodeVariableReferenceExpression(toJsDictionaryReturnValue.Name), new CodePrimitiveExpression(name)), toJsDictionaryValueToAssign));
                        }
                    }

                    fromJsDictionaryMethod.Statements.Add(new CodeMethodReturnStatement(new CodeVariableReferenceExpression(fromJsDictionaryReturnValue.Name)));
                    toJsDictionaryMethod.Statements.Add(new CodeMethodReturnStatement(new CodeVariableReferenceExpression(toJsDictionaryReturnValue.Name)));

                    localType.Members.Add(fromJsDictionaryMethod);
                    localType.Members.Add(toJsDictionaryMethod);
                }
            }

            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            CodeDomProvider codeDomProvider = new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v5.0" } });
            StringBuilder sb = new StringBuilder();
            IndentedTextWriter textWriter = new IndentedTextWriter(new StringWriter(sb));
            codeDomProvider.GenerateCodeFromCompileUnit(compileUnit, textWriter, options);
            textWriter.Close();
            return sb.ToString();
        }

        private CodeStatement[] CreateParameters(OperationDefinition operationDefinition, out CodeVariableReferenceExpression parametersVariable, string enumConvertersTypeName)
        {
            List<CodeStatement> codeStatements = new List<CodeStatement>();

            CodeVariableDeclarationStatement parameters = new CodeVariableDeclarationStatement(typeof(Dictionary<string, object>), "parameters", new CodeObjectCreateExpression(typeof(Dictionary<string, object>)));
            codeStatements.Add(parameters);

            parametersVariable = new CodeVariableReferenceExpression(parameters.Name);

            CodeVariableDeclarationStatement tempArray = new CodeVariableDeclarationStatement(typeof(Array), "tempArray");
            codeStatements.Add(tempArray);

            CodeVariableReferenceExpression tempArrayVariable = new CodeVariableReferenceExpression(tempArray.Name);

            bool usedTempArray = false;

            foreach (ParameterDefinition parameterDefinition in operationDefinition.ParameterDefinitions)
            {
                ISchemaTypeDefinition schemaTypeDefinition = parameterDefinition.TypeDefinition;
                CodeTypeReference codeTypeReference = GetTypeReference(schemaTypeDefinition, parameterDefinition.IsArray, parameterDefinition.IsNullable);

                if (parameterDefinition.IsArray)
                {
                    usedTempArray = true;

                    CodeTypeReference nonArrayCodeTypeReference = GetTypeReference(schemaTypeDefinition, false, parameterDefinition.IsNullable);

                    codeStatements.Add(new CodeAssignStatement(tempArrayVariable, new CodeObjectCreateExpression(typeof(Array))));
                    CodeIterationStatement toJsDictionaryForLoopStatement = new CodeIterationStatement(new CodeVariableDeclarationStatement(typeof(int), "i", new CodePrimitiveExpression(0)), new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression("i"), CodeBinaryOperatorType.LessThan, new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(parameterDefinition.ParameterName), "Count")), new CodeAssignStatement(new CodeVariableReferenceExpression("i"), new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression("i"), CodeBinaryOperatorType.Add, new CodePrimitiveExpression(1))));
                    CodeExpression accessToJsDictionaryValue = new CodeArrayIndexerExpression(new CodeVariableReferenceExpression(parameterDefinition.ParameterName), new CodeVariableReferenceExpression("i"));
                    CodeExpression toJsDictionaryValueToAssign = GetToJsDictionaryValueToAssign(schemaTypeDefinition, nonArrayCodeTypeReference, enumConvertersTypeName, parameterDefinition.IsNullable, accessToJsDictionaryValue);
                    toJsDictionaryForLoopStatement.Statements.Add(new CodeAssignStatement(new CodeArrayIndexerExpression(tempArrayVariable, new CodeVariableReferenceExpression("i")), toJsDictionaryValueToAssign));
                    codeStatements.Add(new CodeConditionStatement(new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(parameterDefinition.ParameterName), CodeBinaryOperatorType.IdentityInequality, new CodePrimitiveExpression(null)), toJsDictionaryForLoopStatement));
                    codeStatements.Add(new CodeExpressionStatement(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(parametersVariable, "Add"), new CodePrimitiveExpression(parameterDefinition.ParameterName), tempArrayVariable)));
                }
                else
                {
                    CodeExpression accessToJsDictionaryValue = new CodeVariableReferenceExpression(parameterDefinition.ParameterName);
                    CodeExpression toJsDictionaryValueToAssign = GetToJsDictionaryValueToAssign(schemaTypeDefinition, codeTypeReference, enumConvertersTypeName, parameterDefinition.IsNullable, accessToJsDictionaryValue);
                    codeStatements.Add(new CodeExpressionStatement(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(parametersVariable, "Add"), new CodePrimitiveExpression(parameterDefinition.ParameterName), toJsDictionaryValueToAssign)));
                }
            }

            if (!usedTempArray)
            {
                codeStatements.Remove(tempArray);
            }

            return codeStatements.ToArray();
        }

        private static CodeExpression GetFromJsDictionaryValueToAssign(ISchemaTypeDefinition schemaTypeDefinition, CodeTypeReference codeTypeReference, string enumConvertersTypeName, bool isNullable, CodeExpression accessFromJsDictionaryValue, CodeTypeReference jsDictionaryCodeTypeReference)
        {
            SchemaEnumTypeDefinition schemaEnumTypeDefinition = schemaTypeDefinition as SchemaEnumTypeDefinition;
            if (schemaEnumTypeDefinition != null)
            {
                CodeTypeReference enumConvertersCodeTypeReference = new CodeTypeReference(enumConvertersTypeName);
                return new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeTypeReferenceExpression(enumConvertersCodeTypeReference), "ConvertStringTo" + (isNullable ? "Nullable" : string.Empty) + schemaEnumTypeDefinition.TypeName), CallScriptReinterpret(new CodeTypeReference(typeof(string)), accessFromJsDictionaryValue));
            }

            if (schemaTypeDefinition is SchemaLocalTypeDefinition)
            {
                return new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeTypeReferenceExpression(codeTypeReference), "FromJsDictionary"), CallScriptReinterpret(jsDictionaryCodeTypeReference, accessFromJsDictionaryValue));
            }

            return CallScriptReinterpret(codeTypeReference, accessFromJsDictionaryValue);
        }

        private static CodeExpression GetToJsDictionaryValueToAssign(ISchemaTypeDefinition schemaTypeDefinition, CodeTypeReference codeTypeReference, string enumConvertersTypeName, bool isNullable, CodeExpression accessToJsDictionaryValue)
        {
            SchemaEnumTypeDefinition schemaEnumTypeDefinition = schemaTypeDefinition as SchemaEnumTypeDefinition;
            if (schemaEnumTypeDefinition != null)
            {
                CodeTypeReference enumConvertersCodeTypeReference = new CodeTypeReference(enumConvertersTypeName);
                return new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeTypeReferenceExpression(enumConvertersCodeTypeReference), "Convert" + (isNullable ? "Nullable" : string.Empty) + schemaEnumTypeDefinition.TypeName + "ToString"), accessToJsDictionaryValue);
            }

            if (schemaTypeDefinition is SchemaLocalTypeDefinition)
            {
                return new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeTypeReferenceExpression(codeTypeReference), "ToJsDictionary"), accessToJsDictionaryValue);
            }

            return accessToJsDictionaryValue;
        }

        private static CodeExpression CallScriptReinterpret(CodeTypeReference codeTypeReference, CodeExpression codeExpression)
        {
            return new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeTypeReferenceExpression("System.Script"), "Reinterpret", codeTypeReference), codeExpression);
        }

        private CodeMemberMethod CreateBaseOperationMethod(OperationDefinition operationDefinition)
        {
            CodeMemberMethod method = new CodeMemberMethod();
            method.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            method.Name = operationDefinition.OperationName;
            foreach (ParameterDefinition inputParameter in operationDefinition.ParameterDefinitions)
            {
                method.Parameters.Add(new CodeParameterDeclarationExpression(GetTypeReference(inputParameter.TypeDefinition, inputParameter.IsArray, inputParameter.IsNullable), inputParameter.ParameterName));
            }
            return method;
        }

        private CodeTypeReference GetTypeReference(ITypeDefinition typeDefinition, bool isArray, bool isNullable)
        {
            CodeTypeReference codeTypeReference = null;

            ILocalTypeDefinition localTypeDefinition = typeDefinition as ILocalTypeDefinition;
            if (localTypeDefinition != null)
            {
                codeTypeReference = new CodeTypeReference(localTypeDefinition.TypeName);
                if (isNullable && localTypeDefinition is SchemaEnumTypeDefinition)
                {
                    codeTypeReference = new CodeTypeReference(typeof(Nullable<>).FullName, codeTypeReference);
                }
            }

            SchemaBuiltInTypeDefinition builtInTypeDefinition = typeDefinition as SchemaBuiltInTypeDefinition;
            if (builtInTypeDefinition != null)
            {
                Type builtInType;
                switch (builtInTypeDefinition.XmlSchemaTypeDefinition.Type)
                {
                    case XmlBuiltInSimpleType.AnyType:
                        builtInType = typeof(object);
                        break;
                    case XmlBuiltInSimpleType.AnyUri:
                    case XmlBuiltInSimpleType.Guid:
                    case XmlBuiltInSimpleType.QName:
                    case XmlBuiltInSimpleType.String:
                        builtInType = typeof(string);
                        break;
                    case XmlBuiltInSimpleType.Base64Binary:
                        builtInType = typeof(byte[]);
                        break;
                    case XmlBuiltInSimpleType.Boolean:
                        builtInType = isNullable ? typeof(bool?) : typeof(bool);
                        break;
                    case XmlBuiltInSimpleType.Byte:
                    case XmlBuiltInSimpleType.UnsignedByte:
                        builtInType = isNullable ? typeof(byte?) : typeof(byte);
                        break;
                    case XmlBuiltInSimpleType.Char:
                        builtInType = isNullable ? typeof(char?) : typeof(char);
                        break;
                    case XmlBuiltInSimpleType.DateTime:
                        builtInType = isNullable ? typeof(DateTime?) : typeof(DateTime);
                        break;
                    case XmlBuiltInSimpleType.Decimal:
                        builtInType = isNullable ? typeof(decimal?) : typeof(decimal);
                        break;
                    case XmlBuiltInSimpleType.Double:
                        builtInType = isNullable ? typeof(double?) : typeof(double);
                        break;
                    case XmlBuiltInSimpleType.Duration:
                        builtInType = isNullable ? typeof(TimeSpan?) : typeof(TimeSpan);
                        break;
                    case XmlBuiltInSimpleType.Float:
                        builtInType = isNullable ? typeof(float?) : typeof(float);
                        break;
                    case XmlBuiltInSimpleType.Int:
                        builtInType = isNullable ? typeof(int?) : typeof(int);
                        break;
                    case XmlBuiltInSimpleType.Long:
                        builtInType = isNullable ? typeof(long?) : typeof(long);
                        break;
                    case XmlBuiltInSimpleType.Short:
                        builtInType = isNullable ? typeof(short?) : typeof(short);
                        break;
                    case XmlBuiltInSimpleType.UnsignedInt:
                        builtInType = isNullable ? typeof(uint?) : typeof(uint);
                        break;
                    case XmlBuiltInSimpleType.UnsignedLong:
                        builtInType = isNullable ? typeof(ulong?) : typeof(ulong);
                        break;
                    case XmlBuiltInSimpleType.UnsignedShort:
                        builtInType = isNullable ? typeof(ushort?) : typeof(ushort);
                        break;
                    default:
                        throw new InvalidOperationException("Could not find type for type definition.");
                }
                codeTypeReference = new CodeTypeReference(builtInType);
            }

            if (codeTypeReference == null)
            {
                throw new InvalidOperationException("Could not find type for type definition.");
            }

            return isArray ? GetArrayTypeReference(codeTypeReference) : codeTypeReference;
        }

        private CodeTypeReference GetArrayTypeReference(CodeTypeReference codeTypeReference)
        {
            return new CodeTypeReference(typeof(List<>).FullName, codeTypeReference);
        }

        private bool IsArrayContainer(IXmlSchemaTypeDefinition xmlTypeDefinition)
        {
            if (xmlTypeDefinition == null)
            {
                throw new ArgumentNullException("xmlTypeDefinition");
            }

            IXmlSchemaComplexTypeDefinition complexElementDefinition = xmlTypeDefinition as IXmlSchemaComplexTypeDefinition;
            return complexElementDefinition != null && complexElementDefinition.Elements.Count == 1 && complexElementDefinition.Elements[0].IsArray;
        }

        private IXmlSchemaElementDefinition GetEffectiveElementDefinition(IXmlSchemaElementDefinition elementDefinition)
        {
            if (elementDefinition == null)
            {
                throw new ArgumentNullException("elementDefinition");
            }

            IXmlSchemaComplexTypeDefinition complexElementDefinition = elementDefinition.Type as IXmlSchemaComplexTypeDefinition;
            return complexElementDefinition != null && IsArrayContainer(elementDefinition.Type) ? complexElementDefinition.Elements[0] : elementDefinition;
        }

        private ISchemaTypeDefinition GetTypeDefinition(IXmlSchemaTypeDefinition xmlTypeDefinition)
        {
            return (ISchemaTypeDefinition)_typeDefinitions.FirstOrDefault(t => t is ISchemaTypeDefinition && GetXmlTypeName(((ISchemaTypeDefinition)t).XmlSchemaTypeDefinition) == GetXmlTypeName(xmlTypeDefinition));
        }

        private ISchemaTypeDefinition AddTypeDefinition(IXmlSchemaTypeDefinition xmlTypeDefinition)
        {
            if (xmlTypeDefinition == null)
            {
                throw new ArgumentNullException("xmlTypeDefinition");
            }

            ISchemaTypeDefinition typeDefinition = GetTypeDefinition(xmlTypeDefinition);
            if (typeDefinition != null)
            {
                return typeDefinition;
            }

            IXmlSchemaEnumTypeDefinition xmlEnumTypeDefinition = xmlTypeDefinition as IXmlSchemaEnumTypeDefinition;
            if (xmlEnumTypeDefinition != null)
            {
                SchemaEnumTypeDefinition enumTypeDefinition = new SchemaEnumTypeDefinition(GetUniqueTypeName(xmlTypeDefinition.GetTypeName()), xmlEnumTypeDefinition);
                _typeDefinitions.Add(enumTypeDefinition);
                return enumTypeDefinition;
            }

            IXmlSchemaSimpleTypeDefinition xmlSimpleTypeDefinition = xmlTypeDefinition as IXmlSchemaSimpleTypeDefinition;
            if (xmlSimpleTypeDefinition != null)
            {
                SchemaBuiltInTypeDefinition builtInTypeDefinition = new SchemaBuiltInTypeDefinition(xmlSimpleTypeDefinition);
                _typeDefinitions.Add(builtInTypeDefinition);
                return builtInTypeDefinition;
            }

            IXmlSchemaComplexTypeDefinition xmlComplexTypeDefinition = xmlTypeDefinition as IXmlSchemaComplexTypeDefinition;
            if (xmlComplexTypeDefinition != null)
            {
                if (IsArrayContainer(xmlTypeDefinition))
                {
                    return AddTypeDefinition(xmlComplexTypeDefinition.Elements[0].Type);
                }

                SchemaLocalTypeDefinition localTypeDefinition = new SchemaLocalTypeDefinition(GetUniqueTypeName(xmlTypeDefinition.GetTypeName()), xmlComplexTypeDefinition);
                _typeDefinitions.Add(localTypeDefinition);

                foreach (IXmlSchemaElementDefinition childElement in xmlComplexTypeDefinition.Elements)
                {
                    AddTypeDefinition(childElement.Type);
                }

                return localTypeDefinition;
            }

            throw new InvalidOperationException("Unknown type definition encountered for type " + xmlTypeDefinition.GetTypeName() + ": " + xmlTypeDefinition.GetType() + ".");
        }

        private string GetXmlTypeName(IXmlSchemaTypeDefinition xmlTypeDefinition)
        {
            return (string.IsNullOrEmpty(xmlTypeDefinition.TypeNamespace) ? string.Empty : (xmlTypeDefinition.TypeNamespace + ":")) + xmlTypeDefinition.GetTypeName();
        }

        private static IXmlSchemaElementDefinition GetElementDefinitionForMessage(XmlDocument wsdl, XmlNamespaceManager namespaceManager, string messageName)
        {
            XmlNode messageNode = wsdl.SelectSingleNode(".//wsdl:message[@name='" + messageName + "']/wsdl:part[@name='parameters']/@element", namespaceManager);
            string parametersElementFullName = messageNode.Value;
            string[] parametersElementNameParts = parametersElementFullName.Split(':');
            string parametersElementNamespace;
            string parametersElementName;
            if (parametersElementNameParts.Length == 2)
            {
                parametersElementNamespace = messageNode.GetNamespaceOfPrefix(parametersElementNameParts[0]);
                parametersElementName = parametersElementNameParts[1];
            }
            else
            {
                parametersElementNamespace = messageNode.GetNamespaceOfPrefix(string.Empty);
                parametersElementName = parametersElementNameParts[0];
            }
            return XmlSchemaParser.GetElementDefinition(wsdl, parametersElementNamespace, parametersElementName);
        }

        private string GetUniqueTypeName(string desiredTypeName)
        {
            string typeName = desiredTypeName;
            int count = 0;
            while (_typeDefinitions.Any(t => t is ILocalTypeDefinition && ((ILocalTypeDefinition)t).TypeName == typeName))
            {
                typeName = desiredTypeName + count;
                count++;
            }
            return typeName;
        }

        private interface ITypeDefinition
        {
        }

        private interface ILocalTypeDefinition : ITypeDefinition
        {
            string TypeName { get; }
        }

        private interface ISchemaTypeDefinition : ITypeDefinition
        {
            IXmlSchemaTypeDefinition XmlSchemaTypeDefinition { get; }
        }

        private abstract class SchemaTypeDefinitionBase<T> : ISchemaTypeDefinition where T : IXmlSchemaTypeDefinition
        {
            private readonly T _xmlSchemaTypeDefinition;

            protected SchemaTypeDefinitionBase(T xmlSchemaTypeDefinition)
            {
                _xmlSchemaTypeDefinition = xmlSchemaTypeDefinition;
            }

            IXmlSchemaTypeDefinition ISchemaTypeDefinition.XmlSchemaTypeDefinition
            {
                get { return _xmlSchemaTypeDefinition; }
            }

            public T XmlSchemaTypeDefinition
            {
                get { return _xmlSchemaTypeDefinition; }
            }
        }

        private class SchemaBuiltInTypeDefinition : SchemaTypeDefinitionBase<IXmlSchemaSimpleTypeDefinition>
        {
            public SchemaBuiltInTypeDefinition(IXmlSchemaSimpleTypeDefinition xmlSchemaSimpleTypeDefinition)
                : base(xmlSchemaSimpleTypeDefinition)
            {
            }
        }

        private class SchemaLocalTypeDefinition : SchemaTypeDefinitionBase<IXmlSchemaComplexTypeDefinition>, ILocalTypeDefinition
        {
            private readonly string _typeName;

            public SchemaLocalTypeDefinition(string typeName, IXmlSchemaComplexTypeDefinition xmlSchemaComplexTypeDefinition)
                : base(xmlSchemaComplexTypeDefinition)
            {
                _typeName = typeName;
            }

            public string TypeName
            {
                get { return _typeName; }
            }
        }

        private class SchemaEnumTypeDefinition : SchemaTypeDefinitionBase<IXmlSchemaEnumTypeDefinition>, ILocalTypeDefinition
        {
            private readonly string _typeName;

            public SchemaEnumTypeDefinition(string typeName, IXmlSchemaEnumTypeDefinition xmlSchemaEnumTypeDefinition)
                : base(xmlSchemaEnumTypeDefinition)
            {
                _typeName = typeName;
            }

            public string TypeName
            {
                get { return _typeName; }
            }
        }

        private class ClientTypeDefinition : ILocalTypeDefinition
        {
            private readonly string _typeName;

            public ClientTypeDefinition(string typeName)
            {
                _typeName = typeName;
            }

            public string TypeName
            {
                get { return _typeName; }
            }
        }

        private class OperationDefinition
        {
            private readonly string _operationName;
            private readonly string _soapAction;
            private readonly IEnumerable<ParameterDefinition> _parameterDefinitions;
            private readonly ResultDefinition _resultDefinition;

            public OperationDefinition(string operationName, string soapAction, IEnumerable<ParameterDefinition> parameterDefinitions, ResultDefinition resultDefinition)
            {
                _operationName = operationName;
                _soapAction = soapAction;
                _parameterDefinitions = parameterDefinitions;
                _resultDefinition = resultDefinition;
            }

            public string OperationName
            {
                get { return _operationName; }
            }

            public string SoapAction
            {
                get { return _soapAction; }
            }

            public IEnumerable<ParameterDefinition> ParameterDefinitions
            {
                get { return _parameterDefinitions; }
            }

            public ResultDefinition ResultDefinition
            {
                get { return _resultDefinition; }
            }
        }

        private class ResultDefinition
        {
            private readonly ISchemaTypeDefinition _typeDefinition;
            private readonly bool _isArray;
            private readonly bool _isNullable;

            public ResultDefinition(ISchemaTypeDefinition typeDefinition, bool isArray, bool isNullable)
            {
                _typeDefinition = typeDefinition;
                _isArray = isArray;
                _isNullable = isNullable;
            }

            public ISchemaTypeDefinition TypeDefinition
            {
                get { return _typeDefinition; }
            }

            public bool IsArray
            {
                get { return _isArray; }
            }

            public bool IsNullable
            {
                get { return _isNullable; }
            }
        }

        private class ParameterDefinition : ResultDefinition
        {
            private readonly string _parameterName;

            public ParameterDefinition(string parameterName, ISchemaTypeDefinition typeDefinition, bool isArray, bool isNullable)
                : base(typeDefinition, isArray, isNullable)
            {
                _parameterName = parameterName;
            }

            public string ParameterName
            {
                get { return _parameterName; }
            }
        }
    }
}