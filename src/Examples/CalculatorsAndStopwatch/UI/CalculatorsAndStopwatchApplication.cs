using MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel;
using MorseCode.CsJs.UI;
using MorseCode.CsJs.ViewModel;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI
{
    public class CalculatorsAndStopwatchApplication : ApplicationBase
    {
        protected override ApplicationViewModelBase CreateApplicationViewModel()
        {
            return new CalculatorsAndStopwatchApplicationViewModel();
        }

        protected override void RegisterPages(PageRegistrationHelper pageRegistrationHelper)
        {
            pageRegistrationHelper.RegisterPage(() => new CalculatorsAndStopwatchPage()).WithBinding<CalculatorsAndStopwatchPageViewModel>((p, d) => p.Bind(d));
            pageRegistrationHelper.RegisterPage(() => new CalculatorPage()).WithBinding<CalculatorPageViewModel>((p, d) => p.Bind(d));
            pageRegistrationHelper.RegisterPage(() => new StopwatchPage()).WithBinding<StopwatchPageViewModel>((p, d) => p.Bind(d));
        }
    }
}