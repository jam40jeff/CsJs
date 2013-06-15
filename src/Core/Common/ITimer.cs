using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.Common
{
    public interface ITimer
    {
        void Start();
        void StartSafe();
        void Stop();
        void StopSafe();
        IReadableObservableProperty<bool> IsRunning { get; }
    }
}