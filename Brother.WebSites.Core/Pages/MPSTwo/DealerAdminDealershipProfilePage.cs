using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerAdminDealershipProfilePage : BasePage
    {

        public static string Url = "/mps/dealer/admin/profile/dealership";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_1_InputProfile_Input")]
        public IWebElement ProfileBoxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSave")]
        public IWebElement ProfileSaveButtonElement;
        

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


    }
}
