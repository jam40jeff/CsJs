using System;

namespace MorseCode.CsJs.Common
{
	public abstract class AssociatedTypeCallbackBase<T>
	{
		private readonly T _o;

		protected AssociatedTypeCallbackBase(T o)
		{
			_o = o;
		}

		//TODO: file a bug because the constraint caused an internal compiler error
		protected void CheckCallbackObject<TCallback>(TCallback o) // where TCallback : T
		{
			if (!ReferenceEquals(o, _o))
			{
				throw new Exception("Callback object must be the same reference as the original object.");
			}
		}
	}
}