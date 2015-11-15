using System;
using System.Collections;
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
    public class ConsumableOrderingPage : BasePage
    {
        public static string Url = "/";


        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonCreate[disabled=\"disabled\"]")]
        public IWebElement DisabledOrderingButton;
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/customer/consumables/raise-order\"]")]
        public IWebElement RaiseOrderActiveTab;
        [FindsBy(How = How.CssSelector, Using = ".col-sm-7 .panel-body .table tr td")]
        public IList<IWebElement> DeviceDataElements;


        public void IsOrderingScreenDisplayed()
        {
            if(RaiseOrderActiveTab == null)
                throw new Exception("Raise Order screen is not displayed");

            AssertElementPresent(RaiseOrderActiveTab, "Raise Order screen is not displayed");
        }

        public void IsOrderButtonDisabled()
        {
            TestCheck.AssertIsEqual(true, DisabledOrderingButton.Displayed, "Ordering button is not disabled");
        }

        public void IsCorrectSerialNumberDisplayed()
        {
            var serialNumber = SpecFlow.GetContext("SerialNumber");
            var dataContainer = new List<object>();

            foreach (var data in DeviceDataElements)
            {
                var datatext = data.Text;
                dataContainer.Add(datatext);
            }

            TestCheck.AssertIsEqual(true, dataContainer.Contains(serialNumber), "Correct serial number is not displayed");

        }
        


    }
}
