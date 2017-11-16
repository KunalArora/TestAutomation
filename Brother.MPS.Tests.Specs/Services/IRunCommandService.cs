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
    }
}
