using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            _container.RegisterTypeAs<PageService, IPageService>();
            _container.RegisterTypeAs<MpsContextData, IContextData>();
        }
    }
}
