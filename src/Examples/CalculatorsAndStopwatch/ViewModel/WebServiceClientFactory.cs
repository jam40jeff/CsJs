using System;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
	public static class WebServiceClientFactory
	{
		private static IWebServiceClientFactory _instance;

		public static IWebServiceClientFactory Instance
		{
			get
			{
				if (_instance == null)
				{
					throw new InvalidOperationException(typeof(WebServiceClientFactory).Name + ".Instance must be set when the application starts.");
				}
				return _instance;
			}
			set { _instance = value; }
		}
	}
}