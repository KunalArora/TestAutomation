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
        public IWebElement ContractTypeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareBillingBasis")]
        public IList<IWebElement> RepeaterModels_HardwareBillingBasis;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareSku_0")]
        public IWebElement SummaryItemizedPrinterElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareSku")]
        public IList<IWebElement> SummaryItemizedPrintersElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_MonoVolume_0")]
        public IWebElement RepeaterModels_MonoVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ColourVolume_0")]
        public IWebElement SummaryColourClickVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_MonoVolume")]
        public IList<IWebElement> SummaryMonoClickVolumeElements;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ColourVolume")]
        public IList<IWebElement> SummaryColourClickVolumeElements;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSaveProposal")]
        public IWebElement SaveProposalElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareBillingBasis_0")]
        public IWebElement ModelBillingBasisElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareMarginPercentage_0")]
        public IWebElement ModelHardwareMarginElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_DeliveryMarginPercentage_0")]
        public IWebElement ModelDeliveryMarginElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterAccessories_0_AccessoryMarginPercentage_0")]
        public IWebElement ModelAccessoryMarginElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterInstallationPacks_0_InstallationPackMarginPercentage_0")]
        public IWebElement ModelInstallationMarginElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterServicePacks_0_ServicePackMarginPercentage_0")]
        public IWebElement ModelServicePackMarginElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterAccessories_0_AccessoryBillingBasis_0")]
        public IWebElement AccessoryBillingBasisElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterInstallationPacks_0_InstallationPackBillingBasis_0")]
        public IWebElement InstallationBillingBasisElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterServicePacks_0_ServicePackBillingBasis_0")]
        public IWebElement ServicePackBillingBasisElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterInstallationPacks_0_InstallationPackSku_0")]
        public IWebElement InstallationTypeNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterInstallationPacks_0_InstallationPackLinePrice_0")]
        public IWebElement InstallationCostNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareQuantity_0")]
        public IWebElement ModelQuantityNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterServicePacks_0_ServicePackSku_0")]
        public IWebElement ServicePackNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterServicePacks_0_ServicePackLinePrice_0")]
        public IWebElement ServiceCostNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_MonoVolume_0")]
        public IWebElement MonoVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ColourVolume_0")]
        public IWebElement ColourVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_BankName")]
        public IWebElement DisplayedBankNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ConsumablesTotalPriceNet_0")]
        public IWebElement ItemizedConsumableNetTotalElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ConsumablesTotalPriceGross_0")]
        public IWebElement ItemizedConsumableGrossTotalElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalPriceNet")]
        public IWebElement ContractConsumableNetTotalElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalPriceGross")]
        public IWebElement ContractConsumableGrossTotalElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelGrandTotal")]
        public IWebElement CalculationBasisElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_LabelDeviceLeasing_0")]
        public IWebElement IndividualLeasingLabelElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_MonoClickRate_0")]
        public IWebElement MonoClickRateElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ColourClickRate_0")]
        public IWebElement ColourClickRateElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonDownloadProposalPdf")]
        public IWebElement DownloadProposalPdfElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonDownloadProposalPdfWithCalcs")]
        public IWebElement DownloadProposalPdfWithCalcElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ProposalName")]
        public IWebElement ProposalNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LeadCodeReference")]
        public IWebElement LeadCodeReferenceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerName")]
        public IWebElement CustomerNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_UsageType")]
        public IWebElement UsageTypeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_UsageBillingFrequency")]
        public IWebElement UsageBillingFrequencyElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ContractTerm")]
        public IWebElement ContractTermElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LeaseRentalFrequency")]
        public IWebElement LeaseRentalFrequencyElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DealershipName")]
        public IWebElement DealershipNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DealerName")]
        public IWebElement DealerNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DealerTelephone")]
        public IWebElement DealerTelephoneElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DealerEmail")]
        public IWebElement DealerEmailElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerDetailsName")]
        public IWebElement CustomerDetailsName;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerAddress")]
        public IWebElement CustomerAddressName;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerCity")]
        public IWebElement CustomerCityElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerCounty")]
        public IWebElement CustomerCountyNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerPostCode")]
        public IWebElement CustomerPostCodeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerCountry")]
        public IWebElement CustomerCountryElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerContact")]
        public IWebElement CustomerContactElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerTelephone")]
        public IWebElement CustomerTelephoneElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerEmail")]
        public IWebElement CustomerEmailElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerTradingStyle")]
        public IWebElement CustomerTradingStyleElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerPaymentType")]
        public IWebElement CustomerPaymentTypeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerCompanyRegistration")]
        public IWebElement CustomerCompanyRegistrationElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerBankName")]
        public IWebElement CustomerBankNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerBankAccount")]
        public IWebElement CustomerBankAccountElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerIban")]
        public IWebElement CustomerIbanElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerBic")]
        public IWebElement CustomerBICElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerSortCode")]
        public IWebElement CustomerSortCodeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerAuthorisedSignatory")]
        public IWebElement CustomerAuthorisedSignatoryElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerVatNumber")]
        public IWebElement CustomerVatNumberElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_DeviceTotalPriceNet_0")]
        public IWebElement RepeaterModels_DeviceTotalPriceNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_DeviceTotalPriceGross_0")]
        public IWebElement RepeaterModels_DeviceTotalPriceGrossElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_DeviceLeasingTotalNet_0")]
        public IWebElement RepeaterModels_DeviceLeasingTotalNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_DeviceLeasingTotalGross_0")]
        public IWebElement RepeaterModels_DeviceLeasingTotalGrossElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ConsumablesTotalPriceNet_0")]
        public IWebElement RepeaterModels_ConsumablesTotalPriceNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ConsumablesTotalPriceGross_0")]
        public IWebElement RepeaterModels_ConsumablesTotalPriceGrossElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeviceTotalsTotalCostNet")]
        public IWebElement DeviceTotalsTotalCostNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeviceTotalsTotalMarginNet")]
        public IWebElement DeviceTotalsTotalMarginNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalMarginNet")]
        public IWebElement ConsumableTotalsTotalMarginNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalPriceNet")]
        public IWebElement ConsumableTotalsTotalPriceNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalMarginGross")]
        public IWebElement ConsumableTotalsTotalMarginGrossElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalPriceGross")]
        public IWebElement ConsumableTotalsTotalPriceGrossElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_GrandTotalMarginNet")]
        public IWebElement GrandTotalMarginNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_GrandTotalPriceNet")]
        public IWebElement GrandTotalPriceNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_BankName")]
        public IWebElement BankNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_TermLength")]
        public IWebElement TermLengthElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_PaymentFrequency")]
        public IWebElement PaymentFrequencyElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_PaymentQuantity")]
        public IWebElement PaymentQuantityElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_PaymentAmountNet")]
        public IWebElement PaymentAmountNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_PaymentAmountGross")]
        public IWebElement PaymentAmountGrossElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepaymentTotalNet")]
        public IWebElement RepaymentTotalNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepaymentTotalGross")]
        public IWebElement RepaymentTotalGrossElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_HardwareAccessoryPrice")]
        public IWebElement HardwareAccessoryPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeliveryInstallationPrice")]
        public IWebElement DeliveryInstallationPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_FinanceCharge")]
        public IWebElement FinanceChargeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_FinanceTotalNet")]
        public IWebElement FinanceTotalNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_FinanceTotalGross")]
        public IWebElement FinanceTotalGrossElement;

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
                RepeaterModels_MonoVolumeElement.Text.Equals(contractType), 
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
                ContractTypeElement.Text.Equals(contractType), 
                "Contract Type does not match");
        }

        private void VerifyCorrectContractTermIsDisplayedOnSummaryPage(string contractTerm)
        {
            TestCheck.AssertIsEqual(true, 
                ContractTermElement.Text.Equals(contractTerm), 
                "Contract Term does not match");
        }

        private void VerifyCorrectUsageTypeIsDisplayedOnSummaryPage(string contractTerm)
        {
            TestCheck.AssertIsEqual(true, 
                UsageTypeElement.Text.Equals(contractTerm), 
                "Usage Type does not match");
        }

        private void VerifyCorrectLeasingFrequencyIsDisplayedOnSummaryPage(string contractTerm)
        {
            TestCheck.AssertIsEqual(true, 
                LeaseRentalFrequencyElement.Text.Equals(contractTerm), 
                "Lease Frequency does not match");
        }

        private void VerifyCorrectBillingTermIsDisplayedOnSummaryPage(string contractTerm)
        {
            TestCheck.AssertIsEqual(true, 
                UsageBillingFrequencyElement.Text.Equals(contractTerm), 
                "Usage Billing Frequency does not match");
        }

        public CloudExistingProposalPage SaveProposal()
        {
            WebDriver.Wait(Helper.DurationType.Second, 3);
            ScrollTo(SaveProposalElement);
            //SaveProposalElement.Click();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, SaveProposalElement);
            return GetTabInstance<CloudExistingProposalPage>(Driver);
        }

        public void VerifySelectedDeviceIsDisplayed(string model)
        {
            string elementname = ".mps-qa-printer";
            if (IsElementPresent(GetElementByCssSelector(elementname,5)))
            {
                string element = "{0}-{1}";
                elementname = string.Format(element, elementname, model);
                AssertElementPresent(GetElementByCssSelector(elementname, 5), "model is not displayed");
            }
        }

        private void VerifyEnteredHardwareMarginIsDisplayed()
        {
            var before = Convert.ToDecimal(SpecFlow.GetContext("EnteredProductMargin"));
            var after = Convert.ToDecimal(ModelHardwareMarginElement.Text.Trim(" %".ToCharArray()));
            TestCheck.AssertIsEqual(before, after, "Product Margin invalid");
        }

        private void VerifyEnteredDeliveryMarginIsDisplayed()
        {
            var before = Convert.ToDecimal(SpecFlow.GetContext("EnteredDeliveryMargin"));
            var after = Convert.ToDecimal(ModelDeliveryMarginElement.Text.Trim(" %".ToCharArray()));
            TestCheck.AssertIsEqual(before, after, "Delivery Margin invalid");
        }

        private void VerifyEnteredInstallationPackMarginIsDisplayed()
        {
            var before = Convert.ToDecimal(SpecFlow.GetContext("EnteredInstallationPackMargin"));
            var after = Convert.ToDecimal(ModelInstallationMarginElement.Text.Trim(" %".ToCharArray()));
            TestCheck.AssertIsEqual(before, after, "InstallationPack Margin invalid");
        }

        private void VerifyEnteredServicePackMarginIsDisplayed()
        {
            var before = Convert.ToDecimal(SpecFlow.GetContext("EnteredServicePackMargin"));
            var after = Convert.ToDecimal(ModelServicePackMarginElement.Text.Trim(" %".ToCharArray()));
            TestCheck.AssertIsEqual(before, after, "ServicePack Margin invalid");
        }

        private void VerifyEnteredOptionMargin0IsDisplayed()
        {
            var before = Convert.ToDecimal(SpecFlow.GetContext("EnteredOptionMargin0"));
            var after = Convert.ToDecimal(ModelAccessoryMarginElement.Text.Trim(" %".ToCharArray()));
            foreach (KeyValuePair<string, object> item in SpecFlow.GetEnumerator())
            {
                if (item.Key.Equals("EnteredOptionMargin0"))
                    TestCheck.AssertIsEqual(before, after, "OptionMargin invalid");
            }
        }

        public void VerifyEnteredMarginsAreDisplayed()
        {
            VerifyEnteredHardwareMarginIsDisplayed();
            VerifyEnteredDeliveryMarginIsDisplayed();
            VerifyEnteredInstallationPackMarginIsDisplayed();
            VerifyEnteredServicePackMarginIsDisplayed();
            VerifyEnteredOptionMargin0IsDisplayed();
        }

        public void StoreProposalSummaryData()
        {
            if (IsElementPresent(CustomerCompanyRegistrationElement))
                SpecFlow.SetContext("DealerProposalSummaryCustomerCompanyRegistrationElement", CustomerCompanyRegistrationElement.Text);
            if (IsElementPresent(CustomerBankNameElement))
                SpecFlow.SetContext("DealerProposalSummaryCustomerBankNameElement", CustomerBankNameElement.Text);
            if (IsElementPresent(CustomerBankAccountElement))
                SpecFlow.SetContext("DealerProposalSummaryCustomerBankAccountElement", CustomerBankAccountElement.Text);
            if (IsElementPresent(CustomerIbanElement))
                SpecFlow.SetContext("DealerProposalSummaryCustomerIbanElement", CustomerIbanElement.Text);
            if (IsElementPresent(CustomerBICElement))
                SpecFlow.SetContext("DealerProposalSummaryCustomerBICElement", CustomerBICElement.Text);
            if (IsElementPresent(CustomerSortCodeElement))
                SpecFlow.SetContext("DealerProposalSummaryCustomerSortCodeElement", CustomerSortCodeElement.Text);
            if (IsElementPresent(CustomerAuthorisedSignatoryElement))
                SpecFlow.SetContext("DealerProposalSummaryCustomerAuthorisedSignatoryElement", CustomerAuthorisedSignatoryElement.Text);
            if (IsElementPresent(CustomerVatNumberElement))
                SpecFlow.SetContext("DealerProposalSummaryCustomerVatNumberElement", CustomerVatNumberElement.Text);
            if (IsElementPresent(RepeaterModels_DeviceTotalPriceNetElement))
                SpecFlow.SetContext("DealerProposalSummaryRepeaterModels_DeviceTotalPriceNetElement", RepeaterModels_DeviceTotalPriceNetElement.Text);
            if (IsElementPresent(RepeaterModels_DeviceTotalPriceGrossElement))
                SpecFlow.SetContext("DealerProposalSummaryRepeaterModels_DeviceTotalPriceGrossElement", RepeaterModels_DeviceTotalPriceGrossElement.Text);
//            if (IsElementPresent(RepeaterModels_DeviceLeasingTotalNetElement))
//                SpecFlow.SetContext("DealerProposalSummaryDeviceRepeaterModels_DeviceLeasingTotalNetElement", RepeaterModels_DeviceLeasingTotalNetElement.Text);
//            if (IsElementPresent(RepeaterModels_DeviceLeasingTotalGrossElement))
//                SpecFlow.SetContext("DealerProposalSummaryRepeaterModels_DeviceLeasingTotalGrossElement", RepeaterModels_DeviceLeasingTotalGrossElement.Text);
            if (IsElementPresent(RepeaterModels_ConsumablesTotalPriceNetElement))
                SpecFlow.SetContext("DealerProposalSummaryRepeaterModels_ConsumablesTotalPriceNetElement", RepeaterModels_ConsumablesTotalPriceNetElement.Text);
            if (IsElementPresent(RepeaterModels_ConsumablesTotalPriceGrossElement))
                SpecFlow.SetContext("DealerProposalSummaryRepeaterModels_ConsumablesTotalPriceGrossElement", RepeaterModels_ConsumablesTotalPriceGrossElement.Text);
            if (IsElementPresent(DeviceTotalsTotalCostNetElement))
                SpecFlow.SetContext("DealerProposalSummaryDeviceTotalsTotalCostNetElement", DeviceTotalsTotalCostNetElement.Text);
            if (IsElementPresent(DeviceTotalsTotalMarginNetElement))
                SpecFlow.SetContext("DealerProposalSummaryDeviceTotalsTotalMarginNetElement", DeviceTotalsTotalMarginNetElement.Text);
            if (IsElementPresent(ConsumableTotalsTotalMarginNetElement))
                SpecFlow.SetContext("DealerProposalSummaryConsumableTotalsTotalMarginNetElement", ConsumableTotalsTotalMarginNetElement.Text);
            if (IsElementPresent(ConsumableTotalsTotalPriceNetElement))
                SpecFlow.SetContext("DealerProposalSummaryConsumableTotalsTotalPriceNetElement", ConsumableTotalsTotalPriceNetElement.Text);
            if (IsElementPresent(ConsumableTotalsTotalMarginGrossElement))
                SpecFlow.SetContext("DealerProposalSummaryConsumableTotalsTotalMarginGrossElement", ConsumableTotalsTotalMarginGrossElement.Text);
            if (IsElementPresent(ConsumableTotalsTotalPriceGrossElement))
                SpecFlow.SetContext("DealerProposalSummaryConsumableTotalsTotalPriceGrossElement", ConsumableTotalsTotalPriceGrossElement.Text);
            if (IsElementPresent(GrandTotalMarginNetElement))
                SpecFlow.SetContext("DealerProposalSummaryGrandTotalMarginNetElement", GrandTotalMarginNetElement.Text);
            if (IsElementPresent(GrandTotalPriceNetElement))
                SpecFlow.SetContext("DealerProposalSummaryGrandTotalPriceNetElement", GrandTotalPriceNetElement.Text);
 //           if (IsElementPresent(BankNameElement))
 //               SpecFlow.SetContext("DealerProposalSummaryBankNameElement", BankNameElement.Text);
 //           if (IsElementPresent(TermLengthElement))
 //               SpecFlow.SetContext("DealerProposalSummaryTermLengthElement", TermLengthElement.Text);
 //           if (IsElementPresent(PaymentFrequencyElement))
 //               SpecFlow.SetContext("DealerProposalSummaryPaymentFrequencyElement", PaymentFrequencyElement.Text);
 //           if (IsElementPresent(PaymentQuantityElement))
 //               SpecFlow.SetContext("DealerProposalSummaryPaymentQuantityElement", PaymentQuantityElement.Text);
 //           if (IsElementPresent(PaymentAmountNetElement))
 //               SpecFlow.SetContext("DealerProposalSummaryPaymentAmountNetElement", PaymentAmountNetElement.Text);
 //           if (IsElementPresent(PaymentAmountGrossElement))
 //               SpecFlow.SetContext("DealerProposalSummaryPaymentAmountGrossElement", PaymentAmountGrossElement.Text);
 //           if (IsElementPresent(RepaymentTotalGrossElement))
 //               SpecFlow.SetContext("DealerProposalSummaryRepaymentTotalGrossElement", RepaymentTotalGrossElement.Text);
 //           if (IsElementPresent(HardwareAccessoryPriceElement))
 //               SpecFlow.SetContext("DealerProposalSummaryHardwareAccessoryPriceElement", HardwareAccessoryPriceElement.Text);
 //           if (IsElementPresent(DeliveryInstallationPriceElement))
 //               SpecFlow.SetContext("DealerProposalSummaryDeliveryInstallationPriceElement", DeliveryInstallationPriceElement.Text);
 //           if (IsElementPresent(FinanceChargeElement))
 //               SpecFlow.SetContext("DealerProposalSummaryFinanceChargeElement", FinanceChargeElement.Text);
 //           if (IsElementPresent(FinanceTotalNetElement))
 //               SpecFlow.SetContext("DealerProposalSummaryFinanceTotalNetElement", FinanceTotalNetElement.Text);
 //           if (IsElementPresent(FinanceTotalGrossElement))
 //               SpecFlow.SetContext("DealerProposalSummaryFinanceGrossElement", FinanceTotalGrossElement.Text);
        }

        public void VerifyProposalName(string proposalName)
        {
            TestCheck.AssertIsEqual(ProposalNameElement.Text,
                proposalName,
                "Description-ProposalName did not match");
        }

        public void VerifyLeadCodeReference(string leadCodeRef)
        {
            TestCheck.AssertIsEqual(LeadCodeReferenceElement.Text,
                leadCodeRef,
                "Description-LeadCodeReference did not match");
        }

        public void VerifyDescriptionTabInput()
        {
            var proposalName = SpecFlow.GetContext("GeneratedProposalName");
            VerifyProposalName(proposalName);

            var leadCodeRef = SpecFlow.GetContext("GeneratedLeadCodeReference");
            VerifyLeadCodeReference(leadCodeRef);
        }
    }
}
