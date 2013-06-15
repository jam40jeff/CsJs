using System;
using System.Linq.Expressions;

namespace MorseCode.CsJs.Common
{
    public static class StaticReflection<T>
    {
        public static string GetPropertyName<TProperty>(Expression<Func<T, TProperty>> propertyPathExpression)
        {
            return ((MemberExpression) propertyPathExpression.Body).Member.Name;
        }
    }
}