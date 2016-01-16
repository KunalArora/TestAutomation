using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CustomerServiceRequestsPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/customer/service-requests\"]")]
        public IWebElement CustomerServiceRequestTab;
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/customer/service-requests/active\"] span")]
        public IWebElement ActiveServiceRequestTab;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ServiceRequestListActions_ActionList_Button_0")]
        public IWebElement RaiseServiceRequestButton;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ComponentIntroductionAlert")]
        public IWebElement ServiceRequestAlertElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputDevice_Input")]
        public IWebElement CustomerDeviceDropdownElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputSubject_Input")]
        public IWebElement ServiceRequestSubjectElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputRequestType_Input")]
        public IWebElement ServiceRequestTypeElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputDescription_Input")]
        public IWebElement ServiceRequestDescriptionElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonRaise")]
        public IWebElement ServiceRequestSubmitButtonElement;
        
        


        public void IsServiceRequestPageDisplayed()
        {
            if(CustomerServiceRequestTab == null)
                throw new Exception("Customer Service Request is no displayed");

            TestCheck.AssertIsEqual(true, CustomerServiceRequestTab.Displayed, "Customer Service Request Page is not displayed");
        }

        public void ClickOnRaiseServiceRequestButton()
        {
            ScrollTo(RaiseServiceRequestButton);
            RaiseServiceRequestButton.Click();
        }

        public void SelectDeviceFromDropdown()
        {
            SelectFromDropdown(CustomerDeviceDropdownElement, "MFC-L8650CDW");
        }

        public void EnterRequestSubject()
        {
            ClearAndType(ServiceRequestSubjectElement, "Testing Service Request");
        }


    }
}
