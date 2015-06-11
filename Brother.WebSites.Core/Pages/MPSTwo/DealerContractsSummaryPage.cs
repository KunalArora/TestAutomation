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
        [FindsBy(How = How.Id, Using = "content_1_ButtonReSignProcess")]
        private IWebElement ResignButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonReSignContractSubmit")]
        private IWebElement FinalResignButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_mpsCheckboxReSignContract_Label")]
        private IWebElement ResignInformationCheckboxElement;

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

        public void ClickReSignButton()
        {
            ScrollTo(ResignButtonElement);
            ResignButtonElement.Click();
            WebDriver.Wait(DurationType.Second, 3);
        }

        public CloudContractPage ClickFinalReSignButton()
        {
            ScrollTo(FinalResignButtonElement);
            FinalResignButtonElement.Click();

            WebDriver.Wait(DurationType.Second, 3);

            return GetTabInstance<CloudContractPage>(Driver);
        }

        public void TickResignInformationCheckbox()
        {
            if (!ResignInformationCheckboxElement.Selected)
                ResignInformationCheckboxElement.Click();
            WebDriver.Wait(DurationType.Second, 3);
        }
    }
}
