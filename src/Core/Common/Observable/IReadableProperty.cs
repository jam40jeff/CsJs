namespace MorseCode.CsJs.Common.Observable
{
    public interface IReadableProperty<out T>
    {
        T Value { get; }
    }
}