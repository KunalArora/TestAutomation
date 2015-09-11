using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    public class BusinessDetailsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }
        [FindsBy(How = How.XPath, Using = ".//*[@id='content_2_navigationcontainer_0_MenuItemsRepeater_LeftMenuLink_6']")]
        public IWebElement BusinessDetailsLink;

        [FindsBy(How = How.CssSelector, Using = "#content_2_innercontent_1_btnUpdateBasicDetails")]
        public IWebElement UpdateDetailsButton;

        [FindsBy(How = How.CssSelector, Using = "#content_2_innercontent_1_SubmitButton")]
        public IWebElement UpdateButton;

        [FindsBy(How = How.Id, Using = "BusinessAccountYesRadioButton")]
        public IWebElement UseMyAccountForBusinessCheckbox;
        
        [FindsBy(How = How.Id, Using = "txtCompanyName")]
        public IWebElement CompanyNameTextBox;

        [FindsBy(How = How.Id, Using = "BusinessSectorDropDown")]
        public IWebElement BusinessSectorDropDownList;

        [FindsBy(How = How.Id, Using = "CompanySizeDropDown")]
        public IWebElement EmployeeCountDropDownList;
        
        [FindsBy(How = How.Id, Using = "txtVatNumber")]
        public IWebElement VatNumberTextBox;
        
        [FindsBy(How = How.CssSelector, Using = ".info-bar")]
        public IWebElement InformationMessageBar;

        [FindsBy(How = How.Id, Using = "BusinessAccountNoRadioButton")]
        public IWebElement DoNotUseMyAccountForBusinessCheckbox;

        public string UpdateButtonId = "#content_2_innercontent_1_SubmitButton";

        public string SwitchAccTypeError = "#business-checkboxes > span > div.error.server-error";

        [FindsBy(How = How.Id, Using = "content_2_innercontent_1_CompanyNameRequiredValidator")]
        public IWebElement CompanyNameErrorMessage;

        [FindsBy(How = How.Id, Using = "content_2_innercontent_1_valBusinessSector")]
        public IWebElement BusinessSectorErrorMessage;
        
        
        public void IsUpdateButtonAvailable()
        {
            IWebElement updateButton = null;
            if (WaitForElementToExistByCssSelector(UpdateButtonId, 5, 5))
            {
                updateButton = Driver.FindElement(By.CssSelector(UpdateButtonId));
            }
            AssertElementPresent(updateButton, "Update Button");
        }


        public void CannotSwitchAccMsgDisplayed()
        {
            IWebElement SwitchAccTypeErrorMsg = null;
            if (WaitForElementToExistByCssSelector(SwitchAccTypeError, 5, 5))
            {
                SwitchAccTypeErrorMsg = Driver.FindElement(By.CssSelector(SwitchAccTypeError));
            }
            AssertElementPresent(SwitchAccTypeErrorMsg, "Switch Account Error Message");
        }

        public void UpdateButtonClick()
        {
            if (UpdateButton == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            AssertElementPresent(UpdateButton, "Update Button");
        }

        public void UseAccountForBusiness()
        {
            UseMyAccountForBusinessCheckbox.Click();
            TestCheck.AssertIsEqual("True", UseMyAccountForBusinessCheckbox.Selected.ToString(), "Use Account For Business Button");
        }
        public void PopulateCompanyNameTextBox(string companyName)
        {
            ScrollTo(CompanyNameTextBox);
            CompanyNameTextBox.SendKeys(companyName);
            //TestCheck.AssertIsEqual(companyName, GetTextBoxValue("CompanyNameTextBox"), "CompanyName Text Box");
        }
        public void PopulateBusinessSectorDropDown(string businessSector)
        {
            SelectFromDropdown(BusinessSectorDropDownList, businessSector);
            AssertItemIsSelected(BusinessSectorDropDownList, businessSector, "Business Sector Drop Down List");
        }
        public void PopulateEmployeeCountDropDown(string numEmployees)
        {
            SelectFromDropdown(EmployeeCountDropDownList, numEmployees);
            AssertItemIsSelected(EmployeeCountDropDownList, numEmployees, "Number of Employees Drop Down List");
        }
        public void PopulateVatNumberTextBox(string vatNumber)
        {
            ScrollTo(VatNumberTextBox);
            VatNumberTextBox.SendKeys(vatNumber);
           // TestCheck.AssertIsEqual(vatNumber, GetTextBoxValue("VatNumberTextBox"), "Vat number Text Box");
        }
        public void DoNotUseAccountForBusiness()
        {
            DoNotUseMyAccountForBusinessCheckbox.Click();
            TestCheck.AssertIsEqual("True", DoNotUseMyAccountForBusinessCheckbox.Selected.ToString(), "Do Not Use Account For Business Button");
        }
        public void ClickUpdateButton()
        {
            if (UpdateButton == null)
            {
                throw new Exception("Unable to locate Update Button");
            }
            ScrollTo(UpdateButton);
            UpdateButton.Click();
        }

        public void ClickUpdateDetailsButton()
        {
            if (UpdateDetailsButton == null)
            {
                throw new Exception("Unable to locate Update Details Button");
            }
            ScrollTo(UpdateDetailsButton);
            UpdateDetailsButton.Click();
        }

        public void ValidateInformationMessageBarStatus(bool displayed)
        {
            if (InformationMessageBar == null)
            {
                throw new Exception("Unable to locate Information Message Bar");
            }
            ScrollTo(InformationMessageBar);
          //  TestCheck.AssertIsEqual(displayed, InformationMessageBar.Displayed, "Information Message Bar");
        }
        public void CompanyNameErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, CompanyNameErrorMessage.Displayed, "Is Error Message Displayed");
        }
        public void BusinessSectorErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, BusinessSectorErrorMessage.Displayed, "Is Error Message Displayed");
        }

        public void UseAccountForBusinessIsSelected()
        {
            TestCheck.AssertIsEqual("True", UseMyAccountForBusinessCheckbox.Selected.ToString(), "Use Account For Business Button");
        }

    }
}