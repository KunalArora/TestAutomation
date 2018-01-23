using System;
using System.Collections.Generic;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Domain;

namespace Brother.Tests.Specs.Services
{
    public class ContractShiftService : IContractShiftService
    {
        private readonly IUrlResolver _urlResolver;
        private readonly IWebRequestService _webRequestService;
        private string _commandBaseUrl = string.Empty;
        private string _authTokenName = "X-BROTHER-Auth";
        private string _authToken = @".Kol%CV#<X$6o4C4/0WKxK36yYaH10"; //UAT only - extend to other environments

        public ContractShiftService(IUrlResolver urlResolver, IWebRequestService webRequestService)
        {
            _urlResolver = urlResolver;
            _webRequestService = webRequestService;
            _commandBaseUrl = string.Format("{0}/sitecore/admin/integration/mps2/contracttimeshift.aspx?contractid={{0}}&timeoffset={{1}}&timeoffsetunit={{2}}&generateprintcounts={{3}}&generateinvoices={{4}}&printvolume={{5}}", _urlResolver.CmsUrl);
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
            var additionalHeaders = new Dictionary<string, string> { { _authTokenName, _authToken } };
            var startTime = DateTime.UtcNow;

            do
            {
                var response = _webRequestService.GetPageResponse(url, "GET", timeOut, null, null, additionalHeaders);
                if (ContractShiftCommandSuccess(response))
                {
                    break;
                }

            } while (retry && (DateTime.UtcNow < startTime.AddSeconds(retryFor)));

        }

        private bool ContractShiftCommandSuccess(WebPageResponse webPageResponse)
        {
            //Update this method to use response headers when runcommand has been updated
            if (webPageResponse.ResponseBody.Contains("Failure"))
            {
                Console.WriteLine("Call to runcommand failed");
                return false;
            }

            if (webPageResponse.ResponseBody.Contains("Already running"))
            {
                Console.WriteLine("Command is already running");
                return false;
            }

            if (webPageResponse.ResponseBody.Contains("Command run"))
            {
                Console.WriteLine("Command successful");
                return true;
            }

            Console.WriteLine("Unable to determine command status");
            return false;
        }

        public void ContractTimeShiftCommand(int contractId, int timeoffset, string timeoffsetunit, bool generateprintcounts, bool generateinvoices, string printvolume)
        {
            string commandUrl = string.Format(_commandBaseUrl, contractId, timeoffset, timeoffsetunit, generateprintcounts, generateinvoices, printvolume);

            ExecuteContractShiftCommand(commandUrl);
        }

    }
}
