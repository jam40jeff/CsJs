using System;
using System.Collections.Generic;
using System.Html;
using System.Xml;

namespace MorseCode.CsJs.UI.Controls
{
	[ControlParser(typeof(Parser))]
	public class HtmlControl : CompositeControlBase
	{
		private readonly string _tagName;
		private readonly Action<ControlCollection> _createChildControls;

		private Element _element;

		private readonly Styles _styles = new Styles();

		public HtmlControl(string tagName, Action<ControlCollection> createChildControls)
		{
			_tagName = tagName;
			_createChildControls = createChildControls;
		}

		protected override void CreateChildControls(ControlCollection controls)
		{
			_createChildControls(controls);
		}

		protected override void CreateElements()
		{
			_element = Document.CreateElement(_tagName);
			_styles.AttachToElement(_element);
		}

		protected override Element GetChildElementContainer()
		{
			return _element;
		}

		protected override IEnumerable<Element> GetRootElements()
		{
			return new[] { _element };
		}

		public Styles Styles
		{
			get { return _styles; }
		}

		public class Parser : ControlParserBase<HtmlControl>
		{
			protected override HtmlControl CreateControl(XmlNode node, Dictionary<string, ControlBase> childControlsById)
			{
				return new HtmlControl(node.Name, controls => controls.AddRange(MarkupParser.ParseNodes(node.ChildNodes, childControlsById)));
			}

			protected override void ParseAttributeAfterSkin(string name, string value, Dictionary<string, ControlBase> childControlsById, Action<Action<HtmlControl>> addPostSkinAction)
			{
				base.ParseAttributeAfterSkin(name, value, childControlsById, addPostSkinAction);

				if (name.ToLower() == "style")
				{
					addPostSkinAction(control => control.Styles.ParseStyleString(value));
				}
			}
		}
	}
}