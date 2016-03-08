using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.Account
{
  public  class Web1HomePage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".content.cf .wrapper .hero .hero-buttons .button")]
        public IWebElement SignInCreateAccountButton;

        public void IsSignInCreateAccountButtonAvailable()
        {
            if (SignInCreateAccountButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(SignInCreateAccountButton, "Sign in / Create an account");
        }

        public Web1RegistrationPage ClickSignInCreateAccountButton()
        {
            MoveToElement(SignInCreateAccountButton);
            SignInCreateAccountButton.Click();
            return GetInstance<Web1RegistrationPage>(Driver);
        }

        [FindsBy(How = How.CssSelector, Using = "#cookieLawBar > div > a.button-blue")]
        public IWebElement AcceptCookiesButton;

        [FindsBy(How = How.CssSelector, Using = "#cookieLawBar > div > p")]
        public IWebElement CookiesInformationBar;

        [FindsBy(How = How.CssSelector, Using = "#cookieLawBar > div > a.button-grey")]
        public IWebElement FindOutMoreCookiesButton;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div > p:nth-child(3) > a")]
        public IWebElement PrivacyPolicyLink;

        [FindsBy(How = How.CssSelector, Using = ".content-unit.six>p>a")]
        public IWebElement TermsAndConditionsLink;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div > p:nth-child(3) > a")]
        public IWebElement ContactUsLink;

        [FindsBy(How = How.CssSelector, Using = "#services > div.carousel-outer > div > div > div:nth-child(2) > p > strong > span > a")]
        public IWebElement CreativeCenterLink;

        [FindsBy(How = How.CssSelector, Using = "#cccontent_0_landingpagecontent_1_CenterRepeater_CenterOptionLink_1")]
        public IWebElement CreativeCenterFamilyLink;

        [FindsBy(How = How.CssSelector, Using = "#cccontent_0_landingpagecontent_1_CenterRepeater_CenterOptionLink_0")]
        public IWebElement CreativeCenterBusinessLink;

        [FindsBy(How = How.CssSelector, Using = ".account [id*=pagetop_0_RegisterLink]")]
        public IWebElement CreativeCenterRegisterLoginLink;

        [FindsBy(How = How.CssSelector, Using = "#cccontent_1_singlecolumnform_1_SignUpButton")]
        public IWebElement CreativeCenterCreateAccountLink;

        [FindsBy(How = How.Id, Using = "cccontent_1_pagetop_0_Logout")]
        public IWebElement CreativeCenterLogoutLink;

        [FindsBy(How = How.CssSelector, Using = "#hide")]
        public IWebElement NoToCreativeCenterSurveyButton;

        [FindsBy(How = How.Id, Using = "FirstNameTextBox")]
        public IWebElement FirstNameCCTextBox;

        [FindsBy(How = How.Id, Using = "LastNameTextBox")]
        public IWebElement LastNameCCTextBox;

    }
}
