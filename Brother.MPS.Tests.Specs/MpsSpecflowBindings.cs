using TechTalk.SpecFlow;
using Brother.Tests.Selenium.Lib.Support;
using NUnit.Framework;

namespace Brother.Tests.Specs
{
    [Binding]
    public static class MpsSpecflowBindings
    {
        [BeforeScenario]
        public static void MpsBeforeScenarioBinding()
        {
            //Hijack driver setting here so it doesn't interfere with core Brother testing
            //TODO: review with BOL team and find more suitable approach than environment variables
            var driver = TestController.CurrentDriver;
            var testParams = TestContext.Parameters;
        }
    }
}
