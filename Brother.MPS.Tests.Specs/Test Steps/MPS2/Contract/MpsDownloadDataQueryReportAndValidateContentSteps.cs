using Brother.MPS.Tests.Specs.MPS2.Proposal;
using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Contract;
using Brother.Tests.Specs.StepActions.Dealership;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Contract
{
    [Binding]
    public class MpsDownloadDataQueryReportAndValidateContentSteps 
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _driver;
        private readonly IContextData _contextData;
        private readonly PageService _pageService;
        private readonly ICountryService _countryService;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly MpsSignInStepActions _mpsSignInStepActions;
        private readonly MpsDealerProposalStepActions _mpsDealerProposalStepActions;
        private readonly MpsDealerContractStepActions _mpsDealerContractStepActions;
        private readonly RunCommandService _runCommandService;
        private readonly ITranslationService _translationService;
        private readonly IPageParseHelper _pageParseHelper;
        private DealerReportsDashboardPage _dealerReportsDashboardPage;
        private readonly MpsDealerProposalSteps _dealerProposalSteps;
        private readonly MpsLocalOfficeApproverProposalSteps _localOfficeApproverProposalSteps;
        private readonly MpsDealerContractSteps _dealerContractSteps;
        private readonly MpsLocalOfficeApproverContractSteps _localOfficeApproverContractSteps;
        private readonly MpsValidateDealerReportStepActions _validateDealerReportStepActions;

        public MpsDownloadDataQueryReportAndValidateContentSteps(
            MpsValidateDealerReportStepActions validateDealerReportStepActions,
            MpsLocalOfficeApproverContractSteps localOfficeApproverContractSteps,
            MpsDealerContractSteps dealerContractSteps,
            MpsLocalOfficeApproverProposalSteps localOfficeApproverProposalSteps,
            MpsDealerProposalSteps dealerProposalSteps,
            MpsSignInStepActions mpsSignInStepActions,
            MpsDealerProposalStepActions mpsDealerProposalStepActions,
            MpsDealerContractStepActions mpsDealerContractStepActions,
            ScenarioContext context,
            IWebDriver driver,
            MpsContextData contextData,
            PageService pageService,
            ICountryService countryService,
            IUserResolver userResolver,
            IUrlResolver urlResolver,
            ITranslationService translationService,
            RunCommandService runCommandService,
            IPageParseHelper pageParseHelper)
        {
            _context = context;
            _driver = driver;
            _contextData = contextData;
            _pageService = pageService;
            _countryService = countryService;
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _mpsSignInStepActions = mpsSignInStepActions;
            _mpsDealerProposalStepActions = mpsDealerProposalStepActions;
            _mpsDealerContractStepActions = mpsDealerContractStepActions;
            _runCommandService = runCommandService;
            _translationService = translationService;
            _pageParseHelper = pageParseHelper;
            _dealerProposalSteps = dealerProposalSteps;
            _localOfficeApproverProposalSteps = localOfficeApproverProposalSteps;
            _dealerContractSteps = dealerContractSteps;
            _localOfficeApproverContractSteps = localOfficeApproverContractSteps;
            _validateDealerReportStepActions = validateDealerReportStepActions;
        }

        [Given(@"I create a running contract ""(.*)"" with below devices:")]
        public void GivenCreateARunningContractWithBelowDevices(int innerContractId, Table printers)
        {
            // Partially similar as BusinessScenatio_1.feature
            var ContractType = "PURCHASE_AND_CLICK";
            var UsageType = "MINIMUM_VOLUME";
            var ContractTerm = "THREE_YEARS";
            var BillingType = "QUARTERLY_IN_ARREARS";
            var ServicePackType = "PAY_UPFRONT";

            _dealerProposalSteps.WhenIHaveNavigatedToTheCreateProposalPage();
            _dealerProposalSteps.WhenICreateAProposalOfContractType(ContractType);
            _dealerProposalSteps.WhenIEnterTheProposalDescription();
            _dealerProposalSteps.WhenICreateANewCustomerForTheProposal();
            _dealerProposalSteps.WhenISelectUsageTypeOfContractTermOfBillingTypeOfAndServicePackTypeOf(UsageType, ContractTerm, BillingType, ServicePackType);
            _dealerProposalSteps.WhenIAddThesePrinters(printers);
            _validateDealerReportStepActions.SnapPrintersToValidateDealerReport(innerContractId);
            _dealerProposalSteps.WhenIPopulateTheClickPriceForEachOfTheSpecifiedPrinters();
            var dealerProposalsCreateSummaryPage = _dealerProposalSteps.GetDealerProposalsCreateSummaryPage();
            _validateDealerReportStepActions.SnapDealerProposalsCreateSummaryPage(innerContractId, dealerProposalsCreateSummaryPage);
            _dealerProposalSteps.WhenISaveTheAboveProposalAndSubmitItForApproval();
            _localOfficeApproverProposalSteps.WhenACloudMpsLocalOfficeApproverApprovesTheAboveProposal();
            _dealerProposalSteps.WhenIHaveNavigatedToTheApprovedProposalsPageAndNavigateToTheProposalSummaryPageForThisProposal();
            _dealerProposalSteps.WhenIClickTheDownloadProposalButtonAndVerifyIfIAmAbleToOpenThePDF();
            _dealerContractSteps.WhenISignTheAboveProposal();
            _localOfficeApproverContractSteps.WhenACloudMPSLocalOfficeApproverAcceptsTheAboveProposal();
        }

        [When(@"I click the 'Report' tab and click the 'Dealer Contract Report'")]
        public void WhenAsADealerClickTheReportTabAndClickTheDealerContractReport()
        {
            var dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl)); ;
            _dealerReportsDashboardPage = _mpsDealerProposalStepActions.NavigateToDealerReportsDashboardPage(dealerDashboardPage);
        }

        [Then(@"I can download, open the file and ensure the data is correct")]
        public void ThenICanDownloadOpenTheFileAndEnsureTheDataIsCorrect()
        {
            _validateDealerReportStepActions.DownloadReportAndVerify(_dealerReportsDashboardPage);
        }


    }
}
