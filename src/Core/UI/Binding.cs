﻿using System;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.ViewModel;

namespace MorseCode.CsJs.UI
{
    public class Binding<T> : IBinding
    {
        private readonly IReadableObservableProperty<T> _dataContext;
        private readonly Action<T> _bindToDataContext;
        private readonly Action<T> _unbindFromDataContext;
        private readonly Action<T> _bindToControl;
        private readonly Action<T> _unbindFromControl;

        public Binding(IReadableObservableProperty<T> dataContext, Action<T> bindToDataContext, Action<T> unbindFromDataContext, Action<T> bindToControl, Action<T> unbindFromControl)
        {
            _dataContext = dataContext;
            _bindToDataContext = bindToDataContext;
            _unbindFromDataContext = unbindFromDataContext;
            _bindToControl = bindToControl;
            _unbindFromControl = unbindFromControl;

            _bindToDataContext(_dataContext.Value);
            _bindToControl(_dataContext.Value);

            _dataContext.Changing += DataContextChanging;
            _dataContext.Changed += DataContextChanged;
        }

        private void DataContextChanging(object sender, EventArgs e)
        {
            _unbindFromDataContext(_dataContext.Value);
            _unbindFromControl(_dataContext.Value);
        }

        private void DataContextChanged(object sender, EventArgs e)
        {
            _bindToDataContext(_dataContext.Value);
            _bindToControl(_dataContext.Value);
        }

        public void Dispose()
        {
            _dataContext.Changing -= DataContextChanging;
            _dataContext.Changed -= DataContextChanged;

            _unbindFromDataContext(_dataContext.Value);
            _unbindFromControl(_dataContext.Value);
        }
    }

    public interface IBinding : IDisposable
    {
    }
}