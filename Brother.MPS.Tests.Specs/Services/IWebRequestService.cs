using System.Collections.Generic;
using Brother.Tests.Specs.Domain;
using System.Text;

namespace Brother.Tests.Specs.Services
{
    public interface IWebRequestService
    {
        WebPageResponse GetPageResponse(string url, string method, int timeout, string contentType = null,
            string body = null, Dictionary<string, string> additionalHeaders = null, Encoding encoding = null);
    }
}
