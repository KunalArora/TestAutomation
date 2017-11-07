using System.Collections.Specialized;
using System.Net;

namespace Brother.Tests.Specs.Domain
{
    public class WebPageResponse
    {
        public string ResponseBody { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public NameValueCollection Headers { get; set; }
    }
}
