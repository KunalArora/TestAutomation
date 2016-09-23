using System;
using System.Collections.Generic;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverContractsSummaryPage : BasePage
    {
        public static string Url = "/mps/local-office/contracts/summary";
        private const string AcceptancePanel = @".js-mps-acceptance-panel";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_ButtonReject")]
        public IWebElement RjectButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonAccept")]
        public IWebElement AcceptButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonOpenOfferRejectReject")]
        public IWebElement FinalRejectButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonContractAcceptAccept")]
        public IWebElement FinalAcceptButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_InputOpenOfferRejectReason_Input")]
        public IWebElement BankRejectReasonElement;
        [FindsBy(How = How.Id, Using = "content_1_InputOpenOfferRejectComment_Input")]
        public IWebElement BankRejectCommentElement;
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
//        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeviceTotalsTotalCostNet")]
//        public IWebElement DeviceTotalsTotalCostNetElement;
//        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeviceTotalsTotalMarginNet")]
//        public IWebElement DeviceTotalsTotalMarginNetElement;
//        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalMarginNet")]
//        public IWebElement ConsumableTotalsTotalMarginNetElement;
//        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalPriceNet")]
//        public IWebElement ConsumableTotalsTotalPriceNetElement;
//        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalMarginGross")]
//        public IWebElement ConsumableTotalsTotalMarginGrossElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalPriceGross")]
        public IWebElement ConsumableTotalsTotalPriceGrossElement;
//        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_GrandTotalMarginNet")]
//        public IWebElement GrandTotalMarginNetElement;
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
        [FindsBy(How = How.Id, Using = "content_1_ComponentContractReviewedAcceptancePanel_InputApproveCustomerReference_Input")]
        public IWebElement CustomerReferenceElement;
        [FindsBy(How = How.Id, Using = "content_1_ComponentContractReviewedAcceptancePanel_InputApproveContractReference_Input")]
        public IWebElement ContractReferenceElement;
        [FindsBy(How = How.Id, Using = "content_1_ComponentContractReviewedAcceptancePanel_InputApproveCreditValue_Input")]
        public IWebElement CreditValueElement;
        
        

        public void ClickRejectButton()
        {
            ScrollTo(RjectButtonElement);
            RjectButtonElement.Click();
        }

        public void ClickAcceptButton()
        {
            ScrollTo(AcceptButtonElement);
            AcceptButtonElement.Click();
            WebDriver.Wait(DurationType.Second, 3);
        }

        public LocalOfficeApproverContractsPage ClickFinalRejectButton()
        {
            ScrollTo(FinalRejectButtonElement);
            FinalRejectButtonElement.Click();

            return GetTabInstance<LocalOfficeApproverContractsPage>(Driver);
        }

        public LocalOfficeApproverContractsPage ClickFinalAcceptButton()
        {
            ScrollTo(FinalAcceptButtonElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, FinalAcceptButtonElement);
            //FinalAcceptButtonElement.Click();

            return GetTabInstance<LocalOfficeApproverContractsPage>(Driver);
        }

        public void EnterContractApprovalDetails()
        {
            try
            {
                if (!GetElementByCssSelector(AcceptancePanel, 5).Displayed) return;
                EnterCustomerReference();
                EnterContractReference();
                EnterCreditValue();
            }
            catch (NullReferenceException wbe)
            {
                MsgOutput(String.Format("Element was not displayed as a result of [{0}]", wbe.Message));
            }
                                                           
        }

        private void EnterCustomerReference()
        {
            var customerReference = "CusRef" + DateTime.Now.ToString("MMdHHmmss");
            
            ClearAndType(CustomerReferenceElement, customerReference);
        }

        private void EnterContractReference()
        {
            var customerReference = "ContractRef" + DateTime.Now.ToString("MMdHHmmss");

            ClearAndType(ContractReferenceElement, customerReference);
        }

        private void EnterCreditValue()
        {
            var credit = CreditValueElement.GetAttribute("value");
            if (string.IsNullOrWhiteSpace(credit) || credit.Equals("0,00"))
            {
                ClearAndType(CreditValueElement, "10.000,00"); 
            }
            else if (string.IsNullOrWhiteSpace(credit) || credit.Equals("0.00"))
            {
                ClearAndType(CreditValueElement, "10,000.00"); 
            }
            
        }


        private string Reason()
        {
            var reason = "";

            if (IsAustriaSystem() || IsGermanSystem())
            {
                reason = "Andere";

            }
            else if (IsUKSystem() || IsIrelandSystem())
            {
                reason = "Expired";

            }
            else if (IsFranceSystem())
            {
                reason = "Expiré";
            }
            else if (IsItalySystem())
            {
                reason = "Scaduta";
            }
            else if (IsItalySystem())
            {
                reason = "Caducado";
            }
            else if (IsSpainSystem())
            {
                reason = "Otro";
            }
            else if (IsSwedenSystem())
            {
                reason = "Annat";
            }
            else if (IsNetherlandSystem())
            {
                reason = "Overig";
            }
            else if (IsDenmarkSystem())
            {
                reason = "Andet";
            }
            else if (IsPolandSystem())
            {
                reason = "Inny";
            }
            else if (IsBelgiumSystem())
            {
                reason = BelgianLanguage();
            }
            return reason;
        }


        private String BelgianLanguage()
        {
            string lang;
            string language;

            try
            {
                language = SpecFlow.GetContext("BelgianLanguage");
            }
            catch (KeyNotFoundException)
            {

                language = "French";
            }

            switch (language)
            {
                case "French":
                    lang = "Expiré";
                    break;
                case "Dutch":
                    lang = "Verlopen";
                    break;

                default:
                    lang = "Expiré";
                    break;
            }

            return lang;
        }

        public void SelectRejectionReason()
        {
            SelectFromDropdown(BankRejectReasonElement, Reason());
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
            VerifyCustomerCompanyRegistrationIsCorrect();
            VerifyCustomerBankNameAccountIsCorrect();
            VerifyCustomerBankAccountIsCorrect();
            VerifyCustomerIbanIsCorrect();
            VerifyCustomerBicIsCorrect();
            VerifyCustomerSortCodeIsCorrect();
            VerifyCustomerAuthorisedSignatoryIsCorrect();
            VerifyCustomerVatNumberIsCorrect();
            VerifyTotalPriceNetIsCorrect();
            VerifyRepeaterModels_DeviceTotalPriceGrossIsCorrect();
            VerifyRepeaterModels_DeviceLeasingTotalNetIsCorrect();
            VerifyRepeaterModels_DeviceLeasingGrossIsCorrect();
            VerifyRepeaterModels_ConsumablesTotalPriceNetIsCorrect();
            VerifyRepeaterModels_ConsumablesTotalPriceGrossIsCorrect();
            VerifyConsumableTotalsTotalPriceGrossIsCorrect();
            VerifyGrandTotalPriceNetIsCorrect();
            VerifyBankNameIsCorrect();
            VerifyTermLengthIsCorrect();
            VerifyPaymentFrequencyIsCorrect();
            VerifyPaymentQuantityIsCorrect();
            VerifyPaymentAmmountNetIsCorrect();
            VerifyPaymentAmmountGrossElementIsCorrect();
            VerifyRepaymentTotalGrossIsCorrect();
            VerifyHardwareAccessoryPriceIsCorrect();
            VerifyDeliveryInstallationPriceIsCorrect();
            VerifyFinanceChargeIsCorrect();
            VerifyFinanceTotalNetIsCorrect();
            VerifyFinanceGrossIsCorrect();
        }

        private void VerifyFinanceGrossIsCorrect()
        {
            TestCheck.AssertIsEqual(FinanceTotalGrossElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryFinanceGrossElement"), "FinanceGross is not correct");
        }

        private void VerifyFinanceTotalNetIsCorrect()
        {
            TestCheck.AssertIsEqual(FinanceTotalNetElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryFinanceTotalNetElement"), "FinanceTotalNet is not correct");
        }

        private void VerifyFinanceChargeIsCorrect()
        {
            TestCheck.AssertIsEqual(FinanceChargeElement.Text, SpecFlow.GetContext("DealerProposalSummaryFinanceChargeElement"),
                "FinanceCharge is not correct");
        }

        private void VerifyDeliveryInstallationPriceIsCorrect()
        {
            TestCheck.AssertIsEqual(DeliveryInstallationPriceElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryDeliveryInstallationPriceElement"),
                "DeliveryInstallationPrice is not correct");
        }

        private void VerifyHardwareAccessoryPriceIsCorrect()
        {
            TestCheck.AssertIsEqual(HardwareAccessoryPriceElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryHardwareAccessoryPriceElement"),
                "HardwareAccessoryPrice is not correct");
        }

        private void VerifyRepaymentTotalGrossIsCorrect()
        {
            TestCheck.AssertIsEqual(RepaymentTotalGrossElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryRepaymentTotalGrossElement"), "RepaymentTotalGross is not correct");
        }

        private void VerifyPaymentAmmountGrossElementIsCorrect()
        {
            TestCheck.AssertIsEqual(PaymentAmountGrossElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryPaymentAmountGrossElement"), "PaymentAmountGross is not correct");
        }

        private void VerifyPaymentAmmountNetIsCorrect()
        {
            TestCheck.AssertIsEqual(PaymentAmountNetElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryPaymentAmountNetElement"), "PaymentAmountNet is not correct");
        }

        private void VerifyPaymentQuantityIsCorrect()
        {
            TestCheck.AssertIsEqual(PaymentQuantityElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryPaymentQuantityElement"), "PaymentQuantity is not correct");
        }

        private void VerifyPaymentFrequencyIsCorrect()
        {
            TestCheck.AssertIsEqual(PaymentFrequencyElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryPaymentFrequencyElement"), "PaymentFrequency is not correct");
        }

        private void VerifyTermLengthIsCorrect()
        {
            TestCheck.AssertIsEqual(TermLengthElement.Text, SpecFlow.GetContext("DealerProposalSummaryTermLengthElement"),
                "TermLength is not correct");
        }

        private void VerifyBankNameIsCorrect()
        {
            TestCheck.AssertIsEqual(BankNameElement.Text, SpecFlow.GetContext("DealerProposalSummaryBankNameElement"),
                "BankName is not correct");
        }

        private void VerifyGrandTotalPriceNetIsCorrect()
        {
            TestCheck.AssertIsEqual(GrandTotalPriceNetElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryGrandTotalPriceNetElement"), "GrandTotalPriceNet is not correct");
        }

        private void VerifyConsumableTotalsTotalPriceGrossIsCorrect()
        {
            TestCheck.AssertIsEqual(ConsumableTotalsTotalPriceGrossElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryConsumableTotalsTotalPriceGrossElement"),
                "ConsumableTotalsTotalPriceGross is not correct");
        }

        private void VerifyRepeaterModels_ConsumablesTotalPriceGrossIsCorrect()
        {
            TestCheck.AssertIsEqual(RepeaterModels_ConsumablesTotalPriceGrossElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryRepeaterModels_ConsumablesTotalPriceGrossElement"),
                "RepeaterModels_ConsumablesTotalPriceGross is not correct");
        }

        private void VerifyRepeaterModels_ConsumablesTotalPriceNetIsCorrect()
        {
            TestCheck.AssertIsEqual(RepeaterModels_ConsumablesTotalPriceNetElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryRepeaterModels_ConsumablesTotalPriceNetElement"),
                "RepeaterModels_ConsumablesTotalPriceNet is not correct");
        }

        private void VerifyRepeaterModels_DeviceLeasingGrossIsCorrect()
        {
            TestCheck.AssertIsEqual(RepeaterModels_DeviceLeasingTotalGrossElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryRepeaterModels_DeviceLeasingTotalGrossElement"),
                "RepeaterModels_DeviceLeasingTotalGross is not correct");
        }

        private void VerifyRepeaterModels_DeviceLeasingTotalNetIsCorrect()
        {
            TestCheck.AssertIsEqual(RepeaterModels_DeviceLeasingTotalNetElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryDeviceRepeaterModels_DeviceLeasingTotalNetElement"),
                "RepeaterModels_DeviceLeasingTotalNet is not correct");
        }

        private void VerifyRepeaterModels_DeviceTotalPriceGrossIsCorrect()
        {
            TestCheck.AssertIsEqual(RepeaterModels_DeviceTotalPriceGrossElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryRepeaterModels_DeviceTotalPriceGrossElement"),
                "RepeaterModels_DeviceTotalPriceGross is not correct");
        }

        private void VerifyTotalPriceNetIsCorrect()
        {
            TestCheck.AssertIsEqual(RepeaterModels_DeviceTotalPriceNetElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryRepeaterModels_DeviceTotalPriceNetElement"),
                "RepeaterModels_DeviceTotalPriceNet is not correct");
        }

        private void VerifyCustomerVatNumberIsCorrect()
        {
            TestCheck.AssertIsEqual(CustomerVatNumberElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryCustomerVatNumberElement"), "CustomerVatNumber is not correct");
        }

        private void VerifyCustomerAuthorisedSignatoryIsCorrect()
        {
            TestCheck.AssertIsEqual(CustomerAuthorisedSignatoryElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryCustomerAuthorisedSignatoryElement"),
                "CustomerAuthorisedSignatory is not correct");
        }

        private void VerifyCustomerSortCodeIsCorrect()
        {
            TestCheck.AssertIsEqual(CustomerSortCodeElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryCustomerSortCodeElement"), "CustomerSortCode is not correct");
        }

        private void VerifyCustomerBicIsCorrect()
        {
            TestCheck.AssertIsEqual(CustomerBICElement.Text, SpecFlow.GetContext("DealerProposalSummaryCustomerBICElement"),
                "CustomerBIC is not correct");
        }

        private void VerifyCustomerIbanIsCorrect()
        {
            TestCheck.AssertIsEqual(CustomerIbanElement.Text, SpecFlow.GetContext("DealerProposalSummaryCustomerIbanElement"),
                "CustomerIban is not correct");
        }

        private void VerifyCustomerBankAccountIsCorrect()
        {
            TestCheck.AssertIsEqual(CustomerBankAccountElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryCustomerBankAccountElement"), "CustomerBankAccount is not correct");
        }

        private void VerifyCustomerBankNameAccountIsCorrect()
        {
            TestCheck.AssertIsEqual(CustomerBankNameElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryCustomerBankNameElement"), "CustomerBankName is not correct");
        }

        private void VerifyCustomerCompanyRegistrationIsCorrect()
        {
            TestCheck.AssertIsEqual(CustomerCompanyRegistrationElement.Text,
                SpecFlow.GetContext("DealerProposalSummaryCustomerCompanyRegistrationElement"),
                "CustomerCompanyRegistration is not correct");
        }
    }
}
