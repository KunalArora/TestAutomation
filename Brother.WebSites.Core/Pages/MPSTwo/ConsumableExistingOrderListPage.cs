using System;
using System.Collections;
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
    public class ConsumableExistingOrderListPage : BasePage
    {
        public static string Url = "/";


        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-show-consumable-order-detail")]
        public IWebElement showDetailButton;
        [FindsBy(How = How.CssSelector, Using = ".btn-group.pull-right.js-mps-filter-ignore")]
        public IWebElement consumableOrderActionButton;
        [FindsBy(How = How.CssSelector, Using = "#OrderDetailHeader")]
        public IWebElement consumableOrderDetailPopUp;
        [FindsBy(How = How.CssSelector, Using = ".mps-consumable-order-detail-row td")]
        public IList<IWebElement> consumableOrderDetail;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ConsumablesOrderList_OrderList_CellOrderId_0")]
        public IWebElement sapConsumableOrderId;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ConsumablesOrderList_OrderList_CellStatus_0")]
        public IWebElement ConsumableOrderProgress;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ConsumablesOrderList_OrderList_CellSerialNo_0")]
        public IWebElement ConsumableOrderSerialNumber;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ConsumablesOrderList_OrderList_CellItemName_0")]
        public IWebElement ConsumableTonerType;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/customer/consumables/orders\"]")]
        public IWebElement ConsumableOrderTab;
        [FindsBy(How = How.CssSelector, Using = ".modal-header .close")]
        public IWebElement ClosePopUp;
       
        

        
        
        private string GetConsumableOrderId()
        {
            WebDriver.Wait(DurationType.Second, 5);
            OpenConsumableActionButton();

            var consumableOrderId = showDetailButton.GetAttribute("data-consumable-order-id");

            consumableOrderActionButton.Click();

            return consumableOrderId;
        }

        public void RemoveExistingConsumableOrder()
        {
            if (GetConsumableOrderId() != String.Empty)
            {
                MPSJobRunnerPage.RunRemoveConsumableOrderByIdJob(GetConsumableOrderId());
            }
        }

        
        public void ClosedConsumableOrder()
        {
            var success = MPSJobRunnerPage.GetConsumableOrderStatusResetMsg(GetConsumableOrderId(), "7");

            TestCheck.AssertIsEqual(true, success.Contains("Success: updated"), 
                "The consumable did not was not successfully changed to delivered");
        }

        public void OpenConsumableActionButton()
        {
            consumableOrderActionButton.Click();
            WaitForElementToExistByCssSelector(".open .js-mps-show-consumable-order-detail", 5, 5);
        }

        public void OpenOrderDetailModal()
        {
            OpenConsumableActionButton();
            showDetailButton.Click();
            WaitForElementToExistByCssSelector("#OrderDetailHeader", 5, 5);
            
        }

        public void IsBlackTonerDisplayed()
        {
            if(ConsumableTonerType == null)
                throw new Exception("Consumable toner type is not displayed");
            var consumableText = ConsumableTonerType.Text;

            StoreOrderDetails();
            TestCheck.AssertIsEqual(true, consumableText.Equals("Black Toner"), "Consumable ");
        }

        private List<string> OrderPopUpDetails()
        {
            var detailsContainer = new List<String>();

            foreach (var detail in consumableOrderDetail)
            {
                var detailText = detail.Text;

                detailsContainer.Add(detailText);
            }

            return detailsContainer;
        }

        public void StoreOrderDetails()
        {
            var sapOrderId = sapConsumableOrderId.Text;
            SpecFlow.SetContext("SAPOrderId", sapOrderId);
        }

        public void IsSapOrderIdInPopUpModal()
        {
            var sapOrderId = SpecFlow.GetContext("SAPOrderId");
            var message = String.Format("Stored SAP Order Id {0} is not available on pop up modal", sapOrderId);
            TestCheck.AssertIsEqual(true, 
                                    OrderPopUpDetails().Contains(sapOrderId), 
                                    message
                                    );
        }
        

        public void IsSerialNumberinOrderDetailDisplayed()
        {
            TestCheck.AssertIsEqual(
                                    true, 
                        OrderPopUpDetails().Contains(GetSerialNumber()), 
                     "Serial number is not displayed in order detail pop up"
                                    );
            //SyncEscapeAction(Driver);
            ClosePopUp.Click();
        }

        private string GetSerialNumber()
        {
            return SpecFlow.GetContext("SerialNumber");
        }
        

        public void IsSerialNumberDisplayedOnOrderListPage()
        {
            var displayedSerial = ConsumableOrderSerialNumber.Text;
            TestCheck.AssertIsEqual(
                                    true, 
                                    displayedSerial.Equals(GetSerialNumber()), 
                String.Format("The serial number displayed {0} is different from the stored serial number {1}", 
                                    displayedSerial, GetSerialNumber())
                                    );
        }

        public void InitialOrderProgress()
        {
            var initial = ConsumableOrderProgress.Text;
            var message = String.Format("The expected progress text was \"In Progress\" but got {0}", initial);

            TestCheck.AssertIsEqual(true, initial.Contains("In Progress"), message);
        }

        public void ClosedOrderProgress()
        {
            var closed = ConsumableOrderProgress.Text;
            var message = String.Format("The expected progress text was \"In Progress\" but got {0}", closed);

            TestCheck.AssertIsEqual(true, closed.Contains("Delivered"), message);
        }

        public void ReloadExistingOrderScreen()
        {
            ConsumableOrderTab.Click();
            WaitForElementToExistById("content_1_ConsumablesOrderList_OrderList_CellItemName_0", 5);
        }



    }
}
