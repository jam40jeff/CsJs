using System;
using MorseCode.CsJs.ViewModel;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
    public class CalculatorsAndStopwatchApplicationViewModel : ApplicationViewModelBase
    {
        public event EventHandler<ApplicationErrorEventArgs> ApplicationError;

        protected virtual void OnApplicationError(ApplicationErrorEventArgs e)
        {
            EventHandler<ApplicationErrorEventArgs> handler = ApplicationError;
            if (handler != null) handler(this, e);
        }

        protected override bool OnError(string errorMessage, string url, int lineNumber)
        {
            OnApplicationError(new ApplicationErrorEventArgs(errorMessage, url, lineNumber));
            return true;
        }

        protected override object DefaultViewModel
        {
            get { return new CalculatorsAndStopwatchPageViewModel(this); }
        }

        public void NavigateToStopwatchPage()
        {
            CurrentViewModelInternal.Value = new StopwatchPageViewModel(this);
        }
    }
}