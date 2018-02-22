using System;
using System.Collections.Generic;
﻿using Brother.Tests.Common.Logging;
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

        private ILoggingService LoggingService { get; set; }

        public RunCommandService(IUrlResolver urlResolver, IWebRequestService webRequestService, ILoggingService loggingService )
        {
            _urlResolver = urlResolver;
            _webRequestService = webRequestService;
            _commandBaseUrl = string.Format("{0}/sitecore/admin/integration/mps2/runcommand.aspx?command={{0}}", _urlResolver.CmsUrl);
            LoggingService = loggingService;
        }

        /// <summary>
        /// Calls RunCommand and optionally retries
        /// </summary>
        /// <param name="url">Full url to runcommand including parameters</param>
        /// <param name="timeOut">Timeout, in seconds, for a single call to runcommand</param>
        /// <param name="retry">Retry if command fails or is already running</param>
        /// <param name="retryInterval">The time to wait, in seconds, between retries</param>
        /// <param name="retryFor">The overall time, in seconds, that the command should be retried for</param>
        private void ExecuteRunCommand(string url, int timeOut = 60, bool retry = false, int retryInterval = 2, int retryFor = 60)
        {
            LoggingService.WriteLogOnMethodEntry(url, timeOut, retry, retryInterval, retryFor);
            var additionalHeaders = new Dictionary<string, string> {{_authTokenName, _authToken}};
            var startTime = DateTime.UtcNow;

            do
            {
                var response = _webRequestService.GetPageResponse(url, "GET", timeOut, null, null, additionalHeaders);
                if (RunCommandSuccess(response))
                {
                    return;
                }

            } while (retry && (DateTime.UtcNow < startTime.AddSeconds(retryFor)));
    //        throw new Exception("ExecuteRunCommand retry error");
        }

        private bool RunCommandSuccess(WebPageResponse webPageResponse)
        {
            LoggingService.WriteLogOnMethodEntry(webPageResponse);
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
            LoggingService.WriteLogOnMethodEntry();
            string commandName = "MPS:SystemJobCreateCustomerAndPersonCommand";
            string commandUrl = string.Format(_commandBaseUrl, commandName);

           ExecuteRunCommand(commandUrl);
        }

        public void RunRaiseClickRateInvoicesCommand()
        {

        }

        public void RunInstallationCompleteCommand()
        {
            
        }

        public void RunMeterReadEmailSyncCommand()
        {
            LoggingService.WriteLogOnMethodEntry();
        }

        public void RunMeterReadCloudSyncCommand(int proposalId) // Pass AgreementId in case of Type 3
        {
            LoggingService.WriteLogOnMethodEntry(proposalId);
            string commandName = string.Format("MPS:NEW:MeterReadCloudSyncCommand&ProposalId={0}&CountryIso=GB", proposalId);
            string commandUrl = string.Format(_commandBaseUrl, commandName);

            ExecuteRunCommand(commandUrl);
        }

        public void RunConsumableOrderRequestsCommand()
        {
            LoggingService.WriteLogOnMethodEntry();
            string commandName = string.Format("MPS:ConsumableOrderRequestsCommand");
            string commandUrl = string.Format(_commandBaseUrl, commandName);

            ExecuteRunCommand(commandUrl);
        }

        public void RunCloseConsumableOrdersCommand()
        {
            LoggingService.WriteLogOnMethodEntry();
        }

        public void RunPollConsumableOrderStatusCommand()
        {
            LoggingService.WriteLogOnMethodEntry();
        }

        public void RunCheckForSilentEmailDevicesCommand()
        {
            LoggingService.WriteLogOnMethodEntry();
            string commandName = "MPS:CheckForSilentEmailDevicesCommand";
            string commandUrl = string.Format(_commandBaseUrl, commandName);

            ExecuteRunCommand(commandUrl);
        }

        public void RunCheckForSilentCloudDevicesCommand()
        {
            LoggingService.WriteLogOnMethodEntry();
        }

        public void RunCreateConsumableOrderCommand()
        {
            string commandName = "MPS:SystemJobCreateConsumableOrderCommand";
            string commandUrl = string.Format(_commandBaseUrl, commandName);

            ExecuteRunCommand(commandUrl);
        }

        public void RunSetupInstalledPrintersCommand()
        {
            LoggingService.WriteLogOnMethodEntry();
            string commandName = "MPS:SystemJobSetupInstalledPrintersCommand";
            string commandUrl = string.Format(_commandBaseUrl, commandName);

            ExecuteRunCommand(commandUrl);
        }

        public void RunStartContractCommand()
        {
            string commandName = "MPS:SystemJobStartContractCommand";
            string commandUrl = string.Format(_commandBaseUrl, commandName);

            ExecuteRunCommand(commandUrl);
        }

    }
}
