using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSOne
{
    public class ContractConfirmationPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["HomePage"].ToString(); }
        }

        [FindsBy(How = How.Id, Using = "content_0_interfaceheader_0_rptContractMenus_MenuItem_0")]
        public IWebElement ContractDescription;
        [FindsBy(How = How.Id, Using = "content_0_interfaceheader_1_ContractNumberLabel")]
        public IWebElement ExistingContractId;

        public void IsExistingContractDescriptionAvailable()
        {
            if (ContractDescription == null)
            {
                throw new Exception("Unable to locate Contract Description on page");
            }
            AssertElementPresent(ContractDescription, "Contract Description");
        }

        public void VerifyTheCorrectContractIdIsDisplayed()
        {
            var displayedContractId = ExistingContractId.Text;
            var storedContractId = SpecFlow.GetContext("TheFirstContractId");
            TestCheck.AssertTextContains(displayedContractId, storedContractId);
        }
    }
}
