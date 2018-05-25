using Brother.Tests.Specs.Domain.DeviceSimulator;
using System.Collections.Generic;

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
        void SetRemainingLife(string deviceId, string tonerInkBlackRemLife, string tonerInkCyanRemLife, string tonerInkMagentaRemLife, string tonerInkYellowRemLife);
        void SetReplaceCount(string deviceId, int tonerInkBlackReplaceCount, int tonerInkCyanReplaceCount, int tonerInkMagentaReplaceCount, int tonerInkYellowReplaceCount);      
        void DeleteDevice(string deviceId);
        IEnumerable<BocSupplyItem> GetSupply(string deviceId);
    }
}
