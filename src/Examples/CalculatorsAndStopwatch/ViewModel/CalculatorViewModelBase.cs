using System;
using System.Runtime.CompilerServices;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
	public abstract class CalculatorViewModelBase : ICalculatorViewModel
	{
		private readonly ObservableCollection<bool> _updateInRealTimeItems;
		private readonly ObservableProperty<bool?> _updateInRealTimeSelection;
		private readonly CalculatedProperty<bool> _updateInRealTime;
		private readonly ReadOnlyProperty<bool> _supportsAsync;
		private readonly ObservableCollection<bool> _simulateLatencyItems;
		private readonly ObservableProperty<bool?> _simulateLatencySelection;
		private readonly CalculatedProperty<bool> _simulateLatency;
		private readonly ObservableCollection<Operator> _operators;
		private readonly ObservableProperty<string> _operand1;
		private readonly ObservableProperty<Operator?> _selectedOperator;
		private readonly CalculatedProperty<string> _selectedOperatorString;
		private readonly ObservableProperty<string> _operand2;

		protected CalculatorViewModelBase(bool supportsAsync)
		{
			_updateInRealTimeItems = new ObservableCollection<bool>(new[] { true, false });
			_updateInRealTimeSelection = new ObservableProperty<bool?>(true);
			_updateInRealTime = CalculatedProperty<bool>.Create(_updateInRealTimeSelection, updateInRealTimeSelection => updateInRealTimeSelection.Value.HasValue && updateInRealTimeSelection.Value.Value);
			_supportsAsync = new ReadOnlyProperty<bool>(supportsAsync);
			_simulateLatencyItems = new ObservableCollection<bool>(new[] { true, false });
			_simulateLatencySelection = new ObservableProperty<bool?>(true);
			_simulateLatency = CalculatedProperty<bool>.Create(_simulateLatencySelection, simulateLatencySelection => simulateLatencySelection.Value.HasValue && simulateLatencySelection.Value.Value);
			_operators = new ObservableCollection<Operator>(new[] { Operator.Add, Operator.Subtract, Operator.Multiply, Operator.Divide });
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
		}

		public ObservableCollection<bool> UpdateInRealTimeItems
		{
			get { return _updateInRealTimeItems; }
		}

		public ObservableProperty<bool?> UpdateInRealTimeSelection
		{
			get { return _updateInRealTimeSelection; }
		}

		public CalculatedProperty<bool> UpdateInRealTime
		{
			get { return _updateInRealTime; }
		}

		public ObservableCollection<bool> SimulateLatencyItems
		{
			get { return _simulateLatencyItems; }
		}

		public ObservableProperty<bool?> SimulateLatencySelection
		{
			get { return _simulateLatencySelection; }
		}

		public CalculatedProperty<bool> SimulateLatency
		{
			get { return _simulateLatency; }
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

		public IReadableObservableProperty<bool> SupportsAsync
		{
			get { return _supportsAsync; }
		}

		public abstract IReadableObservableProperty<string> Result { get; }
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