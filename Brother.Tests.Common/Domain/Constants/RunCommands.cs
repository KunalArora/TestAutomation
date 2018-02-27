﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;

namespace Brother.Tests.Common.Domain.Constants
{
    public class RunCommands
    {
        public const string MpsSystemJobCreateCustomerAndPersonCommand = "MPS:SystemJobCreateCustomerAndPersonCommand";
        public const string MpsNewMeterReadCloudSyncCommand = "MPS:NEW:MeterReadCloudSyncCommand";
        public const string MpsConsumableOrderRequestsCommand = "MPS:ConsumableOrderRequestsCommand";
        public const string MpsCheckForSilentEmailDevicesCommand = "MPS:CheckForSilentEmailDevicesCommand";
        public const string MpsSystemJobCreateConsumableOrderCommand = "MPS:SystemJobCreateConsumableOrderCommand";
        public const string MpsSystemJobSetupInstalledPrintersCommand = "MPS:SystemJobSetupInstalledPrintersCommand";
        public const string MpsSystemJobStartContractCommand = "MPS:SystemJobStartContractCommand";
    }
}