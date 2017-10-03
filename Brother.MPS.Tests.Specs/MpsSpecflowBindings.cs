using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using TechTalk.SpecFlow;
using Brother.Tests.Selenium.Lib.Support;
using NUnit.Framework;

namespace Brother.Tests.Specs
{
    [Binding]
    public class MpsSpecflowBindings
    {
        [BeforeScenario]
        public void MpsBeforeScenarioBinding()
        {
            //Hijack driver setting here so it doesn't interfere with core Brother testing
            //TODO: review with BOL team and find more suitable approach than environment variables
            var driver = TestController.CurrentDriver;

            if (TestContext.Parameters.Exists("output_path"))
            {
                Helper.OutputPath = TestContext.Parameters.Get("output_path");
            } 
        }
    }
}
