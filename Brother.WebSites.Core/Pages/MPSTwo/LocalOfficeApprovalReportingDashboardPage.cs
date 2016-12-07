using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApprovalReportingDashboardPage : BasePage
    {
        private const string DownloadDirectory = @"C:\DataTest";
        
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/reports\"]")]
        public IWebElement ReportTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/reports/data-query\"] .media-heading")]
        public IWebElement DataQueryElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/reports/basic-data-report\"] .media-heading")]
        public IWebElement BasicDataReportElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/reports/dealer-report\"] .media-heading")]
        public IWebElement DealerReportElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/reports/supplies-orders-report\"] .media-heading")]
        public IWebElement SupplierOrdersReportElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/reports/print-volume-report\"] .media-heading")]
        public IWebElement PrintVolumeReportElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/reports/service-request-report\"] .media-heading")]
        public IWebElement ServiceRequestReportElement;


        public void IsReportingPageDisplayed()
        {
            if(ReportTabElement == null)
                throw new Exception("Reporting page not displayed");

            AssertElementPresent(ReportTabElement, "reporting page is not available");
        }

        public void DownloadASpecifiedReport(string report)
        {
            switch (report)
            {
                case "Basic Data Report":
                    DownloadBasicDataReport();
                    break;
                case "Supplier Orders Report":
                    DownloadSupplierOrdersReport();
                    break;
                case "Dealer Report":
                    DownloadDealerReport();
                    break;
                case "Print Volume Report":
                    DownloadPrintVolumeReport();
                    break;
                case "Service Request Report":
                    DownloadServiceRequestReport();
                    break;
            }
        }

        public DataQueryPage NavigateToDataQueryPage()
        {
            IsReportingPageDisplayed();
            DataQueryElement.Click();

            return GetInstance<DataQueryPage>();
        }

        private void DownloadBasicDataReport()
        {
            IsReportingPageDisplayed();
            BasicDataReportElement.Click();
            IsReportDownloaded();
            PurgeDirectoryForAnyExtension(DownloadDirectory, "xlsx");
        }

        private void DownloadDealerReport()
        {
            IsReportingPageDisplayed();
            DealerReportElement.Click();
            IsReportDownloaded();
            PurgeDirectoryForAnyExtension(DownloadDirectory, "xlsx");
        }

        private void IsReportDownloaded()
        {
            WebDriver.Wait(DurationType.Second, 10);
           var downloaded = IsFileDownloaded(DownloadDirectory, "xlsx");

            TestCheck.AssertIsEqual(true, downloaded, "The request report was not downloaded");
        }

        

        private void DownloadSupplierOrdersReport()
        {
            IsReportingPageDisplayed();
            SupplierOrdersReportElement.Click();
            IsReportDownloaded();
            PurgeDirectoryForAnyExtension(DownloadDirectory, "xlsx");
        }

        private void DownloadPrintVolumeReport()
        {
            IsReportingPageDisplayed();
            PrintVolumeReportElement.Click();
            IsReportDownloaded();
            PurgeDirectoryForAnyExtension(DownloadDirectory, "xlsx");
        }

        private void DownloadServiceRequestReport()
        {
            IsReportingPageDisplayed();
            ServiceRequestReportElement.Click();
            IsReportDownloaded();
            PurgeDirectoryForAnyExtension(DownloadDirectory, "xlsx");
        }

    }
}
