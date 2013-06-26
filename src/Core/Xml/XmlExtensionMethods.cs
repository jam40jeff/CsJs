using System.Xml;

namespace MorseCode.CsJs.Xml
{
    //TODO: improve XML DOM and HTML DOM type system
    public static class XmlExtensionMethods
    {
        public static bool IsXmlAttribute(this XmlNode node)
        {
            return node != null && node.NodeType == XmlNodeType.Attribute;
        }

        public static bool IsXmlText(this XmlNode node)
        {
            return node != null && (node.NodeType == XmlNodeType.Text || node.NodeType == XmlNodeType.CDATA);
        }

        public static bool IsXmlDocument(this XmlNode node)
        {
            return node != null && node.NodeType == XmlNodeType.Document;
        }

        public static XmlAttribute AsXmlAttribute(this XmlNode node)
        {
            return IsXmlAttribute(node) ? (XmlAttribute)node : null;
        }

        public static XmlText AsXmlText(this XmlNode node)
        {
            return IsXmlText(node) ? (XmlText)node : null;
        }

        public static XmlDocument AsXmlDocument(this XmlNode node)
        {
            return IsXmlDocument(node) ? (XmlDocument)node : null;
        }
    }
}

namespace MorseCode.CsJs.Xml.XPath
{
}