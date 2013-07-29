namespace MorseCode.CsJs.Common.Observable
{
	public class ReadOnlyProperty<T> : ObservablePropertyBase<T>, IReadOnlyProperty<T>
	{
		public ReadOnlyProperty(T value)
		{
			SetInitialValue(value);
		}
	}
}