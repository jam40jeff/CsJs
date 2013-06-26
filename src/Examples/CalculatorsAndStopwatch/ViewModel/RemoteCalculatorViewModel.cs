using System;
using System.Collections;
using System.Collections.Generic;
using System.Html;
using System.Linq;
using System.Runtime.CompilerServices;
using MorseCode.CsJs.Common;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Net;
using jQueryApi;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
    public class RemoteCalculatorViewModel : CalculatorViewModelBase
    {
        private readonly AsyncCalculatedProperty<string> _result;
        private readonly CalculatedProperty<string> _resultToDisplay;

        public RemoteCalculatorViewModel()
            : base(true)
        {
            _result = AsyncCalculatedProperty<string>.Create(Operand1, Operand2, SelectedOperator,
                                                             (operand1, operand2, selectedOperator, setValue) =>
                                                             {
                                                                 if (selectedOperator.Value == null)
                                                                 {
                                                                     setValue(null);
                                                                 }
                                                                 else
                                                                 {
                                                                     TestInvocator.CustomObject c = new TestInvocator.CustomObject();
                                                                     c.Add = null;
                                                                     c.Property1 = "asdfksdhkdfh";
                                                                     c.Property2 = 29;
                                                                     c.Property3 = null;
                                                                     TestInvocator.CustomObject2 c2 = new TestInvocator.CustomObject2();
                                                                     c2.Property1 = "341231";
                                                                     c2.Property2 = null;
                                                                     c2.Property3 = TestInvocator.SomeEnum.Value2;
                                                                     c.Property4 = c2;
                                                                     c.Property5 = TestInvocator.SomeEnum.Value1;
                                                                     TestInvocator.CustomObject cc = new TestInvocator.CustomObject();
                                                                     cc.Property5 = TestInvocator.SomeEnum.Value3;
                                                                     TestInvocator t = new TestInvocator();
                                                                     t.Url = "http://localhost/CsJsCalculatorsAndStopwatchExampleServices/CalculatorService.svc";
                                                                     t.TestMethod(7.2, 3, false, "something value", c, new List<string> { "a", "b", "c" }, null, new List<TestInvocator.CustomObject> { c, cc }, o => FrameworkUtility.Debugger(), (request, textStatus, error) => FrameworkUtility.Debugger());
                                                                     string method = selectedOperator.Value.Value.EnumToString();
                                                                     SoapClient soapClient = new SoapClient();
                                                                     soapClient.Url = "http://localhost/CsJsCalculatorsAndStopwatchExampleServices/CalculatorService.svc";
                                                                     Dictionary<string, object> parameters = new Dictionary<string, object>();
                                                                     parameters.Add("operand1", FrameworkUtility.DoubleTryParse(operand1.Value));
                                                                     parameters.Add("operand2", FrameworkUtility.DoubleTryParse(operand2.Value));
                                                                     parameters.Add("simulateLatency", SimulateLatency.Value);
                                                                     soapClient.Invoke(method, parameters, o => setValue(o.SafeToString()), (request, textStatus, error) => setValue("Error: " + error));
                                                                 }
                                                             });
            _resultToDisplay = CalculatedProperty<string>.Create(_result, _result.IsCalculating, (result, isCalculating) => isCalculating.Value ? "Calculating..." : result.Value);
        }

        public override IReadableObservableProperty<string> Result
        {
            get { return _resultToDisplay; }
        }

        public class TestInvocator : SoapClient
        {
            public void TestMethod(double? operand1, int operand2, bool simulateLatency, string something, CustomObject Add, List<string> somethingElse, int[] somethingElseAgain, List<CustomObject> somethingElseAgain2, Action<CustomObject> successCallback, Action<jQueryXmlHttpRequest, string, string> errorCallback)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("operand1", operand1);
                parameters.Add("operand2", operand2);
                parameters.Add("simulateLatency", simulateLatency);
                parameters.Add("something", something);
                parameters.Add("Add", CustomObject.ToJsDictionary(Add));
                parameters.Add("somethingElse", somethingElse);
                parameters.Add("somethingElseAgain", somethingElseAgain);
                parameters.Add("somethingElseAgain2", somethingElseAgain2.Select(CustomObject.ToJsDictionary).ToList());
                Invoke("TestMethod", parameters, o => successCallback(CustomObject.FromJsDictionary(Script.Reinterpret<JsDictionary>(o))), errorCallback);
            }

            [PreserveMemberCase]
            public class CustomObject
            {
                public string Property1 { get; set; }
                public int? Property2 { get; set; }
                public CustomObject Property3 { get; set; }
                public CustomObject2 Property4 { get; set; }
                public SomeEnum Property5 { get; set; }
                public SomeEnum? Add { get; set; }

                public static CustomObject FromJsDictionary(JsDictionary d)
                {
                    if (d == null)
                    {
                        return null;
                    }

                    CustomObject o = new CustomObject();
                    o.Property1 = d["Property1"] as string;
                    o.Property2 = d["Property2"] as int?;
                    o.Property3 = FromJsDictionary(Script.Reinterpret<JsDictionary>(d["Property3"]));
                    o.Property4 = CustomObject2.FromJsDictionary(Script.Reinterpret<JsDictionary>(d["Property4"]));
                    string Property5 = d["Property5"] as string;
                    o.Property5 = FrameworkUtility.EnumParse<SomeEnum>(Property5);
                    string Add = d["Add"] as string;
                    o.Add = Add == null ? (SomeEnum?)null : FrameworkUtility.EnumParse<SomeEnum>(Add);
                    return o;
                }

                public static JsDictionary ToJsDictionary(CustomObject o)
                {
                    if (o == null)
                    {
                        return null;
                    }

                    JsDictionary d = new JsDictionary();
                    d["Property1"] = o.Property1;
                    d["Property2"] = o.Property2;
                    d["Property3"] = ToJsDictionary(o.Property3);
                    d["Property4"] = CustomObject2.ToJsDictionary(o.Property4);
                    d["Property5"] = o.Property5.EnumToString();
                    d["Add"] = o.Add == null ? null : o.Add.Value.EnumToString();
                    return d;
                }
            }

            [PreserveMemberCase]
            public class CustomObject2
            {
                public string Property1 { get; set; }
                public int? Property2 { get; set; }
                public SomeEnum? Property3 { get; set; }

                public static CustomObject2 FromJsDictionary(JsDictionary d)
                {
                    if (d == null)
                    {
                        return null;
                    }

                    CustomObject2 o = new CustomObject2();
                    o.Property1 = d["Property1"] as string;
                    o.Property2 = d["Property2"] as int?;
                    string Property3 = d["Property3"] as string;
                    o.Property3 = Property3 == null ? (SomeEnum?)null : FrameworkUtility.EnumParse<SomeEnum>(Property3);
                    return o;
                }

                public static JsDictionary ToJsDictionary(CustomObject2 o)
                {
                    if (o == null)
                    {
                        return null;
                    }

                    JsDictionary d = new JsDictionary();
                    d["Property1"] = o.Property1;
                    d["Property2"] = o.Property2;
                    d["Property3"] = o.Property3 == null ? null : o.Property3.Value.EnumToString();
                    return d;
                }
            }

            [PreserveMemberCase]
            public enum SomeEnum
            {
                Value1,
                Value2,
                Value3
            }
        }
    }
}