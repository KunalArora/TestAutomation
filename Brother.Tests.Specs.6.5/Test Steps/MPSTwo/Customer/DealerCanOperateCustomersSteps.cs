using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using NUnit.Framework.Constraints;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPSTwo.Customer
{
    [Binding]
    public class DealerCanOperateCustomersSteps : BaseSteps
    {
        [Given(@"I navigate to existing customer screen")]
        public void GivenINavigateToExistingCustomerScreen()
        {
            var page = CurrentPage.As<DealerDashBoardPage>();
            NextPage = page.NavigateToExistingCustomerPage();
            
        }
        
        [Then(@"I can see the Existing Customers table")]
        public void ThenICanSeeTheExistingCustomersTable()
        {
            var page = CurrentPage.As<CloudExisitngCustomerPage>();
            page.FindExistingCustomerList();
        }
    }
}
