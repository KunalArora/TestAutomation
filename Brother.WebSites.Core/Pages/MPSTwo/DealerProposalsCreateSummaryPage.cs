using System;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsCreateSummaryPage : BasePage
    {
        public static string URL = "/mps/dealer/proposals/create/summary";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ContractType")]
        private IWebElement SummaryContractTypeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ContractTerm")]
        private IWebElement SummaryContractTermElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_UsageType")]
        private IWebElement SummaryUsageTermElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_UsageBillingFrequency")]
        private IWebElement SummaryUsageBillingFrequencyElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LeaseRentalFrequency")]
        private IWebElement SummaryLeaseRentalFrequencyElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareBillingBasis")]
        private IList<IWebElement> SummaryBillingBasisElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareSku_0")]
        private IWebElement SummaryItemizedPrinterElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareSku")]
        private IList<IWebElement> SummaryItemizedPrintersElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_MonoVolume_0")]
        private IWebElement SummaryMonoClickVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ColourVolume_0")]
        private IWebElement SummaryColourClickVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_MonoVolume")]
        private IList<IWebElement> SummaryMonoClickVolumeElements;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ColourVolume")]
        private IList<IWebElement> SummaryColourClickVolumeElements;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSaveProposal")]
        private IWebElement SaveProposalElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareBillingBasis_0")]
        private IWebElement ModelBillingBasisElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterAccessories_0_AccessoryBillingBasis_0")]
        private IWebElement AccessoryBillingBasisElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterInstallationPacks_0_InstallationPackBillingBasis_0")]
        private IWebElement InstallationBillingBasisElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterServicePacks_0_ServicePackBillingBasis_0")]
        private IWebElement ServicePackBillingBasisElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterInstallationPacks_0_InstallationPackSku_0")]
        private IWebElement InstallationTypeNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterInstallationPacks_0_InstallationPackLinePrice_0")]
        private IWebElement InstallationCostNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareQuantity_0")]
        private IWebElement ModelQuantityNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterServicePacks_0_ServicePackSku_0")]
        private IWebElement ServicePackNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterServicePacks_0_ServicePackLinePrice_0")]
        private IWebElement ServiceCostNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_MonoVolume_0")]
        private IWebElement MonoVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ColourVolume_0")]
        private IWebElement ColourVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_BankName")]
        private IWebElement DisplayedBankNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ConsumablesTotalPriceNet_0")]
        private IWebElement ItemizedConsumableNetTotalElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ConsumablesTotalPriceGross_0")]
        private IWebElement ItemizedConsumableGrossTotalElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalPriceNet")]
        private IWebElement ContractConsumableNetTotalElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalPriceGross")]
        private IWebElement ContractConsumableGrossTotalElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelGrandTotal")]
        private IWebElement CalculationBasisElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_LabelDeviceLeasing_0")]
        private IWebElement IndividualLeasingLabelElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_MonoClickRate_0")]
        private IWebElement MonoClickRateElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ColourClickRate_0")]
        private IWebElement ColourClickRateElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonDownloadProposalPdf")]
        public IWebElement DownloadProposalPdfElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonDownloadProposalPdfWithCalcs")]
        private IWebElement DownloadProposalPdfWithCalcElement;







        public void DownloadDealersProposalDocument()
        {
            DownloadProposalPdfWithCalcElement.Click();
        }

        public void DownloadCustomersProposalDocument()
        {
            DownloadProposalPdfElement.Click();
        }

        private string PrinterString(string printer)
        {
            return String.Format(".mps-qa-printer-{0} .panel-heading a", printer);
        }

        private IWebElement DisplayedPrinterLink(string printer)
        {
            return GetElementByCssSelector(PrinterString(printer));
        }

        public DealerProposalsCreateProductsPage ClickOnDisplayedPrinterLink(string printer)
        {
            DisplayedPrinterLink(printer).Click();
            return GetTabInstance<DealerProposalsCreateProductsPage>(Driver);
        }

        public void VerifyThatCorrectModelBillingBasisIsDisplayed(string basis)
        {
            TestCheck.AssertIsEqual(basis, 
                ModelBillingBasisElement.Text, 
                "Model Billing Basis is not matching");
        }

        public void VerifyThatCorrectAccessoryBillingBasisIsDisplayed(string basis)
        {
            TestCheck.AssertIsEqual(basis, 
                AccessoryBillingBasisElement.Text, 
                "Accessory Billing Basis is not matching");
        }

        public void VerifyThatCorrectInstallationBillingBasisIsDisplayed(string basis)
        {
            TestCheck.AssertIsEqual(basis, 
                InstallationBillingBasisElement.Text, 
                "Installation Billing Basis is not matching");
        }

        public void VerifyThatCorrectServicePackBillingBasisIsDisplayed(string basis)
        {
            TestCheck.AssertIsEqual(basis, 
                ServicePackBillingBasisElement.Text, 
                "Service Pack Billing Basis is not matching");
        }

        public void VerifyThatNetTotalsAreMatching()
        {
            TestCheck.AssertIsEqual(ItemizedConsumableNetTotalElement.Text, 
                ContractConsumableNetTotalElement.Text, 
                "Consumable Net Totals did not match");
        }

        public void VerifyThatGrossTotalsAreMatching()
        {
            TestCheck.AssertIsEqual(ItemizedConsumableGrossTotalElement.Text, 
                ContractConsumableGrossTotalElement.Text, 
                "Consumable Net Totals did not match");
        }

        public void VerifyCorrectMonoVolumeIsDisplayed(string mono)
        {
            TestCheck.AssertIsEqual(MonoVolumeElement.Text, mono, 
                "Correct Mono volume is not displayed");
        }

        public void VerifyCorrectColourVolumeIsDisplayed(string colour)
        {
            TestCheck.AssertIsEqual(ColourVolumeElement.Text, colour,
                "Correct Colour volume is not displayed");
        }

        public void VerifyThatCorrectBankIsDisplayed(string bank)
        {
            TestCheck.AssertIsEqual(bank, DisplayedBankNameElement.Text, 
                "Bank displayed in not correct");
        }

        public void IsMonoClickPriceDisplayedCorrectly()
        {
            TestCheck.AssertIsEqual(SpecFlow.GetContext("ClickPriceMonoValue"),
                MpsUtil.GetValue(MonoClickRateElement.Text).ToString(), 
                "Mono Click Price displayed is different from the calculated on");
        }

        public void IsColourClickPriceDisplayedCorrectly()
        {
            TestCheck.AssertIsEqual(SpecFlow.GetContext("ClickPriceColourValue"),
                MpsUtil.GetValue(ColourClickRateElement.Text).ToString(),
                "Colour Click Price displayed is different from the calculated on");
        }

        public void VerifyLeasingPanelDiplsayed()
        {
            TestCheck.AssertIsEqual(true, 
                IndividualLeasingLabelElement.Displayed, 
                "No leasing label is displayed");
        }

        public void VerifyThatCalculationsAreNotBasedOnEstimates()
        {
            TestCheck.AssertTextContains(CalculationBasisElement.Text, "Minimum Volume");
        }

        public void VerifyInstallationTypeIsConsistent()
        {

            TestCheck.AssertIsEqual(SpecFlow.GetContext("SelectedInstallationType"), 
                InstallationTypeNameElement.Text,
                "Summary Installation Type is different from Selected Installation Type");
        }

        public void VerifyInstallationCostIsConsistent()
        {

            TestCheck.AssertIsEqual(SpecFlow.GetContext("SelectedInstallationPrice"),
                InstallationCostNameElement.Text,
                "Summary Installation Cost is different from Selected Installation Cost");
        }

        public void VerifyServicePackNameIsConsistent()
        {
            TestCheck.AssertIsEqual(SpecFlow.GetContext("ServicePackName"), 
                ServicePackNameElement.Text, "Service Pack names are not the same");
        }

        public void VerifyServicePackCostIsConssistent()
        {
            TestCheck.AssertIsEqual(SpecFlow.GetContext("SelectedServicePackPrice"), 
                ServiceCostNameElement.Text, 
                "Service Pack cost are the same");
        }

        public void VerifyProductQuantityIsConsistent()
        {
            TestCheck.AssertIsEqual(SpecFlow.GetContext("ProductQuantity"),
                ModelQuantityNameElement.Text, 
                "Quantity on Product Page is different from Quantity on Summary Page");
        }


        public void VerifyThatCalculationsAreBasedOnEstimates()
        {
            TestCheck.AssertTextContains(CalculationBasisElement.Text, "Estimated Volume");
        }

        public void VerifyCreatedProposalSummaryPageElements(string summaryElement, string value)
        {
            switch (summaryElement)
            {
                case "Contract Type":
                    VerifyCorrectContractTypeIsDisplayedOnSummaryPage(value);
                    break;
                case "Contract Term":
                    VerifyCorrectContractTermIsDisplayedOnSummaryPage(value);
                    break;
                case "Usage Type":
                    VerifyCorrectUsageTypeIsDisplayedOnSummaryPage(value);
                    break;
                case "Leasing Frequency":
                    VerifyCorrectLeasingFrequencyIsDisplayedOnSummaryPage(value);
                    break;
                case "Billing Term":
                    VerifyCorrectBillingTermIsDisplayedOnSummaryPage(value);
                    break;
                case "Displayed Printer":
                    VerifyCorrectDisplayedPrinterIsDisplayedOnSummaryPage(value);
                    break;
                case "Mono Volume":
                    VerifyCorrectMonoVolumeIsDisplayedOnSummaryPage(value);
                    break;
                case "Colour Volume":
                    VerifyCorrectColourVolumeIsDisplayedOnSummaryPage(value);
                    break;
            }
        }



        private void VerifyCorrectMonoVolumeIsDisplayedOnSummaryPage(string contractType)
        {
            TestCheck.AssertIsEqual(true, 
                SummaryMonoClickVolumeElement.Text.Equals(contractType), 
                "Printer Displayed on Summary page does not match");
        }

        private void VerifyCorrectColourVolumeIsDisplayedOnSummaryPage(string contractType)
        {
            TestCheck.AssertIsEqual(true, 
                SummaryColourClickVolumeElement.Text.Equals(contractType), 
                "Printer Displayed on Summary page does not match");
        }

        private void VerifyCorrectDisplayedPrinterIsDisplayedOnSummaryPage(string contractType)
        {
            TestCheck.AssertIsEqual(true, 
                SummaryItemizedPrinterElement.Text.Equals(contractType), 
                "Printer Displayed on Summary page does not match");
        }

        private void VerifyCorrectContractTypeIsDisplayedOnSummaryPage(string contractType)
        {
            TestCheck.AssertIsEqual(true, 
                SummaryContractTypeElement.Text.Equals(contractType), 
                "Contract Type does not match");
        }

        private void VerifyCorrectContractTermIsDisplayedOnSummaryPage(string contractTerm)
        {
            TestCheck.AssertIsEqual(true, 
                SummaryContractTermElement.Text.Equals(contractTerm), 
                "Contract Term does not match");
        }

        private void VerifyCorrectUsageTypeIsDisplayedOnSummaryPage(string contractTerm)
        {
            TestCheck.AssertIsEqual(true, 
                SummaryUsageTermElement.Text.Equals(contractTerm), 
                "Usage Type does not match");
        }

        private void VerifyCorrectLeasingFrequencyIsDisplayedOnSummaryPage(string contractTerm)
        {
            TestCheck.AssertIsEqual(true, 
                SummaryLeaseRentalFrequencyElement.Text.Equals(contractTerm), 
                "Lease Frequency does not match");
        }

        private void VerifyCorrectBillingTermIsDisplayedOnSummaryPage(string contractTerm)
        {
            TestCheck.AssertIsEqual(true, 
                SummaryUsageBillingFrequencyElement.Text.Equals(contractTerm), 
                "Usage Billing Frequency does not match");
        }

        public CloudExistingProposalPage SaveProposal()
        {
            WebDriver.Wait(Helper.DurationType.Second, 3);
            ScrollTo(SaveProposalElement);
            SaveProposalElement.Click();
            return GetTabInstance<CloudExistingProposalPage>(Driver);
        }
    }
}
