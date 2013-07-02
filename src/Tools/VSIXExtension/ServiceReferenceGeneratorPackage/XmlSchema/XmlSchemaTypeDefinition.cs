namespace MorseCode.CsJs.Tools.VSIXExtension.ServiceReferenceGeneratorPackage.XmlSchema
{
    public abstract class XmlSchemaTypeDefinition : IXmlSchemaTypeDefinition
    {
        public string TypeNamespace { get; set; }

        public abstract string GetTypeName();
    }
}