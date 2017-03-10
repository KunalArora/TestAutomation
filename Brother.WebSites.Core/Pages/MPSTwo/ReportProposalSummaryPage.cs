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

        private const string Install = @"#content_0_SummaryTable_RepeaterModels_RepeaterInstallationPacks_{0}_InstallationPackUnitPrice_0";

        private const string ServicePack =
            @"#content_0_SummaryTable_RepeaterModels_RepeaterServicePacks_{0}_ServicePackUnitPrice_0";

        private const string MonoClickRate =
            @"#content_0_SummaryTable_RepeaterModels_MonoClickRate_{0}";

        private const string ColourClickRate =
            @"#content_0_SummaryTable_RepeaterModels_ColourClickRate_{0}";
        

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
        [FindsBy(How = How.CssSelector, Using = "#content_0_ButtonChangeCustomerAddress")]
        public IWebElement LocalApproverChangeCustomerAddressButton;
        [FindsBy(How = How.CssSelector, Using = "#content_0_SummaryTable_CustomerAddress")]
        public IWebElement SummaryCustomerStreet;
        [FindsBy(How = How.CssSelector, Using = "#content_0_SummaryTable_CustomerContact")]
        public IWebElement SummaryCustomerName;





        public void IsCustomerContactNameEdited()
        {
            if(SummaryCustomerName == null)
                throw new Exception("customer street name is not displayed");
            var street = SummaryCustomerName.Text;

            TestCheck.AssertIsEqual(true, street.Contains("Edited"), 
                                         string.Format("actual text {0} does not contain Edited", street));
        }

        public void IsCustomerCustomerCityEdited()
        {
            if (SummaryCustomerStreet == null)
                throw new Exception("customer street name is not displayed");
            var name = SummaryCustomerStreet.Text;

            TestCheck.AssertIsEqual(true, name.Contains("Edited"),
                                         string.Format("actual text {0} does not contain Edited", name));
        }


        private IWebElement ElementToVerify(string element, string pos)
        {
            var fullformed = string.Format(element, pos);

            return Driver.FindElement(By.CssSelector(fullformed));
        }

        public ProposalSpecialPricingPage NavigateToProposalSpecialPricingPage()
        {
            WaitForElementToExistByCssSelector(".btn.btn-primary.pull-right.js-mps-special-pricing");


            if (SpecialPricingButton == null)
                throw new Exception("Special Pricing Button is not displayed");

            ScrollTo(SpecialPricingButton);
            SpecialPricingButton.Click();

            return GetInstance<ProposalSpecialPricingPage>();
        }


        public LocalOfficeApprovalCustomerInformationPage NavigateToLocalOfficeCustomerInformationPage()
        {
            WaitForElementToExistByCssSelector(".btn.btn-primary.pull-right.js-mps-special-pricing");


            if (LocalApproverChangeCustomerAddressButton == null)
                throw new Exception("Special Pricing Button is not displayed");

            ScrollDownOnAPage(Driver);

            ScrollTo(LocalApproverChangeCustomerAddressButton);
            LocalApproverChangeCustomerAddressButton.Click();

            return GetInstance<LocalOfficeApprovalCustomerInformationPage>();
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

        public void IsNewlyEnteredMonoClickPriceDisplayed(string pos)
        {
            var newPrice = GetElementText(ElementToVerify(MonoClickRate, pos));

            var saved = string.Format("SpecialPriceMonoClickPrice{0}", pos);

            var enteredPrice = SpecFlow.GetContext(saved);

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

        public void IsNewlyEnteredColourClickPriceDisplayed(string pos)
        {
            var newPrice = GetElementText(ElementToVerify(ColourClickRate, pos));

            var saved = string.Format("SpecialPriceColourClickPrice{0}", pos);

            var enteredPrice = SpecFlow.GetContext(saved);

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

        public void IsNewlyEnteredInstallationUnitPriceDisplayed(string pos)
        {
            var newPrice = GetElementText(ElementToVerify(Install, pos));

            var saved = string.Format("SpecialPriceInstallation{0}", pos);

            var enteredPrice = SpecFlow.GetContext(saved);

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

        public void IsNewlyEnteredServicePackUnitPriceDisplayed(string pos)
        {
            var newPrice = GetElementText(ElementToVerify(ServicePack, pos));

            var saved = string.Format("SpecialPriceServicePack{0}", pos);

            var enteredPrice = SpecFlow.GetContext(saved);

            TestCheck.AssertIsEqual(true, newPrice.Contains(enteredPrice),
                string.Format("{0} does not contain {1}", newPrice, enteredPrice));
        }

    }
}
