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
            pageRegistrationHelper.RegisterPage(() => new GridPage()).WithBinding<GridPageViewModel>((p, d) => p.BindDataContext(d));
        }
    }

    public class CalculatorsAndStopwatchSkin : SkinBase
    {
        protected override void AddSkinActions(Action<SkinActionWithType> addSkinAction)
        {
            //NOTE: normally the following line would be used when the skin is contained within one class, however this example is testing the ability to override control skin actions by providing
            //separate skin actions below
            //addSkinAction(CreateSkinAction<DropDown>(control => control.Styles.AddOrSet("color", control.SkinCategory == "Lighter" ? "gray" : "blue")));
            addSkinAction(CreateSkinAction<DropDown>(control => control.Styles.AddOrSet("color", "yellow")));
            addSkinAction(CreateSkinAction<DropDown>(control => control.Styles.AddOrSet("color", "blue")));
            addSkinAction(CreateSkinAction<DropDown>(control =>
                {
                    if (control.SkinCategory == "Lighter")
                    {
                        control.Styles.AddOrSet("color", control.SkinCategory == "Lighter" ? "gray" : "blue");
                    }
                }));
        }
    }
}