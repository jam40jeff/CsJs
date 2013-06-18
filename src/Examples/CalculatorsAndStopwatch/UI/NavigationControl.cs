using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel;
using MorseCode.CsJs.UI.Controls;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI
{
    public class NavigationControl : PlaceHolderCompositeControlBase<NavigationViewModel>
    {
        private Button _switchButton;

        protected override void CreateChildControls()
        {
            _switchButton = new Button();
            _switchButton.Text = "Switch Pages";
            Controls.Add(new HtmlControl("div", controls => controls.Add(_switchButton)));
        }

        protected override void BindControls(IReadableObservableProperty<NavigationViewModel> dataContext)
        {
            _switchButton.BindClickAction(dataContext, d => d.SwitchPages);
        }
    }
}