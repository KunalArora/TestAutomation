using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminDealerDefaultsPage : BasePage
    {
        public static string URL = "/mps/local-office/dealer-defaults/default";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "content_1_InputDeviceDefaultMargin_Input")]
        public IWebElement HardwareDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_InputDeliveryDefaultMargin_Input")]
        public IWebElement DeliveryDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_InputOptionsDefaultMargin_Input")]
        public IWebElement AccesoriesDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_InputInstallationDefaultMargin_Input")]
        public IWebElement InstallationDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_InputServicePackDefaultMargin_Input")]
        public IWebElement ServicePackDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_InputMonoClickDefaultMargin_Input")]
        public IWebElement MonoClickDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_InputColourClickDefaultMargin_Input")]
        public IWebElement ColourClickDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_InputAllInclusiveDefaultMargin_Input")]
        public IWebElement AllInclusiveMargin;
        [FindsBy(How = How.Id, Using = "content_1_InputMinimumMonthlyContractValue_Input")]
        public IWebElement MinimumMonthlyContractValue;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement DealerDefaultsSaveButton;


        private IWebElement HardwareDefaultMarginElement()
        {
            string element = "#content_1_InputDeviceDefaultMargin_Input option[selected=\"selected\"]";

            return GetElementByCssSelector(element);
        }

        public LocalOfficeAdminDealerDefaultsPage SaveDealerDefaults()
        {
            IWebElement element = HardwareDefaultMarginElement();
            string hoge = element.GetAttribute("value");
            SpecFlow.SetContext("HardwareDefaultMargin", element.GetAttribute("value"));

            if (DealerDefaultsSaveButton == null)
                throw new NullReferenceException("Save button is not Dealer Defaults");
            DealerDefaultsSaveButton.Click();

            return GetTabInstance<LocalOfficeAdminDealerDefaultsPage>(Driver);
        }
        
    }
}
