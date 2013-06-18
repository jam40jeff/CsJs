using System.ServiceModel;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.Server.Web.Services
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        double? Add(double? operand1, double? operand2, bool simulateLatency);

        [OperationContract]
        double? Subtract(double? operand1, double? operand2, bool simulateLatency);

        [OperationContract]
        double? Multiply(double? operand1, double? operand2, bool simulateLatency);

        [OperationContract]
        double? Divide(double? operand1, double? operand2, bool simulateLatency);
    }
}