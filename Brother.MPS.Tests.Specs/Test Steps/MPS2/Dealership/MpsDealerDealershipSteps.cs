using Brother.Tests.Common.ContextData;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Dealership;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using System;
using System.IO;
using TechTalk.SpecFlow;

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
        private DealerAdminDealershipProfilePage _dealerAdminDealershipProfilePage;

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

        [Given(@"I Select Admin menu and click on Delearship Profile\.")]
        public void GivenISelectAdminMenuAndClickOnDelearshipProfile_()
        {
            var dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var dealerAdminDashboardPage = _mpsDealerDealershipStepActions.NavigateToDealerAdminDashboardPage(dealerDashboardPage);
            _dealerAdminDealershipProfilePage = _mpsDealerDealershipStepActions.NavigateToDealershipProfilePage(dealerAdminDashboardPage);
        }

        [Then(@"I will be taken into the Dealership Profile tab\.")]
        public void ThenIWillBeTakenIntoTheDealershipProfileTab_()
        {
            _mpsDealerDealershipStepActions.ValidateDealershipProfileTab(_dealerAdminDealershipProfilePage);
        }

        [When(@"I Amend Profile description and use the browse function to add a Jpeg as a logo\. Click Save\.")]
        public void WhenIAmendProfileDescriptionAndUseTheBrowseFunctionToAddAJpegAsALogo_ClickSave_()
        {
            var filePath = _mpsDealerDealershipStepActions.CreateUploadLogoFile();
            _mpsDealerDealershipStepActions.UploadLogoToProfile(_dealerAdminDealershipProfilePage, filePath);
            File.Delete(filePath);
        }

        [Then(@"I 'Dealership profile was updated successfully' will appear at the top of the screen\.")]
        public void ThenIDealershipProfileWasUpdatedSuccessfullyWillAppearAtTheTopOfTheScreen_()
        {
            _mpsDealerDealershipStepActions.VerifyDealershipProfileWasUpdatedSuccessfully(_dealerAdminDealershipProfilePage);
            _mpsDealerDealershipStepActions.RemoveProfileLogo(_dealerAdminDealershipProfilePage); // GC
        }


    }
}
