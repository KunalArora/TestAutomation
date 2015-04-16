using System;
using System.Collections;
using System.Collections.Generic;
using Brother.Tests.Selenium.Lib.Pages.MPSTwo;
using Brother.Tests.Selenium.Lib.Properties;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using BrotherWebSitesCore.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BrotherWebSitesCore.Pages.MPSTwo
{
    public class BankUserLandingPage : BasePage
    {
        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string CheckedValue = @"true";
        private const string RejectionComment = @"This contract was rejected";

        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/bank/leasing-factors\"] .media-heading")]
        public IWebElement CloudBankLandingPageLeasingFactor;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/bank/offers-and-contracts\"] .media-heading")]
        public IWebElement CloudBankLandingPageContractButton;
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/bank/offers-and-contracts/signed-offers\"] span")]
        public IWebElement CloudBankSignedOffersLandingPage;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/bank/offers-and-contracts/confirmed-offers\"] span")]
        public IWebElement CloudBankConfirmOffersScreen;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/bank/open-offers\"]")]
        public IWebElement CloudBankOpenOfferScreen;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/bank/offers-and-contracts/rejected-offers\"] span")]
        public IWebElement CloudBankRejectedOfferScreen;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/bank/offers-and-contracts/signed-offers\"] span")]
        public IWebElement CloudBankSignedOfferScreen;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/bank/offers-and-contracts/invoices\"] span")]
        public IWebElement CloudBankInvoicesScreen;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonAccept")]
        public IWebElement BankAcceptButton;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonReject")]
        public IWebElement BankRejectButton;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonOpenOfferAcceptAccept")]
        public IWebElement BankFinalAcceptButton;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonOpenOfferAcceptCancel")]
        public IWebElement BankCancelFinalAcceptButton;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputOpenOfferAcceptCustomerReference_Input")]
        public IWebElement BankCustomerReferenceField;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputOpenOfferAcceptContractReference_Input")]
        public IWebElement BankInternalReferenceField;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputOpenOfferAcceptCompanyName_Input")]
        public IWebElement BankCompanyNameField;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputOpenOfferAcceptCreditCheckCompleted_Input")]
        public IWebElement BankCreditCheckCompletedDateField;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputOpenOfferAcceptCreditValue_Input")]
        public IWebElement BankCreditCheckValueField;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputOpenOfferAcceptValidUntil_Input")]
        public IWebElement BankOfferValidUntilDateField;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputOpenOfferAcceptComment_Input")]
        public IWebElement BankAcceptanceOfferCommentField;
        [FindsBy(How = How.CssSelector, Using = "td[id*=\"content_1_ContractList_List_LeadCodeReference\"]")]
        public IList<IWebElement> AcceptedContractReferenceNumber;
        [FindsBy(How = How.CssSelector, Using = "td[id*=\"content_1_ContractList_List_ContractName\"]")]
        public IList<IWebElement> AcceptedContractName;
        [FindsBy(How = How.Id, Using = "content_1_InputContractReference_Input")]
        public IWebElement BankContractReferenceField;
        [FindsBy(How = How.Id, Using = "content_1_InputSentByPost_Input")]
        public IWebElement BankSendByPostCheckBox;
        [FindsBy(How = How.Id, Using = "content_1_InputStartDateConfirmed_Input")]
        public IWebElement BankStartDateConfirmedCheckBox;
        [FindsBy(How = How.Id, Using = "content_1_InputTermsAndConditionsSigned_Input")]
        public IWebElement BankTermsAndConditionsSignedCheckBox;
        [FindsBy(How = How.Id, Using = "content_1_InputMachinesHandedOver_Input")]
        public IWebElement BankInputMachinesHandedOverCheckBox;
        [FindsBy(How = How.Id, Using = "content_1_InputResellerInvoicing_Input")]
        public IWebElement BankInputResellerInvoicingCheckBox;
        [FindsBy(How = How.Id, Using = "content_1_InputBrotherInvoicing_Input")]
        public IWebElement BankInputBrotherInvoicingCheckBox;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSave")]
        public IWebElement BankMaintainOfferSaveButton;
        [FindsBy(How = How.Id, Using = "content_1_InputOpenOfferRejectReason_Input")]
        public IWebElement BankRejectReason;
        [FindsBy(How = How.Id, Using = "content_1_InputOpenOfferRejectComment_Input")]
        public IWebElement BankRejectComment;
        [FindsBy(How = How.Id, Using = "content_1_ButtonOpenOfferRejectReject")]
        public IWebElement BankFinalRejectButton;
        [FindsBy(How = How.Id, Using = "content_1_ButtonOpenOfferRejectCancel")]
        public IWebElement BankCancelFinalRejectButton;
        
        
        

        public void IsBankLandingPageDisplayed()
        {
            if (CloudBankLandingPageLeasingFactor == null)
                throw new NullReferenceException("Bank landing page leasing factor is not displayed");
            if (CloudBankLandingPageContractButton == null)
                throw new NullReferenceException("Bank landing page Contract button is not displayed");

            AssertElementPresent(CloudBankLandingPageLeasingFactor, "Bank landing leasing factor button");
            AssertElementPresent(CloudBankLandingPageContractButton, "Bank landing Contract button");
            CloudBankLandingPageContractButton.Click();
        }

        public void IsBankSignedOffersLandingPageDisplayed()
        {
            if (CloudBankSignedOffersLandingPage == null)
                throw new NullReferenceException("Bank signed offers page is not displayed");

            AssertElementPresent(CloudBankSignedOffersLandingPage, "Bank signed offers screen");
        }


        public void StartTheAcceptanceProcess(IWebDriver driver)
        {
            ActionsModule.ClickOnTheActionsDropdown(driver);
            WebDriver.Wait(Helper.DurationType.Second, 3);
            ActionsModule.NavigateToBankContractSummary(driver);
            WebDriver.Wait(Helper.DurationType.Second, 3);
        }

        public void StartMaintainOfferProcess(IWebDriver driver)
        {
            ActionsModule.ClickOnTheActionsDropdown(driver);
            WebDriver.Wait(Helper.DurationType.Second, 3);
            ActionsModule.NavigateToMaintainOfferScreen(driver);
            WebDriver.Wait(Helper.DurationType.Second, 3);
        }

   
        public void ClickOnAcceptanceButton()
        {
            if (BankAcceptButton == null)
                throw new NullReferenceException("Bank Acceptance button is not visible");
            BankAcceptButton.Click();
        }

        public void ClickOnRejectButton()
        {
            if (BankRejectButton == null)
                throw new NullReferenceException("Bank Reject button is not visible");
            BankRejectButton.Click();
        }

        public void FillAcceptanceForm()
        {
            if(BankCustomerReferenceField == null)
                throw new NullReferenceException("Customer reference field is not displayed");
            if (BankInternalReferenceField == null)
                throw new NullReferenceException("Bank Internal reference field is not displayed");
            if (BankCompanyNameField == null)
                throw new NullReferenceException("Company Name field is not displayed");
            if (BankCreditCheckCompletedDateField == null)
                throw new NullReferenceException("Credit check completion field is not displayed");
            if (BankCreditCheckValueField == null)
                throw new NullReferenceException("Credit check value field is not displayed");
            if (BankOfferValidUntilDateField == null)
                throw new NullReferenceException("Offer valid until field is not displayed");
            if (BankAcceptanceOfferCommentField == null)
                throw new NullReferenceException("Bank comment field is not displayed");

            BankCustomerReferenceField.SendKeys(MpsUtil.CustomerReference());
            BankInternalReferenceField.SendKeys(MpsUtil.BankInternalReference());
            TestCheck.AssertIsNotNullOrEmpty(BankCompanyNameField.GetAttribute("value"), "Bank Company Name Field");
            BankCreditCheckCompletedDateField.SendKeys(MpsUtil.SomeDaysFromToday());
            ClearAndType(BankCreditCheckValueField, "2500");
            BankOfferValidUntilDateField.SendKeys(MpsUtil.SomeDaysFromToday());
            BankAcceptanceOfferCommentField.SendKeys("Offer accepted");

        }

        public void FillRejectionForm()
        {
            if(BankRejectComment == null)
                throw new NullReferenceException("Bank contract reject comment box is not displayed");
            if(BankFinalRejectButton == null)
                throw new NullReferenceException("Bank contract final reject confirmation button is not displayed");
            if(BankRejectReason == null)
                throw new NullReferenceException("Bank contract reject reason dropdown is not displayed");

            SelectFromDropdownByValue(BankRejectReason, new Random().Next(1, 3).ToString());
            BankRejectComment.SendKeys(RejectionComment);
            BankFinalRejectButton.Click();
        }

        public void NavigateToBankConfirmedOffers()
        {
            if (CloudBankConfirmOffersScreen == null)
                throw new NullReferenceException("Confirmed Offer tab is not displayed");
            CloudBankConfirmOffersScreen.Click();
        }

        public void NavigateToBankRejectOffersScreen()
        {
            if (CloudBankRejectedOfferScreen == null)
                throw new NullReferenceException("Confirmed Offer tab is not displayed");
            CloudBankRejectedOfferScreen.Click();
        }

        public void NavigateToBankSignedOffers()
        {
            if (CloudBankSignedOfferScreen == null)
                throw new NullReferenceException("Signed Offer tab is not displayed");
            CloudBankSignedOfferScreen.Click();
        }

        public void FinalAcceptanceProcess()
        {
            if(BankFinalAcceptButton == null)
                throw new NullReferenceException("Final Acceptance button is not visible");

            BankFinalAcceptButton.Click();
        }

        public void VerifyThatContractHasBeenApproved()
        {
            WebDriver.Wait(Helper.DurationType.Second, 5);
            //IsBankLandingPageDisplayed();
            VerifyContractIsNoLongerOnOpenOffer();
            NavigateToBankConfirmedOffers();
            WebDriver.Wait(Helper.DurationType.Second, 3);
            VerifyContractIsNowOnConfirmedOffer();

        }

        public void VerifyThatContractHasBeenRejected()
        {
            WebDriver.Wait(Helper.DurationType.Second, 5);
            //IsBankLandingPageDisplayed();
            VerifyContractIsNoLongerOnOpenOffer();
            NavigateToBankRejectOffersScreen();
            WebDriver.Wait(Helper.DurationType.Second, 3);
            VerifyContractIsNowOnRejectedOffer();

        }

        public void VerifyThatContractHasBeenSigned()
        {
            WebDriver.Wait(Helper.DurationType.Second, 3);
            VerifyContractIsNoLongerOnOpenOffer();
            NavigateToBankConfirmedOffers();
            WebDriver.Wait(Helper.DurationType.Second, 3);
            VerifyContractIsNoLongerOnConfirmedOffer();
            NavigateToBankSignedOffers();
            VerifyContractIsNowOnSignedOffer();

        }

        private void VerifyContractIsNowOnRejectedOffer()
        {
            VerifyContractIsNowOnConfirmedOffer();
        }

        private void VerifyContractIsNowOnSignedOffer()
        {
            VerifyContractIsNowOnConfirmedOffer();
        }

        private void VerifyContractIsNoLongerOnConfirmedOffer()
        {
            VerifyContractIsNoLongerOnOpenOffer();
        }

        private void VerifyContractIsNoLongerOnOpenOffer()
        {
            if (AcceptedContractReferenceNumber == null)
                throw new NullReferenceException("Contract Reference is not displayed");
            
            var enteredContractRef = EnteredContractRef();
            var refContainer = new ArrayList();

            foreach (var reference in AcceptedContractReferenceNumber)
            {
                refContainer.Add(reference.Text);
            }
            TestCheck.AssertIsEqual(false, refContainer.Contains(enteredContractRef), "Verify contract is no longer on open offer");

        }

        private static string EnteredContractRef()
        {
            var enteredContractRef = SpecFlow.GetContext("GeneratedLeadCodeReference");
            return enteredContractRef;
        }

        private void VerifyContractIsNowOnConfirmedOffer()
        {
            if (AcceptedContractReferenceNumber == null)
                throw new NullReferenceException("Contract Reference is not displayed");
            if (AcceptedContractName == null)
                throw new NullReferenceException("Contract Name is not displayed");

            var enteredContractName = SpecFlow.GetContext("GeneratedProposalName");
            var enteredContractRef = EnteredContractRef();
            var refContainer = new ArrayList();
            var nameContainer = new ArrayList();

            foreach (var reference in AcceptedContractReferenceNumber)
            {
                refContainer.Add(reference.Text);
            }

            foreach (var name in AcceptedContractName)
            {
                nameContainer.Add(name.Text);
            }

            TestCheck.AssertIsEqual(true, refContainer.Contains(enteredContractRef), "Is contract ref present");
            TestCheck.AssertIsEqual(true, nameContainer.Contains(enteredContractName), "Is contract name present");
        }

        public void MaintainContractOffer()
        {
            if(BankContractReferenceField == null)
                throw new NullReferenceException("Bank Contract Reference Field not displayed");
            if (BankSendByPostCheckBox == null)
                throw new NullReferenceException("Bank Send By Post CheckBox not displayed");
            if (BankStartDateConfirmedCheckBox == null)
                throw new NullReferenceException("Bank Contract Reference Field not displayed");
            if (BankTermsAndConditionsSignedCheckBox == null)
                throw new NullReferenceException("Bank Terms And Conditions Signed CheckBox not displayed");
            if (BankInputMachinesHandedOverCheckBox == null)
                throw new NullReferenceException("Bank Input Machines Handed Over CheckBox not displayed");
            if (BankInputResellerInvoicingCheckBox == null)
                throw new NullReferenceException("Bank Input Reseller Invoicing CheckBox not displayed");
            if (BankInputBrotherInvoicingCheckBox == null)
                throw new NullReferenceException("Bank Input Brother Invoicing CheckBox not displayed");
            if (BankMaintainOfferSaveButton == null)
                throw new NullReferenceException("Bank Maintain Offer Save Button not displayed");

            TestCheck.AssertIsNotNullOrEmpty(BankContractReferenceField.GetAttribute("value"), "Bank Contract Reference");
            
            //Check all checkboxes
            BankSendByPostCheckBox.Click();
            BankStartDateConfirmedCheckBox.Click();
            BankTermsAndConditionsSignedCheckBox.Click();
            BankInputMachinesHandedOverCheckBox.Click();
            BankInputResellerInvoicingCheckBox.Click();
            BankInputBrotherInvoicingCheckBox.Click();
            BankMaintainOfferSaveButton.Click();

            WebDriver.Wait(Helper.DurationType.Second, 5);
         }

        public void VerifyMaintainOfferCheckboxesAreChecked(IWebDriver driver)
        {
            StartMaintainOfferProcess(driver);

            AssertElementIsChecked(BankSendByPostCheckBox, CheckedValue, "");
            AssertElementIsChecked(BankStartDateConfirmedCheckBox, CheckedValue, "");
            AssertElementIsChecked(BankTermsAndConditionsSignedCheckBox, CheckedValue, "");
            AssertElementIsChecked(BankInputMachinesHandedOverCheckBox, CheckedValue, "");
            AssertElementIsChecked(BankInputResellerInvoicingCheckBox, CheckedValue, "");
            AssertElementIsChecked(BankInputBrotherInvoicingCheckBox, CheckedValue, "");

            BankMaintainOfferSaveButton.Click();

            WebDriver.Wait(Helper.DurationType.Second, 5);
        }

    }
}
