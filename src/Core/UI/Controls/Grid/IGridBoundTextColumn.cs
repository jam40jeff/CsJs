namespace MorseCode.CsJs.UI.Controls.Grid
{
	public interface IGridBoundTextColumn : IGridBoundColumn
	{
	}

	public interface IGridBoundTextColumn<in T> : IGridBoundTextColumn, IGridBoundColumn<T>
	{
	}

	public interface IGridBoundTextColumn<in T, out TProperty> : IGridBoundTextColumn<T>, IGridBoundColumn<T, TProperty>
	{
	}
}