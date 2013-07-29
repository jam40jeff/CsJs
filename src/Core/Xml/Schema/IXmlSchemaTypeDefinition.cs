namespace MorseCode.CsJs.Xml.Schema
{
	public interface IXmlSchemaTypeDefinition
	{
		string TypeNamespace { get; set; }
		string GetTypeName();
	}
}