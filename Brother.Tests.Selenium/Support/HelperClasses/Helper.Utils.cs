using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class Utils : Helper
    {
        private const int PageResponseTimeOut = 6000;

        public class OrderInformation
        {
            public string ReferenceOrder;
            public string PurchaseStatusNumber;
        }

        public static OrderInformation GetOrderInformation(string xmlResponseData)
        {
            const string purchStatusText = "PurchStatus>";
            const string referenceOrderNumberText = "RefDocNr>";
            var orderInfo = new OrderInformation();

            var purStatusIndex = xmlResponseData.IndexOf(purchStatusText, 0);
            orderInfo.PurchaseStatusNumber = xmlResponseData.Substring(purStatusIndex + purchStatusText.Length, 4);
            var refOrderIndex = xmlResponseData.IndexOf(referenceOrderNumberText, 0);
            orderInfo.ReferenceOrder = xmlResponseData.Substring(refOrderIndex + referenceOrderNumberText.Length, 10);
            return orderInfo;
        }

        public static HttpStatusCode GetPageResponse(string webPage, string method, int numRetries)
        {
            var maxRetryCount = 0;
            var pageResponse = GetPageResponse(webPage, method);
            while ((pageResponse != HttpStatusCode.OK) && (maxRetryCount != numRetries))
            {
                pageResponse = GetPageResponse(webPage, method);
                if (pageResponse != HttpStatusCode.OK)
                {
                    pageResponse = GetPageResponse(webPage, method == "HEAD" ? "GET" : "HEAD");
                }
                WebDriver.Wait(DurationType.Second, 2);
                MsgOutput(string.Format("Retrying..... [{0}] times", maxRetryCount));
                maxRetryCount++;
            }
            return pageResponse;
        }

      
        public static string GetSuccessStringFromUrl(string url, int numTries, Dictionary<string, string> additionalHeaders = null)
        {
            var retryCount = 0;

            var webClient = new WebClient();


            if (additionalHeaders != null && additionalHeaders.Any())
            {
                foreach (var header in additionalHeaders)
                    webClient.Headers.Add(header.Key, header.Value);
            }
            
            var testFromFile = webClient.DownloadString(url);

            while ((testFromFile.Contains("Failure")) && (retryCount != numTries))
            {
                testFromFile = webClient.DownloadString(url);
                WebDriver.Wait(DurationType.Second, 2);
                MsgOutput(string.Format("Retrying..... [{0}] times", retryCount));
                retryCount++;
            }

            if ((testFromFile.Contains("Failure")))
            {
                MsgOutput(string.Format("The message from url is [{0}] times", testFromFile));
            }
            return testFromFile;
        }

        private static HttpStatusCode PageResponse(WebRequest request, out string xmlResponseData)
        {
            var responseCode = HttpStatusCode.Ambiguous;
            var xmlResponse = string.Empty;

            try
            {
                var response = (HttpWebResponse) request.GetResponse();
                responseCode = response.StatusCode;
                MsgOutput("Retrieving response from url ", request.RequestUri.AbsoluteUri);
                MsgOutput("Response status ", response.StatusDescription);
                MsgOutput(string.Format("Response code received was [{0}]", responseCode.ToString()));
                var receiveStream = response.GetResponseStream();

                var readStream = new StreamReader(receiveStream, Encoding.UTF8);

                xmlResponse = readStream.ReadToEnd();
                response.Close();
            }
            catch (WebException webException)
            {
                var resp = (HttpWebResponse) webException.Response;
                if (webException.Status == WebExceptionStatus.ProtocolError && webException.Response != null)
                {
                    switch (resp.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                        case HttpStatusCode.BadRequest:
                            MsgOutput("Did not get a response back from ", request.RequestUri.AbsoluteUri);
                            MsgOutput("Reason : ", webException.Message);
                            break;
                    }
                    responseCode = resp.StatusCode;
                }
                else if (webException.Status == WebExceptionStatus.ReceiveFailure)
                {
                    responseCode = HttpStatusCode.NotFound;
                }
                MsgOutput("Did not get a response back from ", request.RequestUri.AbsoluteUri);
                MsgOutput("Reason : ", webException.Message);
            }

            MsgOutput(string.Format("Response Code returned was [{0}]", responseCode));
            xmlResponseData = xmlResponse;
            return responseCode;
        }

        public static HttpStatusCode GetPageResponse(string webPage, string method, Dictionary<string, string> additionalHeaders = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            HttpWebRequest webRequest = null;

            if (webPage.Contains("https:"))
            {
                ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback();
            }

            try
            {
                webRequest = (HttpWebRequest) WebRequest.Create(webPage);
            }
            catch (UriFormatException uriFormatException)
            {
                MsgOutput("Unable to determine WebSite for validation ", webPage);
                MsgOutput("Reason : ", uriFormatException.Message);
                if (uriFormatException.InnerException != null)
                {
                    TestCheck.AssertFailTest(string.Format("URI format exception - inner exception [{0}]",
                        uriFormatException.InnerException.Message));
                }
                TestCheck.AssertFailTest(string.Format("URI format exception [{0}]", uriFormatException.Message));
            }

            if (additionalHeaders != null && additionalHeaders.Any())
            {
                foreach (var header in additionalHeaders)
                    webRequest.Headers.Add(header.Key, header.Value);
            }

            webRequest.Method = method;
            webRequest.Timeout = PageResponseTimeOut;
            webRequest.KeepAlive = true;
            webRequest.PreAuthenticate = true;
            webRequest.AllowAutoRedirect = true;
            webRequest.UseDefaultCredentials = true;
            //MsgOutput("Credentials used in connection : ", webRequest.Credentials.ToString());
            string xmlData;
            return PageResponse(webRequest, out xmlData);
        }

        public static bool ConfirmSapOrder(string orderNumber, int numRetries)
        {
            var maxRetryCount = 0;
            var orderSuccess = false;
            string xmlResponseData;
            orderSuccess = ConfirmSapOrder(orderNumber, out xmlResponseData);
            while ((orderSuccess != true) && (maxRetryCount != 20))
            {
                orderSuccess = ConfirmSapOrder(orderNumber, out xmlResponseData);
                WebDriver.Wait(DurationType.Second, 5); // Static pause to allow request to clear before retrying
                MsgOutput(string.Format("Retrying to validate order number [{0}] - RETRY [{1}]", orderNumber,
                    maxRetryCount));
                maxRetryCount++;
            }
            return orderSuccess;
        }

        public static bool ConfirmSapOrder(string orderNumber)
        {
            string xmlResponseData;
            return ConfirmSapOrder(orderNumber, out xmlResponseData);
        }


        // Returns a 200 OK response if the given order number is present on the SAP server
        // for the relevant environment
        public static bool ConfirmSapOrder(string orderNumber, out string xmlResponseData)
        {
            var dv2ConfirmUrl =
                "http://prapp427v.brotherdc.eu:8000/sap/opu/odata/sap/YESD_PURCHASE/PurchaseHeaders('')?$expand=PurchaseItems";
            var qasConfirmUrl =
                "http://prapp426v.brotherdc.eu:8000/sap/opu/odata/sap/YESD_PURCHASE/PurchaseHeaders('')?$expand=PurchaseItems";

            var orderNumberText = @"PurchaseHeaders('')";
            var orderReplaceText = String.Format("PurchaseHeaders('{0}')", orderNumber);

            const string username = "sitecore";
            const string password = "S1t3c0r3";

            var runTimeEnv = GetRunTimeEnv();
            var url = runTimeEnv.Equals("UAT") ? qasConfirmUrl : dv2ConfirmUrl;
            url = url.Replace(orderNumberText, orderReplaceText);

            HttpWebRequest request = null;
            try
            {
                // Create request
                request = (HttpWebRequest) WebRequest.Create(url);
            }
            catch (UriFormatException uriFormatException)
            {
                MsgOutput("Unable to determine WebSite for validation ", url);
                MsgOutput("Reason : ", uriFormatException.Message);
                if (uriFormatException.InnerException != null)
                {
                    TestCheck.AssertFailTest(string.Format("URI format exception - inner exception [{0}]",
                        uriFormatException.InnerException.Message));
                }
                TestCheck.AssertFailTest(string.Format("URI format exception [{0}]", uriFormatException.Message));
            }

            request.Method = WebRequestMethods.Http.Get;
            request.CookieContainer = new CookieContainer();
            request.ContentLength = 0;
            request.PreAuthenticate = false;
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Timeout = PageResponseTimeOut;

            // set credentials
            var nc = new NetworkCredential(username, password);
            var cache = new CredentialCache();
            var newUri = new Uri(url);
            cache.Add(newUri, "Basic", nc);
            request.Credentials = nc;
            var orderSuccess = PageResponse(request, out xmlResponseData);
            MsgOutput(string.Format("Response Code returned for order [{0}] was [{1}]", orderNumber, orderSuccess));
            return orderSuccess == HttpStatusCode.OK;
        }


        /// <summary>
        /// Grants a role to a user
        /// </summary>
        public static void GrantUserRole(string userAccountEmail, string role)
        {
            HttpWebRequest request = null;
            WebDriver.Wait(DurationType.Second, 15);
            var roleCheckUrl = string.Empty;

            var runTimeEnv = string.Empty;
            if (GetRunTimeEnv().Equals("TEST"))
            {
                runTimeEnv = "dv2";
            }

            if (GetRunTimeEnv().Equals("UAT"))
            {
                runTimeEnv = "qas";
            }

            roleCheckUrl = @"http://eu.cms.brother.eu/sitecore/admin/integration/";
            roleCheckUrl = roleCheckUrl.Replace("brother", string.Format("brother{0}", runTimeEnv));

            roleCheckUrl = string.Format("{0}AddRole.aspx?email={1}&role=" + @"{2}", roleCheckUrl, userAccountEmail,
                role);
            var newString = roleCheckUrl.Replace(@"\\", @"\");

            try
            {
                // Create request
                request = (HttpWebRequest) WebRequest.Create(newString);
            }
            catch (UriFormatException uriFormatException)
            {
                MsgOutput("Unable to determine WebSite for validation ", newString);
                MsgOutput("Reason : ", uriFormatException.Message);
                if (uriFormatException.InnerException != null)
                {
                    TestCheck.AssertFailTest(string.Format("URI format exception - inner exception [{0}]",
                        uriFormatException.InnerException.Message));
                }
                TestCheck.AssertFailTest(string.Format("URI format exception [{0}]", uriFormatException.Message));
            }

            request.Method = WebRequestMethods.Http.Post;
            request.CookieContainer = new CookieContainer();
            request.ContentLength = 0;
            request.PreAuthenticate = true;
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Timeout = PageResponseTimeOut;
            string xmlResponseData;
            var response = PageResponse(request, out xmlResponseData);
        }

        /// <summary>
        /// Given a starting page, returns a resonse back from any link on that page
        /// </summary>
        /// <param name="startPage">Starting page to validate responses</param>
        public static bool ValidatePageLinks(string startPage)
        {
            return true;
        }


        public class TrustAllCertificatePolicy : System.Net.ICertificatePolicy
        {
            public TrustAllCertificatePolicy()
            {
            }

            public bool CheckValidationResult(ServicePoint sp,
                X509Certificate cert, WebRequest req, int problem)
            {
                return true;
            }
        }

        public static bool IsPortAvailable(string ipAddress, int portNumber)
        {
            var portInUse = true;
            var retries = 0;
 
            while ((portInUse && retries < 10))
            {
                if (CheckForPortInUse(ipAddress, portNumber) == false)
                {
                    MsgOutput(string.Format("Port number [{0}] is free to connect to", portNumber));
                    portInUse = false;
                }
                else
                {
                    MsgOutput(string.Format("Port number [{0}] is still in use - retrying until it is clear", portNumber));
                    WebDriver.Wait(DurationType.Second, 1);
                    retries++;
                    portInUse = true;
                }
            }
            return !portInUse;
        }

        public static bool CheckForPortInUse(string ipAddress, int portNumber)
        {
            var ipAddr = Dns.GetHostEntry(ipAddress).AddressList[0];
            try
            {
                var tcpListener = new System.Net.Sockets.TcpListener(ipAddr, Convert.ToInt32(portNumber));
                tcpListener.Start();
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                MsgOutput(string.Format("Unable to connect to port [{0}] as it is already in use", portNumber));
                return true;
            }
            return false;
        }
    }
}
