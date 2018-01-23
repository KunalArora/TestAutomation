using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Installer
{
    public class InstallationSelectMethodPage: BasePage, IPageObject
    {
        private const string _validationElementSelector = ".js-mps-install-option-button";
        private const string _url = "/mps/installation/select-method?t={token}"; // TODO: Replace token with dynamic parameter

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        private const string InstallationMethodDataAttributeSelector = "install-option-id";
        

        // Web Elements
        [FindsBy(How = How.CssSelector, Using = ".alert.alert-info.mps-alert.js-mps-alert")]
        public IWebElement AgreementReferenceAlertElement;
        [FindsBy(How = How.Id, Using = "content_0_LabelSelectDevicesInfo")]
        public IWebElement NumberOfDevicesAlertElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-more-install-options")]
        public IWebElement MoreInstallationOptionsButtonElement;
        

        public void VerifyDeviceDetails(string expectedAgreementReference, int expectedNumberOfDevices, string modelName = null)
        {
            string displayedAgreementReference = AgreementReferenceAlertElement.Text;

            TestCheck.AssertIsEqual(
                displayedAgreementReference, string.Format("Agreement reference: {0}", expectedAgreementReference),
                "Agreement Reference validation failed on Select Installation Method page");

            string displayedNumberOfDevices = NumberOfDevicesAlertElement.Text;

            if (modelName != null) // For single device installation
            {
                TestCheck.AssertIsEqual(
                    displayedNumberOfDevices, string.Format("Total number of devices selected for installation: {0} (Model: {1})", expectedNumberOfDevices.ToString(), modelName), 
                    "Number of devices/model name validation failed on Select Installation Method page");
            }
            else // For bulk installation
            {
                TestCheck.AssertIsEqual(
                    displayedNumberOfDevices, string.Format("Total number of devices selected for installation: {0}", expectedNumberOfDevices.ToString()),
                    "Number of devices validation failed on Select Installation Method page");
            }
        }

        public IWebElement BORInstallationButton(int findElementTimeout)
        {
            return SeleniumHelper.FindElementByDataAttributeValue(InstallationMethodDataAttributeSelector, "1", findElementTimeout);
        }

        public IWebElement WebInstallationButton(int findElementTimeout)
        {
            return SeleniumHelper.FindElementByDataAttributeValue(InstallationMethodDataAttributeSelector, "2", findElementTimeout);
        }

        public IWebElement USBInstallationButton(int findElementTimeout)
        {
            return SeleniumHelper.FindElementByDataAttributeValue(InstallationMethodDataAttributeSelector, "4", findElementTimeout);
        }
    }
}
