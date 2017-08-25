using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.WebSites.Core.Annotations;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Tracing;

namespace Brother.WebSites.Core.Pages.Base
{
    public class BaseSteps : Steps
    {
        private const string CURRENT_PAGE_KEY = "CurrentPage";
        protected IWebDriver CurrentDriver = TestController.CurrentDriver;

        protected BasePage NextPage
        {
            set { CurrentPage = value; }
        }

        protected BasePage CurrentPage
        {
            get { return (BasePage)ScenarioContext.Current[CURRENT_PAGE_KEY]; }

            set { ScenarioContext.Current[CURRENT_PAGE_KEY] = value; }
        }

        protected T GetSubjectPage<T>() where T : BasePage, new()
        {
            return ScenarioContext.Current.Get<T>(CURRENT_PAGE_KEY);
        }
    }
}
