using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CompleteSwapProcessPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/dealer/contracts/manage-devices/complete-swap\"]")]
        public IWebElement CompleteSwapScreenElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonNext")]
        public IWebElement UpdateSwapElement;
        



        public void IsCompleteSwapProcessScreenDisplayed()
        {
            if(CompleteSwapScreenElement == null)
                throw new Exception("Complete swap process screen not displayed");

            AssertElementPresent(CompleteSwapScreenElement, "Complete swap process screen cannot be verified");
        }

        public void IsOldDeviceSerialNumberDisplayed()
        {
            var xpathString = "//*[text()='{0}']";
            var oldSerial = SpecFlow.GetContext("SerialNumber");
            xpathString = String.Format(xpathString, oldSerial);

            var oldSerialElement = Driver.FindElement(By.XPath(xpathString));

            TestCheck.AssertIsEqual(true, oldSerialElement.Displayed, "Old Serial number is not displayed");
        }

        public void IsNewDeviceSerialNumberDisplayed()
        {
            var xpathString = "//*[text()='{0}']";
            var newSerial = SpecFlow.GetContext("SwapSerialNumber");
            xpathString = String.Format(xpathString, newSerial);

            var newSerialElement = Driver.FindElement(By.XPath(xpathString));

            TestCheck.AssertIsEqual(true, newSerialElement.Displayed, "Old Serial number is not displayed");
        }


        public DealerManageDevicesPage CompleteSwapProcessThroughPrintCountSwap()
        {
            if(UpdateSwapElement == null)
                throw new Exception("Print counts cannot be swapped");

            UpdateSwapElement.Click();

            return GetInstance<DealerManageDevicesPage>();
        }
    }
}
