using System;
using System.Linq.Expressions;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Common.Property;

namespace MorseCode.CsJs.UI.Controls.Grid
{
	public abstract class GridBoundColumnBase<T, TProperty> : GridColumnBase<T>, IGridBoundColumn<T, TProperty>
	{
		private readonly IPropertyExpression<T, IReadableObservableProperty<TProperty>> _propertyExpression;

		protected GridBoundColumnBase(Expression<Func<T, IReadableObservableProperty<TProperty>>> propertyExpression)
			: this(PropertyExpressionFactory<T>.CreatePropertyExpression(propertyExpression))
		{
		}

		protected GridBoundColumnBase(string uniqueName, Expression<Func<T, IReadableObservableProperty<TProperty>>> propertyExpression)
			: this(uniqueName, PropertyExpressionFactory<T>.CreatePropertyExpression(propertyExpression))
		{
		}

		protected GridBoundColumnBase(IPropertyExpression<T, IReadableObservableProperty<TProperty>> propertyExpression)
			: this(propertyExpression.PropertyName, propertyExpression)
		{
			_propertyExpression = propertyExpression;
		}

		protected GridBoundColumnBase(string uniqueName, IPropertyExpression<T, IReadableObservableProperty<TProperty>> propertyExpression)
			: base(uniqueName)
		{
			_propertyExpression = propertyExpression;
		}

		IPropertyExpression IGridBoundColumn.PropertyExpression
		{
			get { return PropertyExpression; }
		}

		IPropertyExpression<T, IReadableObservableProperty> IGridBoundColumn<T>.PropertyExpression
		{
			get { return PropertyExpression; }
		}

		public IPropertyExpression<T, IReadableObservableProperty<TProperty>> PropertyExpression
		{
			get { return _propertyExpression; }
		}
	}
}