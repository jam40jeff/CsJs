using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MorseCode.CsJs.Common.Property
{
    public static class PropertyExpressionFactory<T>
    {
        public static IPropertyExpression<T, TProperty> CreatePropertyExpression<TProperty>(Expression<Func<T, TProperty>> propertyExpression)
        {
            PropertyInfo property = StaticReflection<T>.GetPropertyInfo(propertyExpression);
            Func<T, TProperty> getProperty = item => (TProperty) property.GetValue(item);
            return new PropertyExpression<T, TProperty>(property.Name, getProperty);
        }
    }
}