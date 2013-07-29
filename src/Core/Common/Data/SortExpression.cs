using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Common.Property;

namespace MorseCode.CsJs.Common.Data
{
	internal class SortExpression<T, TProperty> : ISortExpression<T, TProperty>
	{
		private readonly IPropertyExpression<T, IReadableProperty<TProperty>> _property;
		private readonly SortDirection _sortDirection;

		public SortExpression(IPropertyExpression<T, IReadableProperty<TProperty>> property, SortDirection sortDirection)
		{
			_property = property;
			_sortDirection = sortDirection;
		}

		public IPropertyExpression<T, IReadableProperty<TProperty>> Property
		{
			get { return _property; }
		}

		IPropertyExpression<T, IReadableProperty> ISortExpression<T>.Property
		{
			get { return Property; }
		}

		IPropertyExpression ISortExpression.Property
		{
			get { return Property; }
		}

		public SortDirection SortDirection
		{
			get { return _sortDirection; }
		}

		public TReturn ExecuteWithPropertyType<TReturn>(ISortExpressionWithPropertyTypeCallback<T, TReturn> callback)
		{
			return callback.Callback(this);
		}
	}
}