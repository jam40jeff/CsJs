using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.UI.Controls.Grid
{
	public interface IGridColumn
	{
		string UniqueName { get; set; }
		string HeaderText { get; set; }
	}

	public interface IGridColumn<in T> : IGridColumn
	{
		IControl CreateControl(int rowIndex, IReadableObservableProperty<T> item);
	}
}