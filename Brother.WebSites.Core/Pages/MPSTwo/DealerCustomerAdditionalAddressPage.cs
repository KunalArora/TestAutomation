using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerCustomerAdditionalAddressPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "content_1_LocationManage_InputName_Input")]
        public IWebElement AdditionalContactNameElement;
        [FindsBy(How = How.Id, Using = "content_1_LocationManage_InputDescription_Input")]
        public IWebElement AdditionalContactDescriptionElement;
        [FindsBy(How = How.Id, Using = "content_1_LocationManage_Location_InputNumber_Input")]
        public IWebElement AdditionalContactPropertyNumberElement;
        [FindsBy(How = How.Id, Using = "content_1_LocationManage_Location_InputStreet_Input")]
        public IWebElement AdditionalContactStreetNameElement;
        [FindsBy(How = How.Id, Using = "content_1_LocationManage_Location_InputArea_Input")]
        public IWebElement AdditionalContactAreaNameElement;
        [FindsBy(How = How.Id, Using = "content_1_LocationManage_Location_InputTown_Input")]
        public IWebElement AdditionalContactTownNameElement;
        [FindsBy(How = How.Id, Using = "content_1_LocationManage_Location_InputPostCode_Input")]
        public IWebElement AdditionalContactPostcodeElement;
        [FindsBy(How = How.Id, Using = "content_1_LocationManage_Location_InputRegion_Input")]
        public IWebElement AdditionalContactRegionDropdownElement;
        [FindsBy(How = How.Id, Using = "content_1_LocationManage_InputCostCentre_Input")]
        public IWebElement AdditionalContactCostCentreElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSave")]
        public IWebElement AdditionalContactSaveButtonElement;


        


        public void EnterAdditionalContactName(string name)
        {
            ClearAndType(AdditionalContactNameElement, name);
        }

        public void EnterAdditionalDescription(string desc)
        {
            ClearAndType(AdditionalContactDescriptionElement, desc);
        }
        
        public void EnterAdditionalPropertyNumber(string prop)
        {
            if (!IsIrelandSystem())
            {
                ClearAndType(AdditionalContactPropertyNumberElement, prop);
            }
            
        }

        public void EnterAdditionalStreetName(string street)
        {
            ClearAndType(AdditionalContactStreetNameElement, street);
        }

        public void EnterAdditionalAreaName(string area)
        {
            ClearAndType(AdditionalContactAreaNameElement, area);
        }

        public void EnterAdditionalTownName(string town)
        {
            ClearAndType(AdditionalContactTownNameElement, town);
        }

        public void EnterAdditionalPostcode(string code)
        {
            ClearAndType(AdditionalContactPostcodeElement, code);
        }

        public void SelectAdditionalRegion(string name)
        {
            SelectFromDropdown(AdditionalContactRegionDropdownElement, name);
        }

        public void SelectAdditionRegionByIndex(int value = 1)
        {
            SelectFromDropDownByIndex(AdditionalContactRegionDropdownElement, value);
        }

        public void EnterAdditionalCostCentre(string cost)
        {
            ClearAndType(AdditionalContactCostCentreElement, cost);
        }

        public DealerCustomersManagePage SaveAdditionalDetailsAdded()
        {
            if(AdditionalContactSaveButtonElement == null)
                throw new Exception("Additional Contact Save Button Element is not displayed");

            AdditionalContactSaveButtonElement.Click();

            return GetInstance<DealerCustomersManagePage>();
        }


        public void EnterAdditionalCustomerInformation()
        {
            if (IsUKSystem())
            {
                EnterAdditionalContactName("New " + string.Format("{0} {1}", MpsUtil.FirstName(), MpsUtil.SurName()));
                EnterAdditionalDescription("Additional UK Customer Address");
                EnterAdditionalPropertyNumber("12");
                EnterAdditionalStreetName(MpsUtil.PropertyStreet());
                EnterAdditionalAreaName("Area");
                EnterAdditionalTownName("Town");
                EnterAdditionalPostcode(MpsUtil.PostCodeGb());
                SelectAdditionalRegion("Manchester");
                EnterAdditionalCostCentre("Marketing");
            }
            else if (IsItalySystem())
            {
                EnterAdditionalContactName("New " + string.Format("{0} {1}", MpsUtil.FirstName(), MpsUtil.SurName()));
                EnterAdditionalDescription("Additional Italy Customer Address");
                EnterAdditionalStreetName(MpsUtil.PropertyStreet());
                EnterAdditionalPostcode(MpsUtil.PostCodeIt());
                EnterAdditionalTownName("Town");
                EnterAdditionalCostCentre("Marketing");
            }
            else if (IsNorwaySystem())
            {
                EnterAdditionalContactName("New " + string.Format("{0} {1}", MpsUtil.FirstName(), MpsUtil.SurName()));
                EnterAdditionalDescription("Additional Norway Customer Address");
                EnterAdditionalStreetName(MpsUtil.PropertyStreet());
                EnterAdditionalTownName("Town");
                EnterAdditionalPostcode(MpsUtil.PostCodeNo());
                EnterAdditionalCostCentre("Marketing");
            }
            else if (IsFinlandSystem())
            {
                EnterAdditionalContactName("New " + string.Format("{0} {1}", MpsUtil.FirstName(), MpsUtil.SurName()));
                EnterAdditionalDescription("Additional Finland Customer Address");
                EnterAdditionalStreetName(MpsUtil.PropertyStreet());
                EnterAdditionalTownName("Town");
                EnterAdditionalPostcode(MpsUtil.PostCodeFi());
                EnterAdditionalCostCentre("Marketing");
            }
            else if (IsSwedenSystem())
            {
                EnterAdditionalContactName("New " + string.Format("{0} {1}", MpsUtil.FirstName(), MpsUtil.SurName()));
                EnterAdditionalDescription("Additional Customer Address");
                EnterAdditionalStreetName(MpsUtil.PropertyStreet());
                EnterAdditionalTownName("Town");
                EnterAdditionalPostcode(MpsUtil.PostCodeNs());
                EnterAdditionalCostCentre("Marketing");
            }
            else if (IsGermanSystem() || IsAustriaSystem())
            {
                EnterAdditionalContactName("New " + string.Format("{0} {1}", MpsUtil.FirstName(), MpsUtil.SurName()));
                EnterAdditionalDescription("Additional Customer Address");
                EnterAdditionalPropertyNumber("12");
                EnterAdditionalStreetName(MpsUtil.PropertyStreet());
                EnterAdditionalTownName("Town");
                EnterAdditionalPostcode(MpsUtil.PostCode());
                EnterAdditionalCostCentre("Marketing");
            }
            else if (IsBelgiumSystem())
            {
                EnterAdditionalContactName("New " + string.Format("{0} {1}", MpsUtil.FirstName(), MpsUtil.SurName()));
                EnterAdditionalDescription("Additional Customer Address");
                EnterAdditionalStreetName(MpsUtil.PropertyStreet());
                EnterAdditionalTownName("Town");
                EnterAdditionalPostcode(MpsUtil.PostCodeBe());
                SelectAdditionRegionByIndex();
                EnterAdditionalCostCentre("Marketing");
            }
            else if (IsPolandSystem())
            {
                EnterAdditionalContactName("New " + string.Format("{0} {1}", MpsUtil.FirstName(), MpsUtil.SurName()));
                EnterAdditionalDescription("Additional Customer Address");
                EnterAdditionalPropertyNumber("12");
                EnterAdditionalStreetName(MpsUtil.PropertyStreet());
                EnterAdditionalTownName("Town");
                EnterAdditionalPostcode(MpsUtil.PostCodePl());
                SelectAdditionRegionByIndex();
            }
            else if (IsIrelandSystem())
            {
                EnterAdditionalContactName("New " + string.Format("{0} {1}", MpsUtil.FirstName(), MpsUtil.SurName()));
                EnterAdditionalDescription("Additional Customer Address");
                EnterAdditionalPropertyNumber("12");
                EnterAdditionalStreetName(MpsUtil.PropertyStreet());
                EnterAdditionalTownName("Town");
                EnterAdditionalPostcode(MpsUtil.PostCodeIr());
                SelectAdditionRegionByIndex();
                EnterAdditionalCostCentre("Marketing");
            }
            else if (IsSwissSystem())
            {
                EnterAdditionalContactName("New " + string.Format("{0} {1}", MpsUtil.FirstName(), MpsUtil.SurName()));
                EnterAdditionalDescription("Additional Customer Address");
                EnterAdditionalStreetName(MpsUtil.PropertyStreet());
                EnterAdditionalTownName("Town");
                EnterAdditionalPostcode(MpsUtil.PostCodeSw());
                SelectAdditionRegionByIndex();
                EnterAdditionalCostCentre("Marketing");
            }
            else if (IsNetherlandSystem())
            {
                EnterAdditionalContactName("New " + string.Format("{0} {1}", MpsUtil.FirstName(), MpsUtil.SurName()));
                EnterAdditionalDescription("Additional Customer Address");
                EnterAdditionalStreetName(MpsUtil.PropertyStreet());
                EnterAdditionalTownName("Town");
                EnterAdditionalPostcode(MpsUtil.PostCodeNl());
            }
            else if (IsFranceSystem())
            {
                EnterAdditionalContactName("New " + string.Format("{0} {1}", MpsUtil.FirstName(), MpsUtil.SurName()));
                EnterAdditionalDescription("Additional Customer Address");
                EnterAdditionalStreetName(MpsUtil.PropertyStreet());
                EnterAdditionalTownName("Town");
                EnterAdditionalPostcode(MpsUtil.PostCodeFr());
                SelectAdditionRegionByIndex();
                EnterAdditionalCostCentre("Marketing");
            }
            else if (IsSpainSystem())
            {
                EnterAdditionalContactName("New " + string.Format("{0} {1}", MpsUtil.FirstName(), MpsUtil.SurName()));
                EnterAdditionalDescription("Additional Customer Address");
                EnterAdditionalStreetName(MpsUtil.PropertyStreet());
                EnterAdditionalTownName("Town");
                EnterAdditionalPostcode(MpsUtil.PostCodeSp());
                SelectAdditionRegionByIndex();
                EnterAdditionalCostCentre("Marketing");
            }
            else if (IsDenmarkSystem())
            {
                EnterAdditionalContactName("New " + string.Format("{0} {1}", MpsUtil.FirstName(), MpsUtil.SurName()));
                EnterAdditionalDescription("Additional Customer Address");
                EnterAdditionalStreetName(MpsUtil.PropertyStreet());
                EnterAdditionalTownName("Town");
                EnterAdditionalPostcode(MpsUtil.PostCodeDk());
                EnterAdditionalCostCentre("Marketing");
            }
        }
        
        
    }
}
