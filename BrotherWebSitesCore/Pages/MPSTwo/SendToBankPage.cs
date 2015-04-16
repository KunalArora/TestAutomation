using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Properties;
using Brother.Tests.Selenium.Lib.Support;
using BrotherWebSitesCore.Pages.Base;
using BrotherWebSitesCore.Pages.MPSTwo;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Pages.MPSTwo
{
    public class SendToBankPage : BasePage
    {
        public static string URL = "/mps/dealer/send-to-bank/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_1_legalFormInput")]
        private IWebElement legalFormDropdownElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_companyNumberInput_Input")]
        private IWebElement companyNumberFieldElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_vatNumberInput_Input")]
        private IWebElement ustNumberFieldElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_creditReformNumberInput_Input")]
        private IWebElement creditReformNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_accountNameInput_Input")]
        private IWebElement accountNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_accountKeyInput_Input")]
        private IWebElement accountKeyInputElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_accountNumberInput_Input")]
        private IWebElement accountNumberInputElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_iBanInput_Input")]
        private IWebElement iBanNumberInputElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_biCInput_Input")]
        private IWebElement biCNumberInputElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_companyInfo")]
        private IWebElement companyLegendElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_bankInfo")]
        private IWebElement bankLegendElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonNext")]
        private IWebElement sendToBankNextButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputLeasingBank")]
        private IWebElement leasingBankDropdownElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputAllowToSendToThirdParty")]
        private IWebElement thirdPartyElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSendToBank")]
        private IWebElement FinalButtonForSendToBankElement;
        
        
        

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
