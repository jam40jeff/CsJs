namespace MorseCode.CsJs.ViewModel
{
    public class ReadOnlyProperty<T> : ObservablePropertyBase<T>
    {
        public ReadOnlyProperty(T value)
        {
            SetInitialValue(value);
        }
    }
}