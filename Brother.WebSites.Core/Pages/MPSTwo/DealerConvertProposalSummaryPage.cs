﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerConvertProposalSummaryPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_1_InputSendToLeasingBank_Label")]
        public IWebElement ThirdPartyApproval;
        [FindsBy(How = How.Id, Using = "content_1_InputEnvisagedStartDate_Input")]
        public IWebElement ProposedStartDate;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSaveAsContract")]
        public IWebElement SaveAsContractButton;
        [FindsBy(How = How.Id, Using = "content_1_InputSendToBrother_Input")]
        public IWebElement SendToBrotherElement;
        [FindsBy(How = How.Id, Using = "content_1_InputSendToSchufa_Label")]
        public IWebElement SchufaAuthorisationButton;
        [FindsBy(How = How.Id, Using = "content_1_InputSendToBrother_Label")]
        public IWebElement BrotherAuthorisationButton;
        
        
        

        public void IsConvertSummaryPageDisplayed()
        {
            if (ProposedStartDate == null)
                throw new Exception("Third party permission tick is not displayed");
            AssertElementPresent(ProposedStartDate, "Is convert proposal summary page displayed");
        }

        public void EnterProposedStartDateForContract(string countryIso)
        {
            LoggingService.WriteLogOnMethodEntry(countryIso);
            if (ProposedStartDate == null)
                throw new NullReferenceException("Contract start date field not displayed");
            ProposedStartDate.SendKeys(MpsUtil.SomeDaysFromToday(countryIso));
        }

        public void EnterProposedStartDateForContract()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ProposedStartDate == null)
                throw new NullReferenceException("Contract start date field not displayed");
            ProposedStartDate.SendKeys(MpsUtil.SomeDaysFromToday("GB"));
        }

        public void GiveThirdPartyCheckApproval()
        {
            IWebElement element = GetElementByCssSelector("#content_1_InputSendToLeasingBank_Label", 5);
            if (element != null)
                ThirdPartyApproval.Click();
            element = GetElementByCssSelector("#content_1_InputSendToBrother_Input", 5);
            if (element != null)
                SendToBrotherElement.Click();
        }

        public void GiveBrotherAuthorisation()
        {
            BrotherAuthorisationButton.Click();
        }

        public void GiveSchufaAuthorization()
        {
            if (IsBigAtSystem())
            {
                const string schufa = @"#content_1_InputSendToSchufa_Input";
                var schufaElement = GetElementByCssSelector(schufa, 10);
                if (IsElementPresent(schufaElement))
                    schufaElement.Click();
            }

            
        }

        public DealerProposalsAwaitingApprovalPage SaveProposalAsAContract()
        {
            if (SaveAsContractButton == null)
                throw new NullReferenceException("Save Contract button not available");
            SaveAsContractButton.Click();
           
            return GetInstance<DealerProposalsAwaitingApprovalPage>(Driver);
        }

        public DealerProposalsAwaitingApprovalPage DownloadAndSaveProposalAsAContract()
        {
            if (SaveAsContractButton == null)
                throw new NullReferenceException("Save Contract button not available");
            CalculationEngineModule.DownloadProposalPdfOnSendToBankSummaryPage(Driver);
            CalculationEngineModule.DownloadPageHtml(Driver, "Dealer_ProposalSummary");
            SaveAsContractButton.Click();
            WebDriver.Wait(DurationType.Second, 5);

            return GetInstance<DealerProposalsAwaitingApprovalPage>(Driver);
        }


        

    }
}
