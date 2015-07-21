using System;
using Brother.Tests.Selenium.Lib.Pages.BrotherMainSite.Smart_Supply;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.Smart_Supply
{
    [Binding]
    public class BrotherSupplyClubProductBenefitsSteps : BaseSteps
    {
        [Given(@"I have navigated to the url ""(.*)""")]
        public void GivenIHaveNavigatedToTheUrl(string p0)
        {
            CurrentDriver.Navigate().GoToUrl(p0);
            WebDriver.SetPageLoadTimeout(TimeSpan.FromSeconds(120));
        }

   
        [Then(@"I will see text information relating to the benefit I will receive")]
        public void ThenIWillSeeTextInformationRelatingToTheBenefitIWillReceive()
        {
            NextPage = SmartSupplyProductPage.Productpageload(CurrentDriver);
            CurrentPage.As<SmartSupplyProductPage>().IsBrotherSupplyClubProductBenefitAvailable();  
        }


        [When(@"I click on Add to basket button")]
        public void WhenIClickOnAddToBasketButton()
        {
            CurrentPage.As<SmartSupplyProductPage>().AddSmartSupplyProductToBasketButtonClick();
        }

        [Then(@"I hover the mouse on the basket icon to see text information relating to the benefit I will receive")]
        public void ThenIHoverTheMouseOnTheBasketIconToSeeTextInformationRelatingToTheBenefitIWillReceive()
        {
            CurrentPage.As<SmartSupplyProductPage>().Hoverbasket();
            CurrentPage.As<SmartSupplyProductPage>().PromoInfoPresent();
        }

        [Then(@"I can see the benefit text as  ""(.*)"" and ""(.*)""")]
        public void ThenICanSeeTheBenefitTextAsAnd(string line1, string line2)
        {
            CurrentPage.As<SmartSupplyProductPage>().CheckforPromoDetails(line1, line2);
            
        }

        [Then(@"I can see the product name with the benefits text")]
        public void ThenICanSeeTheProductNameWithTheBenefitsText()
        {
            CurrentPage.As<SmartSupplyProductPage>().CheckProductnameinPromoDetails();
        }

        

    }
}
