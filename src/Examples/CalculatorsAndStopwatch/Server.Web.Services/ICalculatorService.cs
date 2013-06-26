using System.Collections.Generic;
using System.ServiceModel;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.Server.Web.Services
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract(Name = "TestMethod")]
        CustomObject Test(double? operand1, int operand2, bool simulateLatency, string something, CustomObject Add, List<string> somethingElse, int[] somethingElseAgain, List<CustomObject> somethingElseAgain2);

        [OperationContract]
        double? Add(double? operand1, double? operand2, bool simulateLatency);

        [OperationContract]
        double? Subtract(double? operand1, double? operand2, bool simulateLatency);

        [OperationContract]
        double? Multiply(double? operand1, double? operand2, bool simulateLatency);

        [OperationContract]
        double? Divide(double? operand1, double? operand2, bool simulateLatency);
    }

    public class CustomObject
    {
        public string Property1 { get; set; }
        public int? Property2 { get; set; }
        public CustomObject Property3 { get; set; }
        public CustomObject2 Property4 { get; set; }
        public SomeEnum Property5 { get; set; }
        public SomeEnum? Add { get; set; }
    }

    public class CustomObject2
    {
        public string Property1 { get; set; }
        public int? Property2 { get; set; }
        public SomeEnum? Property3 { get; set; }
    }

    public enum SomeEnum
    {
        Value1,
        Value2,
        Value3
    }
}