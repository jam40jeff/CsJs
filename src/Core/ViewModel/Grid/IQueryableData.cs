using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.ViewModel.Grid
{
	public interface IQueryableData<T>
	{
		ReadOnlyProperty<ObservableCollection<T>> Data { get; }
		ReadOnlyProperty<ObservableCollection<IColumnSortExpression<T>>> ColumnSortExpressions { get; }

		void Execute();
	}
}