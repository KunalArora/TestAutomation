using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;

namespace Brother.WebSites.Core.Pages.General
{
    public class SiteAccess : BasePage
    {
        public static void ValidateSiteUrl(string webSite)
        {
            TestController.CurrentDriver.Navigate().GoToUrl(webSite);
            MsgOutput(string.Format("Size of page [{0}] = [{1}]", webSite, TestController.CurrentDriver.PageSource.Length));
            try
            {
                var pageBodySource = TestController.CurrentDriver.FindElement(By.TagName("body")).Text;
                MsgOutput(string.Format("Size of page body = [{0}]", pageBodySource.Length));
            }
            catch (NoSuchElementException noSuchElement)
            {
                TestCheck.AssertFailTest(string.Format("Unable to locate Body element in Test website {0} [{1}]", webSite, noSuchElement));
            }
            catch (TimeoutException timeOut)
            {
               TestCheck.AssertFailTest(string.Format("Timeout searching for Body Element [{0}]", timeOut));
            }
        }

        public static void ValidateLiveSiteUrl(string webSite)
        {
            webSite = CheckForCdServer(webSite);
            TestController.CurrentDriver.Navigate().GoToUrl(webSite);
            MsgOutput(string.Format("Size of page [{0}] = [{1}]", webSite, TestController.CurrentDriver.PageSource.Length));
            try
            {
                MsgOutput("Now searching for © Copyright symbol on site");
                if (WaitForElementToExistByXPath("//div[contains(text(), '©')]", 5, 5))
                {
                    var pageBodySource = TestController.CurrentDriver.FindElement(By.TagName("body")).Text;
                    MsgOutput(string.Format("Size of page body = [{0}]", pageBodySource.Length));
                }
                else
                {
                    TestCheck.AssertFailTest(string.Format("Brother © Copyright Symbol not found in website [{0}] ", webSite));
                }
            }
            catch (NoSuchElementException noSuchElement)
            {
                TestCheck.AssertFailTest(string.Format("Brother © Copyright Symbol not found in website [{0}] [{1}]", webSite, noSuchElement));
            }
            catch (TimeoutException timeOut)
            {
                TestCheck.AssertFailTest(string.Format("Timeout searching for Brother © Copyright symbol [{0}]", timeOut));
            }
        }
    }
}
