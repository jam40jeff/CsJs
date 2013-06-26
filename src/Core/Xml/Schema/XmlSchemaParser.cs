using System;
using System.Collections.Generic;
using System.Xml;
using MorseCode.CsJs.Common;

namespace MorseCode.CsJs.Xml.Schema
{
    //TODO: support attributes
    public static class XmlSchemaParser
    {
        public static IXmlSchemaElementDefinition GetElementDefinition(XmlDocument document, string targetNamespace, string elementName)
        {
            XmlNodeList schemaNodes = XPath.XPath.Evaluate(document, ".//xs:schema[@targetNamespace='" + targetNamespace + "']", ResolveNamespace);
            XmlNode schemaNode = schemaNodes[0];
            XmlNodeList elementNodes = XPath.XPath.Evaluate(schemaNode, "./xs:element[@name='" + elementName + "']", ResolveNamespace);
            if (elementNodes.Count != 1)
            {
                throw new InvalidOperationException("Could not find element definition for element " + elementName + ".");
            }
            return GetElementDefinitionRecursive(document.DocumentElement, schemaNode, elementNodes[0], new Dictionary<TypeReference, IXmlSchemaTypeDefinition>());
        }

        private static IXmlSchemaElementDefinition GetElementDefinitionRecursive(XmlNode document, XmlNode schemaNode, XmlNode elementNode, IDictionary<TypeReference, IXmlSchemaTypeDefinition> typesByName)
        {
            XmlSchemaElementDefinition elementDefinition = new XmlSchemaElementDefinition();

            string elementName = elementNode.Attributes.GetNamedItem("name").Value;
            XmlNode typeAttribute = elementNode.Attributes.GetNamedItem("type");
            XmlNode complexTypeNode = null;
            XmlNode simpleTypeNode = null;
            string rawTypeName = null;
            XmlNode typeSchemaNode;
            IXmlSchemaTypeDefinition existingType = null;
            Action<IXmlSchemaTypeDefinition> addTypeByName = null;
            if (typeAttribute != null)
            {
                rawTypeName = typeAttribute.Value;
                TypeReference typeReference;
                FindTargetSchemaNode(document, elementNode, schemaNode, rawTypeName, out typeSchemaNode, out typeReference);
                if (typesByName.ContainsKey(typeReference))
                {
                    existingType = typesByName[typeReference];
                }
                else
                {
                    addTypeByName = t => typesByName.Add(typeReference, t);
                    if (typeSchemaNode != null)
                    {
                        XmlNodeList complexTypeNodes = XPath.XPath.Evaluate(typeSchemaNode, "./xs:complexType[@name='" + typeReference.Name + "']", ResolveNamespace);
                        if (complexTypeNodes.Count == 1)
                        {
                            complexTypeNode = complexTypeNodes[0];
                        }
                        else
                        {
                            XmlNodeList simpleTypeNodes = XPath.XPath.Evaluate(typeSchemaNode, "./xs:simpleType[@name='" + typeReference.Name + "']", ResolveNamespace);
                            if (simpleTypeNodes.Count == 1)
                            {
                                simpleTypeNode = simpleTypeNodes[0];
                            }
                        }
                    }
                }
            }
            else
            {
                typeSchemaNode = schemaNode;
                XmlNodeList complexTypeNodes = XPath.XPath.Evaluate(elementNode, "./xs:complexType", ResolveNamespace);
                if (complexTypeNodes.Count == 1)
                {
                    complexTypeNode = complexTypeNodes[0];
                }
                else
                {
                    XmlNodeList simpleTypeNodes = XPath.XPath.Evaluate(elementNode, "./xs:simpleType", ResolveNamespace);
                    if (simpleTypeNodes.Count == 1)
                    {
                        simpleTypeNode = simpleTypeNodes[0];
                    }
                }
            }

            string elementTargetNamespace = schemaNode.Attributes.GetNamedItem("targetNamespace").Value;
            string typeTargetNamespace = typeSchemaNode == null ? null : typeSchemaNode.Attributes.GetNamedItem("targetNamespace").Value;

            elementDefinition.ElementNamespace = elementTargetNamespace;

            elementDefinition.IsArray = false;
            XmlNode maxOccursAttribute = elementNode.Attributes.GetNamedItem("maxOccurs");
            if (maxOccursAttribute != null)
            {
                if (maxOccursAttribute.Value == "unbounded")
                {
                    elementDefinition.IsArray = true;
                }
                else
                {
                    int? maxOccurs = FrameworkUtility.IntTryParse(maxOccursAttribute.Value);
                    if (maxOccurs != null && maxOccurs > 0)
                    {
                        elementDefinition.IsArray = true;
                    }
                }
            }

            XmlNode isNillableAttribute = elementNode.Attributes.GetNamedItem("isNillable");
            elementDefinition.IsNullable = isNillableAttribute != null && (isNillableAttribute.Value == "true" || isNillableAttribute.Value == "false");

            elementDefinition.Name = elementName;

            if (existingType != null)
            {
                elementDefinition.Type = existingType;
                return elementDefinition;
            }

            if (complexTypeNode != null)
            {
                XmlSchemaComplexTypeDefinition complexTypeDefinition = new XmlSchemaComplexTypeDefinition();
                if (addTypeByName != null)
                {
                    addTypeByName(complexTypeDefinition);
                }
                XmlNode nameAttribute = complexTypeNode.Attributes.GetNamedItem("name");
                complexTypeDefinition.TypeName = nameAttribute == null ? elementName : nameAttribute.Value;
                complexTypeDefinition.TypeNamespace = typeTargetNamespace;

                XmlNodeList childElementNodes = XPath.XPath.Evaluate(complexTypeNode, "./xs:sequence/xs:element", ResolveNamespace);
                for (int i = 0; i < childElementNodes.Count; i++)
                {
                    complexTypeDefinition.Elements.Add(GetElementDefinitionRecursive(document, typeSchemaNode, childElementNodes[i], typesByName));
                }

                elementDefinition.Type = complexTypeDefinition;

                return elementDefinition;
            }

            if (rawTypeName != null)
            {
                XmlBuiltInSimpleType? type;
                switch (rawTypeName)
                {
                    case "xs:anyType":
                        type = XmlBuiltInSimpleType.AnyType;
                        break;
                    case "xs:anyURI":
                        type = XmlBuiltInSimpleType.AnyUri;
                        break;
                    case "xs:base64Binary":
                        type = XmlBuiltInSimpleType.Base64Binary;
                        break;
                    case "xs:boolean":
                        type = XmlBuiltInSimpleType.Boolean;
                        break;
                    case "xs:byte":
                        type = XmlBuiltInSimpleType.Byte;
                        break;
                    case "xs:dateTime":
                        type = XmlBuiltInSimpleType.DateTime;
                        break;
                    case "xs:decimal":
                        type = XmlBuiltInSimpleType.Decimal;
                        break;
                    case "xs:double":
                        type = XmlBuiltInSimpleType.Double;
                        break;
                    case "xs:float":
                        type = XmlBuiltInSimpleType.Float;
                        break;
                    case "xs:int":
                        type = XmlBuiltInSimpleType.Int;
                        break;
                    case "xs:long":
                        type = XmlBuiltInSimpleType.Long;
                        break;
                    case "xs:QName":
                        type = XmlBuiltInSimpleType.QName;
                        break;
                    case "xs:short":
                        type = XmlBuiltInSimpleType.Short;
                        break;
                    case "xs:string":
                        type = XmlBuiltInSimpleType.String;
                        break;
                    case "xs:unsignedByte":
                        type = XmlBuiltInSimpleType.UnsignedByte;
                        break;
                    case "xs:unsignedInt":
                        type = XmlBuiltInSimpleType.UnsignedInt;
                        break;
                    case "xs:unsignedLong":
                        type = XmlBuiltInSimpleType.UnsignedLong;
                        break;
                    case "xs:unsignedShort":
                        type = XmlBuiltInSimpleType.UnsignedShort;
                        break;
                    case "tns:char":
                        type = XmlBuiltInSimpleType.Char;
                        break;
                    case "tns:duration":
                    case "xs:duration":
                        type = XmlBuiltInSimpleType.Duration;
                        break;
                    case "tns:guid":
                        type = XmlBuiltInSimpleType.Guid;
                        break;
                    default:
                        type = null;
                        break;
                }

                if (type != null)
                {
                    XmlSchemaBuiltInSimpleTypeDefinition builtInSimpleTypeDefinition = new XmlSchemaBuiltInSimpleTypeDefinition();
                    if (addTypeByName != null)
                    {
                        addTypeByName(builtInSimpleTypeDefinition);
                    }
                    string[] typeParts = rawTypeName.Split(':');
                    builtInSimpleTypeDefinition.TypeNamespace = typeParts[0];
                    builtInSimpleTypeDefinition.TypeName = typeParts[1];
                    builtInSimpleTypeDefinition.Type = type.Value;

                    elementDefinition.Type = builtInSimpleTypeDefinition;

                    return elementDefinition;
                }
            }

            if (simpleTypeNode != null)
            {
                XmlNodeList enumerationValueAttributes = XPath.XPath.Evaluate(simpleTypeNode, "./xs:restriction[@base='xs:string']/xs:enumeration/@value", ResolveNamespace);
                if (enumerationValueAttributes.Count > 0)
                {
                    XmlSchemaEnumSimpleTypeDefinition enumSimpleTypeDefinition = new XmlSchemaEnumSimpleTypeDefinition();
                    if (addTypeByName != null)
                    {
                        addTypeByName(enumSimpleTypeDefinition);
                    }

                    for (int i = 0; i < enumerationValueAttributes.Count; i++)
                    {
                        enumSimpleTypeDefinition.EnumValues.Add(enumerationValueAttributes[i].Value);
                    }

                    elementDefinition.Type = enumSimpleTypeDefinition;

                    return elementDefinition;
                }
            }

            throw new InvalidOperationException("Could not find type definition for element " + elementName + ".");
        }

