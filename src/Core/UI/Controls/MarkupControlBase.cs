using System;
using System.Collections.Generic;
using System.Html;
using System.Xml;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.ViewModel;
using jQueryApi;

namespace MorseCode.CsJs.UI.Controls
{
    public abstract class MarkupControlBase<T> : CompositeControl
    {
        private Element _tempElement;
        private Dictionary<string, Control> _childControlsById;

        protected override sealed void CreateElements()
        {
            _tempElement = Document.CreateElement("div");
        }

        protected override sealed Element GetChildElementContainer()
        {
            return Parent == null ? _tempElement : Parent.GetChildElementContainerInternal();
        }

        protected override sealed IEnumerable<Element> GetRootElements()
        {
            return null;
        }

        protected override sealed void CreateChildControls()
        {
            _childControlsById = new Dictionary<string, Control>();
            XmlDocument document = jQuery.ParseXml("<root>" + Markup + "</root>");
            Controls.AddRange(MarkupParser.ParseNodes(document.DocumentElement.ChildNodes, _childControlsById));
            SetupControls();
        }

        protected TControl FindControl<TControl>(string id) where TControl : Control
        {
            Control control = null;
            if (_childControlsById != null)
            {
                _childControlsById.TryGetValue(id, out control);
            }
            return control as TControl;
        }

        protected abstract string Markup { get; }

        protected abstract void SetupControls();

        public void Bind<TDataContext>(IReadableObservableProperty<TDataContext> dataContext, Func<TDataContext, T> getDataContext)
        {
            EnsureChildControlsCreated();

            BindControls(new ReadOnlyProperty<T>(getDataContext(dataContext.Value)));
        }

        public void Bind<TDataContext>(IReadableObservableProperty<TDataContext> dataContext, Func<TDataContext, IReadableObservableProperty<T>> getDataContext)
        {
            EnsureChildControlsCreated();

            EventHandler updateControlEventHandler = null;
            CreateOneWayBinding(
                dataContext,
                d =>
                {
                    Action updateControl = () => BindControls(getDataContext(d));
                    updateControlEventHandler = (sender, args) => updateControl();
                    getDataContext(d).Changed += updateControlEventHandler;
                    updateControl();
                },
                d => getDataContext(d).Changed -= updateControlEventHandler);
        }

        protected abstract void BindControls(IReadableObservableProperty<T> dataContext);

        public override CompositeControl Parent
        {
            get { return base.Parent; }
            set
            {
                EnsureChildControlsCreated();

                base.Parent = value;

                if (value != null)
                {
                    Element container = value.GetChildElementContainerInternal();
                    List<Element> children = new List<Element>();
                    foreach (Element child in _tempElement.Children)
                    {
                        children.Add(child);
                    }
                    foreach (Element child in children)
                    {
                        container.AppendChild(child);
                    }
                    while (_tempElement.Children.Length > 0)
                    {
                        _tempElement.RemoveChild(_tempElement.Children[0]);
                    }
                }
            }
        }
    }
}