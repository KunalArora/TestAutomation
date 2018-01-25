using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Installer
{
    public class InstallationCloudWebPage: BasePage, IPageObject
    {
        private const string _validationElementSelector = ".mps-device-container.js-mps-device";
        private const string _url = "/mps/installation/cloud-web?t={token}"; // TODO: Replace token with dynamic parameter

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }



        private const string IPAddress1Selector = "[id*=content_0_List_InputIp1_]";
        private const string IPAddress2Selector = "[id*=content_0_List_InputIp2_]";
        private const string IPAddress3Selector = "[id*=content_0_List_InputIp3_]";
        private const string IPAddress4Selector = "[id*=content_0_List_InputIp4_]";
        private const string DeviceLocationSelector = "[id*=content_0_List_InputDeviceLocation_]";
        private const string CostCentreSelector = "[id*=content_0_List_InputCostCentre_]";
        private const string ConnectButtonSelector = ".js-mps-button-connect";
        private const string IsConnectedSelector = ".responding";


        // Web Elements
        [FindsBy(How = How.CssSelector, Using = ".js-mps-button-refresh")]
        public IWebElement RefreshButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".panel-body > .table.table-striped > tbody")]
        public IWebElement DeviceTableContainerElement;

        // Fill device details & hit connect for this deviceId
        public void FillDeviceDetailsAndClickConnect(string mpsDeviceId, int findElementTimeout, string windowHandle)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId,findElementTimeout,windowHandle);
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceTableContainerElement);
            foreach(var element in deviceRowElements)
            {
                if (element.GetAttribute("data-id").Equals(mpsDeviceId))
                {
                    ClearAndType(element.FindElement(By.CssSelector(IPAddress1Selector)), "1");
                    ClearAndType(element.FindElement(By.CssSelector(IPAddress2Selector)), "1");
                    ClearAndType(element.FindElement(By.CssSelector(IPAddress3Selector)), "1");
                    ClearAndType(element.FindElement(By.CssSelector(IPAddress4Selector)), "1");

                    ClearAndType(element.FindElement(By.CssSelector(DeviceLocationSelector)), MpsUtil.DeviceLocation());
                    ClearAndType(element.FindElement(By.CssSelector(CostCentreSelector)), MpsUtil.CostCentre());

                    SeleniumHelper.ClickSafety(
                        SeleniumHelper.FindElementByCssSelector(element, ConnectButtonSelector, findElementTimeout), findElementTimeout);

                    SeleniumHelper.CloseBrowserTabsExceptMainWindow(windowHandle);
                }
            }
        }


        public bool AreAllDevicesConnected(int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(findElementTimeout);
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceTableContainerElement);
            foreach (var element in deviceRowElements)
            {
                if (!SeleniumHelper.IsElementDisplayed(element, IsConnectedSelector))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
