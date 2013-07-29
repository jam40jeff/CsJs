using System;
using System.Collections.Generic;
using System.Html;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.UI.Controls
{
	public class CheckBox : ControlBase
	{
		private CheckBoxElement _checkBox;

		private IBinding _checkedBinding;
		private IBinding _enabledBinding;

		protected override void CreateElements()
		{
			_checkBox = (CheckBoxElement)Document.CreateElement("input");
			_checkBox.Type = "checkbox";
		}

		protected override IEnumerable<Element> GetRootElements()
		{
			return new[] { _checkBox };
		}

		private bool Checked
		{
			get
			{
				EnsureElementsCreated();
				return _checkBox.Checked;
			}
			set
			{
				EnsureElementsCreated();
				if (_checkBox.Checked != value)
				{
					_checkBox.Checked = value;
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
				return !_checkBox.Disabled;
			}
			set
			{
				EnsureElementsCreated();
				_checkBox.Disabled = !value;
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
	}
}