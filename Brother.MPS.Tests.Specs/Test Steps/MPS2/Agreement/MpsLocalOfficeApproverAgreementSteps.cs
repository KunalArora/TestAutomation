using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.StepActions.Agreement;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Agreement
{
    [Binding]
    public class MpsLocalOfficeApproverAgreementSteps
    {
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly MpsLocalOfficeApproverAgreementStepActions _mpsLoApproverAgreement;

        // Page objects
        private LocalOfficeAgreementDevicesPage _localOfficeApproverAgreementDevicesPage;

        public MpsLocalOfficeApproverAgreementSteps(MpsSignInStepActions mpsSignIn,
            MpsLocalOfficeApproverAgreementStepActions mpsLoApproverAgreement,
            IUserResolver userResolver,
            IUrlResolver urlResolver)
        {
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _mpsSignIn = mpsSignIn;
            _mpsLoApproverAgreement = mpsLoApproverAgreement;
        }

        [Then(@"a Cloud MPS LO Approver can create and send a bulk installation request")]
        public void ThenACloudMPSLOApproverCanCreateAndSendABulkInstallationRequest()
        {
            var localOfficeApproverDashboardPage = _mpsSignIn.SignInAsLocalOfficeApprover(
                _userResolver.LocalOfficeApproverUsername, _userResolver.LocalOfficeApproverPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var dataQueryPage = _mpsLoApproverAgreement.NavigateToReportsDataQuery(localOfficeApproverDashboardPage);
            var localOfficeApproverAgreementDevicesPage = _mpsLoApproverAgreement.NavigateToAgreementDevicesPage(dataQueryPage);
            _localOfficeApproverAgreementDevicesPage = _mpsLoApproverAgreement.SendBulkInstallationRequest(localOfficeApproverAgreementDevicesPage);
        }
    }
}
