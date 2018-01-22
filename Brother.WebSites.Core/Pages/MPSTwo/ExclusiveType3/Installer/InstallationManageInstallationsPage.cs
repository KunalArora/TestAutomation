using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Installer
{
    public class InstallationManageInstallationsPage: BasePage, IPageObject
    {
        private const string _validationElementSelector = ".mps-dataTables-footer";
        private const string _url = "/mps/installation/manage-installations?t={token}"; // TODO: Replace token with dynamic parameter

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        // Web Elements
        [FindsBy(How = How.CssSelector, Using = ".js-mps-ribbon-install-devices")]
        public IWebElement BulkInstallDevicesButton;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-paging-dt-select-all")]
        public IWebElement BulkSelectAllDevicesCheckboxElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-searchable")]
        public IWebElement DeviceContainerElement;

        public int NumberOfDevices()
        {
            WriteLogOnMethodEntry();
            return SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement).Count;
        }
    }
}
