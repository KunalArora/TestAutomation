using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Domain;
using Brother.Tests.Specs.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brother.Tests.Specs.Services
{
    public class ContractShiftService : IContractShiftService
    {
        private readonly IUrlResolver _urlResolver;
        private readonly IWebRequestService _webRequestService;
        private readonly ITranslationService _translationService;
        private readonly IContextData _contextData;


        private string _commandBaseUrl = string.Empty;
        private string _authTokenName = "X-BROTHER-Auth";
        private string _authToken = @".Kol%CV#<X$6o4C4/0WKxK36yYaH10"; //UAT only - extend to other environments
        private ILoggingService LoggingService { get; set; }

        public ContractShiftService(IUrlResolver urlResolver, IWebRequestService webRequestService, ILoggingService LoggingService,
            ITranslationService translationService,
            IContextData contextData
            )
        {
            _urlResolver = urlResolver;
            _webRequestService = webRequestService;
            _commandBaseUrl = string.Format("{0}/sitecore/admin/integration/mps2/contracttimeshift.aspx?contractid={{0}}&timeoffset={{1}}&timeoffsetunit={{2}}&generateprintcounts={{3}}&generateinvoices={{4}}&printvolume={{5}}", _urlResolver.CmsUrl);
            this.LoggingService = LoggingService;
            _translationService = translationService;
            _contextData = contextData;
        }


        /// <summary>
        /// Calls ContractShiftCommand and optionally retries
        /// </summary>
        /// <param name="url">Full url to contractshiftcommand including parameters</param>
        /// <param name="timeOut">Timeout, in seconds, for a single call to contractshiftcommand</param>
        /// <param name="retry">Retry if command fails or is already running</param>
        /// <param name="retryInterval">The time to wait, in seconds, between retries</param>
        /// <param name="retryFor">The overall time, in seconds, that the command should be retried for</param>
        private void ExecuteContractShiftCommand(string url, int timeOut = 30, bool retry = false, int retryInterval = 2, int retryFor = 60)
        {
            LoggingService.WriteLogOnMethodEntry(url, timeOut, retry, retryInterval, retryFor);
            var additionalHeaders = new Dictionary<string, string> { { _authTokenName, _authToken } };
            var startTime = DateTime.UtcNow;

            do
            {
                var response = _webRequestService.GetPageResponse(url, "GET", timeOut, null, null, additionalHeaders);
                if (ContractShiftCommandSuccess(response))
                {
                    return;
                }

            } while (retry && (DateTime.UtcNow < startTime.AddSeconds(retryFor)));
            //$debug
            //throw new Exception("ExecuteContractShiftCommand retry error");
        }

        private bool ContractShiftCommandSuccess(WebPageResponse webPageResponse)
        {
            LoggingService.WriteLogOnMethodEntry(webPageResponse);
            //Update this method to use response headers when runcommand has been updated
            try
            {
                return webPageResponse.Headers.GetValues("Brother-CommandStatus").Any(val => val.ToUpper() == "SUCCESS");
            }
            catch
            {
                return true; // $debug
                //return false;
            }
            
        }

        public void ContractTimeShiftCommand(int contractId, int timeoffset, string timeoffsetunit, bool generateprintcounts, bool generateinvoices, string printvolume)
        {
            LoggingService.WriteLogOnMethodEntry(contractId, timeoffset, timeoffsetunit, generateprintcounts, generateinvoices, printvolume);
            string commandUrl = string.Format(_commandBaseUrl, contractId, timeoffset, timeoffsetunit, generateprintcounts, generateinvoices, printvolume);

            ExecuteContractShiftCommand(commandUrl);
        }

    }
}
