using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;

namespace F23.ModelValidationExample.Controllers
{
    public class ControllerBase : Controller
    {
        public override ViewResult View()
        {
            SetViewDataMessages();
            return base.View();
        }

        public override ViewResult View(string viewName, object model)
        {
            SetViewDataMessages();
            return base.View(viewName, model);
        }

        public override ViewResult View(object model)
        {
            SetViewDataMessages();
            return base.View(model);
        }

        public override ViewResult View(string viewName)
        {
            SetViewDataMessages();
            return base.View(viewName);
        }

        protected void AddErrorMessage(string message)
        {
            TempData[ViewDataKeys.ErrorMessage] = message;
        }

        protected void AddErrorMessage(IEnumerable<string> messages)
        {
            AddErrorMessage(BuildStatusMessage(messages));
        }

        protected void AddWarningMessage(string message)
        {
            TempData[ViewDataKeys.WarningMessage] = message;
        }
        protected void AddWarningMessage(IEnumerable<string> messages)
        {
            AddWarningMessage(BuildStatusMessage(messages));
        }

        protected void AddSuccessMessage(string message)
        {
            TempData[ViewDataKeys.SuccessMessage] = message;
        }

        protected void AddSuccessMessage(IEnumerable<string> messages)
        {
            AddSuccessMessage(BuildStatusMessage(messages));
        }

        private void SetViewDataMessages()
        {
            if (TempData[ViewDataKeys.SuccessMessage] != null)
                ViewData[ViewDataKeys.SuccessMessage] = TempData[ViewDataKeys.SuccessMessage];
            if (TempData[ViewDataKeys.WarningMessage] != null)
                ViewData[ViewDataKeys.WarningMessage] = TempData[ViewDataKeys.WarningMessage];
            if (TempData[ViewDataKeys.ErrorMessage] != null)
                ViewData[ViewDataKeys.ErrorMessage] = TempData[ViewDataKeys.ErrorMessage];
        }

        private static string BuildStatusMessage(IEnumerable<string> messages)
        {
            var messageString = new StringBuilder();
            messageString.Append("<ul>");
            foreach (var message in messages)
            {
                messageString.Append($"<li>{message}</li>");
            }

            messageString.Append("</ul>");
            return messageString.ToString();
        }
    }

    public static class ViewDataKeys
    {
        public const string SuccessMessage = "SuccessMessage";
        public const string WarningMessage = "WarningMessage";
        public const string ErrorMessage = "ErrorMessage";
    }
}
