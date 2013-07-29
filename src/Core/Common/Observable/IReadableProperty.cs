namespace MorseCode.CsJs.Common.Observable
{
	public interface IReadableProperty
	{
		object Value { get; }

		TReturn ExecuteWithPropertyType<TReturn>(IReadablePropertyWithPropertyTypeCallback<TReturn> callback);
	}

	#region ReadablePropertyWithPropertyTypeCallback

	public interface IReadablePropertyWithPropertyTypeCallback<out TReturn>
	{
		TReturn Callback<TProperty>(IReadableProperty<TProperty> property);
	}

	public abstract class ReadablePropertyWithPropertyTypeCallbackBase<TReturn> : AssociatedTypeCallbackBase<IReadableProperty>, IReadablePropertyWithPropertyTypeCallback<TReturn>
	{
		protected ReadablePropertyWithPropertyTypeCallbackBase(IReadableProperty property)
			: base(property)
		{
		}

		public TReturn Callback<TProperty>(IReadableProperty<TProperty> property)
		{
			CheckCallbackObject(property);
			return Execute(property);
		}

		protected abstract TReturn Execute<TProperty>(IReadableProperty<TProperty> property);
	}

	#endregion ReadablePropertyWithPropertyTypeCallback

	public interface IReadableProperty<out T> : IReadableProperty
	{
		new T Value { get; }
	}
}