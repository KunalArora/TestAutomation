using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

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




        public IWebElement SelectPrinter(string printerName)
        {
            LoggingService.WriteLogOnMethodEntry(printerName);
            string containerSelector = string.Format("li#pc-{0}", printerName);
            string addButtonSelector = ".js-mps-product-open-add";

            var printerContainer = SeleniumHelper.FindElementByCssSelector(containerSelector);
            var addButton = SeleniumHelper.FindElementByCssSelector(printerContainer, addButtonSelector);

            SeleniumHelper.ClickSafety(addButton);

            // Note: Repeatedly click Add button if it doesn't succeed
            while (!SeleniumHelper.FindElementByCssSelector(printerContainer, PreloaderSelector).Displayed)
            {
                SeleniumHelper.ClickSafety(addButton);
            }

            return printerContainer;
        }

        public IWebElement PopulatePrinterDetails(string printerName,
            int quantity,
            string installationPack,
            string servicePack,
            out IWebElement printerContainer
            )
        {
            LoggingService.WriteLogOnMethodEntry(printerName, quantity, installationPack, servicePack);
            string quantityInputSelector = "#Quantity";
            string installationPackInputSelector = "#InstallationPackId";
            string servicePackInputSelector = "#ServicePackId";
            string addToAgreementButtonSelector = ".js-mps-product-configuration-submit";

            // Filter the product
            ClearAndType(FilterProductElement, printerName);

            printerContainer = SelectPrinter(printerName);

            var quantityInput = SeleniumHelper.FindElementByCssSelector(
                printerContainer, quantityInputSelector);
            var installationPackInput = SeleniumHelper.FindElementByCssSelector(
                printerContainer, installationPackInputSelector);
            var servicePackInput = SeleniumHelper.FindElementByCssSelector(
                printerContainer, servicePackInputSelector);
            var addToAgreementButton = SeleniumHelper.FindElementByCssSelector(
                printerContainer, addToAgreementButtonSelector);
         
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

        public void ClickAddToAgreementButton(IWebElement printerContainer, IWebElement addToAgreementButton)
        {
            LoggingService.WriteLogOnMethodEntry(printerContainer, addToAgreementButton);
            SeleniumHelper.ClickSafety(addToAgreementButton);
            SeleniumHelper.FindElementByCssSelector(printerContainer, alertSuccessContinueSelector);
        }

        public IWebElement GetInstallationPackRowElement(IWebElement printerContainer)
        {
            LoggingService.WriteLogOnMethodEntry(printerContainer);
            return SeleniumHelper.FindElementByCssSelector(printerContainer, InstallationPackRowSelector);
        }

        public string InstallationPackQuantity(IWebElement printerContainer)
        {
            LoggingService.WriteLogOnMethodEntry(printerContainer);
            return SeleniumHelper.FindElementByDataAttributeValue(
                GetInstallationPackRowElement(printerContainer), QuantityDataAttributeSelector, "true").Text;
        }

        public string InstallationPackUnitPrice(IWebElement printerContainer)
        {
            LoggingService.WriteLogOnMethodEntry(printerContainer);
            return SeleniumHelper.FindElementByDataAttributeValue(
                GetInstallationPackRowElement(printerContainer), UnitPriceDataAttributeSelector, "true").Text;
        }

        public string InstallationPackTotalPrice(IWebElement printerContainer)
        {
            LoggingService.WriteLogOnMethodEntry(printerContainer);
            return SeleniumHelper.FindElementByDataAttributeValue(
                GetInstallationPackRowElement(printerContainer), TotalPriceDataAttributeSelector, "true").Text;
        }

        public IWebElement GetServicePackRowElement(IWebElement printerContainer)
        {
            LoggingService.WriteLogOnMethodEntry(printerContainer);
            return SeleniumHelper.FindElementByCssSelector(printerContainer, ServicePackRowSelector);
        }

        public string ServicePackQuantity(IWebElement printerContainer)
        {
            LoggingService.WriteLogOnMethodEntry(printerContainer);
            return SeleniumHelper.FindElementByDataAttributeValue(
                GetServicePackRowElement(printerContainer), QuantityDataAttributeSelector, "true").Text;
        }

        public string ServicePackUnitPrice(IWebElement printerContainer)
        {
            LoggingService.WriteLogOnMethodEntry(printerContainer);
            return SeleniumHelper.FindElementByDataAttributeValue(
                GetServicePackRowElement(printerContainer), UnitPriceDataAttributeSelector, "true").Text;
        }

        public string ServicePackTotalPrice(IWebElement printerContainer)
        {
            LoggingService.WriteLogOnMethodEntry(printerContainer);
            return SeleniumHelper.FindElementByDataAttributeValue(
                GetServicePackRowElement(printerContainer), TotalPriceDataAttributeSelector, "true").Text;
        }

        public string TotalLinePrice(IWebElement printerContainer)
        {
            LoggingService.WriteLogOnMethodEntry(printerContainer);
            return SeleniumHelper.FindElementByDataAttributeValue(
                TotalLinePriceDataAttributeSelector, "true").Text;
        }
    }
}
