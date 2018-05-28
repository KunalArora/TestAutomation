using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.ContextData;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Factories
{
    public class WebDriverFactory : IWebDriverFactory
    {
        private ScenarioContext _context;
        private ChromeDriverService _chromeDriverService;
        private const string _webDriverKeyPattern = "__driverInstance_{0}";
        private IContextData _contextData;


        private ChromeOptions CreateDefaultChromeOptions(WebDriverOptions webDriverOptions)
        {
            const string languageArgName = "--lang";
            const string defaultDownloadDirectoryKey = "download.default_directory";

            var chromeOptions = new ChromeOptions();

            if (webDriverOptions == null) { webDriverOptions = new WebDriverOptions();}

            chromeOptions.AddArgument(string.Format("{0}={1}", languageArgName, string.IsNullOrWhiteSpace(webDriverOptions.Culture) ? _contextData.Culture : webDriverOptions.Culture)); //Note: _contextData.Culture is set to be en-GB in the InjectionSetup before the start of scenario

            chromeOptions.AddUserProfilePreference(defaultDownloadDirectoryKey, webDriverOptions.DownloadFolder);

            return chromeOptions;
        }

        public WebDriverFactory(ScenarioContext context, 
            MpsContextData contextData)
        {
            _context = context;
            _chromeDriverService = ChromeDriverService.CreateDefaultService();
            _chromeDriverService.Start();
            _contextData = contextData;
        }
        
        public IWebDriver GetWebDriverInstance(UserType userType, WebDriverOptions webDriverOptions = null)
        {
            var key = WebDriverKey(userType);

            if (_context.ContainsKey(key))
            {
                return _context.Get<IWebDriver>(key);
            }
            
            var chromeOptions = CreateDefaultChromeOptions(webDriverOptions);

            chromeOptions.SetLoggingPreference("browser", LogLevel.All);

            var capabilities = chromeOptions.ToCapabilities();
            var webDriverInstance = new RemoteWebDriver(_chromeDriverService.ServiceUrl, capabilities, TimeSpan.FromSeconds(200));

            webDriverInstance.Manage().Window.Maximize();
            _context.Add(key, webDriverInstance);
            _contextData.WindowHandles.Add(userType, webDriverInstance.CurrentWindowHandle);
            return webDriverInstance;
        }

        public void CloseAllWebDrivers()
        {
            foreach (var userType in Enum.GetNames(typeof(UserType)))
            {
                var key = WebDriverKey(userType);
                if (_context.ContainsKey(key))
                {
                    var webDriverInstance = _context.Get<IWebDriver>(key);
                    webDriverInstance.Quit();
                }
            }
        }

        private string WebDriverKey(UserType userType)
        {
            return WebDriverKey(userType.ToString());
        }

        private string WebDriverKey(string userType)
        {
            return string.Format("__driverInstance_" + userType);
        }
    }
}
