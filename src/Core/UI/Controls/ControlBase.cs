using System;
using System.Collections.Generic;
using System.Html;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.UI.Controls
{
    public abstract class ControlBase : IControl
    {
        private readonly List<IBinding> _bindings = new List<IBinding>();

        private bool _elementsCreated;

        public virtual CompositeControlBase Parent { get; set; }

        protected void EnsureElementsCreated()
        {
            if (!_elementsCreated)
            {
                CreateElements();
                _elementsCreated = true;
            }
        }

        protected abstract void CreateElements();

        internal virtual IEnumerable<Element> GetRootElementsInternal()
        {
            EnsureElementsCreated();
            return GetRootElements();
        }

        protected abstract IEnumerable<Element> GetRootElements();

        protected void CreateOneWayBinding<T>(IReadableObservableProperty<T> dataContext, Action<T> bindToDataContext, Action<T> unbindFromDataContext)
        {
            _bindings.Add(new Binding<T>(dataContext, bindToDataContext, unbindFromDataContext, d => { }, d => { }));
        }

        protected void CreateOneWayToSourceBinding<T>(IReadableObservableProperty<T> dataContext, Action<T> bindToControl, Action<T> unbindFromControl)
        {
            _bindings.Add(new Binding<T>(dataContext, d => { }, d => { }, bindToControl, unbindFromControl));
        }

        protected void CreateTwoWayBinding<T>(IReadableObservableProperty<T> dataContext, Action<T> bindToDataContext, Action<T> unbindFromDataContext, Action<T> bindToControl, Action<T> unbindFromControl)
        {
            _bindings.Add(new Binding<T>(dataContext, bindToDataContext, unbindFromDataContext, bindToControl, unbindFromControl));
        }

        protected void AddBinding(IBinding binding)
        {
            _bindings.Add(binding);
        }

        public void Dispose()
        {
            _bindings.ForEach(b => b.Dispose());
            _bindings.Clear();

            OnDispose();
        }

        protected virtual void OnDispose()
        {
        }
    }
}