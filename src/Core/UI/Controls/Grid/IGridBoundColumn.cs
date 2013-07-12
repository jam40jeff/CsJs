using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Common.Property;

namespace MorseCode.CsJs.UI.Controls.Grid
{
    public interface IGridBoundColumn
    {
    }

// ReSharper disable UnusedTypeParameter
    public interface IGridBoundColumn<in T> : IGridBoundColumn
// ReSharper restore UnusedTypeParameter
    {
    }

    public interface IGridBoundColumn<in T, out TProperty> : IGridBoundColumn<T>, IGridColumn<T>
    {
        IPropertyExpression<T, IReadableObservableProperty<TProperty>> PropertyExpression { get; }
    }
}