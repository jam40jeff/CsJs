using System;
using System.Collections.Generic;
using System.Html;
using System.Xml;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.ViewModel;
using jQueryApi;

namespace MorseCode.CsJs.UI.Controls
{
    // ReSharper disable RedundantNameQualifier
    [ControlParser(typeof(Button.Parser))]
    // ReSharper restore RedundantNameQualifier
    public class Button : Control
    {
        private Element _button;
        private jQueryObject _buttonJQuery;

        protected override void CreateElements()
        {
            _button = Document.CreateElement("button");
            _buttonJQuery = jQuery.FromElement(_button);
            _buttonJQuery.Click(OnButtonClicked);
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

        public event EventHandler ButtonClicked;

        protected void OnButtonClicked(jQueryEvent e)
        {
            if (ButtonClicked != null)
            {
                ButtonClicked(this, EventArgs.Empty);
            }
        }

        public void Bind<T>(IReadableObservableProperty<T> dataContext, Func<T, Action> getClickAction)
        {
            EventHandler updateDataContextEventHandler = null;
            CreateOneWayToSourceBinding(
                dataContext,
                d =>
                {
                    updateDataContextEventHandler = (sender, args) => getClickAction(d)();
                    ButtonClicked += updateDataContextEventHandler;
                },
                d => ButtonClicked -= updateDataContextEventHandler);
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
            protected override Button CreateControl(XmlNode node, Dictionary<string, Control> childControlsById)
            {
                return new Button();
            }

            protected override void ParseAttribute(Button control, string name, string value, Dictionary<string, Control> childControlsById)
            {
                if (name.ToLower() == "text")
                {
                    control.Text = value;
                }
            }
        }
    }
}