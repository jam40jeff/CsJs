using System;
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
                ParseAttributeBeforeSkin(control, attr.Name, attr.Value, childControlsById);
                ParseAttributeAfterSkin(attr.Name, attr.Value, childControlsById, control.AddPostSkinAction);
            }
            return control;
        }

        protected abstract T CreateControl(XmlNode node, Dictionary<string, ControlBase> childControlsById);

        protected virtual void ParseAttributeBeforeSkin(T control, string name, string value, Dictionary<string, ControlBase> childControlsById)
        {
            if (name == "id")
            {
                control.Id = value;
            }
            else if (name == "skincategory")
            {
                control.SkinCategory = value;
            }
        }

        protected virtual void ParseAttributeAfterSkin(string name, string value, Dictionary<string, ControlBase> childControlsById, Action<Action<T>> addPostSkinAction)
        {
        }
    }
}