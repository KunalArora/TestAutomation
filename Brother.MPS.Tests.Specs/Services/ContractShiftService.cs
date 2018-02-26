using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
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
        private string _commandBaseUrl = string.Empty;
        private string _authTokenName = "X-BROTHER-Auth";
        private string _authToken = @".Kol%CV#<X$6o4C4/0WKxK36yYaH10"; //UAT only - extend to other environments
        private readonly int _warningSec;

        private ILoggingService LoggingService { get; set; }

        public ContractShiftService(IUrlResolver urlResolver, IWebRequestService webRequestService, ILoggingService loggingService)
        {
            _urlResolver = urlResolver;
            _webRequestService = webRequestService;
            _commandBaseUrl = string.Format("{0}/sitecore/admin/integration/mps2/contracttimeshift.aspx?contractid={{0}}&timeoffset={{1}}&timeoffsetunit={{2}}&generateprintcounts={{3}}&generateinvoices={{4}}&printvolume={{5}}", _urlResolver.CmsUrl);
            LoggingService = loggingService;
            _warningSec = 20;
        }


        /// <summary>
        /// Calls ContractShiftCommand
        /// </summary>
        /// <param name="url">Full url to contractshiftcommand including parameters</param>
        /// <param name="timeOut">Timeout, in seconds, for a single call to contractshiftcommand</param>
        private void ExecuteContractShiftCommand(string url, int timeOut = 60)
        {
            LoggingService.WriteLogOnMethodEntry(url, timeOut);
            var additionalHeaders = new Dictionary<string, string> { { _authTokenName, _authToken } };
            var startTime = DateTime.UtcNow;

            var response = _webRequestService.GetPageResponse(url, "GET", timeOut, null, null, additionalHeaders);
            ContractShiftCommandSuccess(response);
        }

        private bool ContractShiftCommandSuccess(WebPageResponse webPageResponse)
        {
            if (webPageResponse.Headers["brother-commandstatus"].Equals("SUCCESS"))
            {
                LoggingService.WriteLog(LoggingLevel.INFO, "Contract time shift successful");
                return true;
            }

            LoggingService.WriteLog(LoggingLevel.FAILURE, "Contract time shift failed");
            return false;
        }

        public void ContractTimeShiftCommand(int contractId, int timeoffset, string timeoffsetunit, bool generateprintcounts, bool generateinvoices, string printvolume)
        {
            LoggingService.WriteLogOnMethodEntry(contractId, timeoffset, timeoffsetunit, generateprintcounts, generateinvoices, printvolume);
            string commandUrl = string.Format(_commandBaseUrl, contractId, timeoffset, timeoffsetunit, generateprintcounts, generateinvoices, printvolume);

            LoggingService.WriteLogWhenWarningTimeoutExceeds(l => { ExecuteContractShiftCommand(commandUrl); return true; }, _warningSec, "Contract Shift API is responding slow");
        }
    }
}
