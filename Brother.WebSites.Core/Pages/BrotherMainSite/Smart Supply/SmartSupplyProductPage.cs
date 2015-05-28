using System;
//using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Pages.BrotherMainSite;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace Brother.Tests.Selenium.Lib.Pages.BrotherMainSite.Smart_Supply
{
    //[Binding]
    public class SmartSupplyProductPage : BasePage
    {
        

        [FindsBy(How = How.CssSelector, Using = ".BC-product-page")]
        public IWebElement BSCProductbenefit;


        public void IsBrotherSupplyClubProductBenefitAvailable()
        {
            try 
            {   if (BSCProductbenefit == null)
                throw new Exception("Unable to locate benefits text information on page");
            }
             catch(NotFoundException notFoundException)
            {AssertElementPresent(BSCProductbenefit, "Benefits on Product and delivery mentioned");}
        }

        [FindsBy(How = How.CssSelector, Using = ".button-blue add-to-basket-button")]
        public IWebElement AddtoBasketBrotherSupplyClubProduct;

        public void AddSmartSupplyProductToBasketButtonClick()
        {
            AddtoBasketBrotherSupplyClubProduct.Click();
        }

       
    }
}
