namespace MorseCode.CsJs.ViewModel
{
    public interface IReadableProperty<out T>
    {
        T Value { get; }
    }
}