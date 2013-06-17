using System;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.ViewModel
{
    public abstract class ApplicationViewModelBase
    {
        protected readonly ObservableProperty<object> CurrentViewModelInternal = new ObservableProperty<object>();

        public IReadableObservableProperty<object> CurrentViewModel
        {
            get { return CurrentViewModelInternal; }
        }

        protected abstract object DefaultViewModel { get; }

        protected abstract bool OnError(string errorMessage, string url, int lineNumber);

        public Func<string, string, int, bool> ErrorHandler
        {
            get { return OnError; }
        }

        public void Initialize()
        {
            CurrentViewModelInternal.Value = DefaultViewModel;
        }
    }
}