using System;
using System.Html;
using MorseCode.CsJs.Common;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.UI
{
    public class WindowTimer : ITimer
    {
        private readonly Action _callback;
        private readonly int _milliseconds;
        private readonly bool _autoReset;

        private readonly ObservableProperty<int?> _timerId = new ObservableProperty<int?>();
        private readonly CalculatedProperty<bool> _isRunning;

        public WindowTimer(Action callback, int milliseconds, bool autoReset)
        {
            _callback = callback;
            _milliseconds = milliseconds;
            _autoReset = autoReset;

            _isRunning = CalculatedProperty<bool>.Create(_timerId, timerId => timerId.Value != null);
        }

        public void Start()
        {
            Start(true);
        }

        public void StartSafe()
        {
            Start(false);
        }

        private void Start(bool throwExceptionIfRunning)
        {
            if (_timerId.Value != null)
            {
                if (throwExceptionIfRunning)
                {
                    throw new NotSupportedException("Timer is already running.");
                }

                return;
            }

            if (_autoReset)
            {
                _timerId.Value = Window.SetInterval(_callback, _milliseconds);
            }
            else
            {
                _timerId.Value = Window.SetTimeout(() =>
                    {
                        _timerId.Value = null;
                        _callback();
                    }, _milliseconds);
            }
        }

        public void Stop()
        {
            Stop(true);
        }

        public void StopSafe()
        {
            Stop(false);
        }

        private void Stop(bool throwExceptionIfNotRunning)
        {
            if (_timerId.Value == null)
            {
                if (throwExceptionIfNotRunning)
                {
                    throw new NotSupportedException("Timer is not running.");
                }

                return;
            }

            if (_autoReset)
            {
                Window.ClearInterval(_timerId.Value.Value);
            }
            else
            {
                Window.ClearTimeout(_timerId.Value.Value);
            }
            _timerId.Value = null;
        }

        public IReadableObservableProperty<bool> IsRunning
        {
            get { return _isRunning; }
        }
    }
}