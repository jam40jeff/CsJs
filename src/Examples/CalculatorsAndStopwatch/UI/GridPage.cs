using System.Collections.Generic;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel;
using MorseCode.CsJs.UI.Controls;
using MorseCode.CsJs.UI.Controls.Grid;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI
{
    public class GridPage : PageBase<GridPageViewModel>
    {
        private NavigationControl _navigationControl;
        private Grid _grid;

        public override string Title
        {
            get { return "Grid"; }
        }

        protected override void CreateChildControls(ControlCollection controls)
        {
            _navigationControl = new NavigationControl();
            controls.Add(_navigationControl);

            Panel panel = new Panel(c =>
                {
                    _grid = new Grid();
                    c.Add(_grid);
                });
            panel.Styles.AddOrSet("padding", "15px");
            panel.Styles.AddOrSet("background-color", "rgb(255,255,192)");
            controls.Add(panel);
        }

        protected override void BindControls(IReadableObservableProperty<GridPageViewModel> dataContext)
        {
            _navigationControl.BindDataContext(dataContext, d => d.NavigationViewModel);

            _grid.BindData(dataContext, d => d.Items, d => new List<IGridColumn<SampleItem>>
                {
                    new GridBoundTextColumn<SampleItem, int>(o => o.Id, v => "ID #" + v) {HeaderText = "ID"},
                    new GridBoundTextColumn<SampleItem, string>(o => o.Name) {HeaderText = "Name"},
                    new GridBoundTextColumn<SampleItem, string>(o => o.Something) {HeaderText = "Something Else"},
                    new GridBoundBooleanColumn<SampleItem>(o => o.Boolean) {HeaderText = "A Boolean Value!", DisplayMode = GridBooleanBoundColumnDisplayMode.Text},
                    new GridBoundBooleanColumn<SampleItem>(o => o.Boolean) {HeaderText = "A Boolean Value With Custom Text", DisplayMode = GridBooleanBoundColumnDisplayMode.Text, TrueText = "Absolutely", FalseText = "No Way"},
                    new GridBoundBooleanColumn<SampleItem>(o => o.Boolean) {HeaderText = "Boolean With Checkbox", DisplayMode = GridBooleanBoundColumnDisplayMode.CheckBox}
                });
        }
    }
}