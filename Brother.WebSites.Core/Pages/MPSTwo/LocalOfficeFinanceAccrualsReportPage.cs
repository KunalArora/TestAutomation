using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeFinanceAccrualsReportPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "#content_1_ButtonRunReport";
        private const string _url = "/mps/local-office/finance/accruals/report";

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/finance\"]")]
        public IWebElement FinanceTabElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputRunAtDate_Input")]
        public IWebElement InputRunAtDateElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonRunReport")]
        public IWebElement ButtonRunReportElement;

        public void EnterRunAtDate(DateTime dateTime)
        {
            LoggingService.WriteLogOnMethodEntry(dateTime);
            InputRunAtDateElement.SendKeys(MpsUtil.DateTimeString(dateTime, CultureInfo.TwoLetterISOLanguageName));
        }

        public void ClickOnRunReport()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.ClickSafety(ButtonRunReportElement);
        }

        public void ClickOnFinanceTab()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.ClickSafety(FinanceTabElement,IsUntilUrlChanges:true);
        }
    }
}
