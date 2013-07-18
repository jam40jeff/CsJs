using System;
using System.Linq.Expressions;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Common.Property;

namespace MorseCode.CsJs.UI.Controls.Grid
{
    public abstract class GridBoundColumnBase<T, TProperty> : IGridBoundColumn<T, TProperty>
    {
        private readonly IPropertyExpression<T, IReadableObservableProperty<TProperty>> _propertyExpression;

        protected GridBoundColumnBase(Expression<Func<T, IReadableObservableProperty<TProperty>>> propertyExpression)
            : this(PropertyExpressionFactory<T>.CreatePropertyExpression(propertyExpression))
        {
        }

        protected GridBoundColumnBase(IPropertyExpression<T, IReadableObservableProperty<TProperty>> propertyExpression)
        {
            _propertyExpression = propertyExpression;
        }

        public string HeaderText { get; set; }

        public abstract IControl CreateControl(int rowIndex, IReadableObservableProperty<T> item);

        public IPropertyExpression<T, IReadableObservableProperty<TProperty>> PropertyExpression
        {
            get { return _propertyExpression; }
        }
    }
}