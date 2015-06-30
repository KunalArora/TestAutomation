using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
    public class CodeActivationPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_2_txtCode")]
        public IWebElement EnterCodeTextBox;

        [FindsBy(How = How.CssSelector, Using = "a#content_1_innercontent_2_btnCode")]
        public IWebElement SubmitCodeButton;

        public void IsSubmitCodeButtonAvailable()
        {
            if (SubmitCodeButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(SubmitCodeButton, "Submit Activation Code Button");
        }

        public void IsEnterCodeTextBoxAvailable()
        {
            if (EnterCodeTextBox == null)
            {
                throw new NullReferenceException("Unable to locate text box on page");
            }
            AssertElementPresent(EnterCodeTextBox, "Enter Activation Code Text Box");
        }

        public void EnterActivationCode(string activationCode)
        {
            EnterCodeTextBox.Clear();
            EnterCodeTextBox.SendKeys(activationCode);
            TestCheck.AssertIsEqual(activationCode, GetTextBoxValue("ActivationCodeTextBox"), "Activation Code Text Box");
        }

        public SuccessPage ClickSubmitCodeButton()
        {
            ScrollTo(SubmitCodeButton);
            SubmitCodeButton.Click();
            return GetInstance<SuccessPage>(Driver);
        }
    }
}
