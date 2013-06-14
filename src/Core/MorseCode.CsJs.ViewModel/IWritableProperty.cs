namespace MorseCode.CsJs.ViewModel
{
    public interface IWritableProperty<in T>
    {
        T Value { set; }
    }
}