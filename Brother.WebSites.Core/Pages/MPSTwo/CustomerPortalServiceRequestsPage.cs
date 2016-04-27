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
    public class CustomerPortalServiceRequestsPage : BasePage
    {
        private const string SelectorId= @"content_1_InputDevice_Input";
        private const string ContactPerson = @".mps-info-icon.pull-right.js-mps-view-person-details";

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
        [FindsBy(How = How.CssSelector, Using = ".js-mps-row-select")]
        public IWebElement CreatedServiceRequestRowElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-row-select #content_1_ServiceRequestList_List_RequestType_0")]
        public IWebElement CreatedServiceRequestTypeElement;
        [FindsBy(How = How.CssSelector, Using = ".glyphicon-chevron-right")]
        public IWebElement CreatedServiceRequestDetailButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-service-request-container")]
        public IWebElement CreatedServiceRequestDetailPanelElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-info-icon.pull-right.js-mps-view-person-details")]
        public IWebElement CreatedServiceRequestDetailContactPersonElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-info-icon.pull-right.js-mps-view-device-location")]
        public IWebElement CreatedServiceRequestDetailDeviceLocationElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-info-icon.pull-right.js-mps-view-print-count")]
        public IWebElement CreatedServiceRequestDetailMeterReadingElement;
        [FindsBy(How = How.CssSelector, Using = "[data-dismiss=\"modal\"] span[aria-hidden=\"true\"]")]
        public IWebElement CloseModalPopUpElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-device-location [data-dismiss=\"modal\"] span[aria-hidden=\"true\"]")]
        public IWebElement CloseDeviceLocationModalPopUpElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-print-counts-list [data-dismiss=\"modal\"] span[aria-hidden=\"true\"]")]
        public IWebElement ClosePrintCountModalPopUpElement;
        [FindsBy(How = How.CssSelector, Using = "#MeterReadingLabel")]
        public IWebElement ModalPopUpIdElement;
        [FindsBy(How = How.CssSelector, Using = ".glyphicon-chevron-down")]
        public IWebElement CloseCreatedServiceRequestDetailPanelElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ServiceRequestList_List_Status_0")]
        public IWebElement CreatedServiceRequestStatusElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-device-location")]
        public IWebElement DeviceLocationModalPopUpElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-print-counts-list")]
        public IWebElement PrintCountnModalPopUpElement;
        [FindsBy(How = How.CssSelector, Using = "[data-response-input=\"true\"]")]
        public IWebElement CustomerMessageAreaElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-service-request-response-submit")]
        public IWebElement CustomerMessageAreaSubmitButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-service-request-responses .col-sm-10 p")]
        public IList<IWebElement> MessageDetailElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-person-details .text-right")]
        public IList<IWebElement> ContactPersonModalLabelElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-person-details .col-sm-9")]
        public IList<IWebElement> ContactPersonModalContentElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-device-location .col-sm-4")]
        public IList<IWebElement> DeviceLocationModalContentElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-print-counts-list .table-striped")]
        public IWebElement PrintCountModalContentElement;
        
        

        public void IsServiceRequestPageDisplayed()
        {
            if(CustomerServiceRequestTab == null)
                throw new Exception("Customer Service Request is no displayed");

            TestCheck.AssertIsEqual(true, CustomerServiceRequestTab.Displayed, "Customer Service Request Page is not displayed");
        }

        public void IsContactPersonModalPopulated()
        {
            TestCheck.AssertIsEqual(true, ContactPersonModalLabelElement.Count>1, "There is no error in the Contact Person label");
        }

        public void IsContactPersonContentPopulated()
        {
            TestCheck.AssertIsEqual(true, ContactPersonModalContentElement.Count > 1, "There is no error in the Contact Person model");
        }

        public void IsDeviceLocationContentPopulated()
        {
            TestCheck.AssertIsEqual(true, DeviceLocationModalContentElement.Count > 1, "There is no error in the Device Location model");
        }

        public void IsPrintCountContentPopulated()
        {
            TestCheck.AssertIsEqual(true, PrintCountModalContentElement.Displayed, "There is no error in the Device Location model");
        }

        public void ClickOnRaiseServiceRequestButton()
        {
            ScrollTo(RaiseServiceRequestButton);
            //RaiseServiceRequestButton.Click();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, RaiseServiceRequestButton);
        }

        public void SelectDeviceFromDropdown()
        {
            //SelectFromDropdown(CustomerDeviceDropdownElement, "MFC-L8650CDW");
            SelectFromDropdownWithPartialText(Driver, SelectorId, "MFC-L8650CDW");
        }

        public void EnterRequestSubject()
        {
            ClearAndType(ServiceRequestSubjectElement, "Testing Service Request");
        }

        public void SelectServiceRequestType()
        {
            SelectFromDropdown(ServiceRequestTypeElement, MpsUtil.ServiceRequestType());
        }

        public void EnterRequestDescription()
        {
            ClearAndType(ServiceRequestDescriptionElement, "This is testing automation request");
        }

        public void SubmitServiceRequest()
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ServiceRequestSubmitButtonElement);
        }

        public void SaveServiceRequestStatus()
        {
            var status = CreatedServiceRequestStatusElement.Text;
            SpecFlow.SetContext("Service Request Status", status);
        }


        public void CreateANewServiceRequest()
        {
            ClickOnRaiseServiceRequestButton();
            SelectDeviceFromDropdown();
            EnterRequestSubject();
            SelectServiceRequestType();
            EnterRequestDescription();
            SubmitServiceRequest();
        }

        public void IsCorrectServiceRequestTypeDisplayed()
        {
            var selectedType = SpecFlow.GetContext("ServiceRequestType");
            var displayedType = CreatedServiceRequestTypeElement.Text;

            TestCheck.AssertIsEqual(true, selectedType.Equals(displayedType), 
                                            String.Format("{0} is not equal to the displayed {1}", selectedType, displayedType));
        }

        public void IsServiceRequestCreated()
        {
            SaveServiceRequestStatus();
            TestCheck.AssertIsEqual(true, CreatedServiceRequestRowElement.Displayed, 
                                                        "Service request was not created");
        }

        public void ExpandCreatedServiceRequestRow()
        {
            CreatedServiceRequestDetailButtonElement.Click();
            WaitForElementToExistByCssSelector(ContactPerson, 5, 10);
        }



        public void IsServiceRequestDetailDisplayed()
        {
            TestCheck.AssertIsEqual(true, CreatedServiceRequestDetailPanelElement.Displayed, 
                                                                      "Service Request Detail in snot displayed");
        }

        public void DisplayContactPersonPanel()
        {
            CreatedServiceRequestDetailContactPersonElement.Click();
        }

        public void DisplayDeviceLocation()
        {
            CreatedServiceRequestDetailDeviceLocationElement.Click();
        }

        public void DisplayMeterReading()
        {
            CreatedServiceRequestDetailMeterReadingElement.Click();
        }

        public void IsModalPopUpDisplayed(IWebElement element)
        {
            TestCheck.AssertIsEqual(true, element.Displayed, 
                                                    "Modal pop up is not displayed");
        }

        public void CloseModalPopUp()
        {
            CloseModalPopUpElement.Click();
        }

        public void CloseDeviceLocationModalPopUp()
        {
            CloseDeviceLocationModalPopUpElement.Click();
        }

        public void ClosePrintCountModalPopUp()
        {
            ClosePrintCountModalPopUpElement.Click();
        }

        public void VerifyContactPersonPopUpWorks()
        {
            DisplayContactPersonPanel();
            WebDriver.Wait(DurationType.Second, 3);
            IsModalPopUpDisplayed(ModalPopUpIdElement);
            IsContactPersonModalPopulated();
            IsContactPersonContentPopulated();
            CloseModalPopUp();
            WebDriver.Wait(DurationType.Second, 3);
        }



        public void VerifyDeviceLocationPopUpWorks()
        {
           DisplayDeviceLocation();
           WebDriver.Wait(DurationType.Second, 3);
            IsModalPopUpDisplayed(DeviceLocationModalPopUpElement);
            IsDeviceLocationContentPopulated();
            CloseDeviceLocationModalPopUp();
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void VerifyMeterReadingPopUpWorks()
        {
            DisplayMeterReading();
            WebDriver.Wait(DurationType.Second, 3);
            IsModalPopUpDisplayed(PrintCountnModalPopUpElement);
            IsPrintCountContentPopulated();
            ClosePrintCountModalPopUp();
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void CloseServiceRequestDetailPanel()
        {
            CloseCreatedServiceRequestDetailPanelElement.Click();
        }

        public void CustomerEnterServiceRequestMessage()
        {
            ExpandCreatedServiceRequestRow();
            ClearAndType(CustomerMessageAreaElement, "Testing Sent Message");
            CustomerMessageAreaElement.SendKeys(Keys.Tab);
        }

        public void CustomerSendMessage()
        {
            CustomerEnterServiceRequestMessage();
            CustomerMessageAreaSubmitButtonElement.Click();

        }

        public void IsServiceDeskMessageDisplayed(int messageCount)
        {
            TestCheck.AssertIsEqual(messageCount, MessageDetailElement.Count, "Number of messages displayed");
        }

    }
}
