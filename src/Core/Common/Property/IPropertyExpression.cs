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
		object GetProperty(T item);
	}

	public interface IPropertyExpression<in T, out TProperty> : IPropertyExpression<T>
	{
		new TProperty GetProperty(T item);
	}
}