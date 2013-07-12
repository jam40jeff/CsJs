namespace MorseCode.CsJs.UI.Controls.Grid
{
    public interface IGridColumn
    {
        string HeaderText { get; set; }
    }

    public interface IGridColumn<in T> : IGridColumn
    {
        IControl CreateControl(int rowIndex, T item);
    }
}