
using System.Collections.Generic;
using System.Globalization;
using BoDi;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using OpenQA.Selenium;
using NUnit.Framework;
using TechTalk.SpecFlow;

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
            //var webDriver = new ChromeDriver();
            var webDriver = TestController.CurrentDriver; //temporary until static classes are refactored
            _container.RegisterInstanceAs<IWebDriver>(webDriver);
            _container.RegisterInstanceAs<IContextData>(setContextData());
            _container.RegisterTypeAs<PageService, IPageService>();
            _container.RegisterTypeAs<DefaultUserResolver, IUserResolver>();
            //_container.RegisterTypeAs<MpsContextData, IContextData>();
        }

        private IContextData setContextData()
        {
            string env = TestContext.Parameters.Exists("env") ? TestContext.Parameters.Get("env") : "UAT";
            string cultureName = TestContext.Parameters.Exists("culture") ? TestContext.Parameters.Get("culture") : "en-GB";
            CultureInfo culture = new CultureInfo(cultureName);
            RegionInfo region = new RegionInfo(culture.LCID);
            string country = region.TwoLetterISORegionName;
            string brotherCountryCode = BrotherCountryCodes[country];

            return new MpsContextData
            {
                Environment = env,
                Country = region.Name,
                Culture = cultureName,
                CountryBrotherCode = brotherCountryCode,
                CountryIso = country
            };
        }

        private Dictionary<string, string> BrotherCountryCodes = new Dictionary<string, string>
        {
            {"AT", "BAT"},
            {"BE", "BBE"},
            {"DK", "BND"},
            {"FI", "BNF"},
            {"FR", "BFR"},
            {"DE", "BIG"},
   	        {"IE", "BIR"},
            {"NL", "BNL"},
            {"PL", "BPL"},  
            {"PT", "BPT"},  
            {"NO", "BNN"},
	        {"GB", "BUK"},
            {"ES", "BES"},
            {"SE", "BNS"},
            {"CH", "BSW"},
            {"IT", "BIT"}
        };
    }
}
