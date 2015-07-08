using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminDealerDefaultsPage : BasePage
    {
        public static string URL = "/mps/local-office/dealer-defaults/default";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/dealers']")]
        public IWebElement DealerDefaultsElement;        
        [FindsBy(How = How.Id, Using = "content_1_InputDeviceDefaultMargin_Input")]
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

        private void IsHardwareDefaultMarginAvailable()
        {
            if (HardwareDefaultMargin == null)
                throw new Exception("Hardware Default Margin % is not displayed");

            AssertElementPresent(HardwareDefaultMargin, "Hardware Default Margin % is not displayed");
        }

        public void SelectHardwareDefaultMargin()
        {
            IsHardwareDefaultMarginAvailable();

            SpecFlow.SetContext("DefaultMarginBackup", new SelectElement(HardwareDefaultMargin).SelectedOption.Text);
            var newValue = MpsUtil.DefaultMargins();
            SelectFromDropdown(HardwareDefaultMargin, newValue);
            SpecFlow.SetContext("HardwareDefaultMargin", newValue);
            DealerDefaultsSaveButton.Click();
        }

        public void CheckHardwareDefaultMargin()
        {
            var newValue = SpecFlow.GetContext("HardwareDefaultMargin");
            AssertElementValue(HardwareDefaultMargin, newValue, "Hardware Default Margin");
            SelectFromDropdown(HardwareDefaultMargin, SpecFlow.GetContext("DefaultMarginBackup"));
            DealerDefaultsSaveButton.Click();
        }

        private void IsDeliveryDefaultMarginAvailable()
        {
            if (DeliveryDefaultMargin == null)
                throw new Exception("Delivery Default Margin % is not displayed");

            AssertElementPresent(DeliveryDefaultMargin, "Delivery Default Margin % is not displayed");
        }

        public void SelectDeliveryDefaultMargin()
        {
            IsDeliveryDefaultMarginAvailable();

            SpecFlow.SetContext("DefaultMarginBackup", new SelectElement(HardwareDefaultMargin).SelectedOption.Text);
            var newValue = MpsUtil.DefaultMargins();
            SelectFromDropdown(DeliveryDefaultMargin, newValue);
            SpecFlow.SetContext("DeliveryDefaultMargin", newValue);
            DealerDefaultsSaveButton.Click();
        }

        public void CheckDeliveryDefaultMargin()
        {
            var newValue = SpecFlow.GetContext("DeliveryDefaultMargin");
            AssertElementValue(DeliveryDefaultMargin, newValue, "Delivery Default Margin");
            SelectFromDropdown(DeliveryDefaultMargin, SpecFlow.GetContext("DefaultMarginBackup"));
            DealerDefaultsSaveButton.Click();
        }

        private void IsAccesoriesDefaultMarginAvailable()
        {
            if (AccesoriesDefaultMargin == null)
                throw new Exception("Accesories Default Margin % is not displayed");

            AssertElementPresent(AccesoriesDefaultMargin, "Accesories Default Margin % is not displayed");
        }

        public void SelectAccesoriesDefaultMargin()
        {
            IsAccesoriesDefaultMarginAvailable();

            SpecFlow.SetContext("DefaultMarginBackup", new SelectElement(HardwareDefaultMargin).SelectedOption.Text);
            var newValue = MpsUtil.DefaultMargins();
            SelectFromDropdown(AccesoriesDefaultMargin, newValue);
            SpecFlow.SetContext("AccesoriesDefaultMargin", newValue);
            DealerDefaultsSaveButton.Click();
        }

        public void CheckAccesoriesDefaultMargin()
        {
            var newValue = SpecFlow.GetContext("AccesoriesDefaultMargin");
            AssertElementValue(AccesoriesDefaultMargin, newValue, "Accesories Default Margin");
            SelectFromDropdown(AccesoriesDefaultMargin, SpecFlow.GetContext("DefaultMarginBackup"));
            DealerDefaultsSaveButton.Click();
        }

        private void IsInstallationDefaultMarginAvailable()
        {
            if (InstallationDefaultMargin == null)
                throw new Exception("Installation Default Margin % is not displayed");

            AssertElementPresent(InstallationDefaultMargin, "Installation Default Margin % is not displayed");
        }

        public void SelectInstallationDefaultMargin()
        {
            IsInstallationDefaultMarginAvailable();

            SpecFlow.SetContext("DefaultMarginBackup", new SelectElement(HardwareDefaultMargin).SelectedOption.Text);
            var newValue = MpsUtil.DefaultMargins();
            SelectFromDropdown(InstallationDefaultMargin, newValue);
            SpecFlow.SetContext("InstallationDefaultMargin", newValue);
            DealerDefaultsSaveButton.Click();
        }

        public void CheckInstallationDefaultMargin()
        {
            var newValue = SpecFlow.GetContext("InstallationDefaultMargin");
            AssertElementValue(InstallationDefaultMargin, newValue, "Installation Default Margin");
            SelectFromDropdown(InstallationDefaultMargin, SpecFlow.GetContext("DefaultMarginBackup"));
            DealerDefaultsSaveButton.Click();
        }

        private void IsServicePackDefaultMarginAvailable()
        {
            if (ServicePackDefaultMargin == null)
                throw new Exception("ServicePack Default Margin % is not displayed");

            AssertElementPresent(ServicePackDefaultMargin, "ServicePack Default Margin % is not displayed");
        }

        public void SelectServicePackDefaultMargin()
        {
            IsServicePackDefaultMarginAvailable();

            SpecFlow.SetContext("DefaultMarginBackup", new SelectElement(HardwareDefaultMargin).SelectedOption.Text);
            var newValue = MpsUtil.DefaultMargins();
            SelectFromDropdown(ServicePackDefaultMargin, newValue);
            SpecFlow.SetContext("ServicePackDefaultMargin", newValue);
            DealerDefaultsSaveButton.Click();
        }

        public void CheckServicePackDefaultMargin()
        {
            var newValue = SpecFlow.GetContext("ServicePackDefaultMargin");
            AssertElementValue(ServicePackDefaultMargin, newValue, "ServicePack Default Margin");
            SelectFromDropdown(ServicePackDefaultMargin, SpecFlow.GetContext("DefaultMarginBackup"));
            DealerDefaultsSaveButton.Click();
        }

        private void IsMonoClickDefaultMarginAvailable()
        {
            if (MonoClickDefaultMargin == null)
                throw new Exception("MonoClick Default Margin % is not displayed");

            AssertElementPresent(MonoClickDefaultMargin, "MonoClick Default Margin % is not displayed");
        }

        public void SelectMonoClickDefaultMargin()
        {
            IsMonoClickDefaultMarginAvailable();

            SpecFlow.SetContext("DefaultMarginBackup", new SelectElement(HardwareDefaultMargin).SelectedOption.Text);
            var newValue = MpsUtil.DefaultMargins();
            SelectFromDropdown(MonoClickDefaultMargin, newValue);
            SpecFlow.SetContext("MonoClickDefaultMargin", newValue);
            DealerDefaultsSaveButton.Click();
        }

        public void CheckMonoClickDefaultMargin()
        {
            var newValue = SpecFlow.GetContext("MonoClickDefaultMargin");
            AssertElementValue(MonoClickDefaultMargin, newValue, "MonoClick Default Margin");
            SelectFromDropdown(MonoClickDefaultMargin, SpecFlow.GetContext("DefaultMarginBackup"));
            DealerDefaultsSaveButton.Click();
        }

        private void IsColourClickDefaultMarginAvailable()
        {
            if (ColourClickDefaultMargin == null)
                throw new Exception("ColourClick Default Margin % is not displayed");

            AssertElementPresent(ColourClickDefaultMargin, "ColourClick Default Margin % is not displayed");
        }

        public void SelectColourClickDefaultMargin()
        {
            IsColourClickDefaultMarginAvailable();

            SpecFlow.SetContext("DefaultMarginBackup", new SelectElement(HardwareDefaultMargin).SelectedOption.Text);
            var newValue = MpsUtil.DefaultMargins();
            SelectFromDropdown(ColourClickDefaultMargin, newValue);
            SpecFlow.SetContext("ColourClickDefaultMargin", newValue);
            DealerDefaultsSaveButton.Click();
        }

        public void CheckColourClickDefaultMargin()
        {
            var newValue = SpecFlow.GetContext("ColourClickDefaultMargin");
            AssertElementValue(ColourClickDefaultMargin, newValue, "ColourClick Default Margin");
            SelectFromDropdown(ColourClickDefaultMargin, SpecFlow.GetContext("DefaultMarginBackup"));
            DealerDefaultsSaveButton.Click();
        }

        private void IsAllInclusiveDefaultMarginAvailable()
        {
            if (AllInclusiveMargin == null)
                throw new Exception("AllInclusive Default Margin % is not displayed");

            AssertElementPresent(AllInclusiveMargin, "AllInclusive Default Margin % is not displayed");
        }

        public void SelectAllInclusiveDefaultMargin()
        {
            IsAllInclusiveDefaultMarginAvailable();

            SpecFlow.SetContext("DefaultMarginBackup", new SelectElement(HardwareDefaultMargin).SelectedOption.Text);
            var newValue = MpsUtil.DefaultMargins();
            SelectFromDropdown(AllInclusiveMargin, newValue);
            SpecFlow.SetContext("AllInclusiveMargin", newValue);
            DealerDefaultsSaveButton.Click();
        }

        public void CheckAllInclusiveDefaultMargin()
        {
            var newValue = SpecFlow.GetContext("AllInclusiveMargin");
            AssertElementValue(AllInclusiveMargin, newValue, "AllInclusive Default Margin");
            SelectFromDropdown(AllInclusiveMargin, SpecFlow.GetContext("DefaultMarginBackup"));
            DealerDefaultsSaveButton.Click();
        }

        public void IsDealerDefaultsLinkAvailable()
        {
            if (DealerDefaultsElement == null)
                throw new Exception("Unable to locate dealer defaults link on dashboard page");

            AssertElementPresent(DealerDefaultsElement, "Create Dealer Defaults Link");
        }

        public void ReloadPage()
        {
            IsDealerDefaultsLinkAvailable();
            DealerDefaultsElement.Click();
        }

    }
}
