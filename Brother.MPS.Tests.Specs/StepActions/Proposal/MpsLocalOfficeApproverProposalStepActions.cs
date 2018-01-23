using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Proposal
{
    public class MpsLocalOfficeApproverProposalStepActions : StepActionBase
    {
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IWebDriver _localOfficeApproverWebDriver;
        private readonly IContextData _contextData;
        private readonly ITranslationService _translationService;

        public MpsLocalOfficeApproverProposalStepActions(IWebDriverFactory webDriverFactory,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings,
            ITranslationService translationService,
            ILoggingService loggingService,
            MpsContextData contextData,
            MpsSignInStepActions mpsSignIn)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _contextData = contextData;
            _localOfficeApproverWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeApprover);
            _translationService = translationService;
        }

        public LocalOfficeApproverDashBoardPage SignInAsLocalOfficeApproverAndNavigateToDashboard(string email, string password, string url)
        {
            LoggingService.WriteLogOnMethodEntry(email, password, url);
            return _mpsSignIn.SignInAsLocalOfficeApprover(email, password, url);
        }

        public LocalOfficeApproverApprovalPage NavigateToApprovalDashboard(LocalOfficeApproverDashBoardPage localOfficeApproverDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverDashBoardPage);
            ClickSafety(localOfficeApproverDashBoardPage.ApprovalTabElement, localOfficeApproverDashBoardPage);
            return PageService.GetPageObject<LocalOfficeApproverApprovalPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverProposalsPage NavigateToApprovalListPage(LocalOfficeApproverApprovalPage localOfficeApproverApprovalPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalPage);
            ClickSafety( localOfficeApproverApprovalPage.ProposalLinkElement, localOfficeApproverApprovalPage );
            return PageService.GetPageObject<LocalOfficeApproverProposalsPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalProposalsSummaryPage NavigateToViewSummary(LocalOfficeApproverProposalsPage localOfficeApproverProposalsPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverProposalsPage);
            int proposalId = _contextData.ProposalId;
            localOfficeApproverProposalsPage.ClickOnSummaryPage(proposalId, _localOfficeApproverWebDriver);
            return PageService.GetPageObject<LocalOfficeApproverApprovalProposalsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalProposalsApprovedPage ApproveProposal(LocalOfficeApproverApprovalProposalsSummaryPage localOfficeApproverAprovalProposalsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverAprovalProposalsSummaryPage);
            localOfficeApproverAprovalProposalsSummaryPage.ClickOnAccept(RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<LocalOfficeApproverApprovalProposalsApprovedPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
            
        }

        public LocalOfficeApproverReportsDataQueryPage NavigateToReportsDataQueryPage(LocalOfficeApproverDashBoardPage localOfficeApproverDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverDashBoardPage);
            ClickSafety(localOfficeApproverDashBoardPage.LocalApprovalReportingElement, localOfficeApproverDashBoardPage);
            var localOfficeApproverReportsDashboardPage =  PageService.GetPageObject<LocalOfficeApproverReportsDashboardPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
            ClickSafety( localOfficeApproverReportsDashboardPage.DataQueryElement, localOfficeApproverReportsDashboardPage);
            return PageService.GetPageObject<LocalOfficeApproverReportsDataQueryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverReportsProposalSummaryPage ClidkOnValidateAndApplySpecialPricing(LocalOfficeApproverApprovalSpecialPricingPage localOfficeApproverApprovalSpecialPricingPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalSpecialPricingPage);
            localOfficeApproverApprovalSpecialPricingPage.SeleniumHelper.WaitUntil(d => {
                var isDisplayed = localOfficeApproverApprovalSpecialPricingPage.NextButton.Displayed;
                var isHidden = localOfficeApproverApprovalSpecialPricingPage.NextButton.GetAttribute("class").Contains("hidden");
                if (isDisplayed == false || isHidden) return true; 
                ClickSafety(localOfficeApproverApprovalSpecialPricingPage.NextButton, localOfficeApproverApprovalSpecialPricingPage);
                return false;
            }, RuntimeSettings.DefaultFindElementTimeout);
            ClickSafety(localOfficeApproverApprovalSpecialPricingPage.ValidateButton, localOfficeApproverApprovalSpecialPricingPage);
            localOfficeApproverApprovalSpecialPricingPage.EnterAdditionalAuditInformation(RuntimeSettings.DefaultFindElementTimeout);
            ClickSafety(localOfficeApproverApprovalSpecialPricingPage.ApplySpecialPricing, localOfficeApproverApprovalSpecialPricingPage);
            return PageService.GetPageObject<LocalOfficeApproverReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);            
        }

        public LocalOfficeApproverReportsProposalSummaryPage NavigateToReportsProposalSummaryPage(LocalOfficeApproverReportsDataQueryPage localOfficeApproverReportsDataQueryPage, int proposalId )
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverReportsDataQueryPage, proposalId);
            var proposalIdString = proposalId.ToString();
            localOfficeApproverReportsDataQueryPage.ClickOnSearchedProposal(proposalId, RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<LocalOfficeApproverReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public void PopulateSpecialPricingInstallation(LocalOfficeApproverApprovalSpecialPricingPage localOfficeApproverApprovalSpecialPricingPage, IEnumerable<SpecialPricingProperties> specialPriceList)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalSpecialPricingPage, specialPriceList);
            localOfficeApproverApprovalSpecialPricingPage.SwitchNavInstallTab(RuntimeSettings.DefaultFindElementTimeout);
            foreach (var specialPrice in specialPriceList)
            {
                localOfficeApproverApprovalSpecialPricingPage.EnterSpecialPriceInstallation(specialPrice, RuntimeSettings.DefaultFindElementTimeout);
            }
        }
        public void PopulateSpecialPricingService(LocalOfficeApproverApprovalSpecialPricingPage localOfficeApproverApprovalSpecialPricingPage, IEnumerable<SpecialPricingProperties> specialPriceList)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalSpecialPricingPage, specialPriceList);
            localOfficeApproverApprovalSpecialPricingPage.SwitchNavServiceTab(RuntimeSettings.DefaultFindElementTimeout);
            foreach (var specialPrice in specialPriceList)
            {
                localOfficeApproverApprovalSpecialPricingPage.EnterSpecialPriceService(specialPrice, RuntimeSettings.DefaultFindElementTimeout);
            }
        }

        public void PopulateSpecialPricingClickPrice(LocalOfficeApproverApprovalSpecialPricingPage localOfficeApproverApprovalSpecialPricingPage, IEnumerable<SpecialPricingProperties> specialPriceClickList)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalSpecialPricingPage, specialPriceClickList);
            localOfficeApproverApprovalSpecialPricingPage.SwitchNavClickTab(RuntimeSettings.DefaultFindElementTimeout);
            foreach( var specialPrice in specialPriceClickList) {
                localOfficeApproverApprovalSpecialPricingPage.EnterSpecialPriceClick(specialPrice, RuntimeSettings.DefaultFindElementTimeout);
            }
            
        }

        public LocalOfficeApproverApprovalSpecialPricingPage ClickOnSpecialPricing(LocalOfficeApproverReportsProposalSummaryPage localOfficeApproverReportsProposalSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverReportsProposalSummaryPage);
            ClickSafety(localOfficeApproverReportsProposalSummaryPage.ButtonSpecialPricing, localOfficeApproverReportsProposalSummaryPage);
            return PageService.GetPageObject<LocalOfficeApproverApprovalSpecialPricingPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalContractsSummaryPage ClickViewSummary(LocalOfficeApproverContractsAwaitingAcceptancePage localofficeApproverApprovalContractsAwaitingAcceptancePage, int proposalId)
        {
            LoggingService.WriteLogOnMethodEntry(localofficeApproverApprovalContractsAwaitingAcceptancePage, proposalId);
            localofficeApproverApprovalContractsAwaitingAcceptancePage.ClickOnViewSummary(proposalId, _localOfficeApproverWebDriver);
            return PageService.GetPageObject<LocalOfficeApproverApprovalContractsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalContractsAcceptedPage AcceptContract(LocalOfficeApproverApprovalContractsSummaryPage localOfficeApproverApprovalContractsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalContractsSummaryPage);
            localOfficeApproverApprovalContractsSummaryPage.OnClickAccept();
            return PageService.GetPageObject<LocalOfficeApproverApprovalContractsAcceptedPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public void VerifyAcceptContract(LocalOfficeApproverApprovalContractsAcceptedPage _localOfficeApproverApprovalContractsAcceptedPage, int proposalId, string proposalName)
        {
            LoggingService.WriteLogOnMethodEntry(_localOfficeApproverApprovalContractsAcceptedPage, proposalId, proposalName);
            _localOfficeApproverApprovalContractsAcceptedPage.VerifyContractFilter(proposalId, proposalName, RuntimeSettings.DefaultFindElementTimeout);
        }

        private void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            LoggingService.WriteLogOnMethodEntry(element, pageObject);
            pageObject.SeleniumHelper.ClickSafety(element, RuntimeSettings.DefaultFindElementTimeout);
        }


        public LocalOfficeApproverApprovalProposalsDeclinedPage DeclineProposal(LocalOfficeApproverApprovalProposalsSummaryPage localOfficeApproverApprovalProposalsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalProposalsSummaryPage);
            string proposalDeclineReasonExpired = _translationService.GetProposalDeclineReasonText(TranslationKeys.ProposalDeclineReason.Expired, _contextData.Culture);

            localOfficeApproverApprovalProposalsSummaryPage.DeclineProposal(proposalDeclineReasonExpired, RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<LocalOfficeApproverApprovalProposalsDeclinedPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

    }
}
