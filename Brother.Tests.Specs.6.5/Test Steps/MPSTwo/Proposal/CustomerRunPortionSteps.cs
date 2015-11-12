using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class CustomerRunPortionSteps : BaseSteps
    {
        [When(@"I navigate to customer dashboard page")]
        public void WhenINavigateToCustomerDashboardPage()
        {
            NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToCustomerDashboardPage();
            CurrentPage.As<CustomerDashboardPage>().IsCustomerDashboardPageDisplayed();
        }

    }
}
