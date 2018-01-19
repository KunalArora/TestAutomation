
using BoDi;
using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Globalization;
using TechTalk.SpecFlow;
using SeleniumHelper = Brother.Tests.Selenium.Lib.Helpers.SeleniumHelper;

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
            var scenarioContext = _container.Resolve<ScenarioContext>();

            var loggingServiceSettings = CreateLoggingServiceSettings();
            var loggingService = new MpsLoggingConsole(loggingServiceSettings);
            var webDriver = TestController.CurrentDriver; //temporary until static classes are refactored
            var runtimeSettings = InitialiseRuntimeSettings();
            var contextData = setContextData();
            var defaultUrlResolver = new DefaultUrlResolver(contextData);
            var webRequestService = LoggingProxy.Wrap(loggingService, new WebRequestService());
            var seleniumHelper = LoggingProxy.Wrap(loggingService, new SeleniumHelper(webDriver));
            var pageService = LoggingProxy.Wrap(loggingService, new PageService(webDriver, scenarioContext, loggingService, defaultUrlResolver, seleniumHelper, runtimeSettings));

            _container.RegisterInstanceAs<ILoggingServiceSettings>(loggingServiceSettings);
            _container.RegisterInstanceAs<ILoggingService>(loggingService);
            _container.RegisterInstanceAs<IWebDriver>(webDriver); //default driver when only a single instance is required
            _container.RegisterInstanceAs<IContextData>(contextData);
            _container.RegisterInstanceAs<IRuntimeSettings>(runtimeSettings);
            _container.RegisterTypeAs<WebDriverFactory, IWebDriverFactory>();
            _container.RegisterInstanceAs<IPageService>(pageService);
            _container.RegisterTypeAs<DefaultUserResolver, IUserResolver>();
            _container.RegisterInstanceAs<IUrlResolver>(defaultUrlResolver);
            _container.RegisterTypeAs<CountryService, ICountryService>();
            _container.RegisterTypeAs<DefaultProposalHelper, IProposalHelper>();
            _container.RegisterInstanceAs<ISeleniumHelper>(seleniumHelper);
            _container.RegisterTypeAs<ExpectedTranslationService, ITranslationService>();
            _container.RegisterInstanceAs<IWebRequestService>(webRequestService);
            _container.RegisterInstanceAs<IDeviceSimulatorService>(LoggingProxy.Wrap(loggingService, new DeviceSimulatorService(webRequestService, runtimeSettings)));
            _container.RegisterInstanceAs<IRunCommandService>(LoggingProxy.Wrap(loggingService, new RunCommandService(defaultUrlResolver, webRequestService)));
            _container.RegisterTypeAs<MpsWebToolsService, IMpsWebToolsService>();
            _container.RegisterTypeAs<CalculationService, ICalculationService>();
            _container.RegisterInstanceAs<IPdfHelper>(LoggingProxy.Wrap(loggingService,new PdfHelper()));
            _container.RegisterTypeAs<DefaultAgreementHelper, IAgreementHelper>();
            _container.RegisterInstanceAs<IExcelHelper>(LoggingProxy.Wrap(loggingService,new ExcelHelper(runtimeSettings)));
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
