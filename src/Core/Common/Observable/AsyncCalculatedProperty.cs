using System;
using System.Collections.Generic;

namespace MorseCode.CsJs.Common.Observable
{
    public class AsyncCalculatedProperty<T> : ObservablePropertyBase<T>
    {
        private readonly Random _random = new Random();
        private readonly Queue<int> _requestIds = new Queue<int>();
        private readonly ObservableProperty<bool> _isCalculating = new ObservableProperty<bool>(false);

        private AsyncCalculatedProperty(IEnumerable<IObservable> observables, Action<Action<T>> calculatePropertyValue)
        {
            Action update = () => CalculatePropertyValueAsync(calculatePropertyValue, SetValue);
            foreach (IObservable observable in observables)
            {
                observable.Changed += (sender, args) => update();
            }
            CalculatePropertyValueAsync(calculatePropertyValue, SetInitialValue);
        }

        private void CalculatePropertyValueAsync(Action<Action<T>> calculatePropertyValue, Action<T> setValue)
        {
            int n = _random.Next(int.MaxValue);
            _requestIds.Enqueue(n);
            _isCalculating.Value = true;
            calculatePropertyValue(v =>
            {
                if (_requestIds.Contains(n))
                {
                    while (_requestIds.Dequeue() != n)
                    {
                    }
                    setValue(v);
                    _isCalculating.Value = _requestIds.Count > 0;
                }
            });
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