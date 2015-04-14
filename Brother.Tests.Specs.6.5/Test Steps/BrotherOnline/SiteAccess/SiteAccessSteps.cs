using System;
using System.CodeDom;
using System.Net;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Safari.Internal;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.Tests.Specs.BrotherOnline.SiteAccess
{
    [Binding]
    public class SiteAccessSteps : BaseSteps
    {
        [Given(@"The following site test site ""(.*)"" to validate I should receive an Ok response back")]
        public void GivenTheFollowingSiteTestSiteToValidateIShouldReceiveAnOkResponseBack(string url)
        {
            // Perform a page GET
            Assert.AreEqual(HttpStatusCode.OK, GetWebPageResponse(url), "Incorrect Http Status Code returned");

            WebDriver.SetPageLoadTimeout(TimeSpan.FromSeconds(120));
            ValidateTestSiteUrl(url);
            WebDriver.SetPageLoadTimeout(WebDriver.DefaultTimeout);
        }

        [Given(@"The following site ""(.*)"" to validate I should receive an Ok response back")]
        public void GivenTheFollowingSiteToValidateIShouldReceiveAnOkResponseBack(string url)
        {
            var maxTries = 5;
            HttpStatusCode responseCode = HttpStatusCode.Ambiguous;

            for (var attempts = 1; attempts < maxTries; attempts++)
            {
                Helper.MsgOutput(string.Format("Website response attempt number [{0}]", attempts));

                // Perform a page GET
                //Assert.AreEqual(HttpStatusCode.OK, GetWebPageResponse(url), "Incorrect Http Status Code Returned");
                responseCode = GetWebPageResponse(url);
                switch (responseCode)
                {
                    case HttpStatusCode.Found:
                    case HttpStatusCode.OK:
                        attempts = 5;
                        WebDriver.SetPageLoadTimeout(TimeSpan.FromSeconds(120));
                        ValidateLiveSiteUrl(url);
                        WebDriver.SetPageLoadTimeout(WebDriver.DefaultTimeout);
                        break;
                    case HttpStatusCode.MultipleChoices:
                        Helper.MsgOutput("Response code was Multiple Choices - retrying using relocate URL");
                        break;
                    default:
                        Helper.MsgOutput(string.Format("Failed to get a response from [{0}] - retrying [{1}] times", url,
                            attempts));
                        break;
                }
            }

            Assert.AreEqual(HttpStatusCode.OK, responseCode, "Http Status Code Returned");
        }

        private void ValidateTestSiteUrl(string webSite)
        {
            CurrentDriver.Navigate().GoToUrl(webSite);
            Helper.MsgOutput(string.Format("Size of page [{0}] = [{1}]", webSite, CurrentDriver.PageSource.Length));
            try
            {
                var pageBodySource = CurrentDriver.FindElement(By.TagName("body")).Text;
                Helper.MsgOutput(string.Format("Size of page body = [{0}]", pageBodySource.Length));
            }
            catch (NoSuchElementException noSuchElement)
            {
                Assert.Fail("Unable to locate Body element in Test website {0} [{1}]", webSite, noSuchElement);
            }
            catch (TimeoutException timeOut)
            {
                Assert.Fail("Timeout searching for Body Element [{0}]", timeOut);
            }
        }


        private void ValidateLiveSiteUrl(string webSite)
        {

            webSite = Helper.CheckForCdServer(webSite);
            CurrentDriver.Navigate().GoToUrl(webSite);
            Helper.MsgOutput(string.Format("Size of page [{0}] = [{1}]", webSite, CurrentDriver.PageSource.Length));
            try
            {
                Helper.MsgOutput("Now searching for © Copyright symbol on site");
                if (SeleniumHelper.WaitForElementToExistByXPath("//div[contains(text(), '©')]", 5, 5))
                {
                    var pageBodySource = CurrentDriver.FindElement(By.TagName("body")).Text;
                    Helper.MsgOutput(string.Format("Size of page body = [{0}]", pageBodySource.Length));
                }
                else
                {
                    Assert.Fail("Brother © Copyright Symbol not found in website [{0}] ", webSite); 
                }
            }
            catch (NoSuchElementException noSuchElement)
            {
                Assert.Fail("Brother © Copyright Symbol not found in website [{0}] [{1}]", webSite, noSuchElement);
            }
            catch (TimeoutException timeOut)
            {
                Assert.Fail("Timeout searching for Brother © Copyright symbol [{0}]", timeOut);
            }
        }

        private HttpStatusCode GetWebPageResponse(string webSite)
        {
            var responseTimer = new System.Diagnostics.Stopwatch();
            responseTimer.Start();
            // get response from WebSite
            var responseCode = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Head);
            responseTimer.Stop();
            var responseTime = responseTimer.Elapsed;
            Helper.MsgOutput(string.Format("Response time from website [{0}] was [{1}ms]", webSite, responseTime.Milliseconds));

            return responseCode;
        }
    }
}
