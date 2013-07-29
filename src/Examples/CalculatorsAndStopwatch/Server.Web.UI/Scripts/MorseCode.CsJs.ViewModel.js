(function() {
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.ViewModel.Grid.ColumnSortExpressionFactory.CreateColumnSortExpressionCallback
	var $MorseCode_$CsJs_ViewModel_Grid_ColumnSortExpressionFactory$1$CreateColumnSortExpressionCallback = function(T) {
		var $type = function(sortExpression, columnUniqueName) {
			this.$_columnUniqueName = null;
			ss.makeGenericType(MorseCode.CsJs.Common.Data.SortExpressionWithPropertyTypeCallbackBase$2, [T, ss.makeGenericType($MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression$1, [T])]).call(this, sortExpression);
			this.$_columnUniqueName = columnUniqueName;
		};
		$type.prototype = {
			execute: function(TProperty) {
				return function(sortExpression) {
					return new (ss.makeGenericType($MorseCode_CsJs_ViewModel_Grid_$ColumnSortExpression$2, [T, TProperty]))(this.$_columnUniqueName, sortExpression);
				};
			}
		};
		ss.registerGenericClassInstance($type, $MorseCode_$CsJs_ViewModel_Grid_ColumnSortExpressionFactory$1$CreateColumnSortExpressionCallback, [T], function() {
			return ss.makeGenericType(MorseCode.CsJs.Common.Data.SortExpressionWithPropertyTypeCallbackBase$2, [T, ss.makeGenericType($MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression$1, [T])]);
		}, function() {
			return [ss.makeGenericType(MorseCode.CsJs.Common.Data.ISortExpressionWithPropertyTypeCallback$2, [T, ss.makeGenericType($MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression$1, [T])])];
		});
		return $type;
	};
	ss.registerGenericClass(null, 'MorseCode.$CsJs.ViewModel.Grid.ColumnSortExpressionFactory$1$CreateColumnSortExpressionCallback', $MorseCode_$CsJs_ViewModel_Grid_ColumnSortExpressionFactory$1$CreateColumnSortExpressionCallback, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.ViewModel.ApplicationViewModelBase
	var $MorseCode_CsJs_ViewModel_ApplicationViewModelBase = function() {
		this.currentViewModelInternal = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableProperty$1, [Object]))();
	};
	$MorseCode_CsJs_ViewModel_ApplicationViewModelBase.prototype = {
		get_currentViewModel: function() {
			return this.currentViewModelInternal;
		},
		get_defaultViewModel: null,
		onError: null,
		get_errorHandler: function() {
			return ss.mkdel(this, this.onError);
		},
		initialize: function() {
			this.currentViewModelInternal.set_value$2(this.get_defaultViewModel());
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.ViewModel.Grid.ColumnSortExpression
	var $MorseCode_CsJs_ViewModel_Grid_$ColumnSortExpression$2 = function(T, TProperty) {
		var $type = function(columnUniqueName, sortExpression) {
			this.$_columnUniqueName = null;
			this.$_sortExpression = null;
			this.$_columnUniqueName = columnUniqueName;
			this.$_sortExpression = sortExpression;
		};
		$type.prototype = {
			get_columnUniqueName: function() {
				return this.$_columnUniqueName;
			},
			get_sortExpression$2: function() {
				return this.$_sortExpression;
			},
			get_sortExpression$1: function() {
				return this.get_sortExpression$2();
			},
			get_sortExpression: function() {
				return this.get_sortExpression$2();
			}
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_ViewModel_Grid_$ColumnSortExpression$2, [T, TProperty], function() {
			return null;
		}, function() {
			return [$MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression, ss.makeGenericType($MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression$1, [T]), ss.makeGenericType($MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression$2, [T, TProperty])];
		});
		return $type;
	};
	ss.registerGenericClass(null, 'MorseCode.CsJs.ViewModel.Grid.$ColumnSortExpression$2', $MorseCode_CsJs_ViewModel_Grid_$ColumnSortExpression$2, 2);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.ViewModel.Grid.ColumnSortExpressionFactory
	var $MorseCode_CsJs_ViewModel_Grid_ColumnSortExpressionFactory$1 = function(T) {
		var $type = function() {
		};
		$type.createSortExpression$1 = function(TProperty) {
			return function(propertyExpression, sortDirection) {
				return $type.createSortExpression(TProperty).call(null, ss.makeGenericType(MorseCode.CsJs.Common.Property.PropertyExpressionFactory$1, [T]).createPropertyExpression(ss.makeGenericType(MorseCode.CsJs.Common.Observable.IReadableProperty$1, [TProperty])).call(null, propertyExpression), sortDirection);
			};
		};
		$type.createSortExpression$3 = function(TProperty) {
			return function(columnUniqueName, propertyExpression, sortDirection) {
				return $type.createSortExpression$2(TProperty).call(null, columnUniqueName, ss.makeGenericType(MorseCode.CsJs.Common.Property.PropertyExpressionFactory$1, [T]).createPropertyExpression(ss.makeGenericType(MorseCode.CsJs.Common.Observable.IReadableProperty$1, [TProperty])).call(null, propertyExpression), sortDirection);
			};
		};
		$type.createSortExpression$4 = function(context, propertyExpression, sortDirection) {
			return $type.createSortExpression$5(propertyExpression.get_propertyName(), context, propertyExpression, sortDirection);
		};
		$type.createSortExpression$5 = function(columnUniqueName, context, propertyExpression, sortDirection) {
			var sortExpression = ss.makeGenericType(MorseCode.CsJs.Common.Data.SortExpressionFactory$1, [T]).createSortExpression$2(context, propertyExpression, sortDirection);
			return sortExpression.executeWithPropertyType(ss.makeGenericType($MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression$1, [T])).call(sortExpression, new (ss.makeGenericType($MorseCode_$CsJs_ViewModel_Grid_ColumnSortExpressionFactory$1$CreateColumnSortExpressionCallback, [T]))(sortExpression, columnUniqueName));
		};
		$type.createSortExpression = function(TProperty) {
			return function(propertyExpression, sortDirection) {
				return $type.createSortExpression$2(TProperty).call(null, propertyExpression.get_propertyName(), propertyExpression, sortDirection);
			};
		};
		$type.createSortExpression$2 = function(TProperty) {
			return function(columnUniqueName, propertyExpression, sortDirection) {
				return new (ss.makeGenericType($MorseCode_CsJs_ViewModel_Grid_$ColumnSortExpression$2, [T, TProperty]))(columnUniqueName, ss.makeGenericType(MorseCode.CsJs.Common.Data.SortExpressionFactory$1, [T]).createSortExpression(TProperty).call(null, propertyExpression, sortDirection));
			};
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_ViewModel_Grid_ColumnSortExpressionFactory$1, [T], function() {
			return null;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'MorseCode.CsJs.ViewModel.Grid.ColumnSortExpressionFactory$1', $MorseCode_CsJs_ViewModel_Grid_ColumnSortExpressionFactory$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.ViewModel.Grid.IColumnSortExpression
	var $MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression = function() {
	};
	$MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression.prototype = { get_columnUniqueName: null, get_sortExpression: null };
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.ViewModel.Grid.IColumnSortExpression
	var $MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression$1 = function(T) {
		var $type = function() {
		};
		$type.prototype = { get_sortExpression$1: null };
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression$1, [T], function() {
			return [$MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression];
		});
		return $type;
	};
	ss.registerGenericInterface(global, 'MorseCode.CsJs.ViewModel.Grid.IColumnSortExpression$1', $MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.ViewModel.Grid.IColumnSortExpression
	var $MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression$2 = function(T, TProperty) {
		var $type = function() {
		};
		$type.prototype = { get_sortExpression$2: null };
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression$2, [T, TProperty], function() {
			return [$MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression, ss.makeGenericType($MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression$1, [T])];
		});
		return $type;
	};
	ss.registerGenericInterface(global, 'MorseCode.CsJs.ViewModel.Grid.IColumnSortExpression$2', $MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression$2, 2);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.ViewModel.Grid.IQueryableData
	var $MorseCode_CsJs_ViewModel_Grid_IQueryableData$1 = function(T) {
		var $type = function() {
		};
		$type.prototype = { get_data: null, get_columnSortExpressions: null, execute: null };
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_ViewModel_Grid_IQueryableData$1, [T], function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericInterface(global, 'MorseCode.CsJs.ViewModel.Grid.IQueryableData$1', $MorseCode_CsJs_ViewModel_Grid_IQueryableData$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.ViewModel.Grid.QueryableData
	var $MorseCode_CsJs_ViewModel_Grid_QueryableData$1 = function(T) {
		var $type = function() {
			this.$_data = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableCollection$1, [T])]))(new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableCollection$1, [T]))());
			this.$_columnSortExpressions = new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1, [ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableCollection$1, [ss.makeGenericType($MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression$1, [T])])]))(new (ss.makeGenericType(MorseCode.CsJs.Common.Observable.ObservableCollection$1, [ss.makeGenericType($MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression$1, [T])]))());
			this.$_columnSortExpressions.get_value$1().add_changed(ss.mkdel(this, function(sender, args) {
				this.execute();
			}));
		};
		$type.prototype = {
			loadData: null,
			execute: function() {
				var data = this.loadData();
				this.$_data.get_value$1().clear();
				if (ss.isValue(data)) {
					this.$_data.get_value$1().addRange(data);
				}
			},
			get_data: function() {
				return this.$_data;
			},
			get_columnSortExpressions: function() {
				return this.$_columnSortExpressions;
			}
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_ViewModel_Grid_QueryableData$1, [T], function() {
			return null;
		}, function() {
			return [ss.makeGenericType($MorseCode_CsJs_ViewModel_Grid_IQueryableData$1, [T])];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'MorseCode.CsJs.ViewModel.Grid.QueryableData$1', $MorseCode_CsJs_ViewModel_Grid_QueryableData$1, 1);
	ss.registerClass(global, 'MorseCode.CsJs.ViewModel.ApplicationViewModelBase', $MorseCode_CsJs_ViewModel_ApplicationViewModelBase);
	ss.registerInterface(global, 'MorseCode.CsJs.ViewModel.Grid.IColumnSortExpression', $MorseCode_CsJs_ViewModel_Grid_IColumnSortExpression);
})();
