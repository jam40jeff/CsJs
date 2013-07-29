using System.Collections.Generic;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel;
using MorseCode.CsJs.UI.Controls;
using MorseCode.CsJs.UI.Controls.Grid;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI
{
	public class QueryableGridPage : PageBase<QueryableGridPageViewModel>
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

		protected override void BindControls(IReadableObservableProperty<QueryableGridPageViewModel> dataContext)
		{
			_navigationControl.BindDataContext(dataContext, d => d.NavigationViewModel);

			_grid.BindDataWithSorting(dataContext, new SampleItemCollectionItem(null, -1, null, null, false), d => d.QueryableItems, d => new ReadOnlyProperty<List<IGridColumn<SampleItemCollectionItem>>>(new List<IGridColumn<SampleItemCollectionItem>>
                {
                    //TODO: SaltarelleCompiler issue #227
                    new GridBoundTextColumn<SampleItem, int>(o => o.Id, v => "ID #" + v) {HeaderText = "ID"},
                    new GridBoundTextColumn<SampleItemCollectionItem, string>(o => o.Name) {HeaderText = "Name"},
                    new GridBoundTextColumn<SampleItemCollectionItem, string>(o => o.Something) {HeaderText = "Something Else"},
                    new GridBoundBooleanColumn<SampleItemCollectionItem>(o => o.Boolean) {HeaderText = "A Boolean Value!", DisplayMode = GridBooleanBoundColumnDisplayMode.Text},
                    new GridBoundBooleanColumn<SampleItem>("Boolean2",o => o.Boolean) {HeaderText = "A Boolean Value With Custom Text", DisplayMode = GridBooleanBoundColumnDisplayMode.Text, TrueText = "Absolutely", FalseText = "No Way"},
                    new GridBoundBooleanColumn<SampleItemCollectionItem>("Boolean3",o => o.Boolean) {HeaderText = "Boolean With Checkbox", DisplayMode = GridBooleanBoundColumnDisplayMode.CheckBox},
                    new SampleGridColumn("Sample") {HeaderText = "Custom Column"},
                    new GridButtonColumn<SampleItemCollectionItem>("Button",(item, button) => button.BindText(item, d2 => d2.Id, v => "Delete Row With ID " + v), item => item.Delete) {HeaderText = "Delete"}
                }));
		}

		private class SampleGridColumn : GridColumnBase<SampleItem>
		{
			public SampleGridColumn(string uniqueName)
				: base(uniqueName)
			{
			}

			public override IControl CreateControl(int rowIndex, IReadableObservableProperty<SampleItem> item)
			{
				Panel panel = new Panel(c =>
					{
						Panel topPanel = new Panel(controls =>
							{
								Label label = new Label();
								label.BindText(item, d => d.Id, v => "Line one shows the ID: " + v);
								controls.Add(label);
							});
						c.Add(topPanel);

						Panel bottomPanel = new Panel(controls =>
							{
								Label label = new Label();
								label.BindText(item, d => d.Name, v => "Line two shows the name: " + v);
								controls.Add(label);
							});
						c.Add(bottomPanel);
					});
				return panel;
			}
		}
	}
}