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
                // TODO: Uncomment below (& remove exception) after solving the dynamic parameter dependency problem in URL 
                // return _url; 
                throw new Exception("Cannot determine Page URL due to presence of dynamic parameters");
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



        public void FillMandatoryDetails()
        {
            ClearAndType(CustomerNameInputElement, MpsUtil.CompanyName());
            ClearAndType(ContactFirstNameInputElement, MpsUtil.FirstName());
            ClearAndType(PropertyNumberInputElement, MpsUtil.PropertyNumber());
            ClearAndType(StreetInputElement, MpsUtil.PropertyStreet());
            ClearAndType(TownInputElement, MpsUtil.PropertyTown());

            // For now, handle Post code for UK only
            // TODO: Handle other countries post code as well
            ClearAndType(PostcodeInputElement, MpsUtil.PostCodeGb());
        }

        public void FillNonMandatoryDetails()
        {
            // Address
            ClearAndType(ContactLastNameInputElement, MpsUtil.SurName());
            ClearAndType(EmailInputElement, MpsUtil.GenerateUniqueEmail());
            ClearAndType(TelephoneInputElement, MpsUtil.CompanyTelephone());
            ClearAndType(AreaInputElement, MpsUtil.Area());
            SelectFromDropDownByIndex(RegionInputElement, new Random().Next(1, 25));

            // Reference Data
            ClearAndType(DeviceLocationInputElement, MpsUtil.DeviceLocation());
            ClearAndType(CostCentreInputElement, MpsUtil.CostCentre());
            ClearAndType(Reference1InputElement, MpsUtil.CustomerReference());
            ClearAndType(Reference2InputElement, MpsUtil.BankInternalReference());
            ClearAndType(Reference3InputElement, MpsUtil.CustomerReference());

            // Installation Notes
            ClearAndType(InstallationNotesInputElement, MpsUtil.InstallationNotes());
        }

        public void EditDeviceData(string NonMandatory)
        {
            FillMandatoryDetails();
            if(NonMandatory.ToLower().Equals("yes"))
            {
                FillNonMandatoryDetails();
            }
        }
    }
}
