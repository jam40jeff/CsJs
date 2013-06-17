using System.Collections.Generic;
using System.Xml;

namespace MorseCode.CsJs.UI.Controls
{
    public abstract class ControlParserBase<T> : IControlParser where T : ControlBase
    {
        public ControlBase ParseNode(XmlNode node, Dictionary<string, ControlBase> childControlsById)
        {
            T control = CreateControl(node, childControlsById);
            for (int i = 0; i < node.Attributes.Count; i++)
            {
                XmlAttribute attr = (XmlAttribute)node.Attributes[i];
                ParseAttribute(control, attr.Name, attr.Value, childControlsById);
            }
            return control;
        }

        protected abstract T CreateControl(XmlNode node, Dictionary<string, ControlBase> childControlsById);

        protected abstract void ParseAttribute(T control, string name, string value, Dictionary<string, ControlBase> childControlsById);
    }
}