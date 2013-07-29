namespace MorseCode.CsJs.Common.Observable
{
    public interface IReadableObservableProperty : IReadableProperty, IObservable
    {
    }

    public interface IReadableObservableProperty<out T> : IReadableObservableProperty, IReadableProperty<T>
    {
    }
}