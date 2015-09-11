using Brother.Tests.Selenium.Lib.Support;
using OpenQA.Selenium;
using SpecResults;
using TechTalk.SpecFlow;

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
