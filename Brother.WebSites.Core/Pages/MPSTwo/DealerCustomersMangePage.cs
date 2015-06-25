using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerCustomersMangePage : BasePage
    {
#region ViewModels
        internal class OrganisationBankDetail
        {
            public string PaymentType { get; set; }

            public string BankAccountNumber { get; set; }

            public string BankSortCode { get; set; }

            public string IBAN { get; set; }

            public string BIC { get; set; }

            public string BankName { get; set; }

            public string PropertyNaumber { get; set; }

            public string PropertyStreet { get; set; }

            public string PropertyArea { get; set; }

            public string PropertyTown { get; set; }

            public string PropertyPostcode { get; set; }

            public string PropertyCountry { get; set; }

            public string Region { get; set; }
        }

        internal class OrganisationContactDetail
        {
            public string Title { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Position { get; set; }

            public string Telephone { get; set; }

            public string Mobile { get; set; }

            public string Email { get; set; }

            public string CanOrderConsumablesForAllDevices { get; set; }
        }

        internal class OrganisationDetail
        {
            public string Name { get; set; }

            public string PropertyNumber { get; set; }

            public string PropertyStreet { get; set; }

            public string PropertyArea { get; set; }

            public string PropertyTown { get; set; }

            public string PropertyPostcode { get; set; }

            public string PropertyCountry { get; set; }

            public string Region { get; set; }

            public string CostCentre { get; set; }

            public string LegalForm { get; set; }

            public string CompanyRegistrationNumber { get; set; }

            public string VatRegistrationNumber { get; set; }

            public string TradingStyle { get; set; }

            public string AuthorisedSignatory { get; set; }
        }

#endregion



        public static string URL = "/mps/dealer/customers/manage";
        public const string DealerLatestCreatedOrganization = "DealerLatestCreatedOrganization";
        public const string DealerLatestCreatedContact = "DealerLatestCreatedContact";
        public const string DealerLatestCreatedBank = "DealerLatestCreatedBank";

        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonTitle_Input")]
        private IWebElement ContactTitleElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonFirstName_Input")]
        private IWebElement FirstNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonLastName_Input")]
        private IWebElement LastNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonTelephone_Input")]
        private IWebElement TelephoneElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputPersonEmail_Input")]
        private IWebElement EmailElement;

        [FindsBy(How = How.Id, Using = "content_1_NewOrganisation")]
        private IWebElement NewOrganisationElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerName")]
        private IWebElement CompanyNameElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyNumber_Input")]
        private IWebElement PropertyNumberElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyStreet_Input")]
        private IWebElement PropertyStreetElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyArea_Input")]
        private IWebElement PropertyAreaElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyTown_Input")]
        private IWebElement PropertyTownElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerPropertyPostCode_Input")]
        private IWebElement PropertyPostcodeElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerRegion_Input")]
        private IWebElement RegionElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerLegalForm_Input")]
        private IWebElement PropertyLegalFormElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerTradingStyle_Input")]
        private IWebElement PropertyTradingStyleElement;
        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputCustomerAuthorisedSignatory_Input")]
        private IWebElement PropertyyAuthorisedSignatoryElement;

        [FindsBy(How = How.Id, Using = "content_1_PersonManage_InputBankPaymentType_Input")]
        private IWebElement PaymentTypeElement;

        [FindsBy(How = How.CssSelector, Using = "input[type=\"submit\"]#content_1_ButtonSave")]
        private IWebElement saveButtonElement;

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }


        public void FillOrganisationDetails()
        {
            var org = new OrganisationDetail
            {
                Name = MpsUtil.CompanyName(),
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
        }

        public void FillOrganisationContactDetail()
        {
            var contact = new OrganisationContactDetail
            {
                Title = "2",
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

        private void EnterCompanyName(string companyname)
        {
            CompanyNameElement.SendKeys(companyname);
        }

        private void EnterPropertyNumber(string propertyNumber)
        {
            PropertyNumberElement.SendKeys(propertyNumber);
        }

        private void EnterPropertyStreet(string propertyStreet)
        {
            PropertyStreetElement.SendKeys(propertyStreet);
        }

        private void EnterPropertyArea(string propertyArea)
        {
            PropertyAreaElement.SendKeys(propertyArea);
        }

        private void EnterPropertyTown(string propertyTown)
        {
            PropertyTownElement.SendKeys(propertyTown);
        }

        private void EnterPropertyPostCode(string postcode)
        {
            PropertyPostcodeElement.SendKeys(postcode);
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
            PropertyyAuthorisedSignatoryElement.SendKeys(authsig);
        }

        private void SelectTitleFromDropdown(string value = "2")
        {
            if (ContactTitleElement.Displayed)
                SelectFromDropdownByValue(ContactTitleElement, value);
        }

        private void EnterContactFirstName(string firstname)
        {
            FirstNameElement.SendKeys(firstname);
        }

        private void EnterContactSurName(string surname)
        {
            LastNameElement.SendKeys(surname);
        }

        private void EnterContactTelephone(string telephone)
        {
            TelephoneElement.SendKeys(telephone);
        }

        private void EnterContactEmailAdress(string email)
        {
            EmailElement.SendKeys(email);
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
