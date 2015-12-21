using System;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow.Assist;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsCreateSummaryPage : BasePage
    {
        public static string URL = "/mps/dealer/proposals/create/summary";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string VolumeFormat = "#content_1_SummaryTable_RepeaterModels_{0}Volume_{1}";
        private const string QuantityFormat = "#content_1_SummaryTable_RepeaterModels_{0}Quantity_{1}";
        private const string MarginFormat = "#content_1_SummaryTable_RepeaterModels_{0}MarginPercentage_{1}";
        private const string ClickRateFormat = "#content_1_SummaryTable_RepeaterModels_{0}ClickRate_{1}";

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
        [FindsBy(How = How.Id, Using = "content_1_ButtonCancel")]
        public IWebElement SummaryCloseProposalElement;
        

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

        public DealerClosedProposalPage CloseProposal()
        {
            ScrollTo(SummaryCloseProposalElement);
            HeadlessDismissAlertOk();
            SummaryCloseProposalElement.Click();
            ClickAcceptOnConfrimation(Driver);
            return GetInstance<DealerClosedProposalPage>(Driver);
        }

        public void ClickAcceptOnConfrimation(IWebDriver driver)
        {
            WebDriver.Wait(DurationType.Millisecond, 3000);
            ClickAcceptOnJsAlert(driver);
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
            TestCheck.AssertIsEqual(!IsAustriaSystem() ? bank : "GRENKELEASING GmbH", DisplayedBankNameElement.Text,
                "Bank displayed in not correct");
        }

        public string GetMonoClickValue()
        {
            string MonoClickRate = null;

            if (MonoClickRateElement.Text.Contains("£"))
            {
                MonoClickRate = MpsUtil.GetValue(MonoClickRateElement.Text).ToString();
            }
            else if (MonoClickRateElement.Text.Contains("€"))
            {
                MonoClickRate = MpsUtil.GetEuroValue(MonoClickRateElement.Text).ToString();
            }

            return MonoClickRate;
        }


        public string GetColourClickValue()
        {
            string ColourClickRate = null;

            if (ColourClickRateElement.Text.Contains("£"))
            {
                ColourClickRate = MpsUtil.GetValue(ColourClickRateElement.Text).ToString();
            }
            else if (ColourClickRateElement.Text.Contains("€"))
            {
                ColourClickRate = MpsUtil.GetEuroValue(ColourClickRateElement.Text).ToString();
            }

            return ColourClickRate;
        }


        public void IsMonoClickPriceDisplayedCorrectly()
        {
            TestCheck.AssertTextContains(GetMonoClickValue(), SpecFlow.GetContext("ClickPriceMonoValue"),
                 "Mono Click Price displayed is different from the calculated on");
        }

        public void IsColourClickPriceDisplayedCorrectly()
        {
            TestCheck.AssertTextContains(GetColourClickValue(), SpecFlow.GetContext("ClickPriceColourValue"),
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
            if (IsUKSystem())
            {
                TestCheck.AssertTextContains(CalculationBasisElement.Text, "Minimum Volume");
            }
            else if (IsGermanSystem()||IsAustriaSystem())
            {
                TestCheck.AssertTextContains(CalculationBasisElement.Text, "vereinbarten Mindestdruckvolumina");
            }
            else if (IsFranceSystem())
            {
                TestCheck.AssertTextContains(CalculationBasisElement.Text, "Coût total par matériel sur la base du volume minimum");
            }
            
        }

        public void VerifyInstallationTypeIsConsistent()
        {
            var storedDisplayedInstallationType = SpecFlow.GetContext("SelectedInstallationType");
            var InstallationType = InstallationTypeNameElement.Text;

            TestCheck.AssertIsEqual(storedDisplayedInstallationType.Trim(),
                InstallationType,
                "Summary Installation Type is different from Selected Installation Type");
        }

        public void VerifyInstallationCostIsConsistent()
        {
            var savedInstallationPrice = SpecFlow.GetContext("SelectedInstallationPrice");
            var summaryInstallationCost = InstallationCostNameElement.Text;

            TestCheck.AssertIsEqual(savedInstallationPrice, summaryInstallationCost,
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
            if (IsUKSystem())
            {
                TestCheck.AssertTextContains(CalculationBasisElement.Text, "Estimated Volume");
            }
            else if (IsGermanSystem() || IsAustriaSystem())
            {
                TestCheck.AssertTextContains(CalculationBasisElement.Text, "geschätzten Druckvolumina");
            } else if (IsFranceSystem())
            {
                TestCheck.AssertTextContains(CalculationBasisElement.Text, "Coût total par matériel sur la base de l'estimation de volume de pages");
            }
            
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

        public void VerifyCustomerOrgName(string orgname)
        {
            TestCheck.AssertIsEqual(CustomerNameElement.Text,
                orgname,
                "CustomerInformation-Organization did not match");
        }

        public void VerifyDescriptionTabInput()
        {
            var proposalName = SpecFlow.GetContext("GeneratedProposalName");
            VerifyProposalName(proposalName);

            var leadCodeRef = SpecFlow.GetContext("GeneratedLeadCodeReference");
            VerifyLeadCodeReference(leadCodeRef);
        }

        public void VerifyCustomerInformationTabInput()
        {
            var orgName = SpecFlow.GetContext("DealerLatestEditedCustomerOrg");
            VerifyCustomerOrgName(orgName);
        }

        public void VerifyTermAndTypeTabInput(string contractType)
        {
            VerifyCorrectContractTypeIsDisplayedOnSummaryPage(contractType);

            var usagetype = SpecFlow.GetContext("DealerLatestEditedUsageType");
            VerifyCorrectUsageTypeIsDisplayedOnSummaryPage(usagetype);

            var contractterm = SpecFlow.GetContext("DealerLatestEditedContractTerm");
            VerifyCorrectContractTermIsDisplayedOnSummaryPage(contractterm);
        }

        private static IWebElement FindItem(IWebDriver driver, string format, string type, int row)
        {
            var selector = string.Format(format, type, row);
            return driver.FindElement(By.CssSelector(selector));
        }


        public void VerifyProductsTabInput(IWebDriver driver)
        {
            var product = SpecFlow.GetObject<DealerProposalsCreateProductsPage.ProductDetail>("DealerRecentEditProduct");

            VerifyProduct(driver, product);
        }

        public void VerifyProductsCount(IWebDriver driver, string action)
        {
            var count = SpecFlow.GetContext("DealerEditProductCount");

            VerifyProductCount(driver, count);
        }

        private void VerifyProductCount(IWebDriver driver, string count)
        {
            var printerselector = @".mps-qa-printer";

            var actual = driver.FindElements(By.CssSelector(printerselector)).Count().ToString();

            TestCheck.AssertIsEqual(count, actual, "Product count does not match");
        }

        private void VerifyProduct(IWebDriver driver, DealerProposalsCreateProductsPage.ProductDetail product)
        {
            var modelselector = string.Format(@".panel.mps-qa-printer.mps-qa-printer-{0}", product.Model.Name);

            var modeldiv = driver.FindElement(By.CssSelector(modelselector));

            var pricetalbleselector = "table.mps-table-model-pricing";

            var pricetable = modeldiv.FindElement(By.CssSelector(pricetalbleselector));

            VerifyPrices(pricetable, product.Model, 1);
            VerifyPrices(pricetable, product.LowerTray, 2);
            VerifyPrices(pricetable, product.Usb2Cable, 3);
            VerifyPrices(pricetable, product.Delivery, 4);
            VerifyPrices(pricetable, product.Brother, 5);
            VerifyPrices(pricetable, product.MpsServicePack, 6);
        }

        private void VerifyPrices(IWebElement pricetable, DealerProposalsCreateProductsPage.ItemDetail itemDetail, int row)
        {
            var rowselector = string.Format(@"tbody>tr:nth-child({0})", row);
            var tr = pricetable.FindElement(By.CssSelector(rowselector));

            var quantity = tr.FindElement(By.CssSelector("td:nth-child(2)")).Text;
            TestCheck.AssertIsEqual(itemDetail.Quantity, quantity, "Quantity did not match.");

            var unitcost = RemoveUnites(tr.FindElement(By.CssSelector("td:nth-child(3)")).Text);
            TestCheck.AssertIsEqual(itemDetail.UnitCost, unitcost, "UnitCost did not match.");

            //var margin = RemoveUnites(tr.FindElement(By.CssSelector("td:nth-child(4)")).Text);
            //TestCheck.AssertIsEqual(itemDetail.Margin, margin, "Margin did not match.");

            var unitprice = RemoveUnites(tr.FindElement(By.CssSelector("td:nth-child(5)")).Text);
            TestCheck.AssertIsEqual(itemDetail.UnitPrice, unitprice, "UnitPrice did not match.");

            //var totalprice = RemoveUnites(tr.FindElement(By.CssSelector("td:nth-child(8)")).Text);
            //TestCheck.AssertIsEqual(itemDetail.TotalPrice, totalprice, "TotalPrice did not match.");
        }

        private string RemoveUnites(string str)
        {
            string[] units = { "£", " %" };

            return units.Aggregate(str, (current, u) => current.Replace(u, ""));
        }

        public void VerifyClickPriceTabInput(IWebDriver driver)
        {
            var count = 1;
            for (var i = 0; i < count; i++)
            {
                foreach (var type in new[] { "Mono", "Colour" })
                {
                    //var volume = FindItem(driver, VolumeFormat, type, i);
                    //var margin = FindItem(driver, MarginFormat, type, i);
                    var clickrate = FindItem(driver, ClickRateFormat, type, i);

                    var context = string.Format("ClickPrice{0}Value#{1}", type, i);
                    var expected = SpecFlow.GetContext(context);

                    TestCheck.AssertIsEqual(expected,
                        clickrate.Text.Replace("£", ""),
                        string.Format("ClickPrice-{0}ClickPrice did not match", type));
                }
            }
        }
    }
}
