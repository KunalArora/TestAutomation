using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class ServiceDeskReportingPage : BasePage
    {

        [FindsBy(How = How.CssSelector, Using = ".media-list a[href=\"/mps/local-office/service-desk\"] h4")]
        public IWebElement ServiceDeskLink;


    }
}
