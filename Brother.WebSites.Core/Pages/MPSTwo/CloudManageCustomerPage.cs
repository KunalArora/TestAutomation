using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CloudManageCustomerPage : BasePage
    {
        public static string URL = "/mps/dealer/customers/manage";

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
            EnterCompanyName();
            EnterPropertyNumber();
            EnterPropertyStreet();
            EnterPropertyArea();
            EnterPropertyTown();
            EnterPropertyPostCode();
            EnterPropertyLegalForm();
            WebDriver.Wait(Helper.DurationType.Millisecond, 3000);
            EnterPropertyTradingStyle();
            EnterPropertyAuthorisedSignatory();
        }

        public void FillOrganisationContactDetail()
        {
            SelectTitleFromDropdown();
            EnterContactFirstName();
            EnterContactSurName();
            EnterContactTelephone();
            EnterContactEmailAdress();
        }

        public void FillOrganisationBankDetail(string payment)
        {
            switch (payment)
            {
                case "DirectDebit":
                    SelectPaymentTypeFromDropdown("1");
                    WebDriver.Wait(Helper.DurationType.Millisecond, 3000);
                    throw new System.NotImplementedException();
                    break;;

                case "Invoice":
                    SelectPaymentTypeFromDropdown("2");
                    WebDriver.Wait(Helper.DurationType.Millisecond, 3000);
                    break;

                default:
                    throw new System.NotSupportedException(payment);
            }
        }

        private void EnterCompanyName()
        {
            CompanyNameElement.SendKeys(MpsUtil.CompanyName());
        }

        private void EnterPropertyNumber()
        {
            PropertyNumberElement.SendKeys(MpsUtil.PropertyNumber());
        }

        private void EnterPropertyStreet()
        {
            PropertyStreetElement.SendKeys(MpsUtil.PropertyStreet());
        }

        private void EnterPropertyArea()
        {
            PropertyAreaElement.SendKeys(MpsUtil.FirstName());
        }

        private void EnterPropertyTown()
        {
            PropertyTownElement.SendKeys(MpsUtil.PropertyTown());
        }

        private void EnterPropertyPostCode()
        {
            PropertyPostcodeElement.SendKeys(MpsUtil.PostCode());
        }

        private void SelectRegionFromDropdown(string region)
        {
            SelectFromDropdown(RegionElement, region);
        }

        private void EnterPropertyLegalForm(string value = "1")
        {
            SelectFromDropdownByValue(PropertyLegalFormElement, value);
        }

        private void EnterPropertyTradingStyle(string value = "1")
        {
            SelectFromDropdownByValue(PropertyTradingStyleElement, value);
        }

        private void EnterPropertyAuthorisedSignatory()
        {
            var authsig = "abcdefg";
            PropertyyAuthorisedSignatoryElement.SendKeys(authsig);
        }

        private void SelectTitleFromDropdown()
        {
            if (ContactTitleElement.Displayed)
                SelectFromDropdownByValue(ContactTitleElement, "2");
        }

        private void EnterContactFirstName()
        {
            FirstNameElement.SendKeys(MpsUtil.FirstName());
        }

        private void EnterContactSurName()
        {
            LastNameElement.SendKeys(MpsUtil.SurName());
        }

        private void EnterContactTelephone()
        {
            TelephoneElement.SendKeys(MpsUtil.CompanyTelephone());
        }

        private void EnterContactEmailAdress()
        {
            EmailElement.SendKeys(MpsUtil.GenerateUniqueEmail());
        }

        private void SelectPaymentTypeFromDropdown(string value = "2")
        {
            if (PaymentTypeElement.Displayed)
                SelectFromDropdownByValue(PaymentTypeElement, value);
        }

        public CloudExisitngCustomerPage ClickSaveButton()
        {
            saveButtonElement.Click();
            return GetInstance<CloudExisitngCustomerPage>();
        }
    }
}
