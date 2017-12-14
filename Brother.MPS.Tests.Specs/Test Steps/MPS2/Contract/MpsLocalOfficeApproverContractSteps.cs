using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Constants;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Contract;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Contract
{
    [Binding]
    class MpsLocalOfficeApproverContractSteps
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
        private readonly MpsLocalOfficeApproverContractStepActions _mpsLocalOfficeApproverContractStepActions;
        private readonly MpsLocalOfficeApproverProposalStepActions _mpsLocalOfficeApproverProposalStepActions;
        private readonly IRunCommandService _runCommandService;

        private LocalOfficeApproverApprovalContractsAcceptedPage _localOfficeApproverApprovalContractsAcceptedPage;
        private LocalOfficeApproverManagedevicesManagePage _localOfficeApproverManagedevicesManagePage;
        private readonly ITranslationService _translationService;

        public MpsLocalOfficeApproverContractSteps(
            MpsSignInStepActions mpsSignInStepActions,
            MpsDealerProposalStepActions mpsDealerProposalStepActions,
            MpsDealerContractStepActions mpsDealerContractStepActions,
            MpsLocalOfficeApproverContractStepActions mpsLocalOfficeApproverContractStepActions,
            MpsLocalOfficeApproverProposalStepActions mpsLocalOfficeApproverProposalStepActions,
            ScenarioContext context,
            IWebDriver driver,
            MpsContextData contextData,
            PageService pageService,
            ITranslationService translationService,
            IRunCommandService runCommandService,
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
            _mpsLocalOfficeApproverContractStepActions = mpsLocalOfficeApproverContractStepActions;
            _mpsLocalOfficeApproverProposalStepActions = mpsLocalOfficeApproverProposalStepActions;
            _runCommandService = runCommandService;
            _translationService = translationService;
        }

        [When(@"a Cloud MPS Local Office Approver accepts the above proposal")]
        public void WhenACloudMPSLocalOfficeApproverAcceptsTheAboveProposal()
        {
            //This step follows on from a previous scenario step - check context data has been set
            if (_contextData.Country == null || string.IsNullOrEmpty(_contextData.Culture))
            {
                throw new Exception("Context data not set correctly");
            }

            var localOfficeApproverDashBoardPage = _mpsSignInStepActions.SignInAsLocalOfficeApprover(_userResolver.LocalOfficeApproverUsername, _userResolver.LocalOfficeApproverPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var localOfficeApproverApprovalContractsAwaitingAcceptancePage = _mpsLocalOfficeApproverContractStepActions.NavigateToApprovalContractsAwaitingAcceptancePage(localOfficeApproverDashBoardPage);
            var localOfficeApproverApprovalContractsSummaryPage = _mpsLocalOfficeApproverContractStepActions.ClickViewSummary(localOfficeApproverApprovalContractsAwaitingAcceptancePage, _contextData.ProposalId);
            _localOfficeApproverApprovalContractsAcceptedPage = _mpsLocalOfficeApproverContractStepActions.AcceptContract(localOfficeApproverApprovalContractsSummaryPage);
        }

        [Then(@"I navigate to Accepted Contracts page and validate its existence")]
        public void WhenINavigateToAcceptedContractsPageAndValidateItsExistence()
        {
            _mpsLocalOfficeApproverContractStepActions.VerifyAcceptContract(_localOfficeApproverApprovalContractsAcceptedPage, _contextData.ProposalId, _contextData.ProposalName);
        }

        // TODO OIKE action 内部実装せよ

        [When(@"a Cloud MPS Local Office Approver locate the above contract and click Manage Devices button")]
        public void WhenACloudMPSLocalOfficeApproverLocateTheAboveContractAndClickManageDevicesButton()
        {
            LocalOfficeApproverDashBoardPage _localOfficeApproverDashBoardPage = _mpsLocalOfficeApproverProposalStepActions.SignInAsLocalOfficeApproverAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            LocalOfficeApproverManagedevicesContractsPage _localOfficeApproverManagedevicesContractsPage = _mpsLocalOfficeApproverContractStepActions.NavigateToDeviceManagementPage(_localOfficeApproverDashBoardPage);
            _localOfficeApproverManagedevicesManagePage =  _mpsLocalOfficeApproverContractStepActions.ClickOnActionsManageDevices(_localOfficeApproverManagedevicesContractsPage, _contextData.ProposalId);
            _runCommandService.RunCreateCustomerAndPersonCommand();

            //_localOfficeApproverDashBoardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            //_dealerContractsPage = _mpsDealerContractStepActions.NavigateToContractsPage(_localOfficeApproverDashBoardPage);
            //_mpsDealerContractStepActions.MoveToAcceptedContractsTab(_dealerContractsPage);
            //_mpsDealerContractStepActions.FilterContractUsingProposalId(_dealerContractsPage, _contextData.ProposalId);
            //_dealerManageDevicesPage = _mpsDealerContractStepActions.ClickOnManageDevicesAndProceed(_dealerContractsPage);
            //_runCommandService.RunCreateCustomerAndPersonCommand();
        }

        [When(@"a Cloud MPS Local Office Approver create a ""(.*)"" installation request for ""(.*)"" communication")]
        public void WhenACloudMPSLocalOfficeApproverCreateAInstallationRequestForCommunication(string installationType, string communicationMethod)
        {
            // /mps/local-office/manage-devices/set-communication-method
            LocalOfficeApproverManagedevicesSetCommunicationMethodPage _dealerSetCommunicationMethodPage = _mpsLocalOfficeApproverContractStepActions.CreateInstallationRequest(_localOfficeApproverManagedevicesManagePage);
            // /mps/local-office/manage-devices/set-installation-type
            LocalOfficeApproverManagedevicesSetInstallationTypePage _dealerSetInstallationTypePage = _mpsLocalOfficeApproverContractStepActions.SelectCommunicationMethodAndProceed(_dealerSetCommunicationMethodPage, communicationMethod);
            // /mps/local-office/manage-devices/send-installation-email
            LocalOfficeApproverManagedevicesSendInstallationEmailPage _dealerSendInstallationEmailPage = _mpsLocalOfficeApproverContractStepActions.SelectInstallationTypeAndProceed(_dealerSetInstallationTypePage, installationType);
            _localOfficeApproverManagedevicesManagePage = _mpsLocalOfficeApproverContractStepActions.PopulateInstallerEmailAndSendEmail(_dealerSendInstallationEmailPage);

            //_dealerSetCommunicationMethodPage = _mpsDealerContractStepActions.CreateInstallationRequest(_dealerManageDevicesPage);
            //_dealerSetInstallationTypePage = _mpsDealerContractStepActions.SelectCommunicationMethodAndProceed(_dealerSetCommunicationMethodPage, communicationMethod);
            //_dealerSendInstallationEmailPage = _mpsDealerContractStepActions.SelectInstallationTypeAndProceed(_dealerSetInstallationTypePage, installationType);
            //_dealerManageDevicesPage = _mpsDealerContractStepActions.PopulateInstallerEmailAndSendEmail(_dealerSendInstallationEmailPage);
        }

        [When(@"a Cloud MPS Local Office Approver will be able to see the installation request created above on the Manage Devices page for the above proposal")]
        public void WhenACloudMPSLocalOfficeApproverWillBeAbleToSeeTheInstallationRequestCreatedAboveOnTheManageDevicesPageForTheAboveProposal()
        {
            string resourceInstallationStatusNotStarted = _translationService.GetInstallationStatusText(TranslationKeys.InstallationStatus.NotStarted, _contextData.Culture);
            string url = _mpsLocalOfficeApproverContractStepActions.RetrieveInstallationRequestUrl(_localOfficeApproverManagedevicesManagePage, _contextData.InstallerEmail, _contextData.CompanyLocation, resourceInstallationStatusNotStarted);
            _contextData.WebInstallUrl = url;
        }


        [When(@"a Cloud MPS Local Office Approver will be able to see on the Manage Devices page that all devices for the above contract are connected with default Print Counts")]
        public void WhenACloudMPSLocalOfficeApproverWillBeAbleToSeeOnTheManageDevicesPageThatAllDevicesForTheAboveContractAreConnectedWithDefaultPrintCounts()
        {
            
            var products = _contextData.PrintersProperties;
            _mpsLocalOfficeApproverContractStepActions.InstallationCompleteCheck(_localOfficeApproverManagedevicesManagePage, products);

            //var products = _contextData.PrintersProperties;
            //_mpsDealerContractStepActions.InstallationCompleteCheck(_dealerManageDevicesPage, products);
        }

        [When(@"a Cloud MPS Local Office Approver will be able to see on the Manage Devices page that above devices have updated Print Counts")]
        public void WhenACloudMPSLocalOfficeApproverWillBeAbleToSeeOnTheManageDevicesPageThatAboveDevicesHaveUpdatedPrintCounts()
        {
            _localOfficeApproverManagedevicesManagePage = _mpsLocalOfficeApproverContractStepActions.RetrieveDealerManageDevicesPage();
            _mpsLocalOfficeApproverContractStepActions.CheckForUpdatedPrintCount(_localOfficeApproverManagedevicesManagePage);

            //_dealerManageDevicesPage = _mpsDealerContractStepActions.RetrieveDealerManageDevicesPage();
            //_mpsDealerContractStepActions.CheckForUpdatedPrintCount(_dealerManageDevicesPage);
        }

        [When(@"a Cloud MPS Local Office Approver click Swap Device in the Actions menu for device to be swapped on the Manage devices page")]
        public void WhenACloudMPSLocalOfficeApproverClickSwapDeviceInTheActionsMenuForDeviceToBeSwappedOnTheManageDevicesPage()
        {
            _localOfficeApproverManagedevicesManagePage = _mpsLocalOfficeApproverContractStepActions.RetrieveDealerManageDevicesPage();
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                if (product.IsSwap)
                {
                    _contextData.SwapOldDeviceSerialNumber = product.SerialNumber;
                    _mpsDealerContractStepActions.ClickOnSwapDevice(_localOfficeApproverManagedevicesManagePage, product.SerialNumber);
                }
            }

            //_dealerManageDevicesPage = _mpsDealerContractStepActions.RetrieveDealerManageDevicesPage();
            //var products = _contextData.PrintersProperties;
            //foreach (var product in products)
            //{
            //    if (product.IsSwap)
            //    {
            //        _contextData.SwapOldDeviceSerialNumber = product.SerialNumber;
            //        _mpsDealerContractStepActions.ClickOnSwapDevice(_dealerManageDevicesPage, product.SerialNumber);
            //    }
            //}

        }

        [When(@"a Cloud MPS Local Office Approver create a ""(.*)"" swap installation request with ""(.*)"" installation type for ""(.*)"" communication")]
        public void WhenACloudMPSLocalOfficeApproverCreateASwapInstallationRequestWithInstallationTypeForCommunication(string swapType, string installationType, string communicationMethod)
        {
            string resourceSwapTypeReplaceWithDifferentModel = _translationService.GetSwapTypeText("REPLACE_WITH_DIFFERENT_MODEL", _contextData.Culture);
            swapType = _translationService.GetSwapTypeText(swapType, _contextData.Culture);
            LocalOfficeApproverManagedevicesSetCommunicationMethodPage _dealerSetCommunicationMethodPage = _mpsLocalOfficeApproverContractStepActions.ConfirmSwapAndSelectSwapType(_localOfficeApproverManagedevicesManagePage, swapType, resourceSwapTypeReplaceWithDifferentModel);
            LocalOfficeApproverManagedevicesSetInstallationTypePage _dealerSetInstallationTypePage = _mpsLocalOfficeApproverContractStepActions.SelectCommunicationMethodAndProceed(_dealerSetCommunicationMethodPage, communicationMethod);
            LocalOfficeApproverManagedevicesSendSwapDeviceInstallationEmail _dealerSwapInstallationEmailPage = _mpsLocalOfficeApproverContractStepActions.SelectInstallationTypeAndProceedForSwap(_dealerSetInstallationTypePage, installationType);
            _localOfficeApproverManagedevicesManagePage = _mpsLocalOfficeApproverContractStepActions.PopulateInstallerEmailAndSendEmailForSwap(_dealerSwapInstallationEmailPage);

            //string resourceSwapTypeReplaceWithDifferentModel = _translationService.GetSwapTypeText("REPLACE_WITH_DIFFERENT_MODEL", _contextData.Culture);
            //swapType = _translationService.GetSwapTypeText(swapType, _contextData.Culture);
            //_dealerSetCommunicationMethodPage = _mpsDealerContractStepActions.ConfirmSwapAndSelectSwapType(_dealerManageDevicesPage, swapType, resourceSwapTypeReplaceWithDifferentModel);
            //_dealerSetInstallationTypePage = _mpsDealerContractStepActions.SelectCommunicationMethodAndProceed(_dealerSetCommunicationMethodPage, communicationMethod);
            //_dealerSwapInstallationEmailPage = _mpsDealerContractStepActions.SelectInstallationTypeAndProceedForSwap(_dealerSetInstallationTypePage, installationType);
            //_dealerManageDevicesPage = _mpsDealerContractStepActions.PopulateInstallerEmailAndSendEmailForSwap(_dealerSwapInstallationEmailPage);

        }

        [When(@"a Cloud MPS Local Office Approver will be able to see the status of the installed device is set Being Replaced on the Manage Devices page for the above proposal")]
        public void WhenACloudMPSLocalOfficeApproverWillBeAbleToSeeTheStatusOfTheInstalledDeviceIsSetBeingReplacedOnTheManageDevicesPageForTheAboveProposal()
        {
            string resourceInstallationStatusNotStarted = _translationService.GetInstallationStatusText(TranslationKeys.InstallationStatus.NotStarted, _contextData.Culture);
            string resourceInstalledPrinterStatusBeingReplaced = _translationService.GetInstalledPrinterStatusText(TranslationKeys.InstalledPrinterStatus.BeingReplaced, _contextData.Culture);

            _mpsLocalOfficeApproverContractStepActions.VerifySwappedDeviceStatus(_localOfficeApproverManagedevicesManagePage, _contextData.SwapOldDeviceSerialNumber, resourceInstalledPrinterStatusBeingReplaced);
            var url = _mpsLocalOfficeApproverContractStepActions.RetrieveInstallationRequestUrl(_localOfficeApproverManagedevicesManagePage, _contextData.InstallerEmail, _contextData.CompanyLocation, resourceInstallationStatusNotStarted);
            _contextData.WebSwapInstallUrl = url;

            //string resourceInstallationStatusNotStarted = _translationService.GetInstallationStatusText(TranslationKeys.InstallationStatus.NotStarted, _contextData.Culture);
            //string resourceInstalledPrinterStatusBeingReplaced = _translationService.GetInstalledPrinterStatusText(TranslationKeys.InstalledPrinterStatus.BeingReplaced, _contextData.Culture);

            //_mpsDealerContractStepActions.VerifySwappedDeviceStatus(_dealerManageDevicesPage, _contextData.SwapOldDeviceSerialNumber, resourceInstalledPrinterStatusBeingReplaced);
            //var url = _mpsDealerContractStepActions.RetrieveInstallationRequestUrl(_dealerManageDevicesPage, _contextData.InstallerEmail, _contextData.CompanyLocation, resourceInstallationStatusNotStarted);
            //_contextData.WebSwapInstallUrl = url;

        }

        [Then(@"a Cloud MPS Local Office Approver will be able to see the status of the swap device ""(.*)"" is set Being Swapped with updated print counts on the Manage Devices page for the above proposal")]
        public void ThenACloudMPSLocalOfficeApproverWillBeAbleToSeeTheStatusOfTheSwapDeviceIsSetBeingSwappedWithUpdatedPrintCountsOnTheManageDevicesPageForTheAboveProposal(string swapNewDeviceSerialNumber)
        {
            _localOfficeApproverManagedevicesManagePage = _mpsLocalOfficeApproverContractStepActions.RetrieveDealerManageDevicesPage();
            _mpsLocalOfficeApproverContractStepActions.CheckForSwapDeviceUpdatedPrintCount(_localOfficeApproverManagedevicesManagePage, swapNewDeviceSerialNumber);

            //_dealerManageDevicesPage = _mpsDealerContractStepActions.RetrieveDealerManageDevicesPage();
            //_mpsDealerContractStepActions.CheckForSwapDeviceUpdatedPrintCount(_dealerManageDevicesPage, swapNewDeviceSerialNumber);
        }


    }
}
