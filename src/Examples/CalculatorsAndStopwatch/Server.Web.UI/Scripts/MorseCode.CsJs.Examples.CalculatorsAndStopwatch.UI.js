(function() {
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorControl
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControl = function() {
		ss.makeGenericType($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControlBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel]).call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControl.prototype = {
		setupControls: function() {
			this.get__equals().set_text('=');
			this.get__largeResultPanel().get_styles().addOrSet('margin', '50px');
			this.get__largeResultPanel().get_styles().addOrSet('padding', '50px');
			this.get__largeResultLabel().get_styles().addOrSet('font-size', '72pt');
		},
		bindControls: function(dataContext) {
			var $t1 = this.get__updateInRealTime();
			$t1.bindItemsAndSelection(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel, Boolean).call($t1, dataContext, function(d) {
				return d.get_updateInRealTimeItems();
			}, function(d1) {
				return d1.get_updateInRealTimeSelection();
			}, function(o) {
				return (o ? 'Yes' : 'No');
			}, function(o1) {
				return (o1 ? 'Yes' : 'No');
			});
			var $t2 = this.get__simulateLatencyPanel();
			$t2.bindVisible(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel).call($t2, dataContext, function(d2) {
				return d2.get_supportsAsync();
			});
			this.get__simulateLatencyPanel().set_useSlideVisibilityTransition(true);
			var $t3 = this.get__simulateLatency();
			$t3.bindItemsAndSelection(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel, Boolean).call($t3, dataContext, function(d3) {
				return d3.get_simulateLatencyItems();
			}, function(d4) {
				return d4.get_simulateLatencySelection();
			}, function(o2) {
				return (o2 ? 'Yes' : 'No');
			}, function(o3) {
				return (o3 ? 'Yes' : 'No');
			});
			var $t4 = this.get__function();
			$t4.bindItemsAndSelection(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel, MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.Operator).call($t4, dataContext, function(d5) {
				return d5.get_operators();
			}, function(d6) {
				return d6.get_selectedOperator();
			}, function(o4) {
				return MorseCode.CsJs.Common.FrameworkUtility.enumToString(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.Operator).call(null, o4);
			}, function(o5) {
				return MorseCode.CsJs.Common.FrameworkUtility.enumToString(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.Operator).call(null, o5);
			});
			var $t5 = this.get__operand1();
			$t5.bindUpdateTextBindingWhileChanging(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel).call($t5, dataContext, function(d7) {
				return d7.get_updateInRealTime();
			});
			var $t6 = this.get__operand1();
			$t6.bindText$1(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel).call($t6, dataContext, function(d8) {
				return d8.get_operand1();
			}, true);
			var $t7 = this.get__operator();
			$t7.bindText(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel).call($t7, dataContext, function(d9) {
				return d9.get_selectedOperatorString();
			});
			var $t8 = this.get__operand2();
			$t8.bindUpdateTextBindingWhileChanging(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel).call($t8, dataContext, function(d10) {
				return d10.get_updateInRealTime();
			});
			var $t9 = this.get__operand2();
			$t9.bindText$1(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel).call($t9, dataContext, function(d11) {
				return d11.get_operand2();
			}, true);
			var $t10 = this.get__result();
			$t10.bindText(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel).call($t10, dataContext, function(d12) {
				return d12.get_result();
			});
			var $t11 = this.get__largeResultLabel();
			$t11.bindText(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel).call($t11, dataContext, function(d13) {
				return d13.get_result();
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
			get__updateInRealTime: function() {
				return this.findControl(MorseCode.CsJs.UI.Controls.DropDown).call(this, '_updateInRealTime');
			},
			get__simulateLatencyPanel: function() {
				return this.findControl(MorseCode.CsJs.UI.Controls.Panel).call(this, '_simulateLatencyPanel');
			},
			get__simulateLatency: function() {
				return this.findControl(MorseCode.CsJs.UI.Controls.DropDown).call(this, '_simulateLatency');
			},
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
				return '<declare type="CalculatorControl" />\r\n\r\n<control type="MorseCode.CsJs.UI.Controls.Panel" style="padding: 15px; background-color: rgb(255,255,192);">\r\n  <control type="MorseCode.CsJs.UI.Controls.Label" text="Update In Real-Time: " />\r\n  <control type="MorseCode.CsJs.UI.Controls.DropDown" controlid="_updateInRealTime" style="color: red;" />\r\n</control>\r\n<control type="MorseCode.CsJs.UI.Controls.Panel" controlid="_simulateLatencyPanel" style="padding: 15px; background-color: rgb(192,192,255);">\r\n  <control type="MorseCode.CsJs.UI.Controls.Label" text="Simulate Latency: " />\r\n  <control type="MorseCode.CsJs.UI.Controls.DropDown" controlid="_simulateLatency" />\r\n</control>\r\n<control type="MorseCode.CsJs.UI.Controls.Panel" style="padding: 15px; background-color: rgb(128,128,128);">\r\n  <control type="MorseCode.CsJs.UI.Controls.DropDown" controlid="_function" skincategory="Lighter" />\r\n</control>\r\n<control type="MorseCode.CsJs.UI.Controls.Panel" style="padding: 15px; background-color: rgb(192,192,192);">\r\n  <control type="MorseCode.CsJs.UI.Controls.TextBox" controlid="_operand1" />\r\n  <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_operator" style="padding-left: 5px; padding-right: 5px;" />\r\n  <control type="MorseCode.CsJs.UI.Controls.TextBox" controlid="_operand2" />\r\n  <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_equals" style="padding-left: 5px;" />\r\n  <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_result" style="padding-left: 5px;" />\r\n</control>\r\n<control type="MorseCode.CsJs.UI.Controls.Panel" controlid="_largeResultPanel" style="border: 1px dashed gray;">\r\n  <table style="width: 100%;">\r\n    <tr>\r\n      <td style="height: 150px; vertical-align: middle; text-align: center;">\r\n        <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_largeResultLabel" style="font-family: Arial;" />\r\n      </td>\r\n    </tr>\r\n  </table>\r\n</control>';
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
			this.$_navigationControl.bindDataContext(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorPageViewModel).call(this.$_navigationControl, dataContext, function(d) {
				return d.get_navigationViewModel();
			});
			this.$_calculatorControl.bindDataContext$1(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorPageViewModel).call(this.$_calculatorControl, dataContext, function(d1) {
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
		onBeforeInitialize: function() {
			MorseCode.CsJs.UI.ApplicationBase.prototype.onBeforeInitialize.call(this);
			MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.WebServiceClientFactory.set_instance(new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchWebServiceClientFactory());
			this.set_skin(new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchSkin());
		},
		registerPages: function(pageRegistrationHelper) {
			var $t1 = pageRegistrationHelper.registerPage($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchPage).call(pageRegistrationHelper, function() {
				return new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchPage();
			});
			$t1.withBinding(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel).call($t1, function(p, d) {
				p.bindDataContext(d);
			});
			var $t2 = pageRegistrationHelper.registerPage($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorPage).call(pageRegistrationHelper, function() {
				return new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorPage();
			});
			$t2.withBinding(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorPageViewModel).call($t2, function(p1, d1) {
				p1.bindDataContext(d1);
			});
			var $t3 = pageRegistrationHelper.registerPage($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchPage).call(pageRegistrationHelper, function() {
				return new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchPage();
			});
			$t3.withBinding(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchPageViewModel).call($t3, function(p2, d2) {
				p2.bindDataContext(d2);
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
			this.$_navigationControl.bindDataContext(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel).call(this.$_navigationControl, dataContext, function(d) {
				return d.get_navigationViewModel();
			});
			this.$_switchCalculators.bindClickAction(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel).call(this.$_switchCalculators, dataContext, function(d1) {
				return ss.mkdel(d1, d1.switchCalculators);
			});
			this.$_calculatorLabel.bindText(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel).call(this.$_calculatorLabel, dataContext, function(d2) {
				return d2.get_calculatorText();
			});
			this.$_calculatorControl.bindDataContext$1(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel).call(this.$_calculatorControl, dataContext, function(d3) {
				return d3.get_calculatorViewModel();
			});
			this.$_stopwatchControl.bindDataContext(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel).call(this.$_stopwatchControl, dataContext, function(d4) {
				return d4.get_stopwatchViewModel();
			});
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchSkin
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchSkin = function() {
		MorseCode.CsJs.UI.SkinBase.call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchSkin.prototype = {
		addSkinActions: function(addSkinAction) {
			addSkinAction(this.createSkinAction$1(MorseCode.CsJs.UI.Controls.DropDown).call(this, function(control, skinCategory) {
				control.get_styles().addOrSet('color', ((skinCategory === 'Lighter') ? 'gray' : 'blue'));
			}));
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchWebServiceClientFactory
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchWebServiceClientFactory = function() {
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchWebServiceClientFactory.prototype = {
		createCalculatorClient: function() {
			var calculatorClient = new MorseCode.CsJs.Examples.CalculatorAndStopwatch.ViewModel.CalculatorServiceReference.CalculatorClient();
			calculatorClient.set_url(MorseCode.CsJs.UI.VirtualPathUtility.toAbsolute('~/Services/CalculatorService.svc'));
			return calculatorClient;
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
			this.$_switchButton.bindClickAction(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.NavigationViewModel).call(this.$_switchButton, dataContext, function(d) {
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
			$t1.bindItemsAndSelection(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel, MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel$ViewMode).call($t1, dataContext, function(d) {
				return d.get_viewModes();
			}, function(d1) {
				return d1.get_selectedViewMode();
			}, function(o) {
				return MorseCode.CsJs.Common.FrameworkUtility.enumToString(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel$ViewMode).call(null, o);
			}, function(o1) {
				return MorseCode.CsJs.Common.FrameworkUtility.enumToString(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel$ViewMode).call(null, o1);
			});
			var $t2 = this.get__timeLabel();
			$t2.bindText(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel).call($t2, dataContext, function(d2) {
				return d2.get_elapsedString();
			});
			var $t3 = this.get__startButton();
			$t3.bindClickAction(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel).call($t3, dataContext, function(d3) {
				return ss.mkdel(d3, d3.start);
			});
			var $t4 = this.get__startButton();
			$t4.bindVisible(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel).call($t4, dataContext, function(d4) {
				return d4.get_allowStart();
			});
			var $t5 = this.get__stopButton();
			$t5.bindClickAction(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel).call($t5, dataContext, function(d5) {
				return ss.mkdel(d5, d5.stop);
			});
			var $t6 = this.get__stopButton();
			$t6.bindVisible(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel).call($t6, dataContext, function(d6) {
				return d6.get_allowStop();
			});
			var $t7 = this.get__resetButton();
			$t7.bindClickAction(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel).call($t7, dataContext, function(d7) {
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
				return '<declare type="StopwatchControl" />\r\n\r\n<div style="background-color: black; padding: 75px;">\r\n  <div>\r\n    <control type="MorseCode.CsJs.UI.Controls.DropDown" controlid="_viewModeDropDown" />\r\n  </div>\r\n  <div>\r\n    <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_timeLabel" style="color: rgb(128,0,0); font-family: Arial; font-size: 96pt;" />\r\n  </div>\r\n  <div>\r\n    <control type="MorseCode.CsJs.UI.Controls.Button" controlid="_startButton" text="Start" style="padding-right: 5px;" />\r\n    <control type="MorseCode.CsJs.UI.Controls.Button" controlid="_stopButton" text="Stop" style="padding-right: 5px;" />\r\n    <control type="MorseCode.CsJs.UI.Controls.Button" controlid="_resetButton" text="Reset" />\r\n  </div>\r\n</div>';
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
			this.$_navigationControl.bindDataContext(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchPageViewModel).call(this.$_navigationControl, dataContext, function(d) {
				return d.get_navigationViewModel();
			});
			this.$_stopwatchControl.bindDataContext(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchPageViewModel).call(this.$_stopwatchControl, dataContext, function(d1) {
				return d1.get_stopwatchViewModel();
			});
		}
	};
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorControl', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControl, ss.makeGenericType($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControlBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl]);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorPage', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorPage, ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorPageViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl, MorseCode.CsJs.UI.Controls.IPage]);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchApplication', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchApplication, MorseCode.CsJs.UI.ApplicationBase, [MorseCode.CsJs.UI.IApplication]);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchPage', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchPage, ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl, MorseCode.CsJs.UI.Controls.IPage]);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchSkin', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchSkin, MorseCode.CsJs.UI.SkinBase, [MorseCode.CsJs.UI.ISkin]);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchWebServiceClientFactory', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchWebServiceClientFactory, null, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.IWebServiceClientFactory]);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.NavigationControl', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_NavigationControl, ss.makeGenericType(MorseCode.CsJs.UI.Controls.PlaceHolderCompositeControlBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.NavigationViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl]);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchControl', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControl, ss.makeGenericType($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControlBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl]);
	ss.registerClass(global, 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchPage', $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchPage, ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchPageViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl, MorseCode.CsJs.UI.Controls.IPage]);
})();
