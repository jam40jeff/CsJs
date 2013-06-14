using System;

namespace MorseCode.CsJs.ViewModel
{
    public interface IObservable
    {
        event EventHandler Changing;
        event EventHandler Changed;
    }
}