using System;
using System.Collections.Generic;
using System.Html;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.UI.Controls
{
    public abstract class PlaceHolderCompositeControlBase : CompositeControlBase
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
            throw new NotSupportedException();
        }

        public override void AddControlTo(Element container)
        {
            SwitchContainer(container, _tempElement);
        }

        public override void RemoveControlFrom(Element container)
        {
            SwitchContainer(_tempElement, container);
        }

        private void SwitchContainer(Element container, Element oldContainer)
        {
            foreach (ControlBase control in Controls)
            {
                control.RemoveControlFrom(oldContainer);
                control.AddControlTo(container);
            }
        }
    }

    public abstract class PlaceHolderCompositeControlBase<T> : PlaceHolderCompositeControlBase
    {
        public void BindDataContext<TDataContext>(IReadableObservableProperty<TDataContext> dataContext, Func<TDataContext, T> getDataContext)
        {
            EnsureChildControlsCreated();

            BindControls(new ReadOnlyProperty<T>(getDataContext(dataContext.Value)));
        }

        public void BindDataContext<TDataContext>(IReadableObservableProperty<TDataContext> dataContext, Func<TDataContext, IReadableObservableProperty<T>> getDataContext)
        {
            EnsureChildControlsCreated();

            ObservableProperty<T> thisDataContext = new ObservableProperty<T>(getDataContext(dataContext.Value).Value);

            EventHandler updateControlEventHandler = null;
            CreateOneWayBinding(
                dataContext,
                d =>
                {
                    Action updateControl = () => thisDataContext.Value = getDataContext(d).Value;
                    updateControlEventHandler = (sender, args) => updateControl();
                    getDataContext(d).Changed += updateControlEventHandler;
                    updateControl();
                },
                d => getDataContext(d).Changed -= updateControlEventHandler);

            BindControls(thisDataContext);
        }

        protected abstract void BindControls(IReadableObservableProperty<T> dataContext);
    }
}