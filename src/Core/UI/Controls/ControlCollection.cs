using System;
using System.Collections.Generic;
using System.Linq;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.ViewModel;

namespace MorseCode.CsJs.UI.Controls
{
    public class ControlCollection : ObservableCollection<Control>
    {
        private readonly CompositeControl _owner;

        public ControlCollection(CompositeControl owner)
        {
            _owner = owner;
        }

        protected override void OnItemAdded(Control item)
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

        protected override void OnItemRemoved(Control item)
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

        protected override void OnItemsReset(IEnumerable<Control> oldItems, IEnumerable<Control> newItems)
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
        private readonly Control _control;

        public ControlAddedEventArgs(Control control)
        {
            _control = control;
        }

        public Control Control { get { return _control; } }
    }

    public class ControlRemovedEventArgs : EventArgs
    {
        private readonly Control _control;

        public ControlRemovedEventArgs(Control control)
        {
            _control = control;
        }

        public Control Control { get { return _control; } }
    }

    public class ControlsResetEventArgs : EventArgs
    {
        private readonly IEnumerable<Control> _oldControls;
        private readonly IEnumerable<Control> _newControls;

        public ControlsResetEventArgs(IEnumerable<Control> oldControls, IEnumerable<Control> newControls)
        {
            _oldControls = oldControls;
            _newControls = newControls;
        }

        public IEnumerable<Control> OldControls { get { return _oldControls; } }
        public IEnumerable<Control> NewControls { get { return _newControls; } }
    }
}
