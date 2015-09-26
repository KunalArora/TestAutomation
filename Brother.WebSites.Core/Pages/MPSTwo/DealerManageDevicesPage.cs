using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium.Support.UI;


namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerManageDevicesPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }


        [FindsBy(How = How.CssSelector, Using = "#content_1_ComponentIntroductionAlert")]
        public IWebElement CompanyConfirmationElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DeviceListFilter_InputFilterByLocation")]
        public IWebElement CompanyLocationElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonCreateRequest")]
        public IWebElement CreateRequestElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-alert")]
        public IWebElement LocationSelectionAlertElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-installation-request-container")]
        public IWebElement InstallationRequestLineElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-searchable")]
        public IWebElement InstallationRequestContainerElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-filter-ignore button")]
        public IWebElement InstallationRequestActionButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-delete-installation-request")]
        public IWebElement InstallationRequestDeleteActionElement;
        
       
        

        

        private string GetGeneratedCompany()
        {
            return SpecFlow.GetContext("GeneratedCompanyName");
        }

        public void IsManagedDeviceScreenDisplayed()
        {
            if(CompanyConfirmationElement == null)
                throw new Exception("Managed Device screen is not displayed");

            AssertElementContainsText(CompanyConfirmationElement, GetGeneratedCompany(), "Generated Company");
        }

        public void SelectCompanyLocation()
        {
            var company = new SelectElement(CompanyLocationElement);

            var selectableList = company.Options;

            foreach (var coy in selectableList)
            {
                if (coy.Text.Contains(GetGeneratedCompany()))
                {
                    coy.Click();
                }
            }

            WebDriver.Wait(DurationType.Second, 2);

        }

        public void ClickOnNextButtonToInvokeError()
        {
            MpsUtil.ClickButtonThenNavigateToSameUrl(Driver, CreateRequestElement);
            TestCheck.AssertIsEqual(true, LocationSelectionAlertElement.Displayed, "Location alert is not displayed");
        }

        public DealerSetCommunicationMethodPage CreateInstallationRequest()
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, CreateRequestElement);
            WebDriver.Wait(DurationType.Second, 30);

            return GetTabInstance<DealerSetCommunicationMethodPage>(Driver);
        }

        public void IsInstallationRequestDisplayed()
        {
            AssertElementPresent(InstallationRequestContainerElement, "Installation not finished");
        }



    }
}
