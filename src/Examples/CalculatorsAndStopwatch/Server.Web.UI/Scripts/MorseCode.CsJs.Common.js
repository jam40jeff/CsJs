(function() {
	'use strict';
	global.MorseCode = global.MorseCode || {};
	global.MorseCode.CsJs = global.MorseCode.CsJs || {};
	global.MorseCode.CsJs.Common = global.MorseCode.CsJs.Common || {};
	global.MorseCode.CsJs.Common.Data = global.MorseCode.CsJs.Common.Data || {};
	global.MorseCode.CsJs.Common.Observable = global.MorseCode.CsJs.Common.Observable || {};
	global.MorseCode.CsJs.Common.Property = global.MorseCode.CsJs.Common.Property || {};
	global.System = global.System || {};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Data.SortExpressionFactory.CreateSortExpressionCallback
	var $MorseCode_$CsJs_Common_Data_SortExpressionFactory$1$CreateSortExpressionCallback = function(T) {
		var $type = function(property, propertyExpression, sortDirection) {
			this.$_propertyExpression = null;
			this.$_sortDirection = 0;
			ss.makeGenericType($MorseCode_CsJs_Common_Observable_ReadablePropertyWithPropertyTypeCallbackBase$1, [ss.makeGenericType($MorseCode_CsJs_Common_Data_ISortExpression$1, [T])]).call(this, property);
			this.$_propertyExpression = propertyExpression;
			this.$_sortDirection = sortDirection;
		};
		ss.registerGenericClassInstance($type, $MorseCode_$CsJs_Common_Data_SortExpressionFactory$1$CreateSortExpressionCallback, [T], {
			execute: function(TProperty) {
				return function(property) {
					return new (ss.makeGenericType($MorseCode_CsJs_Common_Data_$SortExpression$2, [T, TProperty]))(this.$_propertyExpression, this.$_sortDirection);
				};
			}
		}, function() {
			return ss.makeGenericType($MorseCode_CsJs_Common_Observable_ReadablePropertyWithPropertyTypeCallbackBase$1, [ss.makeGenericType($MorseCode_CsJs_Common_Data_ISortExpression$1, [T])]);
		}, function() {
			return [ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadablePropertyWithPropertyTypeCallback$1, [ss.makeGenericType($MorseCode_CsJs_Common_Data_ISortExpression$1, [T])])];
		});
		return $type;
	};
	$MorseCode_$CsJs_Common_Data_SortExpressionFactory$1$CreateSortExpressionCallback.__typeName = 'MorseCode.$CsJs.Common.Data.SortExpressionFactory$1$CreateSortExpressionCallback';
	ss.initGenericClass($MorseCode_$CsJs_Common_Data_SortExpressionFactory$1$CreateSortExpressionCallback, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.AssociatedTypeCallbackBase
	var $MorseCode_CsJs_Common_AssociatedTypeCallbackBase$1 = function(T) {
		var $type = function(o) {
			this.$_o = ss.getDefaultValue(T);
			this.$_o = o;
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_AssociatedTypeCallbackBase$1, [T], {
			checkCallbackObject: function(TCallback) {
				return function(o) {
					if (!ss.referenceEquals(o, this.$_o)) {
						throw new ss.Exception('Callback object must be the same reference as the original object.');
					}
				};
			}
		}, function() {
			return null;
		}, function() {
			return [];
		});
		return $type;
	};
	$MorseCode_CsJs_Common_AssociatedTypeCallbackBase$1.__typeName = 'MorseCode.CsJs.Common.AssociatedTypeCallbackBase$1';
	ss.initGenericClass($MorseCode_CsJs_Common_AssociatedTypeCallbackBase$1, 1);
	global.MorseCode.CsJs.Common.AssociatedTypeCallbackBase$1 = $MorseCode_CsJs_Common_AssociatedTypeCallbackBase$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.EnumerableExtensionMethods
	var $MorseCode_CsJs_Common_EnumerableExtensionMethods = function() {
	};
	$MorseCode_CsJs_Common_EnumerableExtensionMethods.__typeName = 'MorseCode.CsJs.Common.EnumerableExtensionMethods';
	$MorseCode_CsJs_Common_EnumerableExtensionMethods.reset = function(T) {
		return function(collection, items) {
			if (ss.referenceEquals(collection, items)) {
				return;
			}
			if (ss.isNullOrUndefined(collection)) {
				return;
			}
			var action = function() {
				ss.clear(collection);
				var $t1 = ss.getEnumerator(items);
				try {
					while ($t1.moveNext()) {
						var item = $t1.current();
						ss.add(collection, item);
					}
				}
				finally {
					$t1.dispose();
				}
			};
			var observableCollection = ss.safeCast(collection, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IObservableCollection$1, [T]));
			if (ss.isValue(observableCollection)) {
				observableCollection.executeWhileBatchingChangeEvents(action);
			}
			else {
				action();
			}
		};
	};
	global.MorseCode.CsJs.Common.EnumerableExtensionMethods = $MorseCode_CsJs_Common_EnumerableExtensionMethods;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.FrameworkUtility
	var $MorseCode_CsJs_Common_FrameworkUtility = function() {
	};
	$MorseCode_CsJs_Common_FrameworkUtility.__typeName = 'MorseCode.CsJs.Common.FrameworkUtility';
	$MorseCode_CsJs_Common_FrameworkUtility.enumParse = function(T) {
		return function(value) {
			return ss.Enum.parse(T, value);
		};
	};
	$MorseCode_CsJs_Common_FrameworkUtility.enumToString = function(T) {
		return function(o) {
			return ss.Enum.toString(T, o);
		};
	};
	$MorseCode_CsJs_Common_FrameworkUtility.safeToString = function(o) {
		return (ss.isNullOrUndefined(o) ? null : o.toString());
	};
	$MorseCode_CsJs_Common_FrameworkUtility.byteTryParse = function(s) {
		var b;
		try {
			b = parseInt(s);
		}
		catch ($t1) {
			return null;
		}
		return (isNaN(b) ? null : b);
	};
	$MorseCode_CsJs_Common_FrameworkUtility.shortTryParse = function(s) {
		var n;
		try {
			n = parseInt(s);
		}
		catch ($t1) {
			return null;
		}
		return (isNaN(n) ? null : n);
	};
	$MorseCode_CsJs_Common_FrameworkUtility.intTryParse = function(s) {
		var i;
		try {
			i = parseInt(s);
		}
		catch ($t1) {
			return null;
		}
		return (isNaN(i) ? null : i);
	};
	$MorseCode_CsJs_Common_FrameworkUtility.longTryParse = function(s) {
		var l;
		try {
			l = parseInt(s);
		}
		catch ($t1) {
			return null;
		}
		return (isNaN(l) ? null : l);
	};
	$MorseCode_CsJs_Common_FrameworkUtility.floatTryParse = function(s) {
		var f;
		try {
			f = parseFloat(s);
		}
		catch ($t1) {
			return null;
		}
		return (isNaN(f) ? null : f);
	};
	$MorseCode_CsJs_Common_FrameworkUtility.doubleTryParse = function(s) {
		var d;
		try {
			d = parseFloat(s);
		}
		catch ($t1) {
			return null;
		}
		return (isNaN(d) ? null : d);
	};
	$MorseCode_CsJs_Common_FrameworkUtility.decimalTryParse = function(s) {
		var d;
		try {
			d = parseFloat(s);
		}
		catch ($t1) {
			return null;
		}
		return (isNaN(d) ? null : d);
	};
	global.MorseCode.CsJs.Common.FrameworkUtility = $MorseCode_CsJs_Common_FrameworkUtility;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.ITimer
	var $MorseCode_CsJs_Common_ITimer = function() {
	};
	$MorseCode_CsJs_Common_ITimer.__typeName = 'MorseCode.CsJs.Common.ITimer';
	global.MorseCode.CsJs.Common.ITimer = $MorseCode_CsJs_Common_ITimer;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.ITimerFactory
	var $MorseCode_CsJs_Common_ITimerFactory = function() {
	};
	$MorseCode_CsJs_Common_ITimerFactory.__typeName = 'MorseCode.CsJs.Common.ITimerFactory';
	global.MorseCode.CsJs.Common.ITimerFactory = $MorseCode_CsJs_Common_ITimerFactory;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.StaticReflection
	var $MorseCode_CsJs_Common_StaticReflection$1 = function(T) {
		var $type = function() {
		};
		$type.getPropertyInfo = function(TProperty) {
			return function(propertyExpression) {
				var memberExpression;
				var unaryExpression = ss.safeCast(propertyExpression.body, ss.isValue(propertyExpression.body) && [4, 10, 11, 28, 29, 30, 34, 40, 44, 49, 54, 60, 62, 77, 78, 79, 80, 82, 83, 84].indexOf(propertyExpression.body.ntype) >= 0);
				if (ss.isValue(unaryExpression)) {
					memberExpression = ss.cast(unaryExpression.operand, ss.isValue(unaryExpression.operand) && unaryExpression.operand.ntype === 23);
				}
				else {
					memberExpression = ss.cast(propertyExpression.body, ss.isValue(propertyExpression.body) && propertyExpression.body.ntype === 23);
				}
				return ss.cast(memberExpression.member, ss.isValue(memberExpression.member) && memberExpression.member.type === 16);
			};
		};
		$type.getPropertyName = function(TProperty) {
			return function(propertyExpression) {
				return $type.getPropertyInfo(TProperty).call(null, propertyExpression).name;
			};
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_StaticReflection$1, [T], {}, function() {
			return null;
		}, function() {
			return [];
		});
		return $type;
	};
	$MorseCode_CsJs_Common_StaticReflection$1.__typeName = 'MorseCode.CsJs.Common.StaticReflection$1';
	ss.initGenericClass($MorseCode_CsJs_Common_StaticReflection$1, 1);
	global.MorseCode.CsJs.Common.StaticReflection$1 = $MorseCode_CsJs_Common_StaticReflection$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.StringUtility
	var $MorseCode_CsJs_Common_StringUtility = function() {
	};
	$MorseCode_CsJs_Common_StringUtility.__typeName = 'MorseCode.CsJs.Common.StringUtility';
	$MorseCode_CsJs_Common_StringUtility.toBase64 = function(bytes) {
		if (ss.isNullOrUndefined(bytes)) {
			return null;
		}
		var output = '';
		var n = 0;
		var chr1 = 0;
		var chr2 = 0;
		var $t1 = ss.getEnumerator(bytes);
		try {
			while ($t1.moveNext()) {
				var b = $t1.current();
				switch (n) {
					case 0: {
						chr1 = b;
						break;
					}
					case 1: {
						chr2 = b;
						break;
					}
					case 2: {
						{
							var chr3 = b;
							var enc1 = chr1 >> 2;
							var enc2 = (chr1 & 3) << 4 | chr2 >> 4;
							var enc3 = (chr2 & 15) << 2 | chr3 >> 6;
							var enc4 = chr3 & 63;
							output = output + $MorseCode_CsJs_Common_StringUtility.$keyString.charAt(enc1) + $MorseCode_CsJs_Common_StringUtility.$keyString.charAt(enc2) + $MorseCode_CsJs_Common_StringUtility.$keyString.charAt(enc3) + $MorseCode_CsJs_Common_StringUtility.$keyString.charAt(enc4);
						}
						break;
					}
				}
				n++;
				n %= 3;
			}
		}
		finally {
			$t1.dispose();
		}
		if (n > 0) {
			if (n < 2) {
				chr2 = 0;
			}
			var enc11 = chr1 >> 2;
			var enc21 = (chr1 & 3) << 4 | chr2 >> 4;
			var enc31 = (chr2 & 15) << 2;
			if (n < 2) {
				enc31 = 64;
			}
			output = output + $MorseCode_CsJs_Common_StringUtility.$keyString.charAt(enc11) + $MorseCode_CsJs_Common_StringUtility.$keyString.charAt(enc21) + $MorseCode_CsJs_Common_StringUtility.$keyString.charAt(enc31) + $MorseCode_CsJs_Common_StringUtility.$keyString.charAt(64);
		}
		return output;
	};
	$MorseCode_CsJs_Common_StringUtility.toBase64$1 = function(s) {
		return $MorseCode_CsJs_Common_StringUtility.toBase64($MorseCode_CsJs_Common_StringUtility.$utf8Encode(s));
	};
	$MorseCode_CsJs_Common_StringUtility.$utf8Encode = function(s) {
		if (ss.isNullOrUndefined(s)) {
			return null;
		}
		s = s.replace(new RegExp('\\r\\n', 'g'), '\\n');
		var bytes = [];
		for (var i = 0; i < s.length; i++) {
			var c = s.charCodeAt(i);
			if (c < 128) {
				ss.add(bytes, c);
			}
			else if (c > 127 && c < 2048) {
				ss.add(bytes, c >> 6 | 192);
				ss.add(bytes, c & 63 | 128);
			}
			else {
				ss.add(bytes, c >> 12 | 224);
				ss.add(bytes, c >> 6 & 63 | 128);
				ss.add(bytes, c & 63 | 128);
			}
		}
		return bytes;
	};
	$MorseCode_CsJs_Common_StringUtility.fromBase64ToByteArray = function(s) {
		if (ss.isNullOrUndefined(s)) {
			return null;
		}
		s = s.replace(new RegExp('[^A-Za-z0-9\\+\\/\\=]', 'g'), '');
		var bytes = [];
		var n = 0;
		while (n < s.length) {
			// ReSharper disable StringIndexOfIsCultureSpecific.1
			var enc1 = $MorseCode_CsJs_Common_StringUtility.$keyString.indexOf(s.charAt(n++));
			var enc2 = $MorseCode_CsJs_Common_StringUtility.$keyString.indexOf(s.charAt(n++));
			var enc3 = $MorseCode_CsJs_Common_StringUtility.$keyString.indexOf(s.charAt(n++));
			var enc4 = $MorseCode_CsJs_Common_StringUtility.$keyString.indexOf(s.charAt(n++));
			// ReSharper restore StringIndexOfIsCultureSpecific.1
			var chr1 = enc1 << 2 | enc2 >> 4;
			var chr2 = (enc2 & 15) << 4 | enc3 >> 2;
			var chr3 = (enc3 & 3) << 6 | enc4;
			ss.add(bytes, chr1);
			if (enc3 !== 64) {
				ss.add(bytes, chr2);
			}
			if (enc4 !== 64) {
				ss.add(bytes, chr3);
			}
		}
		return bytes;
	};
	$MorseCode_CsJs_Common_StringUtility.fromBase64ToString = function(s) {
		return $MorseCode_CsJs_Common_StringUtility.$utf8Decode($MorseCode_CsJs_Common_StringUtility.fromBase64ToByteArray(s));
	};
	$MorseCode_CsJs_Common_StringUtility.$utf8Decode = function(bytes) {
		var s = '';
		var n = 0;
		while (n < bytes.length) {
			var c = bytes[n];
			if (c < 128) {
				s += String.fromCharCode(c);
				n++;
			}
			else if (c > 191 && c < 224) {
				var c2 = bytes[n + 1];
				s += String.fromCharCode((c & 31) << 6 | c2 & 63);
				n += 2;
			}
			else {
				var c21 = bytes[n + 1];
				var c3 = bytes[n + 2];
				s += String.fromCharCode((c & 15) << 12 | (c21 & 63) << 6 | c3 & 63);
				n += 3;
			}
		}
		return s;
	};
	global.MorseCode.CsJs.Common.StringUtility = $MorseCode_CsJs_Common_StringUtility;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.TimerFactory
	var $MorseCode_CsJs_Common_TimerFactory = function() {
	};
	$MorseCode_CsJs_Common_TimerFactory.__typeName = 'MorseCode.CsJs.Common.TimerFactory';
	$MorseCode_CsJs_Common_TimerFactory.get_instance = function() {
		if (ss.isNullOrUndefined($MorseCode_CsJs_Common_TimerFactory.$_instance)) {
			throw new ss.NotSupportedException('TimerFactory.Instance must be set.');
		}
		return $MorseCode_CsJs_Common_TimerFactory.$_instance;
	};
	$MorseCode_CsJs_Common_TimerFactory.set_instance = function(value) {
		$MorseCode_CsJs_Common_TimerFactory.$_instance = value;
	};
	global.MorseCode.CsJs.Common.TimerFactory = $MorseCode_CsJs_Common_TimerFactory;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.UnhandledEnumValueException
	var $MorseCode_CsJs_Common_UnhandledEnumValueException = function() {
		ss.Exception.call(this);
	};
	$MorseCode_CsJs_Common_UnhandledEnumValueException.__typeName = 'MorseCode.CsJs.Common.UnhandledEnumValueException';
	$MorseCode_CsJs_Common_UnhandledEnumValueException.$ctor1 = function(message) {
		ss.Exception.call(this, message);
	};
	$MorseCode_CsJs_Common_UnhandledEnumValueException.$ctor2 = function(message, innerException) {
		ss.Exception.call(this, message, innerException);
	};
	global.MorseCode.CsJs.Common.UnhandledEnumValueException = $MorseCode_CsJs_Common_UnhandledEnumValueException;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.UnhandledEnumValueExceptionFactory
	var $MorseCode_CsJs_Common_UnhandledEnumValueExceptionFactory = function() {
	};
	$MorseCode_CsJs_Common_UnhandledEnumValueExceptionFactory.__typeName = 'MorseCode.CsJs.Common.UnhandledEnumValueExceptionFactory';
	$MorseCode_CsJs_Common_UnhandledEnumValueExceptionFactory.create = function(T) {
		return function(value) {
			throw new $MorseCode_CsJs_Common_UnhandledEnumValueException.$ctor1('An unhandled enum value was encountered for enum type ' + ss.getTypeFullName(T) + ': ' + $MorseCode_CsJs_Common_FrameworkUtility.enumToString(T).call(null, value) + '.');
		};
	};
	global.MorseCode.CsJs.Common.UnhandledEnumValueExceptionFactory = $MorseCode_CsJs_Common_UnhandledEnumValueExceptionFactory;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.VoidType
	var $MorseCode_CsJs_Common_VoidType = function() {
	};
	$MorseCode_CsJs_Common_VoidType.__typeName = 'MorseCode.CsJs.Common.VoidType';
	global.MorseCode.CsJs.Common.VoidType = $MorseCode_CsJs_Common_VoidType;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Data.SortExpression
	var $MorseCode_CsJs_Common_Data_$SortExpression$2 = function(T, TProperty) {
		var $type = function(property, sortDirection) {
			this.$_property = null;
			this.$_sortDirection = 0;
			this.$_property = property;
			this.$_sortDirection = sortDirection;
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Data_$SortExpression$2, [T, TProperty], {
			get_property$2: function() {
				return this.$_property;
			},
			get_property$1: function() {
				return this.get_property$2();
			},
			get_property: function() {
				return this.get_property$2();
			},
			get_sortDirection: function() {
				return this.$_sortDirection;
			},
			executeWithPropertyType: function(TReturn) {
				return function(callback) {
					return callback.callback(TProperty).call(callback, this);
				};
			}
		}, function() {
			return null;
		}, function() {
			return [$MorseCode_CsJs_Common_Data_ISortExpression, ss.makeGenericType($MorseCode_CsJs_Common_Data_ISortExpression$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Data_ISortExpression$2, [T, TProperty])];
		});
		return $type;
	};
	$MorseCode_CsJs_Common_Data_$SortExpression$2.__typeName = 'MorseCode.CsJs.Common.Data.$SortExpression$2';
	ss.initGenericClass($MorseCode_CsJs_Common_Data_$SortExpression$2, 2);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Data.EnumerableSortExpressionUtility
	var $MorseCode_CsJs_Common_Data_EnumerableSortExpressionUtility = function() {
	};
	$MorseCode_CsJs_Common_Data_EnumerableSortExpressionUtility.__typeName = 'MorseCode.CsJs.Common.Data.EnumerableSortExpressionUtility';
	$MorseCode_CsJs_Common_Data_EnumerableSortExpressionUtility.apply$1 = function(T) {
		return function(data, sortExpressions) {
			if (ss.isNullOrUndefined(data) || ss.isNullOrUndefined(sortExpressions)) {
				return data;
			}
			var orderedData = null;
			var isFirst = true;
			var $t1 = ss.getEnumerator(sortExpressions);
			try {
				while ($t1.moveNext()) {
					var sortExpression = $t1.current();
					var property = { $: sortExpression.get_property$1() };
					if (!isFirst) {
						orderedData = ((sortExpression.get_sortDirection() === 1) ? orderedData.thenByDescending(ss.mkdel({ property: property }, function(o) {
							return this.property.$.getProperty$1(o).get_value();
						})) : orderedData.thenBy(ss.mkdel({ property: property }, function(o1) {
							return this.property.$.getProperty$1(o1).get_value();
						})));
					}
					else {
						// ReSharper disable PossibleMultipleEnumeration
						orderedData = ((sortExpression.get_sortDirection() === 1) ? Enumerable.from(data).orderByDescending(ss.mkdel({ property: property }, function(o2) {
							return this.property.$.getProperty$1(o2).get_value();
						})) : Enumerable.from(data).orderBy(ss.mkdel({ property: property }, function(o3) {
							return this.property.$.getProperty$1(o3).get_value();
						})));
						// ReSharper restore PossibleMultipleEnumeration
						isFirst = false;
					}
				}
			}
			finally {
				$t1.dispose();
			}
			// ReSharper disable PossibleMultipleEnumeration
			return (isFirst ? data : orderedData);
			// ReSharper restore PossibleMultipleEnumeration
		};
	};
	global.MorseCode.CsJs.Common.Data.EnumerableSortExpressionUtility = $MorseCode_CsJs_Common_Data_EnumerableSortExpressionUtility;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Data.ISortExpression
	var $MorseCode_CsJs_Common_Data_ISortExpression = function() {
	};
	$MorseCode_CsJs_Common_Data_ISortExpression.__typeName = 'MorseCode.CsJs.Common.Data.ISortExpression';
	global.MorseCode.CsJs.Common.Data.ISortExpression = $MorseCode_CsJs_Common_Data_ISortExpression;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Data.ISortExpression
	var $MorseCode_CsJs_Common_Data_ISortExpression$1 = function(T) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Data_ISortExpression$1, [T], { get_property$1: null, executeWithPropertyType: null }, function() {
			return [$MorseCode_CsJs_Common_Data_ISortExpression];
		});
		ss.setMetadata($type, { variance: [2] });
		return $type;
	};
	$MorseCode_CsJs_Common_Data_ISortExpression$1.__typeName = 'MorseCode.CsJs.Common.Data.ISortExpression$1';
	ss.initGenericInterface($MorseCode_CsJs_Common_Data_ISortExpression$1, 1);
	global.MorseCode.CsJs.Common.Data.ISortExpression$1 = $MorseCode_CsJs_Common_Data_ISortExpression$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Data.ISortExpression
	var $MorseCode_CsJs_Common_Data_ISortExpression$2 = function(T, TProperty) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Data_ISortExpression$2, [T, TProperty], { get_property$2: null }, function() {
			return [$MorseCode_CsJs_Common_Data_ISortExpression, ss.makeGenericType($MorseCode_CsJs_Common_Data_ISortExpression$1, [T])];
		});
		ss.setMetadata($type, { variance: [2, 1] });
		return $type;
	};
	$MorseCode_CsJs_Common_Data_ISortExpression$2.__typeName = 'MorseCode.CsJs.Common.Data.ISortExpression$2';
	ss.initGenericInterface($MorseCode_CsJs_Common_Data_ISortExpression$2, 2);
	global.MorseCode.CsJs.Common.Data.ISortExpression$2 = $MorseCode_CsJs_Common_Data_ISortExpression$2;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Data.ISortExpressionWithPropertyTypeCallback
	var $MorseCode_CsJs_Common_Data_ISortExpressionWithPropertyTypeCallback$2 = function(T, TReturn) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Data_ISortExpressionWithPropertyTypeCallback$2, [T, TReturn], { callback: null }, function() {
			return [];
		});
		ss.setMetadata($type, { variance: [1, 1] });
		return $type;
	};
	$MorseCode_CsJs_Common_Data_ISortExpressionWithPropertyTypeCallback$2.__typeName = 'MorseCode.CsJs.Common.Data.ISortExpressionWithPropertyTypeCallback$2';
	ss.initGenericInterface($MorseCode_CsJs_Common_Data_ISortExpressionWithPropertyTypeCallback$2, 2);
	global.MorseCode.CsJs.Common.Data.ISortExpressionWithPropertyTypeCallback$2 = $MorseCode_CsJs_Common_Data_ISortExpressionWithPropertyTypeCallback$2;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Data.SortDirection
	var $MorseCode_CsJs_Common_Data_SortDirection = function() {
	};
	$MorseCode_CsJs_Common_Data_SortDirection.__typeName = 'MorseCode.CsJs.Common.Data.SortDirection';
	global.MorseCode.CsJs.Common.Data.SortDirection = $MorseCode_CsJs_Common_Data_SortDirection;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Data.SortExpressionFactory
	var $MorseCode_CsJs_Common_Data_SortExpressionFactory$1 = function(T) {
		var $type = function() {
		};
		$type.createSortExpression$1 = function(TProperty) {
			return function(propertyExpression, sortDirection) {
				return $type.createSortExpression(TProperty).call(null, ss.makeGenericType($MorseCode_CsJs_Common_Property_PropertyExpressionFactory$1, [T]).createPropertyExpression(ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [TProperty])).call(null, propertyExpression), sortDirection);
			};
		};
		$type.createSortExpression = function(TProperty) {
			return function(propertyExpression, sortDirection) {
				return new (ss.makeGenericType($MorseCode_CsJs_Common_Data_$SortExpression$2, [T, TProperty]))(propertyExpression, sortDirection);
			};
		};
		$type.createSortExpression$2 = function(context, propertyExpression, sortDirection) {
			var property = propertyExpression.getProperty$1(context);
			return property.executeWithPropertyType(ss.makeGenericType($MorseCode_CsJs_Common_Data_ISortExpression$1, [T])).call(property, new (ss.makeGenericType($MorseCode_$CsJs_Common_Data_SortExpressionFactory$1$CreateSortExpressionCallback, [T]))(property, propertyExpression, sortDirection));
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Data_SortExpressionFactory$1, [T], {}, function() {
			return null;
		}, function() {
			return [];
		});
		return $type;
	};
	$MorseCode_CsJs_Common_Data_SortExpressionFactory$1.__typeName = 'MorseCode.CsJs.Common.Data.SortExpressionFactory$1';
	ss.initGenericClass($MorseCode_CsJs_Common_Data_SortExpressionFactory$1, 1);
	global.MorseCode.CsJs.Common.Data.SortExpressionFactory$1 = $MorseCode_CsJs_Common_Data_SortExpressionFactory$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Data.SortExpressionWithPropertyTypeCallbackBase
	var $MorseCode_CsJs_Common_Data_SortExpressionWithPropertyTypeCallbackBase$2 = function(T, TReturn) {
		var $type = function(sortExpression) {
			ss.makeGenericType($MorseCode_CsJs_Common_AssociatedTypeCallbackBase$1, [ss.makeGenericType($MorseCode_CsJs_Common_Data_ISortExpression$1, [T])]).call(this, sortExpression);
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Data_SortExpressionWithPropertyTypeCallbackBase$2, [T, TReturn], {
			callback: function(TProperty) {
				return function(sortExpression) {
					this.checkCallbackObject(ss.makeGenericType($MorseCode_CsJs_Common_Data_ISortExpression$2, [T, TProperty])).call(this, sortExpression);
					return this.execute(TProperty).call(this, sortExpression);
				};
			},
			execute: null
		}, function() {
			return ss.makeGenericType($MorseCode_CsJs_Common_AssociatedTypeCallbackBase$1, [ss.makeGenericType($MorseCode_CsJs_Common_Data_ISortExpression$1, [T])]);
		}, function() {
			return [ss.makeGenericType($MorseCode_CsJs_Common_Data_ISortExpressionWithPropertyTypeCallback$2, [T, TReturn])];
		});
		return $type;
	};
	$MorseCode_CsJs_Common_Data_SortExpressionWithPropertyTypeCallbackBase$2.__typeName = 'MorseCode.CsJs.Common.Data.SortExpressionWithPropertyTypeCallbackBase$2';
	ss.initGenericClass($MorseCode_CsJs_Common_Data_SortExpressionWithPropertyTypeCallbackBase$2, 2);
	global.MorseCode.CsJs.Common.Data.SortExpressionWithPropertyTypeCallbackBase$2 = $MorseCode_CsJs_Common_Data_SortExpressionWithPropertyTypeCallbackBase$2;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.AsyncCalculatedProperty
	var $MorseCode_CsJs_Common_Observable_AsyncCalculatedProperty$1 = function(T) {
		var $type = function(observables, calculatePropertyValue) {
			this.$_random = new ss.Random();
			this.$_requestIds = new Array();
			this.$_isCalculating = new (ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservableProperty$1, [Boolean]).$ctor1)(false);
			ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T]).call(this);
			var update = ss.mkdel(this, function() {
				this.$calculatePropertyValueAsync(calculatePropertyValue, ss.mkdel(this, this.setValue));
			});
			var $t1 = ss.getEnumerator(observables);
			try {
				while ($t1.moveNext()) {
					var observable = $t1.current();
					observable.add_changed(function(sender, args) {
						update();
					});
				}
			}
			finally {
				$t1.dispose();
			}
			this.$calculatePropertyValueAsync(calculatePropertyValue, ss.mkdel(this, this.setInitialValue));
		};
		$type.create = function(TObservable) {
			return function(observable, calculatePropertyValue, otherObservables) {
				return new $type((otherObservables || []).concat([observable]), function(setValue) {
					calculatePropertyValue(observable, setValue);
				});
			};
		};
		$type.create$1 = function(TObservable1, TObservable2) {
			return function(observable1, observable2, calculatePropertyValue, otherObservables) {
				return new $type((otherObservables || []).concat([observable1, observable2]), function(setValue) {
					calculatePropertyValue(observable1, observable2, setValue);
				});
			};
		};
		$type.create$2 = function(TObservable1, TObservable2, TObservable3) {
			return function(observable1, observable2, observable3, calculatePropertyValue, otherObservables) {
				return new $type((otherObservables || []).concat([observable1, observable2, observable3]), function(setValue) {
					calculatePropertyValue(observable1, observable2, observable3, setValue);
				});
			};
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Observable_AsyncCalculatedProperty$1, [T], {
			$calculatePropertyValueAsync: function(calculatePropertyValue, setValue) {
				var n = this.$_random.nextMax(2147483647);
				this.$_requestIds.push(n);
				this.$_isCalculating.set_value$2(true);
				calculatePropertyValue(ss.mkdel(this, function(v) {
					if (ss.contains(this.$_requestIds, n)) {
						while (this.$_requestIds.shift() !== n) {
						}
						setValue(v);
						this.$_isCalculating.set_value$2(this.$_requestIds.length > 0);
					}
				}));
			},
			get_isCalculating: function() {
				return this.$_isCalculating;
			}
		}, function() {
			return ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T]);
		}, function() {
			return [$MorseCode_CsJs_Common_Observable_IReadableProperty, $MorseCode_CsJs_Common_Observable_IObservable, $MorseCode_CsJs_Common_Observable_IReadableObservableProperty, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, [T])];
		});
		return $type;
	};
	$MorseCode_CsJs_Common_Observable_AsyncCalculatedProperty$1.__typeName = 'MorseCode.CsJs.Common.Observable.AsyncCalculatedProperty$1';
	ss.initGenericClass($MorseCode_CsJs_Common_Observable_AsyncCalculatedProperty$1, 1);
	global.MorseCode.CsJs.Common.Observable.AsyncCalculatedProperty$1 = $MorseCode_CsJs_Common_Observable_AsyncCalculatedProperty$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.CalculatedProperty
	var $MorseCode_CsJs_Common_Observable_CalculatedProperty$1 = function(T) {
		var $type = function(observables, calculatePropertyValue) {
			ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T]).call(this);
			var update = ss.mkdel(this, function() {
				this.setValue(calculatePropertyValue());
			});
			var $t1 = ss.getEnumerator(observables);
			try {
				while ($t1.moveNext()) {
					var observable = $t1.current();
					observable.add_changed(function(sender, args) {
						update();
					});
				}
			}
			finally {
				$t1.dispose();
			}
			this.setInitialValue(calculatePropertyValue());
		};
		$type.create = function(TObservable) {
			return function(observable, calculatePropertyValue, otherObservables) {
				return new $type((otherObservables || []).concat([observable]), function() {
					return calculatePropertyValue(observable);
				});
			};
		};
		$type.create$1 = function(TObservable1, TObservable2) {
			return function(observable1, observable2, calculatePropertyValue, otherObservables) {
				return new $type((otherObservables || []).concat([observable1, observable2]), function() {
					return calculatePropertyValue(observable1, observable2);
				});
			};
		};
		$type.create$2 = function(TObservable1, TObservable2, TObservable3) {
			return function(observable1, observable2, observable3, calculatePropertyValue, otherObservables) {
				return new $type((otherObservables || []).concat([observable1, observable2, observable3]), function() {
					return calculatePropertyValue(observable1, observable2, observable3);
				});
			};
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Observable_CalculatedProperty$1, [T], {}, function() {
			return ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T]);
		}, function() {
			return [$MorseCode_CsJs_Common_Observable_IReadableProperty, $MorseCode_CsJs_Common_Observable_IObservable, $MorseCode_CsJs_Common_Observable_IReadableObservableProperty, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, [T])];
		});
		return $type;
	};
	$MorseCode_CsJs_Common_Observable_CalculatedProperty$1.__typeName = 'MorseCode.CsJs.Common.Observable.CalculatedProperty$1';
	ss.initGenericClass($MorseCode_CsJs_Common_Observable_CalculatedProperty$1, 1);
	global.MorseCode.CsJs.Common.Observable.CalculatedProperty$1 = $MorseCode_CsJs_Common_Observable_CalculatedProperty$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IObservable
	var $MorseCode_CsJs_Common_Observable_IObservable = function() {
	};
	$MorseCode_CsJs_Common_Observable_IObservable.__typeName = 'MorseCode.CsJs.Common.Observable.IObservable';
	global.MorseCode.CsJs.Common.Observable.IObservable = $MorseCode_CsJs_Common_Observable_IObservable;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IObservableCollection
	var $MorseCode_CsJs_Common_Observable_IObservableCollection$1 = function(T) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Observable_IObservableCollection$1, [T], { executeWhileBatchingChangeEvents: null }, function() {
			return [ss.IEnumerable, ss.IEnumerable, ss.ICollection, ss.IList, $MorseCode_CsJs_Common_Observable_IObservable];
		});
		return $type;
	};
	$MorseCode_CsJs_Common_Observable_IObservableCollection$1.__typeName = 'MorseCode.CsJs.Common.Observable.IObservableCollection$1';
	ss.initGenericInterface($MorseCode_CsJs_Common_Observable_IObservableCollection$1, 1);
	global.MorseCode.CsJs.Common.Observable.IObservableCollection$1 = $MorseCode_CsJs_Common_Observable_IObservableCollection$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IObservableProperty
	var $MorseCode_CsJs_Common_Observable_IObservableProperty$1 = function(T) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Observable_IObservableProperty$1, [T], {}, function() {
			return [$MorseCode_CsJs_Common_Observable_IReadableProperty, $MorseCode_CsJs_Common_Observable_IObservable, $MorseCode_CsJs_Common_Observable_IReadableObservableProperty, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IWritableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IProperty$1, [T])];
		});
		return $type;
	};
	$MorseCode_CsJs_Common_Observable_IObservableProperty$1.__typeName = 'MorseCode.CsJs.Common.Observable.IObservableProperty$1';
	ss.initGenericInterface($MorseCode_CsJs_Common_Observable_IObservableProperty$1, 1);
	global.MorseCode.CsJs.Common.Observable.IObservableProperty$1 = $MorseCode_CsJs_Common_Observable_IObservableProperty$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IProperty
	var $MorseCode_CsJs_Common_Observable_IProperty$1 = function(T) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Observable_IProperty$1, [T], { get_value$2: null, set_value$1: null }, function() {
			return [$MorseCode_CsJs_Common_Observable_IReadableProperty, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IWritableProperty$1, [T])];
		});
		return $type;
	};
	$MorseCode_CsJs_Common_Observable_IProperty$1.__typeName = 'MorseCode.CsJs.Common.Observable.IProperty$1';
	ss.initGenericInterface($MorseCode_CsJs_Common_Observable_IProperty$1, 1);
	global.MorseCode.CsJs.Common.Observable.IProperty$1 = $MorseCode_CsJs_Common_Observable_IProperty$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IReadableObservableProperty
	var $MorseCode_CsJs_Common_Observable_IReadableObservableProperty = function() {
	};
	$MorseCode_CsJs_Common_Observable_IReadableObservableProperty.__typeName = 'MorseCode.CsJs.Common.Observable.IReadableObservableProperty';
	global.MorseCode.CsJs.Common.Observable.IReadableObservableProperty = $MorseCode_CsJs_Common_Observable_IReadableObservableProperty;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IReadableObservableProperty
	var $MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1 = function(T) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, [T], {}, function() {
			return [$MorseCode_CsJs_Common_Observable_IReadableProperty, $MorseCode_CsJs_Common_Observable_IObservable, $MorseCode_CsJs_Common_Observable_IReadableObservableProperty, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T])];
		});
		ss.setMetadata($type, { variance: [1] });
		return $type;
	};
	$MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1.__typeName = 'MorseCode.CsJs.Common.Observable.IReadableObservableProperty$1';
	ss.initGenericInterface($MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, 1);
	global.MorseCode.CsJs.Common.Observable.IReadableObservableProperty$1 = $MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IReadableProperty
	var $MorseCode_CsJs_Common_Observable_IReadableProperty = function() {
	};
	$MorseCode_CsJs_Common_Observable_IReadableProperty.__typeName = 'MorseCode.CsJs.Common.Observable.IReadableProperty';
	global.MorseCode.CsJs.Common.Observable.IReadableProperty = $MorseCode_CsJs_Common_Observable_IReadableProperty;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IReadableProperty
	var $MorseCode_CsJs_Common_Observable_IReadableProperty$1 = function(T) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T], { get_value$1: null }, function() {
			return [$MorseCode_CsJs_Common_Observable_IReadableProperty];
		});
		ss.setMetadata($type, { variance: [1] });
		return $type;
	};
	$MorseCode_CsJs_Common_Observable_IReadableProperty$1.__typeName = 'MorseCode.CsJs.Common.Observable.IReadableProperty$1';
	ss.initGenericInterface($MorseCode_CsJs_Common_Observable_IReadableProperty$1, 1);
	global.MorseCode.CsJs.Common.Observable.IReadableProperty$1 = $MorseCode_CsJs_Common_Observable_IReadableProperty$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IReadablePropertyWithPropertyTypeCallback
	var $MorseCode_CsJs_Common_Observable_IReadablePropertyWithPropertyTypeCallback$1 = function(TReturn) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Observable_IReadablePropertyWithPropertyTypeCallback$1, [TReturn], { callback: null }, function() {
			return [];
		});
		ss.setMetadata($type, { variance: [1] });
		return $type;
	};
	$MorseCode_CsJs_Common_Observable_IReadablePropertyWithPropertyTypeCallback$1.__typeName = 'MorseCode.CsJs.Common.Observable.IReadablePropertyWithPropertyTypeCallback$1';
	ss.initGenericInterface($MorseCode_CsJs_Common_Observable_IReadablePropertyWithPropertyTypeCallback$1, 1);
	global.MorseCode.CsJs.Common.Observable.IReadablePropertyWithPropertyTypeCallback$1 = $MorseCode_CsJs_Common_Observable_IReadablePropertyWithPropertyTypeCallback$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IReadOnlyProperty
	var $MorseCode_CsJs_Common_Observable_IReadOnlyProperty$1 = function(T) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Observable_IReadOnlyProperty$1, [T], {}, function() {
			return [$MorseCode_CsJs_Common_Observable_IReadableProperty, $MorseCode_CsJs_Common_Observable_IObservable, $MorseCode_CsJs_Common_Observable_IReadableObservableProperty, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, [T])];
		});
		ss.setMetadata($type, { variance: [1] });
		return $type;
	};
	$MorseCode_CsJs_Common_Observable_IReadOnlyProperty$1.__typeName = 'MorseCode.CsJs.Common.Observable.IReadOnlyProperty$1';
	ss.initGenericInterface($MorseCode_CsJs_Common_Observable_IReadOnlyProperty$1, 1);
	global.MorseCode.CsJs.Common.Observable.IReadOnlyProperty$1 = $MorseCode_CsJs_Common_Observable_IReadOnlyProperty$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IWritableProperty
	var $MorseCode_CsJs_Common_Observable_IWritableProperty$1 = function(T) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Observable_IWritableProperty$1, [T], { set_value: null }, function() {
			return [];
		});
		ss.setMetadata($type, { variance: [2] });
		return $type;
	};
	$MorseCode_CsJs_Common_Observable_IWritableProperty$1.__typeName = 'MorseCode.CsJs.Common.Observable.IWritableProperty$1';
	ss.initGenericInterface($MorseCode_CsJs_Common_Observable_IWritableProperty$1, 1);
	global.MorseCode.CsJs.Common.Observable.IWritableProperty$1 = $MorseCode_CsJs_Common_Observable_IWritableProperty$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.ObservableCollection
	var $MorseCode_CsJs_Common_Observable_ObservableCollection$1 = function(T) {
		var $type = function() {
			this.$_items = null;
			this.$_bulkOperationCount = 0;
			this.$_bulkOldItems = [];
			this.$_queuedChangeEvents = [];
			this.$1$BeforeChangedField = null;
			this.$1$ChangedField = null;
			this.$_items = [];
		};
		$type.$ctor1 = function(items) {
			this.$_items = null;
			this.$_bulkOperationCount = 0;
			this.$_bulkOldItems = [];
			this.$_queuedChangeEvents = [];
			this.$1$BeforeChangedField = null;
			this.$1$ChangedField = null;
			this.$_items = ss.arrayFromEnumerable(items);
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Observable_ObservableCollection$1, [T], {
			indexOf: function(item) {
				return ss.indexOf(this.$_items, item);
			},
			insert: function(index, item) {
				this.onBeforeChanged();
				ss.insert(this.$_items, index, item);
				this.$onItemAddedInternal(item);
			},
			removeAt: function(index) {
				var item = this.$_items[index];
				this.onBeforeChanged();
				ss.removeAt(this.$_items, index);
				this.$onItemRemovedInternal(item);
			},
			get_item: function(index) {
				return this.$_items[index];
			},
			set_item: function(index, value) {
				if (!ss.referenceEquals(value, this.$_items[index])) {
					this.onBeforeChanged();
					var item = this.$_items[index];
					this.$_items[index] = value;
					this.$onItemChangedInternal(item, value);
				}
			},
			add: function(item) {
				this.onBeforeChanged();
				ss.add(this.$_items, item);
				this.$onItemAddedInternal(item);
			},
			addRange: function(items) {
				var oldItems = Enumerable.from(this.$_items).toArray();
				var itemsToAdd = Enumerable.from(items).toArray();
				this.onBeforeChanged();
				ss.arrayAddRange(this.$_items, itemsToAdd);
				this.$onItemsResetInternal(oldItems, this.$_items);
			},
			clear: function() {
				var oldItems = Enumerable.from(this.$_items).toArray();
				this.onBeforeChanged();
				ss.clear(this.$_items);
				this.$onItemsResetInternal(oldItems, this.$_items);
			},
			contains: function(item) {
				return ss.contains(this.$_items, item);
			},
			get_count: function() {
				return this.$_items.length;
			},
			remove: function(item) {
				this.onBeforeChanged();
				var removed = ss.remove(this.$_items, item);
				this.$onItemRemovedInternal(item);
				return removed;
			},
			executeWhileBatchingChangeEvents: function(action) {
				if (this.$_bulkOperationCount === 0) {
					ss.arrayAddRange(this.$_bulkOldItems, this.$_items);
				}
				this.$_bulkOperationCount++;
				action();
				this.$_bulkOperationCount--;
				if (this.$_bulkOperationCount === 0) {
					var oldItems = Enumerable.from(this.$_bulkOldItems).toArray();
					ss.clear(this.$_bulkOldItems);
					if (this.$_queuedChangeEvents.length === 1) {
						this.$_queuedChangeEvents[0]();
					}
					else if (this.$_queuedChangeEvents.length > 1) {
						this.$onItemsResetInternal(oldItems, this.$_items);
					}
					ss.clear(this.$_queuedChangeEvents);
				}
			},
			getEnumerator: function() {
				return ss.getEnumerator(this.$_items);
			},
			$fireChangeEvent: function(action) {
				if (this.$_bulkOperationCount > 0) {
					ss.add(this.$_queuedChangeEvents, action);
				}
				else {
					action();
				}
			},
			$onItemAddedInternal: function(item) {
				this.$fireChangeEvent(ss.mkdel(this, function() {
					this.onItemAdded(item);
					this.onChanged();
				}));
			},
			onItemAdded: function(item) {
			},
			$onItemRemovedInternal: function(item) {
				this.$fireChangeEvent(ss.mkdel(this, function() {
					this.onItemRemoved(item);
					this.onChanged();
				}));
			},
			onItemRemoved: function(item) {
			},
			$onItemChangedInternal: function(oldItem, newItem) {
				this.$fireChangeEvent(ss.mkdel(this, function() {
					this.onItemsChanged(oldItem, newItem);
					this.onChanged();
				}));
			},
			onItemsChanged: function(oldItem, newItem) {
			},
			$onItemsResetInternal: function(oldItems, newItems) {
				this.$fireChangeEvent(ss.mkdel(this, function() {
					this.onItemsReset(oldItems, newItems);
					this.onChanged();
				}));
			},
			onItemsReset: function(oldItems, newItems) {
			},
			add_beforeChanged: function(value) {
				this.$1$BeforeChangedField = ss.delegateCombine(this.$1$BeforeChangedField, value);
			},
			remove_beforeChanged: function(value) {
				this.$1$BeforeChangedField = ss.delegateRemove(this.$1$BeforeChangedField, value);
			},
			onBeforeChanged: function() {
				if (!ss.staticEquals(this.$1$BeforeChangedField, null)) {
					this.$1$BeforeChangedField(this, ss.EventArgs.Empty);
				}
			},
			onChanged: function() {
				if (!ss.staticEquals(this.$1$ChangedField, null)) {
					this.$1$ChangedField(this, ss.EventArgs.Empty);
				}
			},
			add_changed: function(value) {
				this.$1$ChangedField = ss.delegateCombine(this.$1$ChangedField, value);
			},
			remove_changed: function(value) {
				this.$1$ChangedField = ss.delegateRemove(this.$1$ChangedField, value);
			}
		}, function() {
			return null;
		}, function() {
			return [ss.IEnumerable, ss.IEnumerable, ss.ICollection, ss.IList, $MorseCode_CsJs_Common_Observable_IObservable, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IObservableCollection$1, [T])];
		});
		$type.$ctor1.prototype = $type.prototype;
		return $type;
	};
	$MorseCode_CsJs_Common_Observable_ObservableCollection$1.__typeName = 'MorseCode.CsJs.Common.Observable.ObservableCollection$1';
	ss.initGenericClass($MorseCode_CsJs_Common_Observable_ObservableCollection$1, 1);
	global.MorseCode.CsJs.Common.Observable.ObservableCollection$1 = $MorseCode_CsJs_Common_Observable_ObservableCollection$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.ObservableProperty
	var $MorseCode_CsJs_Common_Observable_ObservableProperty$1 = function(T) {
		var $type = function() {
			ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T]).call(this);
		};
		$type.$ctor1 = function(value) {
			ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T]).call(this);
			this.setInitialValue(value);
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Observable_ObservableProperty$1, [T], {
			get_value$2: function() {
				return this.getValue();
			},
			set_value$1: function(value) {
				this.setValue(value);
			},
			set_value: function(value) {
				this.setValue(value);
			},
			get_value$1: function() {
				return this.getValue();
			},
			get_value: function() {
				return this.getValue();
			},
			set_value$2: function(value) {
				this.setValue(value);
			}
		}, function() {
			return ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T]);
		}, function() {
			return [$MorseCode_CsJs_Common_Observable_IReadableProperty, $MorseCode_CsJs_Common_Observable_IObservable, $MorseCode_CsJs_Common_Observable_IReadableObservableProperty, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IWritableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IObservableProperty$1, [T])];
		});
		$type.$ctor1.prototype = $type.prototype;
		return $type;
	};
	$MorseCode_CsJs_Common_Observable_ObservableProperty$1.__typeName = 'MorseCode.CsJs.Common.Observable.ObservableProperty$1';
	ss.initGenericClass($MorseCode_CsJs_Common_Observable_ObservableProperty$1, 1);
	global.MorseCode.CsJs.Common.Observable.ObservableProperty$1 = $MorseCode_CsJs_Common_Observable_ObservableProperty$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.ObservablePropertyBase
	var $MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1 = function(T) {
		var $type = function() {
			this.$_value = ss.getDefaultValue(T);
			this.$1$BeforeChangedField = null;
			this.$1$ChangedField = null;
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T], {
			get_value$1: function() {
				return this.getValue();
			},
			executeWithPropertyType: function(TReturn) {
				return function(callback) {
					return callback.callback(T).call(callback, this);
				};
			},
			get_value: function() {
				return this.get_value$1();
			},
			getValue: function() {
				return this.$_value;
			},
			setInitialValue: function(value) {
				this.$_value = value;
			},
			setValue: function(value) {
				if (!ss.referenceEquals(value, this.$_value)) {
					this.onBeforeValueChanged();
					this.$_value = value;
					this.onValueChanged();
				}
			},
			add_beforeChanged: function(value) {
				this.$1$BeforeChangedField = ss.delegateCombine(this.$1$BeforeChangedField, value);
			},
			remove_beforeChanged: function(value) {
				this.$1$BeforeChangedField = ss.delegateRemove(this.$1$BeforeChangedField, value);
			},
			onBeforeValueChanged: function() {
				if (!ss.staticEquals(this.$1$BeforeChangedField, null)) {
					this.$1$BeforeChangedField(this, ss.EventArgs.Empty);
				}
			},
			add_changed: function(value) {
				this.$1$ChangedField = ss.delegateCombine(this.$1$ChangedField, value);
			},
			remove_changed: function(value) {
				this.$1$ChangedField = ss.delegateRemove(this.$1$ChangedField, value);
			},
			onValueChanged: function() {
				if (!ss.staticEquals(this.$1$ChangedField, null)) {
					this.$1$ChangedField(this, ss.EventArgs.Empty);
				}
			},
			toString: function() {
				return (ss.referenceEquals(this.get_value$1(), null) ? null : this.get_value$1().toString());
			}
		}, function() {
			return null;
		}, function() {
			return [$MorseCode_CsJs_Common_Observable_IReadableProperty, $MorseCode_CsJs_Common_Observable_IObservable, $MorseCode_CsJs_Common_Observable_IReadableObservableProperty, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, [T])];
		});
		return $type;
	};
	$MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1.__typeName = 'MorseCode.CsJs.Common.Observable.ObservablePropertyBase$1';
	ss.initGenericClass($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, 1);
	global.MorseCode.CsJs.Common.Observable.ObservablePropertyBase$1 = $MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.ReadablePropertyWithPropertyTypeCallbackBase
	var $MorseCode_CsJs_Common_Observable_ReadablePropertyWithPropertyTypeCallbackBase$1 = function(TReturn) {
		var $type = function(property) {
			ss.makeGenericType($MorseCode_CsJs_Common_AssociatedTypeCallbackBase$1, [$MorseCode_CsJs_Common_Observable_IReadableProperty]).call(this, property);
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Observable_ReadablePropertyWithPropertyTypeCallbackBase$1, [TReturn], {
			callback: function(TProperty) {
				return function(property) {
					this.checkCallbackObject(ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [TProperty])).call(this, property);
					return this.execute(TProperty).call(this, property);
				};
			},
			execute: null
		}, function() {
			return ss.makeGenericType($MorseCode_CsJs_Common_AssociatedTypeCallbackBase$1, [$MorseCode_CsJs_Common_Observable_IReadableProperty]);
		}, function() {
			return [ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadablePropertyWithPropertyTypeCallback$1, [TReturn])];
		});
		return $type;
	};
	$MorseCode_CsJs_Common_Observable_ReadablePropertyWithPropertyTypeCallbackBase$1.__typeName = 'MorseCode.CsJs.Common.Observable.ReadablePropertyWithPropertyTypeCallbackBase$1';
	ss.initGenericClass($MorseCode_CsJs_Common_Observable_ReadablePropertyWithPropertyTypeCallbackBase$1, 1);
	global.MorseCode.CsJs.Common.Observable.ReadablePropertyWithPropertyTypeCallbackBase$1 = $MorseCode_CsJs_Common_Observable_ReadablePropertyWithPropertyTypeCallbackBase$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.ReadOnlyProperty
	var $MorseCode_CsJs_Common_Observable_ReadOnlyProperty$1 = function(T) {
		var $type = function(value) {
			ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T]).call(this);
			this.setInitialValue(value);
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Observable_ReadOnlyProperty$1, [T], {}, function() {
			return ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T]);
		}, function() {
			return [$MorseCode_CsJs_Common_Observable_IReadableProperty, $MorseCode_CsJs_Common_Observable_IObservable, $MorseCode_CsJs_Common_Observable_IReadableObservableProperty, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadOnlyProperty$1, [T])];
		});
		return $type;
	};
	$MorseCode_CsJs_Common_Observable_ReadOnlyProperty$1.__typeName = 'MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1';
	ss.initGenericClass($MorseCode_CsJs_Common_Observable_ReadOnlyProperty$1, 1);
	global.MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1 = $MorseCode_CsJs_Common_Observable_ReadOnlyProperty$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Property.IPropertyExpression
	var $MorseCode_CsJs_Common_Property_IPropertyExpression = function() {
	};
	$MorseCode_CsJs_Common_Property_IPropertyExpression.__typeName = 'MorseCode.CsJs.Common.Property.IPropertyExpression';
	global.MorseCode.CsJs.Common.Property.IPropertyExpression = $MorseCode_CsJs_Common_Property_IPropertyExpression;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Property.IPropertyExpression
	var $MorseCode_CsJs_Common_Property_IPropertyExpression$1 = function(T) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Property_IPropertyExpression$1, [T], { getProperty: null }, function() {
			return [$MorseCode_CsJs_Common_Property_IPropertyExpression];
		});
		ss.setMetadata($type, { variance: [2] });
		return $type;
	};
	$MorseCode_CsJs_Common_Property_IPropertyExpression$1.__typeName = 'MorseCode.CsJs.Common.Property.IPropertyExpression$1';
	ss.initGenericInterface($MorseCode_CsJs_Common_Property_IPropertyExpression$1, 1);
	global.MorseCode.CsJs.Common.Property.IPropertyExpression$1 = $MorseCode_CsJs_Common_Property_IPropertyExpression$1;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Property.IPropertyExpression
	var $MorseCode_CsJs_Common_Property_IPropertyExpression$2 = function(T, TProperty) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Property_IPropertyExpression$2, [T, TProperty], { getProperty$1: null }, function() {
			return [$MorseCode_CsJs_Common_Property_IPropertyExpression, ss.makeGenericType($MorseCode_CsJs_Common_Property_IPropertyExpression$1, [T])];
		});
		ss.setMetadata($type, { variance: [2, 1] });
		return $type;
	};
	$MorseCode_CsJs_Common_Property_IPropertyExpression$2.__typeName = 'MorseCode.CsJs.Common.Property.IPropertyExpression$2';
	ss.initGenericInterface($MorseCode_CsJs_Common_Property_IPropertyExpression$2, 2);
	global.MorseCode.CsJs.Common.Property.IPropertyExpression$2 = $MorseCode_CsJs_Common_Property_IPropertyExpression$2;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Property.PropertyExpression
	var $MorseCode_CsJs_Common_Property_PropertyExpression$2 = function(T, TProperty) {
		var $type = function(propertyName, getProperty) {
			this.$_propertyName = null;
			this.$_getProperty = null;
			this.$_propertyName = propertyName;
			this.$_getProperty = getProperty;
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Property_PropertyExpression$2, [T, TProperty], {
			get_propertyName: function() {
				return this.$_propertyName;
			},
			getProperty: function(item) {
				return this.getProperty$1(item);
			},
			getProperty$1: function(item) {
				return this.$_getProperty(item);
			}
		}, function() {
			return null;
		}, function() {
			return [$MorseCode_CsJs_Common_Property_IPropertyExpression, ss.makeGenericType($MorseCode_CsJs_Common_Property_IPropertyExpression$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Property_IPropertyExpression$2, [T, TProperty])];
		});
		return $type;
	};
	$MorseCode_CsJs_Common_Property_PropertyExpression$2.__typeName = 'MorseCode.CsJs.Common.Property.PropertyExpression$2';
	ss.initGenericClass($MorseCode_CsJs_Common_Property_PropertyExpression$2, 2);
	global.MorseCode.CsJs.Common.Property.PropertyExpression$2 = $MorseCode_CsJs_Common_Property_PropertyExpression$2;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Property.PropertyExpressionFactory
	var $MorseCode_CsJs_Common_Property_PropertyExpressionFactory$1 = function(T) {
		var $type = function() {
		};
		$type.createPropertyExpression = function(TProperty) {
			return function(propertyExpression) {
				var property = ss.makeGenericType($MorseCode_CsJs_Common_StaticReflection$1, [T]).getPropertyInfo(TProperty).call(null, propertyExpression);
				var getProperty = function(item) {
					return ss.cast(ss.midel(property.getter, item)(), TProperty);
				};
				return new (ss.makeGenericType($MorseCode_CsJs_Common_Property_PropertyExpression$2, [T, TProperty]))(property.name, getProperty);
			};
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Property_PropertyExpressionFactory$1, [T], {}, function() {
			return null;
		}, function() {
			return [];
		});
		return $type;
	};
	$MorseCode_CsJs_Common_Property_PropertyExpressionFactory$1.__typeName = 'MorseCode.CsJs.Common.Property.PropertyExpressionFactory$1';
	ss.initGenericClass($MorseCode_CsJs_Common_Property_PropertyExpressionFactory$1, 1);
	global.MorseCode.CsJs.Common.Property.PropertyExpressionFactory$1 = $MorseCode_CsJs_Common_Property_PropertyExpressionFactory$1;
	////////////////////////////////////////////////////////////////////////////////
	// System.NotImplementedException
	var $System_NotImplementedException = function() {
		ss.Exception.call(this);
	};
	$System_NotImplementedException.__typeName = 'System.NotImplementedException';
	$System_NotImplementedException.$ctor1 = function(message) {
		ss.Exception.call(this, message);
	};
	$System_NotImplementedException.$ctor2 = function(message, innerException) {
		ss.Exception.call(this, message, innerException);
	};
	global.System.NotImplementedException = $System_NotImplementedException;
	ss.initClass($MorseCode_CsJs_Common_EnumerableExtensionMethods, {});
	ss.initClass($MorseCode_CsJs_Common_FrameworkUtility, {});
	ss.initInterface($MorseCode_CsJs_Common_ITimer, { start: null, startSafe: null, stop: null, stopSafe: null, get_isRunning: null });
	ss.initInterface($MorseCode_CsJs_Common_ITimerFactory, { createTimer: null });
	ss.initClass($MorseCode_CsJs_Common_StringUtility, {});
	ss.initClass($MorseCode_CsJs_Common_TimerFactory, {});
	ss.initClass($MorseCode_CsJs_Common_UnhandledEnumValueException, {}, ss.Exception);
	$MorseCode_CsJs_Common_UnhandledEnumValueException.$ctor1.prototype = $MorseCode_CsJs_Common_UnhandledEnumValueException.$ctor2.prototype = $MorseCode_CsJs_Common_UnhandledEnumValueException.prototype;
	ss.initClass($MorseCode_CsJs_Common_UnhandledEnumValueExceptionFactory, {});
	ss.initClass($MorseCode_CsJs_Common_VoidType, {});
	ss.initInterface($MorseCode_CsJs_Common_Data_ISortExpression, { get_property: null, get_sortDirection: null });
	ss.initClass($MorseCode_CsJs_Common_Data_EnumerableSortExpressionUtility, {});
	ss.initEnum($MorseCode_CsJs_Common_Data_SortDirection, { ascending: 0, descending: 1 });
	ss.initInterface($MorseCode_CsJs_Common_Observable_IReadableProperty, { get_value: null, executeWithPropertyType: null });
	ss.initInterface($MorseCode_CsJs_Common_Observable_IObservable, { add_beforeChanged: null, remove_beforeChanged: null, add_changed: null, remove_changed: null });
	ss.initInterface($MorseCode_CsJs_Common_Observable_IReadableObservableProperty, {}, [$MorseCode_CsJs_Common_Observable_IReadableProperty, $MorseCode_CsJs_Common_Observable_IObservable]);
	ss.initInterface($MorseCode_CsJs_Common_Property_IPropertyExpression, { get_propertyName: null });
	ss.initClass($System_NotImplementedException, {}, ss.Exception);
	$System_NotImplementedException.$ctor1.prototype = $System_NotImplementedException.$ctor2.prototype = $System_NotImplementedException.prototype;
	ss.setMetadata($MorseCode_CsJs_Common_Data_ISortExpression$1, { variance: [2] });
	ss.setMetadata($MorseCode_CsJs_Common_Data_ISortExpression$2, { variance: [2, 1] });
	ss.setMetadata($MorseCode_CsJs_Common_Data_ISortExpressionWithPropertyTypeCallback$2, { variance: [1, 1] });
	ss.setMetadata($MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, { variance: [1] });
	ss.setMetadata($MorseCode_CsJs_Common_Observable_IReadableProperty$1, { variance: [1] });
	ss.setMetadata($MorseCode_CsJs_Common_Observable_IReadablePropertyWithPropertyTypeCallback$1, { variance: [1] });
	ss.setMetadata($MorseCode_CsJs_Common_Observable_IReadOnlyProperty$1, { variance: [1] });
	ss.setMetadata($MorseCode_CsJs_Common_Observable_IWritableProperty$1, { variance: [2] });
	ss.setMetadata($MorseCode_CsJs_Common_Property_IPropertyExpression$1, { variance: [2] });
	ss.setMetadata($MorseCode_CsJs_Common_Property_IPropertyExpression$2, { variance: [2, 1] });
	$MorseCode_CsJs_Common_StringUtility.$keyString = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=';
	$MorseCode_CsJs_Common_TimerFactory.$_instance = null;
	$MorseCode_CsJs_Common_VoidType.$value = new $MorseCode_CsJs_Common_VoidType();
})();
