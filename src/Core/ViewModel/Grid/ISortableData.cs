using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.ViewModel.Grid
{
	public interface ISortableData<T>
	{
		ReadOnlyProperty<ObservableCollection<IColumnSortExpression<T>>> ColumnSortExpressions { get; }
	}
}