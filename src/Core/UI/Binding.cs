using System;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.UI
{
	public class Binding<T> : IBinding
	{
		private IReadableObservableProperty<T> _dataContext;
		private Action<T> _bindToDataContext;
		private Action<T> _unbindFromDataContext;
		private Action<T> _bindToControl;
		private Action<T> _unbindFromControl;

		public Binding(IReadableObservableProperty<T> dataContext, Action<T> bindToDataContext, Action<T> unbindFromDataContext, Action<T> bindToControl, Action<T> unbindFromControl)
		{
			_dataContext = dataContext;
			_bindToDataContext = bindToDataContext;
			_unbindFromDataContext = unbindFromDataContext;
			_bindToControl = bindToControl;
			_unbindFromControl = unbindFromControl;

			BindToDataContextInternal();
			BindToControlInternal();

			_dataContext.BeforeChanged += OnBeforeDataContextChanged;
			_dataContext.Changed += OnDataContextChanged;
		}

		private void OnBeforeDataContextChanged(object sender, EventArgs e)
		{
			UnbindFromDataContextInternal();
			UnbindFromControlInternal();
		}

		private void UnbindFromDataContextInternal()
		{
			if (_unbindFromDataContext != null)
			{
				_unbindFromDataContext(_dataContext.Value);
			}
		}

		private void UnbindFromControlInternal()
		{
			if (_unbindFromControl != null)
			{
				_unbindFromControl(_dataContext.Value);
			}
		}

		private void OnDataContextChanged(object sender, EventArgs e)
		{
			BindToDataContextInternal();
			BindToControlInternal();
		}

		private void BindToDataContextInternal()
		{
			if (_bindToDataContext != null)
			{
				_bindToDataContext(_dataContext.Value);
			}
		}

		private void BindToControlInternal()
		{
			if (_bindToControl != null)
			{
				_bindToControl(_dataContext.Value);
			}
		}

		public void Dispose()
		{
			_dataContext.BeforeChanged -= OnBeforeDataContextChanged;
			_dataContext.Changed -= OnDataContextChanged;

			UnbindFromDataContextInternal();
			UnbindFromControlInternal();
		}

		protected IReadableObservableProperty<T> DataContext
		{
			get { return _dataContext; }
			set
			{
				if (!ReferenceEquals(_dataContext, value))
				{
					UnbindFromDataContextInternal();
					UnbindFromControlInternal();
					_dataContext = value;
					BindToDataContextInternal();
					BindToControlInternal();
				}
			}
		}

		protected Action<T> BindToDataContext
		{
			get { return _bindToDataContext; }
			set
			{
				if (!ReferenceEquals(_bindToDataContext, value))
				{
					UnbindFromDataContextInternal();
					_bindToDataContext = value;
					BindToDataContextInternal();
				}
			}
		}

		protected Action<T> UnbindFromDataContext
		{
			get { return _unbindFromDataContext; }
			set { _unbindFromDataContext = value; }
		}

		protected Action<T> BindToControl
		{
			get { return _bindToControl; }
			set
			{
				if (!ReferenceEquals(_bindToControl, value))
				{
					UnbindFromControlInternal();
					_bindToControl = value;
					BindToControlInternal();
				}
			}
		}

		protected Action<T> UnbindFromControl
		{
			get { return _unbindFromControl; }
			set { _unbindFromControl = value; }
		}
	}
}