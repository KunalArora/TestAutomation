using System;
using Brother.Tests.Selenium.Lib.Pages.BrotherMainSite.Basket;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.Checkout;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using BrotherWebSitesCore.Pages.Base;
using BrotherWebSitesCore.Pages.BrotherMainSite.Basket;
using BrotherWebSitesCore.Pages.BrotherOnline.Checkout;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.BrotherOnline
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
