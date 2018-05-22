using Brother.Tests.Common.ContextData;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.StepActions.Agreement;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Agreement
{
    [Binding]
    public class MpsServiceDeskAgreementSteps
    {
        private readonly IContextData _contextData;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly MpsServiceDeskAgreementStepActions _mpsServiceDeskAgreement;

        // Page objects
        private LocalOfficeAgreementDevicesPage _serviceDeskAgreementDevicesPage;
        private ServiceDeskDashBoardPage _serviceDeskDashboardPage;
        private DataQueryPage _dataQueryPage;
        private LocalOfficeAgreementDevicesPage _localOfficeAgreementDevicesPage;

        public MpsServiceDeskAgreementSteps(MpsSignInStepActions mpsSignIn,
            MpsServiceDeskAgreementStepActions mpsServiceDeskAgreement,
            IUserResolver userResolver,
            IUrlResolver urlResolver,
            IContextData contextData)
        {
            _contextData = contextData;
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _mpsSignIn = mpsSignIn;
            _mpsServiceDeskAgreement = mpsServiceDeskAgreement;
        }

        [Then(@"a Cloud MPS Service Desk can create and send installation requests for devices one by one")]
        public void ThenACloudMPSServiceDeskCanCreateAndSendInstallationRequestsForDevicesOneByOne()
        {
            var serviceDeskDashboardPage = _mpsSignIn.SignInAsServiceDesk(
                _userResolver.ServiceDeskUsername, _userResolver.ServiceDeskPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var dataQueryPage = _mpsServiceDeskAgreement.NavigateToReportsDataQuery(serviceDeskDashboardPage);
            var serviceDeskAgreementDevicesPage = _mpsServiceDeskAgreement.NavigateToAgreementDevicesPage(dataQueryPage);
            _serviceDeskAgreementDevicesPage = _mpsServiceDeskAgreement.SendSingleInstallationRequests(serviceDeskAgreementDevicesPage);
        }

        [Then(@"a Cloud MPS Service Desk can verify the service request")]
        public void ThenACloudMPSServiceDeskCanVerifyTheServiceRequest()
        {
            _serviceDeskDashboardPage = _mpsSignIn.SignInAsServiceDesk(
                _userResolver.ServiceDeskUsername, _userResolver.ServiceDeskPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));

            // Below 2 steps are implemented just to retrieve dealer details from agreement summary page for later validation
            _dataQueryPage = _mpsServiceDeskAgreement.NavigateToReportsDataQuery(_serviceDeskDashboardPage);
            _localOfficeAgreementDevicesPage = _mpsServiceDeskAgreement.NavigateToAgreementDevicesPage(_dataQueryPage);

            _mpsServiceDeskAgreement.VerifyServiceRequest(_localOfficeAgreementDevicesPage);
        }

        [When(@"a Cloud MPS Service Desk close the service request")]
        public void WhenACloudMPSServiceDeskCloseTheServiceRequest()
        {
            _serviceDeskDashboardPage = _mpsSignIn.SignInAsServiceDesk(
                _userResolver.ServiceDeskUsername, _userResolver.ServiceDeskPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));

            // Below 2 steps are implemented just to retrieve dealer details from agreement summary page for later validation
            _dataQueryPage = _mpsServiceDeskAgreement.NavigateToReportsDataQuery(_serviceDeskDashboardPage);
            _localOfficeAgreementDevicesPage = _mpsServiceDeskAgreement.NavigateToAgreementDevicesPage(_dataQueryPage);

            _mpsServiceDeskAgreement.CloseServiceRequest(_localOfficeAgreementDevicesPage);
        }


        [When(@"a Cloud MPS Service Desk creates and sends a ""(.*)"" swap device installation request")]
        public void WhenACloudMPSServiceDeskCreatesAndSendsASwapDeviceInstallationRequest(string swapDeviceType)
        {
            _contextData.SwapType = swapDeviceType;

            var serviceDeskDashboardPage = _mpsSignIn.SignInAsServiceDesk(
                _userResolver.ServiceDeskUsername, _userResolver.ServiceDeskPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var dataQueryPage = _mpsServiceDeskAgreement.NavigateToReportsDataQuery(serviceDeskDashboardPage);
            _serviceDeskAgreementDevicesPage = _mpsServiceDeskAgreement.NavigateToAgreementDevicesPage(dataQueryPage);

            _serviceDeskAgreementDevicesPage = _mpsServiceDeskAgreement.SendSwapDeviceInstallationRequest(_serviceDeskAgreementDevicesPage, swapDeviceType);
        }

        [Then(@"a Cloud MPS Service Desk can verify that the new devices are installed and responding")]
        public void ThenACloudMPSServiceDeskCanVerifyThatTheNewDevicesAreInstalledAndResponding()
        {
            _serviceDeskAgreementDevicesPage = _mpsServiceDeskAgreement.VerifyStatusOfSwappedInAndSwappedOutDevices(_serviceDeskAgreementDevicesPage);
        }
    }
}
