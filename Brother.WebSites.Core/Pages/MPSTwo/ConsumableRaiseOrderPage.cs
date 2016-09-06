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
    public class ConsumableRaiseOrderPage : BasePage
    {
        public static string Url = "/";


        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonCreate[disabled=\"disabled\"]")]
        public IWebElement DisabledOrderingButton;
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/customer/consumables/raise-order\"]")]
        public IWebElement RaiseOrderActiveTab;
        [FindsBy(How = How.CssSelector, Using = ".col-sm-7 .panel-body .table tr td")]
        public IList<IWebElement> DeviceDataElements;
        [FindsBy(How = How.CssSelector, Using = ".checkbox.js-mps-printer-supply-item input")]
        public IList<IWebElement> ConsumableItemsElements;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonCreate")]
        public IWebElement SubmitButton;
        [FindsBy(How = How.CssSelector, Using = ".alert.alert-success.fade.in.mps-alert.js-mps-alert")]
        public IWebElement ConsumableOrderConfirmation;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/customer/consumables/orders\"]")]
        public IWebElement ConsumableOrderTab;
        
        
        
        


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

        public void SubmitConsumableForOrder()
        {
            HeadlessDismissAlertOk();
            ClickAcceptOnJsAlert();
            SubmitButton.Click();
            ClickAcceptOnJsAlert();
            WaitForElementToExistByCssSelector(".alert.alert-success.fade.in.mps-alert.js-mps-alert");
        }

        public void SelectBlackToner()
        {
            ConsumableItemsElements.First().Click();
            WebDriver.Wait(DurationType.Second, 2);
        }

        public void IsConsumableOrderSubmitted()
        {
           TestCheck.AssertIsEqual(true, ConsumableOrderConfirmation.Displayed, "Consumable order has not been submitted");
        }

        public ConsumableExistingOrderListPage NavigateToConsumableExistingOrderListPage()
        {
            ConsumableOrderTab.Click();

            return GetInstance<ConsumableExistingOrderListPage>(Driver);
        }


    }
}
