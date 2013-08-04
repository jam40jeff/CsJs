using MorseCode.CsJs.Common.Data;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.ViewModel.Grid
{
	public interface IPageableData
	{
		IReadOnlyProperty<IPagingInstruction> PagingInstruction { get; }
		ObservableProperty<int> ExtraItems { get; }
		CalculatedProperty<int> TotalItems { get; }
		CalculatedProperty<int> TotalPages { get; }
		CalculatedProperty<bool> IsFirstPage { get; }
		CalculatedProperty<bool> IsLastPage { get; }
		CalculatedProperty<bool> CanMovePrevious { get; }
		CalculatedProperty<bool> CanMoveNext { get; }
	}
}