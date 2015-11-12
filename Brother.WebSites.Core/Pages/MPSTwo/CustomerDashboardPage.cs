using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CustomerDashboardPage : BasePage
    {
        public static string Url = "/";


        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/customer/invoices\"] .media-body")]
        public IWebElement CustomerDashboardInvoiceLink;


        public void IsCustomerDashboardPageDisplayed()
        {
            if(CustomerDashboardInvoiceLink == null)
                throw new Exception("Customer Dashboard is not displayed");
            AssertElementPresent(CustomerDashboardInvoiceLink, "Customer Dashboard page");
        }


    }
}
