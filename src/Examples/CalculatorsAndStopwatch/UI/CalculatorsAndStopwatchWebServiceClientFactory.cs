using MorseCode.CsJs.Examples.CalculatorAndStopwatch.ViewModel.CalculatorServiceReference;
using MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel;
using MorseCode.CsJs.UI;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI
{
	public class CalculatorsAndStopwatchWebServiceClientFactory : IWebServiceClientFactory
	{
		public CalculatorClient CreateCalculatorClient()
		{
			CalculatorClient calculatorClient = new CalculatorClient();
			calculatorClient.Url = VirtualPathUtility.ToAbsolute("~/Services/CalculatorService.svc");
			return calculatorClient;
		}
	}
}