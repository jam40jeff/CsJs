using System;
using System.Runtime.CompilerServices;

namespace MorseCode.CsJs.Net
{
    [IgnoreNamespace]
    [ScriptName("SOAPClient")]
    public static class SoapClient
    {
        public static string Username;
        public static string Password;

        public static object Invoke(string url, string method, SoapClientParameters parameters, bool async, Callback callback)
        {
            return null;
        }
    }
}