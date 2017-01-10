using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class ReportProposalSummaryPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".btn.btn-primary.pull-right.js-mps-special-pricing")]
        public IWebElement SpecialPricingButton;
        [FindsBy(How = How.CssSelector, Using = "#TableProposalAudit")]
        public IWebElement SpecialPricingAuditConfirmationTable;
        [FindsBy(How = How.CssSelector, Using = "#content_0_SummaryTable_RepeaterModels_MonoClickRate_0")]
        public IWebElement SpecialPricingSummaryPageMonoClickPrice;
        [FindsBy(How = How.CssSelector, Using = "#content_0_SummaryTable_RepeaterModels_ColourClickRate_0")]
        public IWebElement SpecialPricingSummaryPageColourClickPrice;
        [FindsBy(How = How.CssSelector, Using = "#content_0_SummaryTable_RepeaterModels_RepeaterInstallationPacks_0_InstallationPackUnitPrice_0")]
        public IWebElement SpecialPricingSummaryPageInstallationUnitPrice;
        [FindsBy(How = How.CssSelector, Using = "#content_0_SummaryTable_RepeaterModels_RepeaterServicePacks_0_ServicePackUnitPrice_0")]
        public IWebElement SpecialPricingSummaryPageServicePackUnitPrice;
        



        public ProposalSpecialPricingPage NavigateToProposalSpecialPricingPage()
        {
            WaitForElementToExistByCssSelector(".btn.btn-primary.pull-right.js-mps-special-pricing");


            if (SpecialPricingButton == null)
                throw new Exception("Special Pricing Button is not displayed");

            ScrollTo(SpecialPricingButton);
            SpecialPricingButton.Click();

            return GetInstance<ProposalSpecialPricingPage>();
        }


        public void IsAuditSectionDisplayed()
        {
            if (SpecialPricingAuditConfirmationTable == null)
                throw new Exception("audit section is not displayed");

            TestCheck.AssertIsEqual(true, SpecialPricingAuditConfirmationTable.Displayed, "Confirmation page is not displayed");
        }

        private string GetElementText(IWebElement element)
        {
            var text = element.Text;

            return text;
        }

        public void IsNewlyEnteredMonoClickPriceDisplayed()
        {
            var newPrice = GetElementText(SpecialPricingSummaryPageMonoClickPrice);
            var enteredPrice = SpecFlow.GetContext("SpecialPriceMonoClickPrice");

            TestCheck.AssertIsEqual(true, newPrice.Contains(enteredPrice), 
                string.Format("{0} does not contain {1}", newPrice, enteredPrice));
        }

        public void IsNewlyEnteredColourClickPriceDisplayed()
        {
            var newPrice = GetElementText(SpecialPricingSummaryPageColourClickPrice);
            var enteredPrice = SpecFlow.GetContext("SpecialPriceColourClickPrice");

            TestCheck.AssertIsEqual(true, newPrice.Contains(enteredPrice),
                string.Format("{0} does not contain {1}", newPrice, enteredPrice));
        }

        public void IsNewlyEnteredInstallationUnitPriceDisplayed()
        {
            var newPrice = GetElementText(SpecialPricingSummaryPageInstallationUnitPrice);
            var enteredPrice = SpecFlow.GetContext("SpecialPriceInstallation");

            TestCheck.AssertIsEqual(true, newPrice.Contains(enteredPrice),
                string.Format("{0} does not contain {1}", newPrice, enteredPrice));
        }

        public void IsNewlyEnteredServicePackUnitPriceDisplayed()
        {
            var newPrice = GetElementText(SpecialPricingSummaryPageServicePackUnitPrice);
            var enteredPrice = SpecFlow.GetContext("SpecialPriceServicePack");

            TestCheck.AssertIsEqual(true, newPrice.Contains(enteredPrice),
                string.Format("{0} does not contain {1}", newPrice, enteredPrice));
        }

    }
}
