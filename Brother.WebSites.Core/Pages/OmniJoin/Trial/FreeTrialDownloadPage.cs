using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.Trial
{
    public class FreeTrialDownloadPage : BasePage
    {
        public static string URL = "/";

        public override string DefaultTitle
        {
             get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".enddate")]
        public IWebElement TrialEndDateText;

        [FindsBy(How = How.XPath, Using = ".//*[@id='content']/div/div[1]/hgroup/h2")]
        public IWebElement FreeTrail30DaysOmniJoinAccess;

        [FindsBy(How = How.XPath, Using = ".//*[@id='content']/div/div[2]/div[2]/div/div/div[6]/span[2]")]
        public IWebElement ValidErrorMessageonFreeOjSignupPage;


        [FindsBy(How = How.CssSelector, Using = ".info-tile-image")]
        public IWebElement InfoTileImage;

        public void IsInfoTileAvailable()
        {
            if (InfoTileImage == null)
            {
                throw new NullReferenceException("Unable to locate image on page");
            }
            AssertElementPresent(InfoTileImage, "Info Tile Image"); 
        }

        public string GetTrialExpiryDate()
        {
            return TrialEndDateText.Text;
        }


        public void FreeTrail30DaysOmniJoinAcessMessDisplayed()
        {
            TestCheck.AssertIsEqual(true, FreeTrail30DaysOmniJoinAccess.Displayed, "Is Message Displayed");
        }

        public void ValidErrorMessageonFreeOjSignupPageDisplayed()
        {
            TestCheck.AssertIsEqual(true, ValidErrorMessageonFreeOjSignupPage.Displayed, " Is Error message Displayed");
        }
    }
}
