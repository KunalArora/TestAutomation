using System;
using OpenQA.Selenium;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public class ExpectedConditionsEx : Helper
    {
        public static Func<IWebDriver, bool> TitleIs(string title)
        {
            return (driver) =>
            {
                try
                {
                    return driver.Title == title;
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, bool> UrlChangeFrom(string previousUrl)
        {
            return (driver) =>
            {
                try
                {
                    return driver.Url != previousUrl;
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, bool> UrlNotChangeFrom(string previousUrl)
        {
            return (driver) =>
            {
                try
                {
                    return driver.Url == previousUrl;
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }
    }
   
}
