using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using NUnit.Framework;

namespace Brother.Tests.Specs.UnitTests
{
    /// <summary>
    /// A simple test harness
    /// </summary>
    [TestFixture(Category = "Integration")]
    public class MpsWebToolsServiceTests
    {
        private MpsWebToolsService _mpsWebToolsService;

        public MpsWebToolsServiceTests()
        {
            _mpsWebToolsService = new MpsWebToolsService(new DefaultUrlResolver(new MpsContextData { Environment = "DEV", Country = new Country { DomainSuffix = "co.uk" } }), new WebRequestService(new MpsLoggingConsole(new LoggingServiceSettings())), new MpsContextData(), new MpsLoggingConsole(new LoggingServiceSettings()));
        }

        [Test]
        public void CanRecycleSerialNumber()
        {
            _mpsWebToolsService.RecycleSerialNumber("A1T010521");
        }

        [Test]
        public void CanRemoveConsumableOrderById()
        {
            _mpsWebToolsService.RemoveConsumableOrderById(52508);
        }

        [Test]
        public void CanGetSwapRequestDetail()
        {
            var swapRequestDetail = _mpsWebToolsService.GetSwapRequestDetail(4634);
        }
    }
}

