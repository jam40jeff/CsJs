using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using MorseCode.CsJs.Common;
using MorseCode.CsJs.Xml.Schema;
using MorseCode.CsJs.Xml.XPath;
using jQueryApi;

namespace MorseCode.CsJs.Net
{
    public class SoapClient
    {
        private string _username;
        private string _password;
        private string _url;
        private TimeSpan _timeout = new TimeSpan(0, 1, 0);

        public void Invoke(string method, IDictionary<string, object> parameters, Action<object> successCallback, Action<jQueryXmlHttpRequest, string, string> errorCallback)
        {
            Invoke(method, parameters, successCallback, errorCallback, errorCallback);
        }

        public void Invoke(string method, IDictionary<string, object> parameters, Action<object> successCallback, Action<jQueryXmlHttpRequest, string, string> errorCallback, Action<jQueryXmlHttpRequest, string, string> wsdlErrorCallback)
        {
            Invoke(method, parameters, (data, textStatus, request) => successCallback(data), errorCallback, wsdlErrorCallback);
        }

        public void Invoke(string method, IDictionary<string, object> parameters, Action<object, string, jQueryXmlHttpRequest> successCallback, Action<jQueryXmlHttpRequest, string, string> errorCallback)
        {
            Invoke(method, parameters, successCallback, errorCallback, errorCallback);
        }

        public void Invoke(string method, IDictionary<string, object> parameters, Action<object, string, jQueryXmlHttpRequest> successCallback, Action<jQueryXmlHttpRequest, string, string> errorCallback, Action<jQueryXmlHttpRequest, string, string> wsdlErrorCallback)
        {
            new SoapClientInvocator(_username, _password, _url, _timeout, method, parameters, successCallback, errorCallback, wsdlErrorCallback).Invoke();
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public TimeSpan Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        private class SoapClientInvocator
        {
            private static readonly Dictionary<string, XmlDocument> WsdlByUrl = new Dictionary<string, XmlDocument>();
            private readonly string _username;
            private readonly string _password;
            private readonly string _url;
            private readonly TimeSpan _timeout;
            private readonly string _method;
            private readonly IDictionary<string, object> _parameters;
            private readonly Action<object, string, jQueryXmlHttpRequest> _successCallback;
            private readonly Action<jQueryXmlHttpRequest, string, string> _errorCallback;
            private readonly Action<jQueryXmlHttpRequest, string, string> _wsdlErrorCallback;

            public SoapClientInvocator(string username, string password, string url, TimeSpan timeout, string method, IDictionary<string, object> parameters, Action<object, string, jQueryXmlHttpRequest> successCallback, Action<jQueryXmlHttpRequest, string, string> errorCallback, Action<jQueryXmlHttpRequest, string, string> wsdlErrorCallback)
            {
                _username = username;
                _password = password;
                _url = url;
                _timeout = timeout;
                _method = method;
                _parameters = parameters;
                _successCallback = successCallback;
                _errorCallback = errorCallback;
                _wsdlErrorCallback = wsdlErrorCallback;
            }

            public void Invoke()
            {
                XmlDocument wsdl;
                if (WsdlByUrl.TryGetValue(_url, out wsdl))
                {
                    InvokeUsingWsdl(wsdl);
                    return;
                }

                jQuery.Ajax(_url + "?singleWsdl", new jQueryAjaxOptions { DataType = "xml" }).Then((data, textStatus, request) => LoadedWsdl((XmlDocument)data),
                                                                                                 (request, textStatus, error) => jQuery.Ajax(_url + "?wsdl").Then((data2, textStatus2, request2) => LoadedWsdl((XmlDocument)data2), FailedWsdl));
            }

            private void FailedWsdl(jQueryXmlHttpRequest request, string textStatus, string error)
            {
                _wsdlErrorCallback(request, textStatus, error);
            }

            private void LoadedWsdl(XmlDocument data)
            {
                WsdlByUrl[_url] = data;
                InvokeUsingWsdl(data);
            }

            private void InvokeUsingWsdl(XmlDocument wsdl)
            {
                XmlNode targetNamespaceNode = wsdl.DocumentElement.Attributes.GetNamedItem("targetNamespace");
                string targetNamespace = targetNamespaceNode == null ? string.Empty : targetNamespaceNode.Value;
                string soapRequest = @"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soap:Body>
        <" + _method + @" xmlns=""" + targetNamespace + @""">" + GetParametersXml(wsdl, targetNamespace) + @"</" + _method + @">
    </soap:Body>
</soap:Envelope>";
                jQueryAjaxOptions options = new jQueryAjaxOptions { DataType = "xml" };
                bool useCredentials = !string.IsNullOrEmpty(_username) && !string.IsNullOrEmpty(_password);
                if (useCredentials)
                {
                    options.Username = _username;
                    options.Password = _password;
                }
                options.BeforeSend = request =>
                    {
                        if (useCredentials)
                        {
                            request.SetRequestHeader("Authorization", "Basic " + StringUtility.ToBase64(_username + ":" + _password));
                        }
                        string soapAction = FindSoapAction(wsdl, targetNamespace);
                        request.SetRequestHeader("SOAPAction", soapAction);
                        request.SetRequestHeader("Content-Type", "text/xml; charset=utf-8");
                    };
                options.Timeout = (int)_timeout.TotalMilliseconds;
                options.Type = "POST";
                jQueryAjaxOptionsUtility.SetDataString(options, soapRequest);
                jQuery.Ajax(_url, options).Then((data, textStatus, request) => _successCallback(GetReturnValue(wsdl, Script.Reinterpret<XmlDocument>(data)), textStatus, request), new AjaxFailCallback(_errorCallback));
            }

            private Func<string, string> GetNamespaceResolver(string targetNamespace)
            {
                return prefix =>
                    {
                        if (prefix == "xs")
                        {
                            return "http://www.w3.org/2001/XMLSchema";
                        }

                        if (prefix == "wsdl")
                        {
                            return "http://schemas.xmlsoap.org/wsdl/";
                        }

                        if (prefix == "soap")
                        {
                            return "http://schemas.xmlsoap.org/wsdl/soap/";
                        }

                        if (prefix == "s")
                        {
                            return "http://schemas.xmlsoap.org/soap/envelope/";
                        }

                        if (prefix == "tns")
                        {
                            return targetNamespace;
                        }

                        return null;
                    };
            }

            private string FindSoapAction(XmlDocument wsdl, string targetNamespace)
            {
                string path = ".//wsdl:binding/wsdl:operation[@name='" + _method + "']/soap:operation/@soapAction";
                XmlNodeList nodes = XPath.Evaluate(wsdl, path, GetNamespaceResolver(targetNamespace));
                return nodes == null || nodes.Count < 1 ? string.Empty : nodes[0].Value;
            }

            private string GetParametersXml(XmlDocument wsdl, string targetNamespace)
            {
                string messageName = XPath.Evaluate(wsdl, ".//wsdl:portType/wsdl:operation[@name='" + _method + "']/wsdl:input/@message", GetNamespaceResolver(targetNamespace))[0].Value;
                if (messageName.Contains(":"))
                {
                    messageName = messageName.Substring(messageName.IndexOf(':') + 1);
                }
                string parametersElementFullName = XPath.Evaluate(wsdl, ".//wsdl:message[@name='" + messageName + "']/wsdl:part[@name='parameters']/@element", GetNamespaceResolver(targetNamespace))[0].Value;
                string[] parametersElementNameParts = parametersElementFullName.Split(':');
                string parametersElementNamespace;
                string parametersElementName;
                if (parametersElementNameParts.Length == 2)
                {
                    parametersElementNamespace = XPath.Evaluate(wsdl, ".//wsdl:definitions/@xmlns:" + parametersElementNameParts[0], GetNamespaceResolver(null))[0].Value;
                    parametersElementName = parametersElementNameParts[1];
                }
                else
                {
                    parametersElementNamespace = XPath.Evaluate(wsdl, ".//wsdl:definitions/@targetNamespace", GetNamespaceResolver(null))[0].Value;
                    parametersElementName = parametersElementNameParts[0];
                }
                IXmlSchemaElementDefinition elementDefinition = XmlSchemaParser.GetElementDefinition(wsdl, parametersElementNamespace, parametersElementName);

                string xml = string.Empty;
                foreach (IXmlSchemaElementDefinition childElementDefinition in ((XmlSchemaComplexTypeDefinition)elementDefinition.Type).Elements)
                {
                    xml += GetObjectXmlRecursive(childElementDefinition, _parameters[childElementDefinition.Name], false);
                }
                return xml;
            }

            private string GetObjectXmlRecursive(IXmlSchemaElementDefinition elementDefinition, object value, bool ignoreArray)
            {
                if (Script.IsNullOrUndefined(value))
                {
                    return "<" + elementDefinition.Name + (elementDefinition.ElementNamespace == null ? string.Empty : (" xmlns=\"" + elementDefinition.ElementNamespace + "\"")) + " i:nil=\"true\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" />";
                }

                string xml = string.Empty;
                IXmlSchemaSimpleTypeDefinition simpleTypeDefinition = elementDefinition.Type as IXmlSchemaSimpleTypeDefinition;
                if (simpleTypeDefinition != null)
                {
                    switch (simpleTypeDefinition.Type)
                    {
                        case XmlBuiltInSimpleType.AnyType:
                            xml += EncodeString(value.ToString());
                            break;
                        case XmlBuiltInSimpleType.AnyUri:
                        case XmlBuiltInSimpleType.Guid:
                        case XmlBuiltInSimpleType.QName:
                        case XmlBuiltInSimpleType.String:
                        case XmlBuiltInSimpleType.Enum:
                            EnsureScriptType(elementDefinition.Name, value, "string");
                            xml += EncodeString(Script.Reinterpret<string>(value));
                            break;
                        case XmlBuiltInSimpleType.Base64Binary:
                            string scriptType = Type.GetScriptType(value);
                            if (scriptType == "string")
                            {
                                xml += StringUtility.ToBase64(Script.Reinterpret<string>(value));
                            }
                            else
                            {
                                EnsureJsType(elementDefinition.Name, value, "Array");
                                xml += StringUtility.ToBase64(Script.Reinterpret<byte[]>(value));
                            }
                            break;
                        case XmlBuiltInSimpleType.Boolean:
                            EnsureScriptType(elementDefinition.Name, value, "boolean");
                            xml += value.ToString();
                            break;
                        case XmlBuiltInSimpleType.Char:
                            EnsureScriptType(elementDefinition.Name, value, "number");
                            xml += EncodeString(string.FromCharCode(Script.Reinterpret<char>(value)));
                            break;
                        case XmlBuiltInSimpleType.Byte:
                        case XmlBuiltInSimpleType.Decimal:
                        case XmlBuiltInSimpleType.Double:
                        case XmlBuiltInSimpleType.Float:
                        case XmlBuiltInSimpleType.Int:
                        case XmlBuiltInSimpleType.Long:
                        case XmlBuiltInSimpleType.Short:
                        case XmlBuiltInSimpleType.UnsignedByte:
                        case XmlBuiltInSimpleType.UnsignedInt:
                        case XmlBuiltInSimpleType.UnsignedLong:
                        case XmlBuiltInSimpleType.UnsignedShort:
                            EnsureScriptType(elementDefinition.Name, value, "number");
                            xml += value.ToString();
                            break;
                        case XmlBuiltInSimpleType.DateTime:
                            if (!(value is DateTime))
                            {
                                ThrowTypeException(elementDefinition.Name, value, typeof(DateTime));
                            }
                            string year = Script.Reinterpret<DateTime>(value).GetFullYear().ToString();
                            string month = (Script.Reinterpret<DateTime>(value).GetMonth() + 1).ToString().PadLeft(2, '0');
                            string date = Script.Reinterpret<DateTime>(value).GetDate().ToString().PadLeft(2, '0');
                            string hours = Script.Reinterpret<DateTime>(value).GetHours().ToString().PadLeft(2, '0');
                            string minutes = Script.Reinterpret<DateTime>(value).GetMinutes().ToString().PadLeft(2, '0');
                            string seconds = Script.Reinterpret<DateTime>(value).GetSeconds().ToString().PadLeft(2, '0');
                            string milliseconds = Script.Reinterpret<DateTime>(value).GetMilliseconds().ToString();
                            int timezoneOffsetTotalMinutes = Script.Reinterpret<DateTime>(value).GetTimezoneOffset();
                            int timezoneOffsetTotalMinutesAbs = Math.Abs(timezoneOffsetTotalMinutes);
                            int timezoneOffsetHours = timezoneOffsetTotalMinutesAbs / 60;
                            int timezoneOffsetMinutes = timezoneOffsetTotalMinutesAbs % 60;
                            string timezone = ((timezoneOffsetTotalMinutes < 0) ? "+" : "-") + timezoneOffsetHours.ToString().PadLeft(2, '0') + ":" + timezoneOffsetMinutes.ToString().PadLeft(2, '0');
                            xml += year + "-" + month + "-" + date + "T" + hours + ":" + minutes + ":" + seconds + "." + milliseconds + timezone;
                            break;
                        case XmlBuiltInSimpleType.Duration:
                            if (!(value is TimeSpan))
                            {
                                ThrowTypeException(elementDefinition.Name, value, typeof(TimeSpan));
                            }
                            TimeSpan ts = Script.Reinterpret<TimeSpan>(value);
                            bool durationIsNegative = ts.Ticks < 0;
                            int durationDays = Math.Abs(ts.Days);
                            int durationHours = Math.Abs(ts.Hours);
                            int durationMinutes = Math.Abs(ts.Minutes);
                            int durationSeconds = Math.Abs(ts.Seconds);
                            int durationMilliseconds = Math.Abs(ts.Milliseconds);
                            xml += (durationIsNegative ? "-" : string.Empty) + durationDays + "DT" + durationHours + "H" + durationMinutes + "M" + durationSeconds + "." + durationMilliseconds.ToString().PadLeft(3, '0') + "S";
                            break;
                        default:
                            throw UnhandledEnumValueExceptionFactory.Create(simpleTypeDefinition.Type);
                    }
                }
                else
                {
                    IXmlSchemaComplexTypeDefinition complexTypeDefinition = elementDefinition.Type as IXmlSchemaComplexTypeDefinition;
                    if (complexTypeDefinition == null)
                    {
                        throw new NotSupportedException("Unknown type for element definition: " + elementDefinition.GetType().FullName);
                    }

                    bool isArrayContainer = IsArrayContainer(complexTypeDefinition);
                    if (!ignoreArray && (isArrayContainer || elementDefinition.IsArray))
                    {
                        if (!(value is IEnumerable))
                        {
                            ThrowTypeException(elementDefinition.Name, value, typeof(IEnumerable));
                        }

                        IXmlSchemaElementDefinition arrayElementDefinition;
                        if (isArrayContainer)
                        {
                            xml += "<" + elementDefinition.Name + (elementDefinition.ElementNamespace == null ? string.Empty : (" xmlns=\"" + elementDefinition.ElementNamespace + "\"")) + ">";
                            arrayElementDefinition = complexTypeDefinition.Elements[0];
                        }
                        else
                        {
                            arrayElementDefinition = elementDefinition;
                        }

                        foreach (object item in Script.Reinterpret<Array>(value))
                        {
                            xml += GetObjectXmlRecursive(arrayElementDefinition, item, true);
                        }

                        if (isArrayContainer)
                        {
                            xml += "</" + elementDefinition.Name + ">";
                        }

                        return xml;
                    }

                    foreach (IXmlSchemaElementDefinition childElementDefinition in complexTypeDefinition.Elements)
                    {
                        xml += GetObjectXmlRecursive(childElementDefinition, Script.Reinterpret<JsDictionary>(value)[childElementDefinition.Name], false);
                    }
                }
                return "<" + elementDefinition.Name + (elementDefinition.ElementNamespace == null ? string.Empty : (" xmlns=\"" + elementDefinition.ElementNamespace + "\"")) + ">" + xml + "</" + elementDefinition.Name + ">";
            }

            private bool IsArrayContainer(IXmlSchemaComplexTypeDefinition complexElementDefinition)
            {
                return complexElementDefinition.Elements.Count == 1 && complexElementDefinition.Elements[0].IsArray;
            }

            private static void EnsureScriptType(string elementName, object value, string expectedType)
            {
                string scriptType = Type.GetScriptType(value);
                if (scriptType != expectedType)
                {
                    throw new InvalidOperationException("Expected " + expectedType + " for element " + elementName + ", but encountered " + scriptType + ".");
                }
            }

            private static void EnsureJsType(string elementName, object value, string expectedType)
            {
                string jsType = FrameworkUtility.GetJsType(value);
                if (jsType != expectedType)
                {
                    throw new InvalidOperationException("Expected type " + expectedType + " for element " + elementName + ", but encountered " + jsType + ".");
                }
            }

            private static void ThrowTypeException(string elementName, object value, Type expectedType)
            {
                throw new InvalidOperationException("Expected class type " + expectedType.FullName + " for element " + elementName + ", but encountered " + value.GetType().FullName + ".");
            }

            private static string EncodeString(string s)
            {
                return s == null ? null : s.Replace(new Regex("&", "g"), "&amp;").Replace(new Regex("<", "g"), "&lt;").Replace(new Regex(">", "g"), "&gt;");
            }

            private static string DecodeString(string s)
            {
                return s == null ? null : s.Replace(new Regex("&amp;", "g"), "&").Replace(new Regex("&lt;", "g"), "<").Replace(new Regex("&gt;", "g"), ">");
            }

            private object GetReturnValue(XmlDocument wsdl, XmlDocument data)
            {
                string messageName = XPath.Evaluate(wsdl, ".//wsdl:portType/wsdl:operation[@name='" + _method + "']/wsdl:output/@message", GetNamespaceResolver(null))[0].Value;
                if (messageName.Contains(":"))
                {
                    messageName = messageName.Substring(messageName.IndexOf(':') + 1);
                }
                string parametersElementFullName = XPath.Evaluate(wsdl, ".//wsdl:message[@name='" + messageName + "']/wsdl:part[@name='parameters']/@element", GetNamespaceResolver(null))[0].Value;
                string[] parametersElementNameParts = parametersElementFullName.Split(':');
                string parametersElementNamespace;
                string parametersElementName;
                if (parametersElementNameParts.Length == 2)
                {
                    parametersElementNamespace = XPath.Evaluate(wsdl, ".//wsdl:definitions/@xmlns:" + parametersElementNameParts[0], GetNamespaceResolver(null))[0].Value;
                    parametersElementName = parametersElementNameParts[1];
                }
                else
                {
                    parametersElementNamespace = XPath.Evaluate(wsdl, ".//wsdl:definitions/@targetNamespace", GetNamespaceResolver(null))[0].Value;
                    parametersElementName = parametersElementNameParts[0];
                }
                IXmlSchemaElementDefinition elementDefinition = XmlSchemaParser.GetElementDefinition(wsdl, parametersElementNamespace, parametersElementName);
                IXmlSchemaComplexTypeDefinition resultType = (IXmlSchemaComplexTypeDefinition)elementDefinition.Type;
                XmlNode bodyNode = XPath.Evaluate(data, "./s:Envelope/s:Body", GetNamespaceResolver(null))[0];
                return GetObjectRecursive(resultType.Elements[0], bodyNode.ChildNodes[0]);
            }

            private object GetObjectRecursive(IXmlSchemaElementDefinition elementDefinition, XmlNode parentNode)
            {
                XmlNodeList childNodes;
                IXmlSchemaComplexTypeDefinition complexTypeDefinition = elementDefinition.Type as IXmlSchemaComplexTypeDefinition;
                bool isArrayContainer = complexTypeDefinition != null && IsArrayContainer(complexTypeDefinition);
                if (isArrayContainer || elementDefinition.IsArray)
                {
                    IXmlSchemaElementDefinition arrayElementDefinition = isArrayContainer ? complexTypeDefinition.Elements[0] : elementDefinition;
                    childNodes = XPath.Evaluate(
                        parentNode,
                        "./" +
                        (isArrayContainer ? ((elementDefinition.ElementNamespace == null ? string.Empty : ("tns1:")) + elementDefinition.Name + "/") : string.Empty) +
                        (arrayElementDefinition.ElementNamespace == null ? string.Empty : ("tns2:")) + arrayElementDefinition.Name,
                        prefix => prefix == "tns1" ? elementDefinition.ElementNamespace : (prefix == "tns2" ? arrayElementDefinition.ElementNamespace : string.Empty));
                    List<object> values = new List<object>();
                    for (int i = 0; i < childNodes.Count; i++)
                    {
                        values.Add(GetObjectValue(arrayElementDefinition, childNodes[i]));
                    }
                    return values;
                }

                childNodes = XPath.Evaluate(
                    parentNode,
                    "./" + (elementDefinition.ElementNamespace == null ? string.Empty : ("tns:")) + elementDefinition.Name,
                    prefix => prefix == "tns" ? elementDefinition.ElementNamespace : string.Empty);
                return childNodes.Count != 1 ? null : GetObjectValue(elementDefinition, childNodes[0]);
            }

            private object GetObjectValue(IXmlSchemaElementDefinition elementDefinition, XmlNode node)
            {
                XmlNodeList nilNodes = XPath.Evaluate(node, "./@i:nil", prefix => prefix == "i" ? "http://www.w3.org/2001/XMLSchema-instance" : null);
                if (nilNodes.Count == 1 && (nilNodes[0].Value == "true" || nilNodes[0].Value == "1"))
                {
                    return null;
                }

                IXmlSchemaSimpleTypeDefinition simpleTypeDefinition = elementDefinition.Type as IXmlSchemaSimpleTypeDefinition;
                if (simpleTypeDefinition != null)
                {
                    if (node.ChildNodes.Count != 1 || node.ChildNodes[0].NodeType != XmlNodeType.Text)
                    {
                        throw new InvalidOperationException("Expected text node as child for element " + elementDefinition.Name + ".");
                    }
                    string text = node.ChildNodes[0].Value;
                    switch (simpleTypeDefinition.Type)
                    {
                        case XmlBuiltInSimpleType.AnyType:
                        case XmlBuiltInSimpleType.AnyUri:
                        case XmlBuiltInSimpleType.Guid:
                        case XmlBuiltInSimpleType.QName:
                        case XmlBuiltInSimpleType.String:
                        case XmlBuiltInSimpleType.Enum:
                            return DecodeString(text);
                        case XmlBuiltInSimpleType.Base64Binary:
                            return StringUtility.FromBase64ToByteArray(text);
                        case XmlBuiltInSimpleType.Boolean:
                            return text == "true" || text == "1";
                        case XmlBuiltInSimpleType.Byte:
                            return FrameworkUtility.ByteTryParse(text);
                        case XmlBuiltInSimpleType.Char:
                            return (int)DecodeString(text)[0];
                        case XmlBuiltInSimpleType.Decimal:
                            return FrameworkUtility.DecimalTryParse(text);
                        case XmlBuiltInSimpleType.Double:
                            return FrameworkUtility.DoubleTryParse(text);
                        case XmlBuiltInSimpleType.Float:
                            return FrameworkUtility.FloatTryParse(text);
                        case XmlBuiltInSimpleType.Int:
                            return FrameworkUtility.IntTryParse(text);
                        case XmlBuiltInSimpleType.Long:
                            return FrameworkUtility.LongTryParse(text);
                        case XmlBuiltInSimpleType.Short:
                            return FrameworkUtility.ShortTryParse(text);
                        case XmlBuiltInSimpleType.UnsignedByte:
                            return FrameworkUtility.ByteTryParse(text);
                        case XmlBuiltInSimpleType.UnsignedInt:
                            return FrameworkUtility.IntTryParse(text);
                        case XmlBuiltInSimpleType.UnsignedLong:
                            return FrameworkUtility.LongTryParse(text);
                        case XmlBuiltInSimpleType.UnsignedShort:
                            return FrameworkUtility.ShortTryParse(text);
                        case XmlBuiltInSimpleType.DateTime:
                            string[] bits = text.Split(new Regex("[-T:+]", "g"));
                            int timeZoneStart;
                            int milliseconds;
                            if (bits.Length == 9)
                            {
                                timeZoneStart = 7;
                                milliseconds = FrameworkUtility.IntTryParse(bits[6]) ?? 0;
                            }
                            else
                            {
                                timeZoneStart = 6;
                                milliseconds = 0;
                            }
                            JsDate dateTime = new JsDate(int.Parse(bits[0]), int.Parse(bits[1]) - 1, int.Parse(bits[2]), int.Parse(bits[3]), int.Parse(bits[4]), int.Parse(bits[5]), milliseconds);
                            int offsetMinutes = int.Parse(bits[timeZoneStart]) * 60 + int.Parse(bits[timeZoneStart + 1]);
                            bool offsetIsNegative = new Regex("-\\d\\d:\\d\\d$").Test(text);
                            if (offsetIsNegative)
                            {
                                offsetMinutes *= -1;
                            }
                            dateTime.SetMinutes(dateTime.GetMinutes() - offsetMinutes - dateTime.GetTimezoneOffset());
                            return (DateTime)dateTime;
                        case XmlBuiltInSimpleType.Duration:
                            Regex regex = new Regex("([-+]?)P(([0-9]*)Y)?(([0-9]*)M)?(([0-9]*)D)?(T(([0-9]*)H)?(([0-9]*)M)?(([0-9.]*)S)?)?");
                            RegexMatch match = regex.Exec(text);
                            bool durationIsNegative = match[1] == "-";
                            int durationYears = match[3] == null ? 0 : FrameworkUtility.IntTryParse(match[3]) ?? 0;
                            int durationMonths = match[5] == null ? 0 : FrameworkUtility.IntTryParse(match[5]) ?? 0;
                            if (durationYears != 0 || durationMonths != 0)
                            {
                                throw new InvalidOperationException("Durations may not contain years or months.");
                            }
                            int durationDays = match[7] == null ? 0 : FrameworkUtility.IntTryParse(match[7]) ?? 0;
                            int durationHours = match[10] == null ? 0 : FrameworkUtility.IntTryParse(match[10]) ?? 0;
                            int durationMinutes = match[12] == null ? 0 : FrameworkUtility.IntTryParse(match[12]) ?? 0;
                            double durationFractionalSeconds = match[14] == null ? 0 : FrameworkUtility.DoubleTryParse(match[14]) ?? 0;
                            int durationSeconds = Math.Truncate(durationFractionalSeconds);
                            int durationMilliseconds = Math.Truncate(durationFractionalSeconds * 1000) % 1000;
                            if (durationIsNegative)
                            {
                                durationDays *= -1;
                                durationHours *= -1;
                                durationMinutes *= -1;
                                durationSeconds *= -1;
                                durationMilliseconds *= -1;
                            }
                            return new TimeSpan(durationDays, durationHours, durationMinutes, durationSeconds, durationMilliseconds);
                        default:
                            throw UnhandledEnumValueExceptionFactory.Create(simpleTypeDefinition.Type);
                    }
                }

                IXmlSchemaComplexTypeDefinition complexTypeDefinition = elementDefinition.Type as IXmlSchemaComplexTypeDefinition;
                if (complexTypeDefinition == null)
                {
                    throw new InvalidOperationException("Unknown element type.");
                }
                JsDictionary d = new JsDictionary();
                foreach (IXmlSchemaElementDefinition childElementDefinition in complexTypeDefinition.Elements)
                {
                    d[childElementDefinition.Name] = GetObjectRecursive(childElementDefinition, node);
                }
                return d;
            }
        }
    }
}