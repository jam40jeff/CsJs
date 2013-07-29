using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel;
using MorseCode.CsJs.UI.Controls;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI
{
	public class StopwatchPage : PageBase<StopwatchPageViewModel>
	{
		private NavigationControl _navigationControl;
		private StopwatchControl _stopwatchControl;

		public override string Title
		{
			get { return "Stopwatch"; }
		}

		protected override void CreateChildControls(ControlCollection controls)
		{
			_navigationControl = new NavigationControl();
			controls.Add(_navigationControl);

			_stopwatchControl = new StopwatchControl();
			controls.Add(_stopwatchControl);
		}

		protected override void BindControls(IReadableObservableProperty<StopwatchPageViewModel> dataContext)
		{
			_navigationControl.BindDataContext(dataContext, d => d.NavigationViewModel);
			_stopwatchControl.BindDataContext(dataContext, d => d.StopwatchViewModel);
		}
	}
}