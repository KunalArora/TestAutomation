using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement
{
    public class DealerAgreementCreateProductsPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "div.mps-product-configuration";
        private const string _url = "/mps/dealer/agreements/manage/products";

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        // Selectors
        private const string InstallationPackRowSelector = ".js-mps-installation";
        private const string ServicePackRowSelector = ".js-mps-service-pack";
        private const string QuantityDataAttributeSelector = "quantity";
        private const string UnitPriceDataAttributeSelector = "sell-price";
        private const string TotalPriceDataAttributeSelector = "total-price";
        private const string TotalLinePriceDataAttributeSelector = "total-line-price";
        private const string alertSuccessContinueSelector = "a.alert-link.js-mps-trigger-next";
        private const string PreloaderSelector = ".js-mps-preloader";


        // Web Elements
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement NextButton;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-filter-search-field")]
        public IWebElement FilterProductElement;


        public ISeleniumHelper SeleniumHelper { get; set; }

        public IWebElement SelectPrinter(string printerName, int findElementTimeout)
        {
            string containerSelector = string.Format("li#pc-{0}", printerName);
            string addButtonSelector = ".js-mps-product-open-add";

            var printerContainer = SeleniumHelper.FindElementByCssSelector(containerSelector, findElementTimeout);
            var addButton = SeleniumHelper.FindElementByCssSelector(printerContainer, addButtonSelector, findElementTimeout);

            SeleniumHelper.ClickSafety(addButton, findElementTimeout);

            // Note: Click Add button once again if it doesn't succeed first time
            if (SeleniumHelper.FindElementByCssSelector(printerContainer, PreloaderSelector, findElementTimeout).Displayed)
            {
                SeleniumHelper.ClickSafety(addButton, findElementTimeout);
            }

            return printerContainer;
        }

        public IWebElement PopulatePrinterDetails(string printerName,
            int quantity,
            string installationPack,
            string servicePack,
            int findElementTimeout,
            out IWebElement printerContainer
            )
        {
            string quantityInputSelector = "#Quantity";
            string installationPackInputSelector = "#InstallationPackId";
            string servicePackInputSelector = "#ServicePackId";
            string addToAgreementButtonSelector = ".js-mps-product-configuration-submit";

            // Filter the product
            ClearAndType(FilterProductElement, printerName);

            printerContainer = SelectPrinter(printerName, findElementTimeout);

            var quantityInput = SeleniumHelper.FindElementByCssSelector(
                printerContainer, quantityInputSelector, findElementTimeout);
            var installationPackInput = SeleniumHelper.FindElementByCssSelector(
                printerContainer, installationPackInputSelector, findElementTimeout);
            var servicePackInput = SeleniumHelper.FindElementByCssSelector(
                printerContainer, servicePackInputSelector, findElementTimeout);
            var addToAgreementButton = SeleniumHelper.FindElementByCssSelector(
                printerContainer, addToAgreementButtonSelector, findElementTimeout);
         
            quantityInput.Clear();
            quantityInput.SendKeys(quantity.ToString());

            if (installationPack.ToLower().Equals("yes") && NumberOfSelectOption(installationPackInput) > 1)
            {
                SelectFromDropDownByIndex(installationPackInput, 1);
            }
            
            if (servicePack.ToLower().Equals("yes") && NumberOfSelectOption(servicePackInput) > 1)
            {
                SelectFromDropDownByIndex(servicePackInput, 1);
            }

            return addToAgreementButton;
        }

        public void ClickAddToAgreementButton(IWebElement printerContainer, IWebElement addToAgreementButton, int findElementTimeout)
        {
            SeleniumHelper.ClickSafety(addToAgreementButton, findElementTimeout);
            SeleniumHelper.FindElementByCssSelector(printerContainer, alertSuccessContinueSelector, findElementTimeout);
        }

        public IWebElement GetInstallationPackRowElement(IWebElement printerContainer, int findElementTimeout)
        {
            return SeleniumHelper.FindElementByCssSelector(printerContainer, InstallationPackRowSelector, findElementTimeout);
        }

        public string InstallationPackQuantity(IWebElement printerContainer, int findElementTimeout)
        {
            return SeleniumHelper.FindElementByDataAttributeValue(
                GetInstallationPackRowElement(printerContainer, findElementTimeout), QuantityDataAttributeSelector, "true", findElementTimeout).Text;
        }

        public string InstallationPackUnitPrice(IWebElement printerContainer, int findElementTimeout)
        {
            return SeleniumHelper.FindElementByDataAttributeValue(
                GetInstallationPackRowElement(printerContainer, findElementTimeout), UnitPriceDataAttributeSelector, "true", findElementTimeout).Text;
        }

        public string InstallationPackTotalPrice(IWebElement printerContainer, int findElementTimeout)
        {
            return SeleniumHelper.FindElementByDataAttributeValue(
                GetInstallationPackRowElement(printerContainer, findElementTimeout), TotalPriceDataAttributeSelector, "true", findElementTimeout).Text;
        }

        public IWebElement GetServicePackRowElement(IWebElement printerContainer, int findElementTimeout)
        {
            return SeleniumHelper.FindElementByCssSelector(printerContainer, ServicePackRowSelector, findElementTimeout);
        }

        public string ServicePackQuantity(IWebElement printerContainer, int findElementTimeout)
        {
            return SeleniumHelper.FindElementByDataAttributeValue(
                GetServicePackRowElement(printerContainer, findElementTimeout), QuantityDataAttributeSelector, "true", findElementTimeout).Text;
        }

        public string ServicePackUnitPrice(IWebElement printerContainer, int findElementTimeout)
        {
            return SeleniumHelper.FindElementByDataAttributeValue(
                GetServicePackRowElement(printerContainer, findElementTimeout), UnitPriceDataAttributeSelector, "true", findElementTimeout).Text;
        }

        public string ServicePackTotalPrice(IWebElement printerContainer, int findElementTimeout)
        {
            return SeleniumHelper.FindElementByDataAttributeValue(
                GetServicePackRowElement(printerContainer, findElementTimeout), TotalPriceDataAttributeSelector, "true", findElementTimeout).Text;
        }

        public string TotalLinePrice(IWebElement printerContainer, int findElementTimeout)
        {
            return SeleniumHelper.FindElementByDataAttributeValue(
                TotalLinePriceDataAttributeSelector, "true", findElementTimeout).Text;
        }
    }
}
