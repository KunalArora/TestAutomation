using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CloudExisitngCustomerPage : BasePage
    {
        public static string URL = "/mps/dealer/customers/existing";

        [FindsBy(How = How.CssSelector, Using = "div.js-mps-customer-list-container>table")]
        private IWebElement customerListContainerElement;

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        public void FindExistingCustomerList()
        {
            TestCheck.AssertIsNotNull(customerListContainerElement,
                "Existing customer table is not found.");
        }
    }
}
