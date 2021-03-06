﻿using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class ServiceDeskServiceRequestsActivePage : BasePage, IPageObject
    {
        private const string _validationElementSelector = ".mps-dataTables-footer";
        private const string _url = "/mps/local-office/service-desk/service-requests/active";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }

        private const string CloseService = @".js-mps-service-request-close";
        private const string ServiceRequestMessageSubmitButtonSelector = ".js-mps-service-request-response-submit";
        private const string ServiceRequestMessageInputDataAttributeSelector = "response-input";
        private const string CloseServiceRequestSelector = ".js-mps-service-request-close";
        private const string ServiceRequestIdAttributeSelector = "data-service-request-id";

        private const string ServiceRequestRowSerialNumberSelector = "[id*=content_1_ServiceRequestList_List_SerialNumber_]";
        private const string ServiceRequestRowModelSelector = "[id*=content_1_ServiceRequestList_List_Model_]";
        private const string ServiceRequestRowSRequestTypeSelector = "[id*=content_1_ServiceRequestList_List_RequestType_]";
        private const string ServiceRequestRowStatusSelector = "[id*=content_1_ServiceRequestList_List_Status_]";


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
        [FindsBy(How = How.CssSelector, Using = ".js-mps-filter-search-field")]
        public IWebElement ServiceRequestFilterElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-searchable")]
        public IWebElement ServiceRequestsContainerElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=_ServiceRequestList_List_Row_]")]
        public IList<IWebElement> List_Row;
     

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


        public void VerifyServiceRequest(string model, string serialNumber, string serviceRequestId, string serviceRequestType, string resourceServiceRequestStatusNew)
        {
            LoggingService.WriteLogOnMethodEntry(model, serialNumber, serviceRequestId, serviceRequestType, resourceServiceRequestStatusNew);

            bool foundDevice = false;
            string inputMessage = MpsUtil.ServiceRequestReplyMessage();

            ClearAndType(ServiceRequestFilterElement, string.Format(model + " " + serialNumber));
            var serviceRequestRowElements = SeleniumHelper.FindRowElementsWithinTable(ServiceRequestsContainerElement);
            foreach (var serviceRequestRowElement in serviceRequestRowElements)
            {
                var displayedServiceRequestId = serviceRequestRowElement.GetAttribute(ServiceRequestIdAttributeSelector);
                if (displayedServiceRequestId.Equals(serviceRequestId))
                {
                    try
                    {
                        SeleniumHelper.WaitUntil(
                        d =>
                        SeleniumHelper.FindElementByCssSelector(serviceRequestRowElement, ServiceRequestRowModelSelector).Text == model &&
                        SeleniumHelper.FindElementByCssSelector(serviceRequestRowElement, ServiceRequestRowSerialNumberSelector).Text == serialNumber &&
                        SeleniumHelper.FindElementByCssSelector(serviceRequestRowElement, ServiceRequestRowStatusSelector).Text == resourceServiceRequestStatusNew &&
                        SeleniumHelper.FindElementByCssSelector(serviceRequestRowElement, ServiceRequestRowSRequestTypeSelector).Text == serviceRequestType);
                    }
                    catch
                    {
                        throw new Exception(string.Format("Service Request = {0} information could not be verified for device = {1} with serial number = {2}", serviceRequestId, model, serialNumber));
                    }
                    foundDevice = true;
                    break;
                }
            }
            if (!foundDevice)
            {
                TestCheck.AssertFailTest("Could not find the device row for device with serial number: " + serialNumber + ". Row elements position might have changed.");
            }
        }

        public string CloseServiceRequest(string model, string serialNumber, string serviceRequestId)
        {
            LoggingService.WriteLogOnMethodEntry(model, serialNumber, serviceRequestId);

            bool foundDevice = false;
            string inputMessage = MpsUtil.ServiceRequestReplyMessage();

            SeleniumHelper.SetListFilter(ServiceRequestFilterElement, string.Format(model + " " + serialNumber), List_Row);
            var serviceRequestRowElements = SeleniumHelper.FindRowElementsWithinTable(ServiceRequestsContainerElement);
            foreach (var serviceRequestRowElement in serviceRequestRowElements)
            {
                var displayedServiceRequestId = serviceRequestRowElement.GetAttribute(ServiceRequestIdAttributeSelector);
                if (displayedServiceRequestId.Equals(serviceRequestId))
                {

                    SeleniumHelper.ClickSafety(serviceRequestRowElement);

                    var SubmitButtonElement = SeleniumHelper.FindElementByCssSelector(
                        ServiceRequestMessageSubmitButtonSelector);

                    var MessageInputElement = SeleniumHelper.FindElementByDataAttributeValue(ServiceRequestMessageInputDataAttributeSelector, "true");

                    ClearAndType(MessageInputElement, inputMessage);
                    SeleniumHelper.ClickSafety(SubmitButtonElement);

                    var CloseServiceRequestElement = SeleniumHelper.FindElementByCssSelector(CloseServiceRequestSelector);

                    SeleniumHelper.ClickSafety(CloseServiceRequestElement);
                    SeleniumHelper.AcceptJavascriptAlert();

                    foundDevice = true;
                    break;
                }
            }

            if (!foundDevice)
            {
                TestCheck.AssertFailTest("Could not find the device row for device with serial number: " + serialNumber + ". Row elements position might have changed.");
            }

            return inputMessage;
        }
    }
}
