using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
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

        public IWebElement SelectPrinter(string printerName, int findElementTimeout)
        {
            string containerSelector = string.Format("li#pc-{0}", printerName);
            string addButtonSelector = ".js-mps-product-open-add";

            var printerContainer = SeleniumHelper.FindElementByCssSelector(containerSelector, findElementTimeout);
            var addButton = SeleniumHelper.FindElementByCssSelector(printerContainer, addButtonSelector, findElementTimeout);

            addButton.Click();

            return printerContainer;
        }

        public void PopulatePrinterDetails(string printerName,
            int quantity,
            string installationPack,
            string servicePack,
            int findElementTimeout
            )
        {
            string quantityInputSelector = "#Quantity";
            string installationPackInputSelector = "#InstallationPackId";
            string servicePackInputSelector = "#ServicePackId";
            string addToAgreementButtonSelector = ".js-mps-product-configuration-submit";

            var printerContainer = SelectPrinter(printerName, findElementTimeout);
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

            addToAgreementButton.Click();
        }
    }
}
