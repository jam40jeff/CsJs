namespace MorseCode.CsJs.Xml.Schema
{
	public interface IXmlSchemaAttributeDefinition
	{
		string AttributeNamespace { get; set; }
		string Name { get; set; }
		bool IsNullable { get; set; }
		IXmlSchemaSimpleTypeDefinition Type { get; set; }
	}
}