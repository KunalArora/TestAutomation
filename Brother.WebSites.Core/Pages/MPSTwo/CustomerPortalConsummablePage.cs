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
        [FindsBy(How = How.CssSelector, Using = "#content_1_ContractDevicesList_Contracts_List_0_CellSerialNo_0")]
        public IWebElement ConsumableDeviceFirstSerialNumber;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-filter-ignore")]
        public IWebElement ConsumableDeviceActionButton;
        [FindsBy(How = How.CssSelector, Using = ".open #content_1_ContractDevicesList_Contracts_List_0_ListActions_0_List_0_Link_0")]
        public IWebElement ConsumableDeviceRaiseConsummableButton;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/customer/consumables/orders\"]")]
        public IWebElement ConsumableOrderTab;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ContractDevicesList_Contracts_List_0_Cell_BW_0")]
        public IWebElement BlackTonerCounter;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ContractDevicesList_Contracts_List_0_Cell_C_0")]
        public IWebElement CyanTonerCounter;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-change-ordermode-to-automatic")]
        public IWebElement ConsumableDeviceChangeToAutomatic;
        [FindsBy(How = How.CssSelector, Using = "[data-original-title=\"Replenish mode: Auto\"]")]
        public IWebElement ConsumableDeviceAutomaticConfirmation;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ContractDevicesList_Contracts_List_0_ReplenishModeIcon_0")]
        public IWebElement ConsumableAutomaticConfirmation;
        
        


        public void IsCorrectDeviceSerialNumberDisplayed()
        {
            var serialNumber = MpsUserLogins.UsedSerialNumber(Driver);
            var displayedSerial = ConsumableDeviceSerialNumber.Text;

            TestCheck.AssertIsEqual(serialNumber, displayedSerial, "Displayed serial number is not the same as the one entered");
        }

        public void IsCorrectDeviceSerialNumberDisplayed(string serialNumber)
        {
            var displayedSerial = ConsumableDeviceFirstSerialNumber.Text;

            TestCheck.AssertIsEqual(serialNumber, displayedSerial, "Displayed serial number is not the same as the one entered");
        }

        public void ChangeConsumableOrderToAutomaticOrdering()
        {

            var modeText = ConsumableAutomaticConfirmation.GetAttribute("data-original-title");

            if (modeText.Equals("Replenish mode: Auto")) return;
            ConsumableDeviceActionButton.Click();
            WaitForElementToExistByCssSelector(".open .js-mps-change-ordermode-to-automatic");

            ConsumableDeviceChangeToAutomatic.Click();
            WebDriver.Wait(DurationType.Second, 5);
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

        public void IsReplenishModeAutomation()
        {
            if(ConsumableDeviceAutomaticConfirmation==null)
                throw new Exception("Replenish mode is unknown");

            TestCheck.AssertIsEqual(true, ConsumableDeviceAutomaticConfirmation.Displayed, "Replenish mode is not changed to Automatic");
        }

        public void IsConsumableScreenDisplayed()
        {
            if(ConsumableDeviceScreenTab == null)
                throw new Exception("Consumable screen not displayed");
            MpsJobRunnerPage.RunRefreshPrintCountsFromMedioCommandJob(MpsUtil.CreatedProposal(), Locale);
            MpsJobRunnerPage.RunConsumableOrderRequestsCommandJob();

            AssertElementPresent(ConsumableDeviceScreenTab, "Consumable screen");
        }

        private void RefreshDeviceScreen()
        {
            ConsumableDeviceScreenTab.Click();
        }

        public void ChangeTonerInkStatus(string toner)
        {
            MpsJobRunnerPage.SetTonerInkStatusForNewPrinter(toner);
            MpsJobRunnerPage.NotifyBocOfNewChanges();
        }

       

        public void RunConsumableOrderCreationJobs()
        {
            MpsJobRunnerPage.RunRefreshPrintCountsFromMedioCommandJob(MpsUtil.CreatedProposal(), Locale);
            MpsJobRunnerPage.RunCreateOrderAndServiceRequestsCommandJob();
            MpsJobRunnerPage.RunConsumableOrderRequestsCommandJob();
            RefreshDeviceScreen();
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


        public void IsCyanTonerCountDisplayed()
        {
            if (CyanTonerCounter == null)
                throw new Exception("Black toner element is not displayed");

            TestCheck.AssertIsEqual("1", CyanTonerCounter.Text, "Cyan toner counter is not equal 1");
        }
    }
}
