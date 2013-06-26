namespace MorseCode.CsJs.Xml.Schema
{
    public class XmlSchemaElementDefinition : IXmlSchemaElementDefinition
    {
        public string ElementNamespace { get; set; }
        public string Name { get; set; }
        public bool IsArray { get; set; }
        public bool IsNullable { get; set; }
        public IXmlSchemaTypeDefinition Type { get; set; }
    }
}