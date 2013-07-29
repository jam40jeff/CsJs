using System;
using MorseCode.CsJs.Common;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
	public class CalculatorViewModel : CalculatorViewModelBase
	{
		private readonly CalculatedProperty<string> _result;

		public CalculatorViewModel()
			: base(false)
		{
			_result = CalculatedProperty<string>.Create(Operand1, Operand2, SelectedOperator,
			                                            (operand1, operand2, selectedOperator) =>
				                                            {
					                                            if (selectedOperator.Value == null)
					                                            {
						                                            return null;
					                                            }

					                                            Func<double?, double?, double?> function;
					                                            switch (selectedOperator.Value.Value)
					                                            {
						                                            case Operator.Add:
							                                            function = (x, y) => x + y;
							                                            break;
						                                            case Operator.Subtract:
							                                            function = (x, y) => x - y;
							                                            break;
						                                            case Operator.Multiply:
							                                            function = (x, y) => x*y;
							                                            break;
						                                            case Operator.Divide:
							                                            function = (x, y) => x/y;
							                                            break;
						                                            default:
							                                            throw new NotSupportedException(
								                                            "Unknown enum value " +
								                                            selectedOperator.Value.Value + ".");
					                                            }

					                                            return function(FrameworkUtility.DoubleTryParse(operand1.Value), FrameworkUtility.DoubleTryParse(operand2.Value)).SafeToString();
				                                            });
		}

		public override IReadableObservableProperty<string> Result
		{
			get { return _result; }
		}
	}
}