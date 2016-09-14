using System;
using System.Collections.Generic;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public static class CalculationEngineModule
    {

        private const string DownloadProposalPdf = @"#content_1_ButtonDownloadProposalPdf";
        private const string DownloadSendToApproverPdf = @"#content_1_ButtonDownloadProposalPdf2";

        private static readonly Dictionary<string, string> AuthHeader = new Dictionary<string, string>
        {
            { @"X-BROTHER-Auth", @".Kol%CV#<X$6o4C4/0WKxK36yYaH10" }
            //{ @"X-BROTHER-Auth", @"OX6Z{mO~nQ87rE!32j6Sjo!21@+`by" }
            
        };


        public static string ProposalName()
        {
            var scenarioName = ScenarioContext.Current.ScenarioInfo.Title;
            scenarioName = scenarioName.Replace(" ", "");

            var generatedProposalName = "";

            var prefix = MpsUserLogins.PasswordPrefix();

            if (prefix.ToLower() == "de")
            {
                prefix = "IG";
            }

            var country = String.Format("B{0}", prefix);

            var env = Environment.GetEnvironmentVariable("AutoTestComplimentEnv", EnvironmentVariableTarget.Machine);

            generatedProposalName = String.Format("{0}-{1}-{2}_{3}", country, scenarioName, env, DateTime.Now.ToString("MMdHHmmss"));

            SpecFlow.SetContext("GeneratedProposalName", generatedProposalName);

            return generatedProposalName;

        }

        public static void DownloadPageHtml(IWebDriver driver, string rolePage)
        {
            var url = driver.PageSource;

            var name = "";

            var proposalName = SpecFlow.GetContext("GeneratedProposalName");

            if (url.Contains("contracts/summary"))
            {
                name = proposalName + String.Format("_{0}_ContractSummary", rolePage);
            } 
            else if (url.Contains("summary"))
            {
                name = proposalName + String.Format("_{0}_ProposalSummary", rolePage);
            }
            
            Utils.DownloadAndSaveWebPage(url, proposalName, name);
        }

        public static string CountryToSelect()
        {
            return SpecFlow.GetContext("CountrySelect");
        }
        private static IWebElement DownloadProposalFromSendToApproverPdfElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(DownloadSendToApproverPdf));
        }

        private static IWebElement DownloadProposalPdfElement(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(DownloadProposalPdf));
        }

        public static void DownloadProposalPdfOnSummaryPage(IWebDriver driver)
        {
            DownloadProposalPdfElement(driver).Click();
        }

        public static void DownloadProposalPdfOnSendToBankSummaryPage(IWebDriver driver)
        {
            DownloadProposalFromSendToApproverPdfElement(driver).Click();
        }

        public static void DownloadContractPdf(IWebDriver driver)
        {
            var proposalName = SpecFlow.GetContext("GeneratedProposalName");
            ActionsModule.ClickOnSpecificActionsElement(driver, proposalName);
            ActionsModule.DownloadContractPDFAction(driver);
        }
    }
}
