using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CustomerPortalConsummablePage : BasePage
    {
        public static string Url = "/";


        [FindsBy(How = How.CssSelector, Using = ".alert.alert-info")]
        public IWebElement DeviceScreenRef;
        [FindsBy(How = How.CssSelector, Using = "[href=\"/mps/customer/consumables/devices\"] span")]
        public IWebElement ConsumableDeviceScreenTab;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ContractDevicesList_Contracts_List_1_CellSerialNo_0")]
        public IWebElement ConsumableDeviceSerialNumber;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-filter-ignore")]
        public IWebElement ConsumableDeviceActionButton;
        [FindsBy(How = How.CssSelector, Using = ".open #content_1_ContractDevicesList_Contracts_List_0_ListActions_0_List_0_Link_0")]
        public IWebElement ConsumableDeviceRaiseConsummableButton;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/customer/consumables/orders\"]")]
        public IWebElement ConsumableOrderTab;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ContractDevicesList_Contracts_List_0_Cell_BW_0")]
        public IWebElement BlackTonerCounter;
        


        public void IsCorrectDeviceSerialNumberDisplayed()
        {
            var serialNumber = MpsUserLogins.UsedSerialNumber(Driver);
            var displayedSerial = ConsumableDeviceSerialNumber.Text;

            TestCheck.AssertIsEqual(serialNumber, displayedSerial, "Displayed serial number is not the same as the one entered");
        }

        public void IsCorrectContractIdDisplayed()
        {
            var contractRef = SpecFlow.GetContext("ProposalId");
            var consumableMessage = DeviceScreenRef.Text;

            TestCheck.AssertTextContains(contractRef, consumableMessage, "The right proposal id is not displayed");
        }

        public void RemoveExistingConsumableOrderBySerialNumber()
        {
            var serialNumber = MpsUserLogins.UsedSerialNumber(Driver);
            MpsJobRunnerPage.RunRemoveConsumableOrderByInstalledPrinterJob(serialNumber);
        }



        public void IsConsumableScreenDisplayed()
        {
            if(ConsumableDeviceScreenTab == null)
                throw new Exception("Consumable screen not displayed");
            MpsJobRunnerPage.RunRefreshPrintCountsFromMedioCommandJob();
            MpsJobRunnerPage.RunConsumableOrderRequestsCommandJob();

            AssertElementPresent(ConsumableDeviceScreenTab, "Consumable screen");
        }


        public ConsumableRaiseOrderPage NavigateToConsumableRaiseOrderPage()
        {
            ConsumableDeviceActionButton.Click();
            WebDriver.Wait(DurationType.Second, 2);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ConsumableDeviceRaiseConsummableButton);
            //ConsumableDeviceRaiseConsummableButton.Click();
            
            return GetInstance<ConsumableRaiseOrderPage>(Driver);
        }

        public ConsumableExistingOrderListPage NavigateToConsumableExistingOrderListPage()
        {
            ConsumableOrderTab.Click();

            return GetInstance<ConsumableExistingOrderListPage>(Driver);
        }

        public void IsBlackTonerCountDisplayed()
        {
            if(BlackTonerCounter == null)
                throw new Exception("Black toner element is not displayed");

            TestCheck.AssertIsEqual("1", BlackTonerCounter.Text, "Black toner counter is not equal 1");
        }

    }
}
