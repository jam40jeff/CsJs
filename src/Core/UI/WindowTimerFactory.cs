using System;
using MorseCode.CsJs.Common;

namespace MorseCode.CsJs.UI
{
	public class WindowTimerFactory : ITimerFactory
	{
		private static readonly Lazy<WindowTimerFactory> InstanceLazy;

		static WindowTimerFactory()
		{
			InstanceLazy = new Lazy<WindowTimerFactory>(() => new WindowTimerFactory());
		}

		private WindowTimerFactory()
		{
		}

		public static WindowTimerFactory Instance
		{
			get { return InstanceLazy.Value; }
		}

		public ITimer CreateTimer(Action callback, int milliseconds, bool autoReset)
		{
			return new WindowTimer(callback, milliseconds, autoReset);
		}
	}
}