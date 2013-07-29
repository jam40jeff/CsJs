using System;
using System.Linq.Expressions;
using MorseCode.CsJs.Common.Data;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Common.Property;

namespace MorseCode.CsJs.ViewModel.Grid
{
	public static class ColumnSortExpressionFactory<T>
	{
		public static IColumnSortExpression<T, TProperty> CreateSortExpression<TProperty>(Expression<Func<T, IReadableProperty<TProperty>>> propertyExpression, SortDirection sortDirection)
		{
			return CreateSortExpression(PropertyExpressionFactory<T>.CreatePropertyExpression(propertyExpression), sortDirection);
		}

		public static IColumnSortExpression<T, TProperty> CreateSortExpression<TProperty>(string columnUniqueName, Expression<Func<T, IReadableProperty<TProperty>>> propertyExpression, SortDirection sortDirection)
		{
			return CreateSortExpression(columnUniqueName, PropertyExpressionFactory<T>.CreatePropertyExpression(propertyExpression), sortDirection);
		}

		public static IColumnSortExpression<T> CreateSortExpression(T context, IPropertyExpression<T, IReadableProperty> propertyExpression, SortDirection sortDirection)
		{
			return CreateSortExpression(propertyExpression.PropertyName, context, propertyExpression, sortDirection);
		}

		public static IColumnSortExpression<T> CreateSortExpression(string columnUniqueName, T context, IPropertyExpression<T, IReadableProperty> propertyExpression, SortDirection sortDirection)
		{
			ISortExpression<T> sortExpression = SortExpressionFactory<T>.CreateSortExpression(context, propertyExpression, sortDirection);
			return sortExpression.ExecuteWithPropertyType(new CreateColumnSortExpressionCallback(sortExpression, columnUniqueName));
		}

		public static IColumnSortExpression<T, TProperty> CreateSortExpression<TProperty>(IPropertyExpression<T, IReadableProperty<TProperty>> propertyExpression, SortDirection sortDirection)
		{
			return CreateSortExpression(propertyExpression.PropertyName, propertyExpression, sortDirection);
		}

		public static IColumnSortExpression<T, TProperty> CreateSortExpression<TProperty>(string columnUniqueName, IPropertyExpression<T, IReadableProperty<TProperty>> propertyExpression, SortDirection sortDirection)
		{
			return new ColumnSortExpression<T, TProperty>(columnUniqueName, SortExpressionFactory<T>.CreateSortExpression(propertyExpression, sortDirection));
		}

		private class CreateColumnSortExpressionCallback : SortExpressionWithPropertyTypeCallbackBase<T, IColumnSortExpression<T>>
		{
			private readonly string _columnUniqueName;

			public CreateColumnSortExpressionCallback(ISortExpression<T> sortExpression, string columnUniqueName)
				: base(sortExpression)
			{
				_columnUniqueName = columnUniqueName;
			}

			protected override IColumnSortExpression<T> Execute<TProperty>(ISortExpression<T, TProperty> sortExpression)
			{
				return new ColumnSortExpression<T, TProperty>(_columnUniqueName, sortExpression);
			}
		}
	}
}