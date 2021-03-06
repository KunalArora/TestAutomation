using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Logging;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Specs.Domain;
using Brother.Tests.Specs.Resolvers;
using System;
using System.Collections.Generic;

namespace Brother.Tests.Specs.Services
{
    public class ContractShiftService : IContractShiftService
    {
        private readonly IUrlResolver _urlResolver;
        private readonly IWebRequestService _webRequestService;
        private readonly IContextData _contextData;
        private string _commandBaseUrl = string.Empty;
        private string _authTokenName = "X-BROTHER-Auth";
        private readonly int _warningSec;

        private ILoggingService LoggingService { get; set; }

        public ContractShiftService(IUrlResolver urlResolver, IWebRequestService webRequestService, ILoggingService loggingService, IContextData contextData)
        {
            _urlResolver = urlResolver;
            _webRequestService = webRequestService;
            _contextData = contextData;
            _commandBaseUrl = string.Format("{0}/sitecore/admin/integration/mps2/contracttimeshift.aspx?contractid={{0}}&timeoffset={{1}}&timeoffsetunit={{2}}&generateprintcounts={{3}}&generateinvoices={{4}}&printvolume={{5}}", _urlResolver.CmsUrl);
            LoggingService = loggingService;
            _warningSec = 20;
        }


        /// <summary>
        /// Calls ContractShiftCommand
        /// </summary>
        /// <param name="url">Full url to contractshiftcommand including parameters</param>
        /// <param name="timeOut">Timeout, in seconds, for a single call to contractshiftcommand</param>
        private void ExecuteContractShiftCommand(string url, int timeOut = 300) // Increase the timeout to 300 sec temprarily to be able to do parallel testing
        {
            LoggingService.WriteLogOnMethodEntry(url, timeOut);
            var additionalHeaders = new Dictionary<string, string> { { _authTokenName, AuthToken() } };
            var startTime = DateTime.UtcNow;

            var response = _webRequestService.GetPageResponse(url, "GET", timeOut, null, null, additionalHeaders);
            CheckContractShiftCommandSuccess(response);
        }

        private void CheckContractShiftCommandSuccess(WebPageResponse webPageResponse)
        {
            if (webPageResponse.Headers["brother-commandstatus"].Equals("SUCCESS"))
            {
                LoggingService.WriteLog(LoggingLevel.INFO, "Contract time shift successful");
                return;
            }

            LoggingService.WriteLog(LoggingLevel.FAILURE, "Contract time shift failed");
            TestCheck.AssertFailTest("Contract Shift API has failed. API Response: " + webPageResponse);
        }

        public void ContractTimeShiftCommand(int contractId, int timeoffset, string timeoffsetunit, bool generateprintcounts, bool generateinvoices, string printvolume)
        {
            LoggingService.WriteLogOnMethodEntry(contractId, timeoffset, timeoffsetunit, generateprintcounts, generateinvoices, printvolume);
            string commandUrl = string.Format(_commandBaseUrl, contractId, timeoffset, timeoffsetunit, generateprintcounts, generateinvoices, printvolume);

            LoggingService.WriteLogWhenWarningTimeoutExceeds(l => { ExecuteContractShiftCommand(commandUrl); return true; }, _warningSec, "Contract Shift API is responding slow");
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
    }
}
