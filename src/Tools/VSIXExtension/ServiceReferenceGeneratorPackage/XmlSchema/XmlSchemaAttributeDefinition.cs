namespace MorseCode.CsJs.Tools.VSIXExtension.ServiceReferenceGeneratorPackage.XmlSchema
{
    public class XmlSchemaAttributeDefinition : IXmlSchemaAttributeDefinition
    {
        public string AttributeNamespace { get; set; }
        public string Name { get; set; }
        public bool IsNullable { get; set; }
        public IXmlSchemaSimpleTypeDefinition Type { get; set; }
    }
}