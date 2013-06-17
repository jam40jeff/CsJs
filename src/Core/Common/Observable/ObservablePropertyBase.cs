using System;

namespace MorseCode.CsJs.Common.Observable
{
    public abstract class ObservablePropertyBase<T> : IReadableObservableProperty<T>
    {
        private T _value;

        public T Value
        {
            get { return GetValue(); }
        }

        protected T GetValue()
        {
            return _value;
        }

        protected void SetInitialValue(T value)
        {
            _value = value;
        }

        protected void SetValue(T value)
        {
            if ((object) value != (object) _value)
            {
                OnBeforeValueChanged();
                _value = value;
                OnValueChanged();
            }
        }

        public event EventHandler BeforeChanged;

        protected void OnBeforeValueChanged()
        {
            if (BeforeChanged != null)
            {
                BeforeChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler Changed;

        protected void OnValueChanged()
        {
            if (Changed != null)
            {
                Changed(this, EventArgs.Empty);
            }
        }

        public override string ToString()
        {
            return ReferenceEquals(Value, null) ? null : Value.ToString();
        }
    }
}