using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
   public class EditAddressPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_2_btnAddressSave")]
        public IWebElement SaveButton;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_2_rptAddressFields_AddrLine1Validtor_1")]
        public IWebElement MandatoryFieldValidationErrorMessage;

        public void ClickSaveButton()
        {
           AssertElementPresent(SaveButton, "Save Button");
           SaveButton.Click();
          
        }
        public void IsSaveButtonDisplayed()
        {
            if (SaveButton == null)
            {
                throw new NullReferenceException("Unable to locate save button");
            }
           TestCheck.AssertIsEqual(true, SaveButton.Displayed, "Is Save button displayed");
       }

       public void IsMandatoryFieldValidationErrorMessageDisplayed()
       {
           TestCheck.AssertIsEqual(true, MandatoryFieldValidationErrorMessage.Displayed, "Is mandatory field valdiation error message displayed");
       }
    }
}
