using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BankContractsSummaryPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_ButtonReject")]
        private IWebElement RjectButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonAccept")]
        private IWebElement AcceptButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonOpenOfferRejectReject")]
        private IWebElement FinalRejectButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonContractAcceptAccept")]
        private IWebElement FinalAcceptButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_InputOpenOfferRejectReason_Input")]
        public IWebElement BankRejectReasonElement;
        [FindsBy(How = How.Id, Using = "content_1_InputOpenOfferRejectComment_Input")]
        public IWebElement BankRejectCommentElement;

        public void ClickRejectButton()
        {
            ScrollTo(RjectButtonElement);
            RjectButtonElement.Click();
        }

        public void ClickAcceptButton()
        {
            ScrollTo(AcceptButtonElement);
            AcceptButtonElement.Click();
        }

        public BankContractsPage ClickFinalRejectButton()
        {
            ScrollTo(FinalRejectButtonElement);
            FinalRejectButtonElement.Click();

            return GetTabInstance<BankContractsPage>(Driver);
        }

        public BankContractsPage ClickFinalAcceptButton()
        {
            ScrollTo(FinalAcceptButtonElement);
            FinalAcceptButtonElement.Click();

            return GetTabInstance<BankContractsPage>(Driver);
        }

        public void SelectRejectionReason(string reason)
        {
            SelectFromDropdown(BankRejectReasonElement, reason);
        }

        public void IsAcceptButtonAvailable()
        {
            if (AcceptButtonElement == null)
                throw new NullReferenceException("Create Accept Button");
        }

        public void IsRejectButtonAvailable()
        {
            if (AcceptButtonElement == null)
                throw new NullReferenceException("Create Reject Button");
        }
    }
}
