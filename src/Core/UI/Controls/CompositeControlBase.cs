using System.Collections.Generic;
using System.Html;
using System.Linq;

namespace MorseCode.CsJs.UI.Controls
{
	public abstract class CompositeControlBase : ControlBase, ICompositeControl
	{
		private readonly ControlCollection _controls;

		private bool _childControlsCreated;

		protected CompositeControlBase()
		{
			_controls = new ControlCollection(GetChildElementContainerInternal);
		}

		protected IEnumerable<IControl> Controls
		{
			get { return _controls; }
		}

		public override void AddControlTo(Element container)
		{
			EnsureChildControlsCreated();

			base.AddControlTo(container);
		}

		public override void RemoveControlFrom(Element container)
		{
			EnsureChildControlsCreated();

			base.RemoveControlFrom(container);
		}

		protected void EnsureChildControlsCreated()
		{
			EnsureElementsCreated();

			if (!_childControlsCreated)
			{
				CreateChildControls(_controls);
				_childControlsCreated = true;
			}
		}

		protected abstract void CreateChildControls(ControlCollection controls);

		internal Element GetChildElementContainerInternal()
		{
			EnsureElementsCreated();
			return GetChildElementContainer();
		}

		protected abstract Element GetChildElementContainer();

		protected override void OnDispose()
		{
			base.OnDispose();

			List<ControlBase> controls = _controls.ToList();
			_controls.Clear();
			foreach (ControlBase control in controls)
			{
				control.Dispose();
			}
		}
	}
}