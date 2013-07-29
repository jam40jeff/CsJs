using MorseCode.CsJs.Examples.CalculatorAndStopwatch.ViewModel.CalculatorServiceReference;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
	public interface IWebServiceClientFactory
	{
		CalculatorClient CreateCalculatorClient();
	}
}