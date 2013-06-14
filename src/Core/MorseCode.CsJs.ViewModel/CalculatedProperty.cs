using System;
using System.Collections.Generic;

namespace MorseCode.CsJs.ViewModel
{
    public class CalculatedProperty<T> : ObservablePropertyBase<T>
    {
        private CalculatedProperty(IEnumerable<IObservable> observables, Func<T> calculatePropertyValue)
        {
            Action update = () => SetValue(calculatePropertyValue());
            foreach (IObservable observable in observables)
            {
                observable.Changed += (sender, args) => update();
            }
            SetInitialValue(calculatePropertyValue());
        }

        public static CalculatedProperty<T> Create<TObservable>(TObservable observable, Func<TObservable, T> calculatePropertyValue, List<IObservable> otherObservables = null) where TObservable : IObservable
        {
            return new CalculatedProperty<T>((otherObservables ?? new List<IObservable>()).Concat(observable), () => calculatePropertyValue(observable));
        }

        public static CalculatedProperty<T> Create<TObservable1, TObservable2>(TObservable1 observable1, TObservable2 observable2, Func<TObservable1, TObservable2, T> calculatePropertyValue, List<IObservable> otherObservables = null)
            where TObservable1 : IObservable
            where TObservable2 : IObservable
        {
            return new CalculatedProperty<T>((otherObservables ?? new List<IObservable>()).Concat(observable1, observable2), () => calculatePropertyValue(observable1, observable2));
        }

        public static CalculatedProperty<T> Create<TObservable1, TObservable2, TObservable3>(TObservable1 observable1, TObservable2 observable2, TObservable3 observable3, Func<TObservable1, TObservable2, TObservable3, T> calculatePropertyValue, List<IObservable> otherObservables = null)
            where TObservable1 : IObservable
            where TObservable2 : IObservable
            where TObservable3 : IObservable
        {
            return new CalculatedProperty<T>((otherObservables ?? new List<IObservable>()).Concat(observable1, observable2, observable3), () => calculatePropertyValue(observable1, observable2, observable3));
        }
    }
}