using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement
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

        // Agreement Details
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_AgreementName")]
        public IWebElement AgreementNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ContractTerm2")]
        public IWebElement ContractTermElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LeadCodeReference2")]
        public IWebElement LeadCodeReferenceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_FinanceReference")]
        public IWebElement LeasingFinanceReferenceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ContractType2")]
        public IWebElement ContractTypeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_UsageType2")]
        public IWebElement UsageTypeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DealerReference")]
        public IWebElement DealerReferenceElement;


        //Buttons
        [FindsBy(How = How.Id, Using = "content_1_ButtonSaveAgreement")]
        public IWebElement SaveButton;
        [FindsBy(How = How.Id, Using = "content_1_ButtonCompleteSetupAgreement")]
        public IWebElement CompleteSetupButton;
        [FindsBy(How = How.Id, Using = "content_1_ButtonPrintAgreement")]
        public IWebElement PrintAgreementButton;

  
        // Container
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ProposalDetailsContainer")]
        public IWebElement AgreementDetailsContainer;

        // Agreement Totals
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_GrandTotalPriceNet")]
        public IWebElement AgreementGrandTotalPriceNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_GrandTotalPriceGross")]
        public IWebElement AgreementGrandTotalPriceGrossElement;


        public int AgreementId()
        {
            return Int32.Parse(AgreementDetailsContainer.GetAttribute("data-mps-qa-id"));         
        }

        public void AcceptJavascriptPopupOnCompleteSetup(int findElementTimeout)
        {
            SeleniumHelper.AcceptJavascriptAlert(findElementTimeout);
        }

        public void VerifyContentOnSummaryPage( string AgreementName, string ContractTerm, 
            string LeadCodeReference, string LeasingFinanceReference, string ContractType,
            string UsageType, string DealerReference )
        {
            TestCheck.AssertIsEqual(AgreementNameElement.Text, AgreementName, "Agreement Name validation failed on summary page");
            TestCheck.AssertIsEqual(ContractTermElement.Text, ContractTerm, "Contract Term validation failed on summary page");
            TestCheck.AssertIsEqual(LeadCodeReferenceElement.Text, LeadCodeReference, "Lead code reference validation failed on summary page");
            TestCheck.AssertIsEqual(LeasingFinanceReferenceElement.Text, LeasingFinanceReference, "Leasing Finance Reference validation failed on summary page");
            TestCheck.AssertIsEqual(ContractTypeElement.Text, ContractType, "Contract Type validation failed on summary page");
            TestCheck.AssertIsEqual(UsageTypeElement.Text, UsageType, "Usage Type validation failed on summary page");
            TestCheck.AssertIsEqual(DealerReferenceElement.Text, DealerReference, "Dealer Reference validation failed on summary page");
        }
    }
}