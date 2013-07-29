using System;
using System.Runtime.CompilerServices;
using MorseCode.CsJs.Common;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
	public class StopwatchViewModel
	{
		private readonly ObservableCollection<ViewMode> _viewModes;
		private readonly ObservableProperty<ViewMode?> _selectedViewMode;
		private readonly ObservableProperty<bool> _isActive;
		private readonly ObservableProperty<TimeSpan> _elapsed;
		private readonly CalculatedProperty<string> _elapsedString;
		private readonly ObservableProperty<bool> _isRunning;
		private readonly CalculatedProperty<bool> _allowStop;
		private readonly CalculatedProperty<bool> _allowStart;

		private readonly ITimer _timer;

		private DateTime _start;
		private TimeSpan _previousTime;

		public StopwatchViewModel()
		{
			_viewModes = new ObservableCollection<ViewMode>(new[] { ViewMode.Milliseconds, ViewMode.Seconds });
			_selectedViewMode = new ObservableProperty<ViewMode?>(ViewMode.Seconds);
			_isActive = new ObservableProperty<bool>(true);
			_isActive.Changed += (sender, args) => UpdateTimerState();
			_elapsed = new ObservableProperty<TimeSpan>();
			_elapsedString = CalculatedProperty<string>.Create(_elapsed, _selectedViewMode, (elapsed, selectedViewMode) => GetTimeSpanString(elapsed.Value, selectedViewMode.Value));
			_isRunning = new ObservableProperty<bool>();
			_isRunning.Changed += (sender, args) => UpdateTimerState();
			_allowStop = CalculatedProperty<bool>.Create(_isRunning, isRunning => isRunning.Value);
			_allowStart = CalculatedProperty<bool>.Create(_isRunning, isRunning => !isRunning.Value);
			_timer = TimerFactory.Instance.CreateTimer(OnTimerElapsed, 27, true);
		}

		private static string GetTimeSpanString(TimeSpan timeSpan, ViewMode? selectedViewMode)
		{
			Func<object, int, string> pad = (o, n) => o.SafeToString().PadLeft(n, '0');
			Func<object, string> pad2 = o => pad(o, 2);
			long ticks = timeSpan.Ticks;
			string result = string.Empty;
			if (Math.Abs(ticks) >= 864000000000)
			{
				result += pad2(ticks/864000000000) + ".";
				ticks %= 864000000000;
			}
			result += pad2(ticks/36000000000) + ":";
			ticks %= 36000000000;
			result += pad2(ticks/600000000) + ":";
			ticks %= 600000000;
			result += pad2(ticks/10000000);
			if (selectedViewMode == ViewMode.Milliseconds)
			{
				ticks %= 10000000;
				result += "." + pad(ticks/10000, 3);
			}
			return result;
		}

		private void OnTimerElapsed()
		{
			if (_isRunning.Value && _isActive.Value)
			{
				SetElapsedTime();
			}
		}

		private void UpdateTimerState()
		{
			if (_isRunning.Value && _isActive.Value)
			{
				_timer.StartSafe();
			}
			else
			{
				_timer.StopSafe();
			}
		}

		private void SetElapsedTime()
		{
			_elapsed.Value = new TimeSpan(_previousTime.Ticks + DateTime.Now.Subtract(_start).Ticks);
		}

		public ObservableCollection<ViewMode> ViewModes
		{
			get { return _viewModes; }
		}

		public ObservableProperty<ViewMode?> SelectedViewMode
		{
			get { return _selectedViewMode; }
		}

		public ObservableProperty<bool> IsActive
		{
			get { return _isActive; }
		}

		public CalculatedProperty<string> ElapsedString
		{
			get { return _elapsedString; }
		}

		public CalculatedProperty<bool> AllowStop
		{
			get { return _allowStop; }
		}

		public CalculatedProperty<bool> AllowStart
		{
			get { return _allowStart; }
		}

		public void Stop()
		{
			_isRunning.Value = false;
			SetElapsedTime();
			_previousTime = _elapsed.Value;
		}

		public void Start()
		{
			_start = DateTime.Now;
			SetElapsedTime();
			_isRunning.Value = true;
		}

		public void Reset()
		{
			_start = DateTime.Now;
			_previousTime = new TimeSpan();
			_elapsed.Value = new TimeSpan();
		}

		[PreserveMemberCase]
		public enum ViewMode
		{
			Milliseconds,
			Seconds
		}
	}
}