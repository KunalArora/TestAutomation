﻿using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverProposalsSummaryPage : BasePage
    {
        public static string Url = "/mps/local-office/proposals/summary";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_ButtonApprove")]
        public IWebElement ApproveButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonDecline")]
        public IWebElement DeclineButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalDeclineReason_Input")]
        public IWebElement DeclineReasonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonProposalDeclineDecline")]
        public IWebElement RejectButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalApproveCustomerReference_Input")]
        public IWebElement CustomerReferenceElement;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalApproveContractReference_Input")]
        public IWebElement ReferenceElement;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalApproveCompanyName_Input")]
        public IWebElement CompanyNameElement;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalApproveCreditCheckCompleted_Input")]
        public IWebElement CreditCheckCompletedElement;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalApproveCreditValue_Input")]
        public IWebElement CreditLimitElement;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalApproveValidUntil_Input")]
        public IWebElement ValidUntilElement;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalApproveCreditCheckNotNeeded_Input")]
        public IWebElement CreditCheckNotNeededElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonProposalApproveApprove")]
        public IWebElement AcceptButtonElement;
        

        public void ClickApproveButton()
        {
            ApproveButtonElement.Click();
        }

        public void ClickDeclineButton()
        {
            ScrollTo(DeclineButtonElement);
            DeclineButtonElement.Click();
        }

        public void SelectDeclineReason()
        {
            if (IsAustriaSystem() || IsGermanSystem())
            {
                SelectFromDropdown(DeclineReasonElement, "Andere");
            }
            else if (IsUKSystem() || IsIrelandSystem())
            {
                SelectFromDropdown(DeclineReasonElement, "Other");
            }
            else if (IsItalySystem())
            {
                SelectFromDropdown(DeclineReasonElement, "Altro");
            }
            else if (IsFranceSystem())
            {
                SelectFromDropdown(DeclineReasonElement, "Autre");
            }
            else if (IsSpainSystem())
            {
                SelectFromDropdown(DeclineReasonElement, "Otro");
            }
            else if (IsSwedenSystem())
            {
                SelectFromDropdown(DeclineReasonElement, "Annat");
            }
            else if (IsNetherlandSystem())
            {
                SelectFromDropdown(DeclineReasonElement, "Overig");
            }
            else if (IsDenmarkSystem())
            {
                SelectFromDropdown(DeclineReasonElement, "Udløbet");
            }
            else if (IsBelgiumSystem())
            {
                SelectFromDropdown(DeclineReasonElement, RejectionReason());
            }
            else if (IsSwissSystem())
            {
                SelectFromDropdown(DeclineReasonElement, SwissRejectionReason());
            }
            else if (IsPolandSystem())
            {
                SelectFromDropdown(DeclineReasonElement, "Inny");
            }
            else if (IsFinlandSystem())
            {
               SelectFromDropdown(DeclineReasonElement, "Muu");
            }
            else if (IsNorwaySystem())
            {
                SelectFromDropdown(DeclineReasonElement, "Annet");
            }
        }

        private string RejectionReason()
        {
            var reason = "";
            var language = SpecFlow.GetContext("BelgianLanguage");

            switch (language)
            {
                case "French" :
                    reason = "Autre";
                    break;
                case "Dutch" :
                    reason = "Andere";
                    break;
                default:
                    reason = "Andere";
                    break;
            }

            return reason;
        }

        private string SwissRejectionReason()
        {
            var reason = "";
            var language = SpecFlow.GetContext("BelgianLanguage");

            switch (language)
            {
                case "Français":
                    reason = "Autres";
                    break;
                case "Deutsch":
                    reason = "Andere";
                    break;

                default:
                    reason = "Andere";
                    break;
            }

            return reason;
        }

        public LocalOfficeApproverProposalsPage ClickRejectButton()
        {
            ScrollTo(RejectButtonElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, RejectButtonElement);

            return GetTabInstance<LocalOfficeApproverProposalsPage>(Driver);
        }

        public LocalOfficeApproverProposalsPage ClickAccpetButton()
        {
                
            ScrollTo(AcceptButtonElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, AcceptButtonElement);
            
            var result = GetTabInstance<LocalOfficeApproverProposalsPage>(Driver);

            return result;
        }

        public void EnterCustomerReference(string str)
        {
            if (str.Equals(string.Empty))
                str = MpsUtil.CustomerReference();

            ClearAndType(CustomerReferenceElement, str);
        }

        public void EnterReference(string reference)
        {
            if (reference.Equals(string.Empty))
                reference = MpsUtil.CustomerReference();
            ClearAndType(ReferenceElement, reference);
        }

        
        public void EnterValidUntil()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsFranceSystem() || IsItalySystem() || IsAustriaSystem() || IsUKSystem())
                ValidUntilElement.SendKeys(MpsUtil.SomeDaysFromToday(RegionInfo.TwoLetterISORegionName));
        }

        public void EnterCreditLimit()
        {
            if (IsGermanSystem()
                || IsAustriaSystem() 
                || IsDenmarkSystem()
                || IsFinlandSystem() 
                || IsFranceSystem()
                ||IsIrelandSystem()
                || IsNorwaySystem()
                || IsSwedenSystem()
                || IsSwissSystem()
                || IsBelgiumSystem()
                || IsNetherlandSystem()
                || IsPolandSystem())
                ClearAndType(CreditLimitElement, "30000");
        }

        public void TickCreditCheckNotNeeded()
        {
            if (!CreditCheckNotNeededElement.Selected)
                CreditCheckNotNeededElement.Click();
        }

        public void EnterApprovalInformation()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterCustomerReference("");
            EnterReference("");
            EnterValidUntil();
            EnterCreditLimit();
            TickCreditCheckNotNeeded();
            WebDriver.Wait(Helper.DurationType.Second, 3);
        }

    }
}
