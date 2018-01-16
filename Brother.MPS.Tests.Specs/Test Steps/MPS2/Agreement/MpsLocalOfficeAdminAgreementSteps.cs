using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.StepActions.Agreement;
using Brother.Tests.Specs.StepActions.Common;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Agreement
{
    [Binding]
    public class MpsLocalOfficeAdminAgreementSteps
    {
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly MpsLocalOfficeAdminAgreementStepActions _mpsLoAdminAgreement;

        public MpsLocalOfficeAdminAgreementSteps(
            MpsLocalOfficeAdminAgreementStepActions mpsLoAdminAgreement,
            MpsSignInStepActions mpsSignIn,
            IUserResolver userResolver,
            IUrlResolver urlResolver)
        {
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _mpsSignIn = mpsSignIn;
            _mpsLoAdminAgreement = mpsLoAdminAgreement;
        }

        [When(@"a Cloud MPS Local Office Admin enables the ""(.*)"" installation option for ""(.*)"" communication")]
        public void WhenACloudMPSLocalOfficeAdminEnablesTheInstallationOptionForCommunication(string installationType, string communicationMethod)
        {
            var localOfficeAdminDashboardPage = _mpsSignIn.SignInAsLocalOfficeAdmin(
                _userResolver.LocalOfficeAdminUsername, _userResolver.LocalOfficeAdminPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var dataQueryPage = _mpsLoAdminAgreement.NavigateToReportsDataQuery(localOfficeAdminDashboardPage);
            var localOfficeAdminAgreementDevicesPage = _mpsLoAdminAgreement.NavigateToAgreementDevicesPage(dataQueryPage);
            _mpsLoAdminAgreement.EnableInstallationOption(localOfficeAdminAgreementDevicesPage, installationType, communicationMethod);
        }

        [Then(@"a Cloud MPS Local Office Admin can verify the correct reflection of updated print counts")]
        public void ThenACloudMPSLocalOfficeAdminCanVerifyTheCorrectReflectionOfUpdatedPrintCounts()
        {
            var localOfficeAdminDashboardPage = _mpsSignIn.SignInAsLocalOfficeAdmin(
                _userResolver.LocalOfficeAdminUsername, _userResolver.LocalOfficeAdminPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var dataQueryPage = _mpsLoAdminAgreement.NavigateToReportsDataQuery(localOfficeAdminDashboardPage);
            var localOfficeAdminAgreementDevicesPage = _mpsLoAdminAgreement.NavigateToAgreementDevicesPage(dataQueryPage);
            localOfficeAdminAgreementDevicesPage = _mpsLoAdminAgreement.VerifyUpdatedPrintCounts(localOfficeAdminAgreementDevicesPage);
        }
    }
}