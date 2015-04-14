using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Properties;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace Brother.Tests.Selenium.Lib.Pages.BrotherOnline.AccountManagement
{
    public class MyOrdersPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["MyOrders"].ToString(); }
        }

        [FindsBy(How = How.CssSelector, Using = ".content-wrapper.my-invoices")] 
        public IWebElement InvoiceSection;

        [FindsBy(How = How.CssSelector, Using = ".order-placed")]
        public IWebElement OrderPlaced;

        [FindsBy(How = How.CssSelector, Using = ".order-placed-date")]
        public IWebElement OrderPlacedDate;

        [FindsBy(How = How.CssSelector, Using = ".product-info")]
        public IWebElement ProductInfo;

        [FindsBy(How = How.CssSelector, Using = ".orders-list-container .item-header [href*='orderid')")]
        public  IList<IWebElement>OrdersList;

        public void ValidateOmniJoinPlanChange()
        {
            // NOTE: For an OmniJoin package change the PurchStatus is not used so cannot be validated
            var orders = GetOrderList();
            orders.OrderByDescending(x => x);
            var xmlResponseData = string.Empty;
            if (orders.Count != 2)
            {
                Helper.MsgOutput(string.Format("Error: Incorrect OmniJoin order count to validate. Expected [{0}], but found [{1}]", 2, orders.Count));
            }
            Helper.MsgOutput("Validating last order received to retrieve previous order reference");
            if (!Utils.ConfirmSapOrder(orders[0].ToString(), out xmlResponseData))
            {
                Helper.MsgOutput(string.Format("Error validating order [{0}]", orders[0]));
            }

            Utils.OrderInformation currentOrderInfo = Utils.GetOrderInformation(xmlResponseData);

            // check that the current order contains a reference to the previous order or first order of OmniJoin
            Assert.AreEqual(currentOrderInfo.ReferenceOrder, orders[orders.Count - 1].ToString(), "OmniJoin plan change: previous order number does not match reference order number");
        }

        private List<long> GetOrderList()
        {
            var orderNumberList = new List<long>();
            OrdersList = Driver.FindElements(By.CssSelector(".orders-list-container .item-header a"));
            foreach (var element in OrdersList)
            {
                var orderNumber = element.GetAttribute("href").Split('=');
                if (orderNumber.Length == 2)
                {
                    orderNumberList.Add(Convert.ToInt64(orderNumber[1]));
                }
                else
                {
                    Helper.MsgOutput("Error adding Order Number to list");
                }
            }
            return orderNumberList;
        }

        public string GetOrderInformation()
        {
            // Get order status - e.g.Confirmed
            // Get order item
            // Get order placed date
            // Get order confirmation and compare with order number

            return string.Empty;
        }

        private IWebElement ViewOrderDetailsButton()
        {
            var orderNum = ScenarioContext.Current["OrderConfirmationNumber"].ToString();
            var locatorString = string.Format("a[href*='orderid={0}']", orderNum);
            return Driver.FindElement(By.CssSelector(locatorString));
        }
        public void IsViewOrderDetailsButtonAvailable()
        {
            if (ViewOrderDetailsButton() == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            AssertElementPresent(ViewOrderDetailsButton(), "View Order Details Button");
        }

        public OrderDetailsPage ViewOrderDetailsButtonClick()
        {
            ViewOrderDetailsButton().Click();
            return GetInstance<OrderDetailsPage>(Driver);
        }

    }
}
