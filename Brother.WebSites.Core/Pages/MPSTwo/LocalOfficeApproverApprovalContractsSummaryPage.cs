using Brother.Tests.Selenium.Lib.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverApprovalContractsSummaryPage : BaseSummaryPage, IPageObject
    {
        public static string _url = "/mps/local-office/approval/contracts/summary";
        private const string _validationElementSelector = ".js-mps-contract-summary-contract-accept";

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

        private const string FinalAcceptButtonSelector = ".js-mps-contract-summary-contract-accept-confirm";

        [FindsBy(How = How.CssSelector, Using = ".js-mps-contract-summary-contract-accept")]
        public IWebElement AcceptButtonElement;

        [FindsBy(How = How.Id, Using = "content_1_ButtonReject")]
        public IWebElement RejectButtonElement;

        [FindsBy(How = How.Id, Using = "content_1_ButtonOpenOfferRejectReject")]
        public IWebElement FinalRejectButtonElement;

        //TODO: Refactoring
        public void OnClickAccept()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.ClickSafety(AcceptButtonElement);
            SeleniumHelper.ClickSafety(SeleniumHelper.FindElementByCssSelector(FinalAcceptButtonSelector), RuntimeSettings.DefaultFindElementTimeout, true); // Second accept is dynamic element, hence apply wait
        }

        private const string InputRejectionReasonSelector = "#content_1_InputOpenOfferRejectReason_Input";

        public void RejectContract(string contractRejectReason)
        {
            LoggingService.WriteLogOnMethodEntry(contractRejectReason);
            SeleniumHelper.ClickSafety(RejectButtonElement);
            var inputReasonElement = SeleniumHelper.FindElementByCssSelector(InputRejectionReasonSelector);
            SeleniumHelper.SelectFromDropdownByText(inputReasonElement, contractRejectReason);
            SeleniumHelper.ClickSafety(FinalRejectButtonElement, IsUntilUrlChanges: true);
        }

    }
}
