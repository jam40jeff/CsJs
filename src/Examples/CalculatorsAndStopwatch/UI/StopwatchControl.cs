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
			_viewModeDropDown.BindItemsAndSelection(dataContext, d => d.ViewModes, d => d.SelectedViewMode, o => o.EnumToString(), o => o.EnumToString());
			_timeLabel.BindText(dataContext, d => d.ElapsedString);
			_startButton.BindClickAction(dataContext, d => d.Start);
			_startButton.BindVisible(dataContext, d => d.AllowStart);
			_stopButton.BindClickAction(dataContext, d => d.Stop);
			_stopButton.BindVisible(dataContext, d => d.AllowStop);
			_resetButton.BindClickAction(dataContext, d => d.Reset);
		}
	}
}