﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.Server.Web.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly Random r = new Random();

        public CustomObject Test(double? operand1, int operand2, bool simulateLatency, string something, CustomObject Add, List<string> somethingElse, int[] somethingElseAgain, List<CustomObject> somethingElseAgain2)
        {
            return new CustomObject {Add = SomeEnum.Value2, Property1 = "p1", Property2 = null, Property3 = Add, Property4 = new CustomObject2 {Property1 = "pp1", Property2 = 5, Property3 = null}, Property5 = SomeEnum.Value3};
        }

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