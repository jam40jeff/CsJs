using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel;
using MorseCode.CsJs.UI.Controls;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI
{
    public class CalculatorPage : PageBase<CalculatorPageViewModel>
    {
        private NavigationControl _navigationControl;
        private CalculatorControl _calculatorControl;

        public override string Title
        {
            get { return "Calculator"; }
        }

        protected override void CreateChildControls()
        {
            _navigationControl = new NavigationControl();
            Controls.Add(_navigationControl);

            _calculatorControl = new CalculatorControl();
            Controls.Add(_calculatorControl);
        }

        protected override void BindControls(IReadableObservableProperty<CalculatorPageViewModel> dataContext)
        {
            _navigationControl.Bind(dataContext, d => d.NavigationViewModel);
            _calculatorControl.Bind(dataContext, d => d.CalculatorViewModel);
        }
    }
}