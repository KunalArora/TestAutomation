using BoDi;
using Brother.Tests.Common.CommandLineSettings;
using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Helpers.ExcelHelpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using SeleniumHelper = Brother.Tests.Selenium.Lib.Helpers.SeleniumHelper;

namespace Brother.Tests.Specs.AdditionalBindings
{
    [Binding]
    public class InjectionSetup
    {
        private readonly IObjectContainer _container;
        private readonly ICommandLineSettings _commandLineSettings;

        public InjectionSetup(IObjectContainer container)
        {
            _container = container;
            _commandLineSettings = new CommandLineSettings();
        }

        [BeforeScenario]
        public void RegisterInstances()
        {
            var webDriver = TestController.CurrentDriver; //temporary until static classes are refactored
            _container.RegisterInstanceAs<IWebDriver>(webDriver); //default driver when only a single instance is required
            _container.RegisterInstanceAs<IContextData>(SetContextData());
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
            _container.RegisterTypeAs<DevicesExcelHelper, IDevicesExcelHelper>();
            _container.RegisterTypeAs<ClickBillExcelHelper, IClickBillExcelHelper>();
            _container.RegisterTypeAs<ServiceInstallationBillExcelHelper, IServiceInstallationBillExcelHelper>();
            _container.RegisterTypeAs<MpsLoggingConsole, ILoggingService>();
            _container.RegisterTypeAs<ContractShiftService, IContractShiftService>();
            _container.RegisterTypeAs<PageParseHelper, IPageParseHelper>();
            _container.RegisterTypeAs<AccrualsDetailExcelHelper, IAccrualsDetailExcelHelper>();
            _container.RegisterTypeAs<CPPAgreementExcelHelper, ICPPAgreementExcelHelper>();
            _container.RegisterTypeAs<CppAgreementDevicesExcelHelper, ICppAgreementDevicesExcelHelper>();

            //necessary in order for 'old' (non-DI) framework to get hold of an ILoggingService instance
            Helper.LoggingService = _container.Resolve<ILoggingService>();
        }


        private ILoggingServiceSettings CreateLoggingServiceSettings()
        {
            var loggingServiceSettings = new LoggingServiceSettings
            {
                ScenarioName = ScenarioContext.Current.ScenarioInfo.Title ?? "",
                LoggingLevel = _commandLineSettings.LoggingLevel ?? DefaultLoggingLevel()
            };
            return loggingServiceSettings;
        }

        private IContextData SetContextData()
        {
            //apply defaults, changed per scenario as required
            var countryService = new CountryService();
            var env = _commandLineSettings.EnvironmentUnderTest ?? DefaultEnvironment();
            var culture = _commandLineSettings.Culture ?? DefaultCulture();

            Console.WriteLine("Initialising scenario for environment {0}", env);
            
            SetLegacyHelperProperties(_commandLineSettings.OutputPath, env);

            return new MpsContextData
            {
                Environment = env,
                Culture = culture,
                BaseUrl = _commandLineSettings.BaseUrl ?? DefaultBaseUrl(),
                BusinessType = Brother.Tests.Common.Domain.Enums.BusinessType.Type1,
                Country = countryService.GetByCulture(culture),
                SpecificDealerUsername = _commandLineSettings.DealerUsername ?? SpecificDealerUsername(),
                SpecificDealerPassword = _commandLineSettings.DealerPassword ?? SpecificDealerPassword()
            };
        }

        private string DefaultEnvironment()
        {
            var defaultRuntimeEnvironment = System.Configuration.ConfigurationManager.AppSettings.Get("CommandLineSettings.DefaultRuntimeEnvironment");
            return defaultRuntimeEnvironment ?? "UAT";

            if (_container.Resolve<IContextData>().Environment.ToUpper() == "PROD")
            {
                //A bit heavy handed but ensures that any production scenario removes smoke tests
                var logging = _container.Resolve<ILoggingService>();
                var mpsWebToolsService = _container.Resolve<IMpsWebToolsService>();
                logging.WriteLog(LoggingLevel.INFO, "Clearing production smoke tests");
                mpsWebToolsService.RemoveProductionSmokeTests();
            }
        }

        private string DefaultBaseUrl()
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("CommandLineSettings.DefaultBaseUrl");
        }

        private string SpecificDealerUsername()
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("CommandLineSettings.SpecificDealerUsername");
        }

        private string SpecificDealerPassword()
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("CommandLineSettings.SpecificDealerPassword");
        }

        private string DefaultLoggingLevel()
        {
            var defaultRuntimeEnvironment = System.Configuration.ConfigurationManager.AppSettings.Get("CommandLineSettings.DefaultLoggingLevel");
            return defaultRuntimeEnvironment ?? LoggingLevel.WARNING.ToString();
        }

        private string DefaultCulture()
        {
            var defaultCulture = System.Configuration.ConfigurationManager.AppSettings.Get("CommandLineSettings.DefaultCulture");
            return defaultCulture ?? "en-GB";
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
                    defaultDownloadTimeout: AppSettingToInt("RuntimeSettings.DefaultDownloadTimeout"),
                    defaultAPIResponseTimeout: AppSettingToInt("RuntimeSettings.DefaultAPIResponseTimeout"),
                    defaultSerialNumberOffset: AppSettingToInt("RuntimeSettings.DefaultSerialNumberOffset"),
                    defaultInvoiceGenerationTimeout: AppSettingToInt("RuntimeSettings.DefaultInvoiceGenerationTimeout"),
                    defaultElementNotPresentTimeout: AppSettingToInt("RuntimeSettings.DefaultElementNotPresentTimeout"),
                    defaultWaitForItemTimeout: AppSettingToInt("RuntimeSettings.DefaultWaitForItemTimeout"),
                    defaultType3DealerUsername: AppSettingToString("RuntimeSettings.DefaultType3DealerUsername"),
                    defaultType3DealerPassword: AppSettingToString("RuntimeSettings.DefaultType3DealerPassword")

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

        private string AppSettingToString(string appSettingName)
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get(appSettingName);
        }

        private void SetLegacyHelperProperties(string outputPath, string env)
        {
            Helper.OutputPath = outputPath;
            Helper.EnvironmentUnderTest = env;
        }
    }
}
