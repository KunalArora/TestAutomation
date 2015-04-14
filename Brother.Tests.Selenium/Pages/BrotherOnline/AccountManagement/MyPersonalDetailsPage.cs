using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Pages.BrotherOnline.AccountManagement
{
    public class MyPersonalDetailsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".submit.button-blue")]
        public IWebElement UpdateDetailsButton;


    }
}
