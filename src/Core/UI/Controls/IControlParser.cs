using System.Collections.Generic;
using System.Xml;

namespace MorseCode.CsJs.UI.Controls
{
	public interface IControlParser
	{
		ControlBase ParseNode(XmlNode node, Dictionary<string, ControlBase> childControlsById);
	}
}