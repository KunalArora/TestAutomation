using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Logging;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Services;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using BoDi;

namespace Brother.Tests.Specs.AdditionalBindings
{
    [Binding]
    public class AfterScenario
    {
        private readonly IObjectContainer _container;

        public AfterScenario(IObjectContainer container)
        {
            _container = container;
        }

        [AfterScenario]
        public void TearDown()
        {
            var webDriverFactory = _container.Resolve<IWebDriverFactory>();
            var loggingService = _container.Resolve<ILoggingService>();
            var contextData = _container.Resolve<IContextData>();

            if (ScenarioContext.Current.TestError != null)
            {
                loggingService.WriteLog(LoggingLevel.FAILURE, ScenarioContext.Current.TestError.Message);
                LogJavascriptConsoleOutput(webDriverFactory, loggingService);
            }
            else
            {
                //Remove devices added to simulator in this session
                var deviceSimulatorService = _container.Resolve<IDeviceSimulatorService>();

                foreach (var deviceId in contextData.RegisteredDeviceIds)
                {
                    deviceSimulatorService.DeleteDevice(deviceId);
                }
            }

            if (webDriverFactory != null)
            {
                webDriverFactory.CloseAllWebDrivers();
            }

            if (contextData.Environment.ToUpper() == "PROD")
            {
                //A bit heavy handed but ensures that any production scenario removes smoke tests
                var mpsWebToolsService = _container.Resolve<IMpsWebToolsService>();
                loggingService.WriteLog(LoggingLevel.INFO, "Clearing production smoke tests");
                mpsWebToolsService.RemoveProductionSmokeTests();
            }
        }

        private void LogJavascriptConsoleOutput(IWebDriverFactory webDriverFactory, ILoggingService loggingService)
        {
            //Log javascript console output for all web driver instances
            if (webDriverFactory != null)
            {
                const string DRIVER_INSTANCE_PREFIX = "__driverInstance_";
                const string LOG_NAME = "browser";

                foreach (var item in ScenarioContext.Current)
                {
                    if (item.Key.StartsWith(DRIVER_INSTANCE_PREFIX))
                    {
                        var driver = (IWebDriver)item.Value;
                        var driverName = item.Key.Replace(DRIVER_INSTANCE_PREFIX, "");

                        loggingService.WriteLog(LoggingLevel.DEBUG, "Javacript console output for driver instance {0}", driverName);

                        var logs = driver.Manage().Logs.GetLog(LOG_NAME);
                        if (logs != null)
                        {
                            foreach (var logEntry in logs)
                            {
                                loggingService.WriteLog(LoggingLevel.DEBUG,
                                    string.Format("{0} {1} {2}", logEntry.Timestamp, logEntry.Level, logEntry.Message));
                            }
                        }
                    }
                }
            }            
        }
    }
}
