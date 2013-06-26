namespace MorseCode.CsJs.Xml.Schema
{
    public interface IXmlSchemaElementDefinition
    {
        string ElementNamespace { get; set; }
        string Name { get; set; }
        bool IsArray { get; set; }
        bool IsNullable { get; set; }
        IXmlSchemaTypeDefinition Type { get; set; }
    }
}