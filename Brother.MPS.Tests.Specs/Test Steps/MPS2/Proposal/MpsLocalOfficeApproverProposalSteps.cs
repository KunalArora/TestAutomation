using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.MPS.Tests.Specs.MPS2.Proposal
{
    [Binding]
    public class MpsLocalOfficeApproverProposalSteps
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _driver;
        private readonly IContextData _contextData;
        private readonly PageService _pageService;
        private readonly ICountryService _countryService;
        private readonly ITranslationService _translationService;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly IProposalHelper _proposalHelper;
        private readonly ICalculationService _calculationService;
        private readonly MpsSignInStepActions _mpsSignInStepActions;
        private readonly MpsLocalOfficeApproverProposalStepActions _mpsLocalOfficeApproverProposalStepActions;

        //page objects used by these steps
        private LocalOfficeApproverApprovalProposalsApprovedPage _localOfficeApproverApprovalProposalsApprovedPage;
        private LocalOfficeApproverApprovalProposalsDeclinedPage _localOfficeApproverApprovalProposalsDeclinedPage;
        private LocalOfficeApproverReportsProposalSummaryPage _localOfficeApproverReportsProposalSummaryPage;

        public MpsLocalOfficeApproverProposalSteps(MpsSignInStepActions mpsSignInStepActions,
            MpsLocalOfficeApproverProposalStepActions mpsLocalOfficeApproverProposalStepActions,
            ScenarioContext context,
            IWebDriver driver,
            MpsContextData contextData,
            PageService pageService,
            ICountryService countryService,
            ITranslationService translationService,
            IUserResolver userResolver,
            IUrlResolver urlResolver,
            ICalculationService calculationService,
            IProposalHelper proposalHelper)
        {
            _context = context;
            _driver = driver;
            _contextData = contextData;
            _pageService = pageService;
            _countryService = countryService;
            _translationService = translationService;
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _proposalHelper = proposalHelper;
            _mpsSignInStepActions = mpsSignInStepActions;
            _mpsLocalOfficeApproverProposalStepActions = mpsLocalOfficeApproverProposalStepActions;
            _calculationService = calculationService;
        }

        [When(@"a Cloud MPS Local Office Approver Set a Special Pricing:")]
        public void WhenACloudMPSLocalOfficeApproverSetASpecialPricing(Table table)
        {
            var resourceInstallationPackBrotherInstallation = _translationService.GetInstallationPackText(TranslationKeys.InstallationPack.BrotherInstallation, _contextData.Culture);
            var resourceServicePackTypePayUpFront = _translationService.GetServicePackTypeText(TranslationKeys.ServicePackType.PayUpfront, _contextData.Culture);
            var resourceServicePackTypeIncludedInClickPrice = _translationService.GetServicePackTypeText(TranslationKeys.ServicePackType.IncludedInClickPrice, _contextData.Culture);
            var resourceServicePackTypeAddToTheLeasingRate = _translationService.GetServicePackTypeText(TranslationKeys.ServicePackType.AddToTheLeasingRate, _contextData.Culture);

            var specialPriceList = table.CreateSet<SpecialPricingProperties>();
            var localOfficeApproverDashBoardPage = _mpsSignInStepActions.SignInAsLocalOfficeApprover(_userResolver.LocalOfficeApproverUsername, _userResolver.LocalOfficeApproverPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var localOfficeApproverReportsDataQueryPage = _mpsLocalOfficeApproverProposalStepActions.NavigateToReportsDataQueryPage(localOfficeApproverDashBoardPage);
            var localOfficeApproverReportsProposalSummaryPagePre = _mpsLocalOfficeApproverProposalStepActions.NavigateToReportsProposalSummaryPage(localOfficeApproverReportsDataQueryPage, _contextData.ProposalId);
            var localOfficeApproverApprovalSpecialPricingPage = _mpsLocalOfficeApproverProposalStepActions.ClickOnSpecialPricing(localOfficeApproverReportsProposalSummaryPagePre);
            foreach (var cp in specialPriceList)
            {
                if (cp.Model == "*")
                {
                    cp.Model = ".*";
                }
                cp.InstallUnitCost = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.InstallUnitCost);
                cp.InstallMargin = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.InstallMargin);
                cp.InstallUnitPrice = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.InstallUnitPrice);
                cp.ServiceUnitCost = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.ServiceUnitCost);
                cp.ServiceMargin = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.ServiceMargin);
                cp.ServiceUnitPrice = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.ServiceUnitPrice);
                cp.MonoClickServiceCost = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.MonoClickServiceCost);
                cp.MonoClickServicePrice = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.MonoClickServicePrice);
                cp.MonoClickCoverage = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.MonoClickCoverage);
                cp.MonoClickVolume = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.MonoClickVolume);
                cp.MonoClickMargin = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.MonoClickMargin);
                cp.MonoClick = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.MonoClick);
                cp.ColourClickServiceCost = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.ColourClickServiceCost);
                cp.ColourClickServicePrice = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.ColourClickServicePrice);
                cp.ColourClickCoverage = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.ColourClickCoverage);
                cp.ColourClickVolume = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.ColourClickVolume);
                cp.ColourClickMargin = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.ColourClickMargin);
                cp.ColourClick = _calculationService.ConvertInvariantNumericToCultureNumericString(cp.ColourClick);
            }
            if ( _contextData.PrintersProperties.Any(prop=> prop.InstallationPack == resourceInstallationPackBrotherInstallation))
            {
                _mpsLocalOfficeApproverProposalStepActions.PopulateSpecialPricingInstallation(localOfficeApproverApprovalSpecialPricingPage, specialPriceList);
            }
            if (_contextData.ServicePackType == resourceServicePackTypePayUpFront
                || _contextData.ServicePackType == resourceServicePackTypeAddToTheLeasingRate )
            {
                _mpsLocalOfficeApproverProposalStepActions.PopulateSpecialPricingService(localOfficeApproverApprovalSpecialPricingPage, specialPriceList);
            }
            if (_contextData.ServicePackType == resourceServicePackTypeIncludedInClickPrice
                || _contextData.ServicePackType == resourceServicePackTypePayUpFront
                || _contextData.ServicePackType == resourceServicePackTypeAddToTheLeasingRate )
            {
                _mpsLocalOfficeApproverProposalStepActions.PopulateSpecialPricingClickPrice(localOfficeApproverApprovalSpecialPricingPage, specialPriceList);
            }
            _contextData.SpecialPriceList = specialPriceList;
            _localOfficeApproverReportsProposalSummaryPage = _mpsLocalOfficeApproverProposalStepActions.ClickOnValidateAndApplySpecialPricing(localOfficeApproverApprovalSpecialPricingPage);
            _mpsLocalOfficeApproverProposalStepActions.AssertSpecialPriceInTheAudit(specialPriceList, _localOfficeApproverReportsProposalSummaryPage);
        }

        [When(@"a Cloud MPS Local Office Approver approves the above proposal")]
        public void WhenACloudMpsLocalOfficeApproverApprovesTheAboveProposal()
        {
            //This step follows on from a previous scenario step - check context data has been set
            if (_contextData.Country == null || string.IsNullOrEmpty(_contextData.Culture))
            {
                throw new Exception("Context data not set correctly");
            }

            var localOfficeApproverDashBoardPage = _mpsSignInStepActions.SignInAsLocalOfficeApprover(_userResolver.LocalOfficeApproverUsername, _userResolver.LocalOfficeApproverPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var localOfficeApproverApprovalPage = _mpsLocalOfficeApproverProposalStepActions.NavigateToApprovalDashboard(localOfficeApproverDashBoardPage);
            var localOfficeApproverApprovalProposalsPage = _mpsLocalOfficeApproverProposalStepActions.NavigateToApprovalListPage(localOfficeApproverApprovalPage);
            var localOfficeApproverApprovalProposalsSummaryPage = _mpsLocalOfficeApproverProposalStepActions.NavigateToViewSummary(localOfficeApproverApprovalProposalsPage);
            _localOfficeApproverApprovalProposalsApprovedPage = _mpsLocalOfficeApproverProposalStepActions.ApproveProposal(localOfficeApproverApprovalProposalsSummaryPage);
        }

        [When(@"a Cloud MPS Local Office Approver declines the above proposal")]
        public void WhenACloudMPSLocalOfficeApproverDeclinesTheAboveProposal()
        {
            //This step follows on from a previous scenario step - check context data has been set
            if (_contextData.Country == null || string.IsNullOrEmpty(_contextData.Culture))
            {
                throw new Exception("Context data not set correctly");
            }

            var localOfficeApproverDashBoardPage = _mpsSignInStepActions.SignInAsLocalOfficeApprover(_userResolver.LocalOfficeApproverUsername, _userResolver.LocalOfficeApproverPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var localOfficeApproverApprovalPage = _mpsLocalOfficeApproverProposalStepActions.NavigateToApprovalDashboard(localOfficeApproverDashBoardPage);
            var localOfficeApproverApprovalProposalsPage = _mpsLocalOfficeApproverProposalStepActions.NavigateToApprovalListPage(localOfficeApproverApprovalPage);
            var localOfficeApproverApprovalProposalsSummaryPage = _mpsLocalOfficeApproverProposalStepActions.NavigateToViewSummary(localOfficeApproverApprovalProposalsPage);
            _localOfficeApproverApprovalProposalsDeclinedPage = _mpsLocalOfficeApproverProposalStepActions.DeclineProposal(localOfficeApproverApprovalProposalsSummaryPage);
        }
    }
}
