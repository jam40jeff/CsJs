using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.UI.Controls.Grid
{
	public abstract class GridColumnBase<T> : IGridColumn<T>
	{
		protected GridColumnBase(string uniqueName)
		{
			UniqueName = uniqueName;
		}

		public string UniqueName { get; set; }
		public string HeaderText { get; set; }

		public abstract IControl CreateControl(int rowIndex, IReadableObservableProperty<T> item);
	}
}