namespace MorseCode.CsJs.ViewModel
{
    public interface IReadableObservableProperty<out T> : IReadableProperty<T>, IObservable
    {
    }
}