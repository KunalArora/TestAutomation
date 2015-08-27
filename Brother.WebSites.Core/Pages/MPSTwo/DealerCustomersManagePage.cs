using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Runtime.Serialization;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerCustomersManagePage : BasePage
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
        public const string DealerLatestCreatedOrganization = "DealerLatestCreatedOrganization";
        public const string DealerLatestCreatedContact = "DealerLatestCreatedContact";
        public const string DealerLatestCreatedBank = "DealerLatestCreatedBank";

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

        [FindsBy(How = How.Id, Using = "content_1_NewOrganisation")]
        public IWebElement NewOrganisationElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerName")]
        public IWebElement CompanyNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyNumber_Input")]
        public IWebElement PropertyNumberElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyStreet_Input")]
        public IWebElement PropertyStreetElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyArea_Input")]
        public IWebElement PropertyAreaElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyTown_Input")]
        public IWebElement PropertyTownElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyPostCode_Input")]
        public IWebElement PropertyPostcodeElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerRegion_Input")]
        public IWebElement RegionElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerLegalForm_Input")]
        public IWebElement PropertyLegalFormElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerTradingStyle_Input")]
        public IWebElement PropertyTradingStyleElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerAuthorisedSignatory_Input")]
        public IWebElement PropertyyAuthorisedSignatoryElement;

        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputBankPaymentType_Input")]
        public IWebElement PaymentTypeElement;

        [FindsBy(How = How.CssSelector, Using = "input[type=\"submit\"]#content_1_ButtonSave")]
        public IWebElement saveButtonElement;

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        public void ConfirmOrganisationDetails()
        {
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
            var contact = SpecFlow.GetObject<OrganisationContactDetail>(DealerLatestCreatedContact);

            AssertElementValue(ContactTitleElement, contact.Title);
            AssertElementValue(FirstNameElement, contact.FirstName);
            AssertElementValue(LastNameElement, contact.LastName);
            AssertElementValue(TelephoneElement, contact.Telephone);
            AssertElementValue(EmailElement, contact.Email);
        }

        public void ConfirmOrganisationBankDetail()
        {
            var bank = SpecFlow.GetObject<OrganisationBankDetail>(DealerLatestCreatedBank);

            AssertElementValue(PaymentTypeElement, bank.PaymentType);
        }

        private void AssertElementValue(IWebElement elem, string expected)
        {
            var value = elem.GetAttribute("value");
            TestCheck.AssertIsEqual(expected, value, "Input item is not matched");
        }

        public void FillOrganisationDetails()
        {
            var org = new OrganisationDetail
            {
                Name = "Deletable_" + MpsUtil.CompanyName(), // in order to boost linear search.
                PropertyNumber = MpsUtil.PropertyNumber(),
                PropertyStreet = MpsUtil.PropertyStreet(),
                PropertyArea = MpsUtil.FirstName(),
                PropertyTown = MpsUtil.PropertyTown(),
                PropertyPostcode = MpsUtil.PostCode(),
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

            //EnterTextboxArea(CompanyNameElement, org.Name);
            //EnterTextboxArea(PropertyNumberElement, org.PropertyNumber);
            //EnterTextboxArea(PropertyStreetElement, org.PropertyStreet);
            //EnterTextboxArea(PropertyTownElement, org.PropertyTown);
            //EnterTextboxArea(PropertyPostcodeElement, org.PropertyPostcode);
        }

        public void FillOrganisationContactDetail()
        {
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
            var bank = new OrganisationBankDetail();
            switch (payment)
            {
                case "DirectDebit":
                    bank.PaymentType = "1";
                    throw new System.NotImplementedException();
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
            textbox.Clear();
            textbox.SendKeys(text);
            WebDriver.Wait(Helper.DurationType.Millisecond, 100);
        }

        private void EnterCompanyName(string companyname)
        {
            CompanyNameElement.Clear();
            CompanyNameElement.SendKeys(companyname);
            WebDriver.Wait(Helper.DurationType.Millisecond, 100);
        }

        private void EnterPropertyNumber(string propertyNumber)
        {
            PropertyNumberElement.Clear();
            PropertyNumberElement.SendKeys(propertyNumber);
            WebDriver.Wait(Helper.DurationType.Millisecond, 100);
        }

        private void EnterPropertyStreet(string propertyStreet)
        {
            PropertyStreetElement.Clear();
            PropertyStreetElement.SendKeys(propertyStreet);
            WebDriver.Wait(Helper.DurationType.Millisecond, 100);
        }

        private void EnterPropertyArea(string propertyArea)
        {
            PropertyAreaElement.Clear();
            PropertyAreaElement.SendKeys(propertyArea);
            WebDriver.Wait(Helper.DurationType.Millisecond, 100);
        }

        private void EnterPropertyTown(string propertyTown)
        {
            PropertyTownElement.Clear();
            PropertyTownElement.SendKeys(propertyTown);
            WebDriver.Wait(Helper.DurationType.Millisecond, 100);
        }

        private void EnterPropertyPostCode(string postcode)
        {
            PropertyPostcodeElement.Clear();
            PropertyPostcodeElement.SendKeys(postcode);
            WebDriver.Wait(Helper.DurationType.Millisecond, 100);
        }

        private void SelectRegionFromDropdown(string region)
        {
            SelectFromDropdown(RegionElement, region);
        }

        private void EnterPropertyLegalForm(string value = "1")
        {
            SelectFromDropdownByValue(PropertyLegalFormElement, value);
            WebDriver.Wait(Helper.DurationType.Millisecond, 3000);
        }

        private void EnterPropertyTradingStyle(string value = "1")
        {
            SelectFromDropdownByValue(PropertyTradingStyleElement, value);
        }

        private void EnterPropertyAuthorisedSignatory(string authsig)
        {
            PropertyyAuthorisedSignatoryElement.Clear();
            PropertyyAuthorisedSignatoryElement.SendKeys(authsig);
            WebDriver.Wait(Helper.DurationType.Millisecond, 100);
        }

        private void SelectTitleFromDropdown(string value = "0002")
        {
            if (ContactTitleElement.Displayed)
                SelectFromDropdownByValue(ContactTitleElement, value);
        }

        private void EnterContactFirstName(string firstname)
        {
            FirstNameElement.Clear();
            FirstNameElement.SendKeys(firstname);
            WebDriver.Wait(Helper.DurationType.Millisecond, 100);
        }

        private void EnterContactSurName(string surname)
        {
            LastNameElement.Clear();
            LastNameElement.SendKeys(surname);
            WebDriver.Wait(Helper.DurationType.Millisecond, 100);
        }

        private void EnterContactTelephone(string telephone)
        {
            TelephoneElement.Clear();
            TelephoneElement.SendKeys(telephone);
            WebDriver.Wait(Helper.DurationType.Millisecond, 100);
        }

        private void EnterContactEmailAdress(string email)
        {
            EmailElement.Clear();
            EmailElement.SendKeys(email);
            WebDriver.Wait(Helper.DurationType.Millisecond, 100);
        }

        private void SelectPaymentTypeFromDropdown(string value = "2")
        {
            if (PaymentTypeElement.Displayed)
                SelectFromDropdownByValue(PaymentTypeElement, value);

            WebDriver.Wait(Helper.DurationType.Millisecond, 3000);
        }

        public DealerCustomersExistingPage ClickSaveButton()
        {
            saveButtonElement.Click();
            return GetInstance<DealerCustomersExistingPage>();
        }

    }
}
