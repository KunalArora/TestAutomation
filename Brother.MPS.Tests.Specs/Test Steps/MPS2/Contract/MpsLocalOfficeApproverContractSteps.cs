using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Contract;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using System;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Contract
{
    [Binding]
    class MpsLocalOfficeApproverContractSteps
    {
        private readonly MpsSignInStepActions _mpsSignInStepActions;
        private readonly MpsDealerContractStepActions _mpsDealerContractStepActions;
        private readonly MpsLocalOfficeApproverContractStepActions _mpsLocalOfficeApproverContractStepActions;
        private readonly MpsLocalOfficeApproverProposalStepActions _mpsLocalOfficeApproverProposalStepActions;
        private readonly IContextData _contextData;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly IRunCommandService _runCommandService;
        private readonly ITranslationService _translationService;

        private LocalOfficeApproverApprovalContractsAcceptedPage _localOfficeApproverApprovalContractsAcceptedPage;
        private LocalOfficeApproverManageDevicesManagePage _localOfficeApproverManagedevicesManagePage;
       

        public MpsLocalOfficeApproverContractSteps(
            MpsSignInStepActions mpsSignInStepActions,
            MpsDealerContractStepActions mpsDealerContractStepActions,
            MpsLocalOfficeApproverContractStepActions mpsLocalOfficeApproverContractStepActions,
            MpsLocalOfficeApproverProposalStepActions mpsLocalOfficeApproverProposalStepActions,
            MpsContextData contextData,
            ITranslationService translationService,
            IRunCommandService runCommandService,
            IUserResolver userResolver,
            IUrlResolver urlResolver)
        {
            _contextData = contextData;
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _mpsSignInStepActions = mpsSignInStepActions;
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
            var localOfficeApproverApprovalContractsSummaryPage = _mpsLocalOfficeApproverContractStepActions.ClickViewSummary(localOfficeApproverApprovalContractsAwaitingAcceptancePage);
            _localOfficeApproverApprovalContractsAcceptedPage = _mpsLocalOfficeApproverContractStepActions.AcceptContract(localOfficeApproverApprovalContractsSummaryPage);
        }

        [When(@"a Cloud MPS Local Office Approver rejects the above proposal")]
        public void WhenACloudMPSLocalOfficeApproverRejectsTheAboveProposal()
        {
            var localOfficeApproverDashBoardPage = _mpsSignInStepActions.SignInAsLocalOfficeApprover(_userResolver.LocalOfficeApproverUsername, _userResolver.LocalOfficeApproverPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var localOfficeApproverApprovalContractsAwaitingAcceptancePage = _mpsLocalOfficeApproverContractStepActions.NavigateToApprovalContractsAwaitingAcceptancePage(localOfficeApproverDashBoardPage);
            var localOfficeApproverApprovalContractsSummaryPage = _mpsLocalOfficeApproverContractStepActions.ClickViewSummary(localOfficeApproverApprovalContractsAwaitingAcceptancePage);
            _mpsLocalOfficeApproverContractStepActions.RejectContract(localOfficeApproverApprovalContractsSummaryPage);
        }

        [Then(@"I navigate to Accepted Contracts page and validate its existence")]
        public void WhenINavigateToAcceptedContractsPageAndValidateItsExistence()
        {
            _mpsLocalOfficeApproverContractStepActions.VerifyAcceptContract(_localOfficeApproverApprovalContractsAcceptedPage, _contextData.ProposalId, _contextData.ProposalName);
        }

        [When(@"a Cloud MPS Local Office Approver locate the above contract and click Manage Devices button")]
        public void WhenACloudMPSLocalOfficeApproverLocateTheAboveContractAndClickManageDevicesButton()
        {
            var _localOfficeApproverDashBoardPage = _mpsLocalOfficeApproverProposalStepActions.SignInAsLocalOfficeApproverAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var _localOfficeApproverManagedevicesContractsPage = _mpsLocalOfficeApproverContractStepActions.NavigateToDeviceManagementPage(_localOfficeApproverDashBoardPage);
            _localOfficeApproverManagedevicesManagePage =  _mpsLocalOfficeApproverContractStepActions.ClickOnActionsManageDevices(_localOfficeApproverManagedevicesContractsPage);
            _runCommandService.RunCreateCustomerAndPersonCommand();
        }

        [When(@"a Cloud MPS Local Office Approver create a ""(.*)"" installation request for ""(.*)"" communication")]
        public void WhenACloudMPSLocalOfficeApproverCreateAInstallationRequestForCommunication(string installationType, string communicationMethod)
        {
            var _dealerSetCommunicationMethodPage = _mpsLocalOfficeApproverContractStepActions.CreateInstallationRequest(_localOfficeApproverManagedevicesManagePage);
            var _dealerSetInstallationTypePage = _mpsLocalOfficeApproverContractStepActions.SelectCommunicationMethodAndProceed(_dealerSetCommunicationMethodPage, communicationMethod);
            var _dealerSendInstallationEmailPage = _mpsLocalOfficeApproverContractStepActions.SelectInstallationTypeAndProceed(_dealerSetInstallationTypePage, installationType);
            _localOfficeApproverManagedevicesManagePage = _mpsLocalOfficeApproverContractStepActions.PopulateInstallerEmailAndSendEmail(_dealerSendInstallationEmailPage);
        }

        [When(@"a Cloud MPS Local Office Approver will be able to see the installation request created above on the Manage Devices page for the above proposal")]
        public void WhenACloudMPSLocalOfficeApproverWillBeAbleToSeeTheInstallationRequestCreatedAboveOnTheManageDevicesPageForTheAboveProposal()
        {
            string url = _mpsLocalOfficeApproverContractStepActions.RetrieveInstallationRequestUrl(_localOfficeApproverManagedevicesManagePage);
            _contextData.WebInstallUrl = url;
        }


        [When(@"a Cloud MPS Local Office Approver will be able to see on the Manage Devices page that all devices for the above contract are connected with default Print Counts")]
        public void WhenACloudMPSLocalOfficeApproverWillBeAbleToSeeOnTheManageDevicesPageThatAllDevicesForTheAboveContractAreConnectedWithDefaultPrintCounts()
        {
            
            var products = _contextData.PrintersProperties;
            _mpsLocalOfficeApproverContractStepActions.InstallationCompleteCheck(_localOfficeApproverManagedevicesManagePage, products);
        }

        [When(@"a Cloud MPS Local Office Approver will be able to see on the Manage Devices page that above devices have updated Print Counts")]
        public void WhenACloudMPSLocalOfficeApproverWillBeAbleToSeeOnTheManageDevicesPageThatAboveDevicesHaveUpdatedPrintCounts()
        {
            _localOfficeApproverManagedevicesManagePage = _mpsLocalOfficeApproverContractStepActions.RetrieveDealerManageDevicesPage();
            _mpsLocalOfficeApproverContractStepActions.CheckForUpdatedPrintCount(_localOfficeApproverManagedevicesManagePage);
        }

        [When(@"a Cloud MPS Local Office Approver click Swap Device in the Actions menu for device to be swapped on the Manage devices page")]
        public void WhenACloudMPSLocalOfficeApproverClickSwapDeviceInTheActionsMenuForDeviceToBeSwappedOnTheManageDevicesPage()
        {
            _mpsDealerContractStepActions.ContractShiftBeforeSwapDeviceInstallationRequest(1);
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

        }

        [When(@"a Cloud MPS Local Office Approver create a ""(.*)"" swap installation request with ""(.*)"" installation type for ""(.*)"" communication")]
        public void WhenACloudMPSLocalOfficeApproverCreateASwapInstallationRequestWithInstallationTypeForCommunication(string swapType, string installationType, string communicationMethod)
        {
            string resourceSwapTypeReplaceWithDifferentModel = _translationService.GetSwapTypeText(TranslationKeys.SwapType.ReplaceWithDifferentModel, _contextData.Culture);

            _contextData.SwapType = _translationService.GetSwapTypeText(swapType, _contextData.Culture);
            var dealerSetCommunicationMethodPage = _mpsLocalOfficeApproverContractStepActions.ConfirmSwapAndSelectSwapType(_localOfficeApproverManagedevicesManagePage, _contextData.SwapType, resourceSwapTypeReplaceWithDifferentModel);
            var dealerSetInstallationTypePage = _mpsLocalOfficeApproverContractStepActions.SelectCommunicationMethodAndProceed(dealerSetCommunicationMethodPage, communicationMethod);
            var dealerSwapInstallationEmailPage = _mpsLocalOfficeApproverContractStepActions.SelectInstallationTypeAndProceedForSwap(dealerSetInstallationTypePage, installationType);
            _localOfficeApproverManagedevicesManagePage = _mpsLocalOfficeApproverContractStepActions.PopulateInstallerEmailAndSendEmailForSwap(dealerSwapInstallationEmailPage);
        }

        [When(@"a Cloud MPS Local Office Approver will be able to see the status of the installed device is set Being Replaced on the Manage Devices page for the above proposal")]
        public void WhenACloudMPSLocalOfficeApproverWillBeAbleToSeeTheStatusOfTheInstalledDeviceIsSetBeingReplacedOnTheManageDevicesPageForTheAboveProposal()
        {
            _mpsLocalOfficeApproverContractStepActions.VerifySwappedDeviceStatus(_localOfficeApproverManagedevicesManagePage);
            var url = _mpsLocalOfficeApproverContractStepActions.RetrieveInstallationRequestUrl(_localOfficeApproverManagedevicesManagePage);
            _contextData.WebSwapInstallUrl = url;
        }

        [Then(@"a Cloud MPS Local Office Approver will be able to see the status of the swap device is set Being Swapped with updated print counts on the Manage Devices page for the above proposal")]
        public void ThenACloudMPSLocalOfficeApproverWillBeAbleToSeeTheStatusOfTheSwapDeviceIsSetBeingSwappedWithUpdatedPrintCountsOnTheManageDevicesPageForTheAboveProposal()
        {
            _localOfficeApproverManagedevicesManagePage = _mpsLocalOfficeApproverContractStepActions.RetrieveDealerManageDevicesPage();
            _mpsLocalOfficeApproverContractStepActions.CheckForSwapDeviceUpdatedPrintCount(_localOfficeApproverManagedevicesManagePage);
        }

        [When(@"a Cloud MPS Local Office Approver apply and verify the Overusage")]
        public void WhenACloudMPSLocalOfficeApproverApplyAndVerifyTheOverusage()
        {
            int contractShiftTimeOffsetValue;
            var billingType = _contextData.BillingType;
            var resourceBillingTypeHalfYearlyInArrears = _translationService.GetBillingTypeText(TranslationKeys.BillingType.HalfYearlyInArrears, _contextData.Culture);
            var resourceBillingTypeQuarterlyInArrears = _translationService.GetBillingTypeText(TranslationKeys.BillingType.QuarterlyInArrears, _contextData.Culture);

            // TODO: Create a function in the IContractShiftService class to do this process
            if( billingType == resourceBillingTypeHalfYearlyInArrears )
            {
                contractShiftTimeOffsetValue = 6;
            }
            else if( billingType  == resourceBillingTypeQuarterlyInArrears)
            {
                contractShiftTimeOffsetValue = 3;
            }
            else
            {
                throw new NotImplementedException("WhenACloudMPSLocalOfficeApproverApplyAndVerifyTheOverusage() not support billingType=" + billingType);
            }

            var localOfficeApproverDashBoardPage = _mpsSignInStepActions.SignInAsLocalOfficeApprover(_userResolver.LocalOfficeApproverUsername, _userResolver.LocalOfficeApproverPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var localOfficeApproverReportsDashboardPage = _mpsLocalOfficeApproverContractStepActions.NavigateToReportsDashboardPage(localOfficeApproverDashBoardPage);
            var localOfficeApproverReportsDataQueryPage = _mpsLocalOfficeApproverContractStepActions.NavigateToReportsDataQueryPage(localOfficeApproverReportsDashboardPage);
            var localOfficeApproverReportsProposalsSummaryPage = _mpsLocalOfficeApproverContractStepActions.NavigateToContractsSummaryPage(localOfficeApproverReportsDataQueryPage);
            localOfficeApproverReportsProposalsSummaryPage = _mpsLocalOfficeApproverContractStepActions.ApplyOverusage(localOfficeApproverReportsProposalsSummaryPage, contractShiftTimeOffsetValue);
            var pdfFile = _mpsLocalOfficeApproverContractStepActions.DownloadPdf(localOfficeApproverReportsProposalsSummaryPage);
            try
            {
                _mpsLocalOfficeApproverContractStepActions.AssertAreEqualOverusageValues(pdfFile);
            }
            finally
            {
                _mpsLocalOfficeApproverContractStepActions.DeletePdfFile(pdfFile);
            }
        }
    }
}
