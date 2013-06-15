using MorseCode.CsJs.Common;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI
{
    public class CalculatorControl : CalculatorControlBase<CalculatorViewModel>
    {
        protected override void SetupControls()
        {
            _equals.Text = "=";
            _largeResultPanel.Styles.AddOrSet("margin", "50px");
            _largeResultPanel.Styles.AddOrSet("padding", "50px");
            _largeResultLabel.Styles.AddOrSet("font-size", "96pt");
        }

        protected override void BindControls(IReadableObservableProperty<CalculatorViewModel> dataContext)
        {
            _function.Bind(dataContext, d => d.Operators, d => d.SelectedOperator, o => o.EnumToString(), o => o.EnumToString());
            _operand1.Bind(dataContext, d => d.Operand1, true);
            _operator.Bind(dataContext, d => d.SelectedOperatorString);
            _operand2.Bind(dataContext, d => d.Operand2, true);
            _result.Bind(dataContext, d => d.Result);
            _largeResultLabel.Bind(dataContext, d => d.Result);
        }
    }
}
