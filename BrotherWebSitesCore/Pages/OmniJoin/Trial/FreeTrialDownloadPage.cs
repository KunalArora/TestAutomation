﻿using System;
using BrotherWebSitesCore.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Pages.OmniJoin.Trial
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
    }
}