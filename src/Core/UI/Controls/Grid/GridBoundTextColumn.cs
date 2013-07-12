using System;
using System.Linq.Expressions;
using MorseCode.CsJs.Common;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Common.Property;

namespace MorseCode.CsJs.UI.Controls.Grid
{
    public class GridBoundTextColumn<T, TProperty> : GridBoundColumnBase<T, TProperty>, IGridBoundTextColumn<T, TProperty>
    {
        private readonly Func<TProperty, string> _formatString;

        public GridBoundTextColumn(Expression<Func<T, IReadableObservableProperty<TProperty>>> propertyExpression)
            : this(propertyExpression, v => v.SafeToString())
        {
        }

        public GridBoundTextColumn(IPropertyExpression<T, IReadableObservableProperty<TProperty>> propertyExpression)
            : this(propertyExpression, v => v.SafeToString())
        {
        }

        public GridBoundTextColumn(Expression<Func<T, IReadableObservableProperty<TProperty>>> propertyExpression, Func<TProperty, string> formatString)
            : base(propertyExpression)
        {
            _formatString = formatString;
        }

        public GridBoundTextColumn(IPropertyExpression<T, IReadableObservableProperty<TProperty>> propertyExpression, Func<TProperty, string> formatString)
            : base(propertyExpression)
        {
            _formatString = formatString;
        }

        public override IControl CreateControl(int rowIndex, T item)
        {
            Label label = new Label();
            label.BindText(new ReadOnlyProperty<T>(item), d => PropertyExpression.GetProperty(d), _formatString);
            return label;
        }
    }
}