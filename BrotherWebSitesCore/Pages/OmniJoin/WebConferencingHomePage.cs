using System;
using Brother.Tests.Selenium.Lib.Pages.OmniJoin.Plans;
using Brother.Tests.Selenium.Lib.Pages.OmniJoin.Trial;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using BrotherWebSitesCore.Pages.Base;
using BrotherWebSitesCore.Pages.OmniJoin.Trial;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BrotherWebSitesCore.Pages.OmniJoin
{
    public class WebConferencingHomePage : BasePage
    {
        public static string URL = "/business-solutions/web-conferencing";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "a.button-grey[href*='plans']")]
        public IWebElement BuyPlanButton;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div.steps-content.grid_12 > div.steps-link1.grid_12 > a.button-orange")] //"a.button-orange[href='/free-trial']")]
        public IWebElement GettingStartedButton;

        [FindsBy(How = How.CssSelector, Using = ".omnijoin-sec-nav")]
        public IWebElement SecondaryStickyNavBar;

        public void IsBuyButtonAvailable()
        {
            if (BuyPlanButton == null)
            {
                throw new NullReferenceException("Unable to locate Button on page");
            }
            AssertElementPresent(BuyPlanButton, "Buy Plan Button");
        }

        public PlansHomePage BuyButtonClick()
        {
            ScrollTo(BuyPlanButton);
            ScrollToLocation(TestController.CurrentDriver, 0, -(SecondaryStickyNavBar.Size.Height * 2));
            try
            {
                if (BuyPlanButton.Displayed)
                {
                    BuyPlanButton.Click();
                }
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                Helper.MsgOutput("Buy Button is not visible and is obscured", elementNotVisible.Message);
                
            }
            
            return GetInstance<PlansHomePage>(Driver);
        }

        public FreeTrialPage GettingStartedButtonClick()
        {
            ScrollTo(GettingStartedButton);
            ScrollToLocation(TestController.CurrentDriver, 0, -(SecondaryStickyNavBar.Size.Height * 2));
            GettingStartedButton.Click();
            return GetInstance<FreeTrialPage>(Driver);
        }


    }
}
