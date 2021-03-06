﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerAdminDealershipUsersCreationPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "div.mps-progress-control";
        private const string _url = "/mps/dealer/admin/dealership-users/manage";

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_1_StaffManage_permissionFullDescription")]
        public IWebElement SubDealerPermissionText;
        [FindsBy(How = How.CssSelector, Using = "#content_1_StaffManage_InputTitle_Input")]
        public IWebElement SubDealerTitleElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_StaffManage_InputFirstName_Input")]
        public IWebElement SubDealerFirstNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_StaffManage_InputLastName_Input")]
        public IWebElement SubDealerLastNameElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_StaffManage_InputPosition_Input")]
        public IWebElement SubDealerPositionElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_StaffManage_InputTelephone_Input")]
        public IWebElement SubDealerTelPhoneElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_StaffManage_InputEmail_Input")]
        public IWebElement SubDealerEmailElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_StaffManage_InputNotes_Input")]
        public IWebElement SubDealerNoteElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSave")]
        public IWebElement SubDealerSaveButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_StaffManage_InputPermissionTypes_Input_0")]
        public IWebElement SubDealerRestrictedElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_StaffManage_InputPermissionTypes_Input_1")]
        public IWebElement SubDealerContractManagerElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_StaffManage_InputPermissionTypes_Input_1")]
        public IWebElement SubDealerFullElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ValidationErrors_ErrorContainer")]
        public IWebElement SubDealerErrorContainerElement;
        



        

        public void IsDealershipUserCreationPageDisplayed()
        {
            if(SubDealerPermissionText == null)
                throw new Exception("SubDealer Permission Text returned as null");

            AssertElementPresent(SubDealerPermissionText, "SubDealer Permission Text is not displayed");
        }

        public void FillSubDealerDetails(string permission)
        {
            SelectTitle();
            EnterSubdealerFirstName(MpsUtil.FirstName());
            EnterSubdealerLastName(MpsUtil.SurName());
            EnterSubdealerEmail(MpsUtil.GetSubdealerUniqueEmail());
            EnterSubdealerPosition("Manager");
            EnterSubdealerTelephone(MpsUtil.CompanyTelephone());
            EnterSubdealerNote("Automation Created this");
            SubdealerUserPermission(permission);
        }

        public void EditSubDealerDetails(string permission)
        {
            SelectTitle(1);
            EnterSubdealerPosition("Director");
            EnterSubdealerTelephone(MpsUtil.CompanyTelephone());
            EnterSubdealerNote("Eidted subdealer");
            SubdealerUserPermission(permission);
        }


        public void SelectTitle(int value = 2)
        {
            SelectFromDropDownByIndex(SubDealerTitleElement, value);
        }

        public void EnterSubdealerFirstName(string name)
        {
            ClearAndType(SubDealerFirstNameElement, name);
        }

        public void EnterSubdealerLastName(string name)
        {
            ClearAndType(SubDealerLastNameElement, name);
        }

        public void IsErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, SubDealerErrorContainerElement.Displayed, "error message is not displayed");
        }

        public void EnterSubdealerPosition(string position)
        {
            ClearAndType(SubDealerPositionElement, position);
        }

        public void EnterSubdealerTelephone(string tele)
        {
            ClearAndType(SubDealerTelPhoneElement, tele);
        }

        public void EnterSubdealerEmail(string email)
        {
            ClearAndType(SubDealerEmailElement, email);
        }

        public void EnterSubdealerNote(string note)
        {
            ClearAndType(SubDealerNoteElement, note);
        }


        public void SubdealerUserPermission(string permission)
        {
            switch (permission)
            {
                case "Full":
                    SubDealerFullElement.Click();
                    break;
                case "Restricted" :
                    SubDealerRestrictedElement.Click();
                    break;
                case "Contract Manager":
                    SubDealerContractManagerElement.Click();
                    break;
                default:
                    SubDealerRestrictedElement.Click();
                    break;

            }
        }

        public void SubmitSubdealerWithAnyDetails()
        {
            if (SubDealerSaveButtonElement == null)
                throw new Exception("SubDealer Save Button returned as null");

            SubDealerSaveButtonElement.Click();

        }

        public DealerAdminDealershipUsersPage SaveSubdealerDetails()
        {
            if (SubDealerSaveButtonElement == null)
                throw new Exception("SubDealer Save Button returned as null");

            SubDealerSaveButtonElement.Click();

            return GetInstance<DealerAdminDealershipUsersPage>();

        }

        public void EnterSubDealerDetails()
        {
            LoggingService.WriteLogOnMethodEntry();

            SelectTitle(3);
            EnterSubdealerFirstName(MpsUtil.FirstName());
            EnterSubdealerLastName(MpsUtil.SurName());
            EnterSubdealerEmail(MpsUtil.GetSubdealerUniqueEmail());
            EnterSubdealerPosition("Staff 1");
            EnterSubdealerTelephone(MpsUtil.CompanyTelephone());
            EnterSubdealerNote("Sub dealer creation");
            SubdealerUserPermission("Restricted");
        }

        public void ClickOnCreate()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.ClickSafety(SubDealerSaveButtonElement);
        }

        public string GetEmail()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(SubDealerEmailElement);
        }

        public string GetFirstName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(SubDealerFirstNameElement);
        }

        public string GetLastName()
        {
            LoggingService.WriteLogOnMethodEntry();
            return GetFieldValue(SubDealerLastNameElement);
        }

        private string GetFieldValue(IWebElement element)
        {
            LoggingService.WriteLogOnMethodEntry(element);
            return element.GetAttribute("value");
        }
    }
}
