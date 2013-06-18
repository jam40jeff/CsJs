using MorseCode.CsJs.Common;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Net;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
    public class RemoteCalculatorViewModel : CalculatorViewModelBase
    {
        private readonly AsyncCalculatedProperty<string> _result;
        private readonly CalculatedProperty<string> _resultToDisplay;

        public RemoteCalculatorViewModel()
            : base(true)
        {
            _result = AsyncCalculatedProperty<string>.Create(Operand1, Operand2, SelectedOperator,
                                                             (operand1, operand2, selectedOperator, setValue) =>
                                                                 {
                                                                     if (selectedOperator.Value == null)
                                                                     {
                                                                         setValue(null);
                                                                     }
                                                                     else
                                                                     {
                                                                         string method = selectedOperator.Value.Value.EnumToString();
                                                                         SoapClientParameters parameters = new SoapClientParameters();
                                                                         double? operand1Parsed = FrameworkUtility.DoubleTryParse(operand1.Value);
                                                                         double? operand2Parsed = FrameworkUtility.DoubleTryParse(operand2.Value);
                                                                         parameters.Add("operand1", operand1Parsed.SafeToString());
                                                                         parameters.Add("operand2", operand2Parsed.SafeToString());
                                                                         parameters.Add("simulateLatency", SimulateLatency.Value ? "true" : "false");
                                                                         SoapClient.Invoke("http://localhost/CsJsCalculatorsAndStopwatchExampleServices/CalculatorService.svc", method, parameters, true, (o, x) => setValue(o.SafeToString()));
                                                                     }
                                                                 });
            _resultToDisplay = CalculatedProperty<string>.Create(_result, _result.IsCalculating, (result, isCalculating) => isCalculating.Value ? "Calculating..." : result.Value);
        }

        public override IReadableObservableProperty<string> Result
        {
            get { return _resultToDisplay; }
        }
    }
}