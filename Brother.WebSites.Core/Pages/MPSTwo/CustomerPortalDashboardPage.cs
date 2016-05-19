﻿using System;
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
    public class CustomerPortalDashboardPage : BasePage
    {
        public static string Url = "/";


        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/customer/invoices\"] .media-body")]
        public IWebElement CustomerDashboardInvoiceLink;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/customer/consumables\"] .media-heading")]
        public IWebElement CustomerDashboardConsummableLink;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/customer/print-counts\"] .media-heading")]
        public IWebElement CustomerDashboardPrintCountsLink;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/customer/service-requests\"] .media-heading")]
        public IWebElement CustomerDashboardServiceRequestsLink;


        public void IsCustomerDashboardPageDisplayed()
        {
            if(CustomerDashboardInvoiceLink == null)
                throw new Exception("Customer Dashboard is not displayed");
            AssertElementPresent(CustomerDashboardInvoiceLink, "Customer Dashboard page");
        }

        public CustomerPortalConsummablePage NavigateToCustomerConsummablePage()
        {
            ScrollTo(CustomerDashboardConsummableLink);
            CustomerDashboardConsummableLink.Click();
            MPSJobRunnerPage.RunRefreshPrintCountsFromMedioCommandJob();
            return GetInstance<CustomerPortalConsummablePage>(Driver);
        }

        public CustomerPortalServiceRequestsPage NavigateToCustomerServiceRequestsPage()
        {
            ScrollTo(CustomerDashboardConsummableLink);
            CustomerDashboardServiceRequestsLink.Click();
            return GetInstance<CustomerPortalServiceRequestsPage>(Driver);
        }

        public CustomerPortalPrintCountPage NavigateToCustomerPortalPrintCountPage()
        {
            ScrollTo(CustomerDashboardPrintCountsLink);
            CustomerDashboardPrintCountsLink.Click();
            MPSJobRunnerPage.RunRefreshPrintCountsFromMedioCommandJob();
            return GetInstance<CustomerPortalPrintCountPage>(Driver);
        }

    }
}