using System;
using System.Collections.Generic;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.Common
{
    public static class EnumerableExtensionMethods
    {
        public static void Reset<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            if (collection == items)
            {
                return;
            }

            if (collection == null)
            {
                return;
            }

            Action action = () =>
                {
                    collection.Clear();
                    foreach (T item in items)
                    {
                        collection.Add(item);
                    }
                };

            IObservableCollection<T> observableCollection = collection as IObservableCollection<T>;
            if (observableCollection != null)
            {
                observableCollection.ExecuteWhileBatchingChangeEvents(action);
            }
            else
            {
                action();
            }
        }
    }
}