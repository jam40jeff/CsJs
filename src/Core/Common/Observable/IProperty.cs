namespace MorseCode.CsJs.Common.Observable
{
	public interface IProperty<T> : IReadableProperty<T>, IWritableProperty<T>
	{
		new T Value { get; set; }
	}
}