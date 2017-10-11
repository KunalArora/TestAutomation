
using System;
using System.Collections.Generic;
using System.Globalization;
using BoDi;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Selenium.Lib.Helpers;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
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
            var webDriver = TestController.CurrentDriver; //temporary until static classes are refactored
            _container.RegisterInstanceAs<IWebDriver>(webDriver); //default driver when only a single instance is required
            _container.RegisterInstanceAs<IContextData>(setContextData());
            _container.RegisterTypeAs<WebDriverFactory, IWebDriverFactory>();
            _container.RegisterTypeAs<PageService, IPageService>();
            _container.RegisterTypeAs<DefaultUserResolver, IUserResolver>();
            _container.RegisterTypeAs<DefaultUrlResolver, IUrlResolver>();
            _container.RegisterTypeAs<CountryService, ICountryService>();
            _container.RegisterTypeAs<DefaultProposalHelper, IProposalHelper>();
            _container.RegisterTypeAs<SeleniumHelper, ISeleniumHelper>();
            _container.RegisterTypeAs<ExpectedTranslationService, ITranslationService>();
        }

        private IContextData setContextData()
        {
            string env = TestContext.Parameters.Exists("env") ? TestContext.Parameters.Get("env") : "UAT";
            string cultureName = TestContext.Parameters.Exists("culture") ? TestContext.Parameters.Get("culture") : "en-GB";
            string baseUrl = TestContext.Parameters.Exists("base_url") ? TestContext.Parameters.Get("base_url") : string.Empty;
            CultureInfo culture = new CultureInfo(cultureName);
            RegionInfo region = new RegionInfo(culture.LCID);
            string country = region.TwoLetterISORegionName;

            //apply defaults, changed per scenario as required
            return new MpsContextData
            {
                Environment = env,
                Culture = cultureName,
                BusinessType = Domain.Enums.BusinessType.Type1
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
        }
    }
}
