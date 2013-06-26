(function() {
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Net.SoapClient.SoapClientInvocator
	var $MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator = function(username, password, url, timeout, method, parameters, successCallback, errorCallback, wsdlErrorCallback) {
		this.$_username = null;
		this.$_password = null;
		this.$_url = null;
		this.$_timeout = ss.TimeSpan.getDefaultValue();
		this.$_method = null;
		this.$_parameters = null;
		this.$_successCallback = null;
		this.$_errorCallback = null;
		this.$_wsdlErrorCallback = null;
		this.$_username = username;
		this.$_password = password;
		this.$_url = url;
		this.$_timeout = timeout;
		this.$_method = method;
		this.$_parameters = parameters;
		this.$_successCallback = successCallback;
		this.$_errorCallback = errorCallback;
		this.$_wsdlErrorCallback = wsdlErrorCallback;
	};
	$MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.prototype = {
		$invoke: function() {
			var wsdl = {};
			if ($MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$wsdlByUrl.tryGetValue(this.$_url, wsdl)) {
				this.$invokeUsingWsdl(wsdl.$);
				return;
			}
			$.ajax(this.$_url + '?singleWsdl', { dataType: 'xml' }).then(ss.mkdel(this, function(data, textStatus, request) {
				this.$loadedWsdl(data);
			}), ss.mkdel(this, function(request1, textStatus1, error) {
				$.ajax(this.$_url + '?wsdl').then(ss.mkdel(this, function(data2, textStatus2, request2) {
					this.$loadedWsdl(data2);
				}), ss.mkdel(this, this.$failedWsdl));
			}));
		},
		$failedWsdl: function(request, textStatus, error) {
			this.$_wsdlErrorCallback(request, textStatus, error);
		},
		$loadedWsdl: function(data) {
			$MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$wsdlByUrl.set_item(this.$_url, data);
			this.$invokeUsingWsdl(data);
		},
		$invokeUsingWsdl: function(wsdl) {
			var targetNamespaceNode = wsdl.documentElement.attributes.getNamedItem('targetNamespace');
			var targetNamespace = (ss.isNullOrUndefined(targetNamespaceNode) ? '' : targetNamespaceNode.nodeValue);
			var soapRequest = '<?xml version="1.0" encoding="utf-8"?>\r\n<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">\r\n    <soap:Body>\r\n        <' + this.$_method + ' xmlns="' + targetNamespace + '">' + this.$getParametersXml(wsdl, targetNamespace) + '</' + this.$_method + '>\r\n    </soap:Body>\r\n</soap:Envelope>';
			var options = { dataType: 'xml' };
			var useCredentials = !ss.isNullOrEmptyString(this.$_username) && !ss.isNullOrEmptyString(this.$_password);
			if (useCredentials) {
				options.username = this.$_username;
				options.password = this.$_password;
			}
			options.beforeSend = ss.mkdel(this, function(request) {
				if (useCredentials) {
					request.setRequestHeader('Authorization', 'Basic ' + MorseCode.CsJs.Common.StringUtility.toBase64$1(this.$_username + ':' + this.$_password));
				}
				var soapAction = this.$findSoapAction(wsdl, targetNamespace);
				request.setRequestHeader('SOAPAction', soapAction);
				request.setRequestHeader('Content-Type', 'text/xml; charset=utf-8');
			});
			options.timeout = ss.Int32.trunc(this.$_timeout.ticks / 10000);
			options.type = 'POST';
			options.data = soapRequest;
			$.ajax(this.$_url, options).then(ss.mkdel(this, function(data, textStatus, request1) {
				this.$_successCallback(this.$getReturnValue(wsdl, data), textStatus, request1);
			}), this.$_errorCallback);
		},
		$getNamespaceResolver: function(targetNamespace) {
			return function(prefix) {
				if (prefix === 'xs') {
					return 'http://www.w3.org/2001/XMLSchema';
				}
				if (prefix === 'wsdl') {
					return 'http://schemas.xmlsoap.org/wsdl/';
				}
				if (prefix === 'soap') {
					return 'http://schemas.xmlsoap.org/wsdl/soap/';
				}
				if (prefix === 's') {
					return 'http://schemas.xmlsoap.org/soap/envelope/';
				}
				if (prefix === 'tns') {
					return targetNamespace;
				}
				return null;
			};
		},
		$findSoapAction: function(wsdl, targetNamespace) {
			var path = './/wsdl:binding/wsdl:operation[@name=\'' + this.$_method + '\']/soap:operation/@soapAction';
			var nodes = MorseCode.CsJs.Xml.XPath.XPath.evaluate$3(wsdl, path, this.$getNamespaceResolver(targetNamespace));
			return ((ss.isNullOrUndefined(nodes) || nodes.length < 1) ? '' : nodes[0].nodeValue);
		},
		$getParametersXml: function(wsdl, targetNamespace) {
			var messageName = MorseCode.CsJs.Xml.XPath.XPath.evaluate$3(wsdl, './/wsdl:portType/wsdl:operation[@name=\'' + this.$_method + '\']/wsdl:input/@message', this.$getNamespaceResolver(targetNamespace))[0].nodeValue;
			if (messageName.indexOf(':') !== -1) {
				messageName = messageName.substring(messageName.indexOf(String.fromCharCode(58)) + 1);
			}
			var parametersElementFullName = MorseCode.CsJs.Xml.XPath.XPath.evaluate$3(wsdl, './/wsdl:message[@name=\'' + messageName + '\']/wsdl:part[@name=\'parameters\']/@element', this.$getNamespaceResolver(targetNamespace))[0].nodeValue;
			var parametersElementNameParts = parametersElementFullName.split(String.fromCharCode(58));
			var parametersElementNamespace;
			var parametersElementName;
			if (parametersElementNameParts.length === 2) {
				parametersElementNamespace = MorseCode.CsJs.Xml.XPath.XPath.evaluate$3(wsdl, './/wsdl:definitions/@xmlns:' + parametersElementNameParts[0], this.$getNamespaceResolver(null))[0].nodeValue;
				parametersElementName = parametersElementNameParts[1];
			}
			else {
				parametersElementNamespace = MorseCode.CsJs.Xml.XPath.XPath.evaluate$3(wsdl, './/wsdl:definitions/@targetNamespace', this.$getNamespaceResolver(null))[0].nodeValue;
				parametersElementName = parametersElementNameParts[0];
			}
			var elementDefinition = MorseCode.CsJs.Xml.Schema.XmlSchemaParser.getElementDefinition(wsdl, parametersElementNamespace, parametersElementName);
			var xml = '';
			var $t1 = ss.cast(elementDefinition.get_type(), MorseCode.CsJs.Xml.Schema.XmlSchemaComplexTypeDefinition).get_elements();
			for (var $t2 = 0; $t2 < $t1.length; $t2++) {
				var childElementDefinition = $t1[$t2];
				xml += this.$getObjectXmlRecursive(childElementDefinition, this.$_parameters.get_item(childElementDefinition.get_name()), false);
			}
			return xml;
		},
		$getObjectXmlRecursive: function(elementDefinition, value, ignoreArray) {
			if (ss.isNullOrUndefined(value)) {
				return '<' + elementDefinition.get_name() + (ss.isNullOrUndefined(elementDefinition.get_elementNamespace()) ? '' : (' xmlns="' + elementDefinition.get_elementNamespace() + '"')) + ' i:nil="true" xmlns:i="http://www.w3.org/2001/XMLSchema-instance" />';
			}
			var xml = '';
			var simpleTypeDefinition = ss.safeCast(elementDefinition.get_type(), MorseCode.CsJs.Xml.Schema.IXmlSchemaSimpleTypeDefinition);
			if (ss.isValue(simpleTypeDefinition)) {
				switch (simpleTypeDefinition.get_type()) {
					case 0: {
						xml += $MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$encodeString(value.toString());
						break;
					}
					case 1:
					case 20:
					case 11:
					case 13:
					case 21: {
						$MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$ensureScriptType(elementDefinition.get_name(), value, 'string');
						xml += $MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$encodeString(value);
						break;
					}
					case 2: {
						var scriptType = typeof(value);
						if (scriptType === 'string') {
							xml += MorseCode.CsJs.Common.StringUtility.toBase64$1(value);
						}
						else {
							$MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$ensureJsType(elementDefinition.get_name(), value, 'Array');
							xml += MorseCode.CsJs.Common.StringUtility.toBase64(value);
						}
						break;
					}
					case 3: {
						$MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$ensureScriptType(elementDefinition.get_name(), value, 'boolean');
						xml += value.toString();
						break;
					}
					case 18: {
						$MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$ensureScriptType(elementDefinition.get_name(), value, 'number');
						xml += $MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$encodeString(String.fromCharCode(value));
						break;
					}
					case 4:
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					case 12:
					case 14:
					case 15:
					case 16:
					case 17: {
						$MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$ensureScriptType(elementDefinition.get_name(), value, 'number');
						xml += value.toString();
						break;
					}
					case 5: {
						if (!ss.isInstanceOfType(value, Date)) {
							$MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$throwTypeException(elementDefinition.get_name(), value, Date);
						}
						var year = value.getFullYear().toString();
						var month = ss.padLeftString((value.getMonth() + 1 + 1).toString(), 2, 48);
						var date = ss.padLeftString(value.getDate().toString(), 2, 48);
						var hours = ss.padLeftString(value.getHours().toString(), 2, 48);
						var minutes = ss.padLeftString(value.getMinutes().toString(), 2, 48);
						var seconds = ss.padLeftString(value.getSeconds().toString(), 2, 48);
						var milliseconds = value.getMilliseconds().toString();
						var timezoneOffsetTotalMinutes = value.getTimezoneOffset();
						var timezoneOffsetTotalMinutesAbs = Math.abs(timezoneOffsetTotalMinutes);
						var timezoneOffsetHours = ss.Int32.div(timezoneOffsetTotalMinutesAbs, 60);
						var timezoneOffsetMinutes = timezoneOffsetTotalMinutesAbs % 60;
						var timezone = ((timezoneOffsetTotalMinutes < 0) ? '+' : '-') + ss.padLeftString(timezoneOffsetHours.toString(), 2, 48) + ':' + ss.padLeftString(timezoneOffsetMinutes.toString(), 2, 48);
						xml += year + '-' + month + '-' + date + 'T' + hours + ':' + minutes + ':' + seconds + '.' + milliseconds + timezone;
						break;
					}
					case 19: {
						if (!ss.isInstanceOfType(value, ss.TimeSpan)) {
							$MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$throwTypeException(elementDefinition.get_name(), value, ss.TimeSpan);
						}
						var ts = value;
						var durationIsNegative = ts.ticks < 0;
						var durationDays = Math.abs(ts.ticks / 864000000000 | 0);
						var durationHours = Math.abs(ts.ticks / 36000000000 % 24 | 0);
						var durationMinutes = Math.abs(ts.ticks / 600000000 % 60 | 0);
						var durationSeconds = Math.abs(ts.ticks / 10000000 % 60 | 0);
						var durationMilliseconds = Math.abs(ts.ticks / 10000 % 1000 | 0);
						xml += (durationIsNegative ? '-' : '') + durationDays + 'DT' + durationHours + 'H' + durationMinutes + 'M' + durationSeconds + '.' + ss.padLeftString(durationMilliseconds.toString(), 3, 48) + 'S';
						break;
					}
					default: {
						throw MorseCode.CsJs.Common.UnhandledEnumValueExceptionFactory.create(MorseCode.CsJs.Xml.Schema.XmlBuiltInSimpleType).call(null, simpleTypeDefinition.get_type());
					}
				}
			}
			else {
				var complexTypeDefinition = ss.safeCast(elementDefinition.get_type(), MorseCode.CsJs.Xml.Schema.IXmlSchemaComplexTypeDefinition);
				if (ss.isNullOrUndefined(complexTypeDefinition)) {
					throw new ss.NotSupportedException('Unknown type for element definition: ' + ss.getTypeFullName(ss.getInstanceType(elementDefinition)));
				}
				var isArrayContainer = this.$isArrayContainer(complexTypeDefinition);
				if (!ignoreArray && (isArrayContainer || elementDefinition.get_isArray())) {
					if (!ss.isInstanceOfType(value, ss.IEnumerable)) {
						$MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$throwTypeException(elementDefinition.get_name(), value, ss.IEnumerable);
					}
					var arrayElementDefinition;
					if (isArrayContainer) {
						xml += '<' + elementDefinition.get_name() + (ss.isNullOrUndefined(elementDefinition.get_elementNamespace()) ? '' : (' xmlns="' + elementDefinition.get_elementNamespace() + '"')) + '>';
						arrayElementDefinition = complexTypeDefinition.get_elements()[0];
					}
					else {
						arrayElementDefinition = elementDefinition;
					}
					for (var $t1 = 0; $t1 < value.length; $t1++) {
						var item = value[$t1];
						xml += this.$getObjectXmlRecursive(arrayElementDefinition, item, true);
					}
					if (isArrayContainer) {
						xml += '</' + elementDefinition.get_name() + '>';
					}
					return xml;
				}
				else {
					var $t2 = complexTypeDefinition.get_elements();
					for (var $t3 = 0; $t3 < $t2.length; $t3++) {
						var childElementDefinition = $t2[$t3];
						xml += this.$getObjectXmlRecursive(childElementDefinition, value[childElementDefinition.get_name()], false);
					}
				}
			}
			return '<' + elementDefinition.get_name() + (ss.isNullOrUndefined(elementDefinition.get_elementNamespace()) ? '' : (' xmlns="' + elementDefinition.get_elementNamespace() + '"')) + '>' + xml + '</' + elementDefinition.get_name() + '>';
		},
		$isArrayContainer: function(complexElementDefinition) {
			return complexElementDefinition.get_elements().length === 1 && complexElementDefinition.get_elements()[0].get_isArray();
		},
		$getReturnValue: function(wsdl, data) {
			var messageName = MorseCode.CsJs.Xml.XPath.XPath.evaluate$3(wsdl, './/wsdl:portType/wsdl:operation[@name=\'' + this.$_method + '\']/wsdl:output/@message', this.$getNamespaceResolver(null))[0].nodeValue;
			if (messageName.indexOf(':') !== -1) {
				messageName = messageName.substring(messageName.indexOf(String.fromCharCode(58)) + 1);
			}
			var parametersElementFullName = MorseCode.CsJs.Xml.XPath.XPath.evaluate$3(wsdl, './/wsdl:message[@name=\'' + messageName + '\']/wsdl:part[@name=\'parameters\']/@element', this.$getNamespaceResolver(null))[0].nodeValue;
			var parametersElementNameParts = parametersElementFullName.split(String.fromCharCode(58));
			var parametersElementNamespace;
			var parametersElementName;
			if (parametersElementNameParts.length === 2) {
				parametersElementNamespace = MorseCode.CsJs.Xml.XPath.XPath.evaluate$3(wsdl, './/wsdl:definitions/@xmlns:' + parametersElementNameParts[0], this.$getNamespaceResolver(null))[0].nodeValue;
				parametersElementName = parametersElementNameParts[1];
			}
			else {
				parametersElementNamespace = MorseCode.CsJs.Xml.XPath.XPath.evaluate$3(wsdl, './/wsdl:definitions/@targetNamespace', this.$getNamespaceResolver(null))[0].nodeValue;
				parametersElementName = parametersElementNameParts[0];
			}
			var elementDefinition = MorseCode.CsJs.Xml.Schema.XmlSchemaParser.getElementDefinition(wsdl, parametersElementNamespace, parametersElementName);
			var resultType = ss.cast(elementDefinition.get_type(), MorseCode.CsJs.Xml.Schema.IXmlSchemaComplexTypeDefinition);
			var bodyNode = MorseCode.CsJs.Xml.XPath.XPath.evaluate$3(data, './s:Envelope/s:Body', this.$getNamespaceResolver(null))[0];
			return this.$getObjectRecursive(resultType.get_elements()[0], bodyNode.childNodes[0]);
		},
		$getObjectRecursive: function(elementDefinition, parentNode) {
			var childNodes;
			var complexTypeDefinition = ss.safeCast(elementDefinition.get_type(), MorseCode.CsJs.Xml.Schema.IXmlSchemaComplexTypeDefinition);
			var isArrayContainer = ss.isValue(complexTypeDefinition) && this.$isArrayContainer(complexTypeDefinition);
			if (isArrayContainer || elementDefinition.get_isArray()) {
				var arrayElementDefinition = (isArrayContainer ? complexTypeDefinition.get_elements()[0] : elementDefinition);
				childNodes = MorseCode.CsJs.Xml.XPath.XPath.evaluate$3(parentNode, './' + (isArrayContainer ? ((ss.isNullOrUndefined(elementDefinition.get_elementNamespace()) ? '' : 'tns1:') + elementDefinition.get_name() + '/') : '') + (ss.isNullOrUndefined(arrayElementDefinition.get_elementNamespace()) ? '' : 'tns2:') + arrayElementDefinition.get_name(), function(prefix) {
					return ((prefix === 'tns1') ? elementDefinition.get_elementNamespace() : ((prefix === 'tns2') ? arrayElementDefinition.get_elementNamespace() : ''));
				});
				var values = [];
				for (var i = 0; i < childNodes.length; i++) {
					ss.add(values, this.$getObjectValue(arrayElementDefinition, childNodes[i]));
				}
				return values;
			}
			childNodes = MorseCode.CsJs.Xml.XPath.XPath.evaluate$3(parentNode, './' + (ss.isNullOrUndefined(elementDefinition.get_elementNamespace()) ? '' : 'tns:') + elementDefinition.get_name(), function(prefix1) {
				return ((prefix1 === 'tns') ? elementDefinition.get_elementNamespace() : '');
			});
			return ((childNodes.length !== 1) ? null : this.$getObjectValue(elementDefinition, childNodes[0]));
		},
		$getObjectValue: function(elementDefinition, node) {
			var nilNodes = MorseCode.CsJs.Xml.XPath.XPath.evaluate$3(node, './@i:nil', function(prefix) {
				return ((prefix === 'i') ? 'http://www.w3.org/2001/XMLSchema-instance' : null);
			});
			if (nilNodes.length === 1 && (nilNodes[0].nodeValue === 'true' || nilNodes[0].nodeValue === '1')) {
				return null;
			}
			var simpleTypeDefinition = ss.safeCast(elementDefinition.get_type(), MorseCode.CsJs.Xml.Schema.IXmlSchemaSimpleTypeDefinition);
			if (ss.isValue(simpleTypeDefinition)) {
				if (node.childNodes.length !== 1 || node.childNodes[0].nodeType !== 3) {
					throw new System.InvalidOperationException.$ctor1('Expected text node as child for element ' + elementDefinition.get_name() + '.');
				}
				var text = node.childNodes[0].nodeValue;
				switch (simpleTypeDefinition.get_type()) {
					case 0:
					case 1:
					case 20:
					case 11:
					case 13:
					case 21: {
						return $MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$decodeString(text);
					}
					case 2: {
						return MorseCode.CsJs.Common.StringUtility.fromBase64ToByteArray(text);
					}
					case 3: {
						return text === 'true' || text === '1';
					}
					case 4: {
						return MorseCode.CsJs.Common.FrameworkUtility.byteTryParse(text);
					}
					case 18: {
						return $MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$decodeString(text).charCodeAt(0);
					}
					case 6: {
						return MorseCode.CsJs.Common.FrameworkUtility.decimalTryParse(text);
					}
					case 7: {
						return MorseCode.CsJs.Common.FrameworkUtility.doubleTryParse(text);
					}
					case 8: {
						return MorseCode.CsJs.Common.FrameworkUtility.floatTryParse(text);
					}
					case 9: {
						return MorseCode.CsJs.Common.FrameworkUtility.intTryParse(text);
					}
					case 10: {
						return MorseCode.CsJs.Common.FrameworkUtility.longTryParse(text);
					}
					case 12: {
						return MorseCode.CsJs.Common.FrameworkUtility.shortTryParse(text);
					}
					case 14: {
						return MorseCode.CsJs.Common.FrameworkUtility.byteTryParse(text);
					}
					case 15: {
						return MorseCode.CsJs.Common.FrameworkUtility.intTryParse(text);
					}
					case 16: {
						return MorseCode.CsJs.Common.FrameworkUtility.longTryParse(text);
					}
					case 17: {
						return MorseCode.CsJs.Common.FrameworkUtility.shortTryParse(text);
					}
					case 5: {
						var bits = text.split(new RegExp('[-T:+]', 'g'));
						var timeZoneStart;
						var milliseconds;
						if (bits.length === 9) {
							timeZoneStart = 7;
							milliseconds = ss.coalesce(MorseCode.CsJs.Common.FrameworkUtility.intTryParse(bits[6]), 0);
						}
						else {
							timeZoneStart = 6;
							milliseconds = 0;
						}
						var dateTime = new Date(parseInt(bits[0]), parseInt(bits[1]) - 1, parseInt(bits[2]), parseInt(bits[3]), parseInt(bits[4]), parseInt(bits[5]), milliseconds);
						var offsetMinutes = parseInt(bits[timeZoneStart]) * 60 + parseInt(bits[timeZoneStart + 1]);
						var offsetIsNegative = (new RegExp('-\\d\\d:\\d\\d$')).test(text);
						if (offsetIsNegative) {
							offsetMinutes *= -1;
						}
						dateTime.setMinutes(dateTime.getMinutes() - offsetMinutes - dateTime.getTimezoneOffset());
						return new Date(dateTime.valueOf());
					}
					case 19: {
						var regex = new RegExp('([-+]?)P(([0-9]*)Y)?(([0-9]*)M)?(([0-9]*)D)?(T(([0-9]*)H)?(([0-9]*)M)?(([0-9.]*)S)?)?');
						var match = regex.exec(text);
						var durationIsNegative = match[1] === '-';
						var durationYears = (ss.isNullOrUndefined(match[3]) ? 0 : ss.coalesce(MorseCode.CsJs.Common.FrameworkUtility.intTryParse(match[3]), 0));
						var durationMonths = (ss.isNullOrUndefined(match[5]) ? 0 : ss.coalesce(MorseCode.CsJs.Common.FrameworkUtility.intTryParse(match[5]), 0));
						if (durationYears !== 0 || durationMonths !== 0) {
							throw new System.InvalidOperationException.$ctor1('Durations may not contain years or months.');
						}
						var durationDays = (ss.isNullOrUndefined(match[7]) ? 0 : ss.coalesce(MorseCode.CsJs.Common.FrameworkUtility.intTryParse(match[7]), 0));
						var durationHours = (ss.isNullOrUndefined(match[10]) ? 0 : ss.coalesce(MorseCode.CsJs.Common.FrameworkUtility.intTryParse(match[10]), 0));
						var durationMinutes = (ss.isNullOrUndefined(match[12]) ? 0 : ss.coalesce(MorseCode.CsJs.Common.FrameworkUtility.intTryParse(match[12]), 0));
						var durationFractionalSeconds = (ss.isNullOrUndefined(match[14]) ? 0 : ss.coalesce(MorseCode.CsJs.Common.FrameworkUtility.doubleTryParse(match[14]), 0));
						var durationSeconds = durationFractionalSeconds | 0;
						var durationMilliseconds = (durationFractionalSeconds * 1000 | 0) % 1000;
						if (durationIsNegative) {
							durationDays *= -1;
							durationHours *= -1;
							durationMinutes *= -1;
							durationSeconds *= -1;
							durationMilliseconds *= -1;
						}
						return ss.TimeSpan.fromValues(durationDays, durationHours, durationMinutes, durationSeconds, durationMilliseconds);
					}
					default: {
						throw MorseCode.CsJs.Common.UnhandledEnumValueExceptionFactory.create(MorseCode.CsJs.Xml.Schema.XmlBuiltInSimpleType).call(null, simpleTypeDefinition.get_type());
					}
				}
			}
			var complexTypeDefinition = ss.safeCast(elementDefinition.get_type(), MorseCode.CsJs.Xml.Schema.IXmlSchemaComplexTypeDefinition);
			if (ss.isNullOrUndefined(complexTypeDefinition)) {
				throw new System.InvalidOperationException.$ctor1('Unknown element type.');
			}
			var d = {};
			var $t1 = complexTypeDefinition.get_elements();
			for (var $t2 = 0; $t2 < $t1.length; $t2++) {
				var childElementDefinition = $t1[$t2];
				d[childElementDefinition.get_name()] = this.$getObjectRecursive(childElementDefinition, node);
			}
			return d;
		}
	};
	$MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$ensureScriptType = function(elementName, value, expectedType) {
		var scriptType = typeof(value);
		if (!ss.referenceEquals(scriptType, expectedType)) {
			throw new System.InvalidOperationException.$ctor1('Expected ' + expectedType + ' for element ' + elementName + ', but encountered ' + scriptType + '.');
		}
	};
	$MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$ensureJsType = function(elementName, value, expectedType) {
		var jsType = Object.prototype.toString.call(value).match(new RegExp('\\s([a-zA-Z]+)'))[1];
		if (!ss.referenceEquals(jsType, expectedType)) {
			throw new System.InvalidOperationException.$ctor1('Expected type ' + expectedType + ' for element ' + elementName + ', but encountered ' + jsType + '.');
		}
	};
	$MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$throwTypeException = function(elementName, value, expectedType) {
		throw new System.InvalidOperationException.$ctor1('Expected class type ' + ss.getTypeFullName(expectedType) + ' for element ' + elementName + ', but encountered ' + ss.getTypeFullName(ss.getInstanceType(value)) + '.');
	};
	$MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$encodeString = function(s) {
		return (ss.isNullOrUndefined(s) ? null : s.replace(new RegExp('&', 'g'), '&amp;').replace(new RegExp('<', 'g'), '&lt;').replace(new RegExp('>', 'g'), '&gt;'));
	};
	$MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$decodeString = function(s) {
		return (ss.isNullOrUndefined(s) ? null : s.replace(new RegExp('&amp;', 'g'), '&').replace(new RegExp('&lt;', 'g'), '<').replace(new RegExp('&gt;', 'g'), '>'));
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Net.jQueryAjaxOptionsUtility
	var $MorseCode_CsJs_Net_jQueryAjaxOptionsUtility = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Net.jQueryXmlHttpRequestExtensionMethods
	var $MorseCode_CsJs_Net_jQueryXmlHttpRequestExtensionMethods = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Net.SoapClient
	var $MorseCode_CsJs_Net_SoapClient = function() {
		this.$_username = null;
		this.$_password = null;
		this.$_url = null;
		this.$_timeout = ss.TimeSpan.fromValues(0, 0, 1, 0, 0);
	};
	$MorseCode_CsJs_Net_SoapClient.prototype = {
		invoke: function(method, parameters, successCallback, errorCallback) {
			this.invoke$2(method, parameters, successCallback, errorCallback, errorCallback);
		},
		invoke$2: function(method, parameters, successCallback, errorCallback, wsdlErrorCallback) {
			this.invoke$3(method, parameters, function(data, textStatus, request) {
				successCallback(data);
			}, errorCallback, wsdlErrorCallback);
		},
		invoke$1: function(method, parameters, successCallback, errorCallback) {
			this.invoke$3(method, parameters, successCallback, errorCallback, errorCallback);
		},
		invoke$3: function(method, parameters, successCallback, errorCallback, wsdlErrorCallback) {
			(new $MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator(this.$_username, this.$_password, this.$_url, this.$_timeout, method, parameters, successCallback, errorCallback, wsdlErrorCallback)).$invoke();
		},
		get_username: function() {
			return this.$_username;
		},
		set_username: function(value) {
			this.$_username = value;
		},
		get_password: function() {
			return this.$_password;
		},
		set_password: function(value) {
			this.$_password = value;
		},
		get_url: function() {
			return this.$_url;
		},
		set_url: function(value) {
			this.$_url = value;
		},
		get_timeout: function() {
			return this.$_timeout;
		},
		set_timeout: function(value) {
			this.$_timeout = value;
		}
	};
	ss.registerClass(null, 'MorseCode.$CsJs.Net.SoapClient$SoapClientInvocator', $MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator);
	ss.registerClass(global, 'MorseCode.CsJs.Net.jQueryAjaxOptionsUtility', $MorseCode_CsJs_Net_jQueryAjaxOptionsUtility);
	ss.registerClass(global, 'MorseCode.CsJs.Net.jQueryXmlHttpRequestExtensionMethods', $MorseCode_CsJs_Net_jQueryXmlHttpRequestExtensionMethods);
	ss.registerClass(global, 'MorseCode.CsJs.Net.SoapClient', $MorseCode_CsJs_Net_SoapClient);
	$MorseCode_$CsJs_Net_SoapClient$SoapClientInvocator.$wsdlByUrl = new (ss.makeGenericType(ss.Dictionary$2, [String, Object]))();
})();
