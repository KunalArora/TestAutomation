using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Common.Domain.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Brother.Tests.Specs.Factories
{
    /// <summary>
    /// Factory for creating web driver instances
    /// </summary>
    public interface IWebDriverFactory
    {
        IWebDriver GetWebDriverInstance(UserType userType, ChromeOptions chromeOptions = null);
        void CloseAllWebDrivers();
    }
}
