using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.ServiceRequest
{
    [Binding]
    public class ServiceRequestsOperationsSteps : BaseSteps
    {

        [Given(@"I navigate to customer request page")]
        public void GivenINavigateToCustomerRequestPage()
        {
            NextPage = CurrentPage.As<CustomerDashboardPage>().NavigateToCustomerServiceRequestsPage();
            CurrentPage.As<CustomerServiceRequestsPage>().IsServiceRequestPageDisplayed();
        }



    }
}
