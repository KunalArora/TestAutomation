using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
    public class CancelSubscriptionPage :BasePage
    {

        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_0_innercontent_1_CancelBtn")]
        public IWebElement CancelSubscriptionButton;

        [FindsBy(How = How.CssSelector, Using = ".error")]
        public IWebElement ReasonForCancellationDropDownListErrorMessage;

        [FindsBy(How = How.CssSelector, Using = ".error")]
        public IWebElement ConfirmwithYourAccountPasswordTxtBoxErrorMessage;

        [FindsBy(How = How.CssSelector, Using = "#content_0_innercontent_1_SitecoreTextButton1")] 
        public IWebElement RemoveCancellationButton;

        [FindsBy(How = How.CssSelector, Using = "#content_0_innercontent_1_ReasonDropDwn")]
        public IWebElement ReasonForCancellationDropDownList;

        [FindsBy(How = How.CssSelector, Using = "#passwordTxt")] 
        public IWebElement ConfirmAccountPasswordTextBox;


        public CancelSubscriptionPage ClickCancelSubscriptionButton()
        {
            if (CancelSubscriptionButton == null)
            {
                throw new NullReferenceException("Unable to locate the Cancel subscription button");

            }
            CancelSubscriptionButton.Click();
            return GetInstance<CancelSubscriptionPage>(Driver);
        }

        public void IsReasonForCancellationDropDownListErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true ,ReasonForCancellationDropDownListErrorMessage.Displayed, "Is error message displayed on reasonforcancellation field");
        }

        public void IsConfirmwithYourAccountPasswordTxtBoxErrorMessage()
        {
            TestCheck.AssertIsEqual(true ,ConfirmwithYourAccountPasswordTxtBoxErrorMessage.Displayed, "Is error message displayed on confirmwithyouraccount password field");
        }

        public void IsRemoveCancellationButtonDisplayed()
        {
            if (RemoveCancellationButton == null)
            {
                throw new NullReferenceException("Unable to locate the button");
            }
            TestCheck.AssertIsEqual(true, RemoveCancellationButton.Displayed, "Is remove cancellation button displayed");

        }
        public CancelSubscriptionPage ClickRemoveCancellationButton()
        {
            if (RemoveCancellationButton == null)
            {
                throw new NullReferenceException("Unable to locate the button");
            }
            RemoveCancellationButton.Click();
            return GetInstance<CancelSubscriptionPage>(Driver);
        }
        public void PopulateReasonForCancellationDropDownList(string reasonForDropDownList)
        {
            SelectFromDropdown(ReasonForCancellationDropDownList, reasonForDropDownList);
            AssertItemIsSelected(ReasonForCancellationDropDownList, reasonForDropDownList, "reason for cancellation dropdownlist");
        }

        public void IsCancelSubscriptionButtonDisplayed()
        {
            if (CancelSubscriptionButton == null)
            {
                throw new NullReferenceException("Unable to  locate the button");
            }
            TestCheck.AssertIsEqual(true, CancelSubscriptionButton.Displayed, "Is cancel subscription button displayed");
        }

        public void EnterConfirmAccountPassword(string confirmAccountPassword)
        {
            if (ConfirmAccountPasswordTextBox == null)
            {
                throw new NullReferenceException("unable to locat textbox");
            }
            ConfirmAccountPasswordTextBox.SendKeys(confirmAccountPassword+Keys.Tab);
            
        }
    }
}
