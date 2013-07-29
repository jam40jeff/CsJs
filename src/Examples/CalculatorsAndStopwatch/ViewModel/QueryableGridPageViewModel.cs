using System.Collections.Generic;
using System.Linq;
using MorseCode.CsJs.Common.Data;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.ViewModel.Grid;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
	public class QueryableGridPageViewModel
	{
		private readonly CalculatorsAndStopwatchApplicationViewModel _applicationViewModel;

		private readonly NavigationViewModel _navigationViewModel;

		private readonly ObservableCollection<SampleItemCollectionItem> _items;

		private readonly ReadOnlyProperty<QueryableSampleItems> _queryableItems;

		public QueryableGridPageViewModel(CalculatorsAndStopwatchApplicationViewModel applicationViewModel)
		{
			_applicationViewModel = applicationViewModel;
			_navigationViewModel = new NavigationViewModel(_applicationViewModel);

			_items = new ObservableCollection<SampleItemCollectionItem>();
			IEnumerable<SampleItemCollectionItem> items = new[]
				{
					new SampleItemCollectionItem(_items, 2, "second", "sdkgsdgh", true),
					new SampleItemCollectionItem(_items, 3, "third", "weuirueifsd", false),
					new SampleItemCollectionItem(_items, 4, "fourth", "ioerhivfni", false),
					new SampleItemCollectionItem(_items, 5, "fifth", "zdiofernwiasu", true),
					new SampleItemCollectionItem(_items, 12, "second", "sdkgsdgh", true),
					new SampleItemCollectionItem(_items, 13, "third", "weuirueifsd", false),
					new SampleItemCollectionItem(_items, 14, "fourth", "ioerhivfni", false),
					new SampleItemCollectionItem(_items, 15, "fifth", "zdiofernwiasu", true),
					new SampleItemCollectionItem(_items, 22, "second", "sdkgsdgh", true),
					new SampleItemCollectionItem(_items, 23, "third", "weuirueifsd", false),
					new SampleItemCollectionItem(_items, 24, "fourth", "ioerhivfni", false),
					new SampleItemCollectionItem(_items, 25, "fifth", "zdiofernwiasu", true),
					new SampleItemCollectionItem(_items, 32, "second", "sdkgsdgh", true),
					new SampleItemCollectionItem(_items, 33, "third", "weuirueifsd", false),
					new SampleItemCollectionItem(_items, 34, "fourth", "ioerhivfni", false),
					new SampleItemCollectionItem(_items, 35, "fifth", "zdiofernwiasu", true),
					new SampleItemCollectionItem(_items, 42, "second", "sdkgsdgh", true),
					new SampleItemCollectionItem(_items, 43, "third", "weuirueifsd", false),
					new SampleItemCollectionItem(_items, 44, "fourth", "ioerhivfni", false),
					new SampleItemCollectionItem(_items, 45, "fifth", "zdiofernwiasu", true)
				};
			_items.AddRange(items);

			_queryableItems = new ReadOnlyProperty<QueryableSampleItems>(new QueryableSampleItems(this));
			_queryableItems.Value.Execute();

			_items.Changed += (sender, args) => _queryableItems.Value.Execute();
		}

		public NavigationViewModel NavigationViewModel
		{
			get { return _navigationViewModel; }
		}

		public ReadOnlyProperty<QueryableSampleItems> QueryableItems
		{
			get { return _queryableItems; }
		}

		public class QueryableSampleItems : QueryableData<SampleItemCollectionItem>
		{
			private readonly QueryableGridPageViewModel _parent;

			public QueryableSampleItems(QueryableGridPageViewModel parent)
			{
				_parent = parent;
			}

			protected override IEnumerable<SampleItemCollectionItem> LoadData()
			{
				return EnumerableSortExpressionUtility.Apply(_parent._items, ColumnSortExpressions.Value.Select(s => s.SortExpression));
			}
		}
	}
}