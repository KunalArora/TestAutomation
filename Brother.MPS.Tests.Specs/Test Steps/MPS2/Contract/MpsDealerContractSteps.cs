﻿using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Common.Services;
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
            _dealerSetInstallationTypePage = _mpsDealerContractStepActions.SelectCommunicationMethodAndProceed(_dealerSetCommunicationMethodPage, communicationMethod);
            _dealerSwapInstallationEmailPage = _mpsDealerContractStepActions.SelectInstallationTypeAndProceedForSwap(_dealerSetInstallationTypePage, installationType);
            _dealerManageDevicesPage = _mpsDealerContractStepActions.PopulateInstallerEmailAndSendEmailForSwap(_dealerSwapInstallationEmailPage);
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
            var url = _mpsDealerContractStepActions.RetrieveInstallationRequestUrl(_dealerManageDevicesPage);
            _contextData.WebInstallUrl = url;
        }

        [When(@"I will be able to see on the Manage Devices page that all devices for the above contract are connected with default Print Counts")]
        public void WhenIWillBeAbleToSeeOnTheManageDevicesPageThatAllDevicesForTheAboveContractAreConnectedWithDefaultPrintCounts()
        {
            _mpsDealerContractStepActions.InstallationCompleteCheck(_dealerManageDevicesPage);
        }

        [When(@"I update the print count, raise consumable order and service request for above devices")]
        public void WhenIUpdateThePrintCountRaiseConsumableOrderAndServiceRequestForAboveDevices()
        {
            _mpsDealerContractStepActions.UpdateAndNotifyBOCForPrintCounts();
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
            _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealerContractsPage = _mpsDealerContractStepActions.NavigateToContractsPage(_dealerDashboardPage);
            _mpsDealerContractStepActions.MoveToAcceptedContractsTab(_dealerContractsPage);
            _mpsDealerContractStepActions.FilterContractUsingProposalIdAction(_dealerContractsPage);
            _dealerManageDevicesPage = _mpsDealerContractStepActions.ClickOnManageDevicesAndProceed(_dealerContractsPage);
            _runCommandService.RunCreateCustomerAndPersonCommand();
        }

        [Then(@"I will be able to see the status of the swap device ""(.*)"" is set Being Swapped with updated print counts on the Manage Devices page for the above proposal")]
        public void ThenIWillBeAbleToSeeTheStatusOfTheSwapDeviceIsSetBeingSwappedWithUpdatedPrintCountsOnTheManageDevicesPageForTheAboveProposal(string swapNewDeviceSerialNumber)
        {
            _dealerManageDevicesPage = _mpsDealerContractStepActions.RetrieveDealerManageDevicesPage();
            _mpsDealerContractStepActions.CheckForSwapDeviceUpdatedPrintCount(_dealerManageDevicesPage, swapNewDeviceSerialNumber);
        }

    }
}