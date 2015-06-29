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
    public class DealerContractSummaryPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSign")]
        private IWebElement DealerSignElement;


        public void IsContractSummaryPageDisplayed()
        {
            if (DealerSignElement == null)
                throw new Exception("Contract Summary not displayed");
            AssertElementPresent(DealerSignElement, "Is Contract Summary displayed");
        }

        public DealerAwaitingAcceptanceContractsPage DealerSignsApprovedProposal()
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, DealerSignElement);
            WebDriver.Wait(DurationType.Second, 3);

            return GetInstance<DealerAwaitingAcceptanceContractsPage>(Driver);
        }
    }
}
