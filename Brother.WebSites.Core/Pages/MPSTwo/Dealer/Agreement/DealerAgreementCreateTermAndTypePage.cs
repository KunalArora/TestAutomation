using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
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

        //WebElement properties
        [FindsBy(How = How.Id, Using = "content_1_InputUsageType_Input")]
        public IWebElement UsageTypeElement;

        [FindsBy(How = How.Id, Using = "content_1_InputContractLength_Input")]
        public IWebElement ContractLengthElement;

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
    }
}

