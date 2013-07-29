namespace MorseCode.CsJs.Xml.Schema
{
	public abstract class XmlSchemaTypeDefinition : IXmlSchemaTypeDefinition
	{
		public string TypeNamespace { get; set; }

		public abstract string GetTypeName();
	}
}