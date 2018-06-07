using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerAdminDealershipProfilePage : BasePage, IPageObject
    {

        public static string Url = "/mps/dealer/admin/profile/dealership";
        private const string _validationElementSelector = "#content_1_InputLogoRemove_Label";
        private const string _url = "/mps/dealer/admin/profile/dealership";


        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

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

        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/admin/profile/dealership']")]
        public IWebElement DealershipProfileTabElement;


        [FindsBy(How = How.CssSelector, Using = "#content_1_InputProfile_Input")]
        public IWebElement ProfileBoxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSave")]
        public IWebElement ProfileSaveButtonElement;

        [FindsBy(How = How.CssSelector, Using = "#content_1_InputLogo_Input")]
        public IWebElement InputLogoElement; // upload button
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputLogoRemove_Input")]
        public IWebElement InputLogoRemoveElement; // checkbox
        [FindsBy(How = How.CssSelector, Using = "img[id='content_1_Logo']")]
        public IWebElement LogoElement; // img src=...
        [FindsBy(How = How.CssSelector, Using = "div.alert.alert-success")]
        public IWebElement DivAlertSuccessElement;
        [FindsBy(How = How.CssSelector, Using = "div.alert.alert-success button.close")]
        public IWebElement CloseAlertSuccessElement;

        private void IsDealershopProfilePageDisplayed()
        {
            if (ProfileBoxElement == null)
                throw new Exception("Dealership profile page not displayed");

            AssertElementPresent(ProfileBoxElement, "Profile box");
        }

        public void EnterDealershipProfile()
        {
            IsDealershopProfilePageDisplayed();

            var generateProfile = MpsUtil.DealerProfileSample();
            SpecFlow.SetContext("GeneratedProfile", generateProfile);
            ClearAndType(ProfileBoxElement, generateProfile);
        }

        public void SaveEnterDealerProfile()
        {
            ProfileSaveButtonElement.Click();
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void VerifyThatProfileInputedIsSaved()
        {
            var savedProfile = ProfileBoxElement.Text;
            var generatedProfile = SpecFlow.GetContext("GeneratedProfile");

            TestCheck.AssertIsEqual(savedProfile, generatedProfile, "Saved Profile must be same as inputted profile");
        }

        public void UploadLogo(string filePath)
        {
            LoggingService.WriteLogOnMethodEntry(filePath);
            InputLogoElement.SendKeys(filePath);
            SeleniumHelper.ClickSafety(ProfileSaveButtonElement);
        }

        public void RemoveLogo()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.SetCheckBox(InputLogoRemoveElement, false);
            SeleniumHelper.ClickSafety(ProfileSaveButtonElement);
        }
    }
}
