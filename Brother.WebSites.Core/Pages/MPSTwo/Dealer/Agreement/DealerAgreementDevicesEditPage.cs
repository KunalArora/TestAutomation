using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement
{
    public class DealerAgreementDevicesEditPage: BasePage, IPageObject
    {
        private const string _validationElementSelector = "#content_1_InputCustomerName_Input";
        private const string _url = "/mps/dealer/agreement/{agreementId}/devices/edit/?id={id}"; // TODO: Replace agreementId & id with dynamic parameter

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

        public ISeleniumHelper SeleniumHelper { get; set; }

        // Web Elements

        // Mandatory field elements
        [FindsBy(How = How.Id, Using = "content_1_InputCustomerName_Input")]
        public IWebElement CustomerNameInputElement;
        [FindsBy(How = How.Id, Using = "content_1_InputContactFirstName_Input")]
        public IWebElement ContactFirstNameInputElement;
        [FindsBy(How = How.Id, Using = "content_1_Location_InputNumber_Input")]
        public IWebElement PropertyNumberInputElement;
        [FindsBy(How = How.Id, Using = "content_1_Location_InputStreet_Input")]
        public IWebElement StreetInputElement;
        [FindsBy(How = How.Id, Using = "content_1_Location_InputTown_Input")]
        public IWebElement TownInputElement;
        [FindsBy(How = How.Id, Using = "content_1_Location_InputPostCode_Input")]
        public IWebElement PostcodeInputElement;

        // Non-Mandatory field elements
        [FindsBy(How = How.Id, Using = "content_1_InputContactLastName_Input")]
        public IWebElement ContactLastNameInputElement;
        [FindsBy(How = How.Id, Using = "content_1_InputEmail_Input")]
        public IWebElement EmailInputElement;
        [FindsBy(How = How.Id, Using = "content_1_InputTelephone_Input")]
        public IWebElement TelephoneInputElement;
        [FindsBy(How = How.Id, Using = "content_1_Location_InputArea_Input")]
        public IWebElement AreaInputElement;
        [FindsBy(How = How.Id, Using = "content_1_Location_InputRegion_Input")]
        public IWebElement RegionInputElement; // dropdown
        [FindsBy(How = How.Id, Using = "content_1_InputDeviceLocation_Input")]
        public IWebElement DeviceLocationInputElement;
        [FindsBy(How = How.Id, Using = "content_1_InputCostCentre_Input")]
        public IWebElement CostCentreInputElement;
        [FindsBy(How = How.Id, Using = "content_1_InputReference1_Input")]
        public IWebElement Reference1InputElement;
        [FindsBy(How = How.Id, Using = "content_1_InputReference2_Input")]
        public IWebElement Reference2InputElement;
        [FindsBy(How = How.Id, Using = "content_1_InputReference3_Input")]
        public IWebElement Reference3InputElement;
        [FindsBy(How = How.Id, Using = "content_1_InputInstallationNotes_Input")]
        public IWebElement InstallationNotesInputElement;

        // Save button
        [FindsBy(How = How.CssSelector, Using = ".js-mps-val-btn-next")]
        public IWebElement SaveButtonElement;



        public void FillMandatoryDetails(CustomerInformationMandatoryFields values)
        {
            ClearAndType(CustomerNameInputElement, values.CompanyName);
            ClearAndType(ContactFirstNameInputElement, values.FirstName);
            ClearAndType(PropertyNumberInputElement, values.PropertyNumber);
            ClearAndType(StreetInputElement, values.PropertyStreet);
            ClearAndType(TownInputElement, values.PropertyTown);
            ClearAndType(PostcodeInputElement, values.PostCode);
        }

        public void FillNonMandatoryDetails(CustomerInformationNonMandatoryFields values)
        {

            // Address
            ClearAndType(ContactLastNameInputElement, values.LastName);
            ClearAndType(EmailInputElement, values.Email);
            ClearAndType(TelephoneInputElement, values.Telephone);
            ClearAndType(AreaInputElement, values.PropertyArea);
            SelectFromDropDownByIndex(RegionInputElement, new Random().Next(1, 25));

            // Reference Data
            ClearAndType(DeviceLocationInputElement, values.DeviceLocation);
            ClearAndType(CostCentreInputElement, values.CostCentre);
            ClearAndType(Reference1InputElement, values.Reference_1);
            ClearAndType(Reference2InputElement, values.Reference_2);
            ClearAndType(Reference3InputElement, values.Reference_3);

            // Installation Notes
            ClearAndType(InstallationNotesInputElement, values.InstallationNotes);
        }

        public void EditDeviceData(string optionalValues)
        {
            CustomerInformationMandatoryFields mandatoryValues = new CustomerInformationMandatoryFields();
            FillMandatoryDetails(mandatoryValues);

            if(optionalValues.ToLower().Equals("true"))
            {
                CustomerInformationNonMandatoryFields nonMandatoryValues = new CustomerInformationNonMandatoryFields();
                FillNonMandatoryDetails(nonMandatoryValues);
            }
        }

        public CustomerInformationMandatoryFields GetMandatoryFieldValues()
        {
            CustomerInformationMandatoryFields values = new CustomerInformationMandatoryFields();
            return values;
        }

        public CustomerInformationNonMandatoryFields GetNonMandatoryFieldValues()
        {
            CustomerInformationNonMandatoryFields values = new CustomerInformationNonMandatoryFields();
            return values;
        } 
    }


    //TODO: Make a separate project & add these common classes into the new project. Add reference from both MPS & Websites project to the new project to avoid circular referencing
    public class CustomerInformationMandatoryFields
    {
        public string CompanyName { get { return MpsUtil.CompanyName(); } }
        public string FirstName { get { return MpsUtil.FirstName(); } }
        public string PropertyNumber { get { return MpsUtil.PropertyNumber(); } }
        public string PropertyStreet { get { return MpsUtil.PropertyStreet(); } }
        public string PropertyTown { get { return MpsUtil.PropertyTown(); } }
        public string PostCode { get { return MpsUtil.PostCodeGb(); } } // TODO: Generalize it for all countries
    }

    public class CustomerInformationNonMandatoryFields
    {
        public string LastName { get { return MpsUtil.SurName(); } }
        public string Telephone { get { return MpsUtil.CompanyTelephone(); } }
        public string Email { get { return MpsUtil.GenerateUniqueEmail(); } }
        public string PropertyArea { get { return MpsUtil.Area(); } }
        public string Country { get { return "United Kingdom"; } } // TODO: Replace hard coded string
        public string DeviceLocation { get { return MpsUtil.DeviceLocation(); } }
        public string CostCentre { get { return MpsUtil.CostCentre(); } }
        public string Reference_1 { get { return MpsUtil.CustomerReference(); } }
        public string Reference_2 { get { return MpsUtil.BankInternalReference(); } }
        public string Reference_3 { get { return MpsUtil.CustomerReference(); } }
        public string InstallationNotes { get { return MpsUtil.InstallationNotes(); } }
    }
}
