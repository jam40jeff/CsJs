(function() {
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.FrameworkUtility
	var $MorseCode_CsJs_Common_FrameworkUtility = function() {
	};
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
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.ITimer
	var $MorseCode_CsJs_Common_ITimer = function() {
	};
	$MorseCode_CsJs_Common_ITimer.prototype = { start: null, startSafe: null, stop: null, stopSafe: null, get_isRunning: null };
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.ITimerFactory
	var $MorseCode_CsJs_Common_ITimerFactory = function() {
	};
	$MorseCode_CsJs_Common_ITimerFactory.prototype = { createTimer: null };
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
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_StaticReflection$1, [T], function() {
			return null;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'MorseCode.CsJs.Common.StaticReflection$1', $MorseCode_CsJs_Common_StaticReflection$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.StringUtility
	var $MorseCode_CsJs_Common_StringUtility = function() {
	};
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
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.TimerFactory
	var $MorseCode_CsJs_Common_TimerFactory = function() {
	};
	$MorseCode_CsJs_Common_TimerFactory.get_instance = function() {
		if (ss.isNullOrUndefined($MorseCode_CsJs_Common_TimerFactory.$_instance)) {
			throw new ss.NotSupportedException('TimerFactory.Instance must be set.');
		}
		return $MorseCode_CsJs_Common_TimerFactory.$_instance;
	};
	$MorseCode_CsJs_Common_TimerFactory.set_instance = function(value) {
		$MorseCode_CsJs_Common_TimerFactory.$_instance = value;
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.UnhandledEnumValueException
	var $MorseCode_CsJs_Common_UnhandledEnumValueException = function() {
		ss.Exception.call(this);
	};
	$MorseCode_CsJs_Common_UnhandledEnumValueException.$ctor1 = function(message) {
		ss.Exception.call(this, message);
	};
	$MorseCode_CsJs_Common_UnhandledEnumValueException.$ctor2 = function(message, innerException) {
		ss.Exception.call(this, message, innerException);
	};
	$MorseCode_CsJs_Common_UnhandledEnumValueException.$ctor1.prototype = $MorseCode_CsJs_Common_UnhandledEnumValueException.$ctor2.prototype = $MorseCode_CsJs_Common_UnhandledEnumValueException.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.UnhandledEnumValueExceptionFactory
	var $MorseCode_CsJs_Common_UnhandledEnumValueExceptionFactory = function() {
	};
	$MorseCode_CsJs_Common_UnhandledEnumValueExceptionFactory.create = function(T) {
		return function(value) {
			throw new $MorseCode_CsJs_Common_UnhandledEnumValueException.$ctor1('An unhandled enum value was encountered for enum type ' + ss.getTypeFullName(T) + ': ' + $MorseCode_CsJs_Common_FrameworkUtility.enumToString(T).call(null, value) + '.');
		};
	};
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
		$type.prototype = {
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
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Observable_AsyncCalculatedProperty$1, [T], function() {
			return ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T]);
		}, function() {
			return [ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), $MorseCode_CsJs_Common_Observable_IObservable, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, [T])];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'MorseCode.CsJs.Common.Observable.AsyncCalculatedProperty$1', $MorseCode_CsJs_Common_Observable_AsyncCalculatedProperty$1, 1);
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
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Observable_CalculatedProperty$1, [T], function() {
			return ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T]);
		}, function() {
			return [ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), $MorseCode_CsJs_Common_Observable_IObservable, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, [T])];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'MorseCode.CsJs.Common.Observable.CalculatedProperty$1', $MorseCode_CsJs_Common_Observable_CalculatedProperty$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IObservable
	var $MorseCode_CsJs_Common_Observable_IObservable = function() {
	};
	$MorseCode_CsJs_Common_Observable_IObservable.prototype = { add_beforeChanged: null, remove_beforeChanged: null, add_changed: null, remove_changed: null };
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IObservableCollection
	var $MorseCode_CsJs_Common_Observable_IObservableCollection$1 = function(T) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Observable_IObservableCollection$1, [T], function() {
			return [ss.IEnumerable, ss.IEnumerable, ss.ICollection, ss.IList, $MorseCode_CsJs_Common_Observable_IObservable];
		});
		return $type;
	};
	ss.registerGenericInterface(global, 'MorseCode.CsJs.Common.Observable.IObservableCollection$1', $MorseCode_CsJs_Common_Observable_IObservableCollection$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IObservableProperty
	var $MorseCode_CsJs_Common_Observable_IObservableProperty$1 = function(T) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Observable_IObservableProperty$1, [T], function() {
			return [ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), $MorseCode_CsJs_Common_Observable_IObservable, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IWritableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IProperty$1, [T])];
		});
		return $type;
	};
	ss.registerGenericInterface(global, 'MorseCode.CsJs.Common.Observable.IObservableProperty$1', $MorseCode_CsJs_Common_Observable_IObservableProperty$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IProperty
	var $MorseCode_CsJs_Common_Observable_IProperty$1 = function(T) {
		var $type = function() {
		};
		$type.prototype = { get_value$1: null, set_value$1: null };
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Observable_IProperty$1, [T], function() {
			return [ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IWritableProperty$1, [T])];
		});
		return $type;
	};
	ss.registerGenericInterface(global, 'MorseCode.CsJs.Common.Observable.IProperty$1', $MorseCode_CsJs_Common_Observable_IProperty$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IReadableObservableProperty
	var $MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1 = function(T) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, [T], function() {
			return [ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), $MorseCode_CsJs_Common_Observable_IObservable];
		});
		return $type;
	};
	ss.registerGenericInterface(global, 'MorseCode.CsJs.Common.Observable.IReadableObservableProperty$1', $MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IReadableProperty
	var $MorseCode_CsJs_Common_Observable_IReadableProperty$1 = function(T) {
		var $type = function() {
		};
		$type.prototype = { get_value: null };
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T], function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericInterface(global, 'MorseCode.CsJs.Common.Observable.IReadableProperty$1', $MorseCode_CsJs_Common_Observable_IReadableProperty$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IReadOnlyProperty
	var $MorseCode_CsJs_Common_Observable_IReadOnlyProperty$1 = function(T) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Observable_IReadOnlyProperty$1, [T], function() {
			return [ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), $MorseCode_CsJs_Common_Observable_IObservable, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, [T])];
		});
		return $type;
	};
	ss.registerGenericInterface(global, 'MorseCode.CsJs.Common.Observable.IReadOnlyProperty$1', $MorseCode_CsJs_Common_Observable_IReadOnlyProperty$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.IWritableProperty
	var $MorseCode_CsJs_Common_Observable_IWritableProperty$1 = function(T) {
		var $type = function() {
		};
		$type.prototype = { set_value: null };
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Observable_IWritableProperty$1, [T], function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericInterface(global, 'MorseCode.CsJs.Common.Observable.IWritableProperty$1', $MorseCode_CsJs_Common_Observable_IWritableProperty$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.ObservableCollection
	var $MorseCode_CsJs_Common_Observable_ObservableCollection$1 = function(T) {
		var $type = function() {
			this.$_items = null;
			this.$1$BeforeChangedField = null;
			this.$1$ChangedField = null;
			this.$_items = [];
		};
		$type.prototype = {
			indexOf: function(item) {
				return ss.indexOf(this.$_items, item);
			},
			insert: function(index, item) {
				this.onBeforeChanged();
				ss.insert(this.$_items, index, item);
				this.onItemAdded(item);
				this.onChanged();
			},
			removeAt: function(index) {
				var item = this.$_items[index];
				this.onBeforeChanged();
				ss.removeAt(this.$_items, index);
				this.onItemRemoved(item);
				this.onChanged();
			},
			get_item: function(index) {
				return this.$_items[index];
			},
			set_item: function(index, value) {
				if (!ss.referenceEquals(value, this.$_items[index])) {
					this.onBeforeChanged();
					this.$_items[index] = value;
					this.onChanged();
				}
			},
			add: function(item) {
				this.onBeforeChanged();
				ss.add(this.$_items, item);
				this.onItemAdded(item);
				this.onChanged();
			},
			addRange: function(items) {
				var itemsToAdd = Enumerable.from(items).toArray();
				this.onBeforeChanged();
				ss.arrayAddRange(this.$_items, itemsToAdd);
				itemsToAdd.forEach(ss.mkdel(this, this.onItemAdded));
				this.onChanged();
			},
			clear: function() {
				var oldItems = Enumerable.from(this.$_items).toArray();
				this.onBeforeChanged();
				ss.clear(this.$_items);
				this.onItemsReset(oldItems, this.$_items);
				this.onChanged();
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
				this.onItemRemoved(item);
				this.onChanged();
				return removed;
			},
			getEnumerator: function() {
				return ss.getEnumerator(this.$_items);
			},
			onItemAdded: function(item) {
			},
			onItemRemoved: function(item) {
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
		};
		$type.$ctor1 = function(items) {
			this.$_items = null;
			this.$1$BeforeChangedField = null;
			this.$1$ChangedField = null;
			this.$_items = ss.arrayFromEnumerable(items);
		};
		$type.$ctor1.prototype = $type.prototype;
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Observable_ObservableCollection$1, [T], function() {
			return null;
		}, function() {
			return [ss.IEnumerable, ss.IEnumerable, ss.ICollection, ss.IList, $MorseCode_CsJs_Common_Observable_IObservable, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IObservableCollection$1, [T])];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'MorseCode.CsJs.Common.Observable.ObservableCollection$1', $MorseCode_CsJs_Common_Observable_ObservableCollection$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.ObservableProperty
	var $MorseCode_CsJs_Common_Observable_ObservableProperty$1 = function(T) {
		var $type = function() {
			ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T]).call(this);
		};
		$type.prototype = {
			get_value$1: function() {
				return this.getValue();
			},
			set_value$1: function(value) {
				this.setValue(value);
			},
			set_value: function(value) {
				this.setValue(value);
			},
			get_value: function() {
				return this.getValue();
			},
			set_value$2: function(value) {
				this.setValue(value);
			}
		};
		$type.$ctor1 = function(value) {
			ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T]).call(this);
			this.setInitialValue(value);
		};
		$type.$ctor1.prototype = $type.prototype;
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Observable_ObservableProperty$1, [T], function() {
			return ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T]);
		}, function() {
			return [ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), $MorseCode_CsJs_Common_Observable_IObservable, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IWritableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IObservableProperty$1, [T])];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'MorseCode.CsJs.Common.Observable.ObservableProperty$1', $MorseCode_CsJs_Common_Observable_ObservableProperty$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.ObservablePropertyBase
	var $MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1 = function(T) {
		var $type = function() {
			this.$_value = ss.getDefaultValue(T);
			this.$1$BeforeChangedField = null;
			this.$1$ChangedField = null;
		};
		$type.prototype = {
			get_value: function() {
				return this.getValue();
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
				return (ss.referenceEquals(this.get_value(), null) ? null : this.get_value().toString());
			}
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T], function() {
			return null;
		}, function() {
			return [ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), $MorseCode_CsJs_Common_Observable_IObservable, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, [T])];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'MorseCode.CsJs.Common.Observable.ObservablePropertyBase$1', $MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Observable.ReadOnlyProperty
	var $MorseCode_CsJs_Common_Observable_ReadOnlyProperty$1 = function(T) {
		var $type = function(value) {
			ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T]).call(this);
			this.setInitialValue(value);
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Observable_ReadOnlyProperty$1, [T], function() {
			return ss.makeGenericType($MorseCode_CsJs_Common_Observable_ObservablePropertyBase$1, [T]);
		}, function() {
			return [ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableProperty$1, [T]), $MorseCode_CsJs_Common_Observable_IObservable, ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadableObservableProperty$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Observable_IReadOnlyProperty$1, [T])];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'MorseCode.CsJs.Common.Observable.ReadOnlyProperty$1', $MorseCode_CsJs_Common_Observable_ReadOnlyProperty$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Property.IPropertyExpression
	var $MorseCode_CsJs_Common_Property_IPropertyExpression = function() {
	};
	$MorseCode_CsJs_Common_Property_IPropertyExpression.prototype = { get_propertyName: null };
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Property.IPropertyExpression
	var $MorseCode_CsJs_Common_Property_IPropertyExpression$1 = function(T) {
		var $type = function() {
		};
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Property_IPropertyExpression$1, [T], function() {
			return [$MorseCode_CsJs_Common_Property_IPropertyExpression];
		});
		return $type;
	};
	ss.registerGenericInterface(global, 'MorseCode.CsJs.Common.Property.IPropertyExpression$1', $MorseCode_CsJs_Common_Property_IPropertyExpression$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Property.IPropertyExpression
	var $MorseCode_CsJs_Common_Property_IPropertyExpression$2 = function(T, TProperty) {
		var $type = function() {
		};
		$type.prototype = { getProperty: null };
		ss.registerGenericInterfaceInstance($type, $MorseCode_CsJs_Common_Property_IPropertyExpression$2, [T, TProperty], function() {
			return [$MorseCode_CsJs_Common_Property_IPropertyExpression, ss.makeGenericType($MorseCode_CsJs_Common_Property_IPropertyExpression$1, [T])];
		});
		return $type;
	};
	ss.registerGenericInterface(global, 'MorseCode.CsJs.Common.Property.IPropertyExpression$2', $MorseCode_CsJs_Common_Property_IPropertyExpression$2, 2);
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Common.Property.PropertyExpression
	var $MorseCode_CsJs_Common_Property_PropertyExpression$2 = function(T, TProperty) {
		var $type = function(propertyName, getProperty) {
			this.$_propertyName = null;
			this.$_getProperty = null;
			this.$_propertyName = propertyName;
			this.$_getProperty = getProperty;
		};
		$type.prototype = {
			get_propertyName: function() {
				return this.$_propertyName;
			},
			getProperty: function(item) {
				return this.$_getProperty(item);
			}
		};
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Property_PropertyExpression$2, [T, TProperty], function() {
			return null;
		}, function() {
			return [$MorseCode_CsJs_Common_Property_IPropertyExpression, ss.makeGenericType($MorseCode_CsJs_Common_Property_IPropertyExpression$1, [T]), ss.makeGenericType($MorseCode_CsJs_Common_Property_IPropertyExpression$2, [T, TProperty])];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'MorseCode.CsJs.Common.Property.PropertyExpression$2', $MorseCode_CsJs_Common_Property_PropertyExpression$2, 2);
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
		ss.registerGenericClassInstance($type, $MorseCode_CsJs_Common_Property_PropertyExpressionFactory$1, [T], function() {
			return null;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'MorseCode.CsJs.Common.Property.PropertyExpressionFactory$1', $MorseCode_CsJs_Common_Property_PropertyExpressionFactory$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// System.InvalidOperationException
	var $System_InvalidOperationException = function() {
		ss.Exception.call(this);
	};
	$System_InvalidOperationException.$ctor1 = function(message) {
		ss.Exception.call(this, message);
	};
	$System_InvalidOperationException.$ctor2 = function(message, innerException) {
		ss.Exception.call(this, message, innerException);
	};
	$System_InvalidOperationException.$ctor1.prototype = $System_InvalidOperationException.$ctor2.prototype = $System_InvalidOperationException.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// System.NotImplementedException
	var $System_NotImplementedException = function() {
		ss.Exception.call(this);
	};
	$System_NotImplementedException.$ctor1 = function(message) {
		ss.Exception.call(this, message);
	};
	$System_NotImplementedException.$ctor2 = function(message, innerException) {
		ss.Exception.call(this, message, innerException);
	};
	$System_NotImplementedException.$ctor1.prototype = $System_NotImplementedException.$ctor2.prototype = $System_NotImplementedException.prototype;
	ss.registerClass(global, 'MorseCode.CsJs.Common.FrameworkUtility', $MorseCode_CsJs_Common_FrameworkUtility);
	ss.registerInterface(global, 'MorseCode.CsJs.Common.ITimer', $MorseCode_CsJs_Common_ITimer);
	ss.registerInterface(global, 'MorseCode.CsJs.Common.ITimerFactory', $MorseCode_CsJs_Common_ITimerFactory);
	ss.registerClass(global, 'MorseCode.CsJs.Common.StringUtility', $MorseCode_CsJs_Common_StringUtility);
	ss.registerClass(global, 'MorseCode.CsJs.Common.TimerFactory', $MorseCode_CsJs_Common_TimerFactory);
	ss.registerClass(global, 'MorseCode.CsJs.Common.UnhandledEnumValueException', $MorseCode_CsJs_Common_UnhandledEnumValueException, ss.Exception);
	ss.registerClass(global, 'MorseCode.CsJs.Common.UnhandledEnumValueExceptionFactory', $MorseCode_CsJs_Common_UnhandledEnumValueExceptionFactory);
	ss.registerInterface(global, 'MorseCode.CsJs.Common.Observable.IObservable', $MorseCode_CsJs_Common_Observable_IObservable);
	ss.registerInterface(global, 'MorseCode.CsJs.Common.Property.IPropertyExpression', $MorseCode_CsJs_Common_Property_IPropertyExpression);
	ss.registerClass(global, 'System.InvalidOperationException', $System_InvalidOperationException, ss.Exception);
	ss.registerClass(global, 'System.NotImplementedException', $System_NotImplementedException, ss.Exception);
	$MorseCode_CsJs_Common_StringUtility.$keyString = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=';
	$MorseCode_CsJs_Common_TimerFactory.$_instance = null;
})();
