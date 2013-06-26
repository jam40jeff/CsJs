namespace MorseCode.CsJs.Xml.Schema
{
    public interface IXmlSchemaSimpleTypeDefinition : IXmlSchemaTypeDefinition
    {
        XmlBuiltInSimpleType Type { get; }
    }
}