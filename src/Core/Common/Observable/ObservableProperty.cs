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

        T IProperty<T>.Value
        {
            get { return GetValue(); }
            set { SetValue(value); }
        }

        T IWritableProperty<T>.Value
        {
            set { SetValue(value); }
        }

        T IReadableProperty<T>.Value
        {
            get { return GetValue(); }
        }

        public new T Value
        {
            get { return GetValue(); }
            set { SetValue(value); }
        }
    }
}