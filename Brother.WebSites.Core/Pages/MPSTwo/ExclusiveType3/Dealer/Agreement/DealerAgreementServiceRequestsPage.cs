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
        private const string _validationElementSelector = "#content_1_ServiceRequests_Row_0";
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

        // Selectors
        private const string ServiceRequestRowSelector = "[id*=content_1_ServiceRequests_Row_]";
        private const string ServiceRequestIdSelector = "data-service-request-id";
        private const string ServiceRequestRowDateClosedSelector = "[id*=content_1_ServiceRequests_DateClosedRow_]";
        private const string ServiceRequestContainerSelector = ".js-mps-searchable";

        // Tab link selectors
        private const string MpsTabsSelector = ".mps-tabs-main";
        private const string MpsTabsAgreementSelector = " a[href=\"/mps/dealer/agreement/";

        // WebElements
        [FindsBy(How = How.CssSelector, Using = ".js-mps-filter-search-field")]
        public IWebElement ServiceRequestFilterElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_ServiceRequests_Row_]")]
        public IList<IWebElement> ServiceRequestRowElementList;

        // TABs
        [FindsBy(How = How.CssSelector, Using = "a[href$='/summary']")] // ex. /mps/dealer/agreement/173259/summary
        public IWebElement SummaryTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/details']")]
        public IWebElement DetailsTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/devices']")]
        public IWebElement DevicesTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/billing']")]
        public IWebElement BillingTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/consumables']")]
        public IWebElement ConsumablesTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/service-requests']")]
        public IWebElement ServiceRequestsTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/history']")]
        public IWebElement HistoryTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/silent-devices']")]
        public IWebElement SilentDevicesTabElement;



        public bool DoesServiceRequestExist(string serialNumber)
        {
            LoggingService.WriteLogOnMethodEntry(serialNumber);

            bool exists = false;
            try
            {
                var ServiceRequestContainerElement = SeleniumHelper.FindElementByCssSelector(ServiceRequestContainerSelector);
                var serviceRequestRowElements = SeleniumHelper.FindRowElementsWithinTable(ServiceRequestContainerElement);
                foreach (var serviceRequestRowElement in serviceRequestRowElements)
                {
                    // TODO: Replace this with the conventional element finding method after ID/Class of the Serial Number Element has been fixed
                    string displayedSerialNumber = serviceRequestRowElement.FindElements(By.TagName("td")).ToList()[2].Text;
                    if (displayedSerialNumber.Equals(serialNumber))
                    {
                        exists = true;
                        break;
                    }
                }

                return exists;
            }
            catch
            {
                return exists;
            }
        }

        public string VerifyServiceRequestInformation(string model, string serialNumber, string serviceRequestStatus, string serviceRequestType, bool verifyDateClosed = false)
        {
            SeleniumHelper.FindElementByCssSelector(".mps-dataTables-footer");
            ClearAndType(ServiceRequestFilterElement, string.Format(model + " " + serialNumber));

            IWebElement serviceRequestRowElement = null;

            try
            {
                // TODO: Replace this with the conventional element finding method after ID/Class of the elements have been fixed
                serviceRequestRowElement = SeleniumHelper.WaitUntil(
                    d => 
                        ServiceRequestRowElementList.FirstOrDefault(
                        element => 
                        element.FindElements(By.TagName("td")).ToList()[1].Text == model &&
                        element.FindElements(By.TagName("td")).ToList()[2].Text == serialNumber &&
                        element.FindElements(By.TagName("td")).ToList()[3].Text == serviceRequestStatus &&
                        element.FindElements(By.TagName("td")).ToList()[4].Text == serviceRequestType));

                if (verifyDateClosed)
                {
                    TestCheck.AssertIsNotEqual(
                        SeleniumHelper.FindElementByCssSelector(
                        serviceRequestRowElement, ServiceRequestRowDateClosedSelector).Text,
                        "-", 
                        string.Format("Date closed of the service request for device = {0} and serial number = {1} could not be verified", model, serialNumber));
                }
            }
            catch
            {
                throw new Exception(string.Format("Service Request information could not be verified for device = {0} with serial number = {1}", model, serialNumber));
            }

            return serviceRequestRowElement.GetAttribute(ServiceRequestIdSelector);
        }

    }
}
