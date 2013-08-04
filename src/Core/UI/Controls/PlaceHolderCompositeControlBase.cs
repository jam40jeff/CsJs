using System;
using System.Collections.Generic;
using System.Html;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.UI.Controls
{
	public abstract class PlaceHolderCompositeControlBase : CompositeControlBase
	{
		private Element _tempElement;

		private Element _lastContainer;

		protected override sealed void CreateElements()
		{
			_tempElement = Document.CreateElement("div");
		}

		protected override sealed Element GetChildElementContainer()
		{
			_lastContainer = Parent == null ? _tempElement : Parent.GetChildElementContainer();
			return _lastContainer;
		}

		protected override sealed IEnumerable<Element> GetRootElements()
		{
			throw new NotSupportedException();
		}

		public override void AddControlTo(Element container)
		{
			EnsureChildControlsCreated();

			if (container != _lastContainer)
			{
				SwitchContainer(container, _lastContainer);
				_lastContainer = container;
			}
		}

		public override void RemoveControlFrom(Element container)
		{
			EnsureChildControlsCreated();

			if (_tempElement != _lastContainer)
			{
				SwitchContainer(_tempElement, _lastContainer);
				_lastContainer = _tempElement;
			}
		}

		private void SwitchContainer(Element container, Element oldContainer)
		{
			foreach (ControlBase control in Controls)
			{
				control.RemoveControlFrom(oldContainer);
				control.AddControlTo(container);
			}
		}
	}

	public abstract class PlaceHolderCompositeControlBase<T> : PlaceHolderCompositeControlBase
	{
		private IBinding _dataContextBinding;

		public void BindDataContext<TDataContext>(IReadableObservableProperty<TDataContext> dataContext, Func<TDataContext, T> getDataContext)
		{
			EnsureChildControlsCreated();

			BindControls(new ReadOnlyProperty<T>(getDataContext(dataContext.Value)));
		}

		public void BindDataContext<TDataContext>(IReadableObservableProperty<TDataContext> dataContext, Func<TDataContext, IReadableObservableProperty<T>> getDataContext)
		{
			EnsureUnbound(_dataContextBinding);

			EnsureChildControlsCreated();

			ObservableProperty<T> thisDataContext = new ObservableProperty<T>(getDataContext(dataContext.Value).Value);

			EventHandler updateControlEventHandler = null;
			_dataContextBinding = CreateOneWayBinding(
				dataContext,
				d =>
					{
						Action updateControl = () => thisDataContext.Value = getDataContext(d).Value;
						updateControlEventHandler = (sender, args) => updateControl();
						getDataContext(d).Changed += updateControlEventHandler;
						updateControl();
					},
				d => getDataContext(d).Changed -= updateControlEventHandler);
			AddBinding(_dataContextBinding);

			BindControls(thisDataContext);
		}

		protected abstract void BindControls(IReadableObservableProperty<T> dataContext);
	}
}