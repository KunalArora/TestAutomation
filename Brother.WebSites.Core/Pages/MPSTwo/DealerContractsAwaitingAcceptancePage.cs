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
using TechTalk.SpecFlow;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerContractsAwaitingAcceptancePage : BasePage
    {
        public static string URL = "/mps/dealer/contracts";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".active [href=\"/mps/dealer/contracts/awaiting-acceptance\"]")]
        public IWebElement ContractAwaitingAcceptanceTabElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-manage-devices")]
        public IWebElement ManageDevicesElement;


        public void IsContractAwaitingAcceptanceTabDisplayed()
        {
            if(ContractAwaitingAcceptanceTabElement == null)
                throw new Exception("Dealer Contract Awaiting Acceptance tab is not displayed");
            AssertElementPresent(ContractAwaitingAcceptanceTabElement, "Dealer Contract Awaiting Acceptance tab");
        }


        public void VerifyAcceptedContractIsDisplayed()
        {
            var createdProposal = MpsUtil.CreatedProposal();
            var newlyAdded = @"//td[text()='{0}']";
            newlyAdded = String.Format(newlyAdded, createdProposal);

            var newProposal = Driver.FindElement(By.XPath(newlyAdded));

            TestCheck.AssertIsEqual(true, newProposal.Displayed, "Is new proposal displayed");
        }

        public ManageDevicesPage NavigateToManageDevicesPage()
        {
            if (ManageDevicesElement == null)
                throw new Exception("Manage Device Element is not displayed");

            WebDriver.Wait(DurationType.Second, 30);

            ScrollTo(ActionsModule.SpecificActionsDropdownElement());
            ActionsModule.ClickOnSpecificActionsElement();

            ScrollTo(ManageDevicesElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ManageDevicesElement);
            WebDriver.Wait(DurationType.Second, 30);
            return GetInstance<ManageDevicesPage>(Driver);
        }

        


    }
}
