using System.Collections.Generic;
using System.Html;
using System.Linq;

namespace MorseCode.CsJs.UI.Controls
{
    public abstract class CompositeControl : Control, ICompositeControl
    {
        private readonly ControlCollection _controls;

        private bool _childControlsCreated;

        protected CompositeControl()
        {
            _controls = new ControlCollection(this);
            _controls.ControlAdded += (sender, args) => ChangeControl(args.Control, true);
            _controls.ControlRemoved += (sender, args) => ChangeControl(args.Control, false);
            _controls.ControlsReset += (sender, args) =>
                {
                    args.OldControls.ForEach(c => ChangeControl(c, false));
                    args.NewControls.ForEach(c => ChangeControl(c, true));
                };
        }

        private void ChangeControl(Control control, bool add)
        {
            Element container = GetChildElementContainerInternal();
            IEnumerable<Element> rootElements = control.GetRootElementsInternal();
            if (rootElements != null)
            {
                foreach (Element element in rootElements)
                {
                    if (add)
                    {
                        container.AppendChild(element);
                    }
                    else
                    {
                        container.RemoveChild(element);
                    }
                }
            }
        }

        public ControlCollection Controls
        {
            get { return _controls; }
        }

        internal override IEnumerable<Element> GetRootElementsInternal()
        {
            EnsureChildControlsCreated();

            return base.GetRootElementsInternal();
        }

        protected void EnsureChildControlsCreated()
        {
            EnsureElementsCreated();

            if (!_childControlsCreated)
            {
                CreateChildControls();
                _childControlsCreated = true;
            }
        }

        protected abstract void CreateChildControls();

        internal Element GetChildElementContainerInternal()
        {
            EnsureElementsCreated();
            return GetChildElementContainer();
        }

        protected abstract Element GetChildElementContainer();

        protected override void OnDispose()
        {
            base.OnDispose();

            List<Control> controls = Controls.ToList();
            Controls.Clear();
            foreach (Control control in controls)
            {
                control.Dispose();
            }
        }
    }
}