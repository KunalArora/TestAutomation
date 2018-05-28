using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerCustomersManagePage : BasePage, IPageObject
    {
        #region ViewModels
        [DataContract]
        internal class OrganisationBankDetail
        {
            [DataMember]
            public string PaymentType { get; set; }
            [DataMember]
            public string BankAccountNumber { get; set; }
            [DataMember]
            public string BankSortCode { get; set; }
            [DataMember]
            public string IBAN { get; set; }
            [DataMember]
            public string BIC { get; set; }
            [DataMember]
            public string BankName { get; set; }
            [DataMember]
            public string PropertyNaumber { get; set; }
            [DataMember]
            public string PropertyStreet { get; set; }
            [DataMember]
            public string PropertyArea { get; set; }
            [DataMember]
            public string PropertyTown { get; set; }
            [DataMember]
            public string PropertyPostcode { get; set; }
            [DataMember]
            public string PropertyCountry { get; set; }
            [DataMember]
            public string Region { get; set; }
        }

        [DataContract]
        internal class OrganisationContactDetail
        {
            [DataMember]
            public string Title { get; set; }
            [DataMember]
            public string FirstName { get; set; }
            [DataMember]
            public string LastName { get; set; }
            [DataMember]
            public string Position { get; set; }
            [DataMember]
            public string Telephone { get; set; }
            [DataMember]
            public string Mobile { get; set; }
            [DataMember]
            public string Email { get; set; }
            [DataMember]
            public string CanOrderConsumablesForAllDevices { get; set; }
        }

        [DataContract]
        internal class OrganisationDetail
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public string PropertyNumber { get; set; }
            [DataMember]
            public string PropertyStreet { get; set; }
            [DataMember]
            public string PropertyArea { get; set; }
            [DataMember]
            public string PropertyTown { get; set; }
            [DataMember]
            public string PropertyPostcode { get; set; }
            [DataMember]
            public string PropertyCountry { get; set; }
            [DataMember]
            public string Region { get; set; }
            [DataMember]
            public string CostCentre { get; set; }
            [DataMember]
            public string LegalForm { get; set; }
            [DataMember]
            public string CompanyRegistrationNumber { get; set; }
            [DataMember]
            public string VatRegistrationNumber { get; set; }
            [DataMember]
            public string TradingStyle { get; set; }
            [DataMember]
            public string AuthorisedSignatory { get; set; }
        }

#endregion


        public static string URL = "/mps/dealer/customers/manage";
        private const string _url = "/mps/dealer/customers/manage";
        private const string _validationElementSelector = "div.js-mps-person-manage-container";

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        
        public const string DealerLatestCreatedOrganization = "DealerLatestCreatedOrganization";
        public const string DealerLatestCreatedContact = "DealerLatestCreatedContact";
        public const string DealerLatestCreatedBank = "DealerLatestCreatedBank";
        private const string Germanurl = @"online.de";

        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonTitle_Input")]
        public IWebElement ContactTitleElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonFirstName_Input")]
        public IWebElement FirstNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonLastName_Input")]
        public IWebElement LastNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonTelephone_Input")]
        public IWebElement TelephoneElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonEmail_Input")]
        public IWebElement EmailElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonCanOrderConsumables_Input")]
        public IWebElement OrderingPersonElement;
        [FindsBy(How = How.Id, Using = "content_1_NewOrganisation")]
        public IWebElement NewOrganisationElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerName")]
        public IWebElement CompanyNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_CustomerLocation_InputNumber_Input")]
        public IWebElement PropertyNumberElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_CustomerLocation_InputStreet_Input")]
        public IWebElement PropertyStreetElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_CustomerLocation_InputArea_Input")]
        public IWebElement PropertyAreaElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_CustomerLocation_InputTown_Input")]
        public IWebElement PropertyTownElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_CustomerLocation_InputPostCode_Input")]
        public IWebElement PropertyPostcodeElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_CustomerLocation_InputRegion_Input")]
        public IWebElement RegionElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerLegalForm_Input")]
        public IWebElement PropertyLegalFormElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerTradingStyle_Input")]
        public IWebElement PropertyTradingStyleElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerCostCentre_Input")]
        public IWebElement PropertyCostCentreElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerAuthorisedSignatory_Input")]
        public IWebElement PropertyyAuthorisedSignatoryElement;

        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputBankPaymentType_Input")]
        public IWebElement PaymentTypeElement;

        [FindsBy(How = How.CssSelector, Using = "input[type=\"submit\"]#content_1_ButtonSave")]
        public IWebElement saveButtonElement;

        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerCompanyRegistrationNumber_Input")]
        public IWebElement CompanyRegistrationNumerElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerVatRegistrationNumber_Input")]
        public IWebElement VatFieldElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonFirstName_Input")]
        public IWebElement CustomerContactFirstNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonLastName_Input")]
        public IWebElement CustomerContactLastNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_btnLocationsAdd")]
        public IWebElement CustomerAddAddressButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_rptLocations_Address_1")]
        public IWebElement CustomerAdditionalAddressLineElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputLocationContract_Input")]
        public IWebElement CustomerContractLocationAddressElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonMobile_Input")]
        public IWebElement CustomerContractMobileElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonCulture_Input")]
        public IWebElement CustomerContractCultureElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonPosition_Input")]
        public IWebElement CustomerContactPositionElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-delete-remove #content_1_PersonManage_rptLocations_Address_0")]
        public IWebElement CustomerContractEditedLocationAddressElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputCustomerCreditReformNumber_Input")]
        public IWebElement CustomerCreditReformNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankAccountNumber_Input")]
        public IWebElement BankAccountNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankSortCode_Input")]
        public IWebElement BankSortCodeElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankIban_Input")]
        public IWebElement BankIbanElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankBic_Input")]
        public IWebElement BankBicElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_InputBankName_Input")]
        public IWebElement BankNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_BankLocation_InputTown_Input")]
        public IWebElement BankTownElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_BankLocation_InputNumber_Input")]
        public IWebElement BankPropertyNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_BankLocation_InputStreet_Input")]
        public IWebElement BankStreetElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_BankLocation_InputPostCode_Input")]
        public IWebElement BankPostcodeElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PersonManage_BankPaymentTypeDisplayOnly_Label")]
        public IWebElement PaymentDisplayOnlyElement;
        
        
        

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        public void ConfirmOrganisationDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            var org = SpecFlow.GetObject<OrganisationDetail>(DealerLatestCreatedOrganization);

            AssertElementValue(CompanyNameElement, org.Name);
            AssertElementValue(PropertyNumberElement, org.PropertyNumber);
            AssertElementValue(PropertyStreetElement, org.PropertyStreet);
            AssertElementValue(PropertyAreaElement, org.PropertyArea);
            AssertElementValue(PropertyTownElement, org.PropertyTown);
            AssertElementValue(PropertyPostcodeElement, org.PropertyPostcode);
            AssertElementValue(PropertyLegalFormElement, org.LegalForm);
            AssertElementValue(PropertyTradingStyleElement, org.TradingStyle);
            AssertElementValue(PropertyyAuthorisedSignatoryElement, org.AuthorisedSignatory);
        }

        public void ConfirmOrganisationContactDetail()
        {
            LoggingService.WriteLogOnMethodEntry();
            var contact = SpecFlow.GetObject<OrganisationContactDetail>(DealerLatestCreatedContact);

            AssertElementValue(ContactTitleElement, contact.Title);
            AssertElementValue(FirstNameElement, contact.FirstName);
            AssertElementValue(LastNameElement, contact.LastName);
            AssertElementValue(TelephoneElement, contact.Telephone);
            AssertElementValue(EmailElement, contact.Email);
        }

        public void ConfirmOrganisationBankDetail()
        {
            LoggingService.WriteLogOnMethodEntry();
            var bank = SpecFlow.GetObject<OrganisationBankDetail>(DealerLatestCreatedBank);

            AssertElementValue(PaymentTypeElement, bank.PaymentType);
        }

        private void SelectAPaymentTypeIfNotAlreadySelected()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (GetSelectedOptionText(PaymentTypeElement).Equals("Please Select"))
            {
                SelectFromDropdown(PaymentTypeElement, "Invoice");
            }
        }
        

        private void AssertElementValue(IWebElement elem, string expected)
        {
            LoggingService.WriteLogOnMethodEntry(elem,expected);
            var value = elem.GetAttribute("value");
            TestCheck.AssertIsEqual(expected, value, "Input item is not matched");
        }

        public void IsAdditionalAddressSuccessfullyAdded()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (CustomerAdditionalAddressLineElement == null)
                throw new Exception("Customer Additional Address Line Element is not displayed");

            TestCheck.AssertIsEqual(true, CustomerAdditionalAddressLineElement.Displayed, 
                                            "Customer Additional Address Line Element is not successfully added");
        }
        

        public void IsCustomerContractLocationAddressDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (CustomerContractLocationAddressElement == null)
                throw new Exception("Customer Contract Location Address Element is not displayed");

            TestCheck.AssertIsEqual(true, CustomerContractLocationAddressElement.Displayed,
                                            "Customer Contract Location Address Element is not successfully added");

        }

        public void IsEditedCustomerTownNameDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (PropertyStreetElement == null)
                throw new Exception("Property Town Element is not displayed");

            var town = PropertyStreetElement.GetAttribute("value");

            TestCheck.AssertIsEqual(true, town.Contains("Edited"), string.Format("{0} does not contain Edited", town));
        }

        public void IsEditedCustomerDetailDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (CustomerContractEditedLocationAddressElement == null)
                throw new Exception("edited customer detail element is not displayed");

            var town = CustomerContractEditedLocationAddressElement.Text;

            TestCheck.AssertIsEqual(true, town.Contains("Edited"), string.Format("{0} does not contain Edited", town));
        }

        public void IsEditedCustomerContactFirstNameDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (CustomerContactFirstNameElement == null)
                throw new Exception("Property Town Element is not displayed");

            var town = CustomerContactFirstNameElement.GetAttribute("value");

            TestCheck.AssertIsEqual(true, town.Contains("Edited"), string.Format("{0} does not contain Edited", town));
        }

        public void IsEditedCustomerContactLastNameDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (CustomerContactLastNameElement == null)
                throw new Exception("Property Town Element is not displayed");

            var town = CustomerContactLastNameElement.GetAttribute("value");

            TestCheck.AssertIsEqual(true, town.Contains("Edited"), string.Format("{0} does not contain Edited", town));
        }

        public DealerCustomerAdditionalAddressPage NavigateToCustomerAdditionalAddressPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (CustomerAddAddressButtonElement == null)
                throw new Exception("Customer Add Address Button Element is not displayed");

            if (!(IsFinlandSystem() 
                || IsSwedenSystem()
                || IsPolandSystem()
                || IsNetherlandSystem()
                ||IsDenmarkSystem()))
            {
                SelectAPaymentTypeIfNotAlreadySelected();
            }
            

            CustomerAddAddressButtonElement.Click();

            return GetInstance<DealerCustomerAdditionalAddressPage>();
        }

        
        public string IbanNumber()
        {
            LoggingService.WriteLogOnMethodEntry();
            var iban = "";

            if (!(IsNetherlandSystem()))
            {
                iban = "GB15MIDL40051512345678";

            }
            else if (IsNetherlandSystem())
            {
                iban = "NL91 ABNA 0417 1643 00";
            }
            else if (IsBelgiumSystem())
            {
                iban = "BE68539007547034";
            }
            else if (IsItalySystem())
            {
                iban = "IT40 S054 2811 1010 0000 0123 456";
            }

            return iban;

        }

        public string BicNumber()
        {
            LoggingService.WriteLogOnMethodEntry();
            var bic = "";

            if (IsBelgiumSystem())
            {
                bic = "OBEB3";
            }
            else if (!(IsItalySystem() || IsNetherlandSystem() || IsSpainSystem()))
            {
                bic = "MIDLGB22";
            }

            return bic;
        }


        public void FillCustomerDetails(string payment, string country, string culture)
        {
            LoggingService.WriteLogOnMethodEntry(payment,country,culture);
            switch (country)
            {
                case "Belgium" :
                    FillBelgiumContactInfo(culture);
                    FillBelgiumBankDetails(payment);
                    FillBelgiumOrgDetails();
                    break;
                case "Switzerland" :
                    FillSwissContactInfo(culture);
                    FillSwissBankDetails(payment);
                    FillSwissOrgDetails();
                    break;

                default:
                    MsgOutput(string.Format("{0} is not a recognised country", country));
                    break;
            }
        }

        public void FillCustomerDetails(string payment, string country)
        {
            LoggingService.WriteLogOnMethodEntry(payment,country);
            switch (country)
            {
                case "United Kingdom":
                    FillUkOrgDetails();
                    FillUkContactInfo();
                    FillUkBankDetails(payment);
                    break;
                case "Germany":
                    FillGermanyBankDetails(payment);
                    FillGermanyContactInfo();
                    FillGermanyOrgDetails();
                    break;
                case "Austria":
                    FillAustriaBankDetails(payment);
                    FillAustriaContactInfo();
                    FillAustriaOrgDetails();
                    break;
                case "Italy":
                    FillItalyBankDetails(payment);
                    FillItalyContactInfo();
                    FillItalyOrgDetails();
                    break;
                case "Norway":
                    FillNorwayBankDetails(payment);
                    FillNorwayContactInfo();
                    FillNorwayOrgDetails();
                    break;
                case "Finland":
                    FillFinlandContactInfo();
                    FillFinlandOrgDetails();
                    break;
                case "Sweden" :
                    FillSwedenContactInfo();
                    FillSwedenOrgDetails();
                    break;
                case "Poland":
                    FillPolandBankDetails();
                    FillPolandContactInfo();
                    FillPolandOrgDetails();
                    break;
                case "Ireland" :
                    FillIrelandBankDetails(payment);
                    FillIrelandContactInfo();
                    FillIrelandOrgDetails();
                    break;
                case "Netherlands":
                    FillNetherlandBankDetails();
                    FillNetherlandContactInfo();
                    FillNetherlandOrgDetails();
                    break;
                case "France" :
                    FillFranceBankDetails(payment);
                    FillFranceContactInfo();
                    FillFranceOrgDetails();
                    break;
                case "Spain":
                    FillSpainBankDetails(payment);
                    FillSpainContactInfo();
                    FillSpainOrgDetails();
                    break;
                case "Denmark":
                    FillDenmarkContactInfo();
                    FillDenmarkOrgDetails();
                    break;
                case "Switzerland":
                    FillSwissBankDetails(payment);
                    FillSwissOrgDetails();
                    break;
                default:
                    MsgOutput(string.Format("{0} is not recognised", country));
                    break;
                    
            }
        }

        public void IsEditedDetailsRetained()
        {
            LoggingService.WriteLogOnMethodEntry();
            var companyName = GetFieldValue(CompanyNameElement);
            var authorised = GetFieldValue(PropertyyAuthorisedSignatoryElement);
            var fname = GetFieldValue(FirstNameElement);
            var lName = GetFieldValue(LastNameElement);
            var email = GetFieldValue(EmailElement);
            
            

            TestCheck.AssertIsEqual(false, string.IsNullOrWhiteSpace(companyName), "Company name field is empty");
            TestCheck.AssertIsEqual(false, string.IsNullOrWhiteSpace(authorised), "Authorised person field is empty");
            TestCheck.AssertIsEqual(false, string.IsNullOrWhiteSpace(fname), "First name field is empty");
            TestCheck.AssertIsEqual(false, string.IsNullOrWhiteSpace(lName), "Last name field is empty");
            TestCheck.AssertIsEqual(false, string.IsNullOrWhiteSpace(email), "Email field is empty");

            if (IsNorwaySystem() || IsFinlandSystem() || IsSwedenSystem() || IsDenmarkSystem() || IsNetherlandSystem()) return;
            var bankName = GetFieldValue(BankNameElement);
            TestCheck.AssertIsEqual(false, string.IsNullOrWhiteSpace(bankName), "Bank name field is empty");
        }

        private string GetFieldValue(IWebElement element)
        {
            LoggingService.WriteLogOnMethodEntry(element);
            return element.GetAttribute("value");
        }

        private void FillItalyOrgDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterCompanyName(MpsUtil.CompanyName());
            EnterPropertyStreet(MpsUtil.PropertyStreet());
            EnterPropertyTown("Town");
            EnterPropertyPostCode(MpsUtil.PostCodeIt());
            EnterPropertyArea("Area");
            EnterLegalForm(LegalForm());
            EnterRegistrationNumber();
            EnterInitialVat();
            EnterPropertyAuthorisedSignatory("Mensha");

        }

        private void FillItalyContactInfo()
        {
            LoggingService.WriteLogOnMethodEntry();
            SelectTitleFromDropdown();
            EnterContactFirstName(MpsUtil.FirstName());
            EnterContactSurName(MpsUtil.SurName());
            EnterContactTelephone(MpsUtil.CompanyTelephone());
            EnterContactPosition("Manager");
            EnterContactMobile("07789000011");
            EnterContactEmailAdress(MpsUtil.GenerateUniqueEmail());
        }

        private void FillItalyBankDetails(string payment)
        {
            LoggingService.WriteLogOnMethodEntry(payment);
            SelectPaymentType(payment);

            if (payment.Equals("Fattura"))
            {
                EnterBankIbanNumber(IbanNumber());
            }

            if (payment == "Addebito diretto")
            {
                EnterBankAccountNumber(MpsUtil.AccountNumber());
                EnterBankSortCodeNumber(MpsUtil.BankCodeNumber()); 
            }
            
            EnterBankName("Bank of MPS");
            EnterBankPropertyStreet(MpsUtil.PropertyStreet());
            EnterBankPropertyTown(MpsUtil.PropertyTown());
            EnterBankPostcode(MpsUtil.PostCodeIt());

        }


        private void FillNorwayOrgDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterCompanyName(MpsUtil.CompanyName());
            EnterPropertyStreet(MpsUtil.PropertyStreet());
            EnterPropertyTown("Town");
            EnterPropertyPostCode(MpsUtil.PostCodeNo());
            EnterCostCentre("Marketing");
            EnterLegalForm(LegalForm());
            EnterRegistrationNumber();
            EnterInitialVat();
            EnterPropertyAuthorisedSignatory("Mensha");

        }

        private void FillNorwayContactInfo()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterContactFirstName(MpsUtil.FirstName());
            EnterContactSurName(MpsUtil.SurName());
            EnterContactTelephone(MpsUtil.CompanyTelephone());
            EnterContactPosition("Manager");
            EnterContactMobile("07789000011");
            EnterContactEmailAdress(MpsUtil.GenerateUniqueEmail());
        }

        private void FillNorwayBankDetails(string payment)
        {
            LoggingService.WriteLogOnMethodEntry(payment);
            SelectPaymentType(payment);

        }


        private void FillFinlandOrgDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterCompanyName(MpsUtil.CompanyName());
            EnterPropertyStreet(MpsUtil.PropertyStreet());
            EnterPropertyTown("Town");
            EnterPropertyPostCode(MpsUtil.PostCodeFi());
            EnterCostCentre("Marketing");
            EnterLegalForm(LegalForm());
            EnterRegistrationNumber();
            EnterInitialVat();
            EnterPropertyAuthorisedSignatory("Mensha");

        }

        private void FillFinlandContactInfo()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterContactFirstName(MpsUtil.FirstName());
            EnterContactSurName(MpsUtil.SurName());
            EnterContactTelephone(MpsUtil.CompanyTelephone());
            EnterContactPosition("Manager");
            EnterContactMobile("07789000011");
            EnterContactEmailAdress(MpsUtil.GenerateUniqueEmail());
        }

       

        private void FillSwedenOrgDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterCompanyName(MpsUtil.CompanyName());
            EnterPropertyStreet(MpsUtil.PropertyStreet());
            EnterPropertyTown("Town");
            EnterPropertyPostCode(MpsUtil.PostCodeNs());
            EnterCostCentre("Marketing");
            EnterRegistrationNumber();
            EnterInitialVat();
            EnterPropertyAuthorisedSignatory("Mensha");

        }

        private void FillSwedenContactInfo()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterContactFirstName(MpsUtil.FirstName());
            EnterContactSurName(MpsUtil.SurName());
            EnterContactTelephone(MpsUtil.CompanyTelephone());
            EnterContactPosition("Manager");
            EnterContactMobile("07789000011");
            EnterContactEmailAdress(MpsUtil.GenerateUniqueEmail());
        }

        
        private void FillAustriaOrgDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterCompanyName(MpsUtil.CompanyName());
            EnterPropertyNumber(MpsUtil.PropertyNumber());
            EnterPropertyStreet(MpsUtil.PropertyStreet());
            EnterPropertyTown("Town");
            EnterPropertyArea("Area");
            EnterPropertyPostCode(MpsUtil.PostCode());
            EnterCostCentre("Marketing");
            EnterLegalForm(LegalForm());
            EnterRegistrationNumber();
            EnterInitialVat();
            EnterCreditReformNumber(MpsUtil.CreditReformNumber());
            EnterPropertyAuthorisedSignatory("Mensha");

        }

        private void FillAustriaContactInfo()
        {
            LoggingService.WriteLogOnMethodEntry();
            SelectTitleFromDropdown();
            EnterContactFirstName(MpsUtil.FirstName());
            EnterContactSurName(MpsUtil.SurName());
            EnterContactTelephone(MpsUtil.CompanyTelephone());
            EnterContactPosition("Manager");
            EnterContactMobile("07789000011");
            EnterContactEmailAdress(MpsUtil.GenerateUniqueEmail());
        }

        private void FillAustriaBankDetails(string payment)
        {
            LoggingService.WriteLogOnMethodEntry();
            SelectPaymentType(payment);
            EnterBankAccountNumber(MpsUtil.AccountNumber());
            EnterBankSortCodeNumber(MpsUtil.BankCodeNumber());
            EnterBankIbanNumber(IbanNumber());
            EnterBankBicNumber(BicNumber());
            EnterBankName("Bank of MPS");
        }

        private void FillGermanyOrgDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterCompanyName(MpsUtil.CompanyName());
            EnterPropertyNumber(MpsUtil.PropertyNumber());
            EnterPropertyStreet(MpsUtil.PropertyStreet());
            EnterPropertyTown("Town");
            EnterPropertyArea("Area");
            EnterPropertyPostCode(MpsUtil.PostCode());
            EnterCostCentre("Marketing");
            EnterLegalForm(LegalForm());
            EnterRegistrationNumber();
            EnterInitialVat();
            EnterCreditReformNumber(MpsUtil.CreditReformNumber());
            EnterPropertyAuthorisedSignatory("Mensha");

        }

        private void FillGermanyContactInfo()
        {
            LoggingService.WriteLogOnMethodEntry();
            SelectTitleFromDropdown();
            EnterContactFirstName(MpsUtil.FirstName());
            EnterContactSurName(MpsUtil.SurName());
            EnterContactTelephone(MpsUtil.CompanyTelephone());
            EnterContactPosition("Manager");
            EnterContactMobile("07789000011");
            EnterContactEmailAdress(MpsUtil.GenerateUniqueEmail());
        }

        private void FillGermanyBankDetails(string payment)
        {
            LoggingService.WriteLogOnMethodEntry();
            SelectPaymentType(payment);
            EnterBankAccountNumber(MpsUtil.AccountNumber());
            EnterBankSortCodeNumber(MpsUtil.BankCodeNumber());
            EnterBankIbanNumber(IbanNumber());
            EnterBankBicNumber(BicNumber());
            EnterBankName("Bank of MPS");
        }


        private void FillBelgiumOrgDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterCompanyName(MpsUtil.CompanyName());
            EnterPropertyStreet(MpsUtil.PropertyStreet());
            EnterPropertyTown("Town");
            EnterPropertyPostCode(MpsUtil.PostCodeBe());
            SelectRegionFromDropdownByIndex();
            EnterCostCentre("Marketing");
            EnterLegalFormByIndex();
            EnterRegistrationNumber();
            EnterInitialVat();
            EnterPropertyAuthorisedSignatory("Mensha");

        }

        private void FillBelgiumContactInfo(string culture)
        {
            LoggingService.WriteLogOnMethodEntry(culture);
            SelectTitleFromDropdown();
            EnterContactFirstName(MpsUtil.FirstName());
            EnterContactSurName(MpsUtil.SurName());
            EnterContactTelephone(MpsUtil.CompanyTelephone());
            EnterContactPosition("Manager");
            EnterContactMobile("07789000011");
            EnterContactEmailAdress(MpsUtil.GenerateUniqueEmail());
            SelectCustomerCulture(culture);
            
        }

        private void FillBelgiumBankDetails(string payment)
        {
            LoggingService.WriteLogOnMethodEntry(payment);
            SelectPaymentType(payment);
            EnterBankAccountNumber(MpsUtil.AccountNumber());
            EnterBankIbanNumber(IbanNumber());
            EnterBankBicNumber(BicNumber());
            EnterBankName("Bank of MPS");

        }

        private void FillPolandOrgDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterCompanyName(MpsUtil.CompanyName());
            EnterPropertyNumber(MpsUtil.PropertyNumber());
            EnterPropertyStreet(MpsUtil.PropertyStreet());
            EnterPropertyTown("Town");
            EnterPropertyPostCode(MpsUtil.PostCodePl());
            EnterInitialVat();
            EnterPropertyAuthorisedSignatory("Mensha");

        }

        private void FillPolandContactInfo()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterContactFirstName(MpsUtil.FirstName());
            EnterContactSurName(MpsUtil.SurName());
            EnterContactTelephone(MpsUtil.CompanyTelephone());
            EnterContactPosition("Manager");
            EnterContactMobile("07789000011");
            EnterContactEmailAdress(MpsUtil.GenerateUniqueEmail());
            if (!OrderingPersonElement.Selected)
            {
                ClickOnPersonResponsibleforOrdering();
            }
                
        }

        private void FillPolandBankDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterBankAccountNumber(MpsUtil.AccountNumber());
            EnterBankBicNumber(BicNumber());
            EnterBankName("Bank of MPS");
            EnterBankPropertyNumber(MpsUtil.PropertyNumber());
            EnterBankPropertyStreet(MpsUtil.PropertyStreet());
            EnterBankPropertyTown(MpsUtil.PropertyTown());
            EnterBankPostcode(MpsUtil.PostCodePl());

        }


        private void FillIrelandOrgDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterCompanyName(MpsUtil.CompanyName());
            //EnterPropertyNumber(MpsUtil.PropertyNumber());
            EnterPropertyStreet(MpsUtil.PropertyStreet());
            EnterPropertyTown("Town");
            EnterPropertyPostCode(MpsUtil.PostCodeIr());
            EnterCostCentre("Marketing");
            EnterLegalForm(LegalForm());
            EnterRegistrationNumber();
            EnterInitialVat();
            EnterPropertyAuthorisedSignatory("Mensha");

        }

        private void FillIrelandContactInfo()
        {
            LoggingService.WriteLogOnMethodEntry();
            SelectTitleFromDropdown();
            EnterContactFirstName(MpsUtil.FirstName());
            EnterContactSurName(MpsUtil.SurName());
            EnterContactTelephone(MpsUtil.CompanyTelephone());
            EnterContactPosition("Manager");
            EnterContactMobile("07789000011");
            EnterContactEmailAdress(MpsUtil.GenerateUniqueEmail());
        }

        private void FillIrelandBankDetails(string payment)
        {
            LoggingService.WriteLogOnMethodEntry(payment);
            SelectPaymentType(payment);
            EnterBankAccountNumber(MpsUtil.AccountNumber());
            EnterBankSortCodeNumber(MpsUtil.BankCodeNumber());
            EnterBankIbanNumber(IbanNumber());
            EnterBankBicNumber(BicNumber());
            EnterBankName("Bank of MPS");
            EnterBankPropertyNumber(MpsUtil.PropertyNumber());
            EnterBankPropertyStreet(MpsUtil.PropertyStreet());
            EnterBankPropertyTown(MpsUtil.PropertyTown());
            EnterBankPostcode(MpsUtil.PostCodeIr());

        }


        private void FillNetherlandOrgDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterCompanyName(MpsUtil.CompanyName());
            EnterPropertyStreet(MpsUtil.PropertyStreet());
            EnterPropertyTown("Town");
            EnterPropertyPostCode(MpsUtil.PostCodeNl());
            EnterRegistrationNumber();
            EnterInitialVat();
            EnterPropertyAuthorisedSignatory("Mensha");

        }

        private void FillNetherlandContactInfo()
        {
            LoggingService.WriteLogOnMethodEntry();
            SelectTitleFromDropdown();
            EnterContactFirstName(MpsUtil.FirstName());
            EnterContactSurName(MpsUtil.SurName());
            EnterContactTelephone(MpsUtil.CompanyTelephone());
            EnterContactMobile("07789000011");
            EnterContactEmailAdress(MpsUtil.GenerateUniqueEmail());

            if (!OrderingPersonElement.Selected)
            {
                ClickOnPersonResponsibleforOrdering();
            }
        }

        private void FillNetherlandBankDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterBankIbanNumber(IbanNumber());

        }

        private void FillSwissOrgDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterCompanyName(MpsUtil.CompanyName());
            EnterPropertyStreet(MpsUtil.PropertyStreet());
            EnterPropertyTown("Town");
            EnterPropertyPostCode(MpsUtil.PostCodeSw());
            EnterCostCentre("Marketing");
            EnterLegalFormByIndex();
            EnterInitialVat();
            EnterPropertyAuthorisedSignatory("Mensha");

        }

        private void FillSwissContactInfo(string culture)
        {
            LoggingService.WriteLogOnMethodEntry(culture);
            SelectTitleFromDropdown();
            EnterContactFirstName(MpsUtil.FirstName());
            EnterContactSurName(MpsUtil.SurName());
            EnterContactTelephone(MpsUtil.CompanyTelephone());
            EnterContactMobile("07789000011");
            EnterContactEmailAdress(MpsUtil.GenerateUniqueEmail());
            SelectCustomerCulture(culture);
        }

        private void FillSwissBankDetails(string payment)
        {
            LoggingService.WriteLogOnMethodEntry(payment);
            SelectPaymentType(payment);
            EnterBankAccountNumber(MpsUtil.AccountNumber());
            EnterBankSortCodeNumber(MpsUtil.BankCodeNumber());
            EnterBankIbanNumber(IbanNumber());
            EnterBankBicNumber(BicNumber());
            EnterBankName("Bank of MPS");
            
        }

        private void FillDenmarkOrgDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterCompanyName(MpsUtil.CompanyName());
            EnterPropertyStreet(MpsUtil.PropertyStreet());
            EnterPropertyTown("Town");
            EnterPropertyPostCode(MpsUtil.PostCodeDk());
            EnterCostCentre("Marketing");
            EnterLegalFormByIndex();
            EnterInitialVat();
            EnterPropertyAuthorisedSignatory("Mensha");

        }

        private void FillDenmarkContactInfo()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterContactFirstName(MpsUtil.FirstName());
            EnterContactSurName(MpsUtil.SurName());
            EnterContactTelephone(MpsUtil.CompanyTelephone());
            EnterContactMobile("07789000011");
            EnterContactEmailAdress(MpsUtil.GenerateUniqueEmail());
        }

       
        private void FillSpainOrgDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterCompanyName(MpsUtil.CompanyName());
            EnterPropertyStreet(MpsUtil.PropertyStreet());
            EnterPropertyArea("Area");
            EnterPropertyTown("Town");
            EnterPropertyPostCode(MpsUtil.PostCodeSp());
            EnterRegistrationNumber();
            EnterInitialVat();
            EnterTradingStyle(TradingStyle());
            EnterPropertyAuthorisedSignatory("Mensha");

        }

        private void FillSpainContactInfo()
        {
            LoggingService.WriteLogOnMethodEntry();
            SelectTitleFromDropdown();
            EnterContactFirstName(MpsUtil.FirstName());
            EnterContactSurName(MpsUtil.SurName());
            EnterContactTelephone(MpsUtil.CompanyTelephone());
            EnterContactMobile("07789000011");
            EnterContactEmailAdress(MpsUtil.GenerateUniqueEmail());
        }

        private void FillSpainBankDetails(string payment)
        {
            LoggingService.WriteLogOnMethodEntry(payment);
            SelectPaymentType(payment);

            switch (payment)
            {
                case "Factura":
                    EnterBankAccountNumber(MpsUtil.AccountNumber());
                    EnterBankSortCodeNumber(MpsUtil.BankCodeNumber());
                    EnterBankIbanNumber(IbanNumber());
                    EnterBankBicNumber(BicNumber());
                    EnterBankName("Bank of MPS");
                    EnterBankPropertyStreet(MpsUtil.PropertyStreet());
                    EnterBankPropertyTown(MpsUtil.PropertyTown());
                    EnterBankPostcode(MpsUtil.PostCodeSp());
                    break;
                case "Debito directo":
                    EnterBankIbanNumber(IbanNumber());
                    EnterBankName("Bank of MPS");
                    break;
            }
            

        }

        private void FillFranceOrgDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterCompanyName(MpsUtil.CompanyName());
            EnterPropertyStreet(MpsUtil.PropertyStreet());
            EnterPropertyArea("Area");
            EnterPropertyTown("Town");
            EnterPropertyPostCode(MpsUtil.PostCodeFr());
            EnterPropertyLegalFormByIndex();
            EnterRegistrationNumber();
            EnterInitialVat();
            EnterPropertyAuthorisedSignatory("Mensha");

        }

        private void FillFranceContactInfo()
        {
            LoggingService.WriteLogOnMethodEntry();
            SelectTitleFromDropdown();
            EnterContactFirstName(MpsUtil.FirstName());
            EnterContactSurName(MpsUtil.SurName());
            EnterContactTelephone(MpsUtil.CompanyTelephone());
            EnterContactMobile("07789000011");
            EnterContactEmailAdress(MpsUtil.GenerateUniqueEmail());
        }

        private void FillFranceBankDetails(string payment)
        {
            LoggingService.WriteLogOnMethodEntry(payment);
            SelectPaymentType(payment);
            EnterBankAccountNumber(MpsUtil.AccountNumber());
            EnterBankSortCodeNumber(MpsUtil.BankCodeNumber());
            EnterBankIbanNumber(IbanNumber());
            EnterBankBicNumber(BicNumber());
            EnterBankName("Bank of MPS");
            EnterBankPropertyStreet(MpsUtil.PropertyStreet());
            EnterBankPropertyTown(MpsUtil.PropertyTown());
            EnterBankPostcode(MpsUtil.PostCodeFr());

        }

        private void FillUkOrgDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterCompanyName(MpsUtil.CompanyName());
            EnterPropertyNumber(MpsUtil.PropertyNumber());
            EnterPropertyStreet(MpsUtil.PropertyStreet());
            EnterPropertyArea("Area");
            EnterPropertyTown("Town");
            EnterPropertyPostCode(MpsUtil.PostCodeGb());
            EnterLegalForm(LegalForm());
            EnterRegistrationNumber();
            EnterInitialVat();
            EnterTradingStyle(TradingStyle());
            EnterPropertyAuthorisedSignatory("Mensha");

        }

        private void FillUkContactInfo()
        {
            LoggingService.WriteLogOnMethodEntry();
            SelectTitleFromDropdown();
            EnterContactFirstName(MpsUtil.FirstName());
            EnterContactSurName(MpsUtil.SurName());
            EnterContactTelephone(MpsUtil.CompanyTelephone());
            EnterContactMobile("07789000011");
            EnterContactEmailAdress(MpsUtil.GenerateUniqueEmail());
        }

        private void FillUkBankDetails(string payment)
        {
            LoggingService.WriteLogOnMethodEntry(payment);
            SelectPaymentType(payment);
            EnterBankAccountNumber(MpsUtil.AccountNumber());
            EnterBankSortCodeNumber(MpsUtil.BankCodeNumber());
            EnterBankIbanNumber(IbanNumber());
            EnterBankBicNumber(BicNumber());
            EnterBankName("Bank of MPS");
            EnterBankPropertyNumber(MpsUtil.PropertyNumber());
            EnterBankPropertyStreet(MpsUtil.PropertyStreet());
            EnterBankPropertyTown(MpsUtil.PropertyTown());
            EnterBankPostcode(MpsUtil.PostCodeGb());
            
        }

        public void FillOrganisationDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            var org = new OrganisationDetail
            {
                Name = "Delete_" + MpsUtil.CompanyName(), // in order to boost linear search.
                PropertyNumber = MpsUtil.PropertyNumber(),
                PropertyStreet = MpsUtil.PropertyStreet(),
                PropertyArea = MpsUtil.FirstName(),
                PropertyTown = MpsUtil.PropertyTown(),
                PropertyPostcode = MpsUtil.PostCodeGb() ,
                LegalForm = "1",
                TradingStyle = "1",
                AuthorisedSignatory = "abcdefg"
            };

            SpecFlow.SetObject(DealerLatestCreatedOrganization, org);


            EnterCompanyName(org.Name);
            EnterPropertyNumber(org.PropertyNumber);
            EnterPropertyStreet(org.PropertyStreet);
            EnterPropertyArea(org.PropertyArea);
            EnterPropertyTown(org.PropertyTown);
            EnterPropertyPostCode(org.PropertyPostcode);
            EnterPropertyLegalForm(org.LegalForm);
            EnterPropertyTradingStyle(org.TradingStyle);
            EnterPropertyAuthorisedSignatory(org.AuthorisedSignatory);
            EnterRegistrationNumber();
            EnterInitialVat();

            //EnterTextboxArea(CompanyNameElement, org.Name);
            //EnterTextboxArea(PropertyNumberElement, org.PropertyNumber);
            //EnterTextboxArea(PropertyStreetElement, org.PropertyStreet);
            //EnterTextboxArea(PropertyTownElement, org.PropertyTown);
            //EnterTextboxArea(PropertyPostcodeElement, org.PropertyPostcode);
        }

        public void FillOrganisationContactDetail()
        {
            LoggingService.WriteLogOnMethodEntry();
            var contact = new OrganisationContactDetail
            {
                Title = "0002",
                FirstName = MpsUtil.FirstName(),
                LastName = MpsUtil.SurName(),
                Telephone = MpsUtil.CompanyTelephone(),
                Email = MpsUtil.GenerateUniqueEmail()
            };

            SpecFlow.SetObject(DealerLatestCreatedContact, contact);

            SelectTitleFromDropdown(contact.Title);
            EnterContactFirstName(contact.FirstName);
            EnterContactSurName(contact.LastName);
            EnterContactTelephone(contact.Telephone);
            EnterContactEmailAdress(contact.Email);
        }

        public void FillOrganisationBankDetail(string payment)
        {
            LoggingService.WriteLogOnMethodEntry(payment);
            var bank = new OrganisationBankDetail();
            switch (payment)
            {
                case "DirectDebit":
                    bank.PaymentType = "1";
                    break; ;

                case "Invoice":
                    bank.PaymentType = "2";
                    break;

                default:
                    throw new System.NotSupportedException(payment);
            }

            SpecFlow.SetObject(DealerLatestCreatedBank, bank);

            SelectPaymentTypeFromDropdown(bank.PaymentType);
        }

        private void EnterTextboxArea(IWebElement textbox, string text)
        {
            LoggingService.WriteLogOnMethodEntry(textbox,text);
            textbox.Clear();
            textbox.SendKeys(text);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterCompanyName(string companyname)
        {
            LoggingService.WriteLogOnMethodEntry(companyname);
            CompanyNameElement.Clear();
            CompanyNameElement.SendKeys(companyname);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterCostCentre(string cost)
        {
            LoggingService.WriteLogOnMethodEntry(cost);
            PropertyCostCentreElement.Clear();
            PropertyCostCentreElement.SendKeys(cost);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        public void IsPaymentDetailDisplayedAfterEditing()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsFinlandSystem() || IsSwedenSystem() || IsDenmarkSystem())
            {
                if (PaymentDisplayOnlyElement == null)
                    throw new Exception("selected payment option element is missing");

                TestCheck.AssertIsEqual(true, PaymentDisplayOnlyElement.Displayed,
                    "payment option selected is not displayed");
            }
            else if (IsNorwaySystem())
            {
                if(PaymentTypeElement == null)
                    throw new Exception("payment section is not displayed");
                TestCheck.AssertIsEqual(true, PaymentTypeElement.Displayed, "payment details are not displayed");
            }
            else if (IsNetherlandSystem()|| IsSpainSystem())
            {
                if (BankIbanElement == null)
                    throw new Exception("Bank iban number element is not displayed");
                TestCheck.AssertIsEqual(true, BankIbanElement.Displayed, "bank iban number is not displayed so payment details are not displayed");
            }
            else
            {
                if(BankNameElement == null)
                    throw new Exception("Bank account number element is not displayed");
                TestCheck.AssertIsEqual(true, BankNameElement.Displayed, "bank account number is not displayed so payment details are not displayed");
            }
            
        }

        private void EnterContactPosition(string cost)
        {
            LoggingService.WriteLogOnMethodEntry(cost);
            CustomerContactPositionElement.Clear();
            CustomerContactPositionElement.SendKeys(cost);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void ClickOnPersonResponsibleforOrdering()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (OrderingPersonElement == null)
                throw new Exception("ordering person tick box not found");

            OrderingPersonElement.Click();
        }

        
        

        private void EnterPropertyNumber(string propertyNumber)
        {
            LoggingService.WriteLogOnMethodEntry(propertyNumber);
            PropertyNumberElement.Clear();
            PropertyNumberElement.SendKeys(propertyNumber);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterPropertyStreet(string propertyStreet)
        {
            LoggingService.WriteLogOnMethodEntry(propertyStreet);
            PropertyStreetElement.Clear();
            PropertyStreetElement.SendKeys(propertyStreet);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterPropertyArea(string propertyArea)
        {
            LoggingService.WriteLogOnMethodEntry(propertyArea);
            if (IsNetherlandSystem()) return;
            PropertyAreaElement.Clear();
            PropertyAreaElement.SendKeys(propertyArea);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private string TradingStyle()
        {
            LoggingService.WriteLogOnMethodEntry();
            var trading = "";

            if (IsUKSystem() || IsFranceSystem() || IsIrelandSystem())
            {
                trading = "Non-Regulated";
            }
            else if (IsItalySystem())
            {
                trading = "Non regolamentato";
            }
            else if (IsSpainSystem())
            {
                trading = "No regulado";
                //trading = "Persona Física";
            }
            else if (IsNetherlandSystem())
            {
                trading = "Non-Regulated";
            }
            else if (IsBelgiumSystem())
            {
                trading = "Non-Regulated";
            }
            else if (IsPolandSystem())
            {
                trading = "Non-Regulated";
            }
            else if (IsNorwaySystem())
            {
                trading = "Ikke regulert";
            }
            else if (IsDenmarkSystem())
            {
                trading = "Ikke-reguleret";
            }
            else if (IsFinlandSystem())
            {
                trading = "Ei-säännelty";
            }
            else if (IsSwissSystem())
            {
                trading = "Non-Regulated";
            }
            //else if (IsSwedenSystem())
            //{
            //    trading = "Icke reglerad";
            //}


            return trading;
        }

        public void EnterRegistrationNumber()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsFranceSystem())
            {
                ClearAndType(CompanyRegistrationNumerElement, "RCS PARIS 453 983 245");
            }
            else if (IsUKSystem())
            {
                ClearAndType(CompanyRegistrationNumerElement, "06488522");
            }
            else if (IsIrelandSystem())
            {
                ClearAndType(CompanyRegistrationNumerElement, "159555");
            }
            else if (IsPolandSystem())
            {
                ClearAndType(CompanyRegistrationNumerElement, "8522470967");
            }
            else if (IsNetherlandSystem())
            {
                ClearAndType(CompanyRegistrationNumerElement, "66019702");
            }
            else if (IsSwedenSystem())
            {
                ClearAndType(CompanyRegistrationNumerElement, "556026-6883");
            }
            else if (IsBelgiumSystem())
            {
                ClearAndType(CompanyRegistrationNumerElement, "47706706");
            }
            else if (IsDenmarkSystem())
            {
                //  ClearAndType(CompanyRegistrationNumerElement, "35679626");
            }
            else if (IsNorwaySystem())
            {
                ClearAndType(CompanyRegistrationNumerElement, "913992415");
            }
            //else if (IsSwissSystem())
            //{
            //    ClearAndType(CompanyRegistrationNumerElement, "CHE-106.568.179");
            //}
            //else if (IsFinlandSystem())
            //{
            //    ClearAndType(CompanyRegistrationNumerElement, "0572355-8");
            //}

        }

        public void EnterInitialVat()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsItalySystem())
            {
                ClearAndType(VatFieldElement, "IT00743110157");
            }
            else if (IsFranceSystem())
            {
                ClearAndType(VatFieldElement, "FR40303265045");
            }
            else if (IsUKSystem())
            {
                ClearAndType(VatFieldElement, "GB980780684");
            }
            else if (IsSpainSystem())
            {
                ClearAndType(VatFieldElement, "ES54362315K");
            }
            else if (IsIrelandSystem())
            {
                ClearAndType(VatFieldElement, "IE6433435F");
            }
            else if (IsBelgiumSystem())
            {
                ClearAndType(VatFieldElement, "BE0428759497");
            }
            else if (IsPolandSystem())
            {
                ClearAndType(VatFieldElement, "PL8567346215");
            }
            else if (IsNetherlandSystem())
            {
                ClearAndType(VatFieldElement, "NL004495445B01");
            }
            else if (IsSwissSystem())
            {
                ClearAndType(VatFieldElement, "CHE-106.568.179 MWST");
            }
            else if (IsFinlandSystem())
            {
                ClearAndType(VatFieldElement, "FI20774740");
            }
            else if (IsDenmarkSystem())
            {
                ClearAndType(VatFieldElement, "DK13585628");
            }
            //else if (IsNorwaySystem())
            //{
            //    ClearAndType(VatFieldElement, "NO980395898");
            //}

        }

        private string LegalForm()
        {
            LoggingService.WriteLogOnMethodEntry();
            var legal = "";

            if (IsGermanSystem() || IsAustriaSystem())
            {
                legal = "Aktiengesellschaft";

            }
            else if (IsUKSystem() || IsItalySystem())
            {
                legal ="Church";
            }
            else if (IsIrelandSystem())
            {
                legal = "School";
            }
            else if (IsFranceSystem())
            {
                legal ="Administration";
            }
            else if (IsNorwaySystem())
            {
                legal = "Enkeltpersonforetak";
            }
            else if (IsDenmarkSystem())
            {
                legal = "Enkeltmandsvirksomhed";
            }
            else if (IsSwissSystem())
            {
                var language = SwissLegalForm();
                legal = language;
            }
            else if (IsBelgiumSystem())
            {
                var language = BelgianLegalForm();
                legal = language;
            }
            else if (IsFinlandSystem())
            {
                legal = "Oyj";
            }

            return legal;
        }

        private String BelgianLegalForm()
        {
            LoggingService.WriteLogOnMethodEntry();
            string lang;

            string language;

            try
            {
                language = SpecFlow.GetContext("BelgianLanguage");
            }
            catch (KeyNotFoundException)
            {

                language = "Français";
            }

            switch (language)
            {
                case "":
                case "Français":
                    lang = "Gouvernement";
                    break;
                case "Nederlands":
                    lang = "Overheid";
                    break;

                default:
                    lang = "Overheid";
                    break;
            }

            return lang;
        }

        private String SwissLegalForm()
        {
            LoggingService.WriteLogOnMethodEntry();
            string lang;
            string language;

            try
            {
                language = SpecFlow.GetContext("BelgianLanguage");
            }
            catch (KeyNotFoundException)
            {

                language = "Français";
            }

            switch (language)
            {
                case "Français":
                    lang = "Verein";
                    break;
                case "Deutsch":
                    lang = "Verein";
                    break;

                default:
                    lang = "Verein";
                    break;
            }

            return lang;
        }

        private void EnterPropertyTown(string propertyTown)
        {
            LoggingService.WriteLogOnMethodEntry(propertyTown);
            PropertyTownElement.Clear();
            PropertyTownElement.SendKeys(propertyTown);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterPropertyPostCode(string postcode)
        {
            LoggingService.WriteLogOnMethodEntry(postcode);
            PropertyPostcodeElement.Clear();
            PropertyPostcodeElement.SendKeys(postcode);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void SelectRegionFromDropdown(string region = "1")
        {
            LoggingService.WriteLogOnMethodEntry(region);
            SelectFromDropdownByValue(RegionElement, region);
        }

        private void SelectRegionFromDropdownByIndex(int region = 1)
        {
            LoggingService.WriteLogOnMethodEntry(region);
            SelectFromDropDownByIndex(RegionElement, region);
        }

        private void EnterPropertyLegalForm(string value = "1")
        {
            LoggingService.WriteLogOnMethodEntry(value);
            SelectFromDropdownByValue(PropertyLegalFormElement, value);
            WebDriver.Wait(DurationType.Millisecond, 3000);
        }

        private void EnterPropertyLegalFormByIndex(int value = 1)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            SelectFromDropDownByIndex(PropertyLegalFormElement, value);
            WebDriver.Wait(DurationType.Millisecond, 3000);
        }

        private void SelectCustomerCulture(string value)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            SelectFromDropdown(CustomerContractCultureElement, value);
            WebDriver.Wait(DurationType.Millisecond, 3000);
        }

        private void EnterLegalForm(string value)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            SelectFromDropdown(PropertyLegalFormElement, value);
            WebDriver.Wait(DurationType.Millisecond, 3000);
        }

        private void EnterLegalFormByIndex(int value = 1)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            SelectFromDropDownByIndex(PropertyLegalFormElement, value);
            WebDriver.Wait(DurationType.Millisecond, 3000);
        }

        private void EnterPropertyTradingStyle(string value = "1")
        {
            LoggingService.WriteLogOnMethodEntry(value);
            SelectFromDropdownByValue(PropertyTradingStyleElement, value);
        }

        private void EnterTradingStyle(string style)
        {
            LoggingService.WriteLogOnMethodEntry(style);
            SelectFromDropdown(PropertyTradingStyleElement, style);
        }

        private void EnterPropertyAuthorisedSignatory(string authsig)
        {
            LoggingService.WriteLogOnMethodEntry(authsig);
            PropertyyAuthorisedSignatoryElement.Clear();
            PropertyyAuthorisedSignatoryElement.SendKeys(authsig);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void SelectTitleFromDropdown(string value = "0002")
        {
            LoggingService.WriteLogOnMethodEntry(value);
            if (ContactTitleElement != null)
                SelectFromDropdownByValue(ContactTitleElement, value);
        }

        private void EnterContactFirstName(string firstname)
        {
            LoggingService.WriteLogOnMethodEntry(firstname);
            FirstNameElement.Clear();
            FirstNameElement.SendKeys(firstname);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterCreditReformNumber(string credit)
        {
            LoggingService.WriteLogOnMethodEntry(credit);
            CustomerCreditReformNumberElement.Clear();
            CustomerCreditReformNumberElement.SendKeys(credit);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        

        private void EnterContactSurName(string surname)
        {
            LoggingService.WriteLogOnMethodEntry(surname);
            LastNameElement.Clear();
            LastNameElement.SendKeys(surname);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterContactTelephone(string telephone)
        {
            LoggingService.WriteLogOnMethodEntry(telephone);
            TelephoneElement.Clear();
            TelephoneElement.SendKeys(telephone);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }


        private void EnterContactMobile(string telephone)
        {
            LoggingService.WriteLogOnMethodEntry(telephone);
            CustomerContractMobileElement.Clear();
            CustomerContractMobileElement.SendKeys(telephone);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }
        

        private void EnterContactEmailAdress(string email)
        {
            LoggingService.WriteLogOnMethodEntry(email);
            EmailElement.Clear();
            EmailElement.SendKeys(email);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void SelectPaymentTypeFromDropdown(string value = "2")
        {
            LoggingService.WriteLogOnMethodEntry(value);
            if (PaymentTypeElement.Displayed)
                SelectFromDropdownByValue(PaymentTypeElement, value);

            WebDriver.Wait(DurationType.Millisecond, 3000);
        }

        private void SelectPaymentType(string value)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            if (PaymentTypeElement.Displayed)
                SelectFromDropdown(PaymentTypeElement, value);

            WebDriver.Wait(DurationType.Millisecond, 3000);
        }

        private void EnterBankAccountNumber(string acc)
        {
            LoggingService.WriteLogOnMethodEntry(acc);
            ClearAndType(BankAccountNumberElement, acc);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterBankSortCodeNumber(string acc)
        {
            LoggingService.WriteLogOnMethodEntry(acc);
            ClearAndType(BankSortCodeElement, acc);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterBankIbanNumber(string acc)
        {
            LoggingService.WriteLogOnMethodEntry(acc);
            ClearAndType(BankIbanElement, acc);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterBankBicNumber(string acc)
        {
            LoggingService.WriteLogOnMethodEntry(acc);
            ClearAndType(BankBicElement, acc);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterBankName(string acc)
        {
            LoggingService.WriteLogOnMethodEntry(acc);
            ClearAndType(BankNameElement, acc);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterBankPropertyNumber(string acc)
        {
            LoggingService.WriteLogOnMethodEntry(acc);
            ClearAndType(BankPropertyNumberElement, acc);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterBankPropertyStreet(string acc)
        {
            LoggingService.WriteLogOnMethodEntry(acc);
            ClearAndType(BankStreetElement, acc);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterBankPropertyTown(string acc)
        {
            LoggingService.WriteLogOnMethodEntry(acc);
            ClearAndType(BankTownElement, acc);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterBankPostcode(string acc)
        {
            LoggingService.WriteLogOnMethodEntry(acc);
            ClearAndType(BankPostcodeElement, acc);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }


        [System.Obsolete("saveButtonElement.Click() and PageService.GetPageObject<DealerProposalsCreateProductsPage>(...)")]
        public DealerCustomersExistingPage ClickSaveButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, saveButtonElement);
            //saveButtonElement.Click();
            return GetInstance<DealerCustomersExistingPage>();
        }
        public string GetCompanyName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(CompanyNameElement);
        }

        public  string GetEmail()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(EmailElement);
        }

        public string GetFirstName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(FirstNameElement);
        }

        public string GetLastName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(LastNameElement);
        }

    }
}
