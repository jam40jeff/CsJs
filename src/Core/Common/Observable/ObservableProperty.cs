namespace MorseCode.CsJs.Common.Observable
{
    public class ObservableProperty<T> : ObservablePropertyBase<T>, IObservableProperty<T>
    {
        public ObservableProperty()
        {
        }

        public ObservableProperty(T value)
        {
            SetInitialValue(value);
        }

        T IObservableProperty<T>.Value
        {
            get { return GetValue(); }
            set { SetValue(value); }
        }

        T IWritableProperty<T>.Value
        {
            set { SetValue(value); }
        }

        public new T Value
        {
            get { return GetValue(); }
            set { SetValue(value); }
        }
    }
}