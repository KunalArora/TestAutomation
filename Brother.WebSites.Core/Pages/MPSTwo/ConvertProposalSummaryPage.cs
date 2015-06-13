using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class ConvertProposalSummaryPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_1_InputSendToLeasingBank_Label")]
        private IWebElement ThirdPartyApproval;
        [FindsBy(How = How.Id, Using = "content_1_InputEnvisagedStartDate_Input")]
        private IWebElement ProposedStartDate;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSaveAsContract")]
        private IWebElement SaveAsContractButton;
        [FindsBy(How = How.Id, Using = "content_1_InputSendToBrother_Input")]
        private IWebElement SendToBrotherElement;
        [FindsBy(How = How.Id, Using = "content_1_InputSendToSchufa_Label")]
        private IWebElement SchufaAuthorisationButton;
        [FindsBy(How = How.Id, Using = "content_1_InputSendToBrother_Label")]
        private IWebElement BrotherAuthorisationButton;
        
        
        

        public void IsConvertSummaryPageDisplayed()
        {
            if (ProposedStartDate == null)
                throw new Exception("Third party permission tick is not displayed");
            AssertElementPresent(ProposedStartDate, "Is convert proposal summary page displayed");
        }

        public void EnterProposedStartDateForContract()
        {
            if (ProposedStartDate == null)
                throw new NullReferenceException("Contract start date field not displayed");
            ProposedStartDate.SendKeys(MpsUtil.SomeDaysFromToday());

        }

        public void GiveThirdPartyCheckApproval()
        {
            ThirdPartyApproval.Click();
        }

        public void GiveBrotherAuthorisation()
        {
            BrotherAuthorisationButton.Click();
        }

        public void GiveSchufaAuthorization()
        {
            const string schufa = @"content_1_InputSendToSchufa_Label";
            var schufaElement = GetElementByCssSelector(schufa, 10);
            if (IsElementPresent(schufaElement))
                schufaElement.Click();
        }

        public DealerProposalsAwaitingApproval SaveProposalAsAContract()
        {
            if (SaveAsContractButton == null)
                throw new NullReferenceException("Save Contract button not available");
            SaveAsContractButton.Click();
            WebDriver.Wait(Helper.DurationType.Second, 5);

            return GetInstance<DealerProposalsAwaitingApproval>(Driver);
        }

    }
}
