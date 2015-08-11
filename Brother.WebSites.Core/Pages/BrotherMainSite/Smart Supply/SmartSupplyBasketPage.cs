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
        public IWebElement BSCOptincheckbox;
        public void IsBSCOptincheckboxAvailable()
        {
            try
            {
                if (BSCOptincheckbox == null)
                    throw new Exception("Unable to find the checkbox to opt-in for Supply Club in basket page");
            }
            catch (NotFoundException notFoundException)
            {
                MsgOutput(string.Format("Exception was [{0}]", notFoundException));
                AssertElementPresent(BSCOptincheckbox, "Benefits on Product and delivery mentioned");
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
        

        [FindsBy(How = How.CssSelector, Using = ".cart-view .total-summary .totals .total-values")]
        public IList<IWebElement> PriceCalculationItemsOfBSCBasketElements;

         public bool CheckForDiscountAmount(string normaluserdiscount)
         {
          string[] nd = PriceCalculationItemsOfBSCBasketElements.ElementAt(0).Text.Split(' ');
          var nda = nd.ElementAt(1);
          if(PriceCalculationItemsOfBSCBasketElements == null)
           throw new Exception("Unable to find promo texts on mouse hover over basket");

          AssertElementText(PriceCalculationItemsOfBSCBasketElements.ElementAt(1), normaluserdiscount, "Discount value is zero for normal user");
          if (nda == "€ 0,00") return true;
          return false;
         }
    }
}