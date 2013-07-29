using System;
using System.Collections.Generic;
using System.Xml;

namespace MorseCode.CsJs.UI.Controls
{
	public static class MarkupParser
	{
		public static IEnumerable<ControlBase> ParseNodes(XmlNodeList nodes, Dictionary<string, ControlBase> childControlsById)
		{
			List<ControlBase> controls = new List<ControlBase>();

			if (nodes != null)
			{
				for (int i = 0; i < nodes.Count; i++)
				{
					XmlNode node = nodes[i];

					if (node.NodeType != XmlNodeType.Element)
					{
						continue;
					}

					Type controlType;
					if (node.Name == "control")
					{
						XmlAttribute typeAttribute = (XmlAttribute)node.Attributes.GetNamedItem("type");
						controlType = Type.GetType(typeAttribute.Value);
						if (controlType == null)
						{
							throw new NotSupportedException("Control with type " + typeAttribute.Value + " not found.");
						}
					}
					else
					{
						controlType = typeof(HtmlControl);
					}
					object[] controlParserAttributes = controlType.GetCustomAttributes(typeof(ControlParserAttribute), false);
					if (controlParserAttributes.Length < 1)
					{
						throw new NotSupportedException("Control with type " + controlType.FullName + " must have a ControlParser defined.");
					}
					if (controlParserAttributes.Length > 1)
					{
						throw new NotSupportedException("Control with type " + controlType.FullName + " must have only one ControlParser defined.");
					}
					ControlParserAttribute controlParserAttribute = (ControlParserAttribute)controlParserAttributes[0];
					IControlParser controlParser = (IControlParser)Activator.CreateInstance(controlParserAttribute.ControlParserType);
					ControlBase control = controlParser.ParseNode(node, childControlsById);
					controls.Add(control);

					if (control != null)
					{
						XmlAttribute idAttribute = (XmlAttribute)node.Attributes.GetNamedItem("controlid");
						if (idAttribute != null)
						{
							childControlsById.Add(idAttribute.Value, control);
						}
					}
				}
			}

			return controls;
		}
	}
}