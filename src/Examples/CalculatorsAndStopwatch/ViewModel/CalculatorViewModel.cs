using System;
using System.Runtime.CompilerServices;
using MorseCode.CsJs.Common;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
    public class CalculatorViewModel
    {
        private readonly ObservableCollection<Operator> _operators;
        private readonly ObservableProperty<string> _operand1;
        private readonly ObservableProperty<Operator?> _selectedOperator;
        private readonly CalculatedProperty<string> _selectedOperatorString;
        private readonly ObservableProperty<string> _operand2;
        private readonly CalculatedProperty<string> _result;

        public CalculatorViewModel()
        {
            _operators = new ObservableCollection<Operator>(new[] {Operator.Add, Operator.Subtract, Operator.Multiply, Operator.Divide});
            _operand1 = new ObservableProperty<string>();
            _selectedOperator = new ObservableProperty<Operator?>();
            _selectedOperator.Value = Operator.Add;
            _selectedOperatorString = CalculatedProperty<string>.Create(_selectedOperator, selectedOperator =>
                {
                    if (selectedOperator.Value == null)
                    {
                        return null;
                    }

                    switch (selectedOperator.Value.Value)
                    {
                        case Operator.Add:
                            return "+";
                        case Operator.Subtract:
                            return "-";
                        case Operator.Multiply:
                            return "*";
                        case Operator.Divide:
                            return "/";
                        default:
                            throw new NotSupportedException("Unknown enum value " + selectedOperator.Value.Value + ".");
                    }
                });
            _operand2 = new ObservableProperty<string>();
            _result = CalculatedProperty<string>.Create(_operand1, _operand2, _selectedOperator,
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

        public ObservableCollection<Operator> Operators
        {
            get { return _operators; }
        }

        public ObservableProperty<string> Operand1
        {
            get { return _operand1; }
        }

        public ObservableProperty<Operator?> SelectedOperator
        {
            get { return _selectedOperator; }
        }

        public CalculatedProperty<string> SelectedOperatorString
        {
            get { return _selectedOperatorString; }
        }

        public ObservableProperty<string> Operand2
        {
            get { return _operand2; }
        }

        public CalculatedProperty<string> Result
        {
            get { return _result; }
        }
    }

    [PreserveMemberCase]
    public enum Operator
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
}