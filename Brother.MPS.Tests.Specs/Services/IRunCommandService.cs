using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Services
{
    public interface IRunCommandService
    {
        void RunCreateCustomerAndPersonCommand();
        void RunRaiseClickRateInvoicesCommand();
        void RunInstallationCompleteCommand();
        void RunMeterReadEmailSyncCommand();
        void RunMeterReadCloudSyncCommand(int proposalId);
        void RunConsumableOrderRequestsCommand();
        void RunCloseConsumableOrdersCommand();
        void RunPollConsumableOrderStatusCommand();
        void RunCheckForSilentEmailDevicesCommand();
        void RunCheckForSilentCloudDevicesCommand();
        void RunCreateConsumableOrderCommand();
        void RunContractClosingMonitorCommand();

        #region Exclusively Type 3 

        /// <summary>
        /// Job to retrieve BOC pin per device in the background
        /// </summary>
        void RunSetupInstalledPrintersCommand(); // Only for Type 3

        /// <summary>
        /// Job to force start a contract (/agreement) & put it into "Running" status
        /// </summary>
        void RunStartContractCommand();

        /// <summary>
        /// Job to send device into swapping stage & generate BOC pin
        /// </summary>
        void RunSendSwapRequestCommand();


        #endregion
    }
}
