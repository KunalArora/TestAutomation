using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement
{
    public class DealerAgreementCreateSummaryPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "#content_1_ButtonSaveAgreement";
        private const string _url = "/mps/dealer/agreements/manage/summary";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        //WebElement properties
        [FindsBy(How = How.Id, Using = "content_1_ButtonSaveAgreement")]
        public IWebElement SaveButton;

        [FindsBy(How = How.Id, Using = "content_1_ButtonCompleteSetupAgreement")]
        public IWebElement CompleteSetupButton;

        [FindsBy(How = How.CssSelector, Using = "#content_1_SummaryTable_ProposalDetailsContainer")]
        public IWebElement SummaryPageAgreementIdElement;

        public int AgreementId()
        {
            return Int32.Parse(SummaryPageAgreementIdElement.GetAttribute("data-mps-qa-id"));         
        }

        public void AcceptJavascriptPopupOnCompleteSetup(int findElementTimeout)
        {
            SeleniumHelper.AcceptJavascriptAlert(findElementTimeout);
        }
    }
}

