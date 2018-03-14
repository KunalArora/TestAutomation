using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Globalization;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Proposal
{
    public class MpsBankProposalStepActions : StepActionBase
    {
        private readonly IWebDriver _webDriver;
        private readonly IContractShiftService _contractShiftService;

        public MpsBankProposalStepActions(
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

        public BankProposalsAwaitingApprovalPage NavigateToProposalsAwaitingApprovalPage(BankDashBoardPage bankDashBoardPage)
        {
            ClickSafety(bankDashBoardPage.OffersLinkElement, bankDashBoardPage,true);
            return PageService.GetPageObject<BankProposalsAwaitingApprovalPage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);
        }

        public BankProposalsSummaryPage ClickViewSummary(BankProposalsAwaitingApprovalPage bankProposalsAwaitingApprovalPage)
        {
            LoggingService.WriteLogOnMethodEntry(bankProposalsAwaitingApprovalPage);
            int proposalId = ContextData.ProposalId;
            bankProposalsAwaitingApprovalPage.ClickOnViewSummary(proposalId, _webDriver);
            return PageService.GetPageObject<BankProposalsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);
        }
        public void AssertAreEqualBankSummary(BankProposalsSummaryPage bankProposalsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(bankProposalsSummaryPage);
            var expectedCustomer = ContextData.SnapValues[typeof(DealerProposalsConvertCustomerInformationPage)];
            var expectedSummary = ContextData.SnapValues[typeof(DealerProposalsConvertSummaryPage)];
            var actual = SummaryValue.Parse(bankProposalsSummaryPage);

            //Assert.AreEqual(actual["BankSummaryTable.ContractDetailsContractNumber"], "???"); //TODO MPS-4773 ASK noch nicht gesetzt => not yet set
            var ci = new CultureInfo(ContextData.Culture);
            Assert.AreEqual(ContextData.ContractTerm, actual["BankSummaryTable.ContractDetailsDuration"]);
            Assert.AreEqual(DateTime.Parse(expectedSummary["InputEnvisagedStartDate"]), DateTime.Parse(actual["BankSummaryTable.ContractDetailsStartDate"],ci)); // 11.04.2018
            Assert.AreEqual(ContextData.LeasingBillingCycle, actual["BankSummaryTable.ContractDetailsBillingFrequencyLeasing"]);
            Assert.AreEqual(ContextData.BillingType, actual["BankSummaryTable.ContractDetailsBillingFrequencyClick"]);
            Assert.AreEqual(expectedSummary["SummaryTable.DeviceTotalsTotalPriceNet"], actual["BankSummaryTable.ContractDetailsContractValue"]);// 2.959,66 €
            // content_1_BankSummaryTable_ContractDetailsLeasingFactor	1,66700%
            Assert.AreEqual(expectedSummary["SummaryTable.PaymentAmountNet"], actual["BankSummaryTable.ContractDetailsBillingRate"], "ContractDetailsBillingRate"); // 49,33 €
            Assert.AreEqual(expectedSummary["SummaryTable.FinanceTotalNet"], actual["BankSummaryTable.ContractDetailsSumOfRates"], "ContractDetailsSumOfRates"); // 2.959,80 €


            var adrArr = actual["CustomerDetailsAddress"].Replace("\r", "").Split('\n');
            Assert.AreEqual(expectedCustomer["InputCustomerName"], adrArr[0], "CustomerDetailsAddress.0");
            Assert.AreEqual(expectedCustomer["CustomerLocation.InputStreet"]+" "+ expectedCustomer["CustomerLocation.InputNumber"], adrArr[1], "CustomerDetailsAddress.1");
            Assert.AreEqual(expectedCustomer["CustomerLocation.InputPostCode"] + " " + expectedCustomer["CustomerLocation.InputTown"], adrArr[2], "CustomerDetailsAddress.2");
            Assert.AreEqual(expectedCustomer["InputBankName"], actual["CustomerDetailsBankName"], "CustomerDetailsBankName");
            Assert.AreEqual(expectedCustomer["InputBankSortCode"], actual["CustomerDetailsBankCode"], "CustomerDetailsBankCode");
            Assert.AreEqual(expectedCustomer["InputBankAccountNumber"], actual["CustomerDetailsBankNumber"], "CustomerDetailsBankNumber");
            Assert.AreEqual(expectedCustomer["InputBankIban"], actual["CustomerDetailsIBAN"], "CustomerDetailsIBAN");
            Assert.AreEqual(expectedCustomer["InputBankBic"], actual["CustomerDetailsBIC"], "CustomerDetailsBIC");
        }

        public BankProposalsApprovedPage ClickOnAccept(BankProposalsSummaryPage bankProposalsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(bankProposalsSummaryPage);
            ClickSafety(bankProposalsSummaryPage.ApproveButtonElement, bankProposalsSummaryPage);
            bankProposalsSummaryPage.EnterApprovalInformation(); // de:Freigabeinformationen
            ClickSafety(bankProposalsSummaryPage.AcceptButtonElement, bankProposalsSummaryPage, true);
            return PageService.GetPageObject<BankProposalsApprovedPage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);

        }


        private void ClickSafety(IWebElement element, IPageObject pageObject, bool IsUntilUrlChanges = false)
        {
            LoggingService.WriteLogOnMethodEntry(element, pageObject);
            pageObject.SeleniumHelper.ClickSafety(element, IsUntilUrlChanges: IsUntilUrlChanges);
        }

    }
}
