using System.Collections.Generic;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
	public class GridPageViewModel
	{
		private readonly CalculatorsAndStopwatchApplicationViewModel _applicationViewModel;

		private readonly NavigationViewModel _navigationViewModel;

		private readonly ReadOnlyProperty<ObservableCollection<SampleItemCollectionItem>> _items;

		public GridPageViewModel(CalculatorsAndStopwatchApplicationViewModel applicationViewModel)
		{
			_applicationViewModel = applicationViewModel;
			_navigationViewModel = new NavigationViewModel(_applicationViewModel);

			_items = new ReadOnlyProperty<ObservableCollection<SampleItemCollectionItem>>(new ObservableCollection<SampleItemCollectionItem>());
			IEnumerable<SampleItemCollectionItem> items = new[]
				{
					new SampleItemCollectionItem(_items.Value, 2, "second", "sdkgsdgh", true),
					new SampleItemCollectionItem(_items.Value, 3, "third", "weuirueifsd", false),
					new SampleItemCollectionItem(_items.Value, 4, "fourth", "ioerhivfni", false),
					new SampleItemCollectionItem(_items.Value, 5, "fifth", "zdiofernwiasu", true),
					new SampleItemCollectionItem(_items.Value, 12, "second", "sdkgsdgh", true),
					new SampleItemCollectionItem(_items.Value, 13, "third", "weuirueifsd", false),
					new SampleItemCollectionItem(_items.Value, 14, "fourth", "ioerhivfni", false),
					new SampleItemCollectionItem(_items.Value, 15, "fifth", "zdiofernwiasu", true),
					new SampleItemCollectionItem(_items.Value, 22, "second", "sdkgsdgh", true),
					new SampleItemCollectionItem(_items.Value, 23, "third", "weuirueifsd", false),
					new SampleItemCollectionItem(_items.Value, 24, "fourth", "ioerhivfni", false),
					new SampleItemCollectionItem(_items.Value, 25, "fifth", "zdiofernwiasu", true),
					new SampleItemCollectionItem(_items.Value, 32, "second", "sdkgsdgh", true),
					new SampleItemCollectionItem(_items.Value, 33, "third", "weuirueifsd", false),
					new SampleItemCollectionItem(_items.Value, 34, "fourth", "ioerhivfni", false),
					new SampleItemCollectionItem(_items.Value, 35, "fifth", "zdiofernwiasu", true),
					new SampleItemCollectionItem(_items.Value, 42, "second", "sdkgsdgh", true),
					new SampleItemCollectionItem(_items.Value, 43, "third", "weuirueifsd", false),
					new SampleItemCollectionItem(_items.Value, 44, "fourth", "ioerhivfni", false),
					new SampleItemCollectionItem(_items.Value, 45, "fifth", "zdiofernwiasu", true)
				};
			_items.Value.AddRange(items);
		}

		public NavigationViewModel NavigationViewModel
		{
			get { return _navigationViewModel; }
		}

		public ReadOnlyProperty<ObservableCollection<SampleItemCollectionItem>> Items
		{
			get { return _items; }
		}
	}
}