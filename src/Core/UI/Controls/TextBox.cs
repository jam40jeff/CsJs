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
    [ControlParser(typeof (TextBox.Parser))]
    // ReSharper restore RedundantNameQualifier
    public class TextBox : Control
    {
        private InputElement _input;

        protected override void CreateElements()
        {
            _input = (InputElement) Document.CreateElement("input");
            _input.Type = "text";
            jQuery.FromElement(_input).Keyup(OnTextChanging);
            jQuery.FromElement(_input).Change(OnTextChanged);
        }

        protected override IEnumerable<Element> GetRootElements()
        {
            return new[] {_input};
        }

        public string Text
        {
            get
            {
                EnsureElementsCreated();
                return _input.Value;
            }
            set
            {
                EnsureElementsCreated();
                _input.Value = value;
            }
        }

        public event EventHandler TextChanging;

        protected void OnTextChanging(jQueryEvent e)
        {
            if (TextChanging != null)
            {
                TextChanging(this, EventArgs.Empty);
            }
        }

        public event EventHandler TextChanged;

        protected void OnTextChanged(jQueryEvent e)
        {
            if (TextChanged != null)
            {
                TextChanged(this, EventArgs.Empty);
            }
        }

        public void Bind<T>(IReadableObservableProperty<T> dataContext, Func<T, IObservableProperty<string>> getTextProperty, bool updateWhileChanging)
        {
            EventHandler updateDataContextEventHandler = null;
            EventHandler updateControlEventHandler = null;
            CreateTwoWayBinding(
                dataContext,
                d =>
                    {
                        Action updateControl = () => Text = getTextProperty(d).Value ?? string.Empty;
                        updateControlEventHandler = (sender, args) => updateControl();
                        getTextProperty(d).Changed += updateControlEventHandler;
                        updateControl();
                    },
                d => getTextProperty(d).Changed -= updateControlEventHandler,
                d =>
                    {
                        updateDataContextEventHandler = (sender, args) => getTextProperty(d).Value = Text;
                        if (updateWhileChanging)
                        {
                            TextChanging += updateDataContextEventHandler;
                        }
                        else
                        {
                            TextChanged += updateDataContextEventHandler;
                        }
                    },
                d =>
                    {
                        if (updateWhileChanging)
                        {
                            TextChanging -= updateDataContextEventHandler;
                        }
                        else
                        {
                            TextChanged -= updateDataContextEventHandler;
                        }
                    });
        }


        public class Parser : ControlParserBase<TextBox>
        {
            protected override TextBox CreateControl(XmlNode node, Dictionary<string, Control> childControlsById)
            {
                return new TextBox();
            }

            protected override void ParseAttribute(TextBox control, string name, string value, Dictionary<string, Control> childControlsById)
            {
            }
        }
    }
}