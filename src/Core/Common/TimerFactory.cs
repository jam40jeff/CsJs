using System;

namespace MorseCode.CsJs.Common
{
	public static class TimerFactory
	{
		private static ITimerFactory _instance;

		public static ITimerFactory Instance
		{
			get
			{
				if (_instance == null)
				{
					throw new NotSupportedException("TimerFactory.Instance must be set.");
				}
				return _instance;
			}
			set { _instance = value; }
		}
	}
}