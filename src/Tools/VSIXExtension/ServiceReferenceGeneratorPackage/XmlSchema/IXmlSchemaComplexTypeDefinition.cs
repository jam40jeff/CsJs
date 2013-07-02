using System.Collections.Generic;

namespace MorseCode.CsJs.Tools.VSIXExtension.ServiceReferenceGeneratorPackage.XmlSchema
{
    public interface IXmlSchemaComplexTypeDefinition : IXmlSchemaTypeDefinition
    {
        string TypeName { get; set; }
        List<IXmlSchemaAttributeDefinition> Attributes { get; }
        List<IXmlSchemaElementDefinition> Elements { get; }
    }
}