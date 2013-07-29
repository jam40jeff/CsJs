using System.Collections.Generic;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.ViewModel.Grid
{
	public abstract class QueryableData<T> : IQueryableData<T>
	{
		private readonly ReadOnlyProperty<ObservableCollection<T>> _data = new ReadOnlyProperty<ObservableCollection<T>>(new ObservableCollection<T>());

		private readonly ReadOnlyProperty<ObservableCollection<IColumnSortExpression<T>>> _columnSortExpressions = new ReadOnlyProperty<ObservableCollection<IColumnSortExpression<T>>>(new ObservableCollection<IColumnSortExpression<T>>());

		protected QueryableData()
		{
			_columnSortExpressions.Value.Changed += (sender, args) => Execute();
		}

		protected abstract IEnumerable<T> LoadData();

		public void Execute()
		{
			IEnumerable<T> data = LoadData();
			_data.Value.Clear();
			if (data != null)
			{
				_data.Value.AddRange(data);
			}
		}

		public ReadOnlyProperty<ObservableCollection<T>> Data
		{
			get { return _data; }
		}

		public ReadOnlyProperty<ObservableCollection<IColumnSortExpression<T>>> ColumnSortExpressions
		{
			get { return _columnSortExpressions; }
		}
	}
}