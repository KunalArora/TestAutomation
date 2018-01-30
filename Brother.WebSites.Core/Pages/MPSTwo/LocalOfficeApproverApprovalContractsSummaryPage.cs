using Brother.Tests.Selenium.Lib.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

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

        //TODO: Refactoring
        public void OnClickAccept()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.ClickSafety(AcceptButtonElement);
            SeleniumHelper.ClickSafety(FinalAcceptButtonElement);
        }
    }
}
