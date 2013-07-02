namespace MorseCode.CsJs.Tools.VSIXExtension.ServiceReferenceGeneratorPackage.XmlSchema
{
    public interface IXmlSchemaSimpleTypeDefinition : IXmlSchemaTypeDefinition
    {
        XmlBuiltInSimpleType Type { get; }
    }
}