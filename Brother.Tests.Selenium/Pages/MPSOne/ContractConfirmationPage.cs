using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline;
using Brother.Tests.Selenium.Lib.Properties;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace Brother.Tests.Selenium.Lib.Pages.MPSOne
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
            var storedContractId = ScenarioContext.Current["TheFirstContractId"].ToString();
            AssertTextContains(displayedContractId, storedContractId);
        }
    }
}
