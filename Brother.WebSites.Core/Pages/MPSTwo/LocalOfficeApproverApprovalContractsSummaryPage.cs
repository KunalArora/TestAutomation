using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverApprovalContractsSummaryPage : BaseSummaryPage, IPageObject
    {
        public static string _url = "/mps/local-office/approval/contracts/summary";
        private const string _validationElementSelector = ".js-mps-contract-summary-contract-accept"; // Accept button as "#content_1_ButtonAccept"

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        [FindsBy(How = How.Id, Using = "content_1_ButtonAccept")]
        public IWebElement AcceptButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonContractAcceptAccept")]
        public IWebElement FinalAcceptButtonElement;

        public void OnClickAccept(int findElementTimeout)
        {
            SeleniumHelper.ClickSafety( AcceptButtonElement, findElementTimeout ) ;
            SeleniumHelper.ClickSafety( FinalAcceptButtonElement, findElementTimeout);
        }
    }
}
