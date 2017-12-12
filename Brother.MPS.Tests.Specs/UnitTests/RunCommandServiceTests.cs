﻿using Brother.Tests.Specs.ContextData;
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
    public class RunCommandServiceTests
    {
        private RunCommandService _runCommandService;

        public RunCommandServiceTests()
        {
            _runCommandService = new RunCommandService(new DefaultUrlResolver(new MpsContextData{Environment = "UAT", Country = new Country{ DomainSuffix = "co.uk" } }), new WebRequestService());
        }

        [Test]
        public void CanRunCheckForSilentEmailDevices()
        {
            _runCommandService.RunCheckForSilentEmailDevicesCommand();
        }
    }
}
