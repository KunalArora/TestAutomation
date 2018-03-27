using Brother.Tests.Common.ContextData;
using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement
{
    public class DealerAgreementConsumablesPage: BasePage, IPageObject
    {
        private string _validationElementSelector = ".active a[href*=\"/consumables\"]";
        private const string _url = "/mps/dealer/agreement/{agreementId}/consumables"; // TODO: Replace agreementId with dynamic parameter

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
        private const string ConsumableTableContainerSelector = ".js-mps-searchable";
        private const string PreloaderSelector = ".js-mps-preloader";

        // Web Elements

        [FindsBy(How = How.CssSelector, Using = ".js-mps-nav-back")]
        public IWebElement BackButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_NoRecords")]
        public IWebElement NoConsumablesFoundAlertElement;

        // Returns true if no consumables are found, otherwise false if consumables are present
        public bool IsNoConsumablesFound()
        {
            bool isNoConsumablesFound = false;
            
            if (SeleniumHelper.IsElementDisplayed(NoConsumablesFoundAlertElement))
            {
                isNoConsumablesFound = true;
            }

            return isNoConsumablesFound;
        }

        public void VerifyConsumableOrderInformation(
            string serialNumber, string resourceConsumableOrderStatusInProgress)
        {
            LoggingService.WriteLogOnMethodEntry(serialNumber, resourceConsumableOrderStatusInProgress);

            bool foundDevice = false;

            SeleniumHelper.WaitUntil(d => !SeleniumHelper.FindElementByCssSelector(PreloaderSelector).Displayed);

            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(
                SeleniumHelper.FindElementByCssSelector(ConsumableTableContainerSelector));
            foreach (var deviceRowElement in deviceRowElements)
            {
                // TODO: Replace this with the conventional element finding method after ID/Class of the Serial number Element has been fixed
                var SerialNumberElement = deviceRowElement.FindElements(By.TagName("td")).ToList()[1];
                if (SerialNumberElement.Text.Equals(serialNumber))
                {
                    // TODO: Replace this with the conventional element finding method after ID/Class of these elements have been fixed
                    var OrderIdElement = deviceRowElement.FindElements(By.TagName("td")).ToList()[2];
                    var SKUElement = deviceRowElement.FindElements(By.TagName("td")).ToList()[5];
                    var OrderStatusElement = deviceRowElement.FindElements(By.TagName("td")).ToList()[6];

                    TestCheck.AssertIsNotEqual(
                        OrderIdElement.Text, SKUElement.Text, string.Format("Order Id and SKU have the same value for the device with serial number = {0}", serialNumber));                   
                    
                    TestCheck.AssertIsEqual(
                        OrderStatusElement.Text, resourceConsumableOrderStatusInProgress, string.Format("Status of the consumable order could not be verified for the device with serial number = {0}", serialNumber));

                    foundDevice = true;

                    break;
                }
            }
            
            if(!foundDevice)
            {
                TestCheck.AssertFailTest("Could not find the device row for device with serial number: " + serialNumber + ". Row elements position might have changed.");
            }
        }
    }
}
