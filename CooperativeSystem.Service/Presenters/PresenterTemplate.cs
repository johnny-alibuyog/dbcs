using System;
using CooperativeSystem.Service.Utilities.Logs;

namespace CooperativeSystem.Service.Presenters
{
    public delegate void ErrorHandler(object sender, string message);
    public delegate void SuccessHandler(object sender, string message);

    public abstract class PresenterTemplate
    {
        private ErrorLogger _errorLogger;

        public event ErrorHandler Error;
        public event SuccessHandler Success;

        public PresenterTemplate()
        {
            _errorLogger = new ErrorLogger();
        }

        protected void RaiseErrorEvent(string message)
        {
            RaiseErrorEvent(message, null);
        }

        protected void RaiseErrorEvent(string message, Exception ex)
        {
            if (ex != null)
                _errorLogger.Log(ex.ToString());

            OnError(this, message);
        }

        protected virtual void OnError(object sender, string message)
        {
            if (Error != null)
                Error.Invoke(sender, message);
        }

        protected void RaiseSusccessEvent(string message)
        {
            OnSusccess(this, message);
        }

        protected virtual void OnSusccess(object sender, string message)
        {
            if (Success != null)
                Success.Invoke(sender, message);
        }
    }
}
