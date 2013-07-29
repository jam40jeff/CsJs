using MorseCode.CsJs.Common.Data;

namespace MorseCode.CsJs.ViewModel.Grid
{
	public interface IColumnSortExpression
	{
		string ColumnUniqueName { get; }
		ISortExpression SortExpression { get; }
	}

	public interface IColumnSortExpression<in T> : IColumnSortExpression
	{
		new ISortExpression<T> SortExpression { get; }
	}

	public interface IColumnSortExpression<in T, out TProperty> : IColumnSortExpression<T>
	{
		new ISortExpression<T, TProperty> SortExpression { get; }
	}

	internal class ColumnSortExpression<T, TProperty> : IColumnSortExpression<T, TProperty>
	{
		private readonly string _columnUniqueName;
		private readonly ISortExpression<T, TProperty> _sortExpression;

		public ColumnSortExpression(string columnUniqueName, ISortExpression<T, TProperty> sortExpression)
		{
			_columnUniqueName = columnUniqueName;
			_sortExpression = sortExpression;
		}

		public string ColumnUniqueName
		{
			get { return _columnUniqueName; }
		}

		public ISortExpression<T, TProperty> SortExpression
		{
			get { return _sortExpression; }
		}

		ISortExpression<T> IColumnSortExpression<T>.SortExpression
		{
			get { return SortExpression; }
		}

		ISortExpression IColumnSortExpression.SortExpression
		{
			get { return SortExpression; }
		}
	}
}