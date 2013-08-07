using System;
using System.Collections.Generic;
using System.Html;
using System.Xml;
using MorseCode.CsJs.Common.Observable;
using jQueryApi;

namespace MorseCode.CsJs.UI.Controls
{
	[ControlParser(typeof(Parser))]
	public class CheckBox : ControlBase
	{
		private CheckBoxElement _input;

		private readonly Styles _styles = new Styles();

		private IBinding _checkedBinding;
		private IBinding _enabledBinding;

		protected override void CreateElements()
		{
			_input = (CheckBoxElement)Document.CreateElement("input");
			_input.Type = "checkbox";
			jQueryObject inputJQueryObject = jQuery.FromElement(_input);
			inputJQueryObject.Change(e => OnCheckedChanged());
			_styles.AttachToElement(_input);
		}

		protected override IEnumerable<Element> GetRootElements()
		{
			return new[] { _input };
		}

		private bool Checked
		{
			get
			{
				EnsureElementsCreated();
				return _input.Checked;
			}
			set
			{
				EnsureElementsCreated();
				if (_input.Checked != value)
				{
					_input.Checked = value;
					OnCheckedChanged();
				}
			}
		}

		private event EventHandler CheckedChanged;

		protected void OnCheckedChanged()
		{
			if (CheckedChanged != null)
			{
				CheckedChanged(this, EventArgs.Empty);
			}
		}

		private bool Enabled
		{
			get
			{
				EnsureElementsCreated();
				return !_input.Disabled;
			}
			set
			{
				EnsureElementsCreated();
				_input.Disabled = !value;
			}
		}

		public void BindDisabledChecked<T>(IReadableObservableProperty<T> dataContext, Func<T, IReadableObservableProperty<bool>> getCheckedProperty)
		{
			SetEnabled(false);

			EnsureUnbound(_checkedBinding);

			EventHandler updateControlEventHandler = null;
			_checkedBinding = CreateOneWayBinding(
				dataContext,
				d =>
					{
						Action updateControl = () => Checked = getCheckedProperty(d).Value;
						updateControlEventHandler = (sender, args) => updateControl();
						getCheckedProperty(d).Changed += updateControlEventHandler;
						updateControl();
					},
				d => getCheckedProperty(d).Changed -= updateControlEventHandler);
			AddBinding(_checkedBinding);
		}

		public void BindChecked<T>(IReadableObservableProperty<T> dataContext, Func<T, IObservableProperty<bool>> getCheckedProperty)
		{
			EnsureUnbound(_checkedBinding);

			EventHandler updateDataContextEventHandler = null;
			EventHandler updateControlEventHandler = null;
			_checkedBinding = CreateTwoWayBinding(
				dataContext,
				d =>
					{
						Action updateControl = () => Checked = getCheckedProperty(d).Value;
						updateControlEventHandler = (sender, args) => updateControl();
						getCheckedProperty(d).Changed += updateControlEventHandler;
						updateControl();
					},
				d => getCheckedProperty(d).Changed -= updateControlEventHandler,
				d =>
					{
						updateDataContextEventHandler = (sender, args) => getCheckedProperty(d).Value = Checked;
						CheckedChanged += updateDataContextEventHandler;
					},
				d => CheckedChanged -= updateDataContextEventHandler);
			AddBinding(_checkedBinding);
		}

		private void SetEnabled(bool enabled)
		{
			EnsureUnbound(_enabledBinding);

			_enabledBinding = StaticBinding.Instance;
			Enabled = enabled;
		}

		public void SetDisabledChecked(bool @checked)
		{
			SetEnabled(false);

			EnsureUnbound(_checkedBinding);

			_checkedBinding = StaticBinding.Instance;
			Checked = @checked;
		}

		public void BindEnabled<T>(IReadableObservableProperty<T> dataContext, Func<T, IReadableObservableProperty<bool>> getEnabledProperty)
		{
			EnsureUnbound(_enabledBinding);

			EventHandler updateControlEventHandler = null;
			_enabledBinding = CreateOneWayBinding(
				dataContext,
				d =>
					{
						Action updateControl = () => Enabled = getEnabledProperty(d).Value;
						updateControlEventHandler = (sender, args) => updateControl();
						getEnabledProperty(d).Changed += updateControlEventHandler;
						updateControl();
					},
				d => getEnabledProperty(d).Changed -= updateControlEventHandler);
			AddBinding(_enabledBinding);
		}

		public Styles Styles
		{
			get { return _styles; }
		}

		public class Parser : ControlParserBase<CheckBox>
		{
			protected override CheckBox CreateControl(XmlNode node, Dictionary<string, ControlBase> childControlsById)
			{
				return new CheckBox();
			}

			protected override void ParseAttributeAfterSkin(string name, string value, Dictionary<string, ControlBase> childControlsById, Action<Action<CheckBox>> addPostSkinAction)
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