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
            _applicationViewModel.NavigateToStopwatchPage();
        }
    }
}