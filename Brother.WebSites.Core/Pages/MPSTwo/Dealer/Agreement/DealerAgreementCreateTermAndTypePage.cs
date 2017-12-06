using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement
{
    public class DealerAgreementCreateTermAndTypePage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "#content_1_InputUsageType_Input";
        private const string _url = "/mps/dealer/agreements/manage/term-type";

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

        public ISeleniumHelper SeleniumHelper { get; set; }

        //WebElement properties
        [FindsBy(How = How.Id, Using = "content_1_InputUsageType_Input")]
        public IWebElement UsageTypeElement;

        [FindsBy(How = How.Id, Using = "content_1_InputContractLength_Input")]
        public IWebElement ContractLengthElement;

        [FindsBy(How = How.Id, Using = "content_1_InputServicePaymentOption_Input")]
        public IWebElement ServiceElement;

        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement NextButton;

        public void SelectUsageType(string usage)
        {
            SelectFromDropdown(UsageTypeElement, usage);
        }

        public void SelectContractLength(string contractLength)
        {
            SelectFromDropdown(ContractLengthElement, contractLength);
        }

        public void SelectService(string service)
        {
            SelectFromDropdown(ServiceElement, service);
        }
    }
}

