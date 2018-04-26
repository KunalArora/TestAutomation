using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.StepActions.Agreement;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice;
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

        private LocalOfficeAgreementDevicesPage _localOfficeAdminAgreementDevicesPage;
        private LocalOfficeAgreementBillingPage _localOfficeAdminAgreementBillingPage;

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
            _localOfficeAdminAgreementDevicesPage = _mpsLoAdminAgreement.NavigateToAgreementDevicesPage(dataQueryPage);
            _mpsLoAdminAgreement.EnableInstallationOption(_localOfficeAdminAgreementDevicesPage, installationType, communicationMethod);
        }

        [Then(@"a Cloud MPS Local Office Admin can verify the correct reflection of updated print counts")]
        public void ThenACloudMPSLocalOfficeAdminCanVerifyTheCorrectReflectionOfUpdatedPrintCounts()
        {
            var localOfficeAdminDashboardPage = _mpsSignIn.SignInAsLocalOfficeAdmin(
                _userResolver.LocalOfficeAdminUsername, _userResolver.LocalOfficeAdminPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var dataQueryPage = _mpsLoAdminAgreement.NavigateToReportsDataQuery(localOfficeAdminDashboardPage);
            _localOfficeAdminAgreementDevicesPage = _mpsLoAdminAgreement.NavigateToAgreementDevicesPage(dataQueryPage);
            _localOfficeAdminAgreementDevicesPage = _mpsLoAdminAgreement.VerifyUpdatedPrintCounts(_localOfficeAdminAgreementDevicesPage);
        }

        [Then(@"a Cloud MPS Local Office Admin can verify the generation of consumable orders alongwith status")]
        public void ThenACloudMPSLocalOfficeAdminCanVerifyTheGenerationOfConsumableOrdersAlongwithStatus()
        {
            _localOfficeAdminAgreementDevicesPage = _mpsLoAdminAgreement.VerifyGenerationOfConsumableOrders(_localOfficeAdminAgreementDevicesPage);
        }

        [Then(@"a Cloud MPS Local Office Admin can verify the click rate billing invoice")]
        public void ThenACloudMPSLocalOfficeAdminCanVerifyTheClickRateBillingInvoice()
        {
            _localOfficeAdminAgreementBillingPage = _mpsLoAdminAgreement.VerifyClickRateInvoice(_localOfficeAdminAgreementDevicesPage);
        }

        [Then(@"a Cloud MPS Local Office Admin can verify the service/installation billing invoice")]
        public void ThenACloudMPSLocalOfficeAdminCanVerifyTheServiceInstallationBillingInvoice()
        {
            _localOfficeAdminAgreementBillingPage = _mpsLoAdminAgreement.VerifyServiceInstallationInvoice(_localOfficeAdminAgreementBillingPage);
        }

        [Then(@"a Cloud MPS Local Office Admin can verify the CPP Agreement Report")]
        public void ThenACloudMPSLocalOfficeAdminCanVerifyTheCPPAgreementReport()
        {
            var localOfficeAdminDashboardPage = _mpsSignIn.SignInAsLocalOfficeAdmin(
                _userResolver.LocalOfficeAdminUsername, _userResolver.LocalOfficeAdminPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _mpsLoAdminAgreement.DownloadAndVerifyCPPAgreementReport(localOfficeAdminDashboardPage);
        }
    }
}