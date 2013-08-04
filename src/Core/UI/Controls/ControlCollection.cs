using System;
using System.Collections.Generic;
using System.Html;
using System.Linq;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.UI.Controls
{
	public class ControlCollection : ObservableCollection<ControlBase>
	{
		private readonly Func<Element> _childElementContainer;

		public ControlCollection(Func<Element> childElementContainer)
		{
			_childElementContainer = childElementContainer;
		}

		internal Element GetChildElementContainer()
		{
			return _childElementContainer();
		}

		protected override void OnItemAdded(ControlBase item)
		{
			base.OnItemAdded(item);

			item.Parent = this;
			item.AddControlTo(GetChildElementContainer());

			OnControlAdded(new ControlAddedEventArgs(item));
		}

		protected virtual void OnControlAdded(ControlAddedEventArgs e)
		{
			if (ControlAdded != null)
			{
				ControlAdded(this, e);
			}
		}

		public event EventHandler<ControlAddedEventArgs> ControlAdded;

		protected override void OnItemRemoved(ControlBase item)
		{
			base.OnItemRemoved(item);

			item.Parent = null;
			item.RemoveControlFrom(GetChildElementContainer());

			OnControlRemoved(new ControlRemovedEventArgs(item));
		}

		protected virtual void OnControlRemoved(ControlRemovedEventArgs e)
		{
			if (ControlRemoved != null)
			{
				ControlRemoved(this, e);
			}
		}

		public event EventHandler<ControlRemovedEventArgs> ControlRemoved;

		protected override void OnItemsReset(IEnumerable<ControlBase> oldItems, IEnumerable<ControlBase> newItems)
		{
			List<ControlBase> oldItemsList = oldItems.ToList();
			List<ControlBase> newItemsList = newItems.ToList();

			base.OnItemsReset(oldItemsList, newItemsList);

			Element childElementContainer = GetChildElementContainer();
			oldItemsList.ForEach(i =>
				{
					i.Parent = null;
					i.RemoveControlFrom(childElementContainer);
				});
			newItemsList.ForEach(i =>
				{
					i.Parent = this;
					i.AddControlTo(childElementContainer);
				});

			OnControlsReset(new ControlsResetEventArgs(oldItemsList, newItemsList));
		}

		protected virtual void OnControlsReset(ControlsResetEventArgs e)
		{
			if (ControlsReset != null)
			{
				ControlsReset(this, e);
			}
		}

		public event EventHandler<ControlsResetEventArgs> ControlsReset;
	}

	public class ControlAddedEventArgs : EventArgs
	{
		private readonly ControlBase _control;

		public ControlAddedEventArgs(ControlBase control)
		{
			_control = control;
		}

		public ControlBase Control
		{
			get { return _control; }
		}
	}

	public class ControlRemovedEventArgs : EventArgs
	{
		private readonly ControlBase _control;

		public ControlRemovedEventArgs(ControlBase control)
		{
			_control = control;
		}

		public ControlBase Control
		{
			get { return _control; }
		}
	}

	public class ControlsResetEventArgs : EventArgs
	{
		private readonly IEnumerable<ControlBase> _oldControls;
		private readonly IEnumerable<ControlBase> _newControls;

		public ControlsResetEventArgs(IEnumerable<ControlBase> oldControls, IEnumerable<ControlBase> newControls)
		{
			_oldControls = oldControls;
			_newControls = newControls;
		}

		public IEnumerable<ControlBase> OldControls
		{
			get { return _oldControls; }
		}

		public IEnumerable<ControlBase> NewControls
		{
			get { return _newControls; }
		}
	}
}