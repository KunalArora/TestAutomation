using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminContractsEditEndDatePage : BasePage, IPageObject
    {
        private const string _url = "/mps/local-office/admin/contracts/edit-end-date";
        private const string _validationElementSelector = "#content_1_ButtonSave"; // Save button

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        [FindsBy(How = How.CssSelector, Using = ".input-sm.js-mps-charge-type")]
        public IWebElement ChargeTypeSelectorElement;

        [FindsBy(How = How.CssSelector, Using = ".input-sm.js-mps-cost-price")]
        public IWebElement CostPriceInputElement;

        [FindsBy(How = How.CssSelector, Using = ".input-sm.js-mps-dealer-margin")]
        public IWebElement DealerMarginInputElement;

        [FindsBy(How = How.CssSelector, Using = ".input-sm.js-mps-customer-price")]
        public IWebElement CustomerPriceInputElement;

        [FindsBy(How = How.CssSelector, Using = ".js-mps-add-additional-charge-button")]
        public IWebElement AddAdditionalChargeButtonElement;


        [FindsBy(How = How.CssSelector, Using = "#content_1_InputEndDate_Input")]
        public IWebElement InputEndDateInputElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputDescription_Input")]
        public IWebElement InputDescriptionElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSave")]
        public IWebElement ButtonSaveElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonApplyContractCancellation")]
        public IWebElement ButtonApplyContractCancellationElement;


        public void EnterCancellationDateAndReason(DateTime endDate, string reason, string countryIso)
        {
            LoggingService.WriteLogOnMethodEntry(endDate, reason, countryIso);
            InputEndDateInputElement.SendKeys(MpsUtil.DateTimeString(endDate, countryIso));
            ClearAndType(InputDescriptionElement, reason);
            //SeleniumHelper.ClickSafety(ButtonSaveElement, RuntimeSettings.DefaultFindElementTimeout,true);
        }
    }
}
