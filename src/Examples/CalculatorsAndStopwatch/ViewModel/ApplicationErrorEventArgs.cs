using System;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
    public class ApplicationErrorEventArgs : EventArgs
    {
        private readonly string _errorMessage;
        private readonly string _url;
        private readonly int _lineNumber;

        public ApplicationErrorEventArgs(string errorMessage, string url, int lineNumber)
        {
            _errorMessage = errorMessage;
            _url = url;
            _lineNumber = lineNumber;
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
        }

        public string Url
        {
            get { return _url; }
        }

        public int LineNumber
        {
            get { return _lineNumber; }
        }
    }
}