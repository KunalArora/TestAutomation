
using BoDi;
using Brother.Tests.Common.Logging;
using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Specs.Configuration;
using Brother.Tests.Common.ContextData;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Common.Services;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Globalization;
using TechTalk.SpecFlow;
using SeleniumHelper = Brother.Tests.Selenium.Lib.Helpers.SeleniumHelper;
using Brother.Tests.Common.RuntimeSettings;

namespace Brother.Tests.Specs.AdditionalBindings
{
    [Binding]
    public class InjectionSetup
    {
        private readonly IObjectContainer _container;

        public InjectionSetup(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void RegisterInstances()
        {
            var webDriver = TestController.CurrentDriver; //temporary until static classes are refactored
            _container.RegisterInstanceAs<IWebDriver>(webDriver); //default driver when only a single instance is required
            _container.RegisterInstanceAs<IContextData>(setContextData());
            _container.RegisterInstanceAs<IRuntimeSettings>(InitialiseRuntimeSettings());
            _container.RegisterInstanceAs<ILoggingServiceSettings>(CreateLoggingServiceSettings());
            _container.RegisterTypeAs<WebDriverFactory, IWebDriverFactory>();
            _container.RegisterTypeAs<PageService, IPageService>();
            _container.RegisterTypeAs<DefaultUserResolver, IUserResolver>();
            _container.RegisterTypeAs<DefaultUrlResolver, IUrlResolver>();
            _container.RegisterTypeAs<CountryService, ICountryService>();
            _container.RegisterTypeAs<DefaultProposalHelper, IProposalHelper>();
            _container.RegisterTypeAs<SeleniumHelper, ISeleniumHelper>();
            _container.RegisterTypeAs<ExpectedTranslationService, ITranslationService>();
            _container.RegisterTypeAs<WebRequestService, IWebRequestService>();
            _container.RegisterTypeAs<DeviceSimulatorService, IDeviceSimulatorService>();
            _container.RegisterTypeAs<RunCommandService, IRunCommandService>();
            _container.RegisterTypeAs<MpsWebToolsService, IMpsWebToolsService>();
            _container.RegisterTypeAs<CalculationService, ICalculationService>();
            _container.RegisterTypeAs<PdfHelper, IPdfHelper>();
            _container.RegisterTypeAs<DefaultAgreementHelper, IAgreementHelper>();
            _container.RegisterTypeAs<ExcelHelper, IExcelHelper>();
            _container.RegisterTypeAs<MpsLoggingConsole, ILoggingService>();
        }

        private ILoggingServiceSettings CreateLoggingServiceSettings()
        {
            var loggingServiceSettings = new LoggingServiceSettings();
            SetToCommandLineSettings(loggingServiceSettings);
            loggingServiceSettings.ScenarioName = ScenarioContext.Current.ScenarioInfo.Title ?? "";
            return loggingServiceSettings;
        }

        private void SetToCommandLineSettings(ICommandLineSettings commandLineSettings )
        {
            commandLineSettings.LoggingLevel = TestContext.Parameters.Get("logging_level", DefaultLoggingLevel());
        }

        private IContextData setContextData()
        {
            string env = TestContext.Parameters.Exists("env") ? TestContext.Parameters.Get("env") : DefaultEnvironment();
            string cultureName = TestContext.Parameters.Exists("culture") ? TestContext.Parameters.Get("culture") : "en-GB";
            string baseUrl = TestContext.Parameters.Exists("base_url") ? TestContext.Parameters.Get("base_url") : string.Empty;
            CultureInfo culture = new CultureInfo(cultureName);
            RegionInfo region = new RegionInfo(culture.LCID);
            string country = region.TwoLetterISORegionName;

            Console.WriteLine("Initialising scenario for environment {0}", env);

            //apply defaults, changed per scenario as required
            CountryService countryService = new CountryService();
            
            return new MpsContextData
            {
                Environment = env,
                Culture = cultureName,
                BusinessType = Brother.Tests.Common.Domain.Enums.BusinessType.Type1,
                Country = countryService.GetByName("United Kingdom")
            };
        }

        [AfterScenario]
        public void TearDown()
        {
            var webDriverFactory = _container.Resolve<IWebDriverFactory>();
            if (webDriverFactory != null)
            {
                webDriverFactory.CloseAllWebDrivers();
            }
            if (ScenarioContext.Current.TestError != null)
            {
                var logging = _container.Resolve<ILoggingService>();
                logging.WriteLog(LoggingLevel.FAILURE, ScenarioContext.Current.TestError.Message);
            }

            if (_container.Resolve<IContextData>().Environment.ToUpper() == "PROD")
            {
                //A bit heavy handed but ensures that any production scenario removes smoke tests
                var logging = _container.Resolve<ILoggingService>();
                var mpsWebToolsService = _container.Resolve<IMpsWebToolsService>();
                logging.WriteLog(LoggingLevel.INFO, "Clearing production smoke tests");
                mpsWebToolsService.RemoveProductionSmokeTests();
            }
        }

        private string DefaultEnvironment()
        {
            var defaultRuntimeEnvironment = System.Configuration.ConfigurationManager.AppSettings.Get("DefaultRuntimeEnvironment");
            return defaultRuntimeEnvironment ?? "UAT";
        }

        private string DefaultLoggingLevel()
        {
            var defaultRuntimeEnvironment = System.Configuration.ConfigurationManager.AppSettings.Get("DefaultLoggingLevel");
            return defaultRuntimeEnvironment ?? LoggingLevel.WARNING.ToString();
        }

        private RuntimeSettings InitialiseRuntimeSettings()
        {
            RuntimeSettings runtimeSettings = new RuntimeSettings(
                    defaultDeviceSimulatorTimeout: AppSettingToInt("RuntimeSettings.DefaultDeviceSimulatorTimeout"),
                    defaultFindElementTimeout: AppSettingToInt("RuntimeSettings.DefaultFindElementTimeout"),
                    defaultPageLoadTimeout: AppSettingToInt("RuntimeSettings.DefaultPageLoadTimeout"),
                    defaultPageObjectTimeout: AppSettingToInt("RuntimeSettings.DefaultPageObjectTimeout"),
                    defaultRemoteWebDriverTimeout: AppSettingToInt("RuntimeSettings.DefaultRemoteWebDriverTimeout"),
                    defaultRetryCount: AppSettingToInt("RuntimeSettings.DefaultRetryCount"),
                    defaultDownloadTimeout: AppSettingToInt("RuntimeSettings.DefaultDownloadTimeout")

            );

            return runtimeSettings;
        }

        private int? AppSettingToInt(string appSettingName)
        {
            var appSetting = System.Configuration.ConfigurationManager.AppSettings.Get(appSettingName);
            
            if (appSetting != null)
            {
                int parsedSetting = 0;
                if (int.TryParse(appSetting, out parsedSetting))
                {
                    return parsedSetting;
                }
            }

            return null;
        }
    }
}
