using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.BrotherMainSite.Smart_Supply;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            WebDriver.SetPageLoadTimeout(TimeSpan.FromSeconds(20));
        }


        [Then(@"I will see text information relating to the benefit I will receive")]
        public void ThenIWillSeeTextInformationRelatingToTheBenefitIWillReceive()
        {

            //((Action)(() => { }))();
            CurrentPage.As<SmartSupplyProductPage>().IsBrotherSupplyClubProductBenefitAvailable();  
        }


        [When(@"I click on Add to basket button")]
        public void WhenIClickOnAddToBasketButton()
        {
            CurrentPage.As<SmartSupplyProductPage>().AddSmartSupplyProductToBasketButtonClick();
        }

        [Then(@"I hover the mouse on the basket icon to see text information relating to the benefit I will receive\.")]
        public void ThenIHoverTheMouseObTheBasketIconToSeeTextInformationRelatingToTheBenefitIWillReceive_()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
