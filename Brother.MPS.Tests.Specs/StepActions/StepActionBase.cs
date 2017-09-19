using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions
{
    public class StepActionBase
    {
        protected readonly IWebDriver Driver;
        protected readonly IContextData ContextData;
        protected readonly IPageService PageService;
        protected readonly ScenarioContext ScenarioContext;
        protected readonly IUrlResolver UrlResolver;

        public StepActionBase(IWebDriver driver,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext scenarioContext,
            IUrlResolver urlResolver)
        {
            Driver = driver;
            ContextData = contextData;
            PageService = pageService;
            ScenarioContext = scenarioContext;
            UrlResolver = urlResolver;
        }
    }
}
