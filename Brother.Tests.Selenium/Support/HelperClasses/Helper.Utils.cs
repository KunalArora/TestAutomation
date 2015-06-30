using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Net;
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

        private static HttpStatusCode PageResponse(WebRequest request, out string xmlResponseData)
        {
            var responseCode = HttpStatusCode.Ambiguous;
            string xmlResponse = string.Empty;

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                responseCode = response.StatusCode;
                MsgOutput("Retrieving response from url ", request.RequestUri.AbsoluteUri);
                MsgOutput("Response status ", response.StatusDescription);
                MsgOutput(string.Format("Response code received was [{0}]",responseCode.ToString()));
                var receiveStream = response.GetResponseStream();

                var readStream = new StreamReader(receiveStream, Encoding.UTF8);

                xmlResponse = readStream.ReadToEnd();
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

        public static HttpStatusCode GetPageResponse(string webPage, string method)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            HttpWebRequest webRequest = null;
            if (webPage.Contains("https:"))
            {
                ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
            }

            try
            {
                webRequest = (HttpWebRequest)WebRequest.Create(webPage);
            }
            catch (UriFormatException uriFormatException)
            {
                MsgOutput("Unable to determine WebSite for validation ", webPage);
                MsgOutput("Reason : ", uriFormatException.Message);
                if (uriFormatException.InnerException != null)
                {
                    TestCheck.AssertFailTest(string.Format("URI format exception - inner exception [{0}]", uriFormatException.InnerException.Message));
                }
                TestCheck.AssertFailTest(string.Format("URI format exception [{0}]", uriFormatException.Message));
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
            while ((orderSuccess != true) && (maxRetryCount != 10))
            {
                orderSuccess = ConfirmSapOrder(orderNumber, out xmlResponseData);
                WebDriver.Wait(DurationType.Second, 2);
                MsgOutput(string.Format("Retrying to validate order number [{0}] - RETRY [{1}]", orderNumber, maxRetryCount));
                maxRetryCount++;
            }
            return orderSuccess == true;
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
                request = (HttpWebRequest)WebRequest.Create(url);
            }
            catch (UriFormatException uriFormatException)
            {
                MsgOutput("Unable to determine WebSite for validation ", url);
                MsgOutput("Reason : ", uriFormatException.Message);
                if (uriFormatException.InnerException != null)
                {
                    TestCheck.AssertFailTest(string.Format("URI format exception - inner exception [{0}]", uriFormatException.InnerException.Message));
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

            roleCheckUrl = string.Format("{0}AddRole.aspx?email={1}&role=" + @"{2}", roleCheckUrl, userAccountEmail, role);
            var newString = roleCheckUrl.Replace(@"\\", @"\");

            try
            {
                // Create request
                request = (HttpWebRequest)WebRequest.Create(newString);
            }
            catch (UriFormatException uriFormatException)
            {
                MsgOutput("Unable to determine WebSite for validation ", newString);
                MsgOutput("Reason : ", uriFormatException.Message);
                if (uriFormatException.InnerException != null)
                {
                    TestCheck.AssertFailTest(string.Format("URI format exception - inner exception [{0}]", uriFormatException.InnerException.Message));
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
        /// GetOrpActivationCode()
        /// 
        /// </summary>
        private static SqlConnection GetSqlConnection()
        {
            const string server = @"BIELT348\SQL2008DEV";
            //const string username = @"EU\EUSiteCoreTestAuto";
            const string username = @"AutoTestLocalUser";
            const string password = "@utoT3stL0c@lUs3r";
            const string database = "Brother_MM_UserData";

            var connectionString = "Data Source=" + server + ";";
            connectionString += "User ID=" + username + ";";
            connectionString += "Password=" + password + ";";
            connectionString += "Initial Catalog=" + database;

            var sqlConnection = new SqlConnection();
            try
            {
                sqlConnection.ConnectionString = connectionString;
                sqlConnection.Open();
            }
            catch (SqlException sqlException)
            {
                MsgOutput(string.Format("Sql connection error - {0}", sqlException.Message));
                if (sqlConnection != null)
                    sqlConnection.Dispose();
            }
            return sqlConnection;
        }

        /// <summary>
        /// GetOrpDealerId()
        /// 
        /// </summary>
        public static Guid GetOrpDealerId(string emailAddress)
        {
            var sqlConnection = GetSqlConnection();
            var sql = string.Format("SELECT DealershipId FROM Dealership WHERE (Email = '{0}')", emailAddress);
            var sqlCmd = new SqlCommand(sql, sqlConnection);
            var dealershipId = Guid.Empty;

            using (sqlConnection)
            {
                using (var reader = sqlCmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (!reader.HasRows) return Guid.Empty;
                    // Read advances to the next row.
                    while (reader.Read())
                    {
                        dealershipId = reader.GetGuid(reader.GetOrdinal("DealershipId"));
                    }
                    reader.Close();
                }
            }
            sqlConnection.Close();
            return dealershipId;
        }

        /// <summary>
        /// GetOrpActivationCode()
        /// 
        /// </summary>
        public static string GetOrpActivationCode(Guid dealershipId, int licenseTerm, int numLicenses, string comment)
        {
            var sqlConnection = GetSqlConnection();

            var sql = string.Format("SELECT ActivationCode, DealershipId, LicenceType, TermInMonths, DateActivated, DateCreated, NumberOfLicences, Comment FROM ActivationCode WHERE DealershipId = '{0}' AND (DateActivated IS NULL) AND (Comment ='{1}') ORDER BY DateCreated DESC", dealershipId, comment); 

            var sqlCmd = new SqlCommand(sql, sqlConnection);
            var codeActivated = false;
            var activationCode = string.Empty;

            using (sqlConnection)
            {
                using (var reader = sqlCmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (!reader.HasRows) return "";
                    // Read advances to the next row.
                    while (reader.Read())
                    {
                        activationCode = reader.GetString(reader.GetOrdinal("ActivationCode"));
                        try
                        {
                            // Double check the code has not already been activated
                            var dateActivated = reader.GetDateTime(reader.GetOrdinal("DateActivated"));
                            codeActivated = true;
                        }
                        catch (SqlNullValueException fieldIsNull)
                        {
                            MsgOutput("Activation code has not activated");
                        }
                    }
                }
            }
            return !codeActivated ? activationCode : string.Empty;
        }
        
        /// <summary>
        /// Get site statistics
        /// </summary>
        public static void GetSiteStatistics(string webSite)
        {





        }

        /// <summary>
        /// Given a starting page, returns a resonse back from any link on that page
        /// </summary>
        /// <param name="startPage">Starting page to validate responses</param>
        public static bool ValidatePageLinks(string startPage)
        {
            return true;
        }
    }

    public class TrustAllCertificatePolicy : System.Net.ICertificatePolicy
    {
        public TrustAllCertificatePolicy()
        { }

        public bool CheckValidationResult(ServicePoint sp,
         X509Certificate cert, WebRequest req, int problem)
        {
            return true;
        }
    }
}
