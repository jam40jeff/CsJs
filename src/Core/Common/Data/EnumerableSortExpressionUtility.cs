using System.Collections.Generic;
using System.Linq;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Common.Property;

namespace MorseCode.CsJs.Common.Data
{
	public static class EnumerableSortExpressionUtility
	{
		public static IEnumerable<T> Apply<T>(IEnumerable<T> data, IEnumerable<ISortExpression<T>> sortExpressions)
		{
			if (data == null || sortExpressions == null)
			{
				return data;
			}

			OrderedLinqJSEnumerable<T> orderedData = null;
			bool isFirst = true;
			foreach (ISortExpression<T> sortExpression in sortExpressions)
			{
				IPropertyExpression<T, IReadableProperty> property = sortExpression.Property;
				if (!isFirst)
				{
					orderedData = sortExpression.SortDirection == SortDirection.Descending ? orderedData.ThenByDescending(o => property.GetProperty(o).Value) : orderedData.ThenBy(o => property.GetProperty(o).Value);
				}
				else
				{
					// ReSharper disable PossibleMultipleEnumeration
					orderedData = sortExpression.SortDirection == SortDirection.Descending ? data.OrderByDescending(o => property.GetProperty(o).Value) : data.OrderBy(o => property.GetProperty(o).Value);
					// ReSharper restore PossibleMultipleEnumeration
					isFirst = false;
				}
			}

			// ReSharper disable PossibleMultipleEnumeration
			return isFirst ? data : orderedData;
			// ReSharper restore PossibleMultipleEnumeration
		}
	}
}