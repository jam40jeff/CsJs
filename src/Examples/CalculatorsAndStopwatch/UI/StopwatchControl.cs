using MorseCode.CsJs.Common;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI
{
    public class StopwatchControl : StopwatchControlBase<StopwatchViewModel>
    {
        protected override void SetupControls()
        {
        }

        protected override void BindControls(IReadableObservableProperty<StopwatchViewModel> dataContext)
        {
            _viewModeDropDown.Bind(dataContext, d => d.ViewModes, d => d.SelectedViewMode, o => o.EnumToString(), o => o.EnumToString());
            _timeLabel.Bind(dataContext, d => d.ElapsedString);
            _startButton.Bind(dataContext, d => d.Start);
            _startButton.BindVisible(dataContext, d => d.AllowStart);
            _stopButton.Bind(dataContext, d => d.Stop);
            _stopButton.BindVisible(dataContext, d => d.AllowStop);
            _resetButton.Bind(dataContext, d => d.Reset);
        }
    }
}