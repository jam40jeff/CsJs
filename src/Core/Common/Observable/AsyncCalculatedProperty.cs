using System;
using System.Collections.Generic;

namespace MorseCode.CsJs.Common.Observable
{
	public class AsyncCalculatedProperty<T> : ObservablePropertyBase<T>
	{
		private readonly Random _random = new Random();
		private readonly List<int> _requestIds = new List<int>();
		private readonly ObservableProperty<bool> _isCalculating = new ObservableProperty<bool>(false);

		private AsyncCalculatedProperty(IEnumerable<IObservable> observables, Action<Action<T>> calculatePropertyValue)
		{
			Action update = () => CalculatePropertyValueAsync(calculatePropertyValue, SetValue);
			foreach (IObservable observable in observables)
			{
				observable.Changed += (sender, args) => update();
			}
			CalculatePropertyValueAsyncWithoutDelay(calculatePropertyValue, SetInitialValue);
		}

		public TimeSpan Delay { get; set; }

		private void CalculatePropertyValueAsync(Action<Action<T>> calculatePropertyValue, Action<T> setValue)
		{
			if (Delay > TimeSpan.Zero)
			{
				CalculatePropertyValueAsyncWithDelay(calculatePropertyValue, setValue, Delay);
			}
			else
			{
				CalculatePropertyValueAsyncWithoutDelay(calculatePropertyValue, setValue);
			}
		}

		private void CalculatePropertyValueAsyncWithDelay(Action<Action<T>> calculatePropertyValue, Action<T> setValue, TimeSpan delay)
		{
			_isCalculating.Value = true;
			int requestId = AddRequestId();
			ITimer timer = TimerFactory.Instance.CreateTimer(() => CalculatePropertyValueAsyncCallback(calculatePropertyValue, setValue, requestId), Script.Reinterpret<int>(Math.Round(delay.TotalMilliseconds)), false);
			timer.Start();
		}

		private void CalculatePropertyValueAsyncWithoutDelay(Action<Action<T>> calculatePropertyValue, Action<T> setValue)
		{
			_isCalculating.Value = true;
			int requestId = AddRequestId();
			CalculatePropertyValueAsyncCallback(calculatePropertyValue, setValue, requestId);
		}

		private int AddRequestId()
		{
			int requestId = _random.Next(int.MaxValue);
			_requestIds.Add(requestId);
			return requestId;
		}

		private void CalculatePropertyValueAsyncCallback(Action<Action<T>> calculatePropertyValue, Action<T> setValue, int requestId)
		{
			if (_requestIds.IndexOf(requestId) == _requestIds.Count - 1)
			{
				calculatePropertyValue(v =>
					{
						if (_requestIds.Contains(requestId))
						{
							while (_requestIds.Count > 0)
							{
								if (_requestIds[0] != requestId)
								{
									_requestIds.RemoveAt(0);
								}
								else
								{
									_requestIds.RemoveAt(0);
									break;
								}
							}
							setValue(v);
							_isCalculating.Value = _requestIds.Count > 0;
						}
					});
			}
		}

		public IReadableObservableProperty<bool> IsCalculating
		{
			get { return _isCalculating; }
		}

		public static AsyncCalculatedProperty<T> Create<TObservable>(TObservable observable, Action<TObservable, Action<T>> calculatePropertyValue, List<IObservable> otherObservables = null) where TObservable : IObservable
		{
			return new AsyncCalculatedProperty<T>((otherObservables ?? new List<IObservable>()).Concat(observable), setValue => calculatePropertyValue(observable, setValue));
		}

		public static AsyncCalculatedProperty<T> Create<TObservable1, TObservable2>(TObservable1 observable1, TObservable2 observable2, Action<TObservable1, TObservable2, Action<T>> calculatePropertyValue, List<IObservable> otherObservables = null)
			where TObservable1 : IObservable
			where TObservable2 : IObservable
		{
			return new AsyncCalculatedProperty<T>((otherObservables ?? new List<IObservable>()).Concat(observable1, observable2), setValue => calculatePropertyValue(observable1, observable2, setValue));
		}

		public static AsyncCalculatedProperty<T> Create<TObservable1, TObservable2, TObservable3>(TObservable1 observable1, TObservable2 observable2, TObservable3 observable3, Action<TObservable1, TObservable2, TObservable3, Action<T>> calculatePropertyValue, List<IObservable> otherObservables = null)
			where TObservable1 : IObservable
			where TObservable2 : IObservable
			where TObservable3 : IObservable
		{
			return new AsyncCalculatedProperty<T>((otherObservables ?? new List<IObservable>()).Concat(observable1, observable2, observable3), setValue => calculatePropertyValue(observable1, observable2, observable3, setValue));
		}
	}
}