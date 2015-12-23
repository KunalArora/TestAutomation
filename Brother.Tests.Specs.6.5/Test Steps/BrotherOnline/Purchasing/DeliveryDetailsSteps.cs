using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Checkout;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.Tests.Specs.BrotherOnline.Purchasing
{
    [Binding]
    public class DeliveryDetailsSteps : BaseSteps
    {
        [Then(@"I should see the enter Delivery Address details page")]
        public void ThenIShouldSeeTheEnterDeliveryAddressDetailsPage()
        {
            CurrentPage.As<DeliveryDetailsPage>().IsSaveAndUseAddressButtonAvailable();
        }
          
        [Then(@"I should see DeliveryAddress page")]
        public void ThenIShouldSeeDeliveryAddressPage()
        {
          CurrentPage.As<DeliveryDetailsPage>().IsDeliveryPageSaveAndUserAddressButtonDisplayed();
        }

        [Then(@"I can add delivery address details")]
        public void ThenICanAddDeliveryAddressDetails()
        {
            // Form filler for Delivery Address - should work on all present Delivery Address forms in Brother
            ThenIShouldSeeTheEnterDeliveryAddressDetailsPage();
            CurrentPage.As<DeliveryDetailsPage>().PopulateFirstNameTextBox(Helper.GetAddressInfo("FirstName"));
            CurrentPage.As<DeliveryDetailsPage>().PopulateLastNameTextBox(Helper.GetAddressInfo("LastName"));
            CurrentPage.As<DeliveryDetailsPage>().PopulateHouseNumberTextBox(Helper.GetAddressInfo("HouseNumber"));
            CurrentPage.As<DeliveryDetailsPage>().PopulateHouseNameTextBox(Helper.GetAddressInfo("HouseName"));
            CurrentPage.As<DeliveryDetailsPage>().PopulateAddressLine1TextBox(Helper.GetAddressInfo("Address1"));
            CurrentPage.As<DeliveryDetailsPage>().PopulateAddressLine2TextBox(Helper.GetAddressInfo("Address2"));
            CurrentPage.As<DeliveryDetailsPage>().PopulateCityTownTextBox(Helper.GetAddressInfo("CityTown"));
            CurrentPage.As<DeliveryDetailsPage>().PopulateCountyDropDown(Helper.GetAddressInfo("Country"));
            CurrentPage.As<DeliveryDetailsPage>().PopulatePhoneTextBox(Helper.GetAddressInfo("PhoneNumber"));
        }

        [When(@"I enter the delivery address details ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", (.*)")]
        public void WhenIEnterTheDeliveryAddressDetails(string firstName, string lastName, int houseNumber, string houseName, string addrLine1, string addrLine2, string cityTown, string county, Decimal phoneNumber)
        {
            CurrentPage.As<DeliveryDetailsPage>().PopulateFirstNameTextBox(firstName);
            CurrentPage.As<DeliveryDetailsPage>().PopulateLastNameTextBox(lastName);
            CurrentPage.As<DeliveryDetailsPage>().PopulateHouseNumberTextBox(houseNumber.ToString());
            CurrentPage.As<DeliveryDetailsPage>().PopulateHouseNameTextBox(houseName);
            CurrentPage.As<DeliveryDetailsPage>().PopulateAddressLine1TextBox(addrLine1);
            CurrentPage.As<DeliveryDetailsPage>().PopulateAddressLine2TextBox(addrLine2);
            CurrentPage.As<DeliveryDetailsPage>().PopulateCityTownTextBox(cityTown);
            if (county != string.Empty)
            {
                CurrentPage.As<DeliveryDetailsPage>().PopulateCountyDropDown(county);
            }
            CurrentPage.As<DeliveryDetailsPage>().PopulatePhoneTextBox(phoneNumber.ToString());
        }

        [When(@"I enter the delivery details")]
        public void WhenIEnterTheDeliveryDetails(Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            CurrentPage.As<DeliveryDetailsPage>().PopulateFirstNameTextBox(form.FirstName);
            CurrentPage.As<DeliveryDetailsPage>().PopulateLastNameTextBox(form.LastName);
            CurrentPage.As<DeliveryDetailsPage>().PopulateHouseNumberTextBox(form.HouseNumber.ToString());
            CurrentPage.As<DeliveryDetailsPage>().PopulateHouseNameTextBox(form.HouseName);
            CurrentPage.As<DeliveryDetailsPage>().PopulateAddressLine1TextBox(form.AddressLine1);
            CurrentPage.As<DeliveryDetailsPage>().PopulateAddressLine2TextBox(form.AddressLine2);
            CurrentPage.As<DeliveryDetailsPage>().PopulateCityTownTextBox(form.CityTown);
            CurrentPage.As<DeliveryDetailsPage>().PopulateCountyDropDown(form.County);
            CurrentPage.As<DeliveryDetailsPage>().PopulatePhoneTextBox(form.Phone.ToString());
        }

        [Then(@"I fill in firstname as ""(.*)""")]
        public void ThenIFillInFirstnameAs(string firstName)
        {
            CurrentPage.As<DeliveryDetailsPage>().PopulateFirstNameTextBox(firstName);
        }

        [Then(@"I fill in LastName as ""(.*)""")]
        public void ThenIFillInLastNameAs(string lastName)
        {
            CurrentPage.As<DeliveryDetailsPage>().PopulateLastNameTextBox(lastName);
        }

        [Then(@"I fill in HouseNumber as ""(.*)""")]
        public void ThenIFillInHouseNumberAs(string houseNumber)
        {
            CurrentPage.As<DeliveryDetailsPage>().PopulateHouseNameTextBox(houseNumber);
        }
        [Then(@"I fill in AddressLine(.*) as ""(.*)""")]
        public void ThenIFillInAddressLineAs(int p0, string addressLine1)
        {
         CurrentPage.As<DeliveryDetailsPage>().PopulateAddressLine1TextBox(addressLine1);
        }

        [Then(@"I fill in CityTown as ""(.*)""")]
        public void ThenIFillInCityTownAs(string cityTown)
        {
            CurrentPage.As<DeliveryDetailsPage>().PopulateDeliveryPageCityTownTextBox(cityTown);
        }
        
        [Then(@"I fill in PhoneNumber as ""(.*)""")]
        public void ThenIFillInPhoneNumberAs(string phoneNumber)
        {
           CurrentPage.As<DeliveryDetailsPage>().PopulateDeliveryPagePhoneNumberTextBox(phoneNumber);
        }

        [Then(@"I Click Save & use address")]
        public void ThenIClickSaveUseAddress()
        {
            NextPage = CurrentPage.As<DeliveryDetailsPage>().DeliveryPageSaveAndUseAddressButtonClick();

        }


        [When(@"I Click Save & use address")]
        public void WhenIClickSaveUseAddress()
        {
            NextPage = CurrentPage.As<DeliveryDetailsPage>().SaveAndUseAddressButtonClick();
        }
    }
}
