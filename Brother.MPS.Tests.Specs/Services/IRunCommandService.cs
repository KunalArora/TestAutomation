using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Services
{
    public interface IRunCommandService
    {
        void RunCheckForSilentEmailDevicesCommandJob();
        void RunCheckForSilentMedioDevicesCommandJob();
        void RunClickRateInvoiceCommandJob();
    }
}
