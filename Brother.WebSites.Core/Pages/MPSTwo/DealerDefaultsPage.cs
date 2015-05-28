using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerDefaultsPage : BasePage
    {
        public static string URL = "/mps/local-office/dealer-defaults/default";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_InputDeviceDefaultMargin_Input option:selected")]
        private IWebElement HardwareDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_InputDeliveryDefaultMargin_Input")]
        private IWebElement DeliveryDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_InputOptionsDefaultMargin_Input")]
        private IWebElement AccesoriesDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_InputInstallationDefaultMargin_Input")]
        private IWebElement InstallationDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_InputServicePackDefaultMargin_Input")]
        private IWebElement ServicePackDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_InputMonoClickDefaultMargin_Input")]
        private IWebElement MonoClickDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_InputColourClickDefaultMargin_Input")]
        private IWebElement ColourClickDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_InputAllInclusiveDefaultMargin_Input")]
        private IWebElement AllInclusiveMargin;
        [FindsBy(How = How.Id, Using = "content_1_InputMinimumMonthlyContractValue_Input")]
        private IWebElement MinimumMonthlyContractValue;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement DealerDefaultsSaveButton;

        private void IsHardwareDefaultMargin()
        {
            if (HardwareDefaultMargin == null)
                throw new NullReferenceException("Hardware Default Margin element is not Dealer Defaults");

            AssertElementPresent(HardwareDefaultMargin, "Create HardwareDefault Margin");
        }
        public DealerDefaultsPage SaveDealerDefaults()
        {
            if (DealerDefaultsSaveButton == null)
                throw new NullReferenceException("Save button is not Dealer Defaults");
            DealerDefaultsSaveButton.Click();
            string hoge = HardwareDefaultMargin.Text;
//            SpecFlow.SetContext("HardwareDefaultMargin", HardwareDefaultMargin.Text);
            return GetTabInstance<DealerDefaultsPage>(Driver);
        }
        
    }
}
