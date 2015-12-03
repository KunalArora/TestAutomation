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

        [FindsBy(How = How.CssSelector, Using = ".info-tile-image")]
        public IWebElement InfoTileImage;

        [FindsBy(How = How.XPath, Using = ".//*[@id='content']/div/div[1]/hgroup/h2")]
        public IWebElement StartFreeTrail30DaysSignUpText;

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
        public void StartFreeTrail30DaysSignUpTextDisplayed()
        {
            TestCheck.AssertIsEqual(true, StartFreeTrail30DaysSignUpText.Displayed, "Is Text Displayed");

        } 
    }
}
