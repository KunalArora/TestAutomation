using System;
using System.Net;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class AutomationWebClient : WebClient
    {
        private readonly int _timeoutInMinutes;

        public AutomationWebClient(int timeoutInMinutes = 20)
        {
            _timeoutInMinutes = timeoutInMinutes;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);

            if (request == null)
                throw new ApplicationException("Request is null after creation");

            request.Timeout = (int)TimeSpan.FromMinutes(_timeoutInMinutes).TotalMilliseconds;

            return request;
        }
    }
}