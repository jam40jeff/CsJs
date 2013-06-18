using System;
using System.Collections.Generic;
using System.Html;
using System.Xml;
using MorseCode.CsJs.Common.Observable;
using jQueryApi;

namespace MorseCode.CsJs.UI.Controls
{
    // ReSharper disable RedundantNameQualifier
    [ControlParser(typeof (Panel.Parser))]
    // ReSharper restore RedundantNameQualifier
    public class Panel : CompositeControlBase
    {
        private readonly Action<ControlCollection> _createChildControls;

        private Element _div;
        private jQueryObject _divJQuery;

        private readonly Styles _styles = new Styles();

        private bool _useSlideVisibilityTransition;

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
            _divJQuery = jQuery.FromElement(_div);
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

        public bool Visible
        {
            get { return _divJQuery.Is(":visible"); }
            set
            {
                if (_useSlideVisibilityTransition)
                {
                    if (value)
                    {
                        _divJQuery.SlideDown(200);
                    }
                    else
                    {
                        _divJQuery.SlideUp(200);
                    }
                }
                else
                {
                    _div.Style.Display = value ? string.Empty : "none";
                }
            }
        }

        public bool UseSlideVisibilityTransition
        {
            get { return _useSlideVisibilityTransition; }
            set { _useSlideVisibilityTransition = value; }
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

        public class Parser : ControlParserBase<Panel>
        {
            protected override Panel CreateControl(XmlNode node, Dictionary<string, ControlBase> childControlsById)
            {
                return new Panel(controls => controls.AddRange(MarkupParser.ParseNodes(node.ChildNodes, childControlsById)));
            }

            protected override void ParseAttribute(Panel control, string name, string value, Dictionary<string, ControlBase> childControlsById)
            {
                if (name.ToLower() == "style")
                {
                    control.Styles.ParseStyleString(value);
                }
                else if (name.ToLower() == "useslidevisibilitytransition")
                {
                    control.UseSlideVisibilityTransition = value != null && value.ToLower() == "true";
                }
            }
        }
    }
}