using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Common.Property;

namespace MorseCode.CsJs.Common.Data
{
    public interface ISortExpression
    {
        IPropertyExpression Property { get; }
        SortDirection SortDirection { get; }
    }

    public interface ISortExpression<in T> : ISortExpression
    {
        new IPropertyExpression<T, IReadableProperty> Property { get; }

        TReturn ExecuteWithPropertyType<TReturn>(ISortExpressionWithPropertyTypeCallback<T, TReturn> callback);
    }

    #region SortExpressionWithPropertyTypeCallback

    public interface ISortExpressionWithPropertyTypeCallback<out T, out TReturn>
    {
        TReturn Callback<TProperty>(ISortExpression<T, TProperty> sortExpression);
    }

    public abstract class SortExpressionWithPropertyTypeCallbackBase<T, TReturn> : AssociatedTypeCallbackBase<ISortExpression<T>>, ISortExpressionWithPropertyTypeCallback<T, TReturn>
    {
        protected SortExpressionWithPropertyTypeCallbackBase(ISortExpression<T> sortExpression)
            : base(sortExpression)
        {
        }

        public TReturn Callback<TProperty>(ISortExpression<T, TProperty> sortExpression)
        {
            CheckCallbackObject(sortExpression);
            return Execute(sortExpression);
        }

        protected abstract TReturn Execute<TProperty>(ISortExpression<T, TProperty> sortExpression);
    }

    #endregion SortExpressionWithPropertyTypeCallback

    public interface ISortExpression<in T, out TProperty> : ISortExpression<T>
    {
        new IPropertyExpression<T, IReadableProperty<TProperty>> Property { get; }
    }
}