using System;
using System.Collections.Generic;
using System.Html;
using System.Xml;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.UI.Controls
{
    // ReSharper disable RedundantNameQualifier
    [ControlParser(typeof(Label.Parser))]
    // ReSharper restore RedundantNameQualifier
    public class Label : ControlBase
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
            get
            {
                EnsureElementsCreated();
                return _span.InnerText;
            }
            set
            {
                EnsureElementsCreated();
                _span.InnerText = value;
            }
        }

        public string InnerHtml
        {
            get
            {
                EnsureElementsCreated();
                return _span.InnerHTML;
            }
            set
            {
                EnsureElementsCreated();
                _span.InnerHTML = value;
            }
        }

        public void BindText<T>(IReadableObservableProperty<T> dataContext, Func<T, IReadableObservableProperty<string>> getTextProperty)
        {
            BindText(dataContext, getTextProperty, v => v);
        }

        public void BindText<T, TProperty>(IReadableObservableProperty<T> dataContext, Func<T, IReadableObservableProperty<TProperty>> getTextProperty, Func<TProperty, string> formatString)
        {
            EventHandler updateControlEventHandler = null;
            CreateOneWayBinding(
                dataContext,
                d =>
                {
                    Action updateControl = () => Text = formatString(getTextProperty(d).Value) ?? string.Empty;
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
            protected override Label CreateControl(XmlNode node, Dictionary<string, ControlBase> childControlsById)
            {
                return new Label();
            }

            protected override void ParseAttributeAfterSkin(string name, string value, Dictionary<string, ControlBase> childControlsById, Action<Action<Label>> addPostSkinAction)
            {
                base.ParseAttributeAfterSkin(name, value, childControlsById, addPostSkinAction);

                if (name.ToLower() == "style")
                {
                    addPostSkinAction(control => control.Styles.ParseStyleString(value));
                }
                else if (name.ToLower() == "text")
                {
                    addPostSkinAction(control => control.Text = value);
                }
            }
        }
    }
}