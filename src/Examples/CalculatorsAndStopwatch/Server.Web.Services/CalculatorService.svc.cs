using System;
using System.Threading;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.Server.Web.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly Random r = new Random();

        public double? Add(double? operand1, double? operand2, bool simulateLatency)
        {
            if (simulateLatency)
            {
                Thread.Sleep(r.Next(5000));
            }
            return operand1 + operand2;
        }

        public double? Subtract(double? operand1, double? operand2, bool simulateLatency)
        {
            if (simulateLatency)
            {
                Thread.Sleep(r.Next(5000));
            }
            return operand1 - operand2;
        }

        public double? Multiply(double? operand1, double? operand2, bool simulateLatency)
        {
            if (simulateLatency)
            {
                Thread.Sleep(r.Next(5000));
            }
            return operand1 * operand2;
        }

        public double? Divide(double? operand1, double? operand2, bool simulateLatency)
        {
            if (simulateLatency)
            {
                Thread.Sleep(r.Next(5000));
            }
            return operand1 / operand2;
        }
    }
}