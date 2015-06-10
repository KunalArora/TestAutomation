using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerContractsSummaryPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_ButtonCancel")]
        private IWebElement CancelButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSign")]
        private IWebElement SignButtonElement;

        public void ClickCancelButton()
        {
            ScrollTo(CancelButtonElement);
            CancelButtonElement.Click();
        }

        public CloudContractPage ClickSignButton()
        {
            ScrollTo(SignButtonElement);
            SignButtonElement.Click();

            return GetTabInstance<CloudContractPage>(Driver);
        }
    }
}
