using System;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
    public class NavigationViewModel
    {
        private readonly CalculatorsAndStopwatchApplicationViewModel _applicationViewModel;

        public NavigationViewModel(CalculatorsAndStopwatchApplicationViewModel applicationViewModel)
        {
            _applicationViewModel = applicationViewModel;
        }

        public void SwitchPages()
        {
            Type currentViewModelType = _applicationViewModel.CurrentViewModel.Value.GetType();
            if (currentViewModelType == typeof (CalculatorsAndStopwatchPageViewModel))
            {
                _applicationViewModel.NavigateToCalculatorPage();
            }
            else if (currentViewModelType == typeof(CalculatorPageViewModel))
            {
                _applicationViewModel.NavigateToStopwatchPage();
            }
            else if (currentViewModelType == typeof(StopwatchPageViewModel))
            {
                _applicationViewModel.NavigateToGridPage();
            }
            else if (currentViewModelType == typeof(GridPageViewModel))
            {
                _applicationViewModel.NavigateToCalculatorsAndStopwatchPage();
            }
        }
    }
}