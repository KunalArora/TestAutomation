using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

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
            SeleniumHelper.SetCheckBox(InputSentByPostCheckBoxElement,true);
            SeleniumHelper.SetCheckBox(InputStartDateConfirmedCheckBoxElement, true);
            SeleniumHelper.SetCheckBox(InputTermsAndConditionsSignedCheckBoxElement, true);
            SeleniumHelper.SetCheckBox(InputPreventionOfMoneyLaunderingActCheckBoxElement, true);
            SeleniumHelper.SetCheckBox(InputMachinesHandedOverCheckBoxElement, true);
            SeleniumHelper.SetCheckBox(InputResellerInvoicingCheckBoxElement, true);
            SeleniumHelper.SetCheckBox(InputBrotherInvoicingCheckBoxElement, true);
            SeleniumHelper.SetCheckBox(InputTakeoverReceivedCheckBoxElement, true);
        }

    }
}
