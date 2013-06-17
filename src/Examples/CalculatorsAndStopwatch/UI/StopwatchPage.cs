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

        protected override void CreateChildControls()
        {
            _navigationControl = new NavigationControl();
            Controls.Add(_navigationControl);

            _stopwatchControl = new StopwatchControl();
            Controls.Add(_stopwatchControl);
        }

        protected override void BindControls(IReadableObservableProperty<StopwatchPageViewModel> dataContext)
        {
            _navigationControl.Bind(dataContext, d => d.NavigationViewModel);
            _stopwatchControl.Bind(dataContext, d => d.StopwatchViewModel);
        }
    }
}