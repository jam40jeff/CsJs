using System;
using System.Collections.Generic;
using System.Html;
using System.Xml;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.UI.Controls
{
	[ControlParser(typeof(Parser))]
	public class Label : ControlBase
	{
		private Element _span;

		private readonly Styles _styles = new Styles();

		private IBinding _textBinding;

		protected override void CreateElements()
		{
			_span = Document.CreateElement("span");
			_styles.AttachToElement(_span);
		}

		protected override IEnumerable<Element> GetRootElements()
		{
			return new[] { _span };
		}

		private string Text
		{
			get
			{
				EnsureElementsCreated();
				return _span.InnerText;
			}
			set
			{
				EnsureElementsCreated();
				_span.InnerText = value;
			}
		}

		private string InnerHtml
		{
			get
			{
				EnsureElementsCreated();
				return _span.InnerHTML;
			}
			set
			{
				EnsureElementsCreated();
				_span.InnerHTML = value;
			}
		}

		public void SetText(string text)
		{
			EnsureUnbound(_textBinding);

			_textBinding = StaticBinding.Instance;
			Text = text;
		}

		public void BindText<T>(IReadableObservableProperty<T> dataContext, Func<T, IReadableObservableProperty<string>> getTextProperty)
		{
			BindText(dataContext, getTextProperty, v => v);
		}

		public void BindText<T, TProperty>(IReadableObservableProperty<T> dataContext, Func<T, IReadableObservableProperty<TProperty>> getTextProperty, Func<TProperty, string> formatString)
		{
			EnsureUnbound(_textBinding);

			EventHandler updateControlEventHandler = null;
			_textBinding = CreateOneWayBinding(
				dataContext,
				d =>
					{
						Action updateControl = () => Text = formatString(getTextProperty(d).Value) ?? string.Empty;
						updateControlEventHandler = (sender, args) => updateControl();
						getTextProperty(d).Changed += updateControlEventHandler;
						updateControl();
					},
				d => getTextProperty(d).Changed -= updateControlEventHandler);
			AddBinding(_textBinding);
		}

		public void SetHtml(string html)
		{
			EnsureUnbound(_textBinding);

			_textBinding = StaticBinding.Instance;
			InnerHtml = html;
		}

		public void BindHtml<T>(IReadableObservableProperty<T> dataContext, Func<T, IReadableObservableProperty<string>> getHtmlProperty)
		{
			BindHtml(dataContext, getHtmlProperty, v => v);
		}

		public void BindHtml<T, TProperty>(IReadableObservableProperty<T> dataContext, Func<T, IReadableObservableProperty<TProperty>> getHtmlProperty, Func<TProperty, string> formatString)
		{
			EnsureUnbound(_textBinding);

			EventHandler updateControlEventHandler = null;
			_textBinding = CreateOneWayBinding(
				dataContext,
				d =>
					{
						Action updateControl = () => InnerHtml = formatString(getHtmlProperty(d).Value) ?? string.Empty;
						updateControlEventHandler = (sender, args) => updateControl();
						getHtmlProperty(d).Changed += updateControlEventHandler;
						updateControl();
					},
				d => getHtmlProperty(d).Changed -= updateControlEventHandler);
			AddBinding(_textBinding);
		}

		public Styles Styles
		{
			get { return _styles; }
		}

		public class Parser : ControlParserBase<Label>
		{
			protected override Label CreateControl(XmlNode node, Dictionary<string, ControlBase> childControlsById)
			{
				return new Label();
			}

			protected override void ParseAttributeAfterSkin(string name, string value, Dictionary<string, ControlBase> childControlsById, Action<Action<Label>> addPostSkinAction)
			{
				base.ParseAttributeAfterSkin(name, value, childControlsById, addPostSkinAction);

				if (name.ToLower() == "style")
				{
					addPostSkinAction(control => control.Styles.ParseStyleString(value));
				}
				else if (name.ToLower() == "text")
				{
					addPostSkinAction(control => control.SetText(value));
				}
			}
		}
	}
}