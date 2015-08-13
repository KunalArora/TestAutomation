using System;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Brother.WebSites.Core.Pages.BrotherMainSite.Smart_Supply
{
    public class SmartSupplyBasketPage : BasePage
    {
        public static SmartSupplyBasketPage Basketpageload(IWebDriver driver)
        {
            return GetInstance<SmartSupplyBasketPage>(driver, "", "");
        }

        /*Wait to update the basket counter
        public static int GetBasketItemsCount(IWebDriver driver)
        {
            WebDriver.Wait(Helper.DurationType.Second, 3); // wait for basket to get updated
            //return Convert.ToInt32(BasketIcon(driver).Text);
        }*/

        [FindsBy(How = How.CssSelector, Using = ".styled-checkbox")]
        public IWebElement BSCOptInCheckBox;
        public void IsBSCOptInCheckBoxAvailable()
        {
            try
            {
                if (BSCOptInCheckBox == null)
                    throw new Exception("Unable to find the checkbox to opt-in for Supply Club in basket page");
            }
            catch (NotFoundException notFoundException)
            {
                MsgOutput(string.Format("Exception was [{0}]", notFoundException));
                AssertElementPresent(BSCOptInCheckBox, "Benefits on Product and delivery mentioned");
            }
        }

      

        [FindsBy(How = How.CssSelector, Using = ".BC-basket li")]
        public IList<IWebElement> BSCBasketpageBenefits;
    
  

        [FindsBy(How = How.CssSelector, Using = ".row.delivery.cf.BC-basket")]
        public IWebElement BSCBasketDiscountElements;
        
        public void IsBCDiscountElementsAvailableInBasketPage()
        {
            try
            {
                if (BSCBasketDiscountElements == null)
                    throw new Exception("Unable to find the discount for Supply Club in basket page");
            }
            catch (NotFoundException notFoundException)
            {
                MsgOutput(string.Format("Exception was [{0}]", notFoundException));
                AssertElementPresent(BSCBasketDiscountElements, "Sconto 10% and Spedizione gratuita sopra i 30€ should be present as Brother Club member benefits");
            }
        }

        [FindsBy(How = How.CssSelector, Using = ".cart-view .total-summary .total-labels")]
        public IList<IWebElement> PriceItemsOfBSCBasketElements;
        

        //[FindsBy(How = How.CssSelector, Using = ".cart-view .total-summary .totals .total-values")]
        //public IList<IWebElement> PriceCalculationItemsOfBSCBasketElements;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div.content-unit.six > div.cart-view > div.total-summary.cf > div > div.total-values > span:nth-child(2)")]
        public IWebElement PriceDiscountForNormalUser; 

         public bool CheckForDiscountAmount(string normaluserdiscount)
         {
          string nd = PriceDiscountForNormalUser.Text;
          if (PriceDiscountForNormalUser == null)
           throw new Exception("Unable to find the discount option in the listing of the total summary");

          AssertElementText(PriceDiscountForNormalUser, normaluserdiscount, "Discount value is zero for normal user"); 
          if (nd == "€ 0,00") return true;
          return false;
         }

        public void ClickBSCOptInCheckBox()
        {
           // Checking if the Checkbox is already visible
        WebDriver.Wait(DurationType.Second, 2);
        BSCOptInCheckBox.Click();
        }

        public bool CheckForDiscountAmount()
        {
            string nd = PriceDiscountForNormalUser.Text;
            if (PriceDiscountForNormalUser == null)
                throw new Exception("Unable to find promo texts on mouse hover over basket");

            AssertElementNotContainsText(PriceDiscountForNormalUser, "€ 0,00", "Discount value is zero for normal user");
            if (nd != "€ 0,00") return true;
            return false;
        }

    }
}