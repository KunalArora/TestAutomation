using Brother.Tests.Common.Logging;
using Brother.Tests.Specs.Domain;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Brother.Tests.Specs.Services
{
    public class WebRequestService : IWebRequestService, IILoggingService
    {
        public WebRequestService(ILoggingService loggingService) { LoggingService = loggingService; }

        public ILoggingService LoggingService { get; set; }

        /// <summary>
        /// Sends an http/s request and returns a WebPageResponse object
        /// </summary>
        /// <param name="url">The url to open</param>
        /// <param name="method">HTTP method (only "GET" or "POST") are valid</param>
        /// <param name="timeout">Timeout, in seconds</param>
        /// <param name="contentType">ContentType for POST requests</param>
        /// <param name="body">Payload for POST requests</param>
        /// <param name="additionalHeaders">Specific http headers as required</param>
        /// <returns></returns>
        public WebPageResponse GetPageResponse(string url, string method, int timeout, string contentType = null,
            string body = null, Dictionary<string, string> additionalHeaders = null)
        {
            LoggingService.WriteLogOnMethodEntry(url, method, timeout, contentType, body, additionalHeaders);
            method = method.ToUpper();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls; //protocols need reviewing
            HttpWebRequest webRequest = null;

            if (url.StartsWith("https:"))
            {
                ServicePointManager.ServerCertificateValidationCallback =
                    (sender, certificate, chain, errors) => { return true; };
            }

            try
            {
                webRequest = (HttpWebRequest)WebRequest.Create(url);
            }
            catch (UriFormatException uriFormatException)
            {
                Console.WriteLine("Invalid url ({0}) specified", url);
                Console.WriteLine("Exception detail : {0}", uriFormatException.Message);
                throw;
            }

            if (additionalHeaders != null && additionalHeaders.Any())
            {
                foreach (var header in additionalHeaders)
                    webRequest.Headers.Add(header.Key, header.Value);
            }

            webRequest.Method = method;
            webRequest.Timeout = (timeout * 1000);
            webRequest.KeepAlive = true;
            webRequest.PreAuthenticate = true;
            webRequest.AllowAutoRedirect = true;
            webRequest.UseDefaultCredentials = true;

            if (method == "POST")
            {
                if (!string.IsNullOrWhiteSpace(contentType))
                    webRequest.ContentType = contentType;

                if (!string.IsNullOrWhiteSpace(body))
                {
                    using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        streamWriter.Write(body);
                    }
                }
            }

            var pageResponse =  PageResponse(webRequest);
            LoggingService.WriteLog(LoggingLevel.DEBUG, "<< {0}", pageResponse);
            return pageResponse;
        }

        private WebPageResponse PageResponse(WebRequest request)
        {
            LoggingService.WriteLogOnMethodEntry(request);
            WebPageResponse webPageResponse = new WebPageResponse
            {
                ResponseBody = string.Empty,
                StatusCode = HttpStatusCode.Ambiguous,
                StatusDescription = string.Empty,
                Headers = new NameValueCollection()
            };

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                webPageResponse.StatusCode = response.StatusCode;
                webPageResponse.StatusDescription = response.StatusDescription;
                webPageResponse.Headers = response.Headers;

                Console.WriteLine("Retrieving response from url {0}", request.RequestUri.AbsoluteUri);
                Console.WriteLine("Response status {0}", webPageResponse.StatusDescription);
                Console.WriteLine("Response code received was [{0}]", webPageResponse.StatusCode.ToString());

                if (webPageResponse.Headers != null && webPageResponse.Headers.Count > 0)
                {
                    foreach (var header in webPageResponse.Headers)
                    {
                        string key = header.ToString();
                        if (key.StartsWith("Brother-"))
                        {
                            Console.WriteLine(string.Format("Custom Header {0}: {1}", key, webPageResponse.Headers[key]));
                        }
                    }
                }

                var receiveStream = response.GetResponseStream();

                var readStream = new StreamReader(receiveStream, Encoding.UTF8);

                webPageResponse.ResponseBody = readStream.ReadToEnd();
                response.Close();
            }
            catch (WebException webException)
            {
                var resp = (HttpWebResponse)webException.Response;
                if (webException.Status == WebExceptionStatus.ProtocolError && webException.Response != null)
                {
                    switch (resp.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                        case HttpStatusCode.BadRequest:
                            Console.WriteLine("Response not received from {0}", request.RequestUri.AbsoluteUri);
                            Console.WriteLine("Exception detail : {0}", webException.Message);
                            break;
                    }
                    webPageResponse.StatusCode = resp.StatusCode;
                    webPageResponse.StatusDescription = resp.StatusDescription;
                }
                else if (webException.Status == WebExceptionStatus.ReceiveFailure)
                {
                    webPageResponse.StatusCode = HttpStatusCode.NotFound;
                }
                Console.WriteLine("Response not received from {0}", request.RequestUri.AbsoluteUri);
                Console.WriteLine("Exception detail : {0}", webException.Message);
            }

            Console.WriteLine("Response Code returned was [{0}]", webPageResponse.StatusCode);
            return webPageResponse;
        }

    }
}
