using System;
using System.Collections.Generic;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Brother.WebSites.Core.Pages.BrotherMainSite.Smart_Supply
{
    public class SmartSupplyBasketPage : BasePage
    {
        public static SmartSupplyBasketPage Productpageload(IWebDriver driver)
        {
            return GetInstance<SmartSupplyBasketPage>(driver, "", "");
        }

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
    
  

        [FindsBy(How = How.CssSelector, Using = "#div.row.delivery.cf.BC-basket")]
        public IWebElement BCBasketElements;



    }
}
