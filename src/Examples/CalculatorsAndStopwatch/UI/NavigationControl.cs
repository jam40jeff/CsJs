using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel;
using MorseCode.CsJs.UI.Controls;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI
{
	public class NavigationControl : PlaceHolderCompositeControlBase<NavigationViewModel>
	{
		private Button _switchButton;

		protected override void CreateChildControls(ControlCollection controls)
		{
			_switchButton = new Button();
			_switchButton.SetText("Switch Pages");
			controls.Add(new HtmlControl("div", c => c.Add(_switchButton)));
		}

		protected override void BindControls(IReadableObservableProperty<NavigationViewModel> dataContext)
		{
			_switchButton.BindClickAction(dataContext, d => d.SwitchPages);
		}
	}
}