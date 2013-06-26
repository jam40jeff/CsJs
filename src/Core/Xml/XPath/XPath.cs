using System;
using System.Runtime.CompilerServices;
using System.Xml;
using jQueryApi;

namespace MorseCode.CsJs.Xml.XPath
{
    public static class XPath
    {
        public static XmlNodeList Evaluate(string xml, string xpath)
        {
            return jQuery.FromHtml(xml).XPath(xpath);
        }

        public static XmlNodeList Evaluate(string xml, string xpath, Func<string, string> resolver)
        {
            return jQuery.FromHtml(xml).XPath(xpath);
        }

        public static XmlNodeList Evaluate(XmlNode node, string xpath)
        {
            return GetJQueryObject(node).XPath(xpath);
        }

        public static XmlNodeList Evaluate(XmlNode node, string xpath, Func<string, string> resolver)
        {
            return GetJQueryObject(node).XPath(xpath, resolver);
        }

        [ScriptAlias("$")]
        private static jQueryObject GetJQueryObject(XmlNode node)
        {
            return null;
        }
    }
}