using Brother.Tests.Common.ContextData;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using System;
using TechTalk.SpecFlow;
using Brother.Tests.Specs.MPS2.Dealership;
using Brother.Tests.Specs.StepActions.Dealership;

namespace Brother.Tests.Specs.MPS2.Dealership
{
    [Binding]
    public class MpsDealerDealershipSteps
    {
        private readonly IContextData _contextData;
        private readonly ICountryService _countryService;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly MpsDealerProposalStepActions _mpsDealerProposalStepActions;
        private readonly MpsSignInStepActions _mpsSignInStepActions;
        private readonly MpsDealerDealershipStepActions _mpsDealerDealershipStepActions;

        //Page objects
        private DealerDashBoardPage _dealerDashboardPage;
        private DealerAdminDashBoardPage _dealerAdminDashboardPage;
        private DealerAdminDealershipUsersPage _dealerAdminDealershipUsersPage;
        private DealerAdminDealershipUsersCreationPage _dealerAdminDealershipUsersCreationPage;
        private DealerDashBoardPage _subDealerDashboardPage;

        public MpsDealerDealershipSteps(
            MpsDealerProposalStepActions mpsDealerProposalStepActions,
            MpsDealerDealershipStepActions mpsDealerDealershipStepActions,
            MpsSignInStepActions mpsSignInStepActions,
            MpsContextData contextData,
            ICountryService countryService,
            IUserResolver userResolver,
            IUrlResolver urlResolver)
        {
            _contextData = contextData;
            _countryService = countryService;
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _mpsSignInStepActions = mpsSignInStepActions;
            _mpsDealerProposalStepActions = mpsDealerProposalStepActions;
            _mpsDealerDealershipStepActions = mpsDealerDealershipStepActions;
        }

        [Given(@"I have navigated to the Dealership User page in admin tab as a Cloud MPS Dealer from ""(.*)""")]
        public void GivenIHaveNavigatedToTheDealershipUserPageInAdminTabAsACloudMPSDealerFrom(string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);
            if (_contextData.Country.Cultures.Count != 1)
            {
                throw new ArgumentException("can not auto select culture. please call alternate some garkin");
            }
            _contextData.Culture = _contextData.Country.Cultures[0];
            _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealerAdminDashboardPage = _mpsDealerDealershipStepActions.NavigateToDealerAdminDashboardPage(_dealerDashboardPage);
            _dealerAdminDealershipUsersPage = _mpsDealerDealershipStepActions.NavigateToDealershipUsersPage(_dealerAdminDashboardPage);
        }

        [When(@"I create a new sub dealer")]
        public void GivenICreateANewSubDealer()
        {
           _dealerAdminDealershipUsersCreationPage = _mpsDealerDealershipStepActions.ClickOnAddStaffMember(_dealerAdminDealershipUsersPage);
           _dealerAdminDealershipUsersPage = _mpsDealerDealershipStepActions.EnterSubDealerDetailsAndSave(_dealerAdminDealershipUsersCreationPage);
        }

        [Then(@"I can verify that the Sub dealer is successfully created")]
        public void ThenICanVerifyThatTheSubDealerIsSuccessfullyCreated()
        {
            _mpsDealerDealershipStepActions.VerifySubDealer(_dealerAdminDealershipUsersPage);
        }

        [Given(@"I have navigated to the create proposal page as a Sub dealer from ""(.*)""")]
        public void GivenIHaveNavigatedToTheCreateProposalPageAsASubDealerFrom(string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);
            if (_contextData.Country.Cultures.Count != 1)
            {
                throw new ArgumentException("can not auto select culture. please call alternate some garkin");
            }
            _contextData.Culture = _contextData.Country.Cultures[0];
            _subDealerDashboardPage = _mpsDealerProposalStepActions.SignInAsSubDealerAndNavigateToDashboard(_contextData.SubDealerEmail, _contextData.SubDealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
        }



    }
}
