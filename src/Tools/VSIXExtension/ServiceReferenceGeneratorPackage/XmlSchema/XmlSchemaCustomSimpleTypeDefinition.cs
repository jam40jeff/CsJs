namespace MorseCode.CsJs.Tools.VSIXExtension.ServiceReferenceGeneratorPackage.XmlSchema
{
    public class XmlSchemaCustomSimpleTypeDefinition : XmlSchemaTypeDefinition, IXmlSchemaSimpleTypeDefinition
    {
        public string TypeName { get; set; }
        public XmlBuiltInSimpleType BaseType { get; set; }

        XmlBuiltInSimpleType IXmlSchemaSimpleTypeDefinition.Type
        {
            get { return BaseType; }
        }

        public override string GetTypeName()
        {
            return TypeName;
        }
    }
}