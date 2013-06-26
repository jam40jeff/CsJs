(function() {
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.Schema.XmlSchemaParser.TypeReference
	var $MorseCode_$CsJs_Xml_Schema_XmlSchemaParser$TypeReference = function(namespace1, name) {
		this.$_namespace = null;
		this.$_name = null;
		this.$_namespace = namespace1;
		this.$_name = name;
	};
	$MorseCode_$CsJs_Xml_Schema_XmlSchemaParser$TypeReference.prototype = {
		get_$name: function() {
			return this.$_name;
		},
		$equals: function(other) {
			return ss.equalsT(this.$_namespace, other.$_namespace) && ss.equalsT(this.$_name, other.$_name);
		},
		equals: function(obj) {
			if (ss.referenceEquals(null, obj)) {
				return false;
			}
			if (ss.referenceEquals(this, obj)) {
				return true;
			}
			if (!ss.referenceEquals(ss.getInstanceType(obj), ss.getInstanceType(this))) {
				return false;
			}
			return this.$equals(ss.cast(obj, $MorseCode_$CsJs_Xml_Schema_XmlSchemaParser$TypeReference));
		},
		getHashCode: function() {
			return (ss.isValue(this.$_namespace) ? ss.getHashCode(this.$_namespace) : 0) * 397 ^ (ss.isValue(this.$_name) ? ss.getHashCode(this.$_name) : 0);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.XmlExtensionMethods
	var $MorseCode_CsJs_Xml_XmlExtensionMethods = function() {
	};
	$MorseCode_CsJs_Xml_XmlExtensionMethods.isXmlAttribute = function(node) {
		return ss.isValue(node) && node.nodeType === 2;
	};
	$MorseCode_CsJs_Xml_XmlExtensionMethods.isXmlText = function(node) {
		return ss.isValue(node) && (node.nodeType === 3 || node.nodeType === 4);
	};
	$MorseCode_CsJs_Xml_XmlExtensionMethods.isXmlDocument = function(node) {
		return ss.isValue(node) && node.nodeType === 9;
	};
	$MorseCode_CsJs_Xml_XmlExtensionMethods.asXmlAttribute = function(node) {
		return ($MorseCode_CsJs_Xml_XmlExtensionMethods.isXmlAttribute(node) ? node : null);
	};
	$MorseCode_CsJs_Xml_XmlExtensionMethods.asXmlText = function(node) {
		return ($MorseCode_CsJs_Xml_XmlExtensionMethods.isXmlText(node) ? node : null);
	};
	$MorseCode_CsJs_Xml_XmlExtensionMethods.asXmlDocument = function(node) {
		return ($MorseCode_CsJs_Xml_XmlExtensionMethods.isXmlDocument(node) ? node : null);
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.Schema.IXmlSchemaAttributeDefinition
	var $MorseCode_CsJs_Xml_Schema_IXmlSchemaAttributeDefinition = function() {
	};
	$MorseCode_CsJs_Xml_Schema_IXmlSchemaAttributeDefinition.prototype = { get_attributeNamespace: null, set_attributeNamespace: null, get_name: null, set_name: null, get_isNullable: null, set_isNullable: null, get_type: null, set_type: null };
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.Schema.IXmlSchemaComplexTypeDefinition
	var $MorseCode_CsJs_Xml_Schema_IXmlSchemaComplexTypeDefinition = function() {
	};
	$MorseCode_CsJs_Xml_Schema_IXmlSchemaComplexTypeDefinition.prototype = { get_typeName: null, set_typeName: null, get_attributes: null, get_elements: null };
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.Schema.IXmlSchemaElementDefinition
	var $MorseCode_CsJs_Xml_Schema_IXmlSchemaElementDefinition = function() {
	};
	$MorseCode_CsJs_Xml_Schema_IXmlSchemaElementDefinition.prototype = { get_elementNamespace: null, set_elementNamespace: null, get_name: null, set_name: null, get_isArray: null, set_isArray: null, get_isNullable: null, set_isNullable: null, get_type: null, set_type: null };
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.Schema.IXmlSchemaSimpleTypeDefinition
	var $MorseCode_CsJs_Xml_Schema_IXmlSchemaSimpleTypeDefinition = function() {
	};
	$MorseCode_CsJs_Xml_Schema_IXmlSchemaSimpleTypeDefinition.prototype = { get_type: null };
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.Schema.IXmlSchemaTypeDefinition
	var $MorseCode_CsJs_Xml_Schema_IXmlSchemaTypeDefinition = function() {
	};
	$MorseCode_CsJs_Xml_Schema_IXmlSchemaTypeDefinition.prototype = { get_typeNamespace: null, set_typeNamespace: null, getTypeName: null };
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.Schema.XmlBuiltInSimpleType
	var $MorseCode_CsJs_Xml_Schema_XmlBuiltInSimpleType = function() {
	};
	$MorseCode_CsJs_Xml_Schema_XmlBuiltInSimpleType.prototype = { anyType: 0, anyUri: 1, base64Binary: 2, boolean$1: 3, byte$1: 4, dateTime: 5, decimal: 6, double$1: 7, float$1: 8, int$1: 9, long$1: 10, qName: 11, short$1: 12, string: 13, unsignedByte: 14, unsignedInt: 15, unsignedLong: 16, unsignedShort: 17, char$1: 18, duration: 19, guid: 20, enum$1: 21 };
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.Schema.XmlSchemaAttributeDefinition
	var $MorseCode_CsJs_Xml_Schema_XmlSchemaAttributeDefinition = function() {
		this.$1$AttributeNamespaceField = null;
		this.$1$NameField = null;
		this.$1$IsNullableField = false;
		this.$1$TypeField = null;
	};
	$MorseCode_CsJs_Xml_Schema_XmlSchemaAttributeDefinition.prototype = {
		get_attributeNamespace: function() {
			return this.$1$AttributeNamespaceField;
		},
		set_attributeNamespace: function(value) {
			this.$1$AttributeNamespaceField = value;
		},
		get_name: function() {
			return this.$1$NameField;
		},
		set_name: function(value) {
			this.$1$NameField = value;
		},
		get_isNullable: function() {
			return this.$1$IsNullableField;
		},
		set_isNullable: function(value) {
			this.$1$IsNullableField = value;
		},
		get_type: function() {
			return this.$1$TypeField;
		},
		set_type: function(value) {
			this.$1$TypeField = value;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.Schema.XmlSchemaBuiltInSimpleTypeDefinition
	var $MorseCode_CsJs_Xml_Schema_XmlSchemaBuiltInSimpleTypeDefinition = function() {
		this.$2$TypeNameField = null;
		this.$2$TypeField = 0;
		$MorseCode_CsJs_Xml_Schema_XmlSchemaTypeDefinition.call(this);
	};
	$MorseCode_CsJs_Xml_Schema_XmlSchemaBuiltInSimpleTypeDefinition.prototype = {
		get_typeName: function() {
			return this.$2$TypeNameField;
		},
		set_typeName: function(value) {
			this.$2$TypeNameField = value;
		},
		get_type: function() {
			return this.$2$TypeField;
		},
		set_type: function(value) {
			this.$2$TypeField = value;
		},
		getTypeName: function() {
			return this.get_typeName();
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.Schema.XmlSchemaComplexTypeDefinition
	var $MorseCode_CsJs_Xml_Schema_XmlSchemaComplexTypeDefinition = function() {
		this.$_attributes = [];
		this.$_elements = [];
		this.$2$TypeNameField = null;
		$MorseCode_CsJs_Xml_Schema_XmlSchemaTypeDefinition.call(this);
	};
	$MorseCode_CsJs_Xml_Schema_XmlSchemaComplexTypeDefinition.prototype = {
		get_typeName: function() {
			return this.$2$TypeNameField;
		},
		set_typeName: function(value) {
			this.$2$TypeNameField = value;
		},
		getTypeName: function() {
			return this.get_typeName();
		},
		get_attributes: function() {
			return this.$_attributes;
		},
		get_elements: function() {
			return this.$_elements;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.Schema.XmlSchemaConstants
	var $MorseCode_CsJs_Xml_Schema_XmlSchemaConstants = function() {
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.Schema.XmlSchemaCustomSimpleTypeDefinition
	var $MorseCode_CsJs_Xml_Schema_XmlSchemaCustomSimpleTypeDefinition = function() {
		this.$2$TypeNameField = null;
		this.$2$BaseTypeField = 0;
		$MorseCode_CsJs_Xml_Schema_XmlSchemaTypeDefinition.call(this);
	};
	$MorseCode_CsJs_Xml_Schema_XmlSchemaCustomSimpleTypeDefinition.prototype = {
		get_typeName: function() {
			return this.$2$TypeNameField;
		},
		set_typeName: function(value) {
			this.$2$TypeNameField = value;
		},
		get_baseType: function() {
			return this.$2$BaseTypeField;
		},
		set_baseType: function(value) {
			this.$2$BaseTypeField = value;
		},
		get_type: function() {
			return this.get_baseType();
		},
		getTypeName: function() {
			return this.get_typeName();
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.Schema.XmlSchemaElementDefinition
	var $MorseCode_CsJs_Xml_Schema_XmlSchemaElementDefinition = function() {
		this.$1$ElementNamespaceField = null;
		this.$1$NameField = null;
		this.$1$IsArrayField = false;
		this.$1$IsNullableField = false;
		this.$1$TypeField = null;
	};
	$MorseCode_CsJs_Xml_Schema_XmlSchemaElementDefinition.prototype = {
		get_elementNamespace: function() {
			return this.$1$ElementNamespaceField;
		},
		set_elementNamespace: function(value) {
			this.$1$ElementNamespaceField = value;
		},
		get_name: function() {
			return this.$1$NameField;
		},
		set_name: function(value) {
			this.$1$NameField = value;
		},
		get_isArray: function() {
			return this.$1$IsArrayField;
		},
		set_isArray: function(value) {
			this.$1$IsArrayField = value;
		},
		get_isNullable: function() {
			return this.$1$IsNullableField;
		},
		set_isNullable: function(value) {
			this.$1$IsNullableField = value;
		},
		get_type: function() {
			return this.$1$TypeField;
		},
		set_type: function(value) {
			this.$1$TypeField = value;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.Schema.XmlSchemaEnumSimpleTypeDefinition
	var $MorseCode_CsJs_Xml_Schema_XmlSchemaEnumSimpleTypeDefinition = function() {
		this.$_enumValues = [];
		this.$2$TypeNameField = null;
		$MorseCode_CsJs_Xml_Schema_XmlSchemaTypeDefinition.call(this);
	};
	$MorseCode_CsJs_Xml_Schema_XmlSchemaEnumSimpleTypeDefinition.prototype = {
		get_typeName: function() {
			return this.$2$TypeNameField;
		},
		set_typeName: function(value) {
			this.$2$TypeNameField = value;
		},
		get_enumValues: function() {
			return this.$_enumValues;
		},
		get_type: function() {
			return 21;
		},
		getTypeName: function() {
			return this.get_typeName();
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.Schema.XmlSchemaParser
	var $MorseCode_CsJs_Xml_Schema_XmlSchemaParser = function() {
	};
	$MorseCode_CsJs_Xml_Schema_XmlSchemaParser.getElementDefinition = function(document, targetNamespace, elementName) {
		var schemaNodes = $MorseCode_CsJs_Xml_XPath_XPath.evaluate$3(document, './/xs:schema[@targetNamespace=\'' + targetNamespace + '\']', $MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$resolveNamespace);
		var schemaNode = schemaNodes[0];
		var elementNodes = $MorseCode_CsJs_Xml_XPath_XPath.evaluate$3(schemaNode, './xs:element[@name=\'' + elementName + '\']', $MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$resolveNamespace);
		if (elementNodes.length !== 1) {
			throw new System.InvalidOperationException.$ctor1('Could not find element definition for element ' + elementName + '.');
		}
		return $MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$getElementDefinitionRecursive(document.documentElement, schemaNode, elementNodes[0], new (ss.makeGenericType(ss.Dictionary$2, [$MorseCode_$CsJs_Xml_Schema_XmlSchemaParser$TypeReference, $MorseCode_CsJs_Xml_Schema_IXmlSchemaTypeDefinition]))());
	};
	$MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$getElementDefinitionRecursive = function(document, schemaNode, elementNode, typesByName) {
		var elementDefinition = new $MorseCode_CsJs_Xml_Schema_XmlSchemaElementDefinition();
		var elementName = elementNode.attributes.getNamedItem('name').nodeValue;
		var typeAttribute = elementNode.attributes.getNamedItem('type');
		var complexTypeNode = null;
		var simpleTypeNode = null;
		var rawTypeName = null;
		var typeSchemaNode = {};
		var existingType = null;
		var addTypeByName = null;
		if (ss.isValue(typeAttribute)) {
			rawTypeName = typeAttribute.nodeValue;
			var typeReference = {};
			$MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$findTargetSchemaNode(document, elementNode, schemaNode, rawTypeName, typeSchemaNode, typeReference);
			if (typesByName.containsKey(typeReference.$)) {
				existingType = typesByName.get_item(typeReference.$);
			}
			else {
				addTypeByName = ss.mkdel({ typeReference: typeReference }, function(t) {
					typesByName.add(this.typeReference.$, t);
				});
				if (ss.isValue(typeSchemaNode.$)) {
					var complexTypeNodes = $MorseCode_CsJs_Xml_XPath_XPath.evaluate$3(typeSchemaNode.$, './xs:complexType[@name=\'' + typeReference.$.get_$name() + '\']', $MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$resolveNamespace);
					if (complexTypeNodes.length === 1) {
						complexTypeNode = complexTypeNodes[0];
					}
					else {
						var simpleTypeNodes = $MorseCode_CsJs_Xml_XPath_XPath.evaluate$3(typeSchemaNode.$, './xs:simpleType[@name=\'' + typeReference.$.get_$name() + '\']', $MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$resolveNamespace);
						if (simpleTypeNodes.length === 1) {
							simpleTypeNode = simpleTypeNodes[0];
						}
					}
				}
			}
		}
		else {
			typeSchemaNode.$ = schemaNode;
			var complexTypeNodes1 = $MorseCode_CsJs_Xml_XPath_XPath.evaluate$3(elementNode, './xs:complexType', $MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$resolveNamespace);
			if (complexTypeNodes1.length === 1) {
				complexTypeNode = complexTypeNodes1[0];
			}
			else {
				var simpleTypeNodes1 = $MorseCode_CsJs_Xml_XPath_XPath.evaluate$3(elementNode, './xs:simpleType', $MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$resolveNamespace);
				if (simpleTypeNodes1.length === 1) {
					simpleTypeNode = simpleTypeNodes1[0];
				}
			}
		}
		var elementTargetNamespace = schemaNode.attributes.getNamedItem('targetNamespace').nodeValue;
		var typeTargetNamespace = (ss.isNullOrUndefined(typeSchemaNode.$) ? null : typeSchemaNode.$.attributes.getNamedItem('targetNamespace').nodeValue);
		elementDefinition.set_elementNamespace(elementTargetNamespace);
		elementDefinition.set_isArray(false);
		var maxOccursAttribute = elementNode.attributes.getNamedItem('maxOccurs');
		if (ss.isValue(maxOccursAttribute)) {
			if (maxOccursAttribute.nodeValue === 'unbounded') {
				elementDefinition.set_isArray(true);
			}
			else {
				var maxOccurs = MorseCode.CsJs.Common.FrameworkUtility.intTryParse(maxOccursAttribute.nodeValue);
				if (ss.Nullable.ne(maxOccurs, null) && ss.Nullable.gt(maxOccurs, 0)) {
					elementDefinition.set_isArray(true);
				}
			}
		}
		var isNillableAttribute = elementNode.attributes.getNamedItem('isNillable');
		elementDefinition.set_isNullable(ss.isValue(isNillableAttribute) && (isNillableAttribute.nodeValue === 'true' || isNillableAttribute.nodeValue === 'false'));
		elementDefinition.set_name(elementName);
		if (ss.isValue(existingType)) {
			elementDefinition.set_type(existingType);
			return elementDefinition;
		}
		if (ss.isValue(complexTypeNode)) {
			var complexTypeDefinition = new $MorseCode_CsJs_Xml_Schema_XmlSchemaComplexTypeDefinition();
			if (!ss.staticEquals(addTypeByName, null)) {
				addTypeByName(complexTypeDefinition);
			}
			var nameAttribute = complexTypeNode.attributes.getNamedItem('name');
			complexTypeDefinition.set_typeName((ss.isNullOrUndefined(nameAttribute) ? elementName : nameAttribute.nodeValue));
			complexTypeDefinition.set_typeNamespace(typeTargetNamespace);
			var childElementNodes = $MorseCode_CsJs_Xml_XPath_XPath.evaluate$3(complexTypeNode, './xs:sequence/xs:element', $MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$resolveNamespace);
			for (var i = 0; i < childElementNodes.length; i++) {
				ss.add(complexTypeDefinition.get_elements(), $MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$getElementDefinitionRecursive(document, typeSchemaNode.$, childElementNodes[i], typesByName));
			}
			elementDefinition.set_type(complexTypeDefinition);
			return elementDefinition;
		}
		if (ss.isValue(rawTypeName)) {
			var type;
			switch (rawTypeName) {
				case 'xs:anyType': {
					type = 0;
					break;
				}
				case 'xs:anyURI': {
					type = 1;
					break;
				}
				case 'xs:base64Binary': {
					type = 2;
					break;
				}
				case 'xs:boolean': {
					type = 3;
					break;
				}
				case 'xs:byte': {
					type = 4;
					break;
				}
				case 'xs:dateTime': {
					type = 5;
					break;
				}
				case 'xs:decimal': {
					type = 6;
					break;
				}
				case 'xs:double': {
					type = 7;
					break;
				}
				case 'xs:float': {
					type = 8;
					break;
				}
				case 'xs:int': {
					type = 9;
					break;
				}
				case 'xs:long': {
					type = 10;
					break;
				}
				case 'xs:QName': {
					type = 11;
					break;
				}
				case 'xs:short': {
					type = 12;
					break;
				}
				case 'xs:string': {
					type = 13;
					break;
				}
				case 'xs:unsignedByte': {
					type = 14;
					break;
				}
				case 'xs:unsignedInt': {
					type = 15;
					break;
				}
				case 'xs:unsignedLong': {
					type = 16;
					break;
				}
				case 'xs:unsignedShort': {
					type = 17;
					break;
				}
				case 'tns:char': {
					type = 18;
					break;
				}
				case 'tns:duration':
				case 'xs:duration': {
					type = 19;
					break;
				}
				case 'tns:guid': {
					type = 20;
					break;
				}
				default: {
					type = null;
					break;
				}
			}
			if (ss.Nullable.ne(type, null)) {
				var builtInSimpleTypeDefinition = new $MorseCode_CsJs_Xml_Schema_XmlSchemaBuiltInSimpleTypeDefinition();
				if (!ss.staticEquals(addTypeByName, null)) {
					addTypeByName(builtInSimpleTypeDefinition);
				}
				var typeParts = rawTypeName.split(String.fromCharCode(58));
				builtInSimpleTypeDefinition.set_typeNamespace(typeParts[0]);
				builtInSimpleTypeDefinition.set_typeName(typeParts[1]);
				builtInSimpleTypeDefinition.set_type(ss.Nullable.unbox(type));
				elementDefinition.set_type(builtInSimpleTypeDefinition);
				return elementDefinition;
			}
		}
		if (ss.isValue(simpleTypeNode)) {
			var enumerationValueAttributes = $MorseCode_CsJs_Xml_XPath_XPath.evaluate$3(simpleTypeNode, './xs:restriction[@base=\'xs:string\']/xs:enumeration/@value', $MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$resolveNamespace);
			if (enumerationValueAttributes.length > 0) {
				var enumSimpleTypeDefinition = new $MorseCode_CsJs_Xml_Schema_XmlSchemaEnumSimpleTypeDefinition();
				if (!ss.staticEquals(addTypeByName, null)) {
					addTypeByName(enumSimpleTypeDefinition);
				}
				for (var i1 = 0; i1 < enumerationValueAttributes.length; i1++) {
					ss.add(enumSimpleTypeDefinition.get_enumValues(), enumerationValueAttributes[i1].nodeValue);
				}
				elementDefinition.set_type(enumSimpleTypeDefinition);
				return elementDefinition;
			}
		}
		throw new System.InvalidOperationException.$ctor1('Could not find type definition for element ' + elementName + '.');
	};
	$MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$findTargetSchemaNode = function(document, node, thisSchemaNode, rawTypeName, targetSchemaNode, typeReference) {
		var typeParts = rawTypeName.split(String.fromCharCode(58));
		var typeName;
		var typeTargetNamespace;
		if (typeParts.length === 2) {
			typeTargetNamespace = $MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$getNamespace(node, typeParts[0]);
			typeName = typeParts[1];
			var targetSchemaNodes = $MorseCode_CsJs_Xml_XPath_XPath.evaluate$3(document, './/xs:schema[@targetNamespace=\'' + typeTargetNamespace + '\']', $MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$resolveNamespace);
			targetSchemaNode.$ = targetSchemaNodes[0];
		}
		else if (typeParts.length === 1) {
			typeTargetNamespace = thisSchemaNode.attributes.getNamedItem('targetNamespace').nodeValue;
			typeName = typeParts[0];
			targetSchemaNode.$ = thisSchemaNode;
		}
		else {
			throw new System.InvalidOperationException.$ctor1('Could not find target schema node for type ' + rawTypeName + '.');
		}
		typeReference.$ = new $MorseCode_$CsJs_Xml_Schema_XmlSchemaParser$TypeReference(typeTargetNamespace, typeName);
	};
	$MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$resolveNamespace = function(prefix) {
		return ((prefix === 'xs') ? $MorseCode_CsJs_Xml_Schema_XmlSchemaConstants.xsSchemaNamespace : ((prefix === 'xmlns') ? 'http://www.w3.org/2000/xmlns/' : null));
	};
	$MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$getNamespace = function(node, prefix) {
		return $MorseCode_CsJs_Xml_XPath_XPath.evaluate$3(node, './ancestor-or-self::*[@xmlns:' + prefix + '][1]/@xmlns:' + prefix, $MorseCode_CsJs_Xml_Schema_XmlSchemaParser.$resolveNamespace)[0].nodeValue;
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.Schema.XmlSchemaTypeDefinition
	var $MorseCode_CsJs_Xml_Schema_XmlSchemaTypeDefinition = function() {
		this.$1$TypeNamespaceField = null;
	};
	$MorseCode_CsJs_Xml_Schema_XmlSchemaTypeDefinition.prototype = {
		get_typeNamespace: function() {
			return this.$1$TypeNamespaceField;
		},
		set_typeNamespace: function(value) {
			this.$1$TypeNamespaceField = value;
		},
		getTypeName: null
	};
	////////////////////////////////////////////////////////////////////////////////
	// MorseCode.CsJs.Xml.XPath.XPath
	var $MorseCode_CsJs_Xml_XPath_XPath = function() {
	};
	$MorseCode_CsJs_Xml_XPath_XPath.evaluate = function(xml, xpath) {
		return $(xml).xpath(xpath);
	};
	$MorseCode_CsJs_Xml_XPath_XPath.evaluate$2 = function(xml, xpath, resolver) {
		return $(xml).xpath(xpath);
	};
	$MorseCode_CsJs_Xml_XPath_XPath.evaluate$1 = function(node, xpath) {
		return $(node).xpath(xpath);
	};
	$MorseCode_CsJs_Xml_XPath_XPath.evaluate$3 = function(node, xpath, resolver) {
		return $(node).xpath(xpath, resolver);
	};
	ss.registerClass(null, 'MorseCode.$CsJs.Xml.Schema.XmlSchemaParser$TypeReference', $MorseCode_$CsJs_Xml_Schema_XmlSchemaParser$TypeReference);
	ss.registerClass(global, 'MorseCode.CsJs.Xml.XmlExtensionMethods', $MorseCode_CsJs_Xml_XmlExtensionMethods);
	ss.registerInterface(global, 'MorseCode.CsJs.Xml.Schema.IXmlSchemaAttributeDefinition', $MorseCode_CsJs_Xml_Schema_IXmlSchemaAttributeDefinition);
	ss.registerInterface(global, 'MorseCode.CsJs.Xml.Schema.IXmlSchemaTypeDefinition', $MorseCode_CsJs_Xml_Schema_IXmlSchemaTypeDefinition);
	ss.registerInterface(global, 'MorseCode.CsJs.Xml.Schema.IXmlSchemaComplexTypeDefinition', $MorseCode_CsJs_Xml_Schema_IXmlSchemaComplexTypeDefinition, [$MorseCode_CsJs_Xml_Schema_IXmlSchemaTypeDefinition]);
	ss.registerInterface(global, 'MorseCode.CsJs.Xml.Schema.IXmlSchemaElementDefinition', $MorseCode_CsJs_Xml_Schema_IXmlSchemaElementDefinition);
	ss.registerInterface(global, 'MorseCode.CsJs.Xml.Schema.IXmlSchemaSimpleTypeDefinition', $MorseCode_CsJs_Xml_Schema_IXmlSchemaSimpleTypeDefinition, [$MorseCode_CsJs_Xml_Schema_IXmlSchemaTypeDefinition]);
	ss.registerEnum(global, 'MorseCode.CsJs.Xml.Schema.XmlBuiltInSimpleType', $MorseCode_CsJs_Xml_Schema_XmlBuiltInSimpleType);
	ss.registerClass(global, 'MorseCode.CsJs.Xml.Schema.XmlSchemaAttributeDefinition', $MorseCode_CsJs_Xml_Schema_XmlSchemaAttributeDefinition, null, [$MorseCode_CsJs_Xml_Schema_IXmlSchemaAttributeDefinition]);
	ss.registerClass(global, 'MorseCode.CsJs.Xml.Schema.XmlSchemaTypeDefinition', $MorseCode_CsJs_Xml_Schema_XmlSchemaTypeDefinition, null, [$MorseCode_CsJs_Xml_Schema_IXmlSchemaTypeDefinition]);
	ss.registerClass(global, 'MorseCode.CsJs.Xml.Schema.XmlSchemaBuiltInSimpleTypeDefinition', $MorseCode_CsJs_Xml_Schema_XmlSchemaBuiltInSimpleTypeDefinition, $MorseCode_CsJs_Xml_Schema_XmlSchemaTypeDefinition, [$MorseCode_CsJs_Xml_Schema_IXmlSchemaTypeDefinition, $MorseCode_CsJs_Xml_Schema_IXmlSchemaSimpleTypeDefinition]);
	ss.registerClass(global, 'MorseCode.CsJs.Xml.Schema.XmlSchemaComplexTypeDefinition', $MorseCode_CsJs_Xml_Schema_XmlSchemaComplexTypeDefinition, $MorseCode_CsJs_Xml_Schema_XmlSchemaTypeDefinition, [$MorseCode_CsJs_Xml_Schema_IXmlSchemaTypeDefinition, $MorseCode_CsJs_Xml_Schema_IXmlSchemaComplexTypeDefinition]);
	ss.registerClass(global, 'MorseCode.CsJs.Xml.Schema.XmlSchemaConstants', $MorseCode_CsJs_Xml_Schema_XmlSchemaConstants);
	ss.registerClass(global, 'MorseCode.CsJs.Xml.Schema.XmlSchemaCustomSimpleTypeDefinition', $MorseCode_CsJs_Xml_Schema_XmlSchemaCustomSimpleTypeDefinition, $MorseCode_CsJs_Xml_Schema_XmlSchemaTypeDefinition, [$MorseCode_CsJs_Xml_Schema_IXmlSchemaTypeDefinition, $MorseCode_CsJs_Xml_Schema_IXmlSchemaSimpleTypeDefinition]);
	ss.registerClass(global, 'MorseCode.CsJs.Xml.Schema.XmlSchemaElementDefinition', $MorseCode_CsJs_Xml_Schema_XmlSchemaElementDefinition, null, [$MorseCode_CsJs_Xml_Schema_IXmlSchemaElementDefinition]);
	ss.registerClass(global, 'MorseCode.CsJs.Xml.Schema.XmlSchemaEnumSimpleTypeDefinition', $MorseCode_CsJs_Xml_Schema_XmlSchemaEnumSimpleTypeDefinition, $MorseCode_CsJs_Xml_Schema_XmlSchemaTypeDefinition, [$MorseCode_CsJs_Xml_Schema_IXmlSchemaTypeDefinition, $MorseCode_CsJs_Xml_Schema_IXmlSchemaSimpleTypeDefinition]);
	ss.registerClass(global, 'MorseCode.CsJs.Xml.Schema.XmlSchemaParser', $MorseCode_CsJs_Xml_Schema_XmlSchemaParser);
	ss.registerClass(global, 'MorseCode.CsJs.Xml.XPath.XPath', $MorseCode_CsJs_Xml_XPath_XPath);
	$MorseCode_CsJs_Xml_Schema_XmlSchemaConstants.xsSchemaNamespace = 'http://www.w3.org/2001/XMLSchema';
})();
