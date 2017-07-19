using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class FinanceAccrualsPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonRunReport")]
        public IWebElement RunReportButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputRunAtDate_Input")]
        public IWebElement ReportDateElement;


        //var searchBegin = DateTime.Now.AddDays(-1095).ToString("ddMMyyyy");

        public void EnterDateForDownload()
        {
            var searchDate = DateTime.Now.AddDays(-1).ToString("ddMMyyyy");
            ClearAndType(ReportDateElement, searchDate);
        }

        public void DownloadTheAccrualGenerated()
        {
            if(RunReportButtonElement == null)
                throw new Exception("Run Report button is missing");
            RunReportButtonElement.Click();
        }
        
    }
}
