using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminDealersCreateDealershipPage : BasePage, IPageObject
    {
        private string _validationElementSelector = "#content_1_ButtonBack";
        private const string _url = "/mps/local-office/admin/dealers/create-dealership";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        //Business type details elements
        [FindsBy(How = How.CssSelector, Using = "#content_1_BusinessTypeSelect_InputBusinessTypes_Input_0")]
        public IWebElement Type1BusinessTypeCheckboxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_BusinessTypeSelect_InputBusinessTypes_Input_1")]
        public IWebElement Type3BusinessTypeCheckboxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_BusinessTypeSelect_InputNoDealerCustomerSapIdExists_Input")]
        public IWebElement CustomerSapIdExistsNoRadioButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonBusinessTypesSelectComplete")]
        public IWebElement CompleteButtonElement;

        //Dealer details elements
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputDealershipName_Input")]
        public IWebElement InputDealershipNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputOwnerFirstName_Input")]
        public IWebElement InputOwnerFirstNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputOwnerLastName_Input")]
        public IWebElement InputOwnerLastNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputCEOFirstName_Input")]
        public IWebElement InputCEOFirstNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputCEOLastName_Input")]
        public IWebElement InputCEOLastNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputPropertyNumber_Input")]
        public IWebElement InputPropertyNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputPropertyStreet_Input")]
        public IWebElement InputPropertyStreetElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputPropertyTown_Input")]
        public IWebElement InputPropertyTownElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputPropertyPostCode_Input")]
        public IWebElement InputPropertyPostCodeElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputCompaniesHouseNumber_Input")]
        public IWebElement InputCompaniesHouseNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputVatNumber_Input")]
        public IWebElement InputVatNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputCompanyTaxNumber_Input")]
        public IWebElement InputCompanyTaxNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputConsumerCreditLicenseNumber_Input")]
        public IWebElement InputCustomerCreditLicenceNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputRegisteredCity_Input")]
        public IWebElement InputRegisteredCityElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputCompanyBookIsRegistered_Input")]
        public IWebElement InputCompanyBookIsRegisteredCheckboxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputBankName_Input")]
        public IWebElement InputBankNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputBankAccountNumber_Input")]
        public IWebElement InputBankAccountNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputBankSortCode_Input")]
        public IWebElement InputBankSortCodeElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputBrotherSalesPerson_Input")]
        public IWebElement InputBrotherSalesPersonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputDealerCulture_Input")]
        public IWebElement InputDealerCultureElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputContactTitle_Input")]
        public IWebElement InputContactTitleElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputContactFirstName_Input")]
        public IWebElement InputContactFirstNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputContactLastName_Input")]
        public IWebElement InputContactLastNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputContactTelephone_Input")]
        public IWebElement InputContactTelephoneElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipCreate_InputContactEmail_Input")]
        public IWebElement InputContactEmailElement;

        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSave")]
        public IWebElement SaveButtonElement;
        
        private const string Type3DiscountSelector = "#content_1_BusinessTypeSelect_InputDiscountForType3_Input";
        private const string BillingDateForCPPAgreementsSelector = "#content_1_BusinessTypeSelect_InputPreferredT3BillingDate_Input";
        
        public void InputBusinessTypeDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.SetCheckBox(Type1BusinessTypeCheckboxElement, true);
            SeleniumHelper.SetCheckBox(Type3BusinessTypeCheckboxElement, true);

            var Type3DiscountElement = SeleniumHelper.FindElementByCssSelector(Type3DiscountSelector);
            TestCheck.AssertIsEqual(SeleniumHelper.IsElementDisplayed(Type3DiscountElement), true, "Type 3 discount element is not displayed");

            var BillingDateForCPPAgreementsElement = SeleniumHelper.FindElementByCssSelector(BillingDateForCPPAgreementsSelector);
            TestCheck.AssertIsEqual(SeleniumHelper.IsElementDisplayed(BillingDateForCPPAgreementsElement), true, "Billing date for cpp agreement element is not displayed");

            ClearAndType(Type3DiscountElement, "1");
            SeleniumHelper.SelectFromDropdownByText(BillingDateForCPPAgreementsElement, "1");

            SeleniumHelper.ClickRadioButtonSafely(CustomerSapIdExistsNoRadioButtonElement);
        }


        public void InputDealerDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            FillResellerDetails();
            FillContactDetails();
        }

        private void FillContactDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            SelectTitleFromDropdown();
            EnterContactFirstName(MpsUtil.FirstName());
            EnterContactLastName(MpsUtil.SurName());
            EnterContactTelephone(MpsUtil.CompanyTelephone());
            EnterContactEmailAdress(MpsUtil.GenerateUniqueEmail());
        }

        private void FillResellerDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            EnterDealershipName(MpsUtil.UatBswFrDealershipName());
            EnterOwnerFirstName(MpsUtil.UatBswFrDealershipName());
            EnterOwnerLastName(MpsUtil.UatBswFrDealershipName());
            EnterCEOFirstName(MpsUtil.UatBswFrDealershipName());
            EnterCEOLastName(MpsUtil.UatBswFrDealershipName());
            EnterPropertyNumber(MpsUtil.PropertyNumber());
            EnterPropertyStreet(MpsUtil.PropertyStreet());
            EnterPropertyTown(MpsUtil.PropertyTown());
            EnterPropertyPostCode(MpsUtil.PostCodeSw());
            EnterCompaniesHouseNumber(MpsUtil.CompaniesHouseNumber());
            EnterVatNumber(MpsUtil.VatNumber());
            EnterCompanyTaxNumber(MpsUtil.CompanyTaxNumber());
            EnterConsumerCreditLicenceNumber(MpsUtil.CreditLicenceNumber());
            EnterRegisteredCity(MpsUtil.RegisteredCity());
            SetCompanyBookIsRegisteredLabel(true);
            EnterBankName(MpsUtil.BankName());
            EnterBankAccountNumber(MpsUtil.BankAccountNumber());
            EnterBankSortCode(MpsUtil.BankCodeNumber());
            EnterBrotherSalesPerson(MpsUtil.BrotherSalesPerson());
            EnterDealerCulture("Français");
        }

        private void EnterDealershipName(string dealershipName)
        {
            LoggingService.WriteLogOnMethodEntry(dealershipName);
            ClearAndType(InputDealershipNameElement, dealershipName);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterOwnerFirstName(string ownerFirstName)
        {
            LoggingService.WriteLogOnMethodEntry(ownerFirstName);
            ClearAndType(InputOwnerFirstNameElement, ownerFirstName);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterOwnerLastName(string ownerLastName)
        {
            LoggingService.WriteLogOnMethodEntry(ownerLastName);
            ClearAndType(InputOwnerLastNameElement, ownerLastName);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterPropertyNumber(string propertyNumber)
        {
            LoggingService.WriteLogOnMethodEntry(propertyNumber);
            ClearAndType(InputPropertyNumberElement, propertyNumber);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterPropertyStreet(string propertyStreet)
        {
            LoggingService.WriteLogOnMethodEntry(propertyStreet);
            ClearAndType(InputPropertyStreetElement, propertyStreet);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterPropertyTown(string propertyTown)
        {
            LoggingService.WriteLogOnMethodEntry(propertyTown);
            ClearAndType(InputPropertyTownElement, propertyTown);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterPropertyPostCode(string propertyPostCode)
        {
            LoggingService.WriteLogOnMethodEntry(propertyPostCode);
            ClearAndType(InputPropertyPostCodeElement, propertyPostCode);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterCompaniesHouseNumber(string companiesHouseNumber)
        {
            LoggingService.WriteLogOnMethodEntry(companiesHouseNumber);
            ClearAndType(InputCompaniesHouseNumberElement, companiesHouseNumber);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterVatNumber(string vatNumber)
        {
            LoggingService.WriteLogOnMethodEntry(vatNumber);
            ClearAndType(InputVatNumberElement, vatNumber);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterCompanyTaxNumber(string companyTaxNumber)
        {
            LoggingService.WriteLogOnMethodEntry(companyTaxNumber);
            ClearAndType(InputCompanyTaxNumberElement, companyTaxNumber);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterConsumerCreditLicenceNumber(string consumerCreditLicenceNumber)
        {
            LoggingService.WriteLogOnMethodEntry(consumerCreditLicenceNumber);
            ClearAndType(InputCustomerCreditLicenceNumberElement, consumerCreditLicenceNumber);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterRegisteredCity(string registeredCity)
        {
            LoggingService.WriteLogOnMethodEntry(registeredCity);
            ClearAndType(InputRegisteredCityElement, registeredCity);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void SetCompanyBookIsRegisteredLabel(bool value)
        {
            LoggingService.WriteLogOnMethodEntry(value);
            SeleniumHelper.SetCheckBox(InputCompanyBookIsRegisteredCheckboxElement, value);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterBankName(string bankName)
        {
            LoggingService.WriteLogOnMethodEntry(bankName);
            ClearAndType(InputBankNameElement, bankName);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterBankAccountNumber(string bankAccountNumber)
        {
            LoggingService.WriteLogOnMethodEntry(bankAccountNumber);
            ClearAndType(InputBankAccountNumberElement, bankAccountNumber);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterBankSortCode(string bankSortCode)
        {
            LoggingService.WriteLogOnMethodEntry(bankSortCode);
            ClearAndType(InputBankSortCodeElement, bankSortCode);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterBrotherSalesPerson(string brotherSalesPerson)
        {
            LoggingService.WriteLogOnMethodEntry(brotherSalesPerson);
            ClearAndType(InputBrotherSalesPersonElement, brotherSalesPerson);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterDealerCulture(string dealerCulture)
        {
            LoggingService.WriteLogOnMethodEntry(dealerCulture);
            SeleniumHelper.SelectFromDropdownByText(InputDealerCultureElement, dealerCulture);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterCEOFirstName(string ceoFirstName)
        {
            LoggingService.WriteLogOnMethodEntry(ceoFirstName);
            ClearAndType(InputCEOFirstNameElement, ceoFirstName);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterCEOLastName(string ceoLastName)
        {
            LoggingService.WriteLogOnMethodEntry(ceoLastName);
            ClearAndType(InputCEOLastNameElement, ceoLastName);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterContactFirstName(string firstName)
        {
            LoggingService.WriteLogOnMethodEntry(firstName);
            ClearAndType(InputContactFirstNameElement, firstName);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterContactLastName(string lastName)
        {
            LoggingService.WriteLogOnMethodEntry(lastName);
            ClearAndType(InputContactLastNameElement, lastName);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterContactTelephone(string telephone)
        {
            LoggingService.WriteLogOnMethodEntry(telephone);
            ClearAndType(InputContactTelephoneElement, telephone);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void EnterContactEmailAdress(string email)
        {
            LoggingService.WriteLogOnMethodEntry(email);
            ClearAndType(InputContactEmailElement, email);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private void SelectTitleFromDropdown(string value = "0002")
        {
            LoggingService.WriteLogOnMethodEntry(value);
            if (InputContactTitleElement != null)
                SelectFromDropdownByValue(InputContactTitleElement, value);
        }

        public string GetEmail()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(InputContactEmailElement);
        }

        public string GetFirstName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(InputContactFirstNameElement);
        }

        public string GetLastName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(InputContactLastNameElement);
        }

        public string GetOwnerFirstName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(InputOwnerFirstNameElement);
        }

        public string GetOwnerLastName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(InputOwnerLastNameElement);
        }

        public string GetCeoFirstName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(InputCEOFirstNameElement);
        }

        public string GetCeoLastName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(InputCEOLastNameElement);
        }

        public string GetDealershipName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(InputDealershipNameElement);
        }

        public string GetBankName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(InputBankNameElement);
        }

        public string GetBankAccountNumber()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(InputBankAccountNumberElement);
        }

        public string GetBankSortCode()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(InputBankSortCodeElement);
        }

        public string GetBrotherSalesPerson()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(InputBrotherSalesPersonElement);
        }

        public string GetType3DiscountValue()
        {
            LoggingService.WriteLogOnMethodEntry();
            var Type3DiscountElement = SeleniumHelper.FindElementByCssSelector(Type3DiscountSelector);
            return GetFieldValue(Type3DiscountElement);
        }

        public string GetType3BillingDateValue()
        {
            LoggingService.WriteLogOnMethodEntry();
            var BillingDateForCPPAgreementsElement = SeleniumHelper.FindElementByCssSelector(BillingDateForCPPAgreementsSelector);
            return GetFieldValue(BillingDateForCPPAgreementsElement);
        }

        private string GetFieldValue(IWebElement element)
        {
            LoggingService.WriteLogOnMethodEntry(element);
            return element.GetAttribute("value");
        }
    }
}
