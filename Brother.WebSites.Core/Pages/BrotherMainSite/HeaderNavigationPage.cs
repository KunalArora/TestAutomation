using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherMainSite
{
   public class HeaderNavigationPage : BasePage
    {
            
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "[href='/Products/']")]
        public IWebElement ProductsTopMenu8;

        [FindsBy(How = How.CssSelector, Using = "[href='http://www.brothersewing.co.uk/']")]
        public IWebElement SewingLink;

        [FindsBy(How = How.CssSelector, Using = ".signIn")]
        public IWebElement SignIn;


        public void HoverProductsMenu8(IWebDriver driver)
        {
            var action = new Actions(driver);
            var menuHoverLink = driver.FindElement(By.CssSelector("[href='/Products/']"));
            action.MoveToElement(menuHoverLink).Build().Perform();
            WaitForElementToExistByCssSelector("[href='/Products/']", 60, 60);
        }
        public void HoverProductsMenuAndClickOnSewingLink(IWebDriver driver)
        {
            var action = new Actions(driver);
            var menuHoverLink = driver.FindElement(By.CssSelector("[href='/Products/']"));
            action.MoveToElement(menuHoverLink).Build().Perform();
            WaitForElementToExistByCssSelector("[href='/Products/']", 60, 60);
            WaitForElementToExistByCssSelector("[href='http://www.brothersewing.co.uk/']", 60, 60);
            var submenu = driver.FindElement(By.CssSelector("[href='http://www.brothersewing.co.uk/']"));
            action.MoveToElement(submenu).Build().Perform();
            submenu.Click();
        }
       
       public void SignInExist()
       {
           AssertElementPresent(SignIn, "sign in field");
       }

       public void ClickOnConferencingOption(IWebDriver driver)
       {
           var action = new Actions(driver);
           var menuHoverLink = driver.FindElement(By.CssSelector("[href='http://www.brother.co.uk/business-solutions/web-conferencing']"));
           action.MoveToElement(menuHoverLink).Build().Perform();
           WaitForElementToExistByCssSelector("[href='http://www.brother.co.uk/business-solutions/web-conferencing']", 30, 30);
       }

    }
}


