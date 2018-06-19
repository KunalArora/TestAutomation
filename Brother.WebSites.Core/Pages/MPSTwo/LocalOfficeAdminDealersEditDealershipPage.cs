using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminDealersEditDealershipPage : BasePage, IPageObject
    {
        private string _validationElementSelector = "#content_1_ButtonBack";
        private const string _url = "/mps/local-office/admin/dealers/edit-dealership";

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
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipManage_InputBusinessTypes_Input_0")]
        public IWebElement Type1BusinessTypeCheckboxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipManage_InputBusinessTypes_Input_1")]
        public IWebElement Type3BusinessTypeCheckboxElement;

        //Dealer details elements
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipManage_InputBankName_Input")]
        public IWebElement InputBankNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipManage_InputBankAccountNumber_Input")]
        public IWebElement InputBankAccountNumberElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipManage_InputBankSortCode_Input")]
        public IWebElement InputBankSortCodeElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipManage_InputBrotherSalesPerson_Input")]
        public IWebElement InputBrotherSalesPersonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipManage_InputDiscountForType3_Input")]
        public IWebElement InputDiscountForType3Element;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipManage_InputPreferredT3BillingDate_Input")]
        public IWebElement InputBillingDateForType3Element;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipManage_InputOwnerFirstName_Input")]
        public IWebElement InputOwnerFirstNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipManage_InputCEOFirstName_Input")]
        public IWebElement InputCEOFirstNameElement;

        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSave")]
        public IWebElement ButtonSaveElement;

        public void VerifyPopulatedDetails(string discountType3, string billingDateType3, string bankName, string bankAccountNumber, string bankSortCode, string brotherSalesPerson)
        {
            LoggingService.WriteLogOnMethodEntry(discountType3, billingDateType3, bankName, bankAccountNumber, bankSortCode, brotherSalesPerson);

            var Type1BusinessTypeCheckboxElementValue = Type1BusinessTypeCheckboxElement.GetAttribute("checked");
            var Type3BusinessTypeCheckboxElementValue = Type3BusinessTypeCheckboxElement.GetAttribute("checked");

            TestCheck.AssertIsEqual("true", Type1BusinessTypeCheckboxElementValue, "Type 1 Business type is not checked");
            TestCheck.AssertIsEqual("true", Type3BusinessTypeCheckboxElementValue, "Type 3 Business type is not checked");

            TestCheck.AssertIsEqual(bankName, InputBankNameElement.GetAttribute("value"), "Bank name does not match");
            TestCheck.AssertIsEqual(bankAccountNumber, InputBankAccountNumberElement.GetAttribute("value"), "Bank account number does not match");
            TestCheck.AssertIsEqual(bankSortCode, InputBankSortCodeElement.GetAttribute("value"), "Bank sort code does not match");
            TestCheck.AssertIsEqual(brotherSalesPerson, InputBrotherSalesPersonElement.GetAttribute("value"), "Brother sales person does not match");
        }

        public void EditDealerDetails(string countryIso)
        {
            LoggingService.WriteLogOnMethodEntry(countryIso);
            EnterDiscountForType3("2");
            EnterBillingDateForType3("2");
            EnterOwnerFirstName(MpsUtil.OwnerFirstName(GetRunTimeEnv(), countryIso));
            EnterCEOFirstName(MpsUtil.CeoFirstName(GetRunTimeEnv(), countryIso));

        }

        private void EnterDiscountForType3(string discount)
        {
            LoggingService.WriteLogOnMethodEntry(discount);
            ClearAndType(InputDiscountForType3Element, discount);
        }

        private void EnterBillingDateForType3(string billingDate)
        {
            LoggingService.WriteLogOnMethodEntry(billingDate);
            SeleniumHelper.SelectFromDropdownByText(InputBillingDateForType3Element, billingDate);
        }

        private void EnterOwnerFirstName(string ownerFirstName)
        {
            LoggingService.WriteLogOnMethodEntry(ownerFirstName);
            ClearAndType(InputOwnerFirstNameElement, ownerFirstName);
        }

        private void EnterCEOFirstName(string ceoFirstName)
        {
            LoggingService.WriteLogOnMethodEntry(ceoFirstName);
            ClearAndType(InputCEOFirstNameElement, ceoFirstName);
        }

        public string GetType3DiscountValue()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(InputDiscountForType3Element);
        }

        public string GetType3BillingDateValue()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(InputBillingDateForType3Element);
        }

        public string GetOwnerFirstName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(InputOwnerFirstNameElement);
        }

        public string GetCeoFirstName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(InputCEOFirstNameElement);
        }

        private string GetFieldValue(IWebElement element)
        {
            LoggingService.WriteLogOnMethodEntry(element);
            return element.GetAttribute("value");
        }
    }
}
