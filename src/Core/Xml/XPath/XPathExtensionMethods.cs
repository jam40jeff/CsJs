using System;
using System.Runtime.CompilerServices;
using System.Xml;
using jQueryApi;

namespace MorseCode.CsJs.Xml.XPath
{
    [Imported]
    [IgnoreNamespace]
    public static class XPathExtensionMethods
    {
        [InstanceMethodOnFirstArgument]
        [ScriptName("xpath")]
        public static XmlNodeList XPath(this jQueryObject q, string xpath)
        {
            return null;
        }

        [InstanceMethodOnFirstArgument]
        [ScriptName("xpath")]
        public static XmlNodeList XPath(this jQueryObject q, string xpath, Func<string, string> resolver)
        {
            return null;
        }
    }
}