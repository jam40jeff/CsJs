using System.Collections.Generic;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel;
using MorseCode.CsJs.UI.Controls;
using MorseCode.CsJs.UI.Controls.Grid;

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

        protected override void CreateChildControls(ControlCollection controls)
        {
            _navigationControl = new NavigationControl();
            controls.Add(_navigationControl);

            _calculatorControl = new CalculatorControl();
            controls.Add(_calculatorControl);
        }

        protected override void BindControls(IReadableObservableProperty<CalculatorPageViewModel> dataContext)
        {
            _navigationControl.BindDataContext(dataContext, d => d.NavigationViewModel);
            _calculatorControl.BindDataContext(dataContext, d => d.CalculatorViewModel);
        }
    }
}