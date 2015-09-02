﻿using System;
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



        [FindsBy(How = How.CssSelector, Using = "#content_1_InputCustomerChoiceNew")]
        public IWebElement ConvertCreateNewCustomer;
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
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerName")]
        public IWebElement CompanyNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyNumber_Input")]
        public IWebElement PropertyNumberElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyStreet_Input")]
        public IWebElement PropertyStreetElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputPropertyArea_Input")]
        public IWebElement PropertyAreaElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyTown_Input")]
        public IWebElement PropertyTownElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyPostCode_Input")]
        public IWebElement PropertyPostcodeElement;
        [FindsBy(How = How.Id, Using = "content_1_CustomerManage_InputRegion_Input")]
        public IWebElement RegionElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonFirstName_Input")]
        public IWebElement FirstNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonLastName_Input")]
        public IWebElement LastNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonTelephone_Input")]
        public IWebElement TelephoneElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonEmail_Input")]
        public IWebElement EmailElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonTitle_Input")]
        public IWebElement ContactTitleElement;
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

        public void CreateANewCustomerInConvertProcess()
        {
            if(ConvertCreateNewCustomer == null)
                throw new Exception("Cannot choose customer creation option");
            ConvertCreateNewCustomer.Click();
            NextElement.Click();
        }

        public string GetDealerName()
        {
            return GetElementByCssSelector(".wrapper.cf span[style*=\"text-align\"]").Text;

        }

        public void CustomerCanOrderConsumables()
        {
            CanOrderConsumablesTick.Click();
         }

        public void SelectALegalForm()
        {
            if (GetDealerName().Contains("abmelden"))
            {
                SelectFromDropdown(LegalFormDropdown, "Aktiengesellschaft");

            }
            else if (GetDealerName().Contains("sign out"))
            {
               SelectFromDropdown(LegalFormDropdown, "Church"); 
            }
                
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
            if (GetDealerName().Contains("sign out"))
                SelectFromDropdown(TradingStyleElement, "Non-Regulated");
                WebDriver.Wait(DurationType.Second, 3);
        }

        public void SelectAPaymentType()
        {

            if (GetDealerName().Contains("abmelden"))
            {
                SelectFromDropdown(PaymentTypeDropdown, "Bankeinzug");

            }
            else if (GetDealerName().Contains("sign out"))
            {
                SelectFromDropdown(PaymentTypeDropdown, "Direct Debit");
            }
            
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
            if (GetDealerName().Contains("sign out"))
                 ClearAndType(BankPropertyNumberElement, "12345");
        }

        public void EnterBankPropertyStreet()
        {
            if (GetDealerName().Contains("sign out"))
                 ClearAndType(BankPropertyStreetElement, "abc");
        }

        public void EnterBankPropertyTown()
        {
            if (GetDealerName().Contains("sign out"))
                 ClearAndType(BankPropertyTownElement, "abc");
        }

        public void EnterBankPropertyPostcode()
        {
            if (GetDealerName().Contains("sign out"))
                 ClearAndType(BankPropertyPostcodeElement, "M1 3ED");
        }

        public void FillAllCustomerDetailsOnConvert()
        {
            CreateANewCustomerInConvertProcess();
            FillOrganisationDetails();
            FillOrganisationContactDetail();


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


        public void FillOrganisationDetails()
        {
            EnterCompanyName();
            EnterPropertyNumber();
            EnterPropertyStreet();
            //EnterPropertyArea();
            EnterPropertyTown();
            EnterPropertyPostCode();
            //SelectRegionFromDropdown("Greater Manchester");
           
        }

        public void EnterContactFirstName()
        {
            FirstNameElement.SendKeys(MpsUtil.FirstName());
        }

        public void EnterContactSurName()
        {
            LastNameElement.SendKeys(MpsUtil.SurName());
        }

        public void EnterContactTelephone()
        {
            TelephoneElement.SendKeys(MpsUtil.CompanyTelephone());
        }

        public void EnterContactEmailAdress()
        {
            var email = MpsUtil.GenerateUniqueEmail();
            SpecFlow.SetContext("DealerLatestCreatedCustomerEmail", email);
            EmailElement.SendKeys(email);
        }

        public void FillOrganisationContactDetail()
        {
            SelectTitleFromDropdown();
            EnterContactFirstName();
            EnterContactSurName();
            //EnterContactPosition();
            EnterContactTelephone();
            EnterContactEmailAdress();
        }

        

        public void EnterCompanyName()
        {
            CompanyNameElement.SendKeys(MpsUtil.CompanyName());
        }

        public void EnterPropertyNumber()
        {
            PropertyNumberElement.SendKeys(MpsUtil.PropertyNumber());
        }

        public void EnterPropertyStreet()
        {
            PropertyStreetElement.SendKeys(MpsUtil.PropertyStreet());
        }

        public void EnterPropertyArea()
        {
            PropertyAreaElement.SendKeys(MpsUtil.FirstName());
        }

        public void EnterPropertyTown()
        {
            PropertyTownElement.SendKeys(MpsUtil.PropertyTown());
        }

        public void EnterPropertyPostCode()
        {
            PropertyPostcodeElement.SendKeys(MpsUtil.PostCode());
        }

        public void SelectRegionFromDropdown(string region)
        {
            SelectFromDropdown(RegionElement, region);
        }

        public void SelectTitleFromDropdown()
        {
            if (ContactTitleElement.Displayed)
                //SelectFromDropdownByValue(ContactTitleElement, MpsUtil.ContactTitle());
                SelectFromDropdownByValue(ContactTitleElement, "0002");
        }


        public ConvertProposalTermAndType ProceedToConvertProposalTermAndType()
        {
            NextElement.Click();
            return GetInstance<ConvertProposalTermAndType>(Driver);
        }
        
    }
}
