using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
    public interface ICalculatorViewModel
    {
        ObservableCollection<bool> UpdateInRealTimeItems { get; }
        ObservableProperty<bool?> UpdateInRealTimeSelection { get; }
        CalculatedProperty<bool> UpdateInRealTime { get; }
        IReadableObservableProperty<bool> SupportsAsync { get; }
        ObservableCollection<bool> SimulateLatencyItems { get; }
        ObservableProperty<bool?> SimulateLatencySelection { get; }
        CalculatedProperty<bool> SimulateLatency { get; }
        ObservableCollection<Operator> Operators { get; }
        ObservableProperty<string> Operand1 { get; }
        ObservableProperty<Operator?> SelectedOperator { get; }
        CalculatedProperty<string> SelectedOperatorString { get; }
        ObservableProperty<string> Operand2 { get; }
        IReadableObservableProperty<string> Result { get; }
    }
}