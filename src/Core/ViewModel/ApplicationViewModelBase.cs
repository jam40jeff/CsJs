using System;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.ViewModel
{
    public abstract class ApplicationViewModelBase
    {
        private readonly ObservableProperty<object> _currentViewModel = new ObservableProperty<object>();

        public ObservableProperty<object> CurrentViewModel
        {
            get { return _currentViewModel; }
        }

        protected abstract object DefaultViewModel { get; }

        protected abstract bool OnError(string errorMessage, string url, int lineNumber);

        public Func<string, string, int, bool> ErrorHandler
        {
            get { return OnError; }
        }

        public void Initialize()
        {
            _currentViewModel.Value = DefaultViewModel;
        }
    }
}