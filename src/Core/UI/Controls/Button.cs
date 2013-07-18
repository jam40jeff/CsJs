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

        private IBinding _clickActionBinding;
        private IBinding _textBinding;
        private IBinding _visibleBinding;

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

        private string Text
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

        private bool Visible
        {
            get { return _buttonJQuery.Is(":visible"); }
            set { _button.Style.Display = value ? string.Empty : "none"; }
        }

        private event EventHandler Click;

        protected void OnClick()
        {
            if (Click != null)
            {
                Click(this, EventArgs.Empty);
            }
        }

        public void BindClickAction<T>(IReadableObservableProperty<T> dataContext, Func<T, Action> getClickAction)
        {
            EnsureUnbound(_clickActionBinding);

            EventHandler updateDataContextEventHandler = null;
            _clickActionBinding = CreateOneWayToSourceBinding(
                dataContext,
                d =>
                {
                    updateDataContextEventHandler = (sender, args) => getClickAction(d)();
                    Click += updateDataContextEventHandler;
                },
                d => Click -= updateDataContextEventHandler);
            AddBinding(_clickActionBinding);
        }

        public void SetText(string text)
        {
            EnsureUnbound(_textBinding);

            _textBinding = StaticBinding.Instance;
            Text = text;
        }

        public void BindText<T>(IReadableObservableProperty<T> dataContext, Func<T, IReadableObservableProperty<string>> getTextProperty)
        {
            BindText(dataContext, getTextProperty, v => v);
        }

        public void BindText<T, TProperty>(IReadableObservableProperty<T> dataContext, Func<T, IReadableObservableProperty<TProperty>> getTextProperty, Func<TProperty, string> formatString)
        {
            EnsureUnbound(_textBinding);

            EventHandler updateControlEventHandler = null;
            _textBinding = CreateOneWayBinding(
                dataContext,
                d =>
                {
                    Action updateControl = () => Text = formatString(getTextProperty(d).Value) ?? string.Empty;
                    updateControlEventHandler = (sender, args) => updateControl();
                    getTextProperty(d).Changed += updateControlEventHandler;
                    updateControl();
                },
                d => getTextProperty(d).Changed -= updateControlEventHandler);
            AddBinding(_textBinding);
        }

        public void BindVisible<T>(IReadableObservableProperty<T> dataContext, Func<T, IReadableObservableProperty<bool>> getVisibleProperty)
        {
            EnsureUnbound(_visibleBinding);

            EventHandler updateControlEventHandler = null;
            _visibleBinding = CreateOneWayBinding(
                dataContext,
                d =>
                {
                    Action updateControl = () => Visible = getVisibleProperty(d).Value;
                    updateControlEventHandler = (sender, args) => updateControl();
                    getVisibleProperty(d).Changed += updateControlEventHandler;
                    updateControl();
                },
                d => getVisibleProperty(d).Changed -= updateControlEventHandler);
            AddBinding(_visibleBinding);
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
                    addPostSkinAction(control => control.SetText(value));
                }
            }
        }
    }
}