using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Specs.Domain.DeviceSimulator;

namespace Brother.Tests.Specs.Services
{
    public interface IDeviceSimulatorService
    {
        string CreateNewDevice(string model, string serialNumber);
        void RegisterNewDevice(string deviceId, string installationPin);
        void ChangeDeviceStatus(string deviceId, bool online, bool subscribe);
        void NotifyBocOfDeviceChanges(string deviceId);
        void SetSupply(SetSupplyRequest setSupplyRequest);
        void SetPrintCounts(string deviceId, int monoPrintCount, int colourPrintCount);
        string CreateNewDeviceId();
        void RaiseConsumableOrder(string deviceId, string tonerInkBlackStatus, string tonerInkCyanStatus, string tonerInkMagentaStatus, string tonerInkYellowStatus);

    }
}
