using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Contract;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Contract
{
    [Binding]
    public class MpsDealerContractSteps
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

        //page objects used by these steps
        private DealerDashBoardPage _dealerDashboardPage;
        private DealerContractsPage _dealerContractsPage;
        private DealerManageDevicesPage _dealerManageDevicesPage;
        private DealerSetCommunicationMethodPage _dealerSetCommunicationMethodPage;
        private DealerSetInstallationTypePage _dealerSetInstallationTypePage;
        private DealerSendInstallationEmailPage _dealerSendInstallationEmailPage;
        private DealerSendSwapInstallationEmailPage _dealerSwapInstallationEmailPage;
        private DealerContractsAcceptedPage _dealerContractsAcceptedPage;

        public MpsDealerContractSteps(MpsSignInStepActions mpsSignInStepActions,
            MpsDealerProposalStepActions mpsDealerProposalStepActions,
            MpsDealerContractStepActions mpsDealerContractStepActions,
            ScenarioContext context,
            IWebDriver driver,
            MpsContextData contextData,
            PageService pageService,
            ICountryService countryService,
            IUserResolver userResolver,
            IUrlResolver urlResolver,
            RunCommandService runCommandService)
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
        }

        
        //Similar function is already present in this file so, refactor this particular function.
        [When(@"I locate the contract with id ""(.*)""")]
        public void WhenILocateTheContractWithId(int proposalId)
        {
            // Locate the contract using proposalId
            // Eventually, use contextData to retreive proposalId
            _mpsDealerContractStepActions.FilterContractUsingProposalId(_dealerContractsPage, proposalId);     
        }

        //Similar function is already present in this file so, refactor this particular function.
        [When(@"I click Manage Devices in the Actions menu")]
        public void WhenIClickManageDevicesInTheActionsMenu()
        {
            _dealerManageDevicesPage = _mpsDealerContractStepActions.ClickOnManageDevicesAndProceed(_dealerContractsPage);
        }

        [When(@"I create a ""(.*)"" installation request for ""(.*)"" communication")]
        public void WhenICreateAInstallationRequestForCommunication(string installationType, string communicationMethod)
        {
            _dealerSetCommunicationMethodPage = _mpsDealerContractStepActions.CreateInstallationRequest(_dealerManageDevicesPage);
            _dealerSetInstallationTypePage = _mpsDealerContractStepActions.SelectCommunicationMethodAndProceed(_dealerSetCommunicationMethodPage, communicationMethod);
            _dealerSendInstallationEmailPage = _mpsDealerContractStepActions.SelectInstallationTypeAndProceed(_dealerSetInstallationTypePage, installationType);
            _dealerManageDevicesPage = _mpsDealerContractStepActions.PopulateInstallerEmailAndSendEmail(_dealerSendInstallationEmailPage);
        }

        [When(@"I will be able to see the installation request created above on the Manage Devices page for the above proposal")]
        public void ThenIWillBeAbleToSeeTheInstallationRequestCreatedAboveOnTheManageDevicesPageForTheAboveProposal()
        {
            var url = _mpsDealerContractStepActions.RetrieveInstallationRequestUrl(_dealerManageDevicesPage, _contextData.InstallerEmail, _contextData.CompanyLocation);
            _contextData.WebInstallUrl = url;
        }

        [When(@"I will be able to see on the Manage Devices page that all devices for the above contract are connected with default Print Counts")]
        public void WhenIWillBeAbleToSeeOnTheManageDevicesPageThatAllDevicesForTheAboveContractAreConnectedWithDefaultPrintCounts()
        {
            var products = _contextData.PrintersProperties;
            _mpsDealerContractStepActions.InstallationCompleteCheck(_dealerManageDevicesPage, products);
        }

        [When(@"I update the print count, raise consumable order and service request for above devices")]
        public void WhenIUpdateThePrintCountRaiseConsumableOrderAndServiceRequestForAboveDevices()
        {
            _mpsDealerContractStepActions.UpdatePrintCounts();
            _mpsDealerContractStepActions.RaiseConsumableOrder();
        }


        [Then(@"I will be able to see on the Manage Devices page that above devices have updated Print Counts")]
        public void ThenIWillBeAbleToSeeOnTheManageDevicesPageThatAboveDevicesHaveUpdatedPrintCounts()
        {
            _dealerManageDevicesPage = _mpsDealerContractStepActions.RetrieveDealerManageDevicesPage();
            _mpsDealerContractStepActions.CheckForUpdatedPrintCount(_dealerManageDevicesPage);
        }

        [Then(@"I will be able to see the status of the installed device is set Being Replaced on the Manage Devices page for the above proposal")]
        public void ThenIWillBeAbleToSeeTheStatusOfTheInstalledDeviceIsSetBeingReplacedOnTheManageDevicesPageForTheAboveProposal()
        {
            _mpsDealerContractStepActions.VerifySwappedDeviceStatus(_dealerManageDevicesPage, _contextData.SwapDeviceSerialNumber);
        }

        [When(@"I sign the above proposal")]
        public void WhenISignTheAboveProposal()
        {
            var dealerDashboardPage = _mpsDealerProposalStepActions.NavigateToDashboardPage(_urlResolver.BaseUrl);
            var dealerProposalsApprovedPage = _mpsDealerProposalStepActions.NavigateToDealerContractsApprovedProposalPage(dealerDashboardPage);
            var dealerContractsSummaryPage = _mpsDealerProposalStepActions.ClickViewOffer(dealerProposalsApprovedPage, _contextData.ProposalId);
            var dealerContractsAwaitingAcceptancePage = _mpsDealerProposalStepActions.SignToContract(dealerContractsSummaryPage);
        }

        [When(@"I navigate to the Accepted Contracts page and I locate the above contract and click Manage Devices button")]
        public void WhenINavigateToTheAcceptedContractsPageAndILocateTheAboveContractAndClickManageDevicesButton()
        {
            _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealerContractsPage = _mpsDealerContractStepActions.NavigateToContractsPage(_dealerDashboardPage);
            _mpsDealerContractStepActions.MoveToAcceptedContractsTab(_dealerContractsPage);
            _mpsDealerContractStepActions.FilterContractUsingProposalId(_dealerContractsPage, _contextData.ProposalId);
            _dealerManageDevicesPage = _mpsDealerContractStepActions.ClickOnManageDevicesAndProceed(_dealerContractsPage);
            _runCommandService.RunCreateCustomerAndPersonCommand();
        }
    }
}