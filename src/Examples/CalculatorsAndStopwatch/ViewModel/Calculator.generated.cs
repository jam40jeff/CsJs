//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18046
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MorseCode.CsJs.Examples.CalculatorAndStopwatch.ViewModel.CalculatorServiceReference
{
    
    
    public class CalculatorClient : MorseCode.CsJs.Net.SoapClient
    {
        
        #region TestMethod Method
        private System.Collections.Generic.Dictionary<string, object> GetParametersForTestMethod(System.Nullable<double> operand1, int operand2, bool simulateLatency, string something, CustomObject Add, System.Collections.Generic.List<string> somethingElse, System.Collections.Generic.List<int> somethingElseAgain, System.Collections.Generic.List<System.Nullable<int>> somethingElseNullable, System.Collections.Generic.List<CustomObject> somethingElseAgain2)
        {
            System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
            System.Array tempArray;
            parameters.Add("operand1", operand1);
            parameters.Add("operand2", operand2);
            parameters.Add("simulateLatency", simulateLatency);
            parameters.Add("something", something);
            parameters.Add("Add", CustomObject.ToJsDictionary(Add));
            tempArray = new System.Array();
            if ((somethingElse != null))
            {
                for (int i = 0; (i < somethingElse.Count); i = (i + 1))
                {
                    tempArray[i] = somethingElse[i];
                }
            }
            parameters.Add("somethingElse", tempArray);
            tempArray = new System.Array();
            if ((somethingElseAgain != null))
            {
                for (int i = 0; (i < somethingElseAgain.Count); i = (i + 1))
                {
                    tempArray[i] = somethingElseAgain[i];
                }
            }
            parameters.Add("somethingElseAgain", tempArray);
            tempArray = new System.Array();
            if ((somethingElseNullable != null))
            {
                for (int i = 0; (i < somethingElseNullable.Count); i = (i + 1))
                {
                    tempArray[i] = somethingElseNullable[i];
                }
            }
            parameters.Add("somethingElseNullable", tempArray);
            tempArray = new System.Array();
            if ((somethingElseAgain2 != null))
            {
                for (int i = 0; (i < somethingElseAgain2.Count); i = (i + 1))
                {
                    tempArray[i] = CustomObject.ToJsDictionary(somethingElseAgain2[i]);
                }
            }
            parameters.Add("somethingElseAgain2", tempArray);
            return parameters;
        }
        
        private CustomObject ConvertReturnValueForTestMethod(object value)
        {
            return CustomObject.FromJsDictionary(System.Script.Reinterpret<System.Collections.JsDictionary>(value));
        }
        
        public void TestMethod(System.Nullable<double> operand1, int operand2, bool simulateLatency, string something, CustomObject Add, System.Collections.Generic.List<string> somethingElse, System.Collections.Generic.List<int> somethingElseAgain, System.Collections.Generic.List<System.Nullable<int>> somethingElseNullable, System.Collections.Generic.List<CustomObject> somethingElseAgain2, System.Action<CustomObject> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback)
        {
            this.Invoke("TestMethod", this.GetParametersForTestMethod(operand1, operand2, simulateLatency, something, Add, somethingElse, somethingElseAgain, somethingElseNullable, somethingElseAgain2), o => successCallback(ConvertReturnValueForTestMethod(o)), errorCallback);
        }
        
        public void TestMethod(System.Nullable<double> operand1, int operand2, bool simulateLatency, string something, CustomObject Add, System.Collections.Generic.List<string> somethingElse, System.Collections.Generic.List<int> somethingElseAgain, System.Collections.Generic.List<System.Nullable<int>> somethingElseNullable, System.Collections.Generic.List<CustomObject> somethingElseAgain2, System.Action<CustomObject, string, jQueryApi.jQueryXmlHttpRequest> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback)
        {
            this.Invoke("TestMethod", this.GetParametersForTestMethod(operand1, operand2, simulateLatency, something, Add, somethingElse, somethingElseAgain, somethingElseNullable, somethingElseAgain2), (o,e,r) => successCallback(ConvertReturnValueForTestMethod(o),e,r), errorCallback);
        }
        
        public void TestMethod(System.Nullable<double> operand1, int operand2, bool simulateLatency, string something, CustomObject Add, System.Collections.Generic.List<string> somethingElse, System.Collections.Generic.List<int> somethingElseAgain, System.Collections.Generic.List<System.Nullable<int>> somethingElseNullable, System.Collections.Generic.List<CustomObject> somethingElseAgain2, System.Action<CustomObject> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> wsdlErrorCallback)
        {
            this.Invoke("TestMethod", this.GetParametersForTestMethod(operand1, operand2, simulateLatency, something, Add, somethingElse, somethingElseAgain, somethingElseNullable, somethingElseAgain2), (o) => successCallback(ConvertReturnValueForTestMethod(o)), errorCallback, wsdlErrorCallback);
        }
        
        public void TestMethod(System.Nullable<double> operand1, int operand2, bool simulateLatency, string something, CustomObject Add, System.Collections.Generic.List<string> somethingElse, System.Collections.Generic.List<int> somethingElseAgain, System.Collections.Generic.List<System.Nullable<int>> somethingElseNullable, System.Collections.Generic.List<CustomObject> somethingElseAgain2, System.Action<CustomObject, string, jQueryApi.jQueryXmlHttpRequest> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> wsdlErrorCallback)
        {
            this.Invoke("TestMethod", this.GetParametersForTestMethod(operand1, operand2, simulateLatency, something, Add, somethingElse, somethingElseAgain, somethingElseNullable, somethingElseAgain2), (o,e,r) => successCallback(ConvertReturnValueForTestMethod(o),e,r), errorCallback, wsdlErrorCallback);
        }
        #endregion
        
        #region Add Method
        private System.Collections.Generic.Dictionary<string, object> GetParametersForAdd(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency)
        {
            System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
            parameters.Add("operand1", operand1);
            parameters.Add("operand2", operand2);
            parameters.Add("simulateLatency", simulateLatency);
            return parameters;
        }
        
        private System.Nullable<double> ConvertReturnValueForAdd(object value)
        {
            return System.Script.Reinterpret<System.Nullable<double>>(value);
        }
        
        public void Add(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency, System.Action<System.Nullable<double>> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback)
        {
            this.Invoke("Add", this.GetParametersForAdd(operand1, operand2, simulateLatency), o => successCallback(ConvertReturnValueForAdd(o)), errorCallback);
        }
        
        public void Add(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency, System.Action<System.Nullable<double>, string, jQueryApi.jQueryXmlHttpRequest> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback)
        {
            this.Invoke("Add", this.GetParametersForAdd(operand1, operand2, simulateLatency), (o,e,r) => successCallback(ConvertReturnValueForAdd(o),e,r), errorCallback);
        }
        
        public void Add(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency, System.Action<System.Nullable<double>> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> wsdlErrorCallback)
        {
            this.Invoke("Add", this.GetParametersForAdd(operand1, operand2, simulateLatency), (o) => successCallback(ConvertReturnValueForAdd(o)), errorCallback, wsdlErrorCallback);
        }
        
        public void Add(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency, System.Action<System.Nullable<double>, string, jQueryApi.jQueryXmlHttpRequest> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> wsdlErrorCallback)
        {
            this.Invoke("Add", this.GetParametersForAdd(operand1, operand2, simulateLatency), (o,e,r) => successCallback(ConvertReturnValueForAdd(o),e,r), errorCallback, wsdlErrorCallback);
        }
        #endregion
        
        #region Subtract Method
        private System.Collections.Generic.Dictionary<string, object> GetParametersForSubtract(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency)
        {
            System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
            parameters.Add("operand1", operand1);
            parameters.Add("operand2", operand2);
            parameters.Add("simulateLatency", simulateLatency);
            return parameters;
        }
        
        private System.Nullable<double> ConvertReturnValueForSubtract(object value)
        {
            return System.Script.Reinterpret<System.Nullable<double>>(value);
        }
        
        public void Subtract(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency, System.Action<System.Nullable<double>> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback)
        {
            this.Invoke("Subtract", this.GetParametersForSubtract(operand1, operand2, simulateLatency), o => successCallback(ConvertReturnValueForSubtract(o)), errorCallback);
        }
        
        public void Subtract(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency, System.Action<System.Nullable<double>, string, jQueryApi.jQueryXmlHttpRequest> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback)
        {
            this.Invoke("Subtract", this.GetParametersForSubtract(operand1, operand2, simulateLatency), (o,e,r) => successCallback(ConvertReturnValueForSubtract(o),e,r), errorCallback);
        }
        
        public void Subtract(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency, System.Action<System.Nullable<double>> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> wsdlErrorCallback)
        {
            this.Invoke("Subtract", this.GetParametersForSubtract(operand1, operand2, simulateLatency), (o) => successCallback(ConvertReturnValueForSubtract(o)), errorCallback, wsdlErrorCallback);
        }
        
        public void Subtract(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency, System.Action<System.Nullable<double>, string, jQueryApi.jQueryXmlHttpRequest> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> wsdlErrorCallback)
        {
            this.Invoke("Subtract", this.GetParametersForSubtract(operand1, operand2, simulateLatency), (o,e,r) => successCallback(ConvertReturnValueForSubtract(o),e,r), errorCallback, wsdlErrorCallback);
        }
        #endregion
        
        #region Multiply Method
        private System.Collections.Generic.Dictionary<string, object> GetParametersForMultiply(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency)
        {
            System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
            parameters.Add("operand1", operand1);
            parameters.Add("operand2", operand2);
            parameters.Add("simulateLatency", simulateLatency);
            return parameters;
        }
        
        private System.Nullable<double> ConvertReturnValueForMultiply(object value)
        {
            return System.Script.Reinterpret<System.Nullable<double>>(value);
        }
        
        public void Multiply(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency, System.Action<System.Nullable<double>> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback)
        {
            this.Invoke("Multiply", this.GetParametersForMultiply(operand1, operand2, simulateLatency), o => successCallback(ConvertReturnValueForMultiply(o)), errorCallback);
        }
        
        public void Multiply(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency, System.Action<System.Nullable<double>, string, jQueryApi.jQueryXmlHttpRequest> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback)
        {
            this.Invoke("Multiply", this.GetParametersForMultiply(operand1, operand2, simulateLatency), (o,e,r) => successCallback(ConvertReturnValueForMultiply(o),e,r), errorCallback);
        }
        
        public void Multiply(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency, System.Action<System.Nullable<double>> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> wsdlErrorCallback)
        {
            this.Invoke("Multiply", this.GetParametersForMultiply(operand1, operand2, simulateLatency), (o) => successCallback(ConvertReturnValueForMultiply(o)), errorCallback, wsdlErrorCallback);
        }
        
        public void Multiply(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency, System.Action<System.Nullable<double>, string, jQueryApi.jQueryXmlHttpRequest> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> wsdlErrorCallback)
        {
            this.Invoke("Multiply", this.GetParametersForMultiply(operand1, operand2, simulateLatency), (o,e,r) => successCallback(ConvertReturnValueForMultiply(o),e,r), errorCallback, wsdlErrorCallback);
        }
        #endregion
        
        #region Divide Method
        private System.Collections.Generic.Dictionary<string, object> GetParametersForDivide(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency)
        {
            System.Collections.Generic.Dictionary<string, object> parameters = new System.Collections.Generic.Dictionary<string, object>();
            parameters.Add("operand1", operand1);
            parameters.Add("operand2", operand2);
            parameters.Add("simulateLatency", simulateLatency);
            return parameters;
        }
        
        private System.Nullable<double> ConvertReturnValueForDivide(object value)
        {
            return System.Script.Reinterpret<System.Nullable<double>>(value);
        }
        
        public void Divide(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency, System.Action<System.Nullable<double>> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback)
        {
            this.Invoke("Divide", this.GetParametersForDivide(operand1, operand2, simulateLatency), o => successCallback(ConvertReturnValueForDivide(o)), errorCallback);
        }
        
        public void Divide(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency, System.Action<System.Nullable<double>, string, jQueryApi.jQueryXmlHttpRequest> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback)
        {
            this.Invoke("Divide", this.GetParametersForDivide(operand1, operand2, simulateLatency), (o,e,r) => successCallback(ConvertReturnValueForDivide(o),e,r), errorCallback);
        }
        
        public void Divide(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency, System.Action<System.Nullable<double>> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> wsdlErrorCallback)
        {
            this.Invoke("Divide", this.GetParametersForDivide(operand1, operand2, simulateLatency), (o) => successCallback(ConvertReturnValueForDivide(o)), errorCallback, wsdlErrorCallback);
        }
        
        public void Divide(System.Nullable<double> operand1, System.Nullable<double> operand2, bool simulateLatency, System.Action<System.Nullable<double>, string, jQueryApi.jQueryXmlHttpRequest> successCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> errorCallback, System.Action<jQueryApi.jQueryXmlHttpRequest, string, string> wsdlErrorCallback)
        {
            this.Invoke("Divide", this.GetParametersForDivide(operand1, operand2, simulateLatency), (o,e,r) => successCallback(ConvertReturnValueForDivide(o),e,r), errorCallback, wsdlErrorCallback);
        }
        #endregion
    }
    
    public abstract class EnumConverters
    {
        
        private EnumConverters()
        {
        }
        
        public static string ConvertSomeEnumToString(SomeEnum value)
        {
            if ((value == SomeEnum.Value1))
            {
                return "Value1";
            }
            if ((value == SomeEnum.Value2))
            {
                return "Value2";
            }
            if ((value == SomeEnum.Value3))
            {
                return "Value3";
            }
            throw new System.Exception(("Could not convert SomeEnum value " 
                            + (value + " to string.")));
        }
        
        public static string ConvertNullableSomeEnumToString(System.Nullable<SomeEnum> value)
        {
            if ((value == null))
            {
                return null;
            }
            else
            {
                return EnumConverters.ConvertSomeEnumToString(value.Value);
            }
        }
        
        public static SomeEnum ConvertStringToSomeEnum(string value)
        {
            if ((value == "Value1"))
            {
                return SomeEnum.Value1;
            }
            if ((value == "Value2"))
            {
                return SomeEnum.Value2;
            }
            if ((value == "Value3"))
            {
                return SomeEnum.Value3;
            }
            throw new System.Exception(("Could not convert string value " 
                            + (value + " to SomeEnum.")));
        }
        
        public static System.Nullable<SomeEnum> ConvertStringToNullableSomeEnum(string value)
        {
            if ((value == null))
            {
                return null;
            }
            else
            {
                return EnumConverters.ConvertStringToSomeEnum(value);
            }
        }
    }
    
    [System.Runtime.CompilerServices.PreserveMemberCase()]
    public class CustomObject
    {
        
        private System.Nullable<SomeEnum> _add;
        
        private string _property1;
        
        private System.Nullable<int> _property2;
        
        private System.Collections.Generic.List<CustomObject> _property3 = new System.Collections.Generic.List<CustomObject>();
        
        private CustomObject2 _property4;
        
        private SomeEnum _property5;
        
        public System.Nullable<SomeEnum> Add
        {
            get
            {
                return this._add;
            }
            set
            {
                this._add = value;
            }
        }
        
        public string Property1
        {
            get
            {
                return this._property1;
            }
            set
            {
                this._property1 = value;
            }
        }
        
        public System.Nullable<int> Property2
        {
            get
            {
                return this._property2;
            }
            set
            {
                this._property2 = value;
            }
        }
        
        public System.Collections.Generic.List<CustomObject> Property3
        {
            get
            {
                return this._property3;
            }
        }
        
        public CustomObject2 Property4
        {
            get
            {
                return this._property4;
            }
            set
            {
                this._property4 = value;
            }
        }
        
        public SomeEnum Property5
        {
            get
            {
                return this._property5;
            }
            set
            {
                this._property5 = value;
            }
        }
        
        public static CustomObject FromJsDictionary(System.Collections.JsDictionary value)
        {
            if ((value == null))
            {
                return null;
            }
            CustomObject returnValue = new CustomObject();
            returnValue.Add = EnumConverters.ConvertStringToNullableSomeEnum(System.Script.Reinterpret<string>(value["Add"]));
            returnValue.Property1 = System.Script.Reinterpret<string>(value["Property1"]);
            returnValue.Property2 = System.Script.Reinterpret<System.Nullable<int>>(value["Property2"]);
            for (int i = 0; (i < System.Script.Reinterpret<System.Array>(value["Property3"]).Length); i = (i + 1))
            {
                returnValue.Property3.Add(CustomObject.FromJsDictionary(System.Script.Reinterpret<System.Collections.JsDictionary>(System.Script.Reinterpret<System.Array>(value["Property3"])[i])));
            }
            returnValue.Property4 = CustomObject2.FromJsDictionary(System.Script.Reinterpret<System.Collections.JsDictionary>(value["Property4"]));
            returnValue.Property5 = EnumConverters.ConvertStringToSomeEnum(System.Script.Reinterpret<string>(value["Property5"]));
            return returnValue;
        }
        
        public static System.Collections.JsDictionary ToJsDictionary(CustomObject value)
        {
            if ((value == null))
            {
                return null;
            }
            System.Collections.JsDictionary returnValue = new System.Collections.JsDictionary();
            returnValue["Add"] = EnumConverters.ConvertNullableSomeEnumToString(value.Add);
            returnValue["Property1"] = value.Property1;
            returnValue["Property2"] = value.Property2;
            returnValue["Property3"] = new System.Array();
            for (int i = 0; (i < value.Property3.Count); i = (i + 1))
            {
                System.Script.Reinterpret<System.Array>(returnValue["Property3"])[i] = CustomObject.ToJsDictionary(value.Property3[i]);
            }
            returnValue["Property4"] = CustomObject2.ToJsDictionary(value.Property4);
            returnValue["Property5"] = EnumConverters.ConvertSomeEnumToString(value.Property5);
            return returnValue;
        }
    }
    
    [System.Runtime.CompilerServices.PreserveMemberCase()]
    public enum SomeEnum
    {
        
        Value1,
        
        Value2,
        
        Value3,
    }
    
    [System.Runtime.CompilerServices.PreserveMemberCase()]
    public class CustomObject2
    {
        
        private string _property1;
        
        private System.Nullable<int> _property2;
        
        private System.Nullable<SomeEnum> _property3;
        
        public string Property1
        {
            get
            {
                return this._property1;
            }
            set
            {
                this._property1 = value;
            }
        }
        
        public System.Nullable<int> Property2
        {
            get
            {
                return this._property2;
            }
            set
            {
                this._property2 = value;
            }
        }
        
        public System.Nullable<SomeEnum> Property3
        {
            get
            {
                return this._property3;
            }
            set
            {
                this._property3 = value;
            }
        }
        
        public static CustomObject2 FromJsDictionary(System.Collections.JsDictionary value)
        {
            if ((value == null))
            {
                return null;
            }
            CustomObject2 returnValue = new CustomObject2();
            returnValue.Property1 = System.Script.Reinterpret<string>(value["Property1"]);
            returnValue.Property2 = System.Script.Reinterpret<System.Nullable<int>>(value["Property2"]);
            returnValue.Property3 = EnumConverters.ConvertStringToNullableSomeEnum(System.Script.Reinterpret<string>(value["Property3"]));
            return returnValue;
        }
        
        public static System.Collections.JsDictionary ToJsDictionary(CustomObject2 value)
        {
            if ((value == null))
            {
                return null;
            }
            System.Collections.JsDictionary returnValue = new System.Collections.JsDictionary();
            returnValue["Property1"] = value.Property1;
            returnValue["Property2"] = value.Property2;
            returnValue["Property3"] = EnumConverters.ConvertNullableSomeEnumToString(value.Property3);
            return returnValue;
        }
    }
}