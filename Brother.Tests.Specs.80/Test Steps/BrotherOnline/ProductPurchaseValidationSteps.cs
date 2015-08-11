using Brother.Tests.Selenium.Lib.Support;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.Basket;
using Brother.WebSites.Core.Pages.BrotherOnline.Checkout;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs._80.BrotherOnline
{
    [Binding]
    public class ProductPurchaseValidationSteps : BaseSteps
    {
        [Then(@"I can clear the Basket")]
        public void ThenICanClearTheBasket()
        {
            BasketModule.ClearBasket(TestController.CurrentDriver);
        }

        [Then(@"I can validate selected ""(.*)"" for ""(.*)"" with varying valid and invalid data examples from file DeliveryAddressFieldValidation\\\.xml")]
        public void ThenICanValidateSelectedForWithVaryingValidAndInvalidDataExamplesFromFileDeliveryAddressFieldValidation_Xml(string fieldList, string country)
        {
            CurrentPage.As<DeliveryDetailsPage>().ValidateAddressFields(fieldList, country);
        }
    }
}
