using System;
using System.Collections.Generic;
using System.Html;
using System.Xml;
using MorseCode.CsJs.Common.Observable;
using jQueryApi;

namespace MorseCode.CsJs.UI.Controls
{
	[ControlParser(typeof(Parser))]
	public class TextBox : ControlBase
	{
		private InputElement _input;

		private ITextBoxTextBinding _textBinding;
		private bool _updateTextBindingWhileChanging;

		private IBinding _updateTextBindingWhileChangingBinding;

		protected override void CreateElements()
		{
			_input = (InputElement)Document.CreateElement("input");
			_input.Type = "text";
			jQuery.FromElement(_input).Keyup(e => OnTextChanging());
			jQuery.FromElement(_input).Change(e => OnTextChanged());
		}

		protected override IEnumerable<Element> GetRootElements()
		{
			return new[] { _input };
		}

		private string Text
		{
			get
			{
				EnsureElementsCreated();
				return _input.Value;
			}
			set
			{
				EnsureElementsCreated();
				_input.Value = value;
			}
		}

		private bool UpdateTextBindingWhileChanging
		{
			get { return _updateTextBindingWhileChanging; }
			set
			{
				if (_updateTextBindingWhileChanging != value)
				{
					_updateTextBindingWhileChanging = value;
					if (_textBinding != null)
					{
						_textBinding.UpdateWhileChanging = value;
					}
				}
			}
		}

		private event EventHandler TextChanging;

		protected void OnTextChanging()
		{
			if (TextChanging != null)
			{
				TextChanging(this, EventArgs.Empty);
			}
		}

		private event EventHandler TextChanged;

		protected void OnTextChanged()
		{
			if (TextChanged != null)
			{
				TextChanged(this, EventArgs.Empty);
			}
		}

		public void BindText<T>(IReadableObservableProperty<T> dataContext, Func<T, IObservableProperty<string>> getTextProperty)
		{
			BindText(dataContext, getTextProperty, UpdateTextBindingWhileChanging);
		}

		public void BindText<T>(IReadableObservableProperty<T> dataContext, Func<T, IObservableProperty<string>> getTextProperty, bool updateTextBindingWhileChanging)
		{
			if (_textBinding != null)
			{
				throw new NotSupportedException("Bind may not be called twice on TextBox.");
			}

			EventHandler updateControlEventHandler = null;
			_textBinding = new TextBoxTextBinding<T>(
				this,
				getTextProperty,
				dataContext,
				d =>
					{
						Action updateControl = () => Text = getTextProperty(d).Value ?? string.Empty;
						updateControlEventHandler = (sender, args) => updateControl();
						getTextProperty(d).Changed += updateControlEventHandler;
						updateControl();
					},
				d => getTextProperty(d).Changed -= updateControlEventHandler,
				updateTextBindingWhileChanging);
			AddBinding(_textBinding);
		}

		public void SetUpdateTextBindingWhileChanging(bool updateTextBindingWhileChanging)
		{
			EnsureUnbound(_updateTextBindingWhileChangingBinding);

			_updateTextBindingWhileChangingBinding = StaticBinding.Instance;
			UpdateTextBindingWhileChanging = updateTextBindingWhileChanging;
		}

		public void BindUpdateTextBindingWhileChanging<T>(IReadableObservableProperty<T> dataContext, Func<T, IReadableObservableProperty<bool>> getUpdateTextBindingWhileChangingProperty)
		{
			EnsureUnbound(_updateTextBindingWhileChangingBinding);

			EventHandler updateControlEventHandler = null;
			_updateTextBindingWhileChangingBinding = CreateOneWayBinding(
				dataContext,
				d =>
					{
						Action updateControl = () => UpdateTextBindingWhileChanging = getUpdateTextBindingWhileChangingProperty(d).Value;
						updateControlEventHandler = (sender, args) => updateControl();
						getUpdateTextBindingWhileChangingProperty(d).Changed += updateControlEventHandler;
						updateControl();
					},
				d => getUpdateTextBindingWhileChangingProperty(d).Changed -= updateControlEventHandler);
			AddBinding(_updateTextBindingWhileChangingBinding);
		}

		private interface ITextBoxTextBinding : IBinding
		{
			bool UpdateWhileChanging { get; set; }
		}

		private class TextBoxTextBinding<T> : Binding<T>, ITextBoxTextBinding
		{
			private readonly TextBox _owner;
			private readonly Func<T, IObservableProperty<string>> _getTextProperty;

			private bool _updateWhileChanging;

			private EventHandler _updateDataContextEventHandler;

			public TextBoxTextBinding(TextBox owner, Func<T, IObservableProperty<string>> getTextProperty, IReadableObservableProperty<T> dataContext, Action<T> bindToDataContext, Action<T> unbindFromDataContext, bool updateWhileChanging)
				: base(
					dataContext,
					bindToDataContext,
					unbindFromDataContext,
					null,
					null)
			{
				_owner = owner;
				_updateWhileChanging = updateWhileChanging;
				_getTextProperty = getTextProperty;

				BindToControl = GetBindToControl(updateWhileChanging);
				UnbindFromControl = GetUnbindFromControl(updateWhileChanging);
			}

			private Action<T> GetBindToControl(bool updateWhileChanging)
			{
				return d =>
					{
						_updateDataContextEventHandler = (sender, args) => _getTextProperty(d).Value = _owner.Text;
						if (updateWhileChanging)
						{
							_owner.TextChanging += _updateDataContextEventHandler;
						}
						else
						{
							_owner.TextChanged += _updateDataContextEventHandler;
						}
					};
			}

			private Action<T> GetUnbindFromControl(bool updateWhileChanging)
			{
				return d =>
					{
						if (updateWhileChanging)
						{
							_owner.TextChanging -= _updateDataContextEventHandler;
						}
						else
						{
							_owner.TextChanged -= _updateDataContextEventHandler;
						}
					};
			}

			public bool UpdateWhileChanging
			{
				get { return _updateWhileChanging; }
				set
				{
					if (_updateWhileChanging != value)
					{
						_updateWhileChanging = value;
						BindToControl = GetBindToControl(value);
						UnbindFromControl = GetUnbindFromControl(value);
					}
				}
			}
		}

		public class Parser : ControlParserBase<TextBox>
		{
			protected override TextBox CreateControl(XmlNode node, Dictionary<string, ControlBase> childControlsById)
			{
				return new TextBox();
			}

			protected override void ParseAttributeAfterSkin(string name, string value, Dictionary<string, ControlBase> childControlsById, Action<Action<TextBox>> addPostSkinAction)
			{
				base.ParseAttributeAfterSkin(name, value, childControlsById, addPostSkinAction);

				if (name.ToLower() == "Updatetextbindingwhilechanging")
				{
					addPostSkinAction(control => control.SetUpdateTextBindingWhileChanging(value != null && value.ToLower() == "true"));
				}
			}
		}
	}
}