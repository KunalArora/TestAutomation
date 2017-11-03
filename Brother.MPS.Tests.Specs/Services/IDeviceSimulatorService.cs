using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Services
{
    public interface IDeviceSimulatorService
    {
        string CreateNewDevice(string model, string serialNumber);
        void RegisterNewDevice(string deviceId, string installationPin);
        void ChangeDeviceStatus(string deviceId, bool online, bool subscribe);
        void NotifyBocOfDeviceChanges(string deviceId);
        string CreateNewDeviceId();
    }
}
