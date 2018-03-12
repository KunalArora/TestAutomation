using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
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
    public class ContractShiftServiceTests
    {
        private ContractShiftService _contractShiftService;

        public ContractShiftServiceTests()
        {
            var loggingService = new MpsLoggingConsole(new LoggingServiceSettings());
            _contractShiftService = new ContractShiftService(new DefaultUrlResolver(new MpsContextData { Environment = "UAT", Country = new Country { DomainSuffix = "co.uk" } }), new WebRequestService(loggingService), loggingService, new MpsContextData());
        }

        [Test]
        public void CanApplyContractTimeShift()
        {
            _contractShiftService.ContractTimeShiftCommand(167109, 1, "d", false, true, "Any");
        }
    }
}

