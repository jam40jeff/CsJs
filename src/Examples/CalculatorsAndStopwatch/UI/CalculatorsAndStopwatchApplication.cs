using System;
using MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel;
using MorseCode.CsJs.UI;
using MorseCode.CsJs.UI.Controls;
using MorseCode.CsJs.ViewModel;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI
{
    public class CalculatorsAndStopwatchApplication : ApplicationBase
    {
        protected override ApplicationViewModelBase CreateApplicationViewModel()
        {
            return new CalculatorsAndStopwatchApplicationViewModel();
        }

        protected override void OnBeforeInitialize()
        {
            base.OnBeforeInitialize();

            WebServiceClientFactory.Instance = new CalculatorsAndStopwatchWebServiceClientFactory();

            Skin = new CalculatorsAndStopwatchSkin();
        }

        protected override void RegisterPages(PageRegistrationHelper pageRegistrationHelper)
        {
            pageRegistrationHelper.RegisterPage(() => new CalculatorsAndStopwatchPage()).WithBinding<CalculatorsAndStopwatchPageViewModel>((p, d) => p.BindDataContext(d));
            pageRegistrationHelper.RegisterPage(() => new CalculatorPage()).WithBinding<CalculatorPageViewModel>((p, d) => p.BindDataContext(d));
            pageRegistrationHelper.RegisterPage(() => new StopwatchPage()).WithBinding<StopwatchPageViewModel>((p, d) => p.BindDataContext(d));
        }
    }

    public class CalculatorsAndStopwatchSkin : SkinBase
    {
        protected override void AddSkinActions(Action<SkinActionWithType> addSkinAction)
        {
            addSkinAction(CreateSkinAction<DropDown>((control, skinCategory) => control.Styles.AddOrSet("color", skinCategory == "Lighter" ? "gray" : "blue")));
        }
    }
}