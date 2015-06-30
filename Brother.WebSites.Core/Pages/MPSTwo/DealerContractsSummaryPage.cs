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
        public static string Url = "/mps/dealer/contracts/summary";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_ButtonCancel")]
        public IWebElement CancelButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSign")]
        public IWebElement SignButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonReSignProcess")]
        public IWebElement ResignButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonReSignContractSubmit")]
        public IWebElement FinalResignButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_mpsCheckboxReSignContract_Label")]
        public IWebElement ResignInformationCheckboxElement;

        public void ClickCancelButton()
        {
            ScrollTo(CancelButtonElement);
            CancelButtonElement.Click();
        }

        public DealerContractsPage ClickSignButton()
        {
            ScrollTo(SignButtonElement);
            SignButtonElement.Click();
            WebDriver.Wait(DurationType.Second, 3);
            return GetTabInstance<DealerContractsPage>(Driver);
        }

        public void ClickReSignButton()
        {
            ScrollTo(ResignButtonElement);
            ResignButtonElement.Click();
            WebDriver.Wait(DurationType.Second, 3);
        }

        public DealerContractsPage ClickFinalReSignButton()
        {
            ScrollTo(FinalResignButtonElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, FinalResignButtonElement);

            WebDriver.Wait(DurationType.Second, 3);

            return GetTabInstance<DealerContractsPage>(Driver);
        }

        public void TickResignInformationCheckbox()
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ResignInformationCheckboxElement);
            WebDriver.Wait(DurationType.Second, 3);
        }
    }
}
