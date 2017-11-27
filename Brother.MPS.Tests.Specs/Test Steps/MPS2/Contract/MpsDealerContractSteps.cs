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
            IUrlResolver urlResolver)
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
        }

        [When(@"I have navigated to the Contracts Accepted page as a ""(.*)"" from ""(.*)""")]
        public void WhenIHaveNavigatedToTheContractsAcceptedPageAsAFrom(string role, string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);

            switch (role)
            {
                case "Cloud MPS Dealer":
                    _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
                    break;
                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
            _dealerContractsPage = _mpsDealerContractStepActions.NavigateToContractsPage(_dealerDashboardPage);
            _dealerContractsAcceptedPage = _mpsDealerContractStepActions.NavigateToContractsAcceptedPage(_dealerContractsPage);
        }

        //Similar function is already present in this file so, refactor this particular function.
        [Given(@"I have navigated to the Accepted Contracts page as a ""(.*)"" from ""(.*)""")]
        public void GivenIHaveNavigatedToTheAcceptedContractsPageAsAFrom(string role, string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);

            switch (role)
            {
                case "Cloud MPS Dealer":
                    _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
                    break;
                default:
                    ScenarioContext.Current.Pending();
                    break;
            }

            _dealerContractsPage = _mpsDealerContractStepActions.NavigateToContractsPage(_dealerDashboardPage);
            _mpsDealerContractStepActions.MoveToAcceptedContractsTab(_dealerContractsPage);
        }


        [When(@"I have navigated to the Manage Devices for ""(.*)""")]
        public void WhenIHaveNavigatedToTheManageDevicesFor(int proposalId)
        {
            //Use contextData to retrieve proposalId
            _dealerManageDevicesPage = _mpsDealerContractStepActions.NavigateToManageDevicesPage(_dealerContractsAcceptedPage, proposalId);
            _contextData.ProposalId = proposalId;
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

        [Then(@"I will be able to see the installation request created above on the Manage Devices page for the above proposal")]
        public void ThenIWillBeAbleToSeeTheInstallationRequestCreatedAboveOnTheManageDevicesPageForTheAboveProposal()
        {
            _mpsDealerContractStepActions.VerifyInstallationRequestCreated(_dealerManageDevicesPage, _contextData.InstallerEmail, _contextData.CompanyLocation);
        }

        [When(@"I will be able to see on the Manage Devices page that all devices for the above contract are connected with default Print Counts")]
        public void WhenIWillBeAbleToSeeOnTheManageDevicesPageThatAllDevicesForTheAboveContractAreConnectedWithDefaultPrintCounts()
        {
            _mpsDealerContractStepActions.InstallationCompleteCheck(_dealerManageDevicesPage, _contextData.PrintersProperties);
        }

        [When(@"I update the print count for ""(.*)"" to (.*) and (.*)")]
        public void WhenIUpdateThePrintCountForToAnd(string serialNumber, int monoPrintCount, int colorPrintCount)
        {
            _mpsDealerContractStepActions.UpdatePrintCounts(serialNumber, monoPrintCount, colorPrintCount);
        }

        [Then(@"I will be able to see on the Manage Devices page that ""(.*)"" have updated Print Counts")]
        public void ThenIWillBeAbleToSeeOnTheManageDevicesPageThatHaveUpdatedPrintCounts(string serialNumber)
        {
            _dealerManageDevicesPage = _mpsDealerContractStepActions.RetrieveDealerManageDevicesPage();
            _mpsDealerContractStepActions.CheckForUpdatedPrintCount(_dealerManageDevicesPage, serialNumber);
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


    }
}