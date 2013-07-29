using System;

namespace MorseCode.CsJs.UI.Controls
{
	[AttributeUsage(AttributeTargets.Class)]
	public class ControlParserAttribute : Attribute
	{
		private readonly Type _controlParserType;

		public ControlParserAttribute(Type controlParserType)
		{
			_controlParserType = controlParserType;
		}

		public Type ControlParserType
		{
			get { return _controlParserType; }
		}
	}
}