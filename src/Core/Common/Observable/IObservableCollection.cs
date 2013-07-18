using System.Collections.Generic;

namespace MorseCode.CsJs.Common.Observable
{
    public interface IObservableCollection<T> : IList<T>, IObservable
    {
    }
}