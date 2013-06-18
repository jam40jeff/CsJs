(function() {
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
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorsAndStopwatchPageViewModel = function(applicationViewModel) {
		this.$_applicationViewModel = null;
		this.$_navigationViewModel = null;
		this.$_calculatorViewModel1 = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModel();
		this.$_calculatorViewModel2 = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModel();
		this.$_stopwatchViewModel = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchViewModel();
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
		this.$_updateInRealTimeItems = null;
		this.$_updateInRealTimeSelection = null;
		this.$_updateInRealTime = null;
		this.$_operators = null;
		this.$_operand1 = null;
		this.$_selectedOperator = null;
		this.$_selectedOperatorString = null;
		this.$_operand2 = null;
		this.$_result = null;
		this.$_updateInRealTimeItems = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableCollection$1, [Boolean]).$ctor1)([true, false]);
		this.$_updateInRealTimeSelection = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [ss.Nullable]).$ctor1)(true);
		this.$_updateInRealTime = ss.makeGenericType(MorseCode.CsJs.Common.Observable.CalculatedProperty$1, [Boolean]).create(ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [ss.Nullable])).call(null, this.$_updateInRealTimeSelection, function(updateInRealTimeSelection) {
			return ss.isValue(updateInRealTimeSelection.get_value()) && ss.Nullable.unbox(updateInRealTimeSelection.get_value());
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
		this.$_result = ss.makeGenericType(MorseCode.CsJs.Common.Observable.CalculatedProperty$1, [String]).create$2(ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [String]), ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [String]), ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [ss.Nullable])).call(null, this.$_operand1, this.$_operand2, this.$_selectedOperator, function(operand1, operand2, selectedOperator1) {
			if (ss.Nullable.eq(selectedOperator1.get_value(), null)) {
				return null;
			}
			var function1;
			switch (ss.Nullable.unbox(selectedOperator1.get_value())) {
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
					throw new ss.NotSupportedException('Unknown enum value ' + ss.Nullable.unbox(selectedOperator1.get_value()) + '.');
				}
			}
			return MorseCode.CsJs.Common.FrameworkUtility.safeToString(function1(MorseCode.CsJs.Common.FrameworkUtility.doubleTryParse(operand1.get_value()), MorseCode.CsJs.Common.FrameworkUtility.doubleTryParse(operand2.get_value())));
		}, null);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModel.prototype = {
		get_updateInRealTimeItems: function() {
			return this.$_updateInRealTimeItems;
		},
		get_updateInRealTimeSelection: function() {
			return this.$_updateInRealTimeSelection;
		},
		get_updateInRealTime: function() {
			return this.$_updateInRealTime;
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
		get_result: function() {
			return this.$_result;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.NavigationViewModel
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_NavigationViewModel = function(applicationViewModel) {
		this.$_applicationViewModel = null;
		this.$_applicationViewModel = applicationViewModel;
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_NavigationViewModel.prototype = {
		switchPages: function() {
			this.$_applicationViewModel.navigateToStopwatchPage();
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.Operator
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_Operator = function() {
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_Operator.prototype = { Add: 0, Subtract: 1, Multiply: 2, Divide: 3 };
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
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ApplicationErrorEventArgs', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_ApplicationErrorEventArgs, ss.EventArgs);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorPageViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorPageViewModel);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchApplicationViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorsAndStopwatchApplicationViewModel, MorseCode.CsJs.ViewModel.ApplicationViewModelBase);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorsAndStopwatchPageViewModel);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_CalculatorViewModel);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.NavigationViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_NavigationViewModel);
	ss.registerEnum(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.Operator', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_Operator);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchPageViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchPageViewModel);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchViewModel);
	ss.registerEnum(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel$ViewMode', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_ViewModel_StopwatchViewModel$ViewMode);
})();
