using System;
using System.Collections.Generic;
using System.Html;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.UI.Controls
{
    public abstract class PlaceHolderCompositeControlBase<T> : CompositeControlBase
    {
        private Element _tempElement;

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

        public void BindDataContext<TDataContext>(IReadableObservableProperty<TDataContext> dataContext, Func<TDataContext, T> getDataContext)
        {
            EnsureChildControlsCreated();

            BindControls(new ReadOnlyProperty<T>(getDataContext(dataContext.Value)));
        }

        public void BindDataContext<TDataContext>(IReadableObservableProperty<TDataContext> dataContext, Func<TDataContext, IReadableObservableProperty<T>> getDataContext)
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

        public override CompositeControlBase Parent
        {
            get { return base.Parent; }
            set
            {
                EnsureChildControlsCreated();

                Element oldContainer = GetChildElementContainerInternal();

                base.Parent = value;

                Element container = GetChildElementContainerInternal();

                if (ReferenceEquals(oldContainer, container))
                {
                    return;
                }

                foreach (ControlBase control in Controls)
                {
                    IEnumerable<Element> children = control.GetRootElementsInternal();
                    foreach (Element child in children)
                    {
                        container.AppendChild(child);
                        if (oldContainer.Contains(child))
                        {
                            oldContainer.RemoveChild(child);
                        }
                    }
                }
            }
        }
    }
}