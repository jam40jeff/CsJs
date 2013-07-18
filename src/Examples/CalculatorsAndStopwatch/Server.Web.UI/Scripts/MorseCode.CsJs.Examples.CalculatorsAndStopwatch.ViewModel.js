(function() {
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorAndStopwatch.ViewModel.CalculatorServiceReference.CalculatorClient
	var $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CalculatorClient = function() {
		MorseCode.CsJs.Net.SoapClient.call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CalculatorClient.prototype = {
		$getParametersForTestMethod: function(operand1, operand2, simulateLatency, something, Add, somethingElse, somethingElseAgain, somethingElseNullable, somethingElseAgain2) {
			var parameters = new (ss.makeGenericType(ss.Dictionary$2, [String, Object]))();
			var tempArray;
			parameters.add('operand1', operand1);
			parameters.add('operand2', operand2);
			parameters.add('simulateLatency', simulateLatency);
			parameters.add('something', something);
			parameters.add('Add', $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject.ToJsDictionary(Add));
			tempArray = new Array();
			if (ss.isValue(somethingElse)) {
				for (var i = 0; i < somethingElse.length; i = i + 1) {
					tempArray[i] = somethingElse[i];
				}
			}
			parameters.add('somethingElse', tempArray);
			tempArray = new Array();
			if (ss.isValue(somethingElseAgain)) {
				for (var i1 = 0; i1 < somethingElseAgain.length; i1 = i1 + 1) {
					tempArray[i1] = somethingElseAgain[i1];
				}
			}
			parameters.add('somethingElseAgain', tempArray);
			tempArray = new Array();
			if (ss.isValue(somethingElseNullable)) {
				for (var i2 = 0; i2 < somethingElseNullable.length; i2 = i2 + 1) {
					tempArray[i2] = somethingElseNullable[i2];
				}
			}
			parameters.add('somethingElseNullable', tempArray);
			tempArray = new Array();
			if (ss.isValue(somethingElseAgain2)) {
				for (var i3 = 0; i3 < somethingElseAgain2.length; i3 = i3 + 1) {
					tempArray[i3] = $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject.ToJsDictionary(somethingElseAgain2[i3]);
				}
			}
			parameters.add('somethingElseAgain2', tempArray);
			return parameters;
		},
		$convertReturnValueForTestMethod: function(value) {
			return $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject.FromJsDictionary(value);
		},
		testMethod: function(operand1, operand2, simulateLatency, something, Add, somethingElse, somethingElseAgain, somethingElseNullable, somethingElseAgain2, successCallback, errorCallback) {
			this.invoke('TestMethod', this.$getParametersForTestMethod(operand1, operand2, simulateLatency, something, Add, somethingElse, somethingElseAgain, somethingElseNullable, somethingElseAgain2), ss.mkdel(this, function(o) {
				successCallback(this.$convertReturnValueForTestMethod(o));
			}), errorCallback);
		},
		testMethod$1: function(operand1, operand2, simulateLatency, something, Add, somethingElse, somethingElseAgain, somethingElseNullable, somethingElseAgain2, successCallback, errorCallback) {
			this.invoke$1('TestMethod', this.$getParametersForTestMethod(operand1, operand2, simulateLatency, something, Add, somethingElse, somethingElseAgain, somethingElseNullable, somethingElseAgain2), ss.mkdel(this, function(o, e, r) {
				successCallback(this.$convertReturnValueForTestMethod(o), e, r);
			}), errorCallback);
		},
		testMethod$2: function(operand1, operand2, simulateLatency, something, Add, somethingElse, somethingElseAgain, somethingElseNullable, somethingElseAgain2, successCallback, errorCallback, wsdlErrorCallback) {
			this.invoke$2('TestMethod', this.$getParametersForTestMethod(operand1, operand2, simulateLatency, something, Add, somethingElse, somethingElseAgain, somethingElseNullable, somethingElseAgain2), ss.mkdel(this, function(o) {
				successCallback(this.$convertReturnValueForTestMethod(o));
			}), errorCallback, wsdlErrorCallback);
		},
		testMethod$3: function(operand1, operand2, simulateLatency, something, Add, somethingElse, somethingElseAgain, somethingElseNullable, somethingElseAgain2, successCallback, errorCallback, wsdlErrorCallback) {
			this.invoke$3('TestMethod', this.$getParametersForTestMethod(operand1, operand2, simulateLatency, something, Add, somethingElse, somethingElseAgain, somethingElseNullable, somethingElseAgain2), ss.mkdel(this, function(o, e, r) {
				successCallback(this.$convertReturnValueForTestMethod(o), e, r);
			}), errorCallback, wsdlErrorCallback);
		},
		$getParametersForAdd: function(operand1, operand2, simulateLatency) {
			var parameters = new (ss.makeGenericType(ss.Dictionary$2, [String, Object]))();
			parameters.add('operand1', operand1);
			parameters.add('operand2', operand2);
			parameters.add('simulateLatency', simulateLatency);
			return parameters;
		},
		$convertReturnValueForAdd: function(value) {
			return value;
		},
		add: function(operand1, operand2, simulateLatency, successCallback, errorCallback) {
			this.invoke('Add', this.$getParametersForAdd(operand1, operand2, simulateLatency), ss.mkdel(this, function(o) {
				successCallback(this.$convertReturnValueForAdd(o));
			}), errorCallback);
		},
		add$1: function(operand1, operand2, simulateLatency, successCallback, errorCallback) {
			this.invoke$1('Add', this.$getParametersForAdd(operand1, operand2, simulateLatency), ss.mkdel(this, function(o, e, r) {
				successCallback(this.$convertReturnValueForAdd(o), e, r);
			}), errorCallback);
		},
		add$2: function(operand1, operand2, simulateLatency, successCallback, errorCallback, wsdlErrorCallback) {
			this.invoke$2('Add', this.$getParametersForAdd(operand1, operand2, simulateLatency), ss.mkdel(this, function(o) {
				successCallback(this.$convertReturnValueForAdd(o));
			}), errorCallback, wsdlErrorCallback);
		},
		add$3: function(operand1, operand2, simulateLatency, successCallback, errorCallback, wsdlErrorCallback) {
			this.invoke$3('Add', this.$getParametersForAdd(operand1, operand2, simulateLatency), ss.mkdel(this, function(o, e, r) {
				successCallback(this.$convertReturnValueForAdd(o), e, r);
			}), errorCallback, wsdlErrorCallback);
		},
		$getParametersForSubtract: function(operand1, operand2, simulateLatency) {
			var parameters = new (ss.makeGenericType(ss.Dictionary$2, [String, Object]))();
			parameters.add('operand1', operand1);
			parameters.add('operand2', operand2);
			parameters.add('simulateLatency', simulateLatency);
			return parameters;
		},
		$convertReturnValueForSubtract: function(value) {
			return value;
		},
		subtract: function(operand1, operand2, simulateLatency, successCallback, errorCallback) {
			this.invoke('Subtract', this.$getParametersForSubtract(operand1, operand2, simulateLatency), ss.mkdel(this, function(o) {
				successCallback(this.$convertReturnValueForSubtract(o));
			}), errorCallback);
		},
		subtract$1: function(operand1, operand2, simulateLatency, successCallback, errorCallback) {
			this.invoke$1('Subtract', this.$getParametersForSubtract(operand1, operand2, simulateLatency), ss.mkdel(this, function(o, e, r) {
				successCallback(this.$convertReturnValueForSubtract(o), e, r);
			}), errorCallback);
		},
		subtract$2: function(operand1, operand2, simulateLatency, successCallback, errorCallback, wsdlErrorCallback) {
			this.invoke$2('Subtract', this.$getParametersForSubtract(operand1, operand2, simulateLatency), ss.mkdel(this, function(o) {
				successCallback(this.$convertReturnValueForSubtract(o));
			}), errorCallback, wsdlErrorCallback);
		},
		subtract$3: function(operand1, operand2, simulateLatency, successCallback, errorCallback, wsdlErrorCallback) {
			this.invoke$3('Subtract', this.$getParametersForSubtract(operand1, operand2, simulateLatency), ss.mkdel(this, function(o, e, r) {
				successCallback(this.$convertReturnValueForSubtract(o), e, r);
			}), errorCallback, wsdlErrorCallback);
		},
		$getParametersForMultiply: function(operand1, operand2, simulateLatency) {
			var parameters = new (ss.makeGenericType(ss.Dictionary$2, [String, Object]))();
			parameters.add('operand1', operand1);
			parameters.add('operand2', operand2);
			parameters.add('simulateLatency', simulateLatency);
			return parameters;
		},
		$convertReturnValueForMultiply: function(value) {
			return value;
		},
		multiply: function(operand1, operand2, simulateLatency, successCallback, errorCallback) {
			this.invoke('Multiply', this.$getParametersForMultiply(operand1, operand2, simulateLatency), ss.mkdel(this, function(o) {
				successCallback(this.$convertReturnValueForMultiply(o));
			}), errorCallback);
		},
		multiply$1: function(operand1, operand2, simulateLatency, successCallback, errorCallback) {
			this.invoke$1('Multiply', this.$getParametersForMultiply(operand1, operand2, simulateLatency), ss.mkdel(this, function(o, e, r) {
				successCallback(this.$convertReturnValueForMultiply(o), e, r);
			}), errorCallback);
		},
		multiply$2: function(operand1, operand2, simulateLatency, successCallback, errorCallback, wsdlErrorCallback) {
			this.invoke$2('Multiply', this.$getParametersForMultiply(operand1, operand2, simulateLatency), ss.mkdel(this, function(o) {
				successCallback(this.$convertReturnValueForMultiply(o));
			}), errorCallback, wsdlErrorCallback);
		},
		multiply$3: function(operand1, operand2, simulateLatency, successCallback, errorCallback, wsdlErrorCallback) {
			this.invoke$3('Multiply', this.$getParametersForMultiply(operand1, operand2, simulateLatency), ss.mkdel(this, function(o, e, r) {
				successCallback(this.$convertReturnValueForMultiply(o), e, r);
			}), errorCallback, wsdlErrorCallback);
		},
		$getParametersForDivide: function(operand1, operand2, simulateLatency) {
			var parameters = new (ss.makeGenericType(ss.Dictionary$2, [String, Object]))();
			parameters.add('operand1', operand1);
			parameters.add('operand2', operand2);
			parameters.add('simulateLatency', simulateLatency);
			return parameters;
		},
		$convertReturnValueForDivide: function(value) {
			return value;
		},
		divide: function(operand1, operand2, simulateLatency, successCallback, errorCallback) {
			this.invoke('Divide', this.$getParametersForDivide(operand1, operand2, simulateLatency), ss.mkdel(this, function(o) {
				successCallback(this.$convertReturnValueForDivide(o));
			}), errorCallback);
		},
		divide$1: function(operand1, operand2, simulateLatency, successCallback, errorCallback) {
			this.invoke$1('Divide', this.$getParametersForDivide(operand1, operand2, simulateLatency), ss.mkdel(this, function(o, e, r) {
				successCallback(this.$convertReturnValueForDivide(o), e, r);
			}), errorCallback);
		},
		divide$2: function(operand1, operand2, simulateLatency, successCallback, errorCallback, wsdlErrorCallback) {
			this.invoke$2('Divide', this.$getParametersForDivide(operand1, operand2, simulateLatency), ss.mkdel(this, function(o) {
				successCallback(this.$convertReturnValueForDivide(o));
			}), errorCallback, wsdlErrorCallback);
		},
		divide$3: function(operand1, operand2, simulateLatency, successCallback, errorCallback, wsdlErrorCallback) {
			this.invoke$3('Divide', this.$getParametersForDivide(operand1, operand2, simulateLatency), ss.mkdel(this, function(o, e, r) {
				successCallback(this.$convertReturnValueForDivide(o), e, r);
			}), errorCallback, wsdlErrorCallback);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorAndStopwatch.ViewModel.CalculatorServiceReference.CustomObject
	var $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject = function() {
		this.$_add = null;
		this.$_property1 = null;
		this.$_property2 = null;
		this.$_property3 = [];
		this.$_property4 = null;
		this.$_property5 = 0;
	};
	$MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject.prototype = {
		get_Add: function() {
			return this.$_add;
		},
		set_Add: function(value) {
			this.$_add = value;
		},
		get_Property1: function() {
			return this.$_property1;
		},
		set_Property1: function(value) {
			this.$_property1 = value;
		},
		get_Property2: function() {
			return this.$_property2;
		},
		set_Property2: function(value) {
			this.$_property2 = value;
		},
		get_Property3: function() {
			return this.$_property3;
		},
		get_Property4: function() {
			return this.$_property4;
		},
		set_Property4: function(value) {
			this.$_property4 = value;
		},
		get_Property5: function() {
			return this.$_property5;
		},
		set_Property5: function(value) {
			this.$_property5 = value;
		}
	};
	$MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject.FromJsDictionary = function(value) {
		if (ss.isNullOrUndefined(value)) {
			return null;
		}
		var returnValue = new $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject();
		returnValue.set_Add($MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_EnumConverters.convertStringToNullableSomeEnum(value['Add']));
		returnValue.set_Property1(value['Property1']);
		returnValue.set_Property2(value['Property2']);
		for (var i = 0; i < value['Property3'].length; i = i + 1) {
			ss.add(returnValue.get_Property3(), $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject.FromJsDictionary(value['Property3'][i]));
		}
		returnValue.set_Property4($MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject2.FromJsDictionary(value['Property4']));
		returnValue.set_Property5($MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_EnumConverters.convertStringToSomeEnum(value['Property5']));
		return returnValue;
	};
	$MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject.ToJsDictionary = function(value) {
		if (ss.isNullOrUndefined(value)) {
			return null;
		}
		var returnValue = {};
		returnValue['Add'] = $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_EnumConverters.convertNullableSomeEnumToString(value.get_Add());
		returnValue['Property1'] = value.get_Property1();
		returnValue['Property2'] = value.get_Property2();
		returnValue['Property3'] = new Array();
		for (var i = 0; i < value.get_Property3().length; i = i + 1) {
			returnValue['Property3'][i] = $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject.ToJsDictionary(value.get_Property3()[i]);
		}
		returnValue['Property4'] = $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject2.ToJsDictionary(value.get_Property4());
		returnValue['Property5'] = $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_EnumConverters.convertSomeEnumToString(value.get_Property5());
		return returnValue;
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorAndStopwatch.ViewModel.CalculatorServiceReference.CustomObject2
	var $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject2 = function() {
		this.$_property1 = null;
		this.$_property2 = null;
		this.$_property3 = null;
	};
	$MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject2.prototype = {
		get_Property1: function() {
			return this.$_property1;
		},
		set_Property1: function(value) {
			this.$_property1 = value;
		},
		get_Property2: function() {
			return this.$_property2;
		},
		set_Property2: function(value) {
			this.$_property2 = value;
		},
		get_Property3: function() {
			return this.$_property3;
		},
		set_Property3: function(value) {
			this.$_property3 = value;
		}
	};
	$MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject2.FromJsDictionary = function(value) {
		if (ss.isNullOrUndefined(value)) {
			return null;
		}
		var returnValue = new $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject2();
		returnValue.set_Property1(value['Property1']);
		returnValue.set_Property2(value['Property2']);
		returnValue.set_Property3($MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_EnumConverters.convertStringToNullableSomeEnum(value['Property3']));
		return returnValue;
	};
	$MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject2.ToJsDictionary = function(value) {
		if (ss.isNullOrUndefined(value)) {
			return null;
		}
		var returnValue = {};
		returnValue['Property1'] = value.get_Property1();
		returnValue['Property2'] = value.get_Property2();
		returnValue['Property3'] = $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_EnumConverters.convertNullableSomeEnumToString(value.get_Property3());
		return returnValue;
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorAndStopwatch.ViewModel.CalculatorServiceReference.EnumConverters
	var $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_EnumConverters = function() {
	};
	$MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_EnumConverters.convertSomeEnumToString = function(value) {
		if (value === 0) {
			return 'Value1';
		}
		if (value === 1) {
			return 'Value2';
		}
		if (value === 2) {
			return 'Value3';
		}
		throw new ss.Exception('Could not convert SomeEnum value ' + (value + ' to string.'));
	};
	$MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_EnumConverters.convertNullableSomeEnumToString = function(value) {
		if (ss.Nullable.eq(value, null)) {
			return null;
		}
		else {
			return $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_EnumConverters.convertSomeEnumToString(ss.Nullable.unbox(value));
		}
	};
	$MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_EnumConverters.convertStringToSomeEnum = function(value) {
		if (value === 'Value1') {
			return 0;
		}
		if (value === 'Value2') {
			return 1;
		}
		if (value === 'Value3') {
			return 2;
		}
		throw new ss.Exception('Could not convert string value ' + (value + ' to SomeEnum.'));
	};
	$MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_EnumConverters.convertStringToNullableSomeEnum = function(value) {
		if (ss.isNullOrUndefined(value)) {
			return null;
		}
		else {
			return $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_EnumConverters.convertStringToSomeEnum(value);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorAndStopwatch.ViewModel.CalculatorServiceReference.SomeEnum
	var $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_SomeEnum = function() {
	};
	$MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_SomeEnum.prototype = { Value1: 0, Value2: 1, Value3: 2 };
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ApplicationErrorEventArgs
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_ApplicationErrorEventArgs = function(errorMessage, url, lineNumber) {
		this.$_errorMessage = null;
		this.$_url = null;
		this.$_lineNumber = 0;
		ss.EventArgs.call(this);
		this.$_errorMessage = errorMessage;
		this.$_url = url;
		this.$_lineNumber = lineNumber;
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_ApplicationErrorEventArgs.prototype = {
		get_errorMessage: function() {
			return this.$_errorMessage;
		},
		get_url: function() {
			return this.$_url;
		},
		get_lineNumber: function() {
			return this.$_lineNumber;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorPageViewModel
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorPageViewModel = function(applicationViewModel) {
		this.$_applicationViewModel = null;
		this.$_navigationViewModel = null;
		this.$_calculatorViewModel1 = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModel();
		this.$_calculatorViewModel2 = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModel();
		this.$_isCalculator2 = null;
		this.$_calculatorViewModel = null;
		this.$_calculatorText = null;
		this.$_applicationViewModel = applicationViewModel;
		this.$_navigationViewModel = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_NavigationViewModel(this.$_applicationViewModel);
		this.$_isCalculator2 = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [Boolean]))();
		this.$_calculatorViewModel = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModel]).$ctor1)(this.$_calculatorViewModel1);
		this.$_calculatorText = ss.makeGenericType(MorseCode.CsJs.Common.Observable.CalculatedProperty$1, [String]).create(ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [Boolean])).call(null, this.$_isCalculator2, function(isCalculator2) {
			return 'Calculator ' + (isCalculator2.get_value() ? '2' : '1');
		}, null);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorPageViewModel.prototype = {
		get_navigationViewModel: function() {
			return this.$_navigationViewModel;
		},
		get_calculatorViewModel: function() {
			return this.$_calculatorViewModel;
		},
		get_calculatorText: function() {
			return this.$_calculatorText;
		},
		switchCalculators: function() {
			this.get_calculatorViewModel().set_value$2((this.$_isCalculator2.get_value() ? this.$_calculatorViewModel1 : this.$_calculatorViewModel2));
			this.$_isCalculator2.set_value$2(!this.$_isCalculator2.get_value());
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchApplicationViewModel
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorsAndStopwatchApplicationViewModel = function() {
		this.$2$ApplicationErrorField = null;
		MorseCode.CsJs.ViewModel.ApplicationViewModelBase.call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorsAndStopwatchApplicationViewModel.prototype = {
		add_applicationError: function(value) {
			this.$2$ApplicationErrorField = ss.delegateCombine(this.$2$ApplicationErrorField, value);
		},
		remove_applicationError: function(value) {
			this.$2$ApplicationErrorField = ss.delegateRemove(this.$2$ApplicationErrorField, value);
		},
		onApplicationError: function(e) {
			var handler = this.$2$ApplicationErrorField;
			if (!ss.staticEquals(handler, null)) {
				handler(this, e);
			}
		},
		onError: function(errorMessage, url, lineNumber) {
			this.onApplicationError(new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_ApplicationErrorEventArgs(errorMessage, url, lineNumber));
			return true;
		},
		get_defaultViewModel: function() {
			return new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorsAndStopwatchPageViewModel(this);
		},
		navigateToStopwatchPage: function() {
			this.currentViewModelInternal.set_value$2(new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchPageViewModel(this));
		},
		navigateToCalculatorPage: function() {
			this.currentViewModelInternal.set_value$2(new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorPageViewModel(this));
		},
		navigateToGridPage: function() {
			this.currentViewModelInternal.set_value$2(new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_GridPageViewModel(this));
		},
		navigateToCalculatorsAndStopwatchPage: function() {
			this.currentViewModelInternal.set_value$2(new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorsAndStopwatchPageViewModel(this));
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorsAndStopwatchPageViewModel = function(applicationViewModel) {
		this.$_applicationViewModel = null;
		this.$_navigationViewModel = null;
		this.$_calculatorViewModel1 = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModel();
		this.$_calculatorViewModel2 = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_RemoteCalculatorViewModel();
		this.$_stopwatchViewModel = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchViewModel();
		this.$_isCalculator2 = null;
		this.$_calculatorViewModel = null;
		this.$_calculatorText = null;
		this.$_applicationViewModel = applicationViewModel;
		this.$_navigationViewModel = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_NavigationViewModel(this.$_applicationViewModel);
		this.$_isCalculator2 = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [Boolean]))();
		this.$_calculatorViewModel = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_ICalculatorViewModel]).$ctor1)(this.$_calculatorViewModel1);
		this.$_calculatorText = ss.makeGenericType(MorseCode.CsJs.Common.Observable.CalculatedProperty$1, [String]).create(ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [Boolean])).call(null, this.$_isCalculator2, function(isCalculator2) {
			return 'Calculator ' + (isCalculator2.get_value() ? '2' : '1');
		}, null);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorsAndStopwatchPageViewModel.prototype = {
		get_navigationViewModel: function() {
			return this.$_navigationViewModel;
		},
		get_calculatorViewModel: function() {
			return this.$_calculatorViewModel;
		},
		get_stopwatchViewModel: function() {
			return this.$_stopwatchViewModel;
		},
		get_calculatorText: function() {
			return this.$_calculatorText;
		},
		switchCalculators: function() {
			this.get_calculatorViewModel().set_value$2((this.$_isCalculator2.get_value() ? this.$_calculatorViewModel1 : this.$_calculatorViewModel2));
			this.$_isCalculator2.set_value$2(!this.$_isCalculator2.get_value());
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorViewModel
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModel = function() {
		this.$_result = null;
		$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModelBase.call(this, false);
		this.$_result = ss.makeGenericType(MorseCode.CsJs.Common.Observable.CalculatedProperty$1, [String]).create$2(ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [String]), ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [String]), ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [ss.Nullable])).call(null, this.get_operand1(), this.get_operand2(), this.get_selectedOperator(), function(operand1, operand2, selectedOperator) {
			if (ss.Nullable.eq(selectedOperator.get_value(), null)) {
				return null;
			}
			var function1;
			switch (ss.Nullable.unbox(selectedOperator.get_value())) {
				case 0: {
					function1 = function(x, y) {
						return ss.Nullable.add(x, y);
					};
					break;
				}
				case 1: {
					function1 = function(x1, y1) {
						return ss.Nullable.sub(x1, y1);
					};
					break;
				}
				case 2: {
					function1 = function(x2, y2) {
						return ss.Nullable.mul(x2, y2);
					};
					break;
				}
				case 3: {
					function1 = function(x3, y3) {
						return ss.Nullable.div(x3, y3);
					};
					break;
				}
				default: {
					throw new ss.NotSupportedException('Unknown enum value ' + ss.Nullable.unbox(selectedOperator.get_value()) + '.');
				}
			}
			return MorseCode.CsJs.Common.FrameworkUtility.safeToString(function1(MorseCode.CsJs.Common.FrameworkUtility.doubleTryParse(operand1.get_value()), MorseCode.CsJs.Common.FrameworkUtility.doubleTryParse(operand2.get_value())));
		}, null);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModel.prototype = {
		get_result: function() {
			return this.$_result;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorViewModelBase
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModelBase = function(supportsAsync) {
		this.$_updateInRealTimeItems = null;
		this.$_updateInRealTimeSelection = null;
		this.$_updateInRealTime = null;
		this.$_supportsAsync = null;
		this.$_simulateLatencyItems = null;
		this.$_simulateLatencySelection = null;
		this.$_simulateLatency = null;
		this.$_operators = null;
		this.$_operand1 = null;
		this.$_selectedOperator = null;
		this.$_selectedOperatorString = null;
		this.$_operand2 = null;
		this.$_updateInRealTimeItems = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableCollection$1, [Boolean]).$ctor1)([true, false]);
		this.$_updateInRealTimeSelection = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [ss.Nullable]).$ctor1)(true);
		this.$_updateInRealTime = ss.makeGenericType(MorseCode.CsJs.Common.Observable.CalculatedProperty$1, [Boolean]).create(ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [ss.Nullable])).call(null, this.$_updateInRealTimeSelection, function(updateInRealTimeSelection) {
			return ss.isValue(updateInRealTimeSelection.get_value()) && ss.Nullable.unbox(updateInRealTimeSelection.get_value());
		}, null);
		this.$_supportsAsync = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [Boolean]))(supportsAsync);
		this.$_simulateLatencyItems = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableCollection$1, [Boolean]).$ctor1)([true, false]);
		this.$_simulateLatencySelection = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [ss.Nullable]).$ctor1)(true);
		this.$_simulateLatency = ss.makeGenericType(MorseCode.CsJs.Common.Observable.CalculatedProperty$1, [Boolean]).create(ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [ss.Nullable])).call(null, this.$_simulateLatencySelection, function(simulateLatencySelection) {
			return ss.isValue(simulateLatencySelection.get_value()) && ss.Nullable.unbox(simulateLatencySelection.get_value());
		}, null);
		this.$_operators = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableCollection$1, [$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_Operator]).$ctor1)([0, 1, 2, 3]);
		this.$_operand1 = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [String]))();
		this.$_selectedOperator = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [ss.Nullable]))();
		this.$_selectedOperator.set_value$2(0);
		this.$_selectedOperatorString = ss.makeGenericType(MorseCode.CsJs.Common.Observable.CalculatedProperty$1, [String]).create(ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [ss.Nullable])).call(null, this.$_selectedOperator, function(selectedOperator) {
			if (ss.Nullable.eq(selectedOperator.get_value(), null)) {
				return null;
			}
			switch (ss.Nullable.unbox(selectedOperator.get_value())) {
				case 0: {
					return '+';
				}
				case 1: {
					return '-';
				}
				case 2: {
					return '*';
				}
				case 3: {
					return '/';
				}
				default: {
					throw new ss.NotSupportedException('Unknown enum value ' + ss.Nullable.unbox(selectedOperator.get_value()) + '.');
				}
			}
		}, null);
		this.$_operand2 = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [String]))();
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModelBase.prototype = {
		get_updateInRealTimeItems: function() {
			return this.$_updateInRealTimeItems;
		},
		get_updateInRealTimeSelection: function() {
			return this.$_updateInRealTimeSelection;
		},
		get_updateInRealTime: function() {
			return this.$_updateInRealTime;
		},
		get_simulateLatencyItems: function() {
			return this.$_simulateLatencyItems;
		},
		get_simulateLatencySelection: function() {
			return this.$_simulateLatencySelection;
		},
		get_simulateLatency: function() {
			return this.$_simulateLatency;
		},
		get_operators: function() {
			return this.$_operators;
		},
		get_operand1: function() {
			return this.$_operand1;
		},
		get_selectedOperator: function() {
			return this.$_selectedOperator;
		},
		get_selectedOperatorString: function() {
			return this.$_selectedOperatorString;
		},
		get_operand2: function() {
			return this.$_operand2;
		},
		get_supportsAsync: function() {
			return this.$_supportsAsync;
		},
		get_result: null
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.GridPageViewModel
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_GridPageViewModel = function(applicationViewModel) {
		this.$_applicationViewModel = null;
		this.$_navigationViewModel = null;
		this.$_items = null;
		this.$_applicationViewModel = applicationViewModel;
		this.$_navigationViewModel = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_NavigationViewModel(this.$_applicationViewModel);
		this.$_items = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableCollection$1, [$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem])]))(new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableCollection$1, [$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem]))());
		var items = [new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 2, 'second', 'sdkgsdgh', true), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 3, 'third', 'weuirueifsd', false), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 4, 'fourth', 'ioerhivfni', false), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 5, 'fifth', 'zdiofernwiasu', true), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 12, 'second', 'sdkgsdgh', true), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 13, 'third', 'weuirueifsd', false), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 14, 'fourth', 'ioerhivfni', false), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 15, 'fifth', 'zdiofernwiasu', true), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 22, 'second', 'sdkgsdgh', true), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 23, 'third', 'weuirueifsd', false), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 24, 'fourth', 'ioerhivfni', false), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 25, 'fifth', 'zdiofernwiasu', true), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 32, 'second', 'sdkgsdgh', true), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 33, 'third', 'weuirueifsd', false), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 34, 'fourth', 'ioerhivfni', false), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 35, 'fifth', 'zdiofernwiasu', true), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 42, 'second', 'sdkgsdgh', true), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 43, 'third', 'weuirueifsd', false), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 44, 'fourth', 'ioerhivfni', false), new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem(this.$_items.get_value(), 45, 'fifth', 'zdiofernwiasu', true)];
		this.$_items.get_value().addRange(items);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_GridPageViewModel.prototype = {
		get_navigationViewModel: function() {
			return this.$_navigationViewModel;
		},
		get_items: function() {
			return this.$_items;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_ICalculatorViewModel = function() {
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_ICalculatorViewModel.prototype = { get_updateInRealTimeItems: null, get_updateInRealTimeSelection: null, get_updateInRealTime: null, get_supportsAsync: null, get_simulateLatencyItems: null, get_simulateLatencySelection: null, get_simulateLatency: null, get_operators: null, get_operand1: null, get_selectedOperator: null, get_selectedOperatorString: null, get_operand2: null, get_result: null };
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.IWebServiceClientFactory
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_IWebServiceClientFactory = function() {
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_IWebServiceClientFactory.prototype = { createCalculatorClient: null };
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.NavigationViewModel
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_NavigationViewModel = function(applicationViewModel) {
		this.$_applicationViewModel = null;
		this.$_applicationViewModel = applicationViewModel;
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_NavigationViewModel.prototype = {
		switchPages: function() {
			var currentViewModelType = ss.getInstanceType(this.$_applicationViewModel.get_currentViewModel().get_value());
			if (ss.referenceEquals(currentViewModelType, $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorsAndStopwatchPageViewModel)) {
				this.$_applicationViewModel.navigateToCalculatorPage();
			}
			else if (ss.referenceEquals(currentViewModelType, $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorPageViewModel)) {
				this.$_applicationViewModel.navigateToStopwatchPage();
			}
			else if (ss.referenceEquals(currentViewModelType, $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchPageViewModel)) {
				this.$_applicationViewModel.navigateToGridPage();
			}
			else if (ss.referenceEquals(currentViewModelType, $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_GridPageViewModel)) {
				this.$_applicationViewModel.navigateToCalculatorsAndStopwatchPage();
			}
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.Operator
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_Operator = function() {
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_Operator.prototype = { Add: 0, Subtract: 1, Multiply: 2, Divide: 3 };
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.RemoteCalculatorViewModel
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_RemoteCalculatorViewModel = function() {
		this.$_result = null;
		this.$_resultToDisplay = null;
		$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModelBase.call(this, true);
		this.$_result = ss.makeGenericType(MorseCode.CsJs.Common.Observable.AsyncCalculatedProperty$1, [String]).create$2(ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [String]), ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [String]), ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [ss.Nullable])).call(null, this.get_operand1(), this.get_operand2(), this.get_selectedOperator(), ss.mkdel(this, function(operand1, operand2, selectedOperator, setValue) {
			if (ss.Nullable.eq(selectedOperator.get_value(), null)) {
				setValue(null);
			}
			else {
				//CustomObject c = new CustomObject();
				//c.Add = null;
				//c.Property1 = "asdfksdhkdfh";
				//c.Property2 = 29;
				//CustomObject c3 = new CustomObject();
				//c3.Property1 = null;
				//c3.Property2 = 8;
				//c3.Property5 = SomeEnum.Value1;
				//c.Property3.Add(c3);
				//CustomObject2 c2 = new CustomObject2();
				//c2.Property1 = "341231";
				//c2.Property2 = null;
				//c2.Property3 = SomeEnum.Value2;
				//c.Property4 = c2;
				//c.Property5 = SomeEnum.Value1;
				//CustomObject cc = new CustomObject();
				//cc.Property5 = SomeEnum.Value3;
				//CalculatorClient t = new CalculatorClient();
				//t.Url = "http://localhost/CsJsCalculatorsAndStopwatchExampleServices/CalculatorService.svc";
				//t.TestMethod(7.2, 3, false, "something value", c, new List<string> { "a", "b", "c" }, null, new List<int?> { 1, null, 3 }, new List<CustomObject> { c, cc }, o => FrameworkUtility.Debugger(), (request, textStatus, error) => FrameworkUtility.Debugger());
				var calculatorClient = $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_WebServiceClientFactory.get_instance().createCalculatorClient();
				var method;
				switch (ss.Nullable.unbox(selectedOperator.get_value())) {
					case 0: {
						method = ss.mkdel(calculatorClient, calculatorClient.add);
						break;
					}
					case 1: {
						method = ss.mkdel(calculatorClient, calculatorClient.subtract);
						break;
					}
					case 2: {
						method = ss.mkdel(calculatorClient, calculatorClient.multiply);
						break;
					}
					case 3: {
						method = ss.mkdel(calculatorClient, calculatorClient.divide);
						break;
					}
					default: {
						throw MorseCode.CsJs.Common.UnhandledEnumValueExceptionFactory.create($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_Operator).call(null, ss.Nullable.unbox(selectedOperator.get_value()));
					}
				}
				method(MorseCode.CsJs.Common.FrameworkUtility.doubleTryParse(operand1.get_value()), MorseCode.CsJs.Common.FrameworkUtility.doubleTryParse(operand2.get_value()), this.get_simulateLatency().get_value(), function(o) {
					setValue(MorseCode.CsJs.Common.FrameworkUtility.safeToString(o));
				}, function(request, textStatus, error) {
					setValue('Error: ' + error);
				});
			}
		}), null);
		this.$_resultToDisplay = ss.makeGenericType(MorseCode.CsJs.Common.Observable.CalculatedProperty$1, [String]).create$1(ss.makeGenericType(MorseCode.CsJs.Common.Observable.AsyncCalculatedProperty$1, [String]), ss.makeGenericType(MorseCode.CsJs.Common.Observable.IReadableObservableProperty$1, [Boolean])).call(null, this.$_result, this.$_result.get_isCalculating(), function(result, isCalculating) {
			return (isCalculating.get_value() ? 'Calculating...' : result.get_value());
		}, null);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_RemoteCalculatorViewModel.prototype = {
		get_result: function() {
			return this.$_resultToDisplay;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItem = function(id, name, something, boolean1) {
		this.$_id = null;
		this.$_name = null;
		this.$_something = null;
		this.$_boolean = null;
		this.$_id = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [ss.Int32]))(id);
		this.$_name = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [String]))(name);
		this.$_something = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [String]))(something);
		this.$_boolean = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [Boolean]))(boolean1);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItem.prototype = {
		get_id: function() {
			return this.$_id;
		},
		get_name: function() {
			return this.$_name;
		},
		get_something: function() {
			return this.$_something;
		},
		get_boolean: function() {
			return this.$_boolean;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItemCollectionItem
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem = function(collection, id, name, something, boolean1) {
		this.$_collection = null;
		$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItem.call(this, id, name, something, boolean1);
		this.$_collection = collection;
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem.prototype = {
		delete$1: function() {
			ss.remove(this.$_collection, this);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchPageViewModel
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchPageViewModel = function(applicationViewModel) {
		this.$_applicationViewModel = null;
		this.$_navigationViewModel = null;
		this.$_stopwatchViewModel = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchViewModel();
		this.$_applicationViewModel = applicationViewModel;
		this.$_navigationViewModel = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_NavigationViewModel(this.$_applicationViewModel);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchPageViewModel.prototype = {
		get_navigationViewModel: function() {
			return this.$_navigationViewModel;
		},
		get_stopwatchViewModel: function() {
			return this.$_stopwatchViewModel;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchViewModel = function() {
		this.$_viewModes = null;
		this.$_selectedViewMode = null;
		this.$_isActive = null;
		this.$_elapsed = null;
		this.$_elapsedString = null;
		this.$_isRunning = null;
		this.$_allowStop = null;
		this.$_allowStart = null;
		this.$_timer = null;
		this.$_start = new Date(0);
		this.$_previousTime = ss.TimeSpan.getDefaultValue();
		this.$_viewModes = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableCollection$1, [$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchViewModel$ViewMode]).$ctor1)([0, 1]);
		this.$_selectedViewMode = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [ss.Nullable]).$ctor1)(1);
		this.$_isActive = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [Boolean]).$ctor1)(true);
		this.$_isActive.add_changed(ss.mkdel(this, function(sender, args) {
			this.$updateTimerState();
		}));
		this.$_elapsed = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [ss.TimeSpan]))();
		this.$_elapsedString = ss.makeGenericType(MorseCode.CsJs.Common.Observable.CalculatedProperty$1, [String]).create$1(ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [ss.TimeSpan]), ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [ss.Nullable])).call(null, this.$_elapsed, this.$_selectedViewMode, function(elapsed, selectedViewMode) {
			return $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchViewModel.$getTimeSpanString(elapsed.get_value(), selectedViewMode.get_value());
		}, null);
		this.$_isRunning = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [Boolean]))();
		this.$_isRunning.add_changed(ss.mkdel(this, function(sender1, args1) {
			this.$updateTimerState();
		}));
		this.$_allowStop = ss.makeGenericType(MorseCode.CsJs.Common.Observable.CalculatedProperty$1, [Boolean]).create(ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [Boolean])).call(null, this.$_isRunning, function(isRunning) {
			return isRunning.get_value();
		}, null);
		this.$_allowStart = ss.makeGenericType(MorseCode.CsJs.Common.Observable.CalculatedProperty$1, [Boolean]).create(ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [Boolean])).call(null, this.$_isRunning, function(isRunning1) {
			return !isRunning1.get_value();
		}, null);
		this.$_timer = MorseCode.CsJs.Common.TimerFactory.get_instance().createTimer(ss.mkdel(this, this.$onTimerElapsed), 27, true);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchViewModel.prototype = {
		$onTimerElapsed: function() {
			if (this.$_isRunning.get_value() && this.$_isActive.get_value()) {
				this.$setElapsedTime();
			}
		},
		$updateTimerState: function() {
			if (this.$_isRunning.get_value() && this.$_isActive.get_value()) {
				this.$_timer.startSafe();
			}
			else {
				this.$_timer.stopSafe();
			}
		},
		$setElapsedTime: function() {
			this.$_elapsed.set_value$2(new ss.TimeSpan(this.$_previousTime.ticks + (new ss.TimeSpan((new Date() - this.$_start) * 10000)).ticks));
		},
		get_viewModes: function() {
			return this.$_viewModes;
		},
		get_selectedViewMode: function() {
			return this.$_selectedViewMode;
		},
		get_isActive: function() {
			return this.$_isActive;
		},
		get_elapsedString: function() {
			return this.$_elapsedString;
		},
		get_allowStop: function() {
			return this.$_allowStop;
		},
		get_allowStart: function() {
			return this.$_allowStart;
		},
		stop: function() {
			this.$_isRunning.set_value$2(false);
			this.$setElapsedTime();
			this.$_previousTime = this.$_elapsed.get_value();
		},
		start: function() {
			this.$_start = new Date();
			this.$setElapsedTime();
			this.$_isRunning.set_value$2(true);
		},
		reset: function() {
			this.$_start = new Date();
			this.$_previousTime = new ss.TimeSpan();
			this.$_elapsed.set_value$2(new ss.TimeSpan());
		}
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchViewModel.$getTimeSpanString = function(timeSpan, selectedViewMode) {
		var pad = function(o, n) {
			return ss.padLeftString(MorseCode.CsJs.Common.FrameworkUtility.safeToString(o), n, 48);
		};
		var pad2 = function(o1) {
			return pad(o1, 2);
		};
		var ticks = timeSpan.ticks;
		var result = '';
		if (Math.abs(ticks) >= 864000000000) {
			result += pad2(ss.Int32.div(ticks, 864000000000)) + '.';
			ticks %= 864000000000;
		}
		result += pad2(ss.Int32.div(ticks, 36000000000)) + ':';
		ticks %= 36000000000;
		result += pad2(ss.Int32.div(ticks, 600000000)) + ':';
		ticks %= 600000000;
		result += pad2(ss.Int32.div(ticks, 10000000));
		if (ss.Nullable.eq(selectedViewMode, 0)) {
			ticks %= 10000000;
			result += '.' + pad(ss.Int32.div(ticks, 10000), 3);
		}
		return result;
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel.ViewMode
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchViewModel$ViewMode = function() {
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchViewModel$ViewMode.prototype = { Milliseconds: 0, Seconds: 1 };
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.WebServiceClientFactory
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_WebServiceClientFactory = function() {
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_WebServiceClientFactory.get_instance = function() {
		if (ss.isNullOrUndefined($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_WebServiceClientFactory.$_instance)) {
			throw new System.InvalidOperationException.$ctor1(ss.getTypeName($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_WebServiceClientFactory) + '.Instance must be set when the application starts.');
		}
		return $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_WebServiceClientFactory.$_instance;
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_WebServiceClientFactory.set_instance = function(value) {
		$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_WebServiceClientFactory.$_instance = value;
	};
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorAndStopwatch.ViewModel.CalculatorServiceReference.CalculatorClient', $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CalculatorClient, MorseCode.CsJs.Net.SoapClient);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorAndStopwatch.ViewModel.CalculatorServiceReference.CustomObject', $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorAndStopwatch.ViewModel.CalculatorServiceReference.CustomObject2', $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_CustomObject2);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorAndStopwatch.ViewModel.CalculatorServiceReference.EnumConverters', $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_EnumConverters);
	ss.registerEnum(global, 'MorseCode.CsJs.Examples.CalculatorAndStopwatch.ViewModel.CalculatorServiceReference.SomeEnum', $MorseCode_CsJs_Examples_CalculatorAndStopwatch_ViewModel_CalculatorServiceReference_SomeEnum);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ApplicationErrorEventArgs', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_ApplicationErrorEventArgs, ss.EventArgs);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorPageViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorPageViewModel);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchApplicationViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorsAndStopwatchApplicationViewModel, MorseCode.CsJs.ViewModel.ApplicationViewModelBase);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorsAndStopwatchPageViewModel);
	ss.registerInterface(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_ICalculatorViewModel);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorViewModelBase', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModelBase, null, [$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_ICalculatorViewModel]);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModel, $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModelBase, [$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_ICalculatorViewModel]);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.GridPageViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_GridPageViewModel);
	ss.registerInterface(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.IWebServiceClientFactory', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_IWebServiceClientFactory);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.NavigationViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_NavigationViewModel);
	ss.registerEnum(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.Operator', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_Operator);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.RemoteCalculatorViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_RemoteCalculatorViewModel, $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModelBase, [$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_ICalculatorViewModel]);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItem);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItemCollectionItem', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItemCollectionItem, $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_SampleItem);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchPageViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchPageViewModel);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchViewModel);
	ss.registerEnum(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel$ViewMode', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchViewModel$ViewMode);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.WebServiceClientFactory', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_WebServiceClientFactory);
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_WebServiceClientFactory.$_instance = null;
})();
