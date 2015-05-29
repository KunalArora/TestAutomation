using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class LocalOfficeAdminSteps : BaseSteps
    {
        [Given(@"I enable Easy Print Pro contract")]
        public void GivenIEnableEasyPrintProContract()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminDashBoardPage>().NavigateToEasyPrintProPage();
            CurrentPage.As<EasyPrintProPage>().EnableContractType();
        }

        [Given(@"I navigate to Local Office Admin Dashboard page")]
        public void GivenINavigateToLocalOfficeAdminDashboardPage()
        {
            NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToLOAdminDashboard();
        }

        [When(@"I navigate to Dealer Defaults page")]
        public void WhenINavigateToDealerDefaultsPage()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminDashBoardPage>().NavigateToDealerDefaultsPage();
        }

        [When(@"I can set the default margins for all contracts")]
        public void WhenICanSetTheDefaultMarginsForAllContracts()
        {
            NextPage = CurrentPage.As<DealerDefaultsPage>().SaveDealerDefaults();
        }
    }
}
