using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Factories
{
    public class WebDriverFactory : IWebDriverFactory
    {
        private ScenarioContext _context;

        public WebDriverFactory(ScenarioContext context)
        {
            _context = context;
        }
        //TODO: allow driver and options to be specified
        public IWebDriver GetWebDriverInstance(UserType userType, ChromeOptions chromeOptions = null)
        {
            var key = "__driverInstance_ " + userType.ToString();

            if (_context.ContainsKey(key))
            {
                return _context.Get<IWebDriver>(key);
            }
            if (chromeOptions == null) { chromeOptions = new ChromeOptions();}
            var webDriverInstance = new ChromeDriver(chromeOptions);
            webDriverInstance.Manage().Window.Maximize();
            _context.Add(key, webDriverInstance);
            return webDriverInstance;
        }
    }
}
