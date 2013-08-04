using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.Common.Data
{
	public interface IPagingInstruction
	{
		IObservableProperty<int> PageSize { get; }
		IObservableProperty<int> PageIndex { get; }
	}
}