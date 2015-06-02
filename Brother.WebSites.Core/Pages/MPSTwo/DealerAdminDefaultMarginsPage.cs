using System;
using System.Configuration;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerAdminDefaultMarginsPage : BasePage
    {
        public static string URL = "/mps/dealer/admin/default-margins/margins";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_DealerMarginTable_InputDeviceMargin_Input")]
        private IWebElement HardwareDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_DealerMarginTable_InputOptionMargin_Input")]
        private IWebElement AccesoriesDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_DealerMarginTable_InputDeliveryMargin_Input")]
        private IWebElement DeliveryDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_DealerMarginTable_InputInstallationMargin_Input")]
        private IWebElement InstallationDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_DealerMarginTable_InputServicePackMargin_Input")]
        private IWebElement ServicePackDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_DealerMarginTable_InputMonoClickRateMargin_Input")]
        private IWebElement MonoClickDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_DealerMarginTable_InputColourClickRateMargin_Input")]
        private IWebElement ColourClickDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_DealerMarginTable_InputAllInclusiveMargin_Input")]
        private IWebElement AllInclusiveMargin;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement DealerDefaultsSaveButton;

        private const int HardwareDefaultMarginDefault = 15;
        private const int AccesoriesDefaultMarginDefault = 15;
        private const int DeliveryDefaultMarginDefault = 15;
        private const int InstallationDefaultMarginDefault = 15;
        private const int ServicePackDefaultMarginDefault = 15;
        private const int MonoClickDefaultMarginDefault = 15;
        private const int ColourClickDefaultMarginDefault = 15;
        private const int AllInclusiveMarginDefault = 15;
        private const int duration = 10;

        private void EnterMarginInAutomatically(IWebElement element, int defval)
        {
            string strval = element.GetAttribute("value");
            int val = Convert.ToInt32(strval);
            string newVal;

            if (val.Equals(defval + duration))
            {
                newVal = defval.ToString();
            }
            else
            {
                int incrementedVal = Convert.ToInt32(val) + 1;
                newVal = incrementedVal.ToString();          
            }

            ClearAndType(element, newVal);
        }

        public void EnterHardwareDefaultMarginInAutomatically()
        {
            EnterMarginInAutomatically(HardwareDefaultMargin, HardwareDefaultMarginDefault);
        }
        public void EnterAccesoriesDefaultMarginInAutomatically()
        {
            EnterMarginInAutomatically(AccesoriesDefaultMargin, AccesoriesDefaultMarginDefault);
        }
        public void EnterDeliveryDefaultMarginInAutomatically()
        {
            EnterMarginInAutomatically(DeliveryDefaultMargin, DeliveryDefaultMarginDefault);
        }
        public void EnterInstallationDefaultMarginInAutomatically()
        {
            EnterMarginInAutomatically(InstallationDefaultMargin, InstallationDefaultMarginDefault);
        }
        public void EnterServicePackDefaultMarginInAutomatically()
        {
            EnterMarginInAutomatically(ServicePackDefaultMargin, ServicePackDefaultMarginDefault);
        }
        public void EnterMonoClickDefaultMarginInAutomatically()
        {
            EnterMarginInAutomatically(MonoClickDefaultMargin, MonoClickDefaultMarginDefault);
        }
        public void EnterColourClickDefaultMarginInAutomatically()
        {
            EnterMarginInAutomatically(ColourClickDefaultMargin, ColourClickDefaultMarginDefault);
        }
        public void EnterAllInclusiveMarginInAutomatically()
        {
            EnterMarginInAutomatically(AllInclusiveMargin, AllInclusiveMarginDefault);
        }

        public void ClickNextButton()
        {
            ScrollTo(DealerDefaultsSaveButton);
            DealerDefaultsSaveButton.Click();
        }

        public void StoreMarginConfiguration()
        {
            SpecFlow.SetContext("DealerAdminHardwareDefaultMargin", HardwareDefaultMargin.GetAttribute("value"));
            SpecFlow.SetContext("DealerAdminAccesoriesDefaultMargin", AccesoriesDefaultMargin.GetAttribute("value"));
            SpecFlow.SetContext("DealerAdminDeliveryDefaultMargin", DeliveryDefaultMargin.GetAttribute("value"));
            SpecFlow.SetContext("DealerAdminInstallationDefaultMargin", InstallationDefaultMargin.GetAttribute("value"));
            SpecFlow.SetContext("DealerAdminServicePackDefaultMargin", ServicePackDefaultMargin.GetAttribute("value"));
            SpecFlow.SetContext("DealerAdminMonoClickDefaultMargin", MonoClickDefaultMargin.GetAttribute("value"));
            SpecFlow.SetContext("DealerAdminColourClickDefaultMargin", ColourClickDefaultMargin.GetAttribute("value"));
            SpecFlow.SetContext("DealerAdminAllInclusiveMargin", AllInclusiveMargin.GetAttribute("value"));
        }
    }
}
