using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class ConvertProposalCustomerInfo : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }


        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonCanOrderConsumables_Label")]
        public IWebElement CanOrderConsumablesTick;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerLegalForm_Input")]
        public IWebElement LegalFormDropdown;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerCompanyRegistrationNumber_Input")]
        public IWebElement CompanyRegistrationNumberField;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerVatRegistrationNumber_Input")]
        public IWebElement VATNumberField;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerTradingStyle_Input")]
        public IWebElement TradingStyleElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerAuthorisedSignatory_Input")]
        public IWebElement AuthorizedSignatoryElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankPaymentType_Input")]
        public IWebElement PaymentTypeDropdown;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankName_Input")]
        public IWebElement BankNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankAccountNumber_Input")]
        public IWebElement BankAccountNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankSortCode_Input")]
        public IWebElement BankSortCodeElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankIban_Input")]
        public IWebElement IBANElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankBic_Input")]
        public IWebElement BICElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankPropertyNumber_Input")]
        public IWebElement BankPropertyNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankPropertyStreet_Input")]
        public IWebElement BankPropertyStreetElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankPropertyTown_Input")]
        public IWebElement BankPropertyTownElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankPropertyPostCode_Input")]
        public IWebElement BankPropertyPostcodeElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonNext")]
        public IWebElement NextElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityTitle_Input")]
        public IWebElement PrivateLiableTitleElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityFirstName_Input")]
        public IWebElement PrivateLiableFirstNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityLastName_Input")]
        public IWebElement PrivateLiableLastNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityDateOfBirth_Input")]
        public IWebElement PrivateLiableDOBElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityPropertyNumber_Input")]
        public IWebElement PrivateLiablePropertyNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityPropertyStreet_Input")]
        public IWebElement PrivateLiablePropertyStreetElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityPropertyTown_Input")]
        public IWebElement PrivateLiablePropertyTownElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityPropertyPostCode_Input")]
        public IWebElement PrivateLiablePropertyPostCodeElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputPersonalLiabilityRegion_Input")]
        public IWebElement PrivateLiablePropertyRegionElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputCustomerChoiceNew")]
        public IWebElement CreateNewCustomerRadioButtonElement;



        public void IsConvertCustomerInfoScreenDisplayed()
        {
            if(CreateNewCustomerRadioButtonElement == null)
                throw new Exception("Customer Info page for conversion is not displayed");
            AssertElementPresent(CreateNewCustomerRadioButtonElement, "Customer radio button not displayed");
        }


        public void CustomerCanOrderConsumables()
        {
            CanOrderConsumablesTick.Click();
         }

        public void SelectALegalForm()
        {
            SelectFromDropdown(LegalFormDropdown, "Church");
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void SelectAPrivatelyLiableCustomer()
        {
            SelectFromDropdown(LegalFormDropdown, "Limited Company");
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void EnterCompanyRegistration()
        {
            ClearAndType(CompanyRegistrationNumberField, "06488522");
        }

        public void EnterVatNumber()
        {
            ClearAndType(VATNumberField, "135869456");
        }

        public void EnterAuthoriisedSignatoryNumber()
        {
            ClearAndType(AuthorizedSignatoryElement, "Mensha Uston");
        }

        public void SelectATradingStyle()
        {
            SelectFromDropdown(TradingStyleElement, "Non-Regulated");
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void SelectAPaymentType()
        {
            SelectFromDropdown(PaymentTypeDropdown, "Direct Debit");
            //WebDriver.
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void EnterBankName()
        {
            ClearAndType(BankNameElement, "BNP Paribus");
        }

        public void EnterBankAccountNumber()
        {
            ClearAndType(BankAccountNumberElement, "45789635");
        }

        public void EnterBankSortCode()
        {
            ClearAndType(BankSortCodeElement, "014215");
        }

        public void EnterIbanNumber()
        {
            ClearAndType(IBANElement, "GB15MIDL40051512345678");
        }

        public void EnterBicNumber()
        {
            ClearAndType(BICElement, "MIDLGB22");
        }

        public void EnterBankPropertyNumber()
        {
            ClearAndType(BankPropertyNumberElement, "12345");
        }

        public void EnterBankPropertyStreet()
        {
            ClearAndType(BankPropertyStreetElement, "abc");
        }

        public void EnterBankPropertyTown()
        {
            ClearAndType(BankPropertyTownElement, "abc");
        }

        public void EnterBankPropertyPostcode()
        {
            ClearAndType(BankPropertyPostcodeElement, "M1 3ED");
        }

        public void EnterRemainingCustomerInfo()
        {
            SelectALegalForm();
            EnterCompanyRegistration();
            EnterVatNumber();
            SelectATradingStyle();
            EnterAuthoriisedSignatoryNumber();
        }

        public void EnterPrivateLiableCustomerInfo()
        {
            SelectAPrivatelyLiableCustomer();
            EnterCompanyRegistration();
            EnterVatNumber();
            SelectATradingStyle();
            EnterAuthoriisedSignatoryNumber();
        }

        public void EnterAllBankInformation()
        {
            SelectAPaymentType();
            EnterBankName();
            EnterBankAccountNumber();
            EnterBankSortCode();
            EnterIbanNumber();
            EnterBicNumber();
            EnterBankPropertyNumber();
            EnterBankPropertyStreet();
            EnterBankPropertyTown();
            EnterBankPropertyPostcode();
        }

        private void SelectPrivateLiableTitle()
        {
            SelectFromDropdown(PrivateLiableTitleElement, "Mrs");
        }

        private void EnterPrivateLiableFirstName()
        {
            ClearAndType(PrivateLiableFirstNameElement, "Private");
        }

        private void EnterPrivateLiableLastName()
        {
            ClearAndType(PrivateLiableLastNameElement, "Liable");
        }

        private void EnterPrivateLiableDateOfBirth()
        {
            PrivateLiableDOBElement.SendKeys(MpsUtil.DateOfBirth());
        }

        private void EnterPrivatePropertyNumber()
        {
            ClearAndType(PrivateLiablePropertyNumberElement, "25");
        }

        private void EnterPrivatePropertyStreet()
        {
            ClearAndType(PrivateLiablePropertyStreetElement, "Privately Liable");
        }

        private void EnterPrivatePropertyTown()
        {
            ClearAndType(PrivateLiablePropertyTownElement, "Manchester");
        }

        private void EnterPrivatePropertyPostCode()
        {
            ClearAndType(PrivateLiablePropertyPostCodeElement, "M34 5JE");
        }

        private void SelectPrivatePropertyRegion()
        {
            SelectFromDropdown(PrivateLiablePropertyRegionElement, "Greater Manchester");
        }

        public void EnterPrivateLiableInfo()
        {
            SelectPrivateLiableTitle();
            EnterPrivateLiableFirstName();
            EnterPrivateLiableLastName();
            EnterPrivateLiableDateOfBirth();
            EnterPrivatePropertyNumber();
            EnterPrivatePropertyStreet();
            EnterPrivatePropertyTown();
            EnterPrivatePropertyPostCode();
            SelectPrivatePropertyRegion();
            
        }

        public ConvertProposalTermAndType ProceedToConvertProposalTermAndType()
        {
            NextElement.Click();
            return GetInstance<ConvertProposalTermAndType>(Driver);
        }
        
    }
}
