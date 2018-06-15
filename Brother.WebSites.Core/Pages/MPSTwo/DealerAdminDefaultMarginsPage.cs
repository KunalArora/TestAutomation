using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerAdminDefaultMarginsPage : BasePage, IPageObject
    {
        public static string URL = "/mps/dealer/admin/default-margins/margins";
        private const string _url = "/mps/dealer/admin/default-margins/margins";
        private const string _validationElementSelector = "#content_1_ButtonNext";

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

        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/admin/default-margins']")]
        public IWebElement DefaultMarginsElement;


        [FindsBy(How = How.Id, Using = "content_1_DealerMarginTable_InputDeviceMargin_Input")]
        public IWebElement HardwareDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_DealerMarginTable_InputOptionMargin_Input")]
        public IWebElement AccessoriesDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_DealerMarginTable_InputDeliveryMargin_Input")]
        public IWebElement DeliveryDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_DealerMarginTable_InputInstallationMargin_Input")]
        public IWebElement InstallationDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_DealerMarginTable_InputServicePackMargin_Input")]
        public IWebElement ServicePackDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_DealerMarginTable_InputMonoClickRateMargin_Input")]
        public IWebElement MonoClickDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_DealerMarginTable_InputColourClickRateMargin_Input")]
        public IWebElement ColourClickDefaultMargin;
        [FindsBy(How = How.Id, Using = "content_1_DealerMarginTable_InputAllInclusiveMargin_Input")]
        public IWebElement AllInclusiveMargin;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement DealerDefaultsSaveButton;

        private const decimal HardwareDefaultMarginDefault = 15;
        private const decimal AccesoriesDefaultMarginDefault = 15;
        private const decimal DeliveryDefaultMarginDefault = 15;
        private const decimal InstallationDefaultMarginDefault = 15;
        private const decimal ServicePackDefaultMarginDefault = 15;
        private const decimal MonoClickDefaultMarginDefault = 15;
        private const decimal ColourClickDefaultMarginDefault = 15;
        private const decimal AllInclusiveMarginDefault = 15;
        private const decimal duration = 10;

        private void EnterMarginInAutomatically(IWebElement element, decimal defval)
        {
            var strval = element.GetAttribute("value");
            var val = Convert.ToDecimal(strval);

            string newVal;

            if (val.Equals(defval + duration))
            {
                newVal = defval.ToString();
            }
            else
            {
                var incrementedVal = Convert.ToDecimal(val) + 1;
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
            EnterMarginInAutomatically(AccessoriesDefaultMargin, AccesoriesDefaultMarginDefault);
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
            WaitForElementToExistByCssSelector("#content_1_DealerMarginTable_InputDeviceMargin_Input");
            SpecFlow.SetContext("DealerAdminHardwareDefaultMargin", HardwareDefaultMargin.GetAttribute("value"));
            SpecFlow.SetContext("DealerAdminAccesoriesDefaultMargin", AccessoriesDefaultMargin.GetAttribute("value"));
            SpecFlow.SetContext("DealerAdminDeliveryDefaultMargin", DeliveryDefaultMargin.GetAttribute("value"));
            SpecFlow.SetContext("DealerAdminInstallationDefaultMargin", InstallationDefaultMargin.GetAttribute("value"));
            SpecFlow.SetContext("DealerAdminServicePackDefaultMargin", ServicePackDefaultMargin.GetAttribute("value"));
            SpecFlow.SetContext("DealerAdminMonoClickDefaultMargin", MonoClickDefaultMargin.GetAttribute("value"));
            SpecFlow.SetContext("DealerAdminColourClickDefaultMargin", ColourClickDefaultMargin.GetAttribute("value"));
           // SpecFlow.SetContext("DealerAdminAllInclusiveMargin", AllInclusiveMargin.GetAttribute("value"));
        }
    }
}
