using System.Collections.Generic;
using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Logging;
using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.Domain.DeviceSimulator;
using Brother.Tests.Specs.Services;
using NUnit.Framework;
using Brother.Tests.Common.RuntimeSettings;

namespace Brother.Tests.Specs.UnitTests
{
    /// <summary>
    /// A simple test harness
    /// </summary>
    [TestFixture(Category = "Integration")]
    public class DeviceSimulatorServiceTests
    {
        private DeviceSimulatorService _deviceSimulatorService;

        public DeviceSimulatorServiceTests()
        {
            _deviceSimulatorService = new DeviceSimulatorService(new WebRequestService(new MpsLoggingConsole(new LoggingServiceSettings())), new RuntimeSettings(null, null, null, null, null, null, null, null, null, null), new MpsLoggingConsole(new LoggingServiceSettings()), new MpsContextData());
        }

        [Test]
        public void CanCreateVirtualDevice()
        {
            var deviceId = _deviceSimulatorService.CreateNewDevice("MFC-L8650CDW", "A1B234567");
        }

        [Test]
        public void CanCreateAndDeleteVirtualDevice()
        {
            var deviceId = _deviceSimulatorService.CreateNewDevice("MFC-L8650CDW", "A1B234567");
            _deviceSimulatorService.DeleteDevice(deviceId);
        }

        [Test]
        public void ShouldNotBeAbleToDeleteNonExistentVirtualDevice()
        {
            var deviceId = "babeface-0000-0000-0000-000000000000";
            _deviceSimulatorService.DeleteDevice(deviceId);
        }

        [Test]
        public void CanRegisterVirtualDevice()
        {
            //_deviceSimulatorService.RegisterNewDevice("babeface-2ec2-43fd-9cb6-476f6ff1c132",);
        }

        [Test]
        public void CanSetSupply()
        {
            //Arrange
            var setSupplyRequest = new SetSupplyRequest
            {
                id = "babeface-2ec2-43fd-9cb6-476f6ff1c132",
                items = new List<SetSupplyRequestItem>
                {
                    new SetSupplyRequestItem {name = "TonerInk_Life_Black", value = 20},
                    new SetSupplyRequestItem {name = "TonerInk_Life_Cyan", value = 21},
                    new SetSupplyRequestItem {name = "TonerInk_Life_Magenta", value = 22},
                    new SetSupplyRequestItem {name = "TonerInk_Life_Yellow", value = 23},
                }
            };

            //Act
            _deviceSimulatorService.SetSupply(setSupplyRequest);

            //Assert
        }

        [Test]
        public void CanSetPrintCounts()
        {
            _deviceSimulatorService.SetPrintCounts("babeface-2ec2-43fd-9cb6-476f6ff1c132", 900, 100);
        }
    }
}

