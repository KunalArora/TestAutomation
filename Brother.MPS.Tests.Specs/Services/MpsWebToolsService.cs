using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Models;
using Brother.Tests.Specs.Domain;
using Brother.Tests.Common.Logging;
using Brother.Tests.Specs.Domain;
using Brother.Tests.Specs.Resolvers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;

namespace Brother.Tests.Specs.Services
{
    public class MpsWebToolsService : IMpsWebToolsService
    {
        private readonly IUrlResolver _urlResolver;
        private readonly IWebRequestService _webRequestService;
        private readonly IContextData _contextData;
        private readonly ILoggingService _loggingService;
        private string _baseUrl = string.Empty;
        private string _baseUrlWithoutMps2 = string.Empty;
        private string _authTokenName = "X-BROTHER-Auth";

        public MpsWebToolsService(IUrlResolver urlResolver, IWebRequestService webRequestService, IContextData contextData, ILoggingService loggingService)
        {
            _urlResolver = urlResolver;
            _webRequestService = webRequestService;
            _contextData = contextData;
            _loggingService = loggingService;
            _baseUrl = string.Format("{0}/sitecore/admin/integration/mps2/{{0}}", _urlResolver.CmsUrl);
            _baseUrlWithoutMps2 = string.Format("{0}/sitecore/admin/integration/{{0}}", _urlResolver.CmsUrl).Replace("https://", "http://");

        }

        private void ExecuteWebTool(string url, string authToken = null)
        {
            _loggingService.WriteLogOnMethodEntry(url, authToken);

            var additionalHeaders = new Dictionary<string, string> { { _authTokenName, authToken ?? AuthToken() } };
            var response = _webRequestService.GetPageResponse(url, "GET", 10, null, null, additionalHeaders);

            Console.WriteLine("Executing web tool {0}: response {1}", url, response.ResponseBody);
        }

        private WebPageResponse GetWebToolResponse(string url, string authToken = null)
        {
            _loggingService.WriteLogOnMethodEntry(url, authToken);

            var additionalHeaders = new Dictionary<string, string> { { _authTokenName, authToken ?? AuthToken() } };
            var response = _webRequestService.GetPageResponse(url, "GET", 10, null, null, additionalHeaders);

            Console.WriteLine("Executing web tool {0}: response {1}", url, response.ResponseBody);

            return response;
        }

        public void RecycleSerialNumber(string serialNumber)
        {
            string actionPath = string.Format("recycleserial.aspx?serial={0}", serialNumber);
            string url = string.Format(_baseUrl, actionPath);

            ExecuteWebTool(url);
        }

        public void SetCustomerSapId(int customerId, string sapId)
        {
            throw new NotImplementedException();
        }

        public void SetPersonSapId(int personId, string sapId)
        {
            throw new NotImplementedException();
        }

        public void RemoveConsumableOrderById(int orderId)
        {
            _loggingService.WriteLogOnMethodEntry(orderId);

            string actionPath = string.Format("removeconsumableorderbyid.aspx?orderid={0}", orderId.ToString());
            string url = string.Format(_baseUrl, actionPath);

            ExecuteWebTool(url);
        }

        public void RemoveConsumableOrderByInstalledPrinter(string serialNumber)
        {
            _loggingService.WriteLogOnMethodEntry(serialNumber);

            string actionPath = string.Format("removeconsumableorderbyinstalledprinter.aspx?serial={0}", serialNumber);
            string url = string.Format(_baseUrl, actionPath);

            ExecuteWebTool(url);
        }

        public void SetConsumableOrderStatus(int orderId, int statusId)
        {
            _loggingService.WriteLogOnMethodEntry(orderId, statusId);

            string actionPath = string.Format("setconsumableorderstatus.aspx?orderid={0}&statusid={1}", orderId.ToString(), statusId.ToString());
            string url = string.Format(_baseUrl, actionPath);

            ExecuteWebTool(url);
        }

        public void RegisterCustomer(string idAsMailAddress, string password = "password", string firstName = "John", string lastName = "Doe", string maxmind = CountryIso.UnitedKingdom, string culture = "en")
        {
            _loggingService.WriteLogOnMethodEntry(idAsMailAddress, password, firstName, lastName, maxmind, culture);

            if (string.IsNullOrEmpty(culture)) { TestCheck.AssertFailTest("Culture value cannot be null or empty"); }
            else if (culture.ToLower().Equals("en-gb")) { culture = "en"; } // Note: This is done as BOL doesn't support "en-GB" culture value yet

            string actionPath = string.Format("registeruser.aspx?email={0}&password={1}&firstname={2}&lastname={3}&maxmind={4}&culture={5}",
                WebUtility.UrlEncode(idAsMailAddress), WebUtility.UrlEncode(password), WebUtility.UrlEncode(firstName), WebUtility.UrlEncode(lastName), WebUtility.UrlEncode(maxmind), WebUtility.UrlEncode(culture));

            string url = string.Format(_baseUrlWithoutMps2, actionPath);

            ExecuteWebTool(url);
        }

        public SwapRequestDetail GetSwapRequestDetail(int installedPrinterId)
        {
            _loggingService.WriteLogOnMethodEntry(installedPrinterId);

            string actionPath = string.Format("automation/getswaprequestdetail.aspx?installedprinterid={0}", installedPrinterId.ToString());
            string url = string.Format(_baseUrl, actionPath);

            var response = GetWebToolResponse(url);

            return JsonConvert.DeserializeObject<SwapRequestDetail>(response.ResponseBody);
        }

        private string AuthToken()
        {
            var authToken = string.Empty;

            switch (_contextData.Environment)
            {
                case "DEV":
                    authToken = @"OX6Z{mO~nQ87rE!32j6Sjo!21@+`by";
                    break;
                case "UAT":
                    authToken = @".Kol%CV#<X$6o4C4/0WKxK36yYaH10";
                    break;
                case "TEST":
                    authToken = @"7H85ss+cZmJuJ$1q_-o2C$2WlN]C^V";
                    break;
            }

            return authToken;
        }

        public void RemoveProductionSmokeTests()
        {
            string actionPath = "automation/deletesmokeproposals.aspx";
            string url = string.Format(_baseUrl, actionPath);

            var response = GetWebToolResponse(url, @"0<*87kV?_dtqrr?5+S<L6?W(BO;bF$"); //production auth header       

            if (response.Headers["Brother-CommandStatus"].ToUpper() == "NO_SMOKE_PROPOSALS_FOUND")
            {
                _loggingService.WriteLog(LoggingLevel.INFO, "No smoke proposals found to remove");
            }
            else
            {
                _loggingService.WriteLog(LoggingLevel.INFO, response.ResponseBody);
            }
        }

        public void RegisterRole(string emailAddress, string role)
        {
            _loggingService.WriteLogOnMethodEntry(emailAddress, role);

            string actionPath = string.Format("addrole.aspx?email={0}&role={1}", emailAddress, role);
            string url = string.Format(_baseUrlWithoutMps2, actionPath);

            ExecuteWebTool(url);
        }
    }
}
