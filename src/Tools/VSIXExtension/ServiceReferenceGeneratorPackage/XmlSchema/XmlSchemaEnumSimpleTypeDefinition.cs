using System.Collections.Generic;

namespace MorseCode.CsJs.Tools.VSIXExtension.ServiceReferenceGeneratorPackage.XmlSchema
{
    public class XmlSchemaEnumSimpleTypeDefinition : XmlSchemaTypeDefinition, IXmlSchemaEnumTypeDefinition
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