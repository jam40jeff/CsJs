using System.Collections.Generic;
using System.Linq;
using MorseCode.CsJs.Common.Data;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.ViewModel.Grid
{
	public abstract class QueryableData<T> : IQueryableData<T>, ISortableData<T>, IPageableData
	{
		private readonly ReadOnlyProperty<ObservableCollection<T>> _data = new ReadOnlyProperty<ObservableCollection<T>>(new ObservableCollection<T>());

		private readonly ReadOnlyProperty<ObservableCollection<IColumnSortExpression<T>>> _columnSortExpressions = new ReadOnlyProperty<ObservableCollection<IColumnSortExpression<T>>>(new ObservableCollection<IColumnSortExpression<T>>());
		private readonly ReadOnlyProperty<IPagingInstruction> _pagingInstruction = new ReadOnlyProperty<IPagingInstruction>(new PagingInstruction());
		private readonly ObservableProperty<int> _itemsNotLoadedCount;
		private readonly CalculatedProperty<int> _totalItems;
		private readonly CalculatedProperty<int> _totalPages;
		private readonly CalculatedProperty<bool> _isFirstPage;
		private readonly CalculatedProperty<bool> _isLastPage;
		private readonly CalculatedProperty<bool> _canMovePrevious;
		private readonly CalculatedProperty<bool> _canMoveNext;

		protected QueryableData()
		{
			_itemsNotLoadedCount = new ObservableProperty<int>();
			_totalItems = CalculatedProperty<int>.Create(_data.Value, _itemsNotLoadedCount, (data, extraItems) => data == null ? extraItems.Value : (data.Count + extraItems.Value));
			_totalPages = CalculatedProperty<int>.Create(_pagingInstruction.Value.PageSize, _totalItems, (pageSize, totalItems) => (pageSize.Value == 0 ? 0 : ((totalItems.Value - 1) / pageSize.Value)) + 1);
			_isFirstPage = CalculatedProperty<bool>.Create(_pagingInstruction.Value.PageIndex, pageIndex => pageIndex.Value < 1);
			_isLastPage = CalculatedProperty<bool>.Create(_pagingInstruction.Value.PageIndex, _totalPages, (pageIndex, totalPages) => pageIndex.Value > totalPages.Value - 2);
			_canMovePrevious = CalculatedProperty<bool>.Create(_isFirstPage, isFirstPage => !isFirstPage.Value);
			_canMoveNext = CalculatedProperty<bool>.Create(_isLastPage, isLastPage => !isLastPage.Value);

			_columnSortExpressions.Value.Changed += (sender, args) => Execute();
			_pagingInstruction.Value.PageIndex.Changed += (sender, args) => Execute();
			_pagingInstruction.Value.PageSize.Changed += (sender, args) => Execute();
		}

		protected abstract IPagedResult<IEnumerable<T>> LoadData();

		public void Execute()
		{
			IPagedResult<IEnumerable<T>> data = LoadData();
			_data.Value.Clear();
			if (data != null)
			{
				int itemsCount = 0;
				if (data.Data != null)
				{
					List<T> dataToAdd = data.Data.ToList();
					_data.Value.AddRange(data.Data);
					itemsCount = dataToAdd.Count;
				}
				int itemsNotLoadedCount = data.TotalItems - itemsCount;
				if (itemsNotLoadedCount < itemsCount)
				{
					itemsNotLoadedCount = itemsCount;
				}
				_itemsNotLoadedCount.Value = itemsNotLoadedCount;
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

		public IReadOnlyProperty<IPagingInstruction> PagingInstruction
		{
			get { return _pagingInstruction; }
		}

		public ObservableProperty<int> ExtraItems
		{
			get { return _itemsNotLoadedCount; }
		}

		public CalculatedProperty<int> TotalItems
		{
			get { return _totalItems; }
		}

		public CalculatedProperty<int> TotalPages
		{
			get { return _totalPages; }
		}

		public CalculatedProperty<bool> IsFirstPage
		{
			get { return _isFirstPage; }
		}

		public CalculatedProperty<bool> IsLastPage
		{
			get { return _isLastPage; }
		}

		public CalculatedProperty<bool> CanMovePrevious
		{
			get { return _canMovePrevious; }
		}

		public CalculatedProperty<bool> CanMoveNext
		{
			get { return _canMoveNext; }
		}
	}
}