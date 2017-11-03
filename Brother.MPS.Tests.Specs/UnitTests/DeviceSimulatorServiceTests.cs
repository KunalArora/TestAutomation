using Brother.Tests.Specs.Services;
using NUnit.Framework;

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
            _deviceSimulatorService = new DeviceSimulatorService();
        }

        [Test]
        public void CanCreateVirtualDevice()
        {
            var deviceId = _deviceSimulatorService.CreateNewDevice("MFC-L8650CDW", "A1B234567");
        }
    }
}

