using System;
using System.Collections.Generic;
using System.Html;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.UI.Controls
{
    public abstract class ControlBase : IControl
    {
        private readonly List<IBinding> _bindings = new List<IBinding>();

        private bool _isSetup;
        private bool _elementsCreated;
        private bool _isSkinApplied;

        private ISkin _skin;
        private string _skinCategory;

        private string _id;

        private readonly List<Action> _postSkinActions = new List<Action>();
        private CompositeControlBase _parent;

        internal CompositeControlBase Parent
        {
            get { return _parent; }
            set
            {
                if (_parent != null && value != null)
                {
                    _parent.RemoveChildControl(this);
                }
                _parent = value;
            }
        }

        internal void AddPostSkinAction<T>(Action<T> postSkinAction) where T : ControlBase
        {
            if (_isSkinApplied)
            {
                postSkinAction((T)this);
            }
            else
            {
                _postSkinActions.Add(() => postSkinAction((T)this));
            }
        }

        protected void EnsureSetup()
        {
            if (!_isSetup)
            {
                Setup();
                _isSetup = true;
            }
        }

        protected virtual void Setup()
        {
            EnsureElementsCreated();
            EnsureSkinApplied();
        }

        protected void EnsureElementsCreated()
        {
            if (!_elementsCreated)
            {
                CreateElements();
                _elementsCreated = true;
            }
        }

        protected abstract void CreateElements();

        public ISkin Skin
        {
            get { return _skin; }
            set
            {
                if (_isSkinApplied)
                {
                    throw new InvalidOperationException("Skin cannot be changed after it has been applied.");
                }
                _skin = value;
            }
        }

        public string Id
        {
            get { return _id; }
            set
            {
                if (_isSkinApplied)
                {
                    throw new InvalidOperationException("Id cannot be changed after it has been applied.");
                }
                _id = value;
            }
        }

        public string SkinCategory
        {
            get { return _skinCategory; }
            set
            {
                if (_isSkinApplied)
                {
                    throw new InvalidOperationException("SkinCategory cannot be changed after it has been applied.");
                }
                _skinCategory = value;
            }
        }

        private ISkin GetEffectiveSkin()
        {
            return Skin ?? Application.Current.Skin;
        }

        protected void EnsureSkinApplied()
        {
            if (!_isSkinApplied)
            {
                OnBeforeSkin();

                ISkin skin = GetEffectiveSkin();
                if (skin != null)
                {
                    skin.Apply(this);
                }

                OnAfterSkin();

                foreach (Action postSkinAction in _postSkinActions)
                {
                    postSkinAction();
                }

                OnAfterPostSkinMarkup();

                _isSkinApplied = true;
            }
        }

        public event EventHandler BeforeSkin;

        protected virtual void OnBeforeSkin()
        {
            EventHandler handler = BeforeSkin;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public event EventHandler AfterSkin;

        protected virtual void OnAfterSkin()
        {
            EventHandler handler = AfterSkin;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public event EventHandler AfterPostSkinMarkup;

        protected virtual void OnAfterPostSkinMarkup()
        {
            EventHandler handler = AfterPostSkinMarkup;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public virtual void AddControlTo(Element container)
        {
            EnsureSetup();
            EnsureElementsCreated();
            IEnumerable<Element> rootElements = GetRootElements();
            if (rootElements != null)
            {
                foreach (Element element in rootElements)
                {
                    container.AppendChild(element);
                }
            }
        }

        public virtual void RemoveControlFrom(Element container)
        {
            EnsureSetup();
            EnsureElementsCreated();
            IEnumerable<Element> rootElements = GetRootElements();
            if (rootElements != null)
            {
                foreach (Element element in rootElements)
                {
                    container.RemoveChild(element);
                }
            }
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