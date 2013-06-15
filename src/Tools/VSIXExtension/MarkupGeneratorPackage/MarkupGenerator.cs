using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using MorseCode.CsJs.UI.Controls;

namespace MorseCode.CsJs.MarkupGeneratorPackage
{
    internal class MarkupGenerator : IVsSingleFileGenerator
    {
        public int DefaultExtension(out string pbstrDefaultExtension)
        {
            pbstrDefaultExtension = ".generated.cs";
            return VSConstants.S_OK;
        }

        public int Generate(string wszInputFilePath, string bstrInputFileContents, string wszDefaultNamespace, IntPtr[] rgbOutputFileContents, out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
        {
            string contentsString = GetContents(wszInputFilePath, bstrInputFileContents, wszDefaultNamespace, pGenerateProgress);
            byte[] contents = Encoding.UTF8.GetBytes(contentsString);
            int contentsLength = contents.Length;
            pcbOutput = Convert.ToUInt32(contentsLength);
            rgbOutputFileContents[0] = Marshal.AllocCoTaskMem(contentsLength);
            Marshal.Copy(contents, 0, rgbOutputFileContents[0], contentsLength);
            return VSConstants.S_OK;
        }

        private string GetContents(string inputFilePath, string inputFileContents, string defaultNamespace, IVsGeneratorProgress progress)
        {
            progress.Progress(0, 100);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<root>" + inputFileContents + "</root>");
            XmlNode registerNode = doc.SelectSingleNode("/root/declare");
            string fullClassName = defaultNamespace + "." + Path.GetFileNameWithoutExtension(inputFilePath);
            if (registerNode != null)
            {
                XmlAttribute classNameAttribute = registerNode.Attributes == null ? null : registerNode.Attributes["classname"];
                if (classNameAttribute != null)
                {
                    fullClassName = classNameAttribute.Value;
                }
            }
            int lastDot = fullClassName.LastIndexOf(".", StringComparison.Ordinal);
            string ns = fullClassName.Substring(0, lastDot);
            string className = fullClassName.Substring(lastDot + 1);
            StringBuilder contents = new StringBuilder();
            contents.AppendLine("namespace " + ns);
            contents.AppendLine("{");
            contents.AppendLine("\tpublic abstract class " + className + "Base<T> : global::" + typeof (MarkupControlBase<>).Namespace + ".MarkupControlBase<T>");
            contents.AppendLine("\t{");
            IEnumerable<ElementTypeAndId> elements = ((IEnumerable) doc.SelectNodes("/root//@controlid") ?? new XmlAttribute[0]).Cast<XmlAttribute>().Select(a =>
                {
                    string id = a.Value;
                    XmlElement element = a.OwnerElement;

                    if (element == null)
                    {
                        return null;
                    }

                    if (element.Name == "control")
                    {
                        XmlAttribute typeAttribute = element.Attributes["type"];
                        if (typeAttribute == null)
                        {
                            return null;
                        }
                        return new ElementTypeAndId(typeAttribute.Value, id);
                    }

                    return new ElementTypeAndId(typeof (HtmlControl).FullName, id);
                });
            foreach (ElementTypeAndId element in elements)
            {
                if (element == null)
                {
                    continue;
                }

                contents.AppendLine("\t\tprotected global::" + element.Type + " @" + element.Id + " { get { return FindControl<global::" + element.Type + ">(\"" + element.Id + "\"); } }");
            }
            contents.AppendLine();
            contents.AppendLine("\t\tprotected override string Markup");
            contents.AppendLine("\t\t{");
            contents.AppendLine("\t\t\tget");
            contents.AppendLine("\t\t\t{");
            contents.AppendLine("\t\t\t\treturn");
            contents.Append("@\"");
            contents.Append(inputFileContents.Replace("\"", "\"\""));
            contents.AppendLine("\";");
            contents.AppendLine("\t\t\t}");
            contents.AppendLine("\t\t}");
            contents.AppendLine("\t}");
            contents.AppendLine("}");
            progress.Progress(100, 100);
            return contents.ToString();
        }

        private class ElementTypeAndId
        {
            private readonly string _type;
            private readonly string _id;

            public ElementTypeAndId(string type, string id)
            {
                _type = type;
                _id = id;
            }

            public string Type
            {
                get { return _type; }
            }

            public string Id
            {
                get { return _id; }
            }
        }
    }
}