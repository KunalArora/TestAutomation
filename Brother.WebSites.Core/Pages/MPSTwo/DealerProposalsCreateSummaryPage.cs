﻿using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsCreateSummaryPage : BasePage, IPageObject
    {
        public static string URL = "/mps/dealer/proposals/create/summary";
        private const string _validationElementSelector = "#content_1_ButtonSaveProposal";
        private const string _url = "/mps/dealer/proposals/create/summary";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string VolumeFormat = "#content_1_SummaryTable_RepeaterModels_{0}Volume_{1}";
        private const string QuantityFormat = "#content_1_SummaryTable_RepeaterModels_{0}Quantity_{1}";
        private const string MarginFormat = "#content_1_SummaryTable_RepeaterModels_{0}MarginPercentage_{1}";
        private const string ClickRateFormat = "#content_1_SummaryTable_RepeaterModels_{0}ClickRate_{1}";
        private const string DownloadPath = @"file:///C:/DataTest/";
        private const string UkText = @"Total Quarterly In Arrears";
        private const string DeText = @"Brother EasyPrint Pro";
        private const string AtText = @"Bedingung";
        private const string ItText = @"Pagine + Cloud";
        private const string FrText = @"COUT D’ACQUISITION";
        private const string SpText = @"Propuesta";
        private const string DownloadDirectory = @"C:/DataTest";
        private const string ClickPricePath = @"C:\DataTest\ClickPrice";
        private const string CsvFile = @"ClickPrice.csv";

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
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterInstallationPacks_0_InstallationPackUnitPrice_0")]
        public IWebElement InstallationUnitPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareQuantity_0")]
        public IWebElement ModelQuantityNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterServicePacks_0_ServicePackSku_0")]
        public IWebElement ServicePackNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterServicePacks_0_ServicePackLinePrice_0")]
        public IWebElement ServiceCostNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterServicePacks_0_ServicePackUnitPrice_0")]
        public IWebElement ServicePackUnitPriceElement;
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
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_GrandTotalPriceGross")]
        public IWebElement GrandTotalPriceGrossElement;
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
        [FindsBy(How = How.CssSelector, Using = "#content_1_SummaryTable_ProposalDetailsContainer")]
        public IWebElement SummaryPageContractIdElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonDownloadProposalPdf")]
        public IWebElement SummaryPageDownloadElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_DeviceTotalPriceNet_0")]
        public IWebElement SummaryCustomerDeviceTotalNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerName")]
        public IWebElement SummaryCustomerOrCompanyNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ContractTerm")]
        public IWebElement SummaryContractTermElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ContractType")]
        public IWebElement SummaryContractTypeElement;
        
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ConsumablesTotalPriceNet_0")]
        public IWebElement SummaryProposalConsumableTotalNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_DeviceTotalPriceGross_0")]
        public IWebElement SummaryCustomerDeviceTotalGrossElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareUnitCost_0")]
        public IWebElement SummaryModelUnitCostElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareMarginPercentage_0")]
        public IWebElement SummaryMarginElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareUnitPrice_0")]
        public IWebElement SummaryUnitPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareLineCost_0")]
        public IWebElement SummaryTotalCostElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_HardwareLinePrice_0")]
        public IWebElement SummaryTotalPriceElement;

        //Accessories
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterAccessories_0_AccessoryUnitCost_0")]
        public IWebElement SummaryAccessoryUnitCostElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterAccessories_0_AccessoryMarginPercentage_0")]
        public IWebElement SummaryAccessoryMarginElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterAccessories_0_AccessoryUnitPrice_0")]
        public IWebElement SummaryAccessoryUnitPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterAccessories_0_AccessoryLineCost_0")]
        public IWebElement SummaryAccessoryTotalCostElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterAccessories_0_AccessoryLinePrice_0")]
        public IWebElement SummaryAccessoryTotalPriceElement;

        //Delivery
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_DeliveryLinePrice_0")]
        public IWebElement SummaryDeliveryTotalPriceElement;
        
        //Installation
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterInstallationPacks_0_InstallationPackLinePrice_0")]
        public IWebElement SummaryInstallationTotalPriceElement;
        
        //Service Pack
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterServicePacks_0_ServicePackLinePrice_0")]
        public IWebElement SummaryServicePackTotalPriceElement;
        
        //Device Total
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_DeviceTotalPriceNet_0")]
        public IWebElement SummaryDeviceTotalPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeviceTotalsTotalPriceNet")]
        public IWebElement SummaryGrandDeviceTotalPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalPriceNet")]
        public IWebElement SummaryGrandConsumableTotalPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_GrandTotalPriceNet")]
        public IWebElement SummaryContractGrandTotalPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ChargesTotalPriceNet")]
        public IWebElement SummaryGrandChargesTotalPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeviceTotalsTotalPriceGross")]
        public IWebElement SummaryContractGrandTotalPriceGrossElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_InClickTotalLinePrice")]
        public IWebElement SummaryContractGrandTotalInClickLineElement;
        
        
        
        //Volume
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_MonoVolume_0")]
        public IWebElement SummaryMonthlyMonoVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_MonoLineVolume_0")]
        public IWebElement SummaryLineMonoVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_MonoLinePrice_0")]
        public IWebElement SummaryMonoLinePriceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ColourVolume_0")]
        public IWebElement SummaryMonthlyColourVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ColourLineVolume_0")]
        public IWebElement SummaryLineColourVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ColourLinePrice_0")]
        public IWebElement SummaryColourLinePriceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ConsumablesTotalVolumeNet_0")]
        public IWebElement SummaryTotalVolumeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ConsumablesTotalPriceNet_0")]
        public IWebElement SummaryConsumablesTotalPriceNetElement;
        
        
        //Click rate
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_MonoClickRate_0")]
        public IWebElement SummaryMonoClickRateElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ColourClickRate_0")]
        public IWebElement SummaryColourClickRateElement;

        // alert message
        [FindsBy(How = How.Id, Using = "content_1_ValidationErrors_ErrorContainer")]
        public IWebElement ValidationErrorElement;


        public void DownloadDealersProposalDocument()
        {
            LoggingService.WriteLogOnMethodEntry();
            StoreValuesFromSummaryPage();
            StoreInitialProposalSummaryData();
            DownloadProposalPdfWithCalcElement.Click();
        }

        public void DownloadCustomersProposalDocument()
        {
            LoggingService.WriteLogOnMethodEntry();
            StoreValuesFromSummaryPage();
            StoreInitialProposalSummaryData();
            DownloadProposalPdfElement.Click();
            WebDriver.Wait(DurationType.Second, 5);
        }

        private string OfferName()
        {
            LoggingService.WriteLogOnMethodEntry();
            var name = "";

            var lang = SpecFlow.GetContext("BelgianLanguage");

            switch (lang)
            {
                case "French":
                    name = "Offre-";
                    break;
                case "Dutch":
                    name = "Offerte-";
                    break;
            }
            return name;
        }
        

        private string DownloadFolderPath()
        {
            LoggingService.WriteLogOnMethodEntry();
            var propRef = MpsUtil.GeneratedLeadCodeRef();
            var propName = IsBelgiumSystem() ? OfferName() + MpsUtil.CreatedProposal() : MpsUtil.CreatedProposal();

            var partialPath = DownloadPath + propName + "-" + propRef + "-";

            return partialPath;
        }

        public void GetDownloadedPdfPath()
        {
            LoggingService.WriteLogOnMethodEntry();
            var contractid = SummaryPageContractIdElement.GetAttribute("data-mps-qa-id");
            SpecFlow.SetContext("SummaryPageContractId", contractid);

            var downloadPath = DownloadFolderPath() + contractid + ".pdf";
            SpecFlow.SetContext("DownloadedPdfPath", downloadPath);

        }

        public void SetContractIdValue()
        {
            LoggingService.WriteLogOnMethodEntry();
            var contractid = SummaryPageContractIdElement.GetAttribute("data-mps-qa-id");
            SpecFlow.SetContext("SummaryPageContractId", contractid);
        }

        public DealerProposalPdfPage DisplayDownloadedPdf()
        {
            LoggingService.WriteLogOnMethodEntry();
            var downloadedPdf = DownloadedPdf();
            Driver.Navigate().GoToUrl(downloadedPdf);
            return GetInstance<DealerProposalPdfPage>();
        }

        private string DownloadedPdf()
        {
            LoggingService.WriteLogOnMethodEntry();
            var downloadedPdf = SpecFlow.GetContext("DownloadedPdfPath");
            return downloadedPdf;
        }

        public void DownloadProposalPdf()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (SummaryPageDownloadElement != null)
                SummaryPageDownloadElement.Click();

            WebDriver.Wait(DurationType.Second, 5);

        }

        public void DoesPdfContentContainContractId()
        {
            LoggingService.WriteLogOnMethodEntry();
            WebDriver.Wait(DurationType.Second, 10);
            var contractId = SpecFlow.GetContext("SummaryPageContractId");
            WebDriver.Wait(DurationType.Second, 10);
            TestCheck.AssertTextContains(contractId, ExtractTextFromPdf(DownloadedPdf()),
                "Contract Id is not available in the PDF");

        }

        public void PurgeDownloadsDirectory()
        {
            LoggingService.WriteLogOnMethodEntry();
            //Driver.Navigate().Back();
            PurgeDownloads(DownloadDirectory);
        }

        public void IsDeviceTotalPresentInPdf()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsUKSystem())
            {
                TestCheck.AssertTextContains(SpecFlow.GetContext("SummaryCustomerDeviceTotalNet"), ExtractTextFromPdf(DownloadedPdf()),
                 "Device Total is not available in the PDF"); 
            }
            //else
            //{
            //    TestCheck.AssertTextContains(SpecFlow.GetContext("SummaryCustomerDeviceTotalGross"), ExtractTextFromPdf(DownloadedPdf()),
            //     "Device Total is not available in the PDF"); 
            //}
            
        }

        public void IsConsumableTotalNetPresentInPdf()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsUKSystem())
            {
                var deviceTotal = SpecFlow.GetContext("SummaryProposalConsumableTotalNet");
                TestCheck.AssertTextContains(deviceTotal, ExtractTextFromPdf(DownloadedPdf()),
                    "Consumable Total is not available in the PDF");
            }
            
        }

        public void StoreValuesFromSummaryPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            SpecFlow.SetContext("SummaryCustomerDeviceTotalNet", SummaryCustomerDeviceTotalNetElement.Text);
            SpecFlow.SetContext("SummaryCustomerOrCompanyName", SummaryCustomerOrCompanyNameElement.Text);
            SpecFlow.SetContext("SummaryContractTerm", SummaryContractTermElement.Text);
            SpecFlow.SetContext("SummaryContractType", SummaryContractTypeElement.Text);
            SpecFlow.SetContext("SummaryMonoClickRate", SummaryMonoClickRateElement.Text);
            SpecFlow.SetContext("SummaryColourClickRate", SummaryColourClickRateElement.Text);
            SpecFlow.SetContext("SummaryProposalConsumableTotalNet", SummaryProposalConsumableTotalNetElement.Text);
            if (
                IsElementPresent(
                    GetElementByCssSelector("content_1_SummaryTable_RepeaterModels_DeviceTotalPriceGross_0", 5)))
            {
                SpecFlow.SetContext("SummaryCustomerDeviceTotalGross", SummaryCustomerDeviceTotalGrossElement.Text);
            }
            
            
            
        }


        public void WritePrinterParametersToCsv(string printer, string servicePayment, string monoCoverage, string colourCoverage, string qty,
            string monoVol, string colourVol, string duration)
        {
            LoggingService.WriteLogOnMethodEntry(printer,servicePayment,monoCoverage,colourCoverage,qty,monoVol,colourVol,duration);
            //before your loop
            StreamWriter log;

            var monoPrice = SpecFlow.GetContext("ClickPriceMonoValue");
            string colourPrice;
            var contractId = SummaryPageContractIdElement.GetAttribute("data-mps-qa-id");

            try
            {
                colourPrice = SpecFlow.GetContext("ClickPriceColourValue");
            }
            catch (KeyNotFoundException)
            {
                colourPrice = "Nil";
            }


            var newLine = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\"",
                                            printer, servicePayment, monoCoverage, colourCoverage, qty, monoVol, colourVol, duration, monoPrice, colourPrice, contractId);
            //csv.AppendLine(newLine);

            if (!Directory.Exists(ClickPricePath))
            {
                Directory.CreateDirectory(ClickPricePath);
            }

            var filePath = Path.Combine(ClickPricePath, CsvFile);



            if (!File.Exists(filePath))
            {
                log = new StreamWriter(filePath);
                log.WriteLine("\"Printer\",\"ServicePayment\",\"MonoCoverage\",\"ColourCoverage\",\"Quantity\",\"MonoVol\",\"ColourVol\",\"Duration\",\"MonoPrice\",\"ColourPrice\",\"ProposalId\"");
            }
            else
            {
                log = File.AppendText(filePath);
            }

            // Write to the file:

            log.WriteLine(newLine);

            // Close the stream:
            log.Close();

        }

        public void IsCustomerNamePresentInPdf()
        {
            LoggingService.WriteLogOnMethodEntry();
            var customerName = SpecFlow.GetContext("SummaryCustomerOrCompanyName");
            customerName = customerName.Substring(0, 5);
            TestCheck.AssertTextContains(customerName, ExtractTextFromPdf(DownloadedPdf()),
                "Customer Name is not available in the PDF");
        }

        public void DoesPdfContentContainSomeText()
        {
            LoggingService.WriteLogOnMethodEntry();
            var contractId = SpecFlow.GetContext("DownloadedContractId");


            if (!Driver.Url.Contains("Vertrag"))
            {
                TestCheck.AssertTextContains(contractId, ExtractTextFromPdf(DownloadedPdf()),
                "Contract Id is not available in the PDF");
            }
            

        }

        private string ConvertTermForUk(string term)
        {
            LoggingService.WriteLogOnMethodEntry(term);
            var convertedTerm = "";
            if (!IsUKSystem()) return convertedTerm;
            switch (term)
            {
                case "3 years":
                    convertedTerm = "36";
                    break;

                case "4 years":
                    convertedTerm = "48";
                    break;

                case "5 years":
                    convertedTerm = "60";
                    break;
            }
            return convertedTerm;
        }

        public void IsSummaryContractTermPresentInPdf()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsBigAtSystem()) return;
            var contractTerm = SpecFlow.GetContext("SummaryContractTerm");
            contractTerm = ConvertTermForUk(contractTerm);
            TestCheck.AssertTextContains(contractTerm, ExtractTextFromPdf(DownloadedPdf()),
                "Summary Contract Term is not available in the PDF");
        }

        public void DoesPdfContentContractItems(string type)
        {
            LoggingService.WriteLogOnMethodEntry(type);
            if (!IsItalySystem())
            TestCheck.AssertTextContains(type, ExtractTextFromPdf(DownloadedPdf()),
                "Contract Type is not available in the PDF");

        }

        public void IsSummaryMonoClickRatePresentInPdf()
        {
            LoggingService.WriteLogOnMethodEntry();
            var monoClickRate = SpecFlow.GetContext("SummaryMonoClickRate");
            monoClickRate = ConvertClickRatePrice(monoClickRate);
            TestCheck.AssertTextContains(monoClickRate, ExtractTextFromPdf(DownloadedPdf()),
                "Summary Mono Click Rate is not available in the PDF");
        }

        private string ConvertClickRatePrice(string clickPrice)
        {
            LoggingService.WriteLogOnMethodEntry(clickPrice);
            decimal clickDecimal = 0;

            if (IsBigAtSystem())
            {
                clickDecimal = MpsUtil.GetEuroValue(clickPrice);
            }


            return clickDecimal.ToString();
        }

        private string AddCommaToColourClickPrice(string clickRate)
        {
            LoggingService.WriteLogOnMethodEntry(clickRate);
            var sectionOne = clickRate.Substring(0, 1);
            var sectionTwo = clickRate.Substring(1);

            var coJoin = sectionOne + "," + sectionTwo;

            return coJoin;

        }

        public void IsSummaryColourClickRatePresentInPdf()
        {
            LoggingService.WriteLogOnMethodEntry();
            var colourClickRate = SpecFlow.GetContext("SummaryColourClickRate");
            colourClickRate = ConvertClickRatePrice(colourClickRate);

            if (IsBigAtSystem())
            {
                colourClickRate = AddCommaToColourClickPrice(colourClickRate);
            }

            TestCheck.AssertTextContains(colourClickRate, ExtractTextFromPdf(DownloadedPdf()),
                "Summary Colour Click Rate is not available in the PDF");
        }

        private string SpecificLanguageText()
        {
            LoggingService.WriteLogOnMethodEntry();
            var lang = "";

            if (IsAustriaSystem())
            {
                lang = AtText;
            }
            else if (IsUKSystem())
            {
                lang = UkText;
            }
            else if (IsGermanSystem())
            {
                lang = DeText;
            }
            else if (IsFranceSystem())
            {
                lang = FrText;
            }
            else if (IsItalySystem())
            {
                lang = ItText;
            }
            else if (IsSpainSystem())
            {
                lang = SpText;
            }



            return lang;

        }

        public void IsCorrectLanguagePdfDownloaded()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertTextContains(SpecificLanguageText(), ExtractTextFromPdf(DownloadedPdf()),
                "The correct language PDF is not downloaded");
        }

       
        private string PrinterString(string printer)
        {
            LoggingService.WriteLogOnMethodEntry(printer);
            return String.Format(".mps-qa-printer-{0} .panel-heading a", printer);
        }

        private IWebElement DisplayedPrinterLink(string printer)
        {
            LoggingService.WriteLogOnMethodEntry(printer);
            return GetElementByCssSelector(PrinterString(printer));
        }

        public DealerProposalsCreateProductsPage ClickOnDisplayedPrinterLink(string printer)
        {
            LoggingService.WriteLogOnMethodEntry(printer);
            DisplayedPrinterLink(printer).Click();
            return GetTabInstance<DealerProposalsCreateProductsPage>(Driver);
        }

        public DealerClosedProposalPage CloseProposal()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(SummaryCloseProposalElement);
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert();

            SummaryCloseProposalElement.Click();
            
            ClickAcceptOnConfrimation(Driver);
            return GetInstance<DealerClosedProposalPage>(Driver);
        }

        public void ClickAcceptOnConfrimation(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            WebDriver.Wait(DurationType.Millisecond, 3000);
            ClickAcceptOnJsAlert();
        }


        public void VerifyThatCorrectModelBillingBasisIsDisplayed(string basis)
        {
            LoggingService.WriteLogOnMethodEntry(basis);
            if (!(IsGermanSystem() && GetContractType() == "Easy Print Pro & Service"))
            {
                TestCheck.AssertIsEqual(basis,
                    ModelBillingBasisElement.Text,
                    "Model Billing Basis is not matching");
            }
        }


        public void IsHardwareUnitPriceCorrectlyCalculated()
        {
            LoggingService.WriteLogOnMethodEntry();
            var displayedPrice = SummaryUnitPriceElement.Text;
            var cost = SummaryModelUnitCostElement.Text;
            var margin = MarginDecimal(SummaryMarginElement.Text);

            var calculatedPrice = CalculatePriceFromCostUsingMargin(cost, margin);

            TestCheck.AssertTextContains(displayedPrice, calculatedPrice);
        }

        public void IsAccessoryUnitPriceCorrectlyCalculated()
        {
            LoggingService.WriteLogOnMethodEntry();
            var displayedPrice = SummaryAccessoryUnitPriceElement.Text;
            var cost = SummaryAccessoryUnitCostElement.Text;
            var margin = MarginDecimal(SummaryAccessoryMarginElement.Text);

            var calculatedPrice = CalculatePriceFromCostUsingMargin(cost, margin);

            TestCheck.AssertTextContains(displayedPrice, calculatedPrice);
        }

        private decimal MarginDecimal(string element)
        {
            LoggingService.WriteLogOnMethodEntry(element);
            var splitElement = new string[] {};

            if (element.Contains(","))
            {
                splitElement = element.Split(',');
            }
            else if (element.Contains("."))
            {
                splitElement = element.Split('.');
            }

            var margDecimal = decimal.Parse(splitElement[0]);

            return margDecimal/100;
        }

        private string CalculatePriceFromCostUsingMargin(string cost, decimal margin)
        {
            LoggingService.WriteLogOnMethodEntry(cost,margin);
            var number = MpsUtil.GetValue(cost);
            var costDecimal = (number/(1 - margin));
            costDecimal = RoundUpValue(costDecimal, 2);

            return costDecimal.ToString();
        }

        public void IsTotalVolumeCorrectlyAddedUp()
        {
            LoggingService.WriteLogOnMethodEntry();
            var totalVolume = RemoveCommaFromCurrency(SummaryTotalVolumeElement.Text);
            var monoVolume = RemoveCommaFromCurrency(SummaryLineMonoVolumeElement.Text);
            var colourVolume = RemoveCommaFromCurrency(SummaryLineColourVolumeElement.Text);

            var mDecimal = decimal.Parse(monoVolume);
            var cDecimal = decimal.Parse(colourVolume);

            var totalVol = (mDecimal + cDecimal).ToString();

            TestCheck.AssertTextContains(totalVolume, totalVol);
        }

        public void IsTotalLinePriceCorrectlyCalculated()
        {
            LoggingService.WriteLogOnMethodEntry();
            var displayedTotal = RemoveCommaFromCurrency(SummaryConsumablesTotalPriceNetElement.Text);

            var monoTotalPrice = MpsUtil.GetValue(SummaryMonoLinePriceElement.Text);
            var colourTotalPrice = MpsUtil.GetValue(SummaryColourLinePriceElement.Text);

            var calcTotal = monoTotalPrice + colourTotalPrice;

            calcTotal = RoundUpValue(calcTotal, 2);

            TestCheck.AssertTextContains(displayedTotal, calcTotal.ToString());

        }


        public void IsContractTotalCorrectlyAddedUp()
        {
            LoggingService.WriteLogOnMethodEntry();
            var displayedTotal = RemoveCommaFromCurrency(SummaryContractGrandTotalPriceElement.Text);

            var deviceTotalPrice = MpsUtil.GetValue(SummaryGrandDeviceTotalPriceElement.Text);
            var consumableTotalPrice = MpsUtil.GetValue(SummaryGrandConsumableTotalPriceElement.Text);
            var charges = IsElementPresent(GetElementByCssSelector("#content_1_SummaryTable_ChargesTotalPriceNet"))
                ? MpsUtil.GetValue(SummaryGrandChargesTotalPriceElement.Text)
                : 0;

            var calcTotal = deviceTotalPrice + consumableTotalPrice + charges;

            calcTotal = RoundUpValue(calcTotal, 2);

            TestCheck.AssertTextContains(displayedTotal, calcTotal.ToString());

        }

        public void IsTotalMonoPriceCorrectlyCalculated(string qty)
        {
            LoggingService.WriteLogOnMethodEntry(qty);
            var displayedPrice = RemoveCommaFromCurrency(SummaryMonoLinePriceElement.Text);
            var monoClick = MpsUtil.GetValue(SummaryMonoClickRateElement.Text);
            var totalVol = CalculateTotalMonoVolume(qty);

            var calcTotal = monoClick*totalVol;
            calcTotal = RoundUpValue(calcTotal, 2);


            TestCheck.AssertTextContains(displayedPrice, calcTotal.ToString());
        }

        public void IsTotalColourPriceCorrectlyCalculated(string qty)
        {
            LoggingService.WriteLogOnMethodEntry(qty);
            var displayedPrice = RemoveCommaFromCurrency(SummaryColourLinePriceElement.Text);
            var monoClick = MpsUtil.GetValue(SummaryColourClickRateElement.Text);
            var totalVol = CalculateTotalMonoVolume(qty);

            var calcTotal = monoClick * totalVol;
            calcTotal = RoundUpValue(calcTotal, 2);


            TestCheck.AssertTextContains(displayedPrice, calcTotal.ToString());
        }

        public void IsMonoVolumeTotalCorrect(string qty)
        {
            LoggingService.WriteLogOnMethodEntry(qty);
            var calcVol = CalculateTotalMonoVolume(qty).ToString();
            var displayedTotalVolume = RemoveCommaFromCurrency(SummaryLineMonoVolumeElement.Text);

            TestCheck.AssertTextContains(displayedTotalVolume, calcVol);
        }

        public void IsColourVolumeTotalCorrect(string qty)
        {
            LoggingService.WriteLogOnMethodEntry(qty);
            var calcVol = CalculateTotalColourVolume(qty).ToString();
            var displayedTotalVolume = RemoveCommaFromCurrency(SummaryLineColourVolumeElement.Text);

            TestCheck.AssertTextContains(displayedTotalVolume, calcVol);
        }

        public decimal CalculateTotalMonoVolume(string qty)
        {
            LoggingService.WriteLogOnMethodEntry(qty);
            var mono = decimal.Parse(SummaryMonthlyMonoVolumeElement.Text);
           
           var qtyDec = decimal.Parse(qty);

            var monoTotal = mono * qtyDec * 12 * 3;

            return monoTotal;

        }

        public decimal CalculateTotalColourVolume(string qty)
        {
            LoggingService.WriteLogOnMethodEntry(qty);
            var colour = decimal.Parse(SummaryMonthlyColourVolumeElement.Text);
            
            var qtyDec = decimal.Parse(qty);

            var colourTotal = colour * qtyDec * 12 * 3;
           
            return colourTotal;

        }

        private decimal RoundUpValue(decimal value, int places)
        {
            LoggingService.WriteLogOnMethodEntry(value,places);
            return Math.Round(value, places); 
        }

        private string CalculateTotalAmount(string qty, string unitCost)
        {
            LoggingService.WriteLogOnMethodEntry(qty,unitCost);
            var number = MpsUtil.GetValue(unitCost);
            var quantity = decimal.Parse(qty);

            var totalCost = number*quantity;
            totalCost = RoundUpValue(totalCost, 2);


            return totalCost.ToString();

        }

        private string RemoveCommaFromCurrency(string displayed)
        {
            LoggingService.WriteLogOnMethodEntry(displayed);
            var displayedValue = displayed;
            if (displayedValue.Contains(","))
            {
                displayedValue = displayedValue.Replace(",", "");
            }

            return displayedValue;
        }

        private decimal DeviceTotalOnSummaryPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            var hardwareTotal = MpsUtil.GetValue(SummaryTotalPriceElement.Text);
            var trayTotal = MpsUtil.GetValue(SummaryAccessoryTotalPriceElement.Text);
            var deliveryTotal = MpsUtil.GetValue(SummaryDeliveryTotalPriceElement.Text);
            var installTotal = MpsUtil.GetValue(SummaryInstallationTotalPriceElement.Text);
            var servicePackTotal = MpsUtil.GetValue(SummaryServicePackTotalPriceElement.Text);

            var grandTotal = hardwareTotal + trayTotal + deliveryTotal + installTotal + servicePackTotal;

            return RoundUpValue(grandTotal, 2);

        }

        public void IsDeviceNetTotalAddedUpCorrectly()
        {
            LoggingService.WriteLogOnMethodEntry();
            var displayedTotal = RemoveCommaFromCurrency(SummaryDeviceTotalPriceElement.Text);
            var calculatedTotal = DeviceTotalOnSummaryPage().ToString();

            TestCheck.AssertTextContains(displayedTotal, calculatedTotal);
        }

        public void IsSummaryTotalPriceCorrectlyCalculate(string qty)
        {
            LoggingService.WriteLogOnMethodEntry(qty);
            var displayedPrice = RemoveCommaFromCurrency(SummaryTotalPriceElement.Text);
            
            var cost = SummaryUnitPriceElement.Text;
            var calculatedPrice = CalculateTotalAmount(qty, cost);

            TestCheck.AssertTextContains(displayedPrice, calculatedPrice);

        }

        public void IsSummaryTotalCostCorrectlyCalculate(string qty)
        {
            LoggingService.WriteLogOnMethodEntry(qty);
            var displayedCost = RemoveCommaFromCurrency(SummaryTotalCostElement.Text);

            var cost = SummaryModelUnitCostElement.Text;
            var calculatedPrice = CalculateTotalAmount(qty, cost);

            TestCheck.AssertTextContains(displayedCost, calculatedPrice);

        }

        public void IsSummaryAccessoryTotalPriceCorrectlyCalculate(string qty)
        {
            LoggingService.WriteLogOnMethodEntry(qty);
            var displayedPrice = RemoveCommaFromCurrency(SummaryAccessoryTotalPriceElement.Text);

            var cost = SummaryAccessoryUnitPriceElement.Text;
            var calculatedPrice = CalculateTotalAmount(qty, cost);

            TestCheck.AssertTextContains(displayedPrice, calculatedPrice);

        }

        public void IsSummaryAccessoryTotalCostCorrectlyCalculate(string qty)
        {
            LoggingService.WriteLogOnMethodEntry(qty);
            var displayedCost = RemoveCommaFromCurrency(SummaryAccessoryTotalCostElement.Text);

            var cost = SummaryAccessoryUnitCostElement.Text;
            var calculatedPrice = CalculateTotalAmount(qty, cost);

            TestCheck.AssertTextContains(displayedCost, calculatedPrice);

        }


        public string CalculateCostFromPriceUsingMargin(string price, decimal margin)
        {
            LoggingService.WriteLogOnMethodEntry(price,margin);
            decimal number = MpsUtil.GetValue(price); ;
            var priceDecimal = ((1 - margin)*number);
            priceDecimal = Math.Round(priceDecimal, 2);

            return priceDecimal.ToString();
           
        }

        public void VerifyThatCorrectAccessoryBillingBasisIsDisplayed(string basis)
        {
            LoggingService.WriteLogOnMethodEntry(basis);
            if (!((IsGermanSystem() && GetContractType() == "Easy Print Pro & Service") || IsPolandSystem()))
            {
                TestCheck.AssertIsEqual(basis,
                    AccessoryBillingBasisElement.Text,
                    "Accessory Billing Basis is not matching");
            }
        }

        public void VerifyThatCorrectInstallationBillingBasisIsDisplayed(string basis)
        {
            LoggingService.WriteLogOnMethodEntry(basis);
            if (!(IsGermanSystem() && GetContractType() == "Easy Print Pro & Service"))
            {
                TestCheck.AssertIsEqual(basis,
                    InstallationBillingBasisElement.Text,
                    "Installation Billing Basis is not matching");
            }
        }

        public void VerifyThatCorrectServicePackBillingBasisIsDisplayed(string basis)
        {
            LoggingService.WriteLogOnMethodEntry(basis);
            TestCheck.AssertIsEqual(basis, 
                ServicePackBillingBasisElement.Text, 
                "Service Pack Billing Basis is not matching");
        }

        public void VerifyThatNetTotalsAreMatching()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(ItemizedConsumableNetTotalElement.Text, 
                ContractConsumableNetTotalElement.Text, 
                "Consumable Net Totals did not match");
        }

        public void VerifyThatGrossTotalsAreMatching()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(ItemizedConsumableGrossTotalElement.Text, 
                ContractConsumableGrossTotalElement.Text, 
                "Consumable Net Totals did not match");
        }

        public void VerifyCorrectMonoVolumeIsDisplayed(string mono)
        {
            LoggingService.WriteLogOnMethodEntry(mono);
            TestCheck.AssertIsEqual(MonoVolumeElement.Text, mono, 
                "Correct Mono volume is not displayed");
        }

        public void VerifyCorrectColourVolumeIsDisplayed(string colour)
        {
            LoggingService.WriteLogOnMethodEntry(colour);
            TestCheck.AssertIsEqual(ColourVolumeElement.Text, colour,
                "Correct Colour volume is not displayed");
        }

        public void VerifyThatCorrectBankIsDisplayed(string bank)
        {
            LoggingService.WriteLogOnMethodEntry(bank);
            TestCheck.AssertIsEqual(!IsAustriaSystem() ? bank : "GRENKELEASING GmbH", DisplayedBankNameElement.Text,
                "Bank displayed in not correct");
        }

        public string GetMonoClickValue()
        {
            LoggingService.WriteLogOnMethodEntry();
            //var monoClickRate = IsSwedenSystem() ? MonoClickRateElement.Text : MpsUtil.GetValue(MonoClickRateElement.Text).ToString();

            var monoClickRate =MonoClickRateElement.Text;

            return monoClickRate;
        }


        public string GetColourClickValue()
        {
            LoggingService.WriteLogOnMethodEntry();
            //var colourClickRate = IsSwedenSystem() ? ColourClickRateElement.Text : MpsUtil.GetValue(ColourClickRateElement.Text).ToString();
            var colourClickRate = ColourClickRateElement.Text;
            return colourClickRate;
        }

        public void IsSpecialPricingMonoClickPriceDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            var mono = GetMonoClickValue();
            var monoD = SpecFlow.GetContext("SpecialPriceMonoClickPrice");

            TestCheck.AssertIsEqual(true, mono.Contains(monoD), string.Format("{0} does not contain {1}", mono, monoD));
        }

        public void IsSpecialPricingColourClickPriceDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            var colour = GetColourClickValue();
            var colourD = SpecFlow.GetContext("SpecialPriceColourClickPrice");

            TestCheck.AssertIsEqual(true, colour.Contains(colourD), string.Format("{0} does not contain {1}", colour, colourD));
        }

        public void IsSpecialPricingInstallationUnitPriceDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            var install = InstallationUnitPriceElement.Text;
            var installD = SpecFlow.GetContext("SpecialPriceInstallation");

            TestCheck.AssertIsEqual(true, install.Contains(installD), string.Format("{0} does not contain {1}", install, installD));
        }


        public void IsSpecialPricingServicePackUnitPriceDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            var servicePack = ServicePackUnitPriceElement.Text;
            var servicePackD = SpecFlow.GetContext("SpecialPriceServicePack");

            TestCheck.AssertIsEqual(true, servicePack.Contains(servicePackD), string.Format("{0} does not contain {1}", servicePack, servicePackD));
        }




        public void IsMonoClickPriceDisplayedCorrectly()
        {
            LoggingService.WriteLogOnMethodEntry();
            var monoValue = SpecFlow.GetContext("ClickPriceMonoValue");
            var value = GetMonoClickValue();

            TestCheck.AssertTextContains(monoValue, value, 
                 "Mono Click Price displayed is different from the calculated on");
        }

        public void IsColourClickPriceDisplayedCorrectly()
        {
            LoggingService.WriteLogOnMethodEntry();
            var colourValue = SpecFlow.GetContext("ClickPriceColourValue");

            TestCheck.AssertTextContains(colourValue, GetColourClickValue(),
                 "Colour Click Price displayed is different from the calculated on");
        }

        public void VerifyLeasingPanelDiplsayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, 
                IndividualLeasingLabelElement.Displayed, 
                "No leasing label is displayed");
        }

        public void VerifyThatCalculationsAreNotBasedOnEstimates()
        {
            LoggingService.WriteLogOnMethodEntry();
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
            else if (IsSpainSystem())
            {
                TestCheck.AssertTextContains(CalculationBasisElement.Text, "Total del contrato basado en el volumen mínimo por equipo");
            }

        }

        public void VerifyInstallationTypeIsConsistent()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (!(IsGermanSystem() && GetContractType() == "Easy Print Pro & Service"))
            {
                var storedDisplayedInstallationType = SpecFlow.GetContext("SelectedInstallationType");
                var InstallationType = InstallationTypeNameElement.Text;

                TestCheck.AssertTextContains(InstallationType, storedDisplayedInstallationType.Trim(),
                    "Summary Installation Type is different from Selected Installation Type");
            }
        }

        public void VerifyInstallationCostIsConsistent()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (!(IsGermanSystem() && GetContractType() == "Easy Print Pro & Service"))
            {
                var savedInstallationPrice = SpecFlow.GetContext("SelectedInstallationPrice");
                var summaryInstallationCost = InstallationCostNameElement.Text;

                TestCheck.AssertIsEqual(savedInstallationPrice, summaryInstallationCost,
                    "Summary Installation Cost is different from Selected Installation Cost");
            }
        }

        public void VerifyServicePackNameIsConsistent()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(SpecFlow.GetContext("ServicePackName"), 
                ServicePackNameElement.Text, "Service Pack names are not the same");
        }

        public void VerifyServicePackCostIsConsistent()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (!(IsGermanSystem() && GetContractType() == "Easy Print Pro & Service"))
            {
                TestCheck.AssertIsEqual(SpecFlow.GetContext("SelectedServicePackPrice"),
                    ServiceCostNameElement.Text,
                    "Service Pack cost on Product page is not the same as the Service Pack on Summary page");
            }
        }

        public void VerifyServicePackCostIsInclusiveInClick(string value)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            if (!(IsGermanSystem() && GetContractType() == "Easy Print Pro & Service"))
            {
                var cost = ServiceCostNameElement.Text;
                TestCheck.AssertIsEqual(value, cost,
                    "Service Pack cost on Product page is not the same as the Service Pack on Summary page");
            }
        }

        public void VerifyProductQuantityIsConsistent()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (!(IsGermanSystem() && GetContractType() == "Easy Print Pro & Service"))
            {
                TestCheck.AssertIsEqual(SpecFlow.GetContext("ProductQuantity"),
                    ModelQuantityNameElement.Text,
                    "Quantity on Product Page is different from Quantity on Summary Page");
            }
        }


        public void VerifyThatCalculationsAreBasedOnEstimates()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsUKSystem())
            {
                TestCheck.AssertTextContains(CalculationBasisElement.Text, "Estimated Volume");
            }
            else if (IsAustriaSystem())
            {
                TestCheck.AssertTextContains(CalculationBasisElement.Text, "Mindestdruckvolumina");
            } 
            else if (IsGermanSystem())
            {
                TestCheck.AssertTextContains(CalculationBasisElement.Text, "Druckvolumina");
            } 
            else if (IsFranceSystem())
            {
                TestCheck.AssertTextContains(CalculationBasisElement.Text, "Coût total par matériel sur la base de l'estimation de volume de pages");
            }
            else if (IsSpainSystem())
            {
                TestCheck.AssertTextContains(CalculationBasisElement.Text, "Total del contrato basado en el volumen estimado por equipo");
            }

             
        }

        public void VerifyCreatedProposalSummaryPageElements(string summaryElement, string value)
        {
            LoggingService.WriteLogOnMethodEntry(summaryElement,value);
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
            LoggingService.WriteLogOnMethodEntry(contractType);
            TestCheck.AssertIsEqual(true, 
                RepeaterModels_MonoVolumeElement.Text.Equals(contractType), 
                "Printer Displayed on Summary page does not match");
        }

        private void VerifyCorrectColourVolumeIsDisplayedOnSummaryPage(string contractType)
        {
            LoggingService.WriteLogOnMethodEntry(contractType);
            TestCheck.AssertIsEqual(true, 
                SummaryColourClickVolumeElement.Text.Equals(contractType), 
                "Printer Displayed on Summary page does not match");
        }

        private void VerifyCorrectDisplayedPrinterIsDisplayedOnSummaryPage(string contractType)
        {
            LoggingService.WriteLogOnMethodEntry(contractType);
            TestCheck.AssertIsEqual(true, 
                SummaryItemizedPrinterElement.Text.Equals(contractType), 
                "Printer Displayed on Summary page does not match");
        }

        private void VerifyCorrectContractTypeIsDisplayedOnSummaryPage(string contractType)
        {
            LoggingService.WriteLogOnMethodEntry(contractType);
            TestCheck.AssertIsEqual(true, 
                ContractTypeElement.Text.Equals(contractType), 
                "Contract Type does not match");
        }

        public void VerifyCorrectContractTermIsDisplayedOnSummaryPage(string contractTerm)
        {
            LoggingService.WriteLogOnMethodEntry(contractTerm);
            TestCheck.AssertIsEqual(true, 
                ContractTermElement.Text.Equals(contractTerm), 
                "Contract Term does not match");
        }

        public void VerifyCorrectUsageTypeIsDisplayedOnSummaryPage(string contractTerm)
        {
            LoggingService.WriteLogOnMethodEntry(contractTerm);
            TestCheck.AssertIsEqual(true, 
                UsageTypeElement.Text.Equals(contractTerm), 
                "Usage Type does not match");
        }

        private void VerifyCorrectLeasingFrequencyIsDisplayedOnSummaryPage(string contractTerm)
        {
            LoggingService.WriteLogOnMethodEntry(contractTerm);
            TestCheck.AssertIsEqual(true, 
                LeaseRentalFrequencyElement.Text.Equals(contractTerm), 
                "Lease Frequency does not match");
        }

        public void VerifyCorrectBillingTermIsDisplayedOnSummaryPage(string contractTerm)
        {
            LoggingService.WriteLogOnMethodEntry(contractTerm);
            TestCheck.AssertIsEqual(true, 
                UsageBillingFrequencyElement.Text.Equals(contractTerm), 
                "Usage Billing Frequency does not match");
        }

        public CloudExistingProposalPage SaveProposal()
        {
            LoggingService.WriteLogOnMethodEntry();
            SetContractIdValue();
            WebDriver.Wait(DurationType.Second, 3);
            ScrollTo(SaveProposalElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, SaveProposalElement);
            return GetTabInstance<CloudExistingProposalPage>(Driver);
        }


        public CloudExistingProposalPage DownloadPdfAndSaveProposal()
        {
            LoggingService.WriteLogOnMethodEntry();
            WebDriver.Wait(DurationType.Second, 3);
            CalculationEngineModule.DownloadProposalPdfOnSummaryPage(Driver);
            if (Driver.Url.ToLower().Contains("convert"))
            {
                CalculationEngineModule.DownloadPageHtml(Driver, "Dealer_Convert");
            }
            else if (Driver.Url.ToLower().Contains("create"))
            {
                CalculationEngineModule.DownloadPageHtml(Driver, "Dealer_Create");
            }

            SetContractIdValue();
           
            ScrollTo(SaveProposalElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, SaveProposalElement);
            return GetTabInstance<CloudExistingProposalPage>(Driver);
        }



        public void VerifySelectedDeviceIsDisplayed(string model)
        {
            LoggingService.WriteLogOnMethodEntry(model);
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
            LoggingService.WriteLogOnMethodEntry();
            var before = Convert.ToDecimal(SpecFlow.GetContext("EnteredProductMargin"));
            var after = Convert.ToDecimal(ModelHardwareMarginElement.Text.Trim(" %".ToCharArray()));
            TestCheck.AssertIsEqual(before, after, "Product Margin invalid");
        }

        private void VerifyEnteredDeliveryMarginIsDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            var before = Convert.ToDecimal(SpecFlow.GetContext("EnteredDeliveryMargin"));
            var after = Convert.ToDecimal(ModelDeliveryMarginElement.Text.Trim(" %".ToCharArray()));
            TestCheck.AssertIsEqual(before, after, "Delivery Margin invalid");
        }

        private void VerifyEnteredInstallationPackMarginIsDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            var before = Convert.ToDecimal(SpecFlow.GetContext("EnteredInstallationPackMargin"));
            var after = Convert.ToDecimal(ModelInstallationMarginElement.Text.Trim(" %".ToCharArray()));
            TestCheck.AssertIsEqual(before, after, "InstallationPack Margin invalid");
        }

        private void VerifyEnteredServicePackMarginIsDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            var before = Convert.ToDecimal(SpecFlow.GetContext("EnteredServicePackMargin"));
            var after = Convert.ToDecimal(ModelServicePackMarginElement.Text.Trim(" %".ToCharArray()));
            TestCheck.AssertIsEqual(before, after, "ServicePack Margin invalid");
        }

        private void VerifyEnteredOptionMargin0IsDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
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
            LoggingService.WriteLogOnMethodEntry();
            VerifyEnteredHardwareMarginIsDisplayed();
            VerifyEnteredDeliveryMarginIsDisplayed();
            VerifyEnteredInstallationPackMarginIsDisplayed();
            VerifyEnteredServicePackMarginIsDisplayed();
            VerifyEnteredOptionMargin0IsDisplayed();
        }

        public void StoreInitialProposalSummaryData()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsElementPresent(RepeaterModels_DeviceTotalPriceNetElement))
                SpecFlow.SetContext("DealerProposalSummaryRepeaterModels_DeviceTotalPriceNetElement", RepeaterModels_DeviceTotalPriceNetElement.Text);
            if (IsElementPresent(RepeaterModels_DeviceTotalPriceGrossElement))
                SpecFlow.SetContext("DealerProposalSummaryRepeaterModels_DeviceTotalPriceGrossElement", RepeaterModels_DeviceTotalPriceGrossElement.Text);
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
        }

        public void StoreProposalSummaryData()
        {
            LoggingService.WriteLogOnMethodEntry();
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
            LoggingService.WriteLogOnMethodEntry(proposalName);
            TestCheck.AssertIsEqual(ProposalNameElement.Text,
                proposalName,
                "Description-ProposalName did not match");
        }

        public void VerifyLeadCodeReference(string leadCodeRef)
        {
            LoggingService.WriteLogOnMethodEntry(leadCodeRef);
            TestCheck.AssertIsEqual(LeadCodeReferenceElement.Text,
                leadCodeRef,
                "Description-LeadCodeReference did not match");
        }

        public void VerifyCustomerOrgName(string orgname)
        {
            LoggingService.WriteLogOnMethodEntry(orgname);
            TestCheck.AssertIsEqual(CustomerNameElement.Text,
                orgname,
                "CustomerInformation-Organization did not match");
        }

        public void VerifyDescriptionTabInput()
        {
            LoggingService.WriteLogOnMethodEntry();
            var proposalName = SpecFlow.GetContext("GeneratedProposalName");
            VerifyProposalName(proposalName);

            var leadCodeRef = SpecFlow.GetContext("GeneratedLeadCodeReference");
            VerifyLeadCodeReference(leadCodeRef);
        }

        public void VerifyCustomerInformationTabInput()
        {
            LoggingService.WriteLogOnMethodEntry();
            var orgName = SpecFlow.GetContext("DealerLatestEditedCustomerOrg");
            VerifyCustomerOrgName(orgName);
        }

        public void VerifyTermAndTypeTabInput(string contractType)
        {
            LoggingService.WriteLogOnMethodEntry(contractType);
            VerifyCorrectContractTypeIsDisplayedOnSummaryPage(contractType);

            var usagetype = SpecFlow.GetContext("DealerLatestEditedUsageType");
            VerifyCorrectUsageTypeIsDisplayedOnSummaryPage(usagetype);

            var contractterm = SpecFlow.GetContext("DealerLatestEditedContractTerm");
            VerifyCorrectContractTermIsDisplayedOnSummaryPage(contractterm);
        }

        private IWebElement FindItem(IWebDriver driver, string format, string type, int row)
        {
            LoggingService.WriteLogOnMethodEntry(driver,format,type,row);
            var selector = string.Format(format, type, row);
            return driver.FindElement(By.CssSelector(selector));
        }


        public void VerifyProductsTabInput(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            var product = SpecFlow.GetObject<DealerProposalsCreateProductsPage.ProductDetail>("DealerRecentEditProduct");

            VerifyProduct(driver, product);
        }

        public void VerifyProductsCount(IWebDriver driver, string action)
        {
            LoggingService.WriteLogOnMethodEntry(driver,action);
            if (!IsPolandSystem())
            {
                var count = SpecFlow.GetContext("DealerEditProductCount");

                VerifyProductCount(driver, count);
            }
        }

        private void VerifyProductCount(IWebDriver driver, string count)
        {
            LoggingService.WriteLogOnMethodEntry(driver,count);
            const string printerselector = @".mps-qa-printer";

            var actual = driver.FindElements(By.CssSelector(printerselector)).Count().ToString();

            TestCheck.AssertIsEqual(count, actual, "Product count does not match");
        }

        private void VerifyProduct(IWebDriver driver, DealerProposalsCreateProductsPage.ProductDetail product)
        {
            LoggingService.WriteLogOnMethodEntry(driver, product);
            var modelselector = string.Format(@".panel.mps-qa-printer.mps-qa-printer-{0}", product.Model.Name);

            var modeldiv = driver.FindElement(By.CssSelector(modelselector));

            const string pricetalbleselector = "table.mps-table-model-pricing";

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
            LoggingService.WriteLogOnMethodEntry(pricetable,itemDetail,row);
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
            LoggingService.WriteLogOnMethodEntry(str);
            string[] units = { "£", " %" };

            return units.Aggregate(str, (current, u) => current.Replace(u, ""));
        }

        public void VerifyClickPriceTabInput(IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(driver);
            const int count = 1;
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

        public int ReturnContractId()
        {
            LoggingService.WriteLogOnMethodEntry();
            string contractId = SummaryPageContractIdElement.GetAttribute("data-mps-qa-id");
            return Int32.Parse(contractId);
        }

        public void ClickSaveProposal()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(SaveProposalElement);
            SaveProposalElement.Click();            
        }

        public void VerifyThatServicePackIsCorrectOnSummaryPage(string servicePackType, string resourceServicePackTypeIncludedInClickPrice)
        {
            LoggingService.WriteLogOnMethodEntry(servicePackType,resourceServicePackTypeIncludedInClickPrice);
            if (servicePackType.Equals(resourceServicePackTypeIncludedInClickPrice))
            {
                if (!ServicePackBillingBasisElement.Text.Equals(servicePackType) || (SummaryContractGrandTotalInClickLineElement == null))
                {
                    throw new Exception("Service Pack Content did not get validated on summary page");
                }
            }
        }


        public void VerifyTheCorrectPositionOfCurrencySymbol()
        {
            LoggingService.WriteLogOnMethodEntry();

            if (CultureInfo == null) {TestCheck.AssertFailTest("CultureInfo has null value");}

            string currencySymbol = CultureInfo.NumberFormat.CurrencySymbol;
            var message = "Currency symbol position did not get validated";

            // TODO refactor later
            if (SummaryGrandDeviceTotalPriceElement.Text != "-") { TestCheck.AssertIsEqual(true, SummaryGrandDeviceTotalPriceElement.Text.Contains(currencySymbol), message); }
            
            if(SeleniumHelper.IsElementDisplayed(SummaryContractGrandTotalPriceGrossElement))
            {
                TestCheck.AssertIsEqual(true, SummaryContractGrandTotalPriceGrossElement.Text.Contains(currencySymbol), message);
            }
            else
            {
                LoggingService.WriteLog(Tests.Common.Logging.LoggingLevel.WARNING, "SummaryContractGrandTotalPriceGrossElement validate skip because not found. maybe german");
            }
            TestCheck.AssertIsEqual(true, GrandTotalPriceNetElement.Text.Contains(currencySymbol), message);
            if(SeleniumHelper.IsElementDisplayed(GrandTotalPriceGrossElement))
            {
                TestCheck.AssertIsEqual(true, GrandTotalPriceGrossElement.Text.Contains(currencySymbol), message);
            }
            else
            {
                LoggingService.WriteLog(Tests.Common.Logging.LoggingLevel.WARNING, "GrandTotalPriceGrossElement validate skip because not found. maybe german");
            }
        }

        public void VerifyNoAlertInfoMessage()
        {
            if(SeleniumHelper.IsElementDisplayed(ValidationErrorElement))
            {
                TestCheck.AssertFailTest("Validation error message found message=[" + ValidationErrorElement.Text + "]");
            }
        }


    }
}
