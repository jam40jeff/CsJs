using System;
using System.Collections.Generic;
using System.Html;
using System.Xml;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.ViewModel;

namespace MorseCode.CsJs.UI.Controls
{
// ReSharper disable RedundantNameQualifier
    [ControlParser(typeof(Label.Parser))]
// ReSharper restore RedundantNameQualifier
    public class Label : Control
    {
        private Element _span;

        private readonly Styles _styles = new Styles();

        protected override void CreateElements()
        {
            _span = Document.CreateElement("span");
            _styles.AttachToElement(_span);
        }

        protected override IEnumerable<Element> GetRootElements()
        {
            return new[] { _span };
        }

        public string Text
        {
            get { EnsureElementsCreated(); return _span.InnerText; }
            set { EnsureElementsCreated(); _span.InnerText = value; }
        }

        public string InnerHtml
        {
            get { EnsureElementsCreated(); return _span.InnerHTML; }
            set { EnsureElementsCreated(); _span.InnerHTML = value; }
        }

        public void Bind<T>(IReadableObservableProperty<T> dataContext, Func<T, IReadableObservableProperty<string>> getTextProperty)
        {
            EventHandler updateControlEventHandler = null;
            CreateOneWayBinding(
                dataContext,
                d =>
                {
                    Action updateControl = () => Text = getTextProperty(d).Value ?? string.Empty;
                    updateControlEventHandler = (sender, args) => updateControl();
                    getTextProperty(d).Changed += updateControlEventHandler;
                    updateControl();
                },
                d => getTextProperty(d).Changed -= updateControlEventHandler);
        }

        public Styles Styles
        {
            get { return _styles; }
        }

        public class Parser : ControlParserBase<Label>
        {
            protected override Label CreateControl(XmlNode node, Dictionary<string, Control> childControlsById)
            {
                return new Label();
            }

            protected override void ParseAttribute(Label control, string name, string value, Dictionary<string, Control> childControlsById)
            {
                if (name.ToLower() == "style")
                {
                    control.Styles.ParseStyleString(value);
                }
            }
        }
    }
}
