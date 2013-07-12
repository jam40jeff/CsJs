namespace MorseCode.CsJs.Common.Property
{
    public interface IPropertyExpression
    {
        string PropertyName { get; }
    }

// ReSharper disable UnusedTypeParameter
    public interface IPropertyExpression<in T> : IPropertyExpression
// ReSharper restore UnusedTypeParameter
    {
    }

    public interface IPropertyExpression<in T, out TProperty> : IPropertyExpression<T>
    {
        TProperty GetProperty(T item);
    }
}