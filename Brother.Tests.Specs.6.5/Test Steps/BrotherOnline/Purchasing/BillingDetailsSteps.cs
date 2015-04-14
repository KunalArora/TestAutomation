using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.Checkout;
using Brother.Tests.Selenium.Lib.Pages.OmniJoin.Plans;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.BrotherOnline.Purchasing
{
    [Binding]
    public class BillingDetailsSteps : BaseSteps
    {
        [When(@"I click on Use This Address")]
        [Then(@"I click on Use This Address")]
        public void ThenIClickOnUseThisAddress()
        {
            NextPage = CurrentPage.As<BillingDetailsPage>().AddCardUseThisAddressButtonClick();
        }

        [Then(@"I can add billing address details for Country ""(.*)""")]
        public void ThenICanAddBillingAddressDetailsFor(string country)
        {
            // Form filler for Billing Address - NOTE: this needs to be refactored at some stage to accomodate for more
            // countries
            CurrentPage.As<BillingDetailsPage>().IsSaveBillingAddressButtonAvailable();
            AddBillingAddressInformation(country);
            NextPage = CurrentPage.As<BillingDetailsPage>().SaveBillingAddressButtonClick();
        }

        private void AddBillingAddressInformation(string country)
        {
            CurrentPage.As<BillingDetailsPage>().PopulateFirstNameTextBox(Helper.GetAddressInfo("FirstName"));
            CurrentPage.As<BillingDetailsPage>().PopulateLastNameTextBox(Helper.GetAddressInfo("LastName"));
            if ("United Kingdom".Equals(country))
            {
                CurrentPage.As<BillingDetailsPage>().PopulatePostCodeTextBox(Helper.GetAddressInfo("PostCode"));
                //CurrentPage.As<BillingDetailsPage>().PopulateHouseNumberTextBox(Helper.GetAddressInfo("HouseNumber"));
                //CurrentPage.As<BillingDetailsPage>().PopulateHouseNameTextBox(Helper.GetAddressInfo("HouseName"));
            }
            CurrentPage.As<BillingDetailsPage>().PopulateHouseNumberTextBox(Helper.GetAddressInfo("HouseNumber"));
            CurrentPage.As<BillingDetailsPage>().PopulateHouseNameTextBox(Helper.GetAddressInfo("HouseName"));
            CurrentPage.As<BillingDetailsPage>().PopulateAddressLine1TextBox(Helper.GetAddressInfo("Address1"));
            CurrentPage.As<BillingDetailsPage>().PopulateAddressLine2TextBox(Helper.GetAddressInfo("Address2"));
            CurrentPage.As<BillingDetailsPage>().PopulateCityTownTextBox(Helper.GetAddressInfo("CityTown"));
            if (country.Equals("Ireland"))
            {
                CurrentPage.As<BillingDetailsPage>().PopulateCountryDropDown(Helper.GetAddressInfo("IECounty"));
            }
            CurrentPage.As<BillingDetailsPage>().PopulatePhoneNumberTextBox(Helper.GetAddressInfo("PhoneNumber"));
        }

        [Then(@"I can add a new billing address details for Country ""(.*)""")]
        public void ThenICanAddANewBillingAddressDetailsFor(string country)
        {
            CurrentPage.As<BillingDetailsPage>().IsSaveAddressAndReturnToPaymentMethodsButtonAvailable();
            AddBillingAddressInformation(country);
            NextPage = CurrentPage.As<BillingDetailsPage>().SaveAddressAndReturnToPaymentMethodsButtonClick();
        }

        [Then(@"If I click on Add New Address")]
        public void ThenIfIClickOnAddNewAddress()
        {
            CurrentPage.As<BillingDetailsPage>().IsAddNewAddressButtonAvailable();
            CurrentPage.As<BillingDetailsPage>().AddNewAddressButtonClick();
        }
    }
}
