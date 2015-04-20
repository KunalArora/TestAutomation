using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSOne
{
    [Binding]
    public class MpsbolMyAccountCheckForMpsCustomerSteps : BaseSteps
    {
        [Then(@"""(.*)"" invoices should be displayed")]
        public void ThenMyInvoicesShouldBeDisplayed(string role)
        {
            if (role.Equals("Customer"))
            {
                CurrentPage.As<MyAccountPage>().IsInvoiceSectionAvailable();
                CurrentPage.As<MyAccountPage>().VerifyInvoiceIsDisplayed();
            }
            else
            {
                CurrentPage.As<MyAccountPage>().IsInvoiceSectionAvailable();
            }
            
        }
    }
}
