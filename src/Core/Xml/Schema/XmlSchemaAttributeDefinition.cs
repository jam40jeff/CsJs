namespace MorseCode.CsJs.Xml.Schema
{
    public class XmlSchemaAttributeDefinition : IXmlSchemaAttributeDefinition
    {
        public string AttributeNamespace { get; set; }
        public string Name { get; set; }
        public bool IsNullable { get; set; }
        public IXmlSchemaSimpleTypeDefinition Type { get; set; }
    }
}