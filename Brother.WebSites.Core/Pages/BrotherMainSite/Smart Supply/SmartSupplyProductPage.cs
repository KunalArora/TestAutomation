using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Pages.BrotherMainSite.Smart_Supply
{
    
    public class SmartSupplyProductPage : BasePage
    {

        public static SmartSupplyProductPage Productpageload(IWebDriver driver )
        {
          return GetInstance<SmartSupplyProductPage>(driver, "", "");
        }



        [FindsBy(How = How.CssSelector, Using = ".BC-product-page")]
        public IWebElement BSCProductbenefit;


        public void IsBrotherSupplyClubProductBenefitAvailable()
        {
            try
            {
                if (BSCProductbenefit == null)
                    throw new Exception("Unable to locate benefits text information on page");
            }
            catch (NotFoundException notFoundException)
            {
                MsgOutput(string.Format("Exception was [{0}]", notFoundException));
                AssertElementPresent(BSCProductbenefit, "Benefits on Product and delivery mentioned");
            }
        }

        [FindsBy(How = How.CssSelector, Using = ".button-blue.add-to-basket-button")]
        public IWebElement AddtoBasketBrotherSupplyClubProduct;

        public void AddSmartSupplyProductToBasketButtonClick()
        {
            AddtoBasketBrotherSupplyClubProduct.Click();
            // Checking if the add to cart click event is performed fully
            WebDriver.Wait(DurationType.Second, 5);
        }

        [FindsBy(How = How.CssSelector, Using = ".basket-container")]
        public IWebElement ProductBasketContainer;
        [FindsBy(How = How.CssSelector, Using = ".promo-info")]
        public IWebElement PromoInfo;

        [FindsBy(How = How.CssSelector, Using = ".promo-info ul li")]
        public IList<IWebElement> BenefitsText;

        [FindsBy(How = How.CssSelector, Using = "li.nav-basket")]
        public IWebElement BasketIconSmartSupply;

        [FindsBy(How = How.CssSelector, Using = ".sections.add-to-basket")]
        public IWebElement ChechOutButtonSmartSupply;

        public void Hoverbasket()
        {
            MoveToElement(ProductBasketContainer);
            MoveToElement(PromoInfo);
        }

        public void PromoInfoPresent()
        {
            AssertElementPresent(PromoInfo, "Benefit header");
        }

        public void CheckforPromoDetails(string ptf, string ptl)
        {

            string[] rid = BenefitsText.First().Text.Split(' ');
            string printer = rid.ElementAt(2);
            Hoverbasket();
            if (BenefitsText == null)
            {
                throw new Exception("Unable to find promo texts on mouse hover over basket");
            }

            AssertElementText(BenefitsText.First(), ptf, "Product discount benefits are mentioned");
            //Hoverbasket();
            AssertElementText(BenefitsText.ElementAt(1), ptl,  "Delivery benefits are mentioned");
        }

        public bool CheckProductnameinPromoDetails()
        {
            Hoverbasket();
            string[] rid = BenefitsText.First().Text.Split(' ');
            var productname = rid.ElementAt(2);
            if (productname == "TN-2220") return true;
            return false;
        }

        public void ClickBasketIcon()
        {
         BasketIconSmartSupply.Click();
         MoveToElement(ChechOutButtonSmartSupply);
        }


        public void ClickCheckOutButtonSmartSupply()
        {
            MoveToElement(ProductBasketContainer);
            MoveToElement(ChechOutButtonSmartSupply);
            ChechOutButtonSmartSupply.Click();
        }
    }
}
