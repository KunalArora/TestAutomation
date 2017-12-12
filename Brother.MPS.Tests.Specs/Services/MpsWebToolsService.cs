﻿using Brother.Tests.Specs.Resolvers;
using System;
using System.Collections.Generic;
using System.Net;

namespace Brother.Tests.Specs.Services
{
    public class MpsWebToolsService : IMpsWebToolsService
    {
        private readonly IUrlResolver _urlResolver;
        private readonly IWebRequestService _webRequestService;
        private string _baseUrl = string.Empty;
        private string _baseUrlWithoutMps2 = string.Empty;
        private string _authTokenName = "X-BROTHER-Auth";
        private string _authToken = @".Kol%CV#<X$6o4C4/0WKxK36yYaH10"; //UAT only - extend to other environments

        public MpsWebToolsService(IUrlResolver urlResolver, IWebRequestService webRequestService)
        {
            _urlResolver = urlResolver;
            _webRequestService = webRequestService;
            _baseUrl = string.Format("{0}/sitecore/admin/integration/mps2/{{0}}", _urlResolver.CmsUrl);
            _baseUrlWithoutMps2 = string.Format("{0}/sitecore/admin/integration/{{0}}", _urlResolver.CmsUrl).Replace("https://", "http://");

        }

        private void ExecuteWebTool(string url)
        {
            var additionalHeaders = new Dictionary<string, string> { { _authTokenName, _authToken } };
            var response = _webRequestService.GetPageResponse(url, "GET", 10, null, null, additionalHeaders);

            Console.WriteLine("Executing web tool {0}: response {1}", url, response.ResponseBody);
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
            string actionPath = string.Format("removeconsumableorderbyid.aspx?orderid={0}", orderId.ToString());
            string url = string.Format(_baseUrl, actionPath);

            ExecuteWebTool(url);
        }

        public void RemoveConsumableOrderByInstalledPrinter(string serialNumber)
        {
            string actionPath = string.Format("removeconsumableorderbyinstalledprinter.aspx?serial={0}", serialNumber);
            string url = string.Format(_baseUrl, actionPath);

            ExecuteWebTool(url);            
        }

        public void SetConsumableOrderStatus(int orderId, int statusId)
        {
            string actionPath = string.Format("setconsumableorderstatus.aspx?orderid={0}&statusid={1}", orderId.ToString(), statusId.ToString());
            string url = string.Format(_baseUrl, actionPath);

            ExecuteWebTool(url);
        }

        public void RegisterCustomer(string idAsMailAddress, string password = "password", string firstName = "John", string lastName = "Doe", string maxmind = "GB")
        {
            string actionPath = string.Format("registeruser.aspx?email={0}&password={1}&firstname={2}&lastname={3}&maxmind={4}",
                WebUtility.UrlEncode(idAsMailAddress), WebUtility.UrlEncode(password), WebUtility.UrlEncode(firstName), WebUtility.UrlEncode(lastName), maxmind);
            string url = string.Format(_baseUrlWithoutMps2, actionPath);

            ExecuteWebTool(url);

        }

    }
}