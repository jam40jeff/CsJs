using System;
using System.Collections.Generic;
using System.Xml;

namespace MorseCode.CsJs.Tools.VSIXExtension.ServiceReferenceGeneratorPackage.XmlSchema
{
    //TODO: support attributes
    public static class XmlSchemaParser
    {
        public static IXmlSchemaElementDefinition GetElementDefinition(XmlDocument document, string targetNamespace, string elementName)
        {
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(document.NameTable);
            xmlNamespaceManager.AddNamespace("xs", XmlSchemaConstants.XsSchemaNamespace);
            XmlNode schemaNode = document.SelectSingleNode(".//xs:schema[@targetNamespace='" + targetNamespace + "']", xmlNamespaceManager);
            XmlNodeList elementNodes = schemaNode.SelectNodes("./xs:element[@name='" + elementName + "']", xmlNamespaceManager);
            if (elementNodes.Count != 1)
            {
                throw new InvalidOperationException("Could not find element definition for element " + elementName + ".");
            }
            return GetElementDefinitionRecursive(document.DocumentElement, xmlNamespaceManager, schemaNode, elementNodes[0], new Dictionary<TypeReference, IXmlSchemaTypeDefinition>());
        }

        private static IXmlSchemaElementDefinition GetElementDefinitionRecursive(XmlNode document, XmlNamespaceManager xmlNamespaceManager, XmlNode schemaNode, XmlNode elementNode, IDictionary<TypeReference, IXmlSchemaTypeDefinition> typesByName)
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
                FindTargetSchemaNode(document, xmlNamespaceManager, elementNode, schemaNode, rawTypeName, out typeSchemaNode, out typeReference);
                if (typesByName.ContainsKey(typeReference))
                {
                    existingType = typesByName[typeReference];
                }
                else
                {
                    addTypeByName = t => typesByName.Add(typeReference, t);
                    if (typeSchemaNode != null)
                    {
                        XmlNodeList complexTypeNodes = typeSchemaNode.SelectNodes("./xs:complexType[@name='" + typeReference.Name + "']", xmlNamespaceManager);
                        if (complexTypeNodes.Count == 1)
                        {
                            complexTypeNode = complexTypeNodes[0];
                        }
                        else
                        {
                            XmlNodeList simpleTypeNodes = typeSchemaNode.SelectNodes("./xs:simpleType[@name='" + typeReference.Name + "']", xmlNamespaceManager);
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
                XmlNodeList complexTypeNodes = elementNode.SelectNodes("./xs:complexType", xmlNamespaceManager);
                if (complexTypeNodes.Count == 1)
                {
                    complexTypeNode = complexTypeNodes[0];
                }
                else
                {
                    XmlNodeList simpleTypeNodes = elementNode.SelectNodes("./xs:simpleType", xmlNamespaceManager);
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
                    int maxOccurs;
                    if (int.TryParse(maxOccursAttribute.Value, out maxOccurs) && maxOccurs > 0)
                    {
                        elementDefinition.IsArray = true;
                    }
                }
            }

            XmlNode nillableAttribute = elementNode.Attributes.GetNamedItem("nillable");
            elementDefinition.IsNullable = nillableAttribute != null && (nillableAttribute.Value == "true" || nillableAttribute.Value == "false");

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

                XmlNodeList childElementNodes = complexTypeNode.SelectNodes("./xs:sequence/xs:element", xmlNamespaceManager);
                for (int i = 0; i < childElementNodes.Count; i++)
                {
                    complexTypeDefinition.Elements.Add(GetElementDefinitionRecursive(document, xmlNamespaceManager, typeSchemaNode, childElementNodes[i], typesByName));
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
                XmlNodeList enumerationValueAttributes = simpleTypeNode.SelectNodes("./xs:restriction[@base='xs:string']/xs:enumeration/@value", xmlNamespaceManager);
                if (enumerationValueAttributes.Count > 0)
                {
                    XmlSchemaEnumSimpleTypeDefinition enumSimpleTypeDefinition = new XmlSchemaEnumSimpleTypeDefinition();
                    if (addTypeByName != null)
                    {
                        addTypeByName(enumSimpleTypeDefinition);
                    }
                    XmlNode nameAttribute = simpleTypeNode.Attributes.GetNamedItem("name");
                    enumSimpleTypeDefinition.TypeName = nameAttribute.Value;
                    enumSimpleTypeDefinition.TypeNamespace = typeTargetNamespace;

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

        private static void FindTargetSchemaNode(XmlNode document, XmlNamespaceManager xmlNamespaceManager, XmlNode node, XmlNode thisSchemaNode, string rawTypeName, out XmlNode targetSchemaNode, out TypeReference typeReference)
        {
            string[] typeParts = rawTypeName.Split(':');
            string typeName;
            string typeTargetNamespace;
            if (typeParts.Length == 2)
            {
                typeTargetNamespace = node.GetNamespaceOfPrefix(typeParts[0]);
                typeName = typeParts[1];
                XmlNodeList targetSchemaNodes = document.SelectNodes(".//xs:schema[@targetNamespace='" + typeTargetNamespace + "']", xmlNamespaceManager);
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