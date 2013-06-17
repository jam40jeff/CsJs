using System;
using System.Collections.Generic;
using System.Html;
using System.Xml;

namespace MorseCode.CsJs.UI.Controls
{
// ReSharper disable RedundantNameQualifier
    [ControlParser(typeof(HtmlControl.Parser))]
// ReSharper restore RedundantNameQualifier
    public class HtmlControl : CompositeControlBase
    {
        private readonly string _tagName;
        private readonly Action<ControlCollection> _createChildControls;

        private Element _element;

        private readonly Styles _styles = new Styles();

        public HtmlControl(string tagName, Action<ControlCollection> createChildControls)
        {
            _tagName = tagName;
            _createChildControls = createChildControls;
        }

        protected override void CreateChildControls()
        {
            _createChildControls(Controls);
        }

        protected override void CreateElements()
        {
            _element = Document.CreateElement(_tagName);
            _styles.AttachToElement(_element);
        }

        protected override Element GetChildElementContainer()
        {
            return _element;
        }

        protected override IEnumerable<Element> GetRootElements()
        {
            return new[] { _element };
        }

        public Styles Styles
        {
            get { return _styles; }
        }

        public class Parser : ControlParserBase<HtmlControl>
        {
            protected override HtmlControl CreateControl(XmlNode node, Dictionary<string, ControlBase> childControlsById)
            {
                return new HtmlControl(node.Name, controls => controls.AddRange(MarkupParser.ParseNodes(node.ChildNodes, childControlsById)));
            }

            protected override void ParseAttribute(HtmlControl control, string name, string value, Dictionary<string, ControlBase> childControlsById)
            {
                if (name.ToLower() == "style")
                {
                    control.Styles.ParseStyleString(value);
                }
            }
        }
    }
}