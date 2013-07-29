namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
	public class StopwatchPageViewModel
	{
		private readonly CalculatorsAndStopwatchApplicationViewModel _applicationViewModel;

		private readonly NavigationViewModel _navigationViewModel;
		private readonly StopwatchViewModel _stopwatchViewModel = new StopwatchViewModel();

		public StopwatchPageViewModel(CalculatorsAndStopwatchApplicationViewModel applicationViewModel)
		{
			_applicationViewModel = applicationViewModel;
			_navigationViewModel = new NavigationViewModel(_applicationViewModel);
		}

		public NavigationViewModel NavigationViewModel
		{
			get { return _navigationViewModel; }
		}

		public StopwatchViewModel StopwatchViewModel
		{
			get { return _stopwatchViewModel; }
		}
	}
}