using System.Collections.Generic;
using Brother.Tests.Specs.Domain;

namespace Brother.Tests.Specs.Services
{
    public interface IWebRequestService
    {
        WebPageResponse GetPageResponse(string url, string method, int timeout, string contentType = null,
            string body = null, Dictionary<string, string> additionalHeaders = null);
    }
}
