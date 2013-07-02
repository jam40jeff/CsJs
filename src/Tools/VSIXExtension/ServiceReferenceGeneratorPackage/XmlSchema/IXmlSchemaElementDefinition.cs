namespace MorseCode.CsJs.Tools.VSIXExtension.ServiceReferenceGeneratorPackage.XmlSchema
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