using System.Collections.Generic;

namespace MorseCode.CsJs.Xml.Schema
{
	public class XmlSchemaComplexTypeDefinition : XmlSchemaTypeDefinition, IXmlSchemaComplexTypeDefinition
	{
		private readonly List<IXmlSchemaAttributeDefinition> _attributes = new List<IXmlSchemaAttributeDefinition>();
		private readonly List<IXmlSchemaElementDefinition> _elements = new List<IXmlSchemaElementDefinition>();

		public string TypeName { get; set; }

		public override string GetTypeName()
		{
			return TypeName;
		}

		public List<IXmlSchemaAttributeDefinition> Attributes
		{
			get { return _attributes; }
		}

		public List<IXmlSchemaElementDefinition> Elements
		{
			get { return _elements; }
		}
	}
}