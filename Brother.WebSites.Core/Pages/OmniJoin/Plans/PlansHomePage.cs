using System;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.OmniJoin.Support;
using Brother.WebSites.Core.Pages.OmniJoin.Trial;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.Plans
{
    public class PlansHomePage : BasePage
    {
        public static string URL = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = @".button-orange[href*='free-trial']")]
        public IWebElement StartYourFreeTrialButton;

        [FindsBy(How = How.CssSelector, Using = @".button-orange[href*='plans/personal']")]
        public IWebElement OmniJoinLiteChoosePlanButton;

        [FindsBy(How = How.CssSelector, Using = @".button-orange[href*='plans/professional']")]
        public IWebElement OmniJoinProChoosePlanButton;

        [FindsBy(How = How.CssSelector, Using = @".button-orange[href*='plans/business']")]
        public IWebElement OmniJoinBusinessChoosePlanButton;

        [FindsBy(How = How.CssSelector, Using = @".button-orange[href*='contact-us']")]
        public IWebElement ContactUsButton;

        public void IsStartFreeTrialButtonAvailable()
        {
            if (StartYourFreeTrialButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(StartYourFreeTrialButton, "Start Your Free Trial Button");
        }

        public FreeTrialDownloadPage StartFreeTrialButtonClick()
        {
            ScrollTo(StartYourFreeTrialButton);
            StartYourFreeTrialButton.Click();
            return GetInstance<FreeTrialDownloadPage>(Driver);
        }

        public ProfessionalPlanPage ChooseProPlanButtonClick()
        {
            ScrollTo(OmniJoinProChoosePlanButton);
            OmniJoinProChoosePlanButton.Click();
            return GetInstance<ProfessionalPlanPage>(Driver);
        }

        public LitePlanPage ChooseLitePlanButtonClick()
        {
            ScrollTo(OmniJoinLiteChoosePlanButton);
            OmniJoinLiteChoosePlanButton.Click();
            return GetInstance<LitePlanPage>(Driver);
        }

        public BusinessPlanPage ChooseBusinessPlanButtonClick()
        {
            ScrollTo(OmniJoinBusinessChoosePlanButton);
            OmniJoinBusinessChoosePlanButton.Click();
            return GetInstance<BusinessPlanPage>(Driver);
        }

        public ContactUsPage ContactUsButtonClick()
        {
            ScrollTo(ContactUsButton);
            ContactUsButton.Click();
            return GetInstance<ContactUsPage>(Driver);
        }
    }
}
