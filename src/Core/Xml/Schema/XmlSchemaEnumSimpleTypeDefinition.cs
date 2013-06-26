using System.Collections.Generic;

namespace MorseCode.CsJs.Xml.Schema
{
    public class XmlSchemaEnumSimpleTypeDefinition : XmlSchemaTypeDefinition, IXmlSchemaSimpleTypeDefinition
    {
        private readonly List<string> _enumValues = new List<string>();

        public string TypeName { get; set; }

        public List<string> EnumValues
        {
            get { return _enumValues; }
        }

        XmlBuiltInSimpleType IXmlSchemaSimpleTypeDefinition.Type
        {
            get { return XmlBuiltInSimpleType.Enum; }
        }

        public override string GetTypeName()
        {
            return TypeName;
        }
    }
}