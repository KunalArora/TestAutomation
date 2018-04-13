using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Services;
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
        private readonly ITranslationService _translationService;

        //page objects used by these steps
        private DealerDashBoardPage _dealerDashboardPage;
        private DealerContractsPage _dealerContractsPage;
        private DealerManageDevicesPage _dealerManageDevicesPage;
        private DealerSetCommunicationMethodPage _dealerSetCommunicationMethodPage;
        private DealerSetInstallationTypePage _dealerSetInstallationTypePage;
        private DealerSendInstallationEmailPage _dealerSendInstallationEmailPage;
        private DealerSendSwapInstallationEmailPage _dealerSwapInstallationEmailPage;
        private DealerReportsProposalsSummaryPage _dealerReportsProposalsSummaryPage;

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
            ITranslationService translationService,
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
            _translationService = translationService;
        }

        
        //Similar function is already present in this file so, refactor this particular function.
        [When(@"I locate the contract with id ""(.*)""")]
        public void WhenILocateTheContractWithId()
        {
            // Locate the contract using proposalId
            // Eventually, use contextData to retreive proposalId
            _mpsDealerContractStepActions.FilterContractUsingProposalIdAction(_dealerContractsPage);     
        }

        [When(@"I click Swap Device in the Actions menu for device to be swapped on the Manage devices page")]
        public void WhenIClickSwapDeviceInTheActionsMenuForDeviceToBeSwappedOnTheManageDevicesPage()
        {
            _dealerManageDevicesPage = _mpsDealerContractStepActions.RetrieveDealerManageDevicesPage();
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                if (product.IsSwap)
                {
                    _contextData.SwapOldDeviceSerialNumber = product.SerialNumber;
                    _mpsDealerContractStepActions.ClickOnSwapDevice(_dealerManageDevicesPage, product.SerialNumber);
                }
            }
        }
        
        [When(@"I create a ""(.*)"" swap installation request with ""(.*)"" installation type for ""(.*)"" communication")]
        public void WhenICreateASwapInstallationRequestWithInstallationTypeForCommunication(string swapType, string installationType, string communicationMethod)
        {
            _contextData.SwapType = _translationService.GetSwapTypeText(swapType, _contextData.Culture);
            _dealerSetCommunicationMethodPage = _mpsDealerContractStepActions.ConfirmSwapAndSelectSwapType(_dealerManageDevicesPage);
            _dealerSetInstallationTypePage = _mpsDealerContractStepActions.SelectCommunicationMethodAndProceedForCloud(_dealerSetCommunicationMethodPage);
            _dealerSwapInstallationEmailPage = _mpsDealerContractStepActions.SelectInstallationTypeAndProceedForSwap(_dealerSetInstallationTypePage, installationType);
            _dealerManageDevicesPage = _mpsDealerContractStepActions.PopulateInstallerEmailAndSendEmailForSwap(_dealerSwapInstallationEmailPage);
        }

        [When(@"I create a ""(.*)"" installation request for ""(.*)"" communication")]
        public void WhenICreateAInstallationRequestForCommunication(string installationType, string communicationMethod)
        {
            _dealerSetCommunicationMethodPage = _mpsDealerContractStepActions.CreateInstallationRequest(_dealerManageDevicesPage);
            switch(communicationMethod)
            {
                case "Cloud":
                    _dealerSetInstallationTypePage = _mpsDealerContractStepActions.SelectCommunicationMethodAndProceedForCloud(_dealerSetCommunicationMethodPage);
                    _dealerSendInstallationEmailPage = _mpsDealerContractStepActions.SelectInstallationTypeAndProceed(_dealerSetInstallationTypePage, installationType);
                    break;
                case "Email":
                    _dealerSendInstallationEmailPage = _mpsDealerContractStepActions.SelectCommunicationMethodAndProceedForEmail(_dealerSetCommunicationMethodPage);
                    break;
                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
            _dealerManageDevicesPage = _mpsDealerContractStepActions.PopulateInstallerEmailAndSendEmail(_dealerSendInstallationEmailPage);
        }

        [When(@"I will be able to see the installation request created above on the Manage Devices page for the above proposal")]
        public void ThenIWillBeAbleToSeeTheInstallationRequestCreatedAboveOnTheManageDevicesPageForTheAboveProposal()
        {
            var url = _mpsDealerContractStepActions.RetrieveInstallationRequestUrl(_dealerManageDevicesPage);
            _contextData.WebInstallUrl = url;
        }

        [When(@"I will be able to see on the Manage Devices page that all devices for the above contract are connected with default Print Counts")]
        public void WhenIWillBeAbleToSeeOnTheManageDevicesPageThatAllDevicesForTheAboveContractAreConnectedWithDefaultPrintCounts()
        {
            _mpsDealerContractStepActions.CloudInstallationCompleteCheck(_dealerManageDevicesPage);
        }

        [When(@"I update the print count")]
        public void WhenIUpdateThePrintCount()
        {
            _mpsDealerContractStepActions.UpdateAndNotifyBOCForPrintCounts();
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.ProposalId);
        }

        [When(@"I update the Consumable Order and verify it\.")]
        public void WhenIUpdateTheConsumableOrderAndVerifyIt_()
        {
            _mpsDealerContractStepActions.UpdateAndNotifyBOCForConsumableOrder();
            _mpsDealerContractStepActions.RunCommandServicesRequests();
            _mpsDealerContractStepActions.VerifyConsumableOrder(_dealerReportsProposalsSummaryPage);
        }

        [When(@"I update the print count and verify it on the Manage devices page")]
        public void WhenIUpdateThePrintCountAndVerifyItOnTheManageDevicesPage()
        {
            _mpsDealerContractStepActions.UpdateAndNotifyBOCForPrintCounts();
            _mpsDealerContractStepActions.RunCommandServicesRequests();
            ThenIWillBeAbleToSeeOnTheManageDevicesPageThatAboveDevicesHaveUpdatedPrintCounts();
        }

        [When(@"I navigate to the contract summary page in the reports section")]
        public void WhenINavigateToTheContractSummaryPageInTheReportsSection()
        {
            var dealerDashBoardPage = _mpsSignInStepActions.SignInAsDealer(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var dealerReportsDashboardPage = _mpsDealerContractStepActions.NavigateToReportsDashboardPage(dealerDashBoardPage);
            var dealerReportsDataQueryPage = _mpsDealerContractStepActions.NavigateToReportsDataQueryPage(dealerReportsDashboardPage);
             _dealerReportsProposalsSummaryPage = _mpsDealerContractStepActions.NavigateToContractsSummaryPage(dealerReportsDataQueryPage);
        }

        [When(@"I verify updated print count")]
        public void WhenIVerifyUpdatedPrintCount()
        {
            _mpsDealerContractStepActions.VerifyUpdatedPrintCounts(_dealerReportsProposalsSummaryPage);
        }


        [When(@"I update the print count, raise consumable order and service request for above devices")]
        public void WhenIUpdateThePrintCountRaiseConsumableOrderAndServiceRequestForAboveDevices()
        {
            _mpsDealerContractStepActions.UpdateAndNotifyBOCForPrintCounts();
            _mpsDealerContractStepActions.UpdateAndNotifyBOCForConsumableOrder();
            _mpsDealerContractStepActions.UpdateAndNotifyBOCForServiceRequest();
            _mpsDealerContractStepActions.RunCommandServicesRequests();
        }

        [When(@"I will raise consumable order and service request for above devices")]
        public void WhenIWillRaiseConsumableOrderAndServiceRequestForAboveDevices()
        {
            _mpsDealerContractStepActions.UpdateAndNotifyBOCForConsumableOrder();
            _mpsDealerContractStepActions.UpdateAndNotifyBOCForServiceRequest();
            _mpsDealerContractStepActions.RunCommandServicesRequests();
        }

        [When(@"I will be able to see on the Manage Devices page that above devices have updated Print Counts")]
        public void ThenIWillBeAbleToSeeOnTheManageDevicesPageThatAboveDevicesHaveUpdatedPrintCounts()
        {
            _dealerManageDevicesPage = _mpsDealerContractStepActions.RetrieveDealerManageDevicesPage();
            _mpsDealerContractStepActions.CheckForUpdatedPrintCount(_dealerManageDevicesPage);
        }

        [When(@"I will be able to see the status of the installed device is set Being Replaced on the Manage Devices page for the above proposal")]
        public void ThenIWillBeAbleToSeeTheStatusOfTheInstalledDeviceIsSetBeingReplacedOnTheManageDevicesPageForTheAboveProposal()
        {
            _mpsDealerContractStepActions.VerifySwappedDeviceStatusAction(_dealerManageDevicesPage);
            var url = _mpsDealerContractStepActions.RetrieveInstallationRequestUrl(_dealerManageDevicesPage);
            _contextData.WebSwapInstallUrl = url;
        }
        
        [When(@"I sign the above proposal")]
        public void WhenISignTheAboveProposal()
        {
            var dealerDashboardPage = _mpsDealerProposalStepActions.NavigateToDashboardPage(_urlResolver.BaseUrl);
            var dealerContractsApprovedProposalPage = _mpsDealerProposalStepActions.NavigateToDealerContractsApprovedProposalPage(dealerDashboardPage);
            var dealerContractsSummaryPage = _mpsDealerProposalStepActions.ClickViewOffer(dealerContractsApprovedProposalPage);
            var dealerContractsAwaitingAcceptancePage = _mpsDealerProposalStepActions.SignToContract(dealerContractsSummaryPage);
        }

        [When(@"I navigate to the Accepted Contracts page and I locate the above contract and click Manage Devices button")]
        public void WhenINavigateToTheAcceptedContractsPageAndILocateTheAboveContractAndClickManageDevicesButton()
        {
            var resourceContractTypePurchaseAndClick = _translationService.GetContractTypeText(TranslationKeys.ContractType.PurchaseAndClick, _contextData.Culture);
            var resourceContractTypeEPP = _translationService.GetContractTypeText(TranslationKeys.ContractType.EasyPrintProAndService, _contextData.Culture);

            _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealerContractsPage = _mpsDealerContractStepActions.NavigateToContractsPage(_dealerDashboardPage);
            if( _contextData.ContractType == resourceContractTypePurchaseAndClick || _contextData.ContractType == resourceContractTypeEPP)
            {
                _mpsDealerContractStepActions.MoveToAcceptedContractsTab(_dealerContractsPage);
            }else
            {
                _mpsDealerContractStepActions.MoveToAwaitingAcceptanceContractsTab(_dealerContractsPage);
            }
            _mpsDealerContractStepActions.FilterContractUsingProposalIdAction(_dealerContractsPage);
            _dealerManageDevicesPage = _mpsDealerContractStepActions.ClickOnManageDevicesAndProceed(_dealerContractsPage);
            _runCommandService.RunCreateCustomerAndPersonCommand();
        }

        [Then(@"I will be able to see the status of the swap device is set Being Swapped with updated print counts on the Manage Devices page for the above proposal")]
        public void ThenIWillBeAbleToSeeTheStatusOfTheSwapDeviceIsSetBeingSwappedWithUpdatedPrintCountsOnTheManageDevicesPageForTheAboveProposal()
        {
            _dealerManageDevicesPage = _mpsDealerContractStepActions.RetrieveDealerManageDevicesPage();
            _mpsDealerContractStepActions.CheckForSwapDeviceUpdatedPrintCount(_dealerManageDevicesPage);
        }

        [Then(@"I can see the above proposal in the Rejected list")]
        public void WhenICanSeeTheAboveProposalInTheRejectedList()
        {
            var dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var dealerContractsRejectedPage = _mpsDealerProposalStepActions.NavigateToDealerContractsRejectedPage(dealerDashboardPage);
            _mpsDealerContractStepActions.VerifyRejectedContractInRejectedContractsList(dealerContractsRejectedPage);
        }

        [When(@"I verify that the email installation is completed successfuly")]
        public void WhenIVerifyThatTheEmailInstallationIsCompletedSuccessfuly()
        {
            _mpsDealerContractStepActions.EmailInstallationCompleteCheck(_dealerManageDevicesPage);
        }

        [When(@"I navigate to Accepted Contracts Page and click Manage devices button")]
        public void WhenINavigateToAcceptedContractsPageAndClickManageDevicesButton()
        {
            _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealerContractsPage = _mpsDealerContractStepActions.NavigateToContractsPage(_dealerDashboardPage);
            _mpsDealerContractStepActions.MoveToAcceptedContractsTab(_dealerContractsPage);
            _mpsDealerContractStepActions.FilterContractUsingProposalIdAction(_dealerContractsPage);
            _dealerManageDevicesPage = _mpsDealerContractStepActions.ClickOnManageDevicesAndProceed(_dealerContractsPage);
            _runCommandService.RunCreateCustomerAndPersonCommand();
        }

        [When(@"I move the contract and change the status to running")]
        public void WhenIMoveTheContractAndChangeTheStatusToRunning()
        {
            _mpsDealerContractStepActions.MoveContract();
            _mpsDealerContractStepActions.ChangeContractToRunning();
        }
    }
}