using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsSummaryPage : BaseSummaryPage, IPageObject
    {
        public static string _url = "/mps/dealer/proposals/summary";
        private const string _validationElementSelector = ".js-mps-nav-back"; // Back button element

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

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

        [FindsBy(How = How.Id, Using = "content_1_ButtonDownloadProposalPdf")]
        public IWebElement DownloadProposalPdfElement;

        [FindsBy(How = How.Id, Using = "content_1_ButtonCancel")]
        public IWebElement CancelProposalElement;

        public void ClickOnCancelProposalButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.ClickSafety(CancelProposalElement);
            SeleniumHelper.AcceptJavascriptAlert();
        }
    }

}
