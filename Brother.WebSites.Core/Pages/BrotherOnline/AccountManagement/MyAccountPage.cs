using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    public class MyAccountPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".content-wrapper.my-invoices")]
        public IWebElement InvoiceSection;

        [FindsBy(How = How.XPath, Using = ".//*[@id='content_2_navigationcontainer_0_MenuItemsRepeater_LeftMenuLink_6']")]
        public IWebElement BusinessDetailsLink;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_2_InvoicesRepeater_tablerow_0")]
        public IWebElement InvoiceRow;

        [FindsBy(How = How.CssSelector, Using = "#content_2_navigationcontainer_0_MenuItemsRepeater_LeftMenuLink_9")]
        public IWebElement SignInDetailsMenu;


        public void IsInvoiceSectionAvailable()
        {
            if (InvoiceSection == null)
            {
                throw new Exception("Unable to locate Invoice Section on page");
            }
            AssertElementPresent(InvoiceSection, "Invoice Section");
        }

        public void VerifyInvoiceIsDisplayed()
        {
            if (!InvoiceRow.Displayed)
            {
                throw new Exception("Unable to locate Invoice Column on page");
            }
            AssertElementPresent(InvoiceRow, "Invoice Column");
        }
        public BusinessDetailsPage ClickBusinessDetailsLink()
        {
            ScrollTo(BusinessDetailsLink);
            BusinessDetailsLink.Click();
            return GetInstance<BusinessDetailsPage>(Driver);
        }

    }
}
