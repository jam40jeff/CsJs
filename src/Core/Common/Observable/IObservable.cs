using System;

namespace MorseCode.CsJs.Common.Observable
{
    public interface IObservable
    {
        event EventHandler BeforeChanged;
        event EventHandler Changed;
    }
}