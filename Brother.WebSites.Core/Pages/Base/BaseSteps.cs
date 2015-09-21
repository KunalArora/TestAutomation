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
        protected IWebDriver CurrentDriver = TestController.CurrentDriver;

        protected BasePage NextPage
        {
            set { CurrentPage = value; }
        }

        protected BasePage CurrentPage
        {
            get { return (BasePage)ScenarioContext.Current["CurrentPage"]; }

            set { ScenarioContext.Current["CurrentPage"] = value; }
        }
    }
}
