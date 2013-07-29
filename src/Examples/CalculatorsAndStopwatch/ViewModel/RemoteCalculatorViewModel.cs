using System;
using MorseCode.CsJs.Common;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Examples.CalculatorAndStopwatch.ViewModel.CalculatorServiceReference;
using jQueryApi;

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
						                                                 //CustomObject c = new CustomObject();
						                                                 //c.Add = null;
						                                                 //c.Property1 = "asdfksdhkdfh";
						                                                 //c.Property2 = 29;
						                                                 //CustomObject c3 = new CustomObject();
						                                                 //c3.Property1 = null;
						                                                 //c3.Property2 = 8;
						                                                 //c3.Property5 = SomeEnum.Value1;
						                                                 //c.Property3.Add(c3);
						                                                 //CustomObject2 c2 = new CustomObject2();
						                                                 //c2.Property1 = "341231";
						                                                 //c2.Property2 = null;
						                                                 //c2.Property3 = SomeEnum.Value2;
						                                                 //c.Property4 = c2;
						                                                 //c.Property5 = SomeEnum.Value1;
						                                                 //CustomObject cc = new CustomObject();
						                                                 //cc.Property5 = SomeEnum.Value3;
						                                                 //CalculatorClient t = new CalculatorClient();
						                                                 //t.Url = "http://localhost/CsJsCalculatorsAndStopwatchExampleServices/CalculatorService.svc";
						                                                 //t.TestMethod(7.2, 3, false, "something value", c, new List<string> { "a", "b", "c" }, null, new List<int?> { 1, null, 3 }, new List<CustomObject> { c, cc }, o => FrameworkUtility.Debugger(), (request, textStatus, error) => FrameworkUtility.Debugger());

						                                                 CalculatorClient calculatorClient = WebServiceClientFactory.Instance.CreateCalculatorClient();
						                                                 Action<double?, double?, bool, Action<double?>, Action<jQueryXmlHttpRequest, string, string>> method;
						                                                 switch (selectedOperator.Value.Value)
						                                                 {
							                                                 case Operator.Add:
								                                                 method = calculatorClient.Add;
								                                                 break;
							                                                 case Operator.Subtract:
								                                                 method = calculatorClient.Subtract;
								                                                 break;
							                                                 case Operator.Multiply:
								                                                 method = calculatorClient.Multiply;
								                                                 break;
							                                                 case Operator.Divide:
								                                                 method = calculatorClient.Divide;
								                                                 break;
							                                                 default:
								                                                 throw UnhandledEnumValueExceptionFactory.Create(selectedOperator.Value.Value);
						                                                 }
						                                                 method(FrameworkUtility.DoubleTryParse(operand1.Value), FrameworkUtility.DoubleTryParse(operand2.Value), SimulateLatency.Value, o => setValue(o.SafeToString()), (request, textStatus, error) => setValue("Error: " + error));
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