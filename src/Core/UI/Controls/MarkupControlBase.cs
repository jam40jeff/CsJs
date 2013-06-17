using System.Collections.Generic;
using System.Xml;
using jQueryApi;

namespace MorseCode.CsJs.UI.Controls
{
    public abstract class MarkupControlBase<T> : PlaceHolderCompositeControlBase<T>
    {
        private Dictionary<string, ControlBase> _childControlsById;

        protected override sealed void CreateChildControls()
        {
            _childControlsById = new Dictionary<string, ControlBase>();
            XmlDocument document = jQuery.ParseXml("<root>" + Markup + "</root>");
            Controls.AddRange(MarkupParser.ParseNodes(document.DocumentElement.ChildNodes, _childControlsById));
            SetupControls();
        }

        protected TControl FindControl<TControl>(string id) where TControl : ControlBase
        {
            ControlBase control = null;
            if (_childControlsById != null)
            {
                _childControlsById.TryGetValue(id, out control);
            }
            return control as TControl;
        }

        protected abstract string Markup { get; }

        protected abstract void SetupControls();
    }
}