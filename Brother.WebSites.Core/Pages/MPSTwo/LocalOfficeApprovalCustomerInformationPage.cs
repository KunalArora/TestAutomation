using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApprovalCustomerInformationPage : BasePage
    {

        [FindsBy(How = How.CssSelector, Using = "#content_0_PersonManage_InputCustomerName")]
        public IWebElement CustomerNameField;
        [FindsBy(How = How.CssSelector, Using = "#content_0_PersonManage_InputCustomerLegalForm_Input")]
        public IWebElement CustomerLegalForm;
        [FindsBy(How = How.CssSelector, Using = "#content_0_PersonManage_InputCustomerCostCentre_Input")]
        public IWebElement CustomerCostCentre;
        [FindsBy(How = How.CssSelector, Using = "#content_0_PersonManage_InputCustomerCompanyRegistrationNumber_Input")]
        public IWebElement CustomerCompanyRegistrationNumber;
        [FindsBy(How = How.CssSelector, Using = "#content_0_PersonManage_InputCustomerVatRegistrationNumber_Input")]
        public IWebElement CustomerCompanyVatRegistrationNumber;
        [FindsBy(How = How.CssSelector, Using = "#content_0_PersonManage_InputCustomerTradingStyle_Input")]
        public IWebElement CustomerTradingStyle;
        [FindsBy(How = How.CssSelector, Using = "#content_0_PersonManage_InputCustomerAuthorisedSignatory_Input")]
        public IWebElement CustomerAuthorisedSignatory;
        [FindsBy(How = How.CssSelector, Using = "#content_0_PersonManage_InputPersonEmail_Input")]
        public IWebElement CustomerPersonEmail;
        [FindsBy(How = How.CssSelector, Using = "#content_0_PersonManage_CustomerLocation_InputStreet_Input")]
        public IWebElement CustomerLocationStreetName;
        [FindsBy(How = How.CssSelector, Using = "#content_0_ButtonSave")]
        public IWebElement UpdateChanges;
        [FindsBy(How = How.CssSelector, Using = "#content_0_PersonManage_InputPersonFirstName_Input")]
        public IWebElement CustomerContactFirstName;
        [FindsBy(How = How.CssSelector, Using = "#content_0_PersonManage_InputPersonLastName_Input")]
        public IWebElement CustomerContactLastName;
        [FindsBy(How = How.CssSelector, Using = "#content_0_PersonManage_rptLocations_Actions_0 .js-mps-filter-ignore")]
        public IWebElement CustomerFirstAddressActionButton;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-location-edit")]
        public IWebElement CustomerEditButton;
        
        
        
        
        
        


        public void IsCustomerNameReadOnly()
        {
            if(CustomerNameField == null)
                throw new Exception("customer information page not displayed");

            //TestCheck.AssertIsEqual(true, CustomerNameField.GetAttribute("readonly").Equals("readonly"), 
            //                                    "customer name is not readonly view");

            TestCheck.AssertIsEqual(false, CustomerNameField.Enabled,
                                                "customer name is not readonly view");
        }

        public ReportProposalSummaryPage UpdateChangesMade()
        {
            if(UpdateChanges == null)
                throw new Exception("update changes button is not displayed");

            UpdateChanges.Click();

            return GetInstance<ReportProposalSummaryPage>();
        }

        public LocalOfficeApprovalReportManageCustomerPage StartCustomerEdit()
        {
            if(CustomerFirstAddressActionButton == null)
                throw new Exception("customer action button not displayed");

            if (CustomerEditButton == null)
                throw new Exception("Customer action button is not opened");

            CustomerFirstAddressActionButton.Click();

            WaitForElementToExistByCssSelector(".open .js-mps-location-edit");

            CustomerEditButton.Click();
            return GetInstance<LocalOfficeApprovalReportManageCustomerPage>();
        }

        public void IsCustomerTradingStyleReadOnly()
        {
            if (CustomerTradingStyle == null)
                throw new Exception("customer information page not displayed");

            //TestCheck.AssertIsEqual(true, CustomerTradingStyle.GetAttribute("readonly").Equals("readonly"),
            //                                    "customer Trading Style is not readonly view");
            TestCheck.AssertIsEqual(false, CustomerTradingStyle.Enabled,
                                                "customer Trading Style is not readonly view");
        }

        public void IsCustomerPersonEmailReadOnly()
        {
            if (CustomerPersonEmail == null)
                throw new Exception("customer information page not displayed");

            //TestCheck.AssertIsEqual(true, CustomerPersonEmail.GetAttribute("readonly").Equals("readonly"),
            //                                    "Customer Person Email is not readonly view");

            TestCheck.AssertIsEqual(false, CustomerPersonEmail.Enabled,
                                                "Customer Person Email is not readonly view");
        }

        public void EditCustomerContactLastName()
        {
            if (CustomerContactLastName == null)
                throw new Exception("First name is not displayed");

            var name = CustomerContactLastName.GetAttribute("value");

            var comboLastName = string.Format("Edited {0}", name);

            ClearAndType(CustomerContactLastName, comboLastName);

        }

        public void EditCustomerContactFirstName()
        {
            if (CustomerContactFirstName == null)
                throw new Exception("Last name is not displayed");

            var name = CustomerContactFirstName.GetAttribute("value");

            var comboFirstName = string.Format("Edited {0}", name);

            ClearAndType(CustomerContactFirstName, comboFirstName);

        }

        public void EditCustomerStreetName()
        {
            if (CustomerLocationStreetName == null)
                throw new Exception("Street name is not displayed");

            var name = CustomerLocationStreetName.GetAttribute("value");

            var comboStreetName = string.Format("Edited {0}", name);

            ClearAndType(CustomerLocationStreetName, comboStreetName);

        }

        public void IsCustomerAuthorisedSignatoryReadOnly()
        {
            if (CustomerAuthorisedSignatory == null)
                throw new Exception("customer information page not displayed");

            //TestCheck.AssertIsEqual(true, CustomerAuthorisedSignatory.GetAttribute("readonly").Equals("readonly"),
            //                                    "Customer Authorised Signatory is not readonly view");

            TestCheck.AssertIsEqual(false, CustomerAuthorisedSignatory.Enabled,
                                                "Customer Authorised Signatory is not readonly view");
        }

        public void IsCustomerLegalFormDisabled()
        {
            if (CustomerLegalForm == null)
                throw new Exception("customer information page not displayed");

            //TestCheck.AssertIsEqual(true, CustomerLegalForm.GetAttribute("readonly").Equals("readonly"),
            //                                    "customer Legal Form is not readonly view");

            TestCheck.AssertIsEqual(false, CustomerLegalForm.Enabled,
                                                "customer Legal Form is not readonly view");
        }

        public void IsCustomerCompanyVatRegistrationNumberDisabled()
        {
            if (CustomerCompanyVatRegistrationNumber == null)
                throw new Exception("customer information page not displayed");

            //TestCheck.AssertIsEqual(true, CustomerCompanyVatRegistrationNumber.GetAttribute("readonly").Equals("readonly"),
            //                                    "Customer Company Vat Registration Number is not readonly view");

            TestCheck.AssertIsEqual(false, CustomerCompanyVatRegistrationNumber.Enabled,
                                                "Customer Company Vat Registration Number is not readonly view");
        }


        public void IsCustomerCompanyRegistrationNumberDisabled()
        {
            if (CustomerCompanyRegistrationNumber == null)
                throw new Exception("customer information page not displayed");

            //TestCheck.AssertIsEqual(true, CustomerCompanyRegistrationNumber.GetAttribute("readonly").Equals("readonly"),
            //                                    "Customer Company Registration Number is not readonly view");


            TestCheck.AssertIsEqual(false, CustomerCompanyRegistrationNumber.Enabled,
                                                "Customer Company Registration Number is not readonly view");
        }

        public void IsCustomerCostCentreDisabled()
        {
            if (CustomerCostCentre == null)
                throw new Exception("customer information page not displayed");

            //TestCheck.AssertIsEqual(true, CustomerCostCentre.GetAttribute("readonly").Equals("readonly"),
            //                                    "customer cost centre is not readonly view");

            TestCheck.AssertIsEqual(false, CustomerCostCentre.Enabled,
                                                "customer cost centre is not readonly view");
        }

        
    }
}
