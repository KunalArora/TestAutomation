using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerSendForApproverPage : BasePage
    {
        public static string URL = "/mps/dealer/send-to-bank/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_1_legalFormInput")]
        public IWebElement legalFormDropdownElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_companyNumberInput_Input")]
        public IWebElement companyNumberFieldElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_vatNumberInput_Input")]
        public IWebElement ustNumberFieldElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_creditReformNumberInput_Input")]
        public IWebElement creditReformNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_accountNameInput_Input")]
        public IWebElement accountNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_accountKeyInput_Input")]
        public IWebElement accountKeyInputElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_accountNumberInput_Input")]
        public IWebElement accountNumberInputElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_iBanInput_Input")]
        public IWebElement iBanNumberInputElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_biCInput_Input")]
        public IWebElement biCNumberInputElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_companyInfo")]
        public IWebElement companyLegendElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_bankInfo")]
        public IWebElement bankLegendElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonNext")]
        public IWebElement sendToBankNextButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputLeasingBank")]
        public IWebElement leasingBankDropdownElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputAllowToSendToThirdParty")]
        public IWebElement thirdPartyElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSendToBank")]
        public IWebElement FinalButtonForSendToBankElement;
        
        
        

        public void IsCompanyLegendDisplayed()
        {
            if(companyLegendElement == null)
                throw new NullReferenceException("Company form is not displayed");
            AssertElementPresent(companyLegendElement, "Company Lengend");
        }

        public void IsBankLegendDisplayed()
        {
            if (bankLegendElement == null)
                throw new NullReferenceException("Bank form is not displayed");
            AssertElementPresent(bankLegendElement, "Bank Lengend");
        }

        public void ProceedOnSendToBankScreen()
        {
            if (sendToBankNextButtonElement == null)
                throw new NullReferenceException("Next Button is not displayed");
            sendToBankNextButtonElement.Click();
        }

        private void SelectALegalForm()
        {
            SelectFromDropdownByValue(legalFormDropdownElement, MpsUtil.BusinessType());
        }

        public void FillCompanyDetails()
        {
            if (companyNumberFieldElement == null) 
                throw new NullReferenceException("Company number not available");
            if (ustNumberFieldElement == null)
                throw new NullReferenceException("UST-Number not available");
            if (creditReformNumberElement == null)
                throw new NullReferenceException("Credit Reform Number not available");

            SelectALegalForm();
            companyNumberFieldElement.SendKeys(MpsUtil.AccountNumber());
            ustNumberFieldElement.SendKeys(MpsUtil.VatNumber());
            creditReformNumberElement.SendKeys(MpsUtil.CreditReformNumber());
        }

        public void FillBankAccountInfo()
        {
            if (accountNameElement == null)
                throw new NullReferenceException("Account Name not available");
            if (accountKeyInputElement == null)
                throw new NullReferenceException("Bank Code not available");
            if (accountNumberInputElement == null)
                throw new NullReferenceException("Account Number not available");
            
            accountNameElement.SendKeys(MpsUtil.CompanyName());
            accountKeyInputElement.SendKeys(MpsUtil.BankCodeNumber());
            accountNumberInputElement.SendKeys(MpsUtil.AccountNumber());

        }

        private void SelectALeasingBank()
        {
            SelectFromDropdownByValue(leasingBankDropdownElement, "3");
        }

        private void ClickOnThirdPartyAuthorization()
        {
            if(thirdPartyElement == null) 
                throw new NullReferenceException("Third Party checkbox not found");
            thirdPartyElement.Click();
        }

        public void SelectALeasingBankAndProceed()
        {
            SelectALeasingBank();
            ClickOnThirdPartyAuthorization();
            ProceedOnSendToBankScreen();
        }

        public CloudExistingProposalPage SendProposalToActualContract()
        {
            if(FinalButtonForSendToBankElement == null)
                throw new NullReferenceException("Cannot actually send a proposal to bank");

            FinalButtonForSendToBankElement.Click();
            return GetTabInstance<CloudExistingProposalPage>(Driver);
        }

    }
}
