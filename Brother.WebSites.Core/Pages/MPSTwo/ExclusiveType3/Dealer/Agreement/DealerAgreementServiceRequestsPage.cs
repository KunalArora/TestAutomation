using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement
{
    public class DealerAgreementServiceRequestsPage: BasePage, IPageObject
    {
        private const string _validationElementSelector = ".active a[href*=\"/service-requests\"]";
        private const string _url = "/mps/dealer/agreement/{agreementId}/service-requests"; // TODO: Replace agreementId with dynamic parameter

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        // Selectors
        private const string ServiceRequestRowSelector = "[id*=content_1_ServiceRequests_Row_]";
        private const string ServiceRequestIdSelector = "data-service-request-id";
        private const string ServiceRequestRowDateClosedSelector = "[id*=content_1_ServiceRequests_DateClosedRow_]";

        // Tab link selectors
        private const string MpsTabsSelector = ".mps-tabs-main";
        private const string MpsTabsAgreementSelector = " a[href=\"/mps/dealer/agreement/";

        // WebElements
        [FindsBy(How = How.CssSelector, Using = ".js-mps-filter-search-field")]
        public IWebElement ServiceRequestFilterElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_ServiceRequests_Row_]")]
        public IList<IWebElement> ServiceRequestRowElementList;

        public string VerifyServiceRequestInformation(string model, string serialNumber, string serviceRequestStatus, string serviceRequestType, bool verifyDateClosed = false)
        {
            SeleniumHelper.FindElementByCssSelector(ServiceRequestRowSelector, RuntimeSettings.DefaultFindElementTimeout);
            ClearAndType(ServiceRequestFilterElement, string.Format(model + " " + serialNumber));

            IWebElement serviceRequestRowElement = null;

            try
            {
                // TODO: Replace this with the conventional element finding method after ID/Class of the elements have been fixed
                serviceRequestRowElement = SeleniumHelper.WaitUntil(
                    d => 
                        ServiceRequestRowElementList.First(
                        element => 
                        element.FindElements(By.TagName("td")).ToList()[1].Text == model &&
                        element.FindElements(By.TagName("td")).ToList()[2].Text == serialNumber &&
                        element.FindElements(By.TagName("td")).ToList()[3].Text == serviceRequestStatus &&
                        element.FindElements(By.TagName("td")).ToList()[4].Text == serviceRequestType),
                        RuntimeSettings.DefaultFindElementTimeout);

                if (verifyDateClosed)
                {
                    TestCheck.AssertIsNotEqual(
                        SeleniumHelper.FindElementByCssSelector(
                        serviceRequestRowElement, ServiceRequestRowDateClosedSelector, RuntimeSettings.DefaultFindElementTimeout).Text,
                        "-", 
                        string.Format("Data closed of the service request for device = {0} and serial number = {1} could not be verified", model, serialNumber));
                }
            }
            catch
            {
                throw new Exception(string.Format("Service Request information could not be verified for device = {0} with serial number = {1}", model, serialNumber));
            }

            return serviceRequestRowElement.GetAttribute(ServiceRequestIdSelector);
        }

        public IWebElement DevicesTabElement(int agreementId)
        {
            return SeleniumHelper.FindElementByCssSelector(
                string.Format(MpsTabsSelector + MpsTabsAgreementSelector + "{0}/devices\"]", agreementId.ToString()), RuntimeSettings.DefaultFindElementTimeout);
        }
    }
}
