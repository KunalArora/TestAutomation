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


        public void IsConvertSummaryPageDisplayed()
        {
            if(ThirdPartyApproval == null)
                throw new Exception("Third party permission tick is not displayed");
            AssertElementPresent(ThirdPartyApproval, "Is convert proposal summary page displayed");
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
