namespace MorseCode.CsJs.Tools.VSIXExtension.ServiceReferenceGeneratorPackage.XmlSchema
{
    public interface IXmlSchemaTypeDefinition
    {
        string TypeNamespace { get; set; }
        string GetTypeName();
    }
}