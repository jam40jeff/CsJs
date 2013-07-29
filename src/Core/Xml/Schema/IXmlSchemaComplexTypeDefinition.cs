using System.Collections.Generic;

namespace MorseCode.CsJs.Xml.Schema
{
	public interface IXmlSchemaComplexTypeDefinition : IXmlSchemaTypeDefinition
	{
		string TypeName { get; set; }
		List<IXmlSchemaAttributeDefinition> Attributes { get; }
		List<IXmlSchemaElementDefinition> Elements { get; }
	}
}