﻿using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.Base;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions
{
    public class StepActionBase
    {
        protected readonly IWebDriverFactory WebDriverFactory;
        protected readonly IContextData ContextData;
        protected readonly IPageService PageService;
        protected readonly ScenarioContext ScenarioContext;
        protected readonly IUrlResolver UrlResolver;
        protected readonly IRuntimeSettings RuntimeSettings;
        protected readonly ILoggingService LoggingService;

        public StepActionBase(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext scenarioContext,
            IUrlResolver urlResolver,
            ILoggingService loggingService,
            IRuntimeSettings runtimeSettings)
        {
            WebDriverFactory = webDriverFactory;
            ContextData = contextData;
            PageService = pageService;
            ScenarioContext = scenarioContext;
            UrlResolver = urlResolver;
            LoggingService = loggingService;
            RuntimeSettings = runtimeSettings;
        }

        public TPage Refresh<TPage>(TPage page, int? timeout=null) where TPage : BasePage, IPageObject
        {
            LoggingService.WriteLogOnMethodEntry(page, timeout);
            return PageService.Refresh(page, timeout ?? RuntimeSettings.DefaultPageLoadTimeout);
        }

    }
}
