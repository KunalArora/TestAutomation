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

        public override string ToString()
        {
            try {
                return string.Format("{{StatusCode={0}, StatusDescription={1}, Headers={2}, ResponseBody={3}}}", StatusCode, StatusDescription, Headers, ResponseBody)
                    .Replace("\r","\\r").Replace("\n","\\n");
            }
            catch
            {
                return base.ToString();
            }            
        }
    }
}
