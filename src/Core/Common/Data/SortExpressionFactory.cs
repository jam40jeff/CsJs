using System;
using System.Linq.Expressions;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Common.Property;

namespace MorseCode.CsJs.Common.Data
{
    public static class SortExpressionFactory<T>
    {
		public static ISortExpression<T, TProperty> CreateSortExpression<TProperty>(Expression<Func<T, IReadableProperty<TProperty>>> propertyExpression, SortDirection sortDirection)
		{
			return CreateSortExpression(PropertyExpressionFactory<T>.CreatePropertyExpression(propertyExpression), sortDirection);
		}

        public static ISortExpression<T, TProperty> CreateSortExpression<TProperty>(IPropertyExpression<T, IReadableProperty<TProperty>> propertyExpression, SortDirection sortDirection)
        {
            return new SortExpression<T, TProperty>(propertyExpression, sortDirection);
        }

		public static ISortExpression<T> CreateSortExpression(T context, IPropertyExpression<T, IReadableProperty> propertyExpression, SortDirection sortDirection)
		{
			IReadableProperty property = propertyExpression.GetProperty(context);
			return property.ExecuteWithPropertyType(new CreateSortExpressionCallback(property, propertyExpression, sortDirection));
		}

        private class CreateSortExpressionCallback : ReadablePropertyWithPropertyTypeCallbackBase<ISortExpression<T>>
        {
            private readonly IPropertyExpression<T, IReadableProperty> _propertyExpression;
            private readonly SortDirection _sortDirection;

            public CreateSortExpressionCallback(IReadableProperty property, IPropertyExpression<T, IReadableProperty> propertyExpression, SortDirection sortDirection)
                : base(property)
            {
                _propertyExpression = propertyExpression;
                _sortDirection = sortDirection;
            }

            protected override ISortExpression<T> Execute<TProperty>(IReadableProperty<TProperty> property)
            {
                return new SortExpression<T, TProperty>(Script.Reinterpret<IPropertyExpression<T, IReadableProperty<TProperty>>>(_propertyExpression), _sortDirection);
            }
        }
    }
}