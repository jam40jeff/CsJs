using System;
using System.Collections.Generic;
using System.Html;
using System.Xml;
using MorseCode.CsJs.Common.Observable;
using jQueryApi;

namespace MorseCode.CsJs.UI.Controls
{
    // ReSharper disable RedundantNameQualifier
    [ControlParser(typeof(Button.Parser))]
    // ReSharper restore RedundantNameQualifier
    public class Button : ControlBase
    {
        private Element _button;
        private jQueryObject _buttonJQuery;

        protected override void CreateElements()
        {
            _button = Document.CreateElement("button");
            _buttonJQuery = jQuery.FromElement(_button);
            _buttonJQuery.Click(e => OnClick());
        }

        protected override IEnumerable<Element> GetRootElements()
        {
            return new[] { _button };
        }

        public string Text
        {
            get
            {
                EnsureElementsCreated();
                return _button.InnerText;
            }
            set
            {
                EnsureElementsCreated();
                _button.InnerText = value;
            }
        }

        public bool Visible
        {
            get { return _buttonJQuery.Is(":visible"); }
            set { _button.Style.Display = value ? string.Empty : "none"; }
        }

        public event EventHandler Click;

        protected void OnClick()
        {
            if (Click != null)
            {
                Click(this, EventArgs.Empty);
            }
        }

        public void BindClickAction<T>(IReadableObservableProperty<T> dataContext, Func<T, Action> getClickAction)
        {
            EventHandler updateDataContextEventHandler = null;
            CreateOneWayToSourceBinding(
                dataContext,
                d =>
                {
                    updateDataContextEventHandler = (sender, args) => getClickAction(d)();
                    Click += updateDataContextEventHandler;
                },
                d => Click -= updateDataContextEventHandler);
        }

        public void BindVisible<T>(IReadableObservableProperty<T> dataContext, Func<T, IReadableObservableProperty<bool>> getVisibleProperty)
        {
            EventHandler updateControlEventHandler = null;
            CreateOneWayBinding(
                dataContext,
                d =>
                {
                    Action updateControl = () => Visible = getVisibleProperty(d).Value;
                    updateControlEventHandler = (sender, args) => updateControl();
                    getVisibleProperty(d).Changed += updateControlEventHandler;
                    updateControl();
                },
                d => getVisibleProperty(d).Changed -= updateControlEventHandler);
        }

        public class Parser : ControlParserBase<Button>
        {
            protected override Button CreateControl(XmlNode node, Dictionary<string, ControlBase> childControlsById)
            {
                return new Button();
            }

            protected override void ParseAttributeAfterSkin(string name, string value, Dictionary<string, ControlBase> childControlsById, Action<Action<Button>> addPostSkinAction)
            {
                base.ParseAttributeAfterSkin(name, value, childControlsById, addPostSkinAction);

                if (name.ToLower() == "text")
                {
                    addPostSkinAction(control => control.Text = value);
                }
            }
        }
    }
}