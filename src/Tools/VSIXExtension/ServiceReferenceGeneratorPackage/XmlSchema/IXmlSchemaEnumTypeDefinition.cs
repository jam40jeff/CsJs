using System.Collections.Generic;

namespace MorseCode.CsJs.Tools.VSIXExtension.ServiceReferenceGeneratorPackage.XmlSchema
{
    public interface IXmlSchemaEnumTypeDefinition : IXmlSchemaSimpleTypeDefinition
    {
        string TypeName { get; set; }
        List<string> EnumValues { get; }
    }
}