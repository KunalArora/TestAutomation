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


        private static ChromeOptions CreateDefaultChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--lang=en-GB"); // for date stamp
            chromeOptions.AddUserProfilePreference("download.default_directory", TestController.DownloadPath);
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
        //TODO: allow driver and options to be specified
        public IWebDriver GetWebDriverInstance(UserType userType, ChromeOptions chromeOptions = null)
        {
            var key = WebDriverKey(userType);

            if (_context.ContainsKey(key))
            {
                return _context.Get<IWebDriver>(key);
            }
            if (chromeOptions == null) {
                chromeOptions = CreateDefaultChromeOptions();
            }
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
