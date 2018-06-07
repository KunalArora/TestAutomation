using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Dealership;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using System;
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

        //Page objects

        public MpsDealerDefaultMarginsSteps(
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
        }

        [Given(@"I Select Admin menu and click on Default Margins\.")]
        public void GivenISelectAdminMenuAndClickOnDefaultMargins_()
        {
            _contextData.SetBusinessType("1");
            //_contextData.Country = _countryService.GetByName(country);
            if (_contextData.Country.Cultures.Count != 1)
            {
                throw new ArgumentException("can not auto select culture. please call alternate some garkin");
            }
            _contextData.Culture = _contextData.Country.Cultures[0];
            var dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var dealerAdminDashboardPage = _mpsDealerDealershipStepActions.NavigateToDealerAdminDashboardPage(dealerDashboardPage);
            _dealerAdminDefaultMarginsPage = _mpsDealerDefaultMarginsStepActions.NavigateToDealerMarginsPage(dealerAdminDashboardPage);
        }

        [Then(@"I will be taken into the Default Margins tab\.")]
        public void ThenIWillBeTakenIntoTheDefaultMarginsTab_()
        {
            _mpsDealerDefaultMarginsStepActions.AssertAreSelectDefaultMarginsTab(_dealerAdminDefaultMarginsPage);
        }

        [When(@"I Overtype default margins HardwareDefaultMargin of ""(.*)"", AccessoriesDefaultMargin of ""(.*)"", DeliveryDefaultMargin of ""(.*)"", InstallationDefaultMargin of ""(.*)"", ServicePackDefaultMargin of ""(.*)"", MonoClickDefaultCommission of ""(.*)"", and ColourClickDefaultCommission of ""(.*)""  with required % and click Save")]
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


        [Then(@"I Default margins will be amended\.")]
        public void ThenIDefaultMarginsWillBeAmended_()
        {
            // try create proposal for view margins. logic similar as Type1BusinessScenario_1
            Given(string.Format(@"I have navigated to the Create Proposal page as a Cloud MPS Dealer from ""{0}""", _contextData.Country.Name));
            When(string.Format(@"I create a ""{0}"" proposal", "PURCHASE_AND_CLICK"));
            When(@"I enter the proposal description");
            When(@"I create a new customer for the proposal");
            When(string.Format(@"I select Usage Type of ""{0}"", Contract Term of ""{1}"", Billing Type of ""{2}"" and Service Pack type of ""{3}""",
                "MINIMUM_VOLUME",       // UsageType
                "THREE_YEARS",          // ContractTerm
                "QUARTERLY_IN_ARREARS", // BillingType
                "PAY_UPFRONT"           // ServicePackType
                ));
            var colourModel = "DCP-L8450CDW";
            When(@"I add these printers:",CreateColourPrinterTable(colourModel));
            When(@"I calculate the click price for each of the above printers");
            // verify
            _mpsDealerDefaultMarginsStepActions.VerifyDefaultMarginsWillBeAmended(_contextData.DealerAdminDefaultMargins, colourModel);
            // restore
            Given(@"I Select Admin menu and click on Default Margins.");
            _mpsDealerDefaultMarginsStepActions.SetDealerMargins(_dealerAdminDefaultMarginsPage, _contextData.DealerAdminDefaultMarginsOriginal);
            _dealerAdminDefaultMarginsPage = _mpsDealerDefaultMarginsStepActions.ClickOnSave(_dealerAdminDefaultMarginsPage);
        }

        private Table CreateColourPrinterTable(string colourModel)
        {
            Table table = new Table(new string[] {
                        "Model",
                        "Price",
                        "InstallationPack",
                        "Delivery",
                        "CoverageMono",
                        "VolumeMono",
                        "CoverageColour",
                        "VolumeColour",
                        "SerialNumber",
                        "MonoPrintCount",
                        "ColorPrintCount",
                        "TonerInkBlackStatus",
                        "TonerInkCyanStatus",
                        "TonerInkMagentaStatus",
                        "TonerInkYellowStatus",
                        "LaserUnit",
                        "FuserUnit",
                        "PaperFeedingKit1",
                        "PaperFeedingKit2",
                        "PaperFeedingKit3",
                        "IsSwap",
                        "lowerTrayPrice"

            });
            table.AddRow(new string[] {
                        colourModel,
                        "1000.00",
                        "BROTHER_INSTALLATION",
                        "Yes",
                        "5",
                        "1000",
                        "20",
                        "250",
                        "A3P145602",
                        "3000",
                        "1500",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "false",
                        "1000.00"
            });
            return table;
        }
    }
}
