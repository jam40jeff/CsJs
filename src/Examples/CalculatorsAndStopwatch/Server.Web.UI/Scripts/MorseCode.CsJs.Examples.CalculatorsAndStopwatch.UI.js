(function() {
	'use strict';
	global.MorseCode = global.MorseCode || {};
	global.MorseCode.CsJs = global.MorseCode.CsJs || {};
	global.MorseCode.CsJs.Examples = global.MorseCode.CsJs.Examples || {};
	global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch = global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch || {};
	global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI = global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI || {};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.GridPage.SampleGridColumn
	var $MorseCode_$CsJs_Examples_CalculatorsAndStopwatch_UI_GridPage$SampleGridColumn = function(uniqueName) {
		ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridColumnBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem]).call(this, uniqueName);
	};
	$MorseCode_$CsJs_Examples_CalculatorsAndStopwatch_UI_GridPage$SampleGridColumn.__typeName = 'MorseCode.$CsJs.Examples.CalculatorsAndStopwatch.UI.GridPage$SampleGridColumn';
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.QueryableGridPage.SampleGridColumn
	var $MorseCode_$CsJs_Examples_CalculatorsAndStopwatch_UI_QueryableGridPage$SampleGridColumn = function(uniqueName) {
		ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridColumnBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem]).call(this, uniqueName);
	};
	$MorseCode_$CsJs_Examples_CalculatorsAndStopwatch_UI_QueryableGridPage$SampleGridColumn.__typeName = 'MorseCode.$CsJs.Examples.CalculatorsAndStopwatch.UI.QueryableGridPage$SampleGridColumn';
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorControl
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControl = function() {
		ss.makeGenericType($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControlBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel]).call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControl.__typeName = 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorControl';
	global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorControl = $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControl;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorControlBase
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControlBase$1 = function(T) {
		var $type = function() {
			ss.makeGenericType(MorseCode.CsJs.UI.Controls.MarkupControlBase$1, [T]).call(this);
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControlBase$1, [T], {
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
				return '<control classname="MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorControl">\r\n  <control type="MorseCode.CsJs.UI.Controls.Panel" style="padding: 15px; background-color: rgb(255,255,192);">\r\n    <control type="MorseCode.CsJs.UI.Controls.Label" text="Update In Real-Time: " />\r\n    <control type="MorseCode.CsJs.UI.Controls.DropDown" controlid="_updateInRealTime" style="color: red;" />\r\n  </control>\r\n  <control type="MorseCode.CsJs.UI.Controls.Panel" controlid="_simulateLatencyPanel" style="padding: 15px; background-color: rgb(192,192,255);">\r\n    <control type="MorseCode.CsJs.UI.Controls.Label" text="Simulate Latency: " />\r\n    <control type="MorseCode.CsJs.UI.Controls.DropDown" controlid="_simulateLatency" />\r\n  </control>\r\n  <control type="MorseCode.CsJs.UI.Controls.Panel" style="padding: 15px; background-color: rgb(128,128,128);">\r\n    <control type="MorseCode.CsJs.UI.Controls.DropDown" controlid="_function" skincategory="Lighter" />\r\n  </control>\r\n  <control type="MorseCode.CsJs.UI.Controls.Panel" style="padding: 15px; background-color: rgb(192,192,192);">\r\n    <control type="MorseCode.CsJs.UI.Controls.TextBox" controlid="_operand1" />\r\n    <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_operator" style="padding-left: 5px; padding-right: 5px;" />\r\n    <control type="MorseCode.CsJs.UI.Controls.TextBox" controlid="_operand2" />\r\n    <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_equals" style="padding-left: 5px;" />\r\n    <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_result" style="padding-left: 5px;" />\r\n  </control>\r\n  <control type="MorseCode.CsJs.UI.Controls.Panel" controlid="_largeResultPanel" style="border: 1px dashed gray;">\r\n    <table style="width: 100%;">\r\n      <tr>\r\n        <td style="height: 150px; vertical-align: middle; text-align: center;">\r\n          <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_largeResultLabel" style="font-family: Arial;" />\r\n        </td>\r\n      </tr>\r\n    </table>\r\n  </control>\r\n</control>';
			}
		}, function() {
			return ss.makeGenericType(MorseCode.CsJs.UI.Controls.MarkupControlBase$1, [T]);
		}, function() {
			return [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl];
		});
		return $type;
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControlBase$1.__typeName = 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorControlBase$1';
	ss.initGenericClass($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControlBase$1, 1);
	global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorControlBase$1 = $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControlBase$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorPage
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorPage = function() {
		this.$_navigationControl = null;
		this.$_calculatorControl = null;
		ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorPageViewModel]).call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorPage.__typeName = 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorPage';
	global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorPage = $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorPage;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchApplication
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchApplication = function() {
		MorseCode.CsJs.UI.ApplicationBase.call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchApplication.__typeName = 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchApplication';
	global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchApplication = $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchApplication;
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
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchPage.__typeName = 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchPage';
	global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchPage = $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchPage;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchSkin
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchSkin = function() {
		MorseCode.CsJs.UI.SkinBase.call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchSkin.__typeName = 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchSkin';
	global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchSkin = $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchSkin;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchWebServiceClientFactory
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchWebServiceClientFactory = function() {
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchWebServiceClientFactory.__typeName = 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchWebServiceClientFactory';
	global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorsAndStopwatchWebServiceClientFactory = $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchWebServiceClientFactory;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.GridPage
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_GridPage = function() {
		this.$_navigationControl = null;
		this.$_grid = null;
		ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.GridPageViewModel]).call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_GridPage.__typeName = 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.GridPage';
	global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.GridPage = $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_GridPage;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.NavigationControl
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_NavigationControl = function() {
		this.$_switchButton = null;
		ss.makeGenericType(MorseCode.CsJs.UI.Controls.PlaceHolderCompositeControlBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.NavigationViewModel]).call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_NavigationControl.__typeName = 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.NavigationControl';
	global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.NavigationControl = $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_NavigationControl;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.QueryableGridPage
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_QueryableGridPage = function() {
		this.$_navigationControl = null;
		this.$_grid = null;
		ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.QueryableGridPageViewModel]).call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_QueryableGridPage.__typeName = 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.QueryableGridPage';
	global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.QueryableGridPage = $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_QueryableGridPage;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchControl
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControl = function() {
		ss.makeGenericType($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControlBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel]).call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControl.__typeName = 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchControl';
	global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchControl = $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControl;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchControlBase
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControlBase$1 = function(T) {
		var $type = function() {
			ss.makeGenericType(MorseCode.CsJs.UI.Controls.MarkupControlBase$1, [T]).call(this);
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControlBase$1, [T], {
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
				return '<control classname="MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchControl">\r\n  <div style="background-color: black; padding: 75px;">\r\n    <div>\r\n      <control type="MorseCode.CsJs.UI.Controls.DropDown" controlid="_viewModeDropDown" />\r\n    </div>\r\n    <div>\r\n      <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_timeLabel" style="color: rgb(128,0,0); font-family: Arial; font-size: 96pt;" />\r\n    </div>\r\n    <div>\r\n      <control type="MorseCode.CsJs.UI.Controls.Button" controlid="_startButton" text="Start" style="padding-right: 5px;" />\r\n      <control type="MorseCode.CsJs.UI.Controls.Button" controlid="_stopButton" text="Stop" style="padding-right: 5px;" />\r\n      <control type="MorseCode.CsJs.UI.Controls.Button" controlid="_resetButton" text="Reset" />\r\n    </div>\r\n  </div>\r\n</control>';
			}
		}, function() {
			return ss.makeGenericType(MorseCode.CsJs.UI.Controls.MarkupControlBase$1, [T]);
		}, function() {
			return [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl];
		});
		return $type;
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControlBase$1.__typeName = 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchControlBase$1';
	ss.initGenericClass($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControlBase$1, 1);
	global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchControlBase$1 = $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControlBase$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchPage
	var $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchPage = function() {
		this.$_navigationControl = null;
		this.$_stopwatchControl = null;
		ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchPageViewModel]).call(this);
	};
	$MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchPage.__typeName = 'MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchPage';
	global.MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.StopwatchPage = $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchPage;
	ss.initClass($MorseCode_$CsJs_Examples_CalculatorsAndStopwatch_UI_GridPage$SampleGridColumn, {
		createControl: function(rowIndex, item) {
			var panel = new MorseCode.CsJs.UI.Controls.Panel(function(c) {
				var topPanel = new MorseCode.CsJs.UI.Controls.Panel(function(controls) {
					var label = new MorseCode.CsJs.UI.Controls.Label();
					label.bindText$1(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, ss.Int32).call(label, item, function(d) {
						return d.get_id();
					}, function(v) {
						return 'Line one shows the ID: ' + v;
					});
					controls.add(label);
				});
				c.add(topPanel);
				var bottomPanel = new MorseCode.CsJs.UI.Controls.Panel(function(controls1) {
					var label1 = new MorseCode.CsJs.UI.Controls.Label();
					label1.bindText$1(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, String).call(label1, item, function(d1) {
						return d1.get_name();
					}, function(v1) {
						return 'Line two shows the name: ' + v1;
					});
					controls1.add(label1);
				});
				c.add(bottomPanel);
			});
			return panel;
		}
	}, ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridColumnBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem]), [MorseCode.CsJs.UI.Controls.Grid.IGridColumn, ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.IGridColumn$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem])]);
	ss.initClass($MorseCode_$CsJs_Examples_CalculatorsAndStopwatch_UI_QueryableGridPage$SampleGridColumn, {
		createControl: function(rowIndex, item) {
			var panel = new MorseCode.CsJs.UI.Controls.Panel(function(c) {
				var topPanel = new MorseCode.CsJs.UI.Controls.Panel(function(controls) {
					var label = new MorseCode.CsJs.UI.Controls.Label();
					label.bindText$1(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, ss.Int32).call(label, item, function(d) {
						return d.get_id();
					}, function(v) {
						return 'Line one shows the ID: ' + v;
					});
					controls.add(label);
				});
				c.add(topPanel);
				var bottomPanel = new MorseCode.CsJs.UI.Controls.Panel(function(controls1) {
					var label1 = new MorseCode.CsJs.UI.Controls.Label();
					label1.bindText$1(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, String).call(label1, item, function(d1) {
						return d1.get_name();
					}, function(v1) {
						return 'Line two shows the name: ' + v1;
					});
					controls1.add(label1);
				});
				c.add(bottomPanel);
			});
			return panel;
		}
	}, ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridColumnBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem]), [MorseCode.CsJs.UI.Controls.Grid.IGridColumn, ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.IGridColumn$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem])]);
	ss.initClass($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControl, {
		setupControls: function() {
			this.get__equals().setText('=');
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
	}, ss.makeGenericType($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControlBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.ICalculatorViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl]);
	ss.initClass($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorPage, {
		get_title: function() {
			return 'Calculator';
		},
		createChildControls: function(controls) {
			this.$_navigationControl = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_NavigationControl();
			controls.add(this.$_navigationControl);
			this.$_calculatorControl = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControl();
			controls.add(this.$_calculatorControl);
		},
		bindControls: function(dataContext) {
			this.$_navigationControl.bindDataContext(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorPageViewModel).call(this.$_navigationControl, dataContext, function(d) {
				return d.get_navigationViewModel();
			});
			this.$_calculatorControl.bindDataContext$1(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorPageViewModel).call(this.$_calculatorControl, dataContext, function(d1) {
				return d1.get_calculatorViewModel();
			});
		}
	}, ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorPageViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl, MorseCode.CsJs.UI.Controls.IPage]);
	ss.initClass($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchApplication, {
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
			var $t4 = pageRegistrationHelper.registerPage($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_GridPage).call(pageRegistrationHelper, function() {
				return new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_GridPage();
			});
			$t4.withBinding(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.GridPageViewModel).call($t4, function(p3, d3) {
				p3.bindDataContext(d3);
			});
			var $t5 = pageRegistrationHelper.registerPage($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_QueryableGridPage).call(pageRegistrationHelper, function() {
				return new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_QueryableGridPage();
			});
			$t5.withBinding(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.QueryableGridPageViewModel).call($t5, function(p4, d4) {
				p4.bindDataContext(d4);
			});
		}
	}, MorseCode.CsJs.UI.ApplicationBase, [MorseCode.CsJs.UI.IApplication]);
	ss.initClass($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchPage, {
		get_title: function() {
			return 'Calculators and Stopwatch';
		},
		createChildControls: function(controls) {
			this.$_navigationControl = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_NavigationControl();
			controls.add(this.$_navigationControl);
			var div = new MorseCode.CsJs.UI.Controls.HtmlControl('div', ss.mkdel(this, function(c) {
				this.$_switchCalculators = new MorseCode.CsJs.UI.Controls.Button();
				this.$_switchCalculators.setText('Switch Calculators');
				c.add(this.$_switchCalculators);
				this.$_calculatorLabel = new MorseCode.CsJs.UI.Controls.Label();
				this.$_calculatorLabel.get_styles().addOrSet('padding-left', '15px');
				c.add(this.$_calculatorLabel);
			}));
			controls.add(div);
			this.$_calculatorControl = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorControl();
			controls.add(this.$_calculatorControl);
			this.$_stopwatchControl = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControl();
			controls.add(this.$_stopwatchControl);
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
	}, ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.CalculatorsAndStopwatchPageViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl, MorseCode.CsJs.UI.Controls.IPage]);
	ss.initClass($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchSkin, {
		addSkinActions: function(addSkinAction) {
			//NOTE: normally the following line would be used when the skin is contained within one class, however this example is testing the ability to override control skin actions by providing
			//separate skin actions below
			//addSkinAction(CreateSkinAction<DropDown>(control => control.Styles.AddOrSet("color", control.SkinCategory == "Lighter" ? "gray" : "blue")));
			addSkinAction(this.createSkinAction(MorseCode.CsJs.UI.Controls.DropDown).call(this, function(control) {
				control.get_styles().addOrSet('color', 'yellow');
			}));
			addSkinAction(this.createSkinAction(MorseCode.CsJs.UI.Controls.DropDown).call(this, function(control1) {
				control1.get_styles().addOrSet('color', 'blue');
			}));
			addSkinAction(this.createSkinAction(MorseCode.CsJs.UI.Controls.DropDown).call(this, function(control2) {
				if (control2.get_skinCategory() === 'Lighter') {
					control2.get_styles().addOrSet('color', ((control2.get_skinCategory() === 'Lighter') ? 'gray' : 'blue'));
				}
			}));
		}
	}, MorseCode.CsJs.UI.SkinBase, [MorseCode.CsJs.UI.ISkin]);
	ss.initClass($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_CalculatorsAndStopwatchWebServiceClientFactory, {
		createCalculatorClient: function() {
			var calculatorClient = new MorseCode.CsJs.Examples.CalculatorAndStopwatch.ViewModel.CalculatorServiceReference.CalculatorClient();
			calculatorClient.set_url(MorseCode.CsJs.UI.VirtualPathUtility.toAbsolute('~/Services/CalculatorService.svc'));
			return calculatorClient;
		}
	}, null, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.IWebServiceClientFactory]);
	ss.initClass($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_GridPage, {
		get_title: function() {
			return 'Grid';
		},
		createChildControls: function(controls) {
			this.$_navigationControl = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_NavigationControl();
			controls.add(this.$_navigationControl);
			var panel = new MorseCode.CsJs.UI.Controls.Panel(ss.mkdel(this, function(c) {
				this.$_grid = new MorseCode.CsJs.UI.Controls.Grid.Grid();
				c.add(this.$_grid);
			}));
			panel.get_styles().addOrSet('padding', '15px');
			panel.get_styles().addOrSet('background-color', 'rgb(255,255,192)');
			controls.add(panel);
		},
		bindControls: function(dataContext) {
			this.$_navigationControl.bindDataContext(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.GridPageViewModel).call(this.$_navigationControl, dataContext, function(d) {
				return d.get_navigationViewModel();
			});
			this.$_grid.bindData$2(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.GridPageViewModel, MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItemCollectionItem).call(this.$_grid, dataContext, new MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItemCollectionItem(null, -1, null, null, false), function(d1) {
				return d1.get_items();
			}, function(d2) {
				var $t34 = ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [Array]);
				var $t1 = [];
				var $t5 = ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridBoundTextColumn$2, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, ss.Int32]);
				var $t2 = { ntype: 38, type: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'o' };
				var $t3 = { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'Id', type: 16, returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [ss.Int32]), getter: { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'get_Id', type: 8, sname: 'get_id', returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [ss.Int32]), params: [] } };
				var $t4 = { ntype: 10, type: ss.makeGenericType(MorseCode.CsJs.Common.Observable.IReadableObservableProperty$1, [ss.Int32]), operand: { ntype: 23, type: $t3.returnType, expression: $t2, member: $t3 } };
				var $t6 = new $t5.$ctor3({ ntype: 18, type: Function, returnType: $t4.type, body: $t4, params: [$t2] }, function(v) {
					return 'ID #' + v;
				});
				$t6.set_headerText('ID');
				ss.add($t1, $t6);
				null;
				var $t10 = ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridBoundTextColumn$2, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, String]);
				var $t7 = { ntype: 38, type: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'o' };
				var $t8 = { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'Name', type: 16, returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [String]), getter: { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'get_Name', type: 8, sname: 'get_name', returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [String]), params: [] } };
				var $t9 = { ntype: 10, type: ss.makeGenericType(MorseCode.CsJs.Common.Observable.IReadableObservableProperty$1, [String]), operand: { ntype: 23, type: $t8.returnType, expression: $t7, member: $t8 } };
				var $t11 = new $t10.$ctor1({ ntype: 18, type: Function, returnType: $t9.type, body: $t9, params: [$t7] });
				$t11.set_headerText('Name');
				ss.add($t1, $t11);
				null;
				var $t15 = ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridBoundTextColumn$2, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, String]);
				var $t12 = { ntype: 38, type: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'o' };
				var $t13 = { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'Something', type: 16, returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [String]), getter: { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'get_Something', type: 8, sname: 'get_something', returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [String]), params: [] } };
				var $t14 = { ntype: 10, type: ss.makeGenericType(MorseCode.CsJs.Common.Observable.IReadableObservableProperty$1, [String]), operand: { ntype: 23, type: $t13.returnType, expression: $t12, member: $t13 } };
				var $t16 = new $t15.$ctor1({ ntype: 18, type: Function, returnType: $t14.type, body: $t14, params: [$t12] });
				$t16.set_headerText('Something Else');
				ss.add($t1, $t16);
				null;
				var $t20 = ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridBoundBooleanColumn$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem]);
				var $t17 = { ntype: 38, type: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'o' };
				var $t18 = { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'Boolean', type: 16, returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [Boolean]), getter: { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'get_Boolean', type: 8, sname: 'get_boolean', returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [Boolean]), params: [] } };
				var $t19 = { ntype: 10, type: ss.makeGenericType(MorseCode.CsJs.Common.Observable.IReadableObservableProperty$1, [Boolean]), operand: { ntype: 23, type: $t18.returnType, expression: $t17, member: $t18 } };
				var $t21 = new $t20.$ctor1({ ntype: 18, type: Function, returnType: $t19.type, body: $t19, params: [$t17] });
				$t21.set_headerText('A Boolean Value!');
				$t21.set_displayMode(1);
				ss.add($t1, $t21);
				null;
				var $t25 = ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridBoundBooleanColumn$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem]);
				var $t22 = { ntype: 38, type: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'o' };
				var $t23 = { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'Boolean', type: 16, returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [Boolean]), getter: { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'get_Boolean', type: 8, sname: 'get_boolean', returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [Boolean]), params: [] } };
				var $t24 = { ntype: 10, type: ss.makeGenericType(MorseCode.CsJs.Common.Observable.IReadableObservableProperty$1, [Boolean]), operand: { ntype: 23, type: $t23.returnType, expression: $t22, member: $t23 } };
				var $t26 = new $t25.$ctor3('Boolean2', { ntype: 18, type: Function, returnType: $t24.type, body: $t24, params: [$t22] });
				$t26.set_headerText('A Boolean Value With Custom Text');
				$t26.set_displayMode(1);
				$t26.set_trueText('Absolutely');
				$t26.set_falseText('No Way');
				ss.add($t1, $t26);
				null;
				var $t30 = ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridBoundBooleanColumn$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem]);
				var $t27 = { ntype: 38, type: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'o' };
				var $t28 = { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'Boolean', type: 16, returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [Boolean]), getter: { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'get_Boolean', type: 8, sname: 'get_boolean', returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [Boolean]), params: [] } };
				var $t29 = { ntype: 10, type: ss.makeGenericType(MorseCode.CsJs.Common.Observable.IReadableObservableProperty$1, [Boolean]), operand: { ntype: 23, type: $t28.returnType, expression: $t27, member: $t28 } };
				var $t31 = new $t30.$ctor3('Boolean3', { ntype: 18, type: Function, returnType: $t29.type, body: $t29, params: [$t27] });
				$t31.set_headerText('Boolean With Checkbox');
				$t31.set_displayMode(0);
				ss.add($t1, $t31);
				null;
				var $t32 = new $MorseCode_$CsJs_Examples_CalculatorsAndStopwatch_UI_GridPage$SampleGridColumn('Sample');
				$t32.set_headerText('Custom Column');
				ss.add($t1, $t32);
				null;
				var $t33 = new (ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridButtonColumn$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItemCollectionItem]))('Button', function(item, button) {
					button.bindText$1(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItemCollectionItem, ss.Int32).call(button, item, function(d21) {
						return d21.get_id();
					}, function(v1) {
						return 'Delete Row With ID ' + v1;
					});
				}, function(item1) {
					return ss.mkdel(item1, item1.delete$1);
				});
				$t33.set_headerText('Delete');
				ss.add($t1, $t33);
				null;
				return new $t34($t1);
			});
		}
	}, ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.GridPageViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl, MorseCode.CsJs.UI.Controls.IPage]);
	ss.initClass($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_NavigationControl, {
		createChildControls: function(controls) {
			this.$_switchButton = new MorseCode.CsJs.UI.Controls.Button();
			this.$_switchButton.setText('Switch Pages');
			controls.add(new MorseCode.CsJs.UI.Controls.HtmlControl('div', ss.mkdel(this, function(c) {
				c.add(this.$_switchButton);
			})));
		},
		bindControls: function(dataContext) {
			this.$_switchButton.bindClickAction(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.NavigationViewModel).call(this.$_switchButton, dataContext, function(d) {
				return ss.mkdel(d, d.switchPages);
			});
		}
	}, ss.makeGenericType(MorseCode.CsJs.UI.Controls.PlaceHolderCompositeControlBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.NavigationViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl]);
	ss.initClass($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_QueryableGridPage, {
		get_title: function() {
			return 'Grid';
		},
		createChildControls: function(controls) {
			this.$_navigationControl = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_NavigationControl();
			controls.add(this.$_navigationControl);
			var panel = new MorseCode.CsJs.UI.Controls.Panel(ss.mkdel(this, function(c) {
				this.$_grid = new MorseCode.CsJs.UI.Controls.Grid.Grid();
				c.add(this.$_grid);
			}));
			panel.get_styles().addOrSet('padding', '15px');
			panel.get_styles().addOrSet('background-color', 'rgb(255,255,192)');
			controls.add(panel);
		},
		bindControls: function(dataContext) {
			this.$_navigationControl.bindDataContext(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.QueryableGridPageViewModel).call(this.$_navigationControl, dataContext, function(d) {
				return d.get_navigationViewModel();
			});
			this.$_grid.bindDataWithSorting$2(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.QueryableGridPageViewModel, MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItemCollectionItem).call(this.$_grid, dataContext, new MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItemCollectionItem(null, -1, null, null, false), function(d1) {
				return d1.get_queryableItems();
			}, function(d2) {
				var $t34 = ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [Array]);
				var $t1 = [];
				var $t5 = ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridBoundTextColumn$2, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, ss.Int32]);
				var $t2 = { ntype: 38, type: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'o' };
				var $t3 = { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'Id', type: 16, returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [ss.Int32]), getter: { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'get_Id', type: 8, sname: 'get_id', returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [ss.Int32]), params: [] } };
				var $t4 = { ntype: 10, type: ss.makeGenericType(MorseCode.CsJs.Common.Observable.IReadableObservableProperty$1, [ss.Int32]), operand: { ntype: 23, type: $t3.returnType, expression: $t2, member: $t3 } };
				var $t6 = new $t5.$ctor3({ ntype: 18, type: Function, returnType: $t4.type, body: $t4, params: [$t2] }, function(v) {
					return 'ID #' + v;
				});
				$t6.set_headerText('ID');
				ss.add($t1, $t6);
				null;
				var $t10 = ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridBoundTextColumn$2, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, String]);
				var $t7 = { ntype: 38, type: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'o' };
				var $t8 = { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'Name', type: 16, returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [String]), getter: { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'get_Name', type: 8, sname: 'get_name', returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [String]), params: [] } };
				var $t9 = { ntype: 10, type: ss.makeGenericType(MorseCode.CsJs.Common.Observable.IReadableObservableProperty$1, [String]), operand: { ntype: 23, type: $t8.returnType, expression: $t7, member: $t8 } };
				var $t11 = new $t10.$ctor1({ ntype: 18, type: Function, returnType: $t9.type, body: $t9, params: [$t7] });
				$t11.set_headerText('Name');
				ss.add($t1, $t11);
				null;
				var $t15 = ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridBoundTextColumn$2, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, String]);
				var $t12 = { ntype: 38, type: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'o' };
				var $t13 = { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'Something', type: 16, returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [String]), getter: { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'get_Something', type: 8, sname: 'get_something', returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [String]), params: [] } };
				var $t14 = { ntype: 10, type: ss.makeGenericType(MorseCode.CsJs.Common.Observable.IReadableObservableProperty$1, [String]), operand: { ntype: 23, type: $t13.returnType, expression: $t12, member: $t13 } };
				var $t16 = new $t15.$ctor1({ ntype: 18, type: Function, returnType: $t14.type, body: $t14, params: [$t12] });
				$t16.set_headerText('Something Else');
				ss.add($t1, $t16);
				null;
				var $t20 = ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridBoundBooleanColumn$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem]);
				var $t17 = { ntype: 38, type: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'o' };
				var $t18 = { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'Boolean', type: 16, returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [Boolean]), getter: { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'get_Boolean', type: 8, sname: 'get_boolean', returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [Boolean]), params: [] } };
				var $t19 = { ntype: 10, type: ss.makeGenericType(MorseCode.CsJs.Common.Observable.IReadableObservableProperty$1, [Boolean]), operand: { ntype: 23, type: $t18.returnType, expression: $t17, member: $t18 } };
				var $t21 = new $t20.$ctor1({ ntype: 18, type: Function, returnType: $t19.type, body: $t19, params: [$t17] });
				$t21.set_headerText('A Boolean Value!');
				$t21.set_displayMode(1);
				ss.add($t1, $t21);
				null;
				var $t25 = ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridBoundBooleanColumn$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem]);
				var $t22 = { ntype: 38, type: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'o' };
				var $t23 = { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'Boolean', type: 16, returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [Boolean]), getter: { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'get_Boolean', type: 8, sname: 'get_boolean', returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [Boolean]), params: [] } };
				var $t24 = { ntype: 10, type: ss.makeGenericType(MorseCode.CsJs.Common.Observable.IReadableObservableProperty$1, [Boolean]), operand: { ntype: 23, type: $t23.returnType, expression: $t22, member: $t23 } };
				var $t26 = new $t25.$ctor3('Boolean2', { ntype: 18, type: Function, returnType: $t24.type, body: $t24, params: [$t22] });
				$t26.set_headerText('A Boolean Value With Custom Text');
				$t26.set_displayMode(1);
				$t26.set_trueText('Absolutely');
				$t26.set_falseText('No Way');
				ss.add($t1, $t26);
				null;
				var $t30 = ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridBoundBooleanColumn$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem]);
				var $t27 = { ntype: 38, type: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'o' };
				var $t28 = { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'Boolean', type: 16, returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [Boolean]), getter: { typeDef: MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItem, name: 'get_Boolean', type: 8, sname: 'get_boolean', returnType: ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [Boolean]), params: [] } };
				var $t29 = { ntype: 10, type: ss.makeGenericType(MorseCode.CsJs.Common.Observable.IReadableObservableProperty$1, [Boolean]), operand: { ntype: 23, type: $t28.returnType, expression: $t27, member: $t28 } };
				var $t31 = new $t30.$ctor3('Boolean3', { ntype: 18, type: Function, returnType: $t29.type, body: $t29, params: [$t27] });
				$t31.set_headerText('Boolean With Checkbox');
				$t31.set_displayMode(0);
				ss.add($t1, $t31);
				null;
				var $t32 = new $MorseCode_$CsJs_Examples_CalculatorsAndStopwatch_UI_QueryableGridPage$SampleGridColumn('Sample');
				$t32.set_headerText('Custom Column');
				ss.add($t1, $t32);
				null;
				var $t33 = new (ss.makeGenericType(MorseCode.CsJs.UI.Controls.Grid.GridButtonColumn$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItemCollectionItem]))('Button', function(item, button) {
					button.bindText$1(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.SampleItemCollectionItem, ss.Int32).call(button, item, function(d21) {
						return d21.get_id();
					}, function(v1) {
						return 'Delete Row With ID ' + v1;
					});
				}, function(item1) {
					return ss.mkdel(item1, item1.delete$1);
				});
				$t33.set_headerText('Delete');
				ss.add($t1, $t33);
				null;
				return new $t34($t1);
			});
		}
	}, ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.QueryableGridPageViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl, MorseCode.CsJs.UI.Controls.IPage]);
	ss.initClass($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControl, {
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
	}, ss.makeGenericType($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControlBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl]);
	ss.initClass($MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchPage, {
		get_title: function() {
			return 'Stopwatch';
		},
		createChildControls: function(controls) {
			this.$_navigationControl = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_NavigationControl();
			controls.add(this.$_navigationControl);
			this.$_stopwatchControl = new $MorseCode_CsJs_Examples_CalculatorsAndStopwatch_UI_StopwatchControl();
			controls.add(this.$_stopwatchControl);
		},
		bindControls: function(dataContext) {
			this.$_navigationControl.bindDataContext(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchPageViewModel).call(this.$_navigationControl, dataContext, function(d) {
				return d.get_navigationViewModel();
			});
			this.$_stopwatchControl.bindDataContext(MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchPageViewModel).call(this.$_stopwatchControl, dataContext, function(d1) {
				return d1.get_stopwatchViewModel();
			});
		}
	}, ss.makeGenericType(MorseCode.CsJs.UI.Controls.PageBase$1, [MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.StopwatchPageViewModel]), [ss.IDisposable, MorseCode.CsJs.UI.Controls.IControl, MorseCode.CsJs.UI.Controls.ICompositeControl, MorseCode.CsJs.UI.Controls.IPage]);
})();
