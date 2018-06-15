using Brother.MPS.Tests.Specs.MPS2.Proposal;
using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Dealership;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Dealership
{

    [Binding]
    public class MpsDealerDefaultMarginsSteps : Steps
    {
        private readonly IContextData _contextData;
        private readonly ICountryService _countryService;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly MpsDealerProposalStepActions _mpsDealerProposalStepActions;
        private readonly MpsSignInStepActions _mpsSignInStepActions;
        private readonly MpsDealerDealershipStepActions _mpsDealerDealershipStepActions;
        private readonly MpsDealerDefaultMarginsStepActions _mpsDealerDefaultMarginsStepActions;
        private DealerAdminDefaultMarginsPage _dealerAdminDefaultMarginsPage;
        private readonly ITranslationService _translationService;
        private readonly MpsDealerProposalSteps _mpsDealerProposalSteps;

        //Page objects

        public MpsDealerDefaultMarginsSteps(
            MpsDealerProposalSteps mpsDealerProposalSteps,
            ITranslationService translationService,
            MpsDealerProposalStepActions mpsDealerProposalStepActions,
            MpsDealerDealershipStepActions mpsDealerDealershipStepActions,
            MpsDealerDefaultMarginsStepActions mpsDealerDefaultMarginsStepActions,
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
            _mpsDealerDefaultMarginsStepActions = mpsDealerDefaultMarginsStepActions;
            _translationService = translationService;
            _mpsDealerProposalSteps = mpsDealerProposalSteps;
        }

        [Given(@"I select Admin menu and click on Default Margins")]
        public void GivenISelectAdminMenuAndClickOnDefaultMargins()
        {
            var dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var dealerAdminDashboardPage = _mpsDealerDealershipStepActions.NavigateToDealerAdminDashboardPage(dealerDashboardPage);
            _dealerAdminDefaultMarginsPage = _mpsDealerDefaultMarginsStepActions.NavigateToDealerMarginsPage(dealerAdminDashboardPage);
        }

        [Then(@"I will be taken into the Default Margins tab")]
        public void ThenIWillBeTakenIntoTheDefaultMarginsTab()
        {
            _mpsDealerDefaultMarginsStepActions.AssertAreSelectDefaultMarginsTab(_dealerAdminDefaultMarginsPage);
        }

        [When(@"I overtype default margins HardwareDefaultMargin of ""(.*)"", AccessoriesDefaultMargin of ""(.*)"", DeliveryDefaultMargin of ""(.*)"", InstallationDefaultMargin of ""(.*)"", ServicePackDefaultMargin of ""(.*)"", MonoClickDefaultCommission of ""(.*)"", and ColourClickDefaultCommission of ""(.*)""  with required % and click Save")]
        public void WhenIOvertypeDefaultMarginsWithRequiredAndClickSave(
            double HardwareDefaultMargin,
            double AccessoriesDefaultMargin,
            double DeliveryDefaultMargin,
            double InstallationDefaultMargin,
            double ServicePackDefaultMargin,
            double MonoClickDefaultCommission,
            double ColourClickDefaultCommission)
        {

            _contextData.DealerAdminDefaultMargins = new DealerDefaultMargins()
            {
                HardwareDefaultMargin = HardwareDefaultMargin,
                AccessoriesDefaultMargin = AccessoriesDefaultMargin,
                DeliveryDefaultMargin = DeliveryDefaultMargin,
                InstallationDefaultMargin = InstallationDefaultMargin,
                ServicePackDefaultMargin = ServicePackDefaultMargin,
                MonoClickDefaultCommission = MonoClickDefaultCommission,
                ColourClickDefaultCommission = ColourClickDefaultCommission
            };
            _contextData.DealerAdminDefaultMarginsOriginal =  _mpsDealerDefaultMarginsStepActions.SetDealerMargins(_dealerAdminDefaultMarginsPage, _contextData.DealerAdminDefaultMargins);
            _dealerAdminDefaultMarginsPage = _mpsDealerDefaultMarginsStepActions.ClickOnSave(_dealerAdminDefaultMarginsPage);
        }


        [Then(@"I verify default margins will be amended")]
        public void ThenIVerifyDefaultMarginsWillBeAmended(Table printers)
        {
            // try create proposal for view margins. logic similar as Type1BusinessScenario_1
            _mpsDealerProposalSteps.GivenIHaveNavigatedToTheCreateProposalPageAsACloudMPSDealerFrom(_contextData.Country.Name);
            _mpsDealerProposalSteps.WhenICreateAProposalOfContractType("PURCHASE_AND_CLICK");
            _mpsDealerProposalSteps.WhenIEnterTheProposalDescription();
            _mpsDealerProposalSteps.WhenICreateANewCustomerForTheProposal();
            _mpsDealerProposalSteps.WhenISelectUsageTypeOfContractTermOfBillingTypeOfAndServicePackTypeOf(
                "MINIMUM_VOLUME",       // UsageType
                "THREE_YEARS",          // ContractTerm
                "QUARTERLY_IN_ARREARS", // BillingType
                "PAY_UPFRONT"           // ServicePackType
                );
            _mpsDealerProposalSteps.WhenIAddThesePrinters(printers);
            _mpsDealerProposalSteps.WhenIPopulateTheClickPriceForEachOfTheSpecifiedPrinters();

            // verify
            _mpsDealerDefaultMarginsStepActions.VerifyDefaultMarginsWillBeAmended(_contextData.DealerAdminDefaultMargins, _contextData.PrintersProperties);
            
            // restore
            GivenISelectAdminMenuAndClickOnDefaultMargins();
            _mpsDealerDefaultMarginsStepActions.SetDealerMargins(_dealerAdminDefaultMarginsPage, _contextData.DealerAdminDefaultMarginsOriginal);
            _dealerAdminDefaultMarginsPage = _mpsDealerDefaultMarginsStepActions.ClickOnSave(_dealerAdminDefaultMarginsPage);
        }

    }
}
