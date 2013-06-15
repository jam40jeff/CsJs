namespace MorseCode.CsJs.Common.Observable
{
    public interface IObservableProperty<T> : IReadableObservableProperty<T>, IWritableProperty<T>
    {
        new T Value { get; set; }
    }
}