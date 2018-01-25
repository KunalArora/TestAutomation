using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.StepActions.Agreement;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Agreement
{
    [Binding]
    public class MpsServiceDeskAgreementSteps
    {
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly MpsServiceDeskAgreementStepActions _mpsServiceDeskAgreement;

        // Page objects
        private LocalOfficeAgreementDevicesPage _serviceDeskAgreementDevicesPage;

        public MpsServiceDeskAgreementSteps(MpsSignInStepActions mpsSignIn,
            MpsServiceDeskAgreementStepActions mpsServiceDeskAgreement,
            IUserResolver userResolver,
            IUrlResolver urlResolver)
        {
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

        [Then(@"a Cloud MPS Service Desk can verify the service request and close it")]
        public void ThenACloudMPSServiceDeskCanVerifyTheServiceRequestAndCloseIt()
        {
            var serviceDeskDashboardPage = _mpsSignIn.SignInAsServiceDesk(
                _userResolver.ServiceDeskUsername, _userResolver.ServiceDeskPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _mpsServiceDeskAgreement.VerifyServiceRequestAndCloseIt(serviceDeskDashboardPage);
        }
    }
}
