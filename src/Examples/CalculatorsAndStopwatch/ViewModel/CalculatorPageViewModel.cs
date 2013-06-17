using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
    public class CalculatorPageViewModel
    {
        private readonly CalculatorsAndStopwatchApplicationViewModel _applicationViewModel;

        private readonly NavigationViewModel _navigationViewModel;
        private readonly CalculatorViewModel _calculatorViewModel1 = new CalculatorViewModel();
        private readonly CalculatorViewModel _calculatorViewModel2 = new CalculatorViewModel();

        private readonly ObservableProperty<bool> _isCalculator2;
        private readonly ObservableProperty<CalculatorViewModel> _calculatorViewModel;
        private readonly CalculatedProperty<string> _calculatorText;

        public CalculatorPageViewModel(CalculatorsAndStopwatchApplicationViewModel applicationViewModel)
        {
            _applicationViewModel = applicationViewModel;
            _navigationViewModel = new NavigationViewModel(_applicationViewModel);

            _isCalculator2 = new ObservableProperty<bool>();
            _calculatorViewModel = new ObservableProperty<CalculatorViewModel>(_calculatorViewModel1);
            _calculatorText = CalculatedProperty<string>.Create(_isCalculator2, isCalculator2 => "Calculator " + (isCalculator2.Value ? "2" : "1"));
        }

        public NavigationViewModel NavigationViewModel
        {
            get { return _navigationViewModel; }
        }

        public ObservableProperty<CalculatorViewModel> CalculatorViewModel
        {
            get { return _calculatorViewModel; }
        }

        public CalculatedProperty<string> CalculatorText
        {
            get { return _calculatorText; }
        }

        public void SwitchCalculators()
        {
            CalculatorViewModel.Value = _isCalculator2.Value ? _calculatorViewModel1 : _calculatorViewModel2;
            _isCalculator2.Value = !_isCalculator2.Value;
        }
    }
}