using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel;
using MorseCode.CsJs.UI.Controls;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI
{
    public class CalculatorsAndStopwatchPage : PageBase<CalculatorsAndStopwatchViewModel>
    {
        private Button _switchCalculators;
        private Label _calculatorLabel;
        private CalculatorControl _calculatorControl;
        private StopwatchControl _stopwatchControl;

        protected override void CreateChildControls()
        {
            HtmlControl div = new HtmlControl("div", controls =>
            {
                _switchCalculators = new Button();
                _switchCalculators.Text = "Switch Calculators";
                controls.Add(_switchCalculators);

                _calculatorLabel = new Label();
                _calculatorLabel.Styles.AddOrSet("padding-left", "15px");
                controls.Add(_calculatorLabel);
            });
            Controls.Add(div);

            _calculatorControl = new CalculatorControl();
            Controls.Add(_calculatorControl);

            _stopwatchControl = new StopwatchControl();
            Controls.Add(_stopwatchControl);
        }

        protected override void BindControls(IReadableObservableProperty<CalculatorsAndStopwatchViewModel> dataContext)
        {
            _switchCalculators.Bind(dataContext, d => d.SwitchCalculators);
            _calculatorLabel.Bind(dataContext, d => d.CalculatorText);
            _calculatorControl.Bind(dataContext, d => d.CalculatorViewModel);
            _stopwatchControl.Bind(dataContext, d => d.StopwatchViewModel);
        }

        protected override CalculatorsAndStopwatchViewModel CreateViewModel()
        {
            return new CalculatorsAndStopwatchViewModel();
        }
    }
}