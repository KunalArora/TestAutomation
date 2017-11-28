using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Specs.Domain.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Factories
{
    public class WebDriverFactory : IWebDriverFactory
    {
        private ScenarioContext _context;
        private const string _webDriverKeyPattern = "__driverInstance_{0}";

        public static ChromeOptions CreateDefaultChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--lang=en-GB"); // for date stamp
            chromeOptions.AddUserProfilePreference("download.default_directory", TestController.DownloadPath);
            return chromeOptions;
        }

        public WebDriverFactory(ScenarioContext context)
        {
            _context = context;
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
            var webDriverInstance = new ChromeDriver(chromeOptions);
            webDriverInstance.Manage().Window.Maximize();
            _context.Add(key, webDriverInstance);
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
            return string.Format("__driverInstance_ " + userType);
        }
    }
}
