using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MorseCode.CsJs.Common
{
    public static class StaticReflection<T>
    {
        public static PropertyInfo GetPropertyInfo<TProperty>(Expression<Func<T, TProperty>> propertyExpression)
        {
            MemberExpression memberExpression;
            UnaryExpression unaryExpression = propertyExpression.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                memberExpression = (MemberExpression) unaryExpression.Operand;
            }
            else
            {
                memberExpression = (MemberExpression) propertyExpression.Body;
            }
            return (PropertyInfo) memberExpression.Member;
        }

        public static string GetPropertyName<TProperty>(Expression<Func<T, TProperty>> propertyExpression)
        {
            return GetPropertyInfo(propertyExpression).Name;
        }
    }
}