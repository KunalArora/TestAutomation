using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite;
using Brother.WebSites.Core.Pages.BrotherMainSite.Basket;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    [Binding]
    public class CheckoutPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }
       
        public void GetPublishedPage(string url)
        {
            WebDriver.SetPageLoadTimeout(TimeSpan.FromSeconds(120));
            WebSites.Core.Pages.General.SiteAccess.ValidateSiteUrl(url);
            WebDriver.SetPageLoadTimeout(WebDriver.DefaultTimeout);
        }

        private HttpStatusCode GetWebPageResponse(string webSite)
        {
            var responseTimer = new System.Diagnostics.Stopwatch();
            responseTimer.Start();
            // get response from WebSite
            var responseCode = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
            responseTimer.Stop();
            var responseTime = responseTimer.Elapsed;
            Helper.MsgOutput(string.Format("Response time from website [{0}] was [{1}ms]", webSite, responseTime.Milliseconds));

            return responseCode;
        }

        [FindsBy(How = How.CssSelector, Using = ".common--features-carousel--item [href='/supplies']")]
        public IWebElement SuppliesLink;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div.feature-carousel > div > ul.feature-carousel-items > li:nth-child(1) > div > a")]
        public IWebElement PrintersLink;

        [FindsBy(How = How.CssSelector, Using = "#supplies-code")]
        public IWebElement SuppliesCodeExitBox;

        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div/div[3]/div/div/div[1]/div/div/div[2]/button")]
        public IWebElement SuppliesCodeSearchButton;

        [FindsBy(How = How.Id, Using = "product--btn-buy-online")]
        public IWebElement AddToBasketButton;


       public void AddToBasketButtonClick()
        {
            ScrollTo(AddToBasketButton);
            AddToBasketButton.Click();
            Thread.Sleep(TimeSpan.FromSeconds(4));
        }

       public BasketPage GoToBolBasketPage(string url)
       {
           Driver.Navigate().GoToUrl(url);
           return GetInstance<BasketPage>(Driver);
       }

    }
}
