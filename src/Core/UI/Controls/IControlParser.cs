using System.Collections.Generic;
using System.Xml;

namespace MorseCode.CsJs.UI.Controls
{
    public interface IControlParser
    {
        Control ParseNode(XmlNode node, Dictionary<string, Control> childControlsById);
    }
}