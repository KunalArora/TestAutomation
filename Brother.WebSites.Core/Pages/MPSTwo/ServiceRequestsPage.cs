using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class ServiceRequestsPage : BasePage
    {
        private const string CloseService = @".js-mps-service-request-close";

        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/local-office/service-desk/service-requests/active\"] span")]
        public IWebElement ServiceRequestActiveTab;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/service-desk/service-requests/closed\"] span")]
        public IWebElement ServiceRequestClosedTab;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-service-request-close")]
        public IWebElement CloseServiceRequestElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-service-request-responses .col-sm-10 p")]
        public IList<IWebElement> MessageDetailElement;
        [FindsBy(How = How.CssSelector, Using = "[data-response-input=\"true\"]")]
        public IWebElement ServiceDeskMessageAreaElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-service-request-response-submit")]
        public IWebElement ServiceDeskMessageAreaSubmitButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-view-person-details")]
        public IWebElement ContactPersonPopUpElement;
        
        



        public void IsServiceRequestPageDisplayed()
        {
            if(ServiceRequestActiveTab == null)
                throw new Exception("Active service request page is not displayed");
            AssertElementPresent(ServiceRequestActiveTab, "Service request page is not displayed");
        }

        public IWebElement CreatedServiceRequestElement()
        {
            const string newlyCreated = @"//td[text()='Blue Hollow_170210045302 Ltd']";

            return Driver.FindElement(By.XPath(newlyCreated));
        }

        public void IsCreatedServiceRequestDisplayed()
        {
            TestCheck.AssertIsEqual(true, CreatedServiceRequestElement().Displayed, "Created Service Request is not displayed");
        }

        public void OpenServiceRequestDetail()
        {
            CreatedServiceRequestElement().Click();
            WaitForElementToExistByCssSelector(CloseService, 5, 10);
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert();
        }

        public void CloseServiceRequest()
        {
            ScrollTo(CloseServiceRequestElement);
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert();
            CloseServiceRequestElement.Click();
            ClickAcceptOnJsAlert();
        }

        public void ServiceDeskEnterServiceRequestMessage()
        {
            ClearAndType(ServiceDeskMessageAreaElement, "Testing Sent Message");
            ServiceDeskMessageAreaElement.SendKeys(Keys.Tab);
        }

        public void ServiceDeskSendMessage()
        {
            ServiceDeskEnterServiceRequestMessage();
            ServiceDeskMessageAreaSubmitButtonElement.Click();

        }

        public void IsServiceDeskMessageDisplayed(int messageCount)
        {
            TestCheck.AssertIsEqual(messageCount, MessageDetailElement.Count, "Number of messages displayed");
        }
    }
}
