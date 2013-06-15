namespace MorseCode.CsJs.Common.Observable
{
    public interface IReadableObservableProperty<out T> : IReadableProperty<T>, IObservable
    {
    }
}