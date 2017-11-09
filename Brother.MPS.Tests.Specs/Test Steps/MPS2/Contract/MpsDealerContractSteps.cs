using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Contract;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Contract
{
    [Binding]
    public class MpsDealerContractSteps
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _driver;
        private readonly IContextData _contextData;
        private readonly PageService _pageService;
        private readonly ICountryService _countryService;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly MpsSignInStepActions _mpsSignInStepActions;
        private readonly MpsDealerProposalStepActions _mpsDealerProposalStepActions;
        private readonly MpsDealerContractStepActions _mpsDealerContractStepActions;

        //page objects used by these steps
        private DealerDashBoardPage _dealerDashboardPage;
        private DealerContractsPage _dealerContractsPage;
        private DealerManageDevicesPage _dealerManageDevicesPage;
        private DealerSetCommunicationMethodPage _dealerSetCommunicationMethodPage;
        private DealerSetInstallationTypePage _dealerSetInstallationTypePage;
        private DealerSendInstallationEmailPage _dealerSendInstallationEmailPage;

        public MpsDealerContractSteps(MpsSignInStepActions mpsSignInStepActions,
            MpsDealerProposalStepActions mpsDealerProposalStepActions,
            MpsDealerContractStepActions mpsDealerContractStepActions,
            ScenarioContext context,
            IWebDriver driver,
            MpsContextData contextData,
            PageService pageService,
            ICountryService countryService,
            IUserResolver userResolver,
            IUrlResolver urlResolver)
        {
            _context = context;
            _driver = driver;
            _contextData = contextData;
            _pageService = pageService;
            _countryService = countryService;
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _mpsSignInStepActions = mpsSignInStepActions;
            _mpsDealerProposalStepActions = mpsDealerProposalStepActions;
            _mpsDealerContractStepActions = mpsDealerContractStepActions;
        }


        [Given(@"I have navigated to the Accepted Contracts page as a ""(.*)"" from ""(.*)""")]
        public void GivenIHaveNavigatedToTheAcceptedContractsPageAsAFrom(string role, string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);

            switch (role)
            {
                case "Cloud MPS Dealer":
                    _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
                    break;
                default:
                    ScenarioContext.Current.Pending();
                    break;
            }

            _dealerContractsPage = _mpsDealerContractStepActions.NavigateToContractsPage(_dealerDashboardPage);
            _mpsDealerContractStepActions.MoveToAcceptedContractsTab(_dealerContractsPage);
        }


        [When(@"I locate the contract with id ""(.*)""")]
        public void WhenILocateTheContractWithId(int proposalId)
        {
            // Locate the contract using proposalId
            // Eventually, use contextData to retreive proposalId
            _mpsDealerContractStepActions.FilterContractUsingProposalId(_dealerContractsPage, proposalId);     
        }

        [When(@"I click Manage Devices in the Actions menu")]
        public void WhenIClickManageDevicesInTheActionsMenu()
        {
            _dealerManageDevicesPage = _mpsDealerContractStepActions.ClickOnManageDevicesAndProceed(_dealerContractsPage);
        }

        [When(@"I create a ""(.*)"" installation request for ""(.*)"" communication")]
        public void WhenICreateAInstallationRequestForCommunication(string installationType, string communicationMethod)
        {
            _dealerSetCommunicationMethodPage = _mpsDealerContractStepActions.CreateInstallationRequest(_dealerManageDevicesPage);
            _dealerSetInstallationTypePage = _mpsDealerContractStepActions.SelectCommunicationMethodAndProceed(_dealerSetCommunicationMethodPage, communicationMethod);
            _dealerSendInstallationEmailPage = _mpsDealerContractStepActions.SelectInstallationTypeAndProceed(_dealerSetInstallationTypePage, installationType);
            _dealerManageDevicesPage = _mpsDealerContractStepActions.PopulateInstallerEmailAndSendEmail(_dealerSendInstallationEmailPage);
        }

        [Then(@"I will be able to see the installation request created above on the Manage Devices page for the above proposal")]
        public void ThenIWillBeAbleToSeeTheInstallationRequestCreatedAboveOnTheManageDevicesPageForTheAboveProposal()
        {
            _mpsDealerContractStepActions.VerifyInstallationRequestCreated(_dealerManageDevicesPage, _contextData.InstallerEmail, _contextData.CompanyLocation);


        }

    }
}
