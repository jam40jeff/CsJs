using System;
using System.Collections.Generic;
using System.Html;
using System.Xml;

namespace MorseCode.CsJs.UI.Controls
{
// ReSharper disable RedundantNameQualifier
    [ControlParser(typeof (Panel.Parser))]
// ReSharper restore RedundantNameQualifier
    public class Panel : CompositeControl
    {
        private readonly Action<ControlCollection> _createChildControls;

        private Element _div;

        private readonly Styles _styles = new Styles();

        public Panel(Action<ControlCollection> createChildControls)
        {
            _createChildControls = createChildControls;
        }

        protected override void CreateChildControls()
        {
            _createChildControls(Controls);
        }

        protected override void CreateElements()
        {
            _div = Document.CreateElement("div");
            _styles.AttachToElement(_div);
        }

        protected override Element GetChildElementContainer()
        {
            return _div;
        }

        protected override IEnumerable<Element> GetRootElements()
        {
            return new[] {_div};
        }

        public Styles Styles
        {
            get { return _styles; }
        }

        public class Parser : ControlParserBase<Panel>
        {
            protected override Panel CreateControl(XmlNode node, Dictionary<string, Control> childControlsById)
            {
                return new Panel(controls => controls.AddRange(MarkupParser.ParseNodes(node.ChildNodes, childControlsById)));
            }

            protected override void ParseAttribute(Panel control, string name, string value, Dictionary<string, Control> childControlsById)
            {
                if (name.ToLower() == "style")
                {
                    control.Styles.ParseStyleString(value);
                }
            }
        }
    }
}