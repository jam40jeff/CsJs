namespace MorseCode.CsJs.Tools.VSIXExtension.ServiceReferenceGeneratorPackage.XmlSchema
{
    public class XmlSchemaBuiltInSimpleTypeDefinition : XmlSchemaTypeDefinition, IXmlSchemaSimpleTypeDefinition
    {
        public string TypeName { get; set; }
        public XmlBuiltInSimpleType Type { get; set; }

        public override string GetTypeName()
        {
            return TypeName;
        }
    }
}