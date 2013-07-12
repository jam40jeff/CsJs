using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
    public class GridPageViewModel
    {
        private readonly CalculatorsAndStopwatchApplicationViewModel _applicationViewModel;

        private readonly NavigationViewModel _navigationViewModel;

        private readonly ObservableCollection<SampleItem> _items;

        public GridPageViewModel(CalculatorsAndStopwatchApplicationViewModel applicationViewModel)
        {
            _applicationViewModel = applicationViewModel;
            _navigationViewModel = new NavigationViewModel(_applicationViewModel);

            _items = new ObservableCollection<SampleItem>(new[]
                {
                    new SampleItem(2, "second", "sdkgsdgh", true),
                    new SampleItem(3, "third", "weuirueifsd", false),
                    new SampleItem(4, "fourth", "ioerhivfni", false),
                    new SampleItem(5, "fifth", "zdiofernwiasu", true)
                });
        }

        public NavigationViewModel NavigationViewModel
        {
            get { return _navigationViewModel; }
        }

        public ObservableCollection<SampleItem> Items
        {
            get { return _items; }
        }
    }
}