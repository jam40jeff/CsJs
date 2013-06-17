using System;
using System.Collections.Generic;
using System.Linq;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.ViewModel;

namespace MorseCode.CsJs.UI.Controls
{
    public class ControlCollection : ObservableCollection<ControlBase>
    {
        private readonly CompositeControlBase _owner;

        public ControlCollection(CompositeControlBase owner)
        {
            _owner = owner;
        }

        protected override void OnItemAdded(ControlBase item)
        {
            base.OnItemAdded(item);

            item.Parent = _owner;

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
            base.OnItemsReset(oldItems, newItems);

            oldItems.ForEach(i => i.Parent = null);
            newItems.ForEach(i => i.Parent = _owner);

            OnControlsReset(new ControlsResetEventArgs(oldItems, newItems));
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

        public ControlBase Control { get { return _control; } }
    }

    public class ControlRemovedEventArgs : EventArgs
    {
        private readonly ControlBase _control;

        public ControlRemovedEventArgs(ControlBase control)
        {
            _control = control;
        }

        public ControlBase Control { get { return _control; } }
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

        public IEnumerable<ControlBase> OldControls { get { return _oldControls; } }
        public IEnumerable<ControlBase> NewControls { get { return _newControls; } }
    }
}
