using System;

namespace MorseCode.CsJs.Common.Property
{
    public class PropertyExpression<T, TProperty> : IPropertyExpression<T, TProperty>
    {
        private readonly string _propertyName;
        private readonly Func<T, TProperty> _getProperty;

        public PropertyExpression(string propertyName, Func<T, TProperty> getProperty)
        {
            _propertyName = propertyName;
            _getProperty = getProperty;
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public TProperty GetProperty(T item)
        {
            return _getProperty(item);
        }
    }
}