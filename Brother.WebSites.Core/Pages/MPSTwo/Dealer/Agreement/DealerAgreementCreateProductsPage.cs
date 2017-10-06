using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement
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

        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement NextButton;

        public ISeleniumHelper SeleniumHelper { get; set; }

        public IWebElement SelectPrinter(string printerName)
        {
            string containerSelector = string.Format("li#pc-{0}", printerName);
            string addButtonSelector = ".js-mps-product-open-add";

            var printerContainer = SeleniumHelper.FindElementByCssSelector(containerSelector, 10);
            var addButton = SeleniumHelper.FindElementByCssSelector(printerContainer, addButtonSelector, 10);

            addButton.Click();

            return printerContainer;
        }

        public void PopulatePrinterDetails(string printerName,
            int quantity,
            string installationPack,
            string servicePack,
            bool continueToClickPrice = false)
        {
            string quantityInputSelector = "#Quantity";
            string installationPackInputSelector = "#InstallationPackId";
            string servicePackInputSelector = "#ServicePackId";
            string addToAgreementButtonSelector = ".js-mps-product-configuration-submit";
            string continueLinkSelector = ".js-mps-trigger-next";

            var printerContainer = SelectPrinter(printerName);
            var quantityInput = SeleniumHelper.FindElementByCssSelector(printerContainer, quantityInputSelector, 10);
            var installationPackInput = SeleniumHelper.FindElementByCssSelector(printerContainer, installationPackInputSelector, 10);
            var servicePackInput = SeleniumHelper.FindElementByCssSelector(printerContainer, servicePackInputSelector, 10);
            var addToAgreementButton = SeleniumHelper.FindElementByCssSelector(printerContainer, addToAgreementButtonSelector, 10);
         
            quantityInput.Clear();
            quantityInput.SendKeys(quantity.ToString());

            SeleniumHelper.SelectFromDropdownByText(installationPackInput, installationPack);
            SeleniumHelper.SelectFromDropdownByText(servicePackInput, servicePack);

            addToAgreementButton.Click();

            if (continueToClickPrice)
            {
                var continueLink = SeleniumHelper.FindElementByCssSelector(printerContainer, continueLinkSelector, 10);
                continueLink.Click();
            }
        }
    }
}
