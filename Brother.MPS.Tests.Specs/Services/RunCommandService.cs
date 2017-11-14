using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Specs.Domain;
using Brother.Tests.Specs.Resolvers;

namespace Brother.Tests.Specs.Services
{
    public class RunCommandService : IRunCommandService
    {
        private readonly IUrlResolver _urlResolver;
        private readonly IWebRequestService _webRequestService;
        private string _commandBaseUrl = string.Empty;
        private string _authTokenName = "X-BROTHER-Auth";
        private string _authToken = @".Kol%CV#<X$6o4C4/0WKxK36yYaH10"; //UAT only - extend to other environments

        public RunCommandService(IUrlResolver urlResolver, IWebRequestService webRequestService)
        {
            _urlResolver = urlResolver;
            _webRequestService = webRequestService;
            _commandBaseUrl = string.Format("{0}/sitecore/admin/integration/mps2/runcommand.aspx?command={{0}}", _urlResolver.CmsUrl);
        }

        /// <summary>
        /// Calls RunCommand and optionally retries
        /// </summary>
        /// <param name="url">Full url to runcommand including parameters</param>
        /// <param name="timeOut">Timeout, in seconds, for a single call to runcommand</param>
        /// <param name="retry">Retry if command fails or is already running</param>
        /// <param name="retryInterval">The time to wait, in seconds, between retries</param>
        /// <param name="retryFor">The overall time, in seconds, that the command should be retried for</param>
        private void ExecuteRunCommand(string url, int timeOut = 30, bool retry = false, int retryInterval = 2, int retryFor = 60)
        {
            var additionalHeaders = new Dictionary<string, string> {{_authTokenName, _authToken}};
            var startTime = DateTime.UtcNow;

            do
            {
                var response = _webRequestService.GetPageResponse(url, "GET", timeOut, null, null, additionalHeaders);
                if (RunCommandSuccess(response))
                {
                    break;
                }

            } while (retry && (DateTime.UtcNow < startTime.AddSeconds(retryFor)));
            
        }

        private bool RunCommandSuccess(WebPageResponse webPageResponse)
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

        public void RunCreateCustomerAndPersonCommand()
        {
            
        }

        public void RunRaiseClickRateInvoicesCommand()
        {

        }

        public void RunInstallationCompleteCommand()
        {
            
        }

        public void RunMeterReadEmailSyncCommand()
        {
            
        }

        public void RunMeterReadCloudSyncCommand()
        {
            
        }

        public void RunConsumableOrderRequestsCommand()
        {
            
        }

        public void RunCloseConsumableOrdersCommand()
        {
            
        }

        public void RunPollConsumableOrderStatusCommand()
        {
            
        }

        public void RunCheckForSilentEmailDevicesCommand()
        {
            string commandName = "MPS:CheckForSilentEmailDevicesCommand";
            string commandUrl = string.Format(_commandBaseUrl, commandName);

            ExecuteRunCommand(commandUrl);
        }

        public void RunCheckForSilentCloudDevicesCommand()
        {
            
        }

        public void RunCreateConsumableOrderCommand()
        {
            
        }
    }
}
