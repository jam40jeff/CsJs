using System;
using System.Collections.Generic;
using System.Html;
using System.Xml;
using MorseCode.CsJs.Common.Observable;
using jQueryApi;

namespace MorseCode.CsJs.UI.Controls
{
	[ControlParser(typeof(Parser))]
	public class Panel : CompositeControlBase
	{
		private readonly Action<ControlCollection> _createChildControls;

		private Element _div;
		private jQueryObject _divJQuery;

		private readonly Styles _styles = new Styles();

		private bool _useSlideVisibilityTransition;

		private IBinding _visibleBinding;

		public Panel(Action<ControlCollection> createChildControls)
		{
			_createChildControls = createChildControls;
		}

		protected override void CreateChildControls(ControlCollection controls)
		{
			_createChildControls(controls);
		}

		protected override void CreateElements()
		{
			_div = Document.CreateElement("div");
			_divJQuery = jQuery.FromElement(_div);
			_styles.AttachToElement(_div);
		}

		protected override Element GetChildElementContainer()
		{
			return _div;
		}

		protected override IEnumerable<Element> GetRootElements()
		{
			return new[] { _div };
		}

		public Styles Styles
		{
			get { return _styles; }
		}

		private bool Visible
		{
			get { return _divJQuery.Is(":visible"); }
			set
			{
				if (_useSlideVisibilityTransition)
				{
					if (value)
					{
						_divJQuery.SlideDown(200);
					}
					else
					{
						_divJQuery.SlideUp(200);
					}
				}
				else
				{
					_div.Style.Display = value ? string.Empty : "none";
				}
			}
		}

		public bool UseSlideVisibilityTransition
		{
			get { return _useSlideVisibilityTransition; }
			set { _useSlideVisibilityTransition = value; }
		}

		public void BindVisible<T>(IReadableObservableProperty<T> dataContext, Func<T, IReadableObservableProperty<bool>> getVisibleProperty)
		{
			EnsureUnbound(_visibleBinding);

			EventHandler updateControlEventHandler = null;
			_visibleBinding = CreateOneWayBinding(
				dataContext,
				d =>
					{
						Action updateControl = () => Visible = getVisibleProperty(d).Value;
						updateControlEventHandler = (sender, args) => updateControl();
						getVisibleProperty(d).Changed += updateControlEventHandler;
						updateControl();
					},
				d => getVisibleProperty(d).Changed -= updateControlEventHandler);
			AddBinding(_visibleBinding);
		}

		public class Parser : ControlParserBase<Panel>
		{
			protected override Panel CreateControl(XmlNode node, Dictionary<string, ControlBase> childControlsById)
			{
				return new Panel(controls => controls.AddRange(MarkupParser.ParseNodes(node.ChildNodes, childControlsById)));
			}

			protected override void ParseAttributeAfterSkin(string name, string value, Dictionary<string, ControlBase> childControlsById, Action<Action<Panel>> addPostSkinAction)
			{
				base.ParseAttributeAfterSkin(name, value, childControlsById, addPostSkinAction);

				if (name.ToLower() == "style")
				{
					addPostSkinAction(control => control.Styles.ParseStyleString(value));
				}
				else if (name.ToLower() == "useslidevisibilitytransition")
				{
					addPostSkinAction(control => control.UseSlideVisibilityTransition = value != null && value.ToLower() == "true");
				}
			}
		}
	}
}