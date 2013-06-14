namespace MorseCode.CsJs.ViewModel
{
    public interface IObservableProperty<T> : IReadableObservableProperty<T>, IWritableProperty<T>
    {
        new T Value { get; set; }
    }
}