using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Contract
{
    //    class MpsBankContractStepActions
    public class MpsBankContractStepActions : StepActionBase
    {
        private readonly IWebDriver _webDriver;
        private readonly IContractShiftService _contractShiftService;

        public MpsBankContractStepActions(
            IContractShiftService contractShiftService,
            IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext scenarioContext,
            IUrlResolver urlResolver,
            ILoggingService loggingService,
            IRuntimeSettings runtimeSettings)
            : base(webDriverFactory, contextData, pageService, scenarioContext, urlResolver, loggingService, runtimeSettings)
        {
            _webDriver = WebDriverFactory.GetWebDriverInstance(UserType.Bank);
            _contractShiftService = contractShiftService;

        }


        public BankContractsApprovedProposalsPage NavigateToContractsApprovedProposalsPage(BankDashBoardPage bankDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(bankDashBoardPage);
            ClickSafety(bankDashBoardPage.ContractsLinkElement, bankDashBoardPage, true);
            return PageService.GetPageObject<BankContractsApprovedProposalsPage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);
        }

        public BankContractsMaintenancePage ClickOnContractEdit(BankContractsAcceptedPage bankContractsAcceptedPage)
        {
            LoggingService.WriteLogOnMethodEntry(bankContractsAcceptedPage);
            bankContractsAcceptedPage.ClickOnContractEdit(ContextData.ProposalId, _webDriver);
            return PageService.GetPageObject<BankContractsMaintenancePage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);
        }

        public BankContractsAwaitingAcceptancePage CheckAllBoxesAndSave(BankContractsMaintenancePage bankContractsMaintenancePage)
        {
            LoggingService.WriteLogOnMethodEntry(bankContractsMaintenancePage);
            bankContractsMaintenancePage.EnableCheckAll();
            ClickSafety(bankContractsMaintenancePage.ButtonSaveElement, bankContractsMaintenancePage, true);
            return PageService.GetPageObject<BankContractsAwaitingAcceptancePage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);
        }

        public void ContractTimeShift(int backToTheMonth)
        {
            LoggingService.WriteLogOnMethodEntry(backToTheMonth);
            var days = (int)(DateTime.Now - DateTime.Now.AddMonths(-backToTheMonth)).TotalDays;
            _contractShiftService.ContractTimeShiftCommand(ContextData.ProposalId, days, "d", false, true, "Any");
        }

        public BankContractsAwaitingAcceptancePage NavigateToContractsAwaitingAcceptancePage(BankContractsApprovedProposalsPage bankContractsApprovedProposalsPage)
        {
            LoggingService.WriteLogOnMethodEntry(bankContractsApprovedProposalsPage);
            ClickSafety(bankContractsApprovedProposalsPage.SignatureExpectedTabElement, bankContractsApprovedProposalsPage, true);
            return PageService.GetPageObject<BankContractsAwaitingAcceptancePage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);
        }

        public BankContractsSummaryPage ClickOnViewSummary(BankContractsAwaitingAcceptancePage bankContractsAwaitingAcceptancePage)
        {
            LoggingService.WriteLogOnMethodEntry(bankContractsAwaitingAcceptancePage);
            bankContractsAwaitingAcceptancePage.ClickOnViewSummary(ContextData.ProposalId, _webDriver);
            return PageService.GetPageObject<BankContractsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);
        }

        public BankContractsAcceptedPage ClickOnAccept(BankContractsSummaryPage bankContractsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(bankContractsSummaryPage);
            ClickSafety(bankContractsSummaryPage.AcceptButtonElement, bankContractsSummaryPage);
            bankContractsSummaryPage.SeleniumHelper.WaitUntil(d => bankContractsSummaryPage.FinalAcceptButtonElement.Enabled);
            ClickSafety(bankContractsSummaryPage.FinalAcceptButtonElement, bankContractsSummaryPage, true);
            return PageService.GetPageObject<BankContractsAcceptedPage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);

        }

        private void ClickSafety(IWebElement element, IPageObject pageObject, bool IsUntilUrlChanges = false)
        {
            LoggingService.WriteLogOnMethodEntry(element, pageObject);
            pageObject.SeleniumHelper.ClickSafety(element, IsUntilUrlChanges: IsUntilUrlChanges);
        }

        public void CheckTheBillingToEnsureDetailsAreCorrectlyPopulated()
        {
            LoggingService.WriteLogOnMethodEntry();
            // TODO MPS-4773 DL INVOICE AND VALIDATE
        }
    }
}
