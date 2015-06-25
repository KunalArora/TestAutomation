using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.ViewModels;
using Brother.WebSites.Core.ViewModels.MPSTwo;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CloudManageCustomerPage : BasePage
    {
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

            var json = ModelUtils.JsonSerialize(org);
            SpecFlow.SetContext(DealerLatestCreatedOrganization, json);

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

            var json = ModelUtils.JsonSerialize(contact);
            SpecFlow.SetContext(DealerLatestCreatedContact, json);

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

            var json = ModelUtils.JsonSerialize(bank);
            SpecFlow.SetContext(DealerLatestCreatedBank, json);

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

        public CloudExisitngCustomerPage ClickSaveButton()
        {
            saveButtonElement.Click();
            return GetInstance<CloudExisitngCustomerPage>();
        }
    }
}