        private static void FindTargetSchemaNode(XmlNode document, XmlNode node, XmlNode thisSchemaNode, string rawTypeName, out XmlNode targetSchemaNode, out TypeReference typeReference)
        {
            string[] typeParts = rawTypeName.Split(':');
            string typeName;
            string typeTargetNamespace;
            if (typeParts.Length == 2)
            {
                typeTargetNamespace = GetNamespace(node, typeParts[0]);
                typeName = typeParts[1];
                XmlNodeList targetSchemaNodes = XPath.XPath.Evaluate(document, ".//xs:schema[@targetNamespace='" + typeTargetNamespace + "']", ResolveNamespace);
                targetSchemaNode = targetSchemaNodes[0];
            }
            else if (typeParts.Length == 1)
            {
                typeTargetNamespace = thisSchemaNode.Attributes.GetNamedItem("targetNamespace").Value;
                typeName = typeParts[0];
                targetSchemaNode = thisSchemaNode;
            }
            else
            {
                throw new InvalidOperationException("Could not find target schema node for type " + rawTypeName + ".");
            }
            typeReference = new TypeReference(typeTargetNamespace, typeName);
        }

        private static string ResolveNamespace(string prefix)
        {
            return prefix == "xs" ? XmlSchemaConstants.XsSchemaNamespace : (prefix == "xmlns" ? "http://www.w3.org/2000/xmlns/" : null);
        }

        private static string GetNamespace(XmlNode node, string prefix)
        {
            return XPath.XPath.Evaluate(node, "./ancestor-or-self::*[@xmlns:" + prefix + "][1]/@xmlns:" + prefix, ResolveNamespace)[0].Value;
        }

        private class TypeReference
        {
            private readonly string _namespace;
            private readonly string _name;

            public TypeReference(string @namespace, string name)
            {
                _namespace = @namespace;
                _name = name;
            }

            public string Name
            {
                get { return _name; }
            }

            private bool Equals(TypeReference other)
            {
                return string.Equals(_namespace, other._namespace) && string.Equals(_name, other._name);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((TypeReference)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((_namespace != null ? _namespace.GetHashCode() : 0) * 397) ^ (_name != null ? _name.GetHashCode() : 0);
                }
            }
        }
    }
}