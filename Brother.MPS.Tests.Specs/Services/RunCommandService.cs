using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Logging;
using Brother.Tests.Specs.Domain;
using Brother.Tests.Specs.Resolvers;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Brother.Tests.Specs.Services
{
    public class RunCommandService : IRunCommandService
    {
        private readonly IUrlResolver _urlResolver;
        private readonly IWebRequestService _webRequestService;
        private readonly IContextData _contextData;
        private string _commandBaseUrl = string.Empty;
        private string _authTokenName = "X-BROTHER-Auth";

        private ILoggingService LoggingService { get; set; }

        public RunCommandService(IUrlResolver urlResolver, IWebRequestService webRequestService, ILoggingService loggingService, IContextData contextData)
        {
            _urlResolver = urlResolver;
            _webRequestService = webRequestService;
            _commandBaseUrl = string.Format("{0}/sitecore/admin/integration/mps2/runcommand.aspx?command={{0}}", _urlResolver.CmsUrl);
            LoggingService = loggingService;
            _contextData = contextData;
        }

        /// <summary>
        /// Calls RunCommand and optionally retries
        /// </summary>
        /// <param name="url">Full url to runcommand including parameters</param>
        /// <param name="timeOut">Timeout, in seconds, for a single call to runcommand</param>
        /// <param name="retry">Retry if command fails or is already running</param>
        /// <param name="retryInterval">The time to wait, in seconds, between retries</param>
        /// <param name="retryFor">The overall time, in seconds, that the command should be retried for</param>
        private void ExecuteRunCommand(string url, int timeOut = 300, bool retry = true, int retryInterval = 10, int retryFor = 300)
        {
            LoggingService.WriteLogOnMethodEntry(url, timeOut, retry, retryInterval, retryFor);
            var warningSec = retryFor / 5;
            LoggingService.WriteLogWhenWarningTimeoutExceeds(ls =>
           {
               var additionalHeaders = new Dictionary<string, string> { { _authTokenName, AuthToken() } };
               var startTime = DateTime.UtcNow;
               var endTime = startTime.AddSeconds(retryFor);

               if (!CommandIsValidForEnvironment(url))
               {
                   var message = string.Format("Command url {0} is not valid for the current environment", url);
                   LoggingService.WriteLog(LoggingLevel.FAILURE, message);
                   throw new Exception(message);
               }

               do
               {
                   var response = _webRequestService.GetPageResponse(url, "GET", timeOut, null, null, additionalHeaders);
                   if (RunCommandSuccess(response))
                   {
                       return true;
                   }
                   if(retryInterval > 0)
                   {
                       System.Threading.Tasks.Task.Delay(retryInterval * 1000);
                   }
               } while (retry && (DateTime.UtcNow < endTime));
               Assert.Fail("ExecuteRunCommand timeout timeOut={0}, retryFor={1}, url={2}", timeOut, retryFor,url);
               return false; // dummy
           }, warningSec, "too slow url=" + url);
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
                case "PROD":
                    authToken = @"0<*87kV?_dtqrr?5+S<L6?W(BO;bF$";
                    break;
            }

            return authToken;
        }

        private bool RunCommandSuccess(WebPageResponse webPageResponse)
        {
            LoggingService.WriteLogOnMethodEntry(webPageResponse);
            //Update this method to use response headers when runcommand has been updated
            if (webPageResponse.ResponseBody.Contains("Failure"))
            {
                Console.WriteLine("Call to runcommand failed");
                Assert.Fail("Call to runcommand failed");
                return false; // dummy 
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
            Assert.Fail("Unable to determine command status");
            return false; // dummy
        }

        private bool CommandIsValidForEnvironment(string commandUrl)
        {
            //Production
            if (_contextData.Environment.ToUpper() == "PROD")
            {
                if (commandUrl.Contains(RunCommands.MpsSystemJobSetupInstalledPrintersCommand))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //All commands are valid for other environments
            return true;
        }

        public void RunCreateCustomerAndPersonCommand()
        {
            LoggingService.WriteLogOnMethodEntry();
            string commandName = RunCommands.MpsSystemJobCreateCustomerAndPersonCommand;
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

        //countryIso values for BUK=GB and BIG=DE
        public void RunMeterReadCloudSyncCommand(int proposalId, string countryIso) // Pass AgreementId in case of Type 3
        {
            LoggingService.WriteLogOnMethodEntry(proposalId, countryIso);
            string commandName = string.Format("{0}&ProposalId={1}&CountryIso={2}", RunCommands.MpsNewMeterReadCloudSyncCommand, proposalId, countryIso);
            string commandUrl = string.Format(_commandBaseUrl, commandName);

            ExecuteRunCommand(commandUrl);
        }

        public void RunConsumableOrderRequestsCommand()
        {
            LoggingService.WriteLogOnMethodEntry();
            string commandName = RunCommands.MpsConsumableOrderRequestsCommand;
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
            string commandName = RunCommands.MpsCheckForSilentEmailDevicesCommand;
            string commandUrl = string.Format(_commandBaseUrl, commandName);

            ExecuteRunCommand(commandUrl);
        }

        public void RunCheckForSilentCloudDevicesCommand()
        {
            LoggingService.WriteLogOnMethodEntry();
        }

        public void RunCreateConsumableOrderCommand()
        {
            LoggingService.WriteLogOnMethodEntry();
            string commandName = RunCommands.MpsSystemJobCreateConsumableOrderCommand;
            string commandUrl = string.Format(_commandBaseUrl, commandName);

            ExecuteRunCommand(commandUrl);
        }

        public void RunSetupInstalledPrintersCommand()
        {
            LoggingService.WriteLogOnMethodEntry();
            string commandName = RunCommands.MpsSystemJobSetupInstalledPrintersCommand;
            string commandUrl = string.Format(_commandBaseUrl, commandName);

            ExecuteRunCommand(commandUrl);
        }

        public void RunStartContractCommand()
        {
            LoggingService.WriteLogOnMethodEntry();
            string commandName = RunCommands.MpsSystemJobStartContractCommand;
            string commandUrl = string.Format(_commandBaseUrl, commandName);

            ExecuteRunCommand(commandUrl);
        }

        public void RunContractClosingMonitorCommand()
        {
            LoggingService.WriteLogOnMethodEntry();
            string commandName = RunCommands.MpsContractClosingMonitorCommand;
            string commandUrl = string.Format(_commandBaseUrl, commandName);

            ExecuteRunCommand(commandUrl);
        }

        public void RunSendSwapRequestCommand()
        {
            LoggingService.WriteLogOnMethodEntry();
            string commandName = RunCommands.MpsSystemJobSendSwapRequestCommand;
            string commandUrl = string.Format(_commandBaseUrl, commandName);

            ExecuteRunCommand(commandUrl);
        }
    }
}
