using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BankContractsMaintenancePage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "#content_1_ButtonBack";
        private const string _url = "/mps/bank/contracts/maintenance";

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
        // #content_1_InputSentByPost_Input
        // #content_1_InputStartDateConfirmed_Input
        // #content_1_InputTermsAndConditionsSigned_Input
        // #content_1_InputPreventionOfMoneyLaunderingAct_Input
        // #content_1_InputMachinesHandedOver_Input
        // #content_1_InputResellerInvoicing_Input
        // #content_1_InputBrotherInvoicing_Input
        // #content_1_InputTakeoverReceived_Input

        [FindsBy(How = How.CssSelector, Using = "#content_1_InputSentByPost_Input")]
        public IWebElement InputSentByPostCheckBoxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputStartDateConfirmed_Input")]
        public IWebElement InputStartDateConfirmedCheckBoxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputTermsAndConditionsSigned_Input")]
        public IWebElement InputTermsAndConditionsSignedCheckBoxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputPreventionOfMoneyLaunderingAct_Input")]
        public IWebElement InputPreventionOfMoneyLaunderingActCheckBoxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputMachinesHandedOver_Input")]
        public IWebElement InputMachinesHandedOverCheckBoxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputResellerInvoicing_Input")]
        public IWebElement InputResellerInvoicingCheckBoxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputBrotherInvoicing_Input")]
        public IWebElement InputBrotherInvoicingCheckBoxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputTakeoverReceived_Input")]
        public IWebElement InputTakeoverReceivedCheckBoxElement;

        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSave")]
        public IWebElement ButtonSaveElement;

        public void EnableCheckAll()
        {
            LoggingService.WriteLogOnMethodEntry();
            CheckEnabled(InputSentByPostCheckBoxElement);
            CheckEnabled(InputStartDateConfirmedCheckBoxElement);
            CheckEnabled(InputTermsAndConditionsSignedCheckBoxElement);
            CheckEnabled(InputPreventionOfMoneyLaunderingActCheckBoxElement);
            CheckEnabled(InputMachinesHandedOverCheckBoxElement);
            CheckEnabled(InputResellerInvoicingCheckBoxElement);
            CheckEnabled(InputBrotherInvoicingCheckBoxElement);
            CheckEnabled(InputTakeoverReceivedCheckBoxElement);
        }

        private void CheckEnabled(IWebElement element, Boolean selected=true)
        {
            LoggingService.WriteLogOnMethodEntry(element,selected);
            if ( element.Selected == selected) { return; }
            SeleniumHelper.WaitUntil(d => element.Displayed && element.Enabled);
            element.Click();
        }
    }
}
