using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel;
using MorseCode.CsJs.UI.Controls;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI
{
    public class CalculatorsAndStopwatchPage : PageBase<CalculatorsAndStopwatchPageViewModel>
    {
        private NavigationControl _navigationControl;
        private Button _switchCalculators;
        private Label _calculatorLabel;
        private CalculatorControl _calculatorControl;
        private StopwatchControl _stopwatchControl;

        public override string Title
        {
            get { return "Calculators and Stopwatch"; }
        }

        protected override void CreateChildControls(ControlCollection controls)
        {
            _navigationControl = new NavigationControl();
            controls.Add(_navigationControl);

            HtmlControl div = new HtmlControl("div", c =>
                {
                    _switchCalculators = new Button();
                    _switchCalculators.SetText("Switch Calculators");
                    c.Add(_switchCalculators);

                    _calculatorLabel = new Label();
                    _calculatorLabel.Styles.AddOrSet("padding-left", "15px");
                    c.Add(_calculatorLabel);
                });
            controls.Add(div);

            _calculatorControl = new CalculatorControl();
            controls.Add(_calculatorControl);

            _stopwatchControl = new StopwatchControl();
            controls.Add(_stopwatchControl);
        }

        protected override void BindControls(IReadableObservableProperty<CalculatorsAndStopwatchPageViewModel> dataContext)
        {
            _navigationControl.BindDataContext(dataContext, d => d.NavigationViewModel);
            _switchCalculators.BindClickAction(dataContext, d => d.SwitchCalculators);
            _calculatorLabel.BindText(dataContext, d => d.CalculatorText);
            _calculatorControl.BindDataContext(dataContext, d => d.CalculatorViewModel);
            _stopwatchControl.BindDataContext(dataContext, d => d.StopwatchViewModel);
        }
    }
}