using Brother.Tests.Common.Logging;
using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement
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
            LoggingService.WriteLogOnMethodEntry(values);
            ClearAndType(CustomerNameInputElement, values.CompanyName);
            ClearAndType(ContactFirstNameInputElement, values.FirstName);
            ClearAndType(ContactLastNameInputElement, values.LastName);
            ClearAndType(PropertyNumberInputElement, values.PropertyNumber);
            ClearAndType(StreetInputElement, values.PropertyStreet);
            ClearAndType(TownInputElement, values.PropertyTown);
            ClearAndType(PostcodeInputElement, values.PostCode);
        }

        public void FillNonMandatoryDetails(CustomerInformationOptionalFields values)
        {
            LoggingService.WriteLogOnMethodEntry(values);
            // Address
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

        public string EditDeviceData(string isOptionalValues)
        {
            LoggingService.WriteLogOnMethodEntry(isOptionalValues);
            CustomerInformationMandatoryFields mandatoryValues = new CustomerInformationMandatoryFields();
            FillMandatoryDetails(mandatoryValues);
            CustomerInformationOptionalFields nonMandatoryValues = null;
            if(isOptionalValues.ToLower().Equals("true"))
            {
                nonMandatoryValues = new CustomerInformationOptionalFields();
                FillNonMandatoryDetails(nonMandatoryValues);
            }

            return ValidationExpression(LoggingService, mandatoryValues, nonMandatoryValues);          
        }

        // This is used for validation purpose. 
        // It is the Address string which is displayed on Devices page after editing device data. 
        public string ValidationExpression(ILoggingService LoggingService, CustomerInformationMandatoryFields mandatoryValues, CustomerInformationOptionalFields optionalValues = null)
        {
            LoggingService.WriteLogOnMethodEntry(mandatoryValues,optionalValues);
            List<string> validationExpression = new string[] {
                mandatoryValues.CompanyName, string.Format("{0} {1}", mandatoryValues.PropertyNumber, mandatoryValues.PropertyStreet),
                mandatoryValues.PropertyTown, mandatoryValues.PostCode }.ToList();

            if (optionalValues != null)
            {
                // Note: Area is used as part of address (used for validation)
                // Insert area into correct position of the validation expression (expected address string)
                validationExpression.Insert(2, optionalValues.PropertyArea);
            }
            
            return string.Join(", ", validationExpression);
        }
    }


    //TODO: Make a separate project & add these common classes into the new project. Add reference from both MPS & Websites project to the new project to avoid circular referencing
    public class CustomerInformationMandatoryFields
    {
        private string _companyName;
        private string _firstName;
        private string _lastName;
        private string _propertyNumber;
        private string _propertyStreet;
        private string _propertyTown;
        private string _postCode;
                
        public CustomerInformationMandatoryFields()
        {
            _companyName = MpsUtil.CompanyName();
            _firstName = MpsUtil.FirstName();
            _lastName = MpsUtil.SurName();
            _propertyNumber = MpsUtil.PropertyNumber();
            _propertyStreet = MpsUtil.PropertyStreet();
            _propertyTown = MpsUtil.PropertyTown();
            _postCode = MpsUtil.PostCodeGb(); // TODO: Generalize it for all countries
        }

        public string CompanyName { get { return _companyName; } }
        public string FirstName { get { return _firstName; } }
        public string LastName { get { return _lastName; } }
        public string PropertyNumber { get { return _propertyNumber; } }
        public string PropertyStreet { get { return _propertyStreet; } }
        public string PropertyTown { get { return _propertyTown; } }
        public string PostCode { get { return _postCode; } } 
    }

    public class CustomerInformationOptionalFields
    {
        private string _telephone; 
        private string _email;
        private string _propertyArea;
        private string _deviceLocation;
        private string _costCentre;
        private string _reference1;
        private string _reference2;
        private string _reference3;
        private string _installationNotes;

        public CustomerInformationOptionalFields()
        {
            _telephone = MpsUtil.CompanyTelephone();
            _email = MpsUtil.GenerateUniqueEmail();
            _propertyArea = MpsUtil.Area();
            _deviceLocation = MpsUtil.DeviceLocation();
            _costCentre = MpsUtil.CostCentre();
            _reference1 = MpsUtil.CustomerReference();
            _reference2 = MpsUtil.BankInternalReference();
            _reference3 = MpsUtil.CustomerReference();
            _installationNotes = MpsUtil.InstallationNotes();
        }

        public string Telephone { get { return _telephone; } }
        public string Email { get { return _email; } }
        public string PropertyArea { get { return _propertyArea; } }
        public string DeviceLocation { get { return _deviceLocation; } }
        public string CostCentre { get { return _costCentre; } }
        public string Reference_1 { get { return _reference1; } }
        public string Reference_2 { get { return _reference2; } }
        public string Reference_3 { get { return _reference3; } }
        public string InstallationNotes { get { return _installationNotes; } }
    }
}
