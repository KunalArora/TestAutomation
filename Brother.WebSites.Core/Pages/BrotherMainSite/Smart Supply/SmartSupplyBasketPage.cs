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

        [FindsBy(How = How.Id, Using = "content_0_basketoptions_0_chkBrotherSupplyClubOptIn")]
        public IWebElement BSCOptInCheckBox;
        public void IsBSCOptInCheckBoxAvailable()
        {
            WebDriver.Wait(DurationType.Second, 5);
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

        [FindsBy(How = How.CssSelector, Using = ".total-values span")]
        public IList<IWebElement> PriceDiscountForNormalUser; 

         public bool CheckForDiscountAmount(string normaluserdiscount)
         {
          WaitForElementToExistByCssSelector(".cart-view .total-summary .totals .total-values", 2, 60);
          string nd = PriceDiscountForNormalUser.ElementAt(1).Text;
          if (nd == null)
           throw new Exception("Unable to find the discount option in the listing of the total summary");

          AssertElementText(PriceDiscountForNormalUser.ElementAt(1), normaluserdiscount, "Discount value is zero for normal user"); 
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
            string nd = PriceDiscountForNormalUser.ElementAt(1).Text;
            if (PriceDiscountForNormalUser == null)
                throw new Exception("Unable to find the discount value in the listing of the total summary");

            AssertElementNotContainsText(PriceDiscountForNormalUser.ElementAt(1), "€ 0,00", "Discount value is not zero for supply club user");
            if (nd != "€ 0,00") return true;
            return false;
        }

        [FindsBy(How = How.CssSelector, Using = ".total-labels span")]
        public IList<IWebElement> PriceLabelSequenceInBasketPage;

        public bool CheckForPriceLabelSequenceInBasketPage()
        {
            string[] PriceLabelsList = {"Subtotale (IVA esclusa)", "Sconto", "Prezzo netto", "IVA 22%", "Totale da pagare ora"};
            string[] VerifyPriceLabelsList = new string[PriceLabelsList.Length];
            for (int i = 0; i < PriceLabelsList.Length; i++)
            {
                // Assign string reference based on induction variable.
                VerifyPriceLabelsList[i] = PriceLabelSequenceInBasketPage.ElementAt(i).Text;
            }
            if (PriceLabelsList == VerifyPriceLabelsList) return true;
            return false;
        }
    }
}