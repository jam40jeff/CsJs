using System;

namespace MorseCode.CsJs.Common
{
	public interface ITimerFactory
	{
		ITimer CreateTimer(Action callback, int milliseconds, bool autoReset);
	}
}