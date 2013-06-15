using System;

namespace MorseCode.CsJs.Common.Observable
{
    public interface IObservable
    {
        event EventHandler Changing;
        event EventHandler Changed;
    }
}