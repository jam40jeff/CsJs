using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Common.Property;

namespace MorseCode.CsJs.UI.Controls.Grid
{
    public interface IGridBoundColumn : IGridColumn
    {
        IPropertyExpression PropertyExpression { get; }
    }

    // ReSharper disable UnusedTypeParameter
    public interface IGridBoundColumn<in T> : IGridBoundColumn, IGridColumn<T>
    // ReSharper restore UnusedTypeParameter
    {
        new IPropertyExpression<T, IReadableObservableProperty> PropertyExpression { get; }
    }

    public interface IGridBoundColumn<in T, out TProperty> : IGridBoundColumn<T>
    {
        new IPropertyExpression<T, IReadableObservableProperty<TProperty>> PropertyExpression { get; }
    }
}