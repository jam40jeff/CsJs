﻿(function() {
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorControl
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControl = function() {
		ss.makeGenericType($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControlBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorViewModel]).call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControl.prototype = {
		setupControls: function() {
			this.get__equals().set_text('=');
			this.get__largeResultPanel().get_styles().addOrSet('margin', '50px');
			this.get__largeResultPanel().get_styles().addOrSet('padding', '50px');
			this.get__largeResultLabel().get_styles().addOrSet('font-size', '96pt');
		},
		bindControls: function(dataContext) {
			var $t1 = this.get__function();
			$t1.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorViewModel, MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.Operator).call($t1, dataContext, function(d) {
				return d.get_operators();
			}, function(d1) {
				return d1.get_selectedOperator();
			}, function(o) {
				return MorseCode.CsJs.Common.FrameworkUtility.enumToString(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.Operator).call(null, o);
			}, function(o1) {
				return MorseCode.CsJs.Common.FrameworkUtility.enumToString(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.Operator).call(null, o1);
			});
			var $t2 = this.get__operand1();
			$t2.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorViewModel).call($t2, dataContext, function(d2) {
				return d2.get_operand1();
			}, true);
			var $t3 = this.get__operator();
			$t3.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorViewModel).call($t3, dataContext, function(d3) {
				return d3.get_selectedOperatorString();
			});
			var $t4 = this.get__operand2();
			$t4.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorViewModel).call($t4, dataContext, function(d4) {
				return d4.get_operand2();
			}, true);
			var $t5 = this.get__result();
			$t5.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorViewModel).call($t5, dataContext, function(d5) {
				return d5.get_result();
			});
			var $t6 = this.get__largeResultLabel();
			$t6.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorViewModel).call($t6, dataContext, function(d6) {
				return d6.get_result();
			});
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorControlBase
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControlBase$1 = function(T) {
		var $type = function() {
			ss.makeGenericType(MorseCode.CsJs.UI.Controls.MarkupControlBase$1, [T]).call(this);
		};
		$type.prototype = {
			get__function: function() {
				return this.findControl(MorseCode.CsJs.UI.Controls.DropDown).call(this, '_function');
			},
			get__operand1: function() {
				return this.findControl(MorseCode.CsJs.UI.Controls.TextBox).call(this, '_operand1');
			},
			get__operator: function() {
				return this.findControl(MorseCode.CsJs.UI.Controls.Label).call(this, '_operator');
			},
			get__operand2: function() {
				return this.findControl(MorseCode.CsJs.UI.Controls.TextBox).call(this, '_operand2');
			},
			get__equals: function() {
				return this.findControl(MorseCode.CsJs.UI.Controls.Label).call(this, '_equals');
			},
			get__result: function() {
				return this.findControl(MorseCode.CsJs.UI.Controls.Label).call(this, '_result');
			},
			get__largeResultPanel: function() {
				return this.findControl(MorseCode.CsJs.UI.Controls.Panel).call(this, '_largeResultPanel');
			},
			get__largeResultLabel: function() {
				return this.findControl(MorseCode.CsJs.UI.Controls.Label).call(this, '_largeResultLabel');
			},
			get_markup: function() {
				return '<declare type="CalculatorControl" />\r\n\r\n<control type="MorseCode.CsJs.UI.Controls.Panel" style="padding: 15px; background-color: rgb(128,128,128);">\r\n  <control type="MorseCode.CsJs.UI.Controls.DropDown" controlid="_function" />\r\n</control>\r\n<control type="MorseCode.CsJs.UI.Controls.Panel" style="padding: 15px; background-color: rgb(192,192,192);">\r\n  <control type="MorseCode.CsJs.UI.Controls.TextBox" controlid="_operand1" />\r\n  <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_operator" style="padding-left: 5px; padding-right: 5px;" />\r\n  <control type="MorseCode.CsJs.UI.Controls.TextBox" controlid="_operand2" />\r\n  <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_equals" style="padding-left: 5px;" />\r\n  <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_result" style="padding-left: 5px;" />\r\n</control>\r\n<control type="MorseCode.CsJs.UI.Controls.Panel" controlid="_largeResultPanel" style="border: 1px dashed gray;">\r\n  <table style="width: 100%;">\r\n    <tr>\r\n      <td style="height: 200px; vertical-align: middle; text-align: center;">\r\n        <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_largeResultLabel" style="font-family: Arial;" />\r\n      </td>\r\n    </tr>\r\n  </table>\r\n</control>';
			}
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControlBase$1, [T], function() {
			return ss.makeGenericType(MorseCode.CsJs.UI.Controls.MarkupControlBase$1, [T]);
		}, function() {
			return [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorControlBase$1', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControlBase$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorPage
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorPage = function() {
		this.$_navigationControl = null;
		this.$_calculatorControl = null;
		ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorPageViewModel]).call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorPage.prototype = {
		get_title: function() {
			return 'Calculator';
		},
		createChildControls: function() {
			this.$_navigationControl = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_NavigationControl();
			this.get_controls().add(this.$_navigationControl);
			this.$_calculatorControl = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControl();
			this.get_controls().add(this.$_calculatorControl);
		},
		bindControls: function(dataContext) {
			this.$_navigationControl.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorPageViewModel).call(this.$_navigationControl, dataContext, function(d) {
				return d.get_navigationViewModel();
			});
			this.$_calculatorControl.bind$1(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorPageViewModel).call(this.$_calculatorControl, dataContext, function(d1) {
				return d1.get_calculatorViewModel();
			});
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchApplication
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchApplication = function() {
		MorseCode.CsJs.UI.ApplicationBase.call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchApplication.prototype = {
		createApplicationViewModel: function() {
			return new MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchApplicationViewModel();
		},
		registerPages: function(pageRegistrationHelper) {
			var $t1 = pageRegistrationHelper.registerPage($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchPage).call(pageRegistrationHelper, function() {
				return new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchPage();
			});
			$t1.withBinding(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel).call($t1, function(p, d) {
				p.bind(d);
			});
			var $t2 = pageRegistrationHelper.registerPage($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorPage).call(pageRegistrationHelper, function() {
				return new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorPage();
			});
			$t2.withBinding(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorPageViewModel).call($t2, function(p1, d1) {
				p1.bind(d1);
			});
			var $t3 = pageRegistrationHelper.registerPage($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchPage).call(pageRegistrationHelper, function() {
				return new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchPage();
			});
			$t3.withBinding(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchPageViewModel).call($t3, function(p2, d2) {
				p2.bind(d2);
			});
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchPage
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchPage = function() {
		this.$_navigationControl = null;
		this.$_switchCalculators = null;
		this.$_calculatorLabel = null;
		this.$_calculatorControl = null;
		this.$_stopwatchControl = null;
		ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel]).call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchPage.prototype = {
		get_title: function() {
			return 'Calculators and Stopwatch';
		},
		createChildControls: function() {
			this.$_navigationControl = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_NavigationControl();
			this.get_controls().add(this.$_navigationControl);
			var div = new MorseCode.CsJs.UI.Controls.HtmlControl('div', ss.mkdel(this, function(controls) {
				this.$_switchCalculators = new MorseCode.CsJs.UI.Controls.Button();
				this.$_switchCalculators.set_text('Switch Calculators');
				controls.add(this.$_switchCalculators);
				this.$_calculatorLabel = new MorseCode.CsJs.UI.Controls.Label();
				this.$_calculatorLabel.get_styles().addOrSet('padding-left', '15px');
				controls.add(this.$_calculatorLabel);
			}));
			this.get_controls().add(div);
			this.$_calculatorControl = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControl();
			this.get_controls().add(this.$_calculatorControl);
			this.$_stopwatchControl = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControl();
			this.get_controls().add(this.$_stopwatchControl);
		},
		bindControls: function(dataContext) {
			this.$_navigationControl.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel).call(this.$_navigationControl, dataContext, function(d) {
				return d.get_navigationViewModel();
			});
			this.$_switchCalculators.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel).call(this.$_switchCalculators, dataContext, function(d1) {
				return ss.mkdel(d1, d1.switchCalculators);
			});
			this.$_calculatorLabel.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel).call(this.$_calculatorLabel, dataContext, function(d2) {
				return d2.get_calculatorText();
			});
			this.$_calculatorControl.bind$1(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel).call(this.$_calculatorControl, dataContext, function(d3) {
				return d3.get_calculatorViewModel();
			});
			this.$_stopwatchControl.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel).call(this.$_stopwatchControl, dataContext, function(d4) {
				return d4.get_stopwatchViewModel();
			});
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.NavigationControl
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_NavigationControl = function() {
		this.$_switchButton = null;
		ss.makeGenericType(MorseCode.CsJs.UI.Controls.PlaceHolderCompositeControlBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.NavigationViewModel]).call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_NavigationControl.prototype = {
		createChildControls: function() {
			this.$_switchButton = new MorseCode.CsJs.UI.Controls.Button();
			this.$_switchButton.set_text('Switch Pages');
			this.get_controls().add(new MorseCode.CsJs.UI.Controls.HtmlControl('div', ss.mkdel(this, function(controls) {
				controls.add(this.$_switchButton);
			})));
		},
		bindControls: function(dataContext) {
			this.$_switchButton.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.NavigationViewModel).call(this.$_switchButton, dataContext, function(d) {
				return ss.mkdel(d, d.switchPages);
			});
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchControl
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControl = function() {
		ss.makeGenericType($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControlBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel]).call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControl.prototype = {
		setupControls: function() {
		},
		bindControls: function(dataContext) {
			var $t1 = this.get__viewModeDropDown();
			$t1.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel, MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel$ViewMode).call($t1, dataContext, function(d) {
				return d.get_viewModes();
			}, function(d1) {
				return d1.get_selectedViewMode();
			}, function(o) {
				return MorseCode.CsJs.Common.FrameworkUtility.enumToString(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel$ViewMode).call(null, o);
			}, function(o1) {
				return MorseCode.CsJs.Common.FrameworkUtility.enumToString(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel$ViewMode).call(null, o1);
			});
			var $t2 = this.get__timeLabel();
			$t2.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel).call($t2, dataContext, function(d2) {
				return d2.get_elapsedString();
			});
			var $t3 = this.get__startButton();
			$t3.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel).call($t3, dataContext, function(d3) {
				return ss.mkdel(d3, d3.start);
			});
			var $t4 = this.get__startButton();
			$t4.bindVisible(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel).call($t4, dataContext, function(d4) {
				return d4.get_allowStart();
			});
			var $t5 = this.get__stopButton();
			$t5.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel).call($t5, dataContext, function(d5) {
				return ss.mkdel(d5, d5.stop);
			});
			var $t6 = this.get__stopButton();
			$t6.bindVisible(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel).call($t6, dataContext, function(d6) {
				return d6.get_allowStop();
			});
			var $t7 = this.get__resetButton();
			$t7.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel).call($t7, dataContext, function(d7) {
				return ss.mkdel(d7, d7.reset);
			});
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchControlBase
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControlBase$1 = function(T) {
		var $type = function() {
			ss.makeGenericType(MorseCode.CsJs.UI.Controls.MarkupControlBase$1, [T]).call(this);
		};
		$type.prototype = {
			get__viewModeDropDown: function() {
				return this.findControl(MorseCode.CsJs.UI.Controls.DropDown).call(this, '_viewModeDropDown');
			},
			get__timeLabel: function() {
				return this.findControl(MorseCode.CsJs.UI.Controls.Label).call(this, '_timeLabel');
			},
			get__startButton: function() {
				return this.findControl(MorseCode.CsJs.UI.Controls.Button).call(this, '_startButton');
			},
			get__stopButton: function() {
				return this.findControl(MorseCode.CsJs.UI.Controls.Button).call(this, '_stopButton');
			},
			get__resetButton: function() {
				return this.findControl(MorseCode.CsJs.UI.Controls.Button).call(this, '_resetButton');
			},
			get_markup: function() {
				return '<declare type="StopwatchControl" />\r\n\r\n<div style="background-color: black; padding: 100px;">\r\n  <div>\r\n    <control type="MorseCode.CsJs.UI.Controls.DropDown" controlid="_viewModeDropDown" />\r\n  </div>\r\n  <div>\r\n    <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_timeLabel" style="color: rgb(128,0,0); font-family: Arial; font-size: 128pt;" />\r\n  </div>\r\n  <div>\r\n    <control type="MorseCode.CsJs.UI.Controls.Button" controlid="_startButton" text="Start" style="padding-right: 5px;" />\r\n    <control type="MorseCode.CsJs.UI.Controls.Button" controlid="_stopButton" text="Stop" style="padding-right: 5px;" />\r\n    <control type="MorseCode.CsJs.UI.Controls.Button" controlid="_resetButton" text="Reset" />\r\n  </div>\r\n</div>';
			}
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControlBase$1, [T], function() {
			return ss.makeGenericType(MorseCode.CsJs.UI.Controls.MarkupControlBase$1, [T]);
		}, function() {
			return [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchControlBase$1', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControlBase$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchPage
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchPage = function() {
		this.$_navigationControl = null;
		this.$_stopwatchControl = null;
		ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchPageViewModel]).call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchPage.prototype = {
		get_title: function() {
			return 'Stopwatch';
		},
		createChildControls: function() {
			this.$_navigationControl = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_NavigationControl();
			this.get_controls().add(this.$_navigationControl);
			this.$_stopwatchControl = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControl();
			this.get_controls().add(this.$_stopwatchControl);
		},
		bindControls: function(dataContext) {
			this.$_navigationControl.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchPageViewModel).call(this.$_navigationControl, dataContext, function(d) {
				return d.get_navigationViewModel();
			});
			this.$_stopwatchControl.bind(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchPageViewModel).call(this.$_stopwatchControl, dataContext, function(d1) {
				return d1.get_stopwatchViewModel();
			});
		}
	};
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorControl', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControl, ss.makeGenericType($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControlBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl]);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorPage', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorPage, ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorPageViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl, MorseCode.CsJs.UI.Controls.IPage]);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchApplication', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchApplication, MorseCode.CsJs.UI.ApplicationBase);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchPage', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchPage, ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl, MorseCode.CsJs.UI.Controls.IPage]);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.NavigationControl', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_NavigationControl, ss.makeGenericType(MorseCode.CsJs.UI.Controls.PlaceHolderCompositeControlBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.NavigationViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl]);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchControl', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControl, ss.makeGenericType($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControlBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl]);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchPage', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchPage, ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchPageViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl, MorseCode.CsJs.UI.Controls.IPage]);
})();
