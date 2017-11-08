using System.Collections.Generic;
using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.DeviceSimulator;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
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
            _mpsWebToolsService = new MpsWebToolsService(new DefaultUrlResolver(new MpsContextData { Environment = "UAT", Country = new Country { DomainSuffix = "co.uk" } }), new WebRequestService());
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
    }
}

