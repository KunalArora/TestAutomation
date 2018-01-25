using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement
{
    public class DealerAgreementConsumablesCreatePage: BasePage, IPageObject
    {
        private const string _validationElementSelector = ".js-mps-button-create-consumable-order";
        private const string _url = "/mps/dealer/agreement/{agreementId}/consumables/create/?id={mpsDeviceId}"; // TODO: Replace agreementId & mpsDeviceId with dynamic parameters

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
        private const string DataItemTypeSelector = "item-type";
        private const string AlertSuccessSelector = ".alert.alert-success";

        // Web Elements
        [FindsBy(How = How.CssSelector, Using = ".js-mps-button-create-consumable-order")]
        public IWebElement SubmitOrderButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-nav-back")]
        public IWebElement BackButtonElement;

        public void SelectConsumables(
            string tonerInkBlackStatus, string tonerInkCyanStatus, string tonerInkMagentaStatus, string tonerInkYellowStatus)
        {
            if (tonerInkBlackStatus.ToLower().Equals("empty"))
            {
                SelectConsumableCheckBox("Black Toner");
            }

            if (tonerInkCyanStatus.ToLower().Equals("empty"))
            {
                SelectConsumableCheckBox("Cyan Toner");
            }

            if (tonerInkMagentaStatus.ToLower().Equals("empty"))
            {
                SelectConsumableCheckBox("Magenta Toner");
            }

            if (tonerInkYellowStatus.ToLower().Equals("empty"))
            {
                SelectConsumableCheckBox("Yellow Toner");
            }
        }

        public void VerifySuccessfulOrderCreation()
        {
            // Verify success & close modal alert
            var alertSuccessElement = SeleniumHelper.FindElementByCssSelector(AlertSuccessSelector, RuntimeSettings.DefaultFindElementTimeout);
            SeleniumHelper.ClickSafety(alertSuccessElement.FindElement(By.ClassName("close")), RuntimeSettings.DefaultFindElementTimeout);
        }


        private void SelectConsumableCheckBox(string DataItemTypeValue)
        {
            var element = SeleniumHelper.FindElementByDataAttributeValue(DataItemTypeSelector, DataItemTypeValue, RuntimeSettings.DefaultFindElementTimeout);
            if (element != null || !element.Enabled)
            {
                if (!element.Selected)
                {
                    SeleniumHelper.ClickSafety(element, RuntimeSettings.DefaultFindElementTimeout);
                }
            }
            else
            {
                throw new Exception(string.Format("Checkbox for {0} Consumable could not be selected", DataItemTypeValue));
            }
        }
    }
}
