namespace MorseCode.CsJs.Common.Observable
{
	public interface IWritableProperty<in T>
	{
		T Value { set; }
	}
}