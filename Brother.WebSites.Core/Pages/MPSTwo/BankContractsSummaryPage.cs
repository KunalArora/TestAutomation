﻿using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BankContractsSummaryPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_ButtonReject")]
        private IWebElement RjectButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonAccept")]
        private IWebElement AcceptButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonOpenOfferRejectReject")]
        private IWebElement FinalRejectButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonContractAcceptAccept")]
        private IWebElement FinalAcceptButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_InputOpenOfferRejectReason_Input")]
        public IWebElement BankRejectReasonElement;
        [FindsBy(How = How.Id, Using = "content_1_InputOpenOfferRejectComment_Input")]
        public IWebElement BankRejectCommentElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LeaseRentalFrequency")]
        private IWebElement LeaseRentalFrequencyElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DealershipName")]
        private IWebElement DealershipNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DealerName")]
        private IWebElement DealerNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DealerTelephone")]
        private IWebElement DealerTelephoneElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DealerEmail")]
        private IWebElement DealerEmailElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerDetailsName")]
        private IWebElement CustomerDetailsName;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerAddress")]
        private IWebElement CustomerAddressName;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerCity")]
        private IWebElement CustomerCityElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerCounty")]
        private IWebElement CustomerCountyNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerPostCode")]
        private IWebElement CustomerPostCodeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerCountry")]
        private IWebElement CustomerCountryElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerContact")]
        private IWebElement CustomerContactElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerTelephone")]
        private IWebElement CustomerTelephoneElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerEmail")]
        private IWebElement CustomerEmailElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerTradingStyle")]
        private IWebElement CustomerTradingStyleElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerPaymentType")]
        private IWebElement CustomerPaymentTypeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerCompanyRegistration")]
        private IWebElement CustomerCompanyRegistrationElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerBankName")]
        private IWebElement CustomerBankNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerBankAccount")]
        private IWebElement CustomerBankAccountElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerIban")]
        private IWebElement CustomerIbanElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerBic")]
        private IWebElement CustomerBICElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerSortCode")]
        private IWebElement CustomerSortCodeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerAuthorisedSignatory")]
        private IWebElement CustomerAuthorisedSignatoryElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerVatNumber")]
        private IWebElement CustomerVatNumberElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_DeviceTotalPriceNet_0")]
        private IWebElement RepeaterModels_DeviceTotalPriceNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_DeviceTotalPriceGross_0")]
        private IWebElement RepeaterModels_DeviceTotalPriceGrossElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_DeviceLeasingTotalNet_0")]
        private IWebElement RepeaterModels_DeviceLeasingTotalNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_DeviceLeasingTotalGross_0")]
        private IWebElement RepeaterModels_DeviceLeasingTotalGrossElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ConsumablesTotalPriceNet_0")]
        private IWebElement RepeaterModels_ConsumablesTotalPriceNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ConsumablesTotalPriceGross_0")]
        private IWebElement RepeaterModels_ConsumablesTotalPriceGrossElement;
//        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeviceTotalsTotalCostNet")]
//        private IWebElement DeviceTotalsTotalCostNetElement;
//        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeviceTotalsTotalMarginNet")]
//        private IWebElement DeviceTotalsTotalMarginNetElement;
//        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalMarginNet")]
//        private IWebElement ConsumableTotalsTotalMarginNetElement;
//        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalPriceNet")]
//        private IWebElement ConsumableTotalsTotalPriceNetElement;
//        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalMarginGross")]
//        private IWebElement ConsumableTotalsTotalMarginGrossElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalPriceGross")]
        private IWebElement ConsumableTotalsTotalPriceGrossElement;
//        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_GrandTotalMarginNet")]
//        private IWebElement GrandTotalMarginNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_GrandTotalPriceNet")]
        private IWebElement GrandTotalPriceNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_BankName")]
        private IWebElement BankNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_TermLength")]
        private IWebElement TermLengthElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_PaymentFrequency")]
        private IWebElement PaymentFrequencyElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_PaymentQuantity")]
        private IWebElement PaymentQuantityElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_PaymentAmountNet")]
        private IWebElement PaymentAmountNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_PaymentAmountGross")]
        private IWebElement PaymentAmountGrossElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepaymentTotalNet")]
        private IWebElement RepaymentTotalNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepaymentTotalGross")]
        private IWebElement RepaymentTotalGrossElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_HardwareAccessoryPrice")]
        private IWebElement HardwareAccessoryPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeliveryInstallationPrice")]
        private IWebElement DeliveryInstallationPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_FinanceCharge")]
        private IWebElement FinanceChargeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_FinanceTotalNet")]
        private IWebElement FinanceTotalNetElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_FinanceTotalGross")]
        private IWebElement FinanceTotalGrossElement;

        public void ClickRejectButton()
        {
            ScrollTo(RjectButtonElement);
            RjectButtonElement.Click();
        }

        public void ClickAcceptButton()
        {
            ScrollTo(AcceptButtonElement);
            AcceptButtonElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 3);
        }

        public BankContractsPage ClickFinalRejectButton()
        {
            ScrollTo(FinalRejectButtonElement);
            FinalRejectButtonElement.Click();

            return GetTabInstance<BankContractsPage>(Driver);
        }

        public BankContractsPage ClickFinalAcceptButton()
        {
            ScrollTo(FinalAcceptButtonElement);
            FinalAcceptButtonElement.Click();

            return GetTabInstance<BankContractsPage>(Driver);
        }

        public void SelectRejectionReason(string reason)
        {
            SelectFromDropdown(BankRejectReasonElement, reason);
        }

        public void IsAcceptButtonAvailable()
        {
            if (AcceptButtonElement == null)
                throw new NullReferenceException("Create Accept Button");
        }

        public void IsRejectButtonAvailable()
        {
            if (AcceptButtonElement == null)
                throw new NullReferenceException("Create Reject Button");
        }

        public void VerifyThatTheContractDataIsEqualToProposalCreatedByDealer()
        {
            TestCheck.AssertIsEqual(CustomerCompanyRegistrationElement.Text, SpecFlow.GetContext("DealerProposalSummaryCustomerCompanyRegistrationElement"), "CustomerCompanyRegistration is not correct");
            TestCheck.AssertIsEqual(CustomerBankNameElement.Text, SpecFlow.GetContext("DealerProposalSummaryCustomerBankNameElement"), "CustomerBankName is not correct");
            TestCheck.AssertIsEqual(CustomerBankAccountElement.Text, SpecFlow.GetContext("DealerProposalSummaryCustomerBankAccountElement"), "CustomerBankAccount is not correct");
            TestCheck.AssertIsEqual(CustomerIbanElement.Text, SpecFlow.GetContext("DealerProposalSummaryCustomerIbanElement"), "CustomerIban is not correct");
            TestCheck.AssertIsEqual(CustomerBICElement.Text, SpecFlow.GetContext("DealerProposalSummaryCustomerBICElement"), "CustomerBIC is not correct");
            TestCheck.AssertIsEqual(CustomerSortCodeElement.Text, SpecFlow.GetContext("DealerProposalSummaryCustomerSortCodeElement"), "CustomerSortCode is not correct");
            TestCheck.AssertIsEqual(CustomerAuthorisedSignatoryElement.Text, SpecFlow.GetContext("DealerProposalSummaryCustomerAuthorisedSignatoryElement"), "CustomerAuthorisedSignatory is not correct");
            TestCheck.AssertIsEqual(CustomerVatNumberElement.Text, SpecFlow.GetContext("DealerProposalSummaryCustomerVatNumberElement"), "CustomerVatNumber is not correct");
            TestCheck.AssertIsEqual(RepeaterModels_DeviceTotalPriceNetElement.Text, SpecFlow.GetContext("DealerProposalSummaryRepeaterModels_DeviceTotalPriceNetElement"), "RepeaterModels_DeviceTotalPriceNet is not correct");
            TestCheck.AssertIsEqual(RepeaterModels_DeviceTotalPriceGrossElement.Text, SpecFlow.GetContext("DealerProposalSummaryRepeaterModels_DeviceTotalPriceGrossElement"), "RepeaterModels_DeviceTotalPriceGross is not correct");
            TestCheck.AssertIsEqual(RepeaterModels_DeviceLeasingTotalNetElement.Text, SpecFlow.GetContext("DealerProposalSummaryDeviceRepeaterModels_DeviceLeasingTotalNetElement"), "RepeaterModels_DeviceLeasingTotalNet is not correct");
            TestCheck.AssertIsEqual(RepeaterModels_DeviceLeasingTotalGrossElement.Text, SpecFlow.GetContext("DealerProposalSummaryRepeaterModels_DeviceLeasingTotalGrossElement"), "RepeaterModels_DeviceLeasingTotalGross is not correct");
            TestCheck.AssertIsEqual(RepeaterModels_ConsumablesTotalPriceNetElement.Text, SpecFlow.GetContext("DealerProposalSummaryRepeaterModels_ConsumablesTotalPriceNetElement"), "RepeaterModels_ConsumablesTotalPriceNet is not correct");
            TestCheck.AssertIsEqual(RepeaterModels_ConsumablesTotalPriceGrossElement.Text, SpecFlow.GetContext("DealerProposalSummaryRepeaterModels_ConsumablesTotalPriceGrossElement"), "RepeaterModels_ConsumablesTotalPriceGross is not correct");
//            TestCheck.AssertIsEqual(DeviceTotalsTotalCostNetElement.Text, SpecFlow.GetContext("DealerProposalSummaryDeviceTotalsTotalCostNetElement"), "DeviceTotalsTotalCostNet is not correct");
//            TestCheck.AssertIsEqual(DeviceTotalsTotalMarginNetElement.Text, SpecFlow.GetContext("DealerProposalSummaryDeviceTotalsTotalMarginNetElement"), "DeviceTotalsTotalMarginNet is not correct");
//            TestCheck.AssertIsEqual(ConsumableTotalsTotalMarginNetElement.Text, SpecFlow.GetContext("DealerProposalSummaryConsumableTotalsTotalMarginNetElement"), "ConsumableTotalsTotalMarginNet is not correct");
//            TestCheck.AssertIsEqual(ConsumableTotalsTotalPriceNetElement.Text, SpecFlow.GetContext("DealerProposalSummaryConsumableTotalsTotalPriceNetElement"), "ConsumableTotalsTotalPriceNet is not correct");
//            TestCheck.AssertIsEqual(ConsumableTotalsTotalMarginGrossElement.Text, SpecFlow.GetContext("DealerProposalSummaryConsumableTotalsTotalMarginGrossElement"), "ConsumableTotalsTotalMarginGross is not correct");
            TestCheck.AssertIsEqual(ConsumableTotalsTotalPriceGrossElement.Text, SpecFlow.GetContext("DealerProposalSummaryConsumableTotalsTotalPriceGrossElement"), "ConsumableTotalsTotalPriceGross is not correct");
//            TestCheck.AssertIsEqual(GrandTotalMarginNetElement.Text, SpecFlow.GetContext("DealerProposalSummaryGrandTotalMarginNetElement"), "GrandTotalMarginNet is not correct");
            TestCheck.AssertIsEqual(GrandTotalPriceNetElement.Text, SpecFlow.GetContext("DealerProposalSummaryGrandTotalPriceNetElement"), "GrandTotalPriceNet is not correct");
            TestCheck.AssertIsEqual(BankNameElement.Text, SpecFlow.GetContext("DealerProposalSummaryBankNameElement"), "BankName is not correct");
            TestCheck.AssertIsEqual(TermLengthElement.Text, SpecFlow.GetContext("DealerProposalSummaryTermLengthElement"), "TermLength is not correct");
            TestCheck.AssertIsEqual(PaymentFrequencyElement.Text, SpecFlow.GetContext("DealerProposalSummaryPaymentFrequencyElement"), "PaymentFrequency is not correct");
            TestCheck.AssertIsEqual(PaymentQuantityElement.Text, SpecFlow.GetContext("DealerProposalSummaryPaymentQuantityElement"), "PaymentQuantity is not correct");
            TestCheck.AssertIsEqual(PaymentAmountNetElement.Text, SpecFlow.GetContext("DealerProposalSummaryPaymentAmountNetElement"), "PaymentAmountNet is not correct");
            TestCheck.AssertIsEqual(PaymentAmountGrossElement.Text, SpecFlow.GetContext("DealerProposalSummaryPaymentAmountGrossElement"), "PaymentAmountGross is not correct");
            TestCheck.AssertIsEqual(RepaymentTotalGrossElement.Text, SpecFlow.GetContext("DealerProposalSummaryRepaymentTotalGrossElement"), "RepaymentTotalGross is not correct");
            TestCheck.AssertIsEqual(HardwareAccessoryPriceElement.Text, SpecFlow.GetContext("DealerProposalSummaryHardwareAccessoryPriceElement"), "HardwareAccessoryPrice is not correct");
            TestCheck.AssertIsEqual(DeliveryInstallationPriceElement.Text, SpecFlow.GetContext("DealerProposalSummaryDeliveryInstallationPriceElement"), "DeliveryInstallationPrice is not correct");
            TestCheck.AssertIsEqual(FinanceChargeElement.Text, SpecFlow.GetContext("DealerProposalSummaryFinanceChargeElement"), "FinanceCharge is not correct");
            TestCheck.AssertIsEqual(FinanceTotalNetElement.Text, SpecFlow.GetContext("DealerProposalSummaryFinanceTotalNetElement"), "FinanceTotalNet is not correct");
            TestCheck.AssertIsEqual(FinanceTotalGrossElement.Text, SpecFlow.GetContext("DealerProposalSummaryFinanceGrossElement"), "FinanceGross is not correct");
        }
    }
}
