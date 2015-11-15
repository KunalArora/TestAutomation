using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CustomerConsummablePage : BasePage
    {
        public static string Url = "/";


        [FindsBy(How = How.CssSelector, Using = ".alert.alert-info")]
        public IWebElement DeviceScreenRef;
        [FindsBy(How = How.CssSelector, Using = "[href=\"/mps/customer/consumables/devices\"] span")]
        public IWebElement ConsumableDeviceScreenTab;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ContractDevicesList_Contracts_List_0_CellSerialNo_0")]
        public IWebElement ConsumableDeviceSerialNumber;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-filter-ignore")]
        public IWebElement ConsumableDeviceActionButton;
        [FindsBy(How = How.CssSelector, Using = ".open #content_1_ContractDevicesList_Contracts_List_0_ListActions_0_List_0_Link_0")]
        public IWebElement ConsumableDeviceRaiseConsummableButton;


        public void IsCorrectDeviceSerialNumberDisplayed()
        {
            var serialNumber = SpecFlow.GetContext("SerialNumber");
            var displayedSerial = ConsumableDeviceSerialNumber.Text;

            TestCheck.AssertIsEqual(serialNumber, displayedSerial, "Displayed serial number is not the same as the one entered");
        }

        public void IsCorrectContractIdDisplayed()
        {
            var contractRef = SpecFlow.GetContext("ProposalId");
            var consumableMessage = DeviceScreenRef.Text;

            TestCheck.AssertTextContains(contractRef, consumableMessage, "The right proposal id is not displayed");
        }

        public void IsConsumableScreenDisplayed()
        {
            if(ConsumableDeviceScreenTab == null)
                throw new Exception("Consumable screen not displayed");

            AssertElementPresent(ConsumableDeviceScreenTab, "Consumable screen");
        }


        public ConsumableOrderingPage NavigateToConsumableOrderingPage()
        {
            ConsumableDeviceActionButton.Click();
            WebDriver.Wait(DurationType.Second, 2);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ConsumableDeviceRaiseConsummableButton);
            //ConsumableDeviceRaiseConsummableButton.Click();

            return GetInstance<ConsumableOrderingPage>(Driver);
        }

    }
}
