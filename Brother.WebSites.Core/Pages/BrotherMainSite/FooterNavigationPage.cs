using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherMainSite
{
   public class FooterNavigationPage : BasePage
    {
            
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#loginuser")]
        public IWebElement UsernameInputField;

        [FindsBy(How = How.CssSelector, Using = "[href='http://www.brother-network.co.uk/']")]
        public IWebElement BrotherNetwork;

        [FindsBy(How = How.CssSelector, Using = "#footer-products > li:nth-child(6) > a")]
        public IWebElement SuppliesAndAccessoriesFooterLink;

        [FindsBy(How = How.XPath, Using = "//*[@id='footer-products']/li[8]/a")]
        public IWebElement LatestPromotionsFooterLink;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > div > h4 > a.button-green")]
        public IWebElement RegisterAndClaimButton;

        [FindsBy(How = How.CssSelector, Using = "#by-supply-number > input")]
        public IWebElement EnterSuppliesCodeTextBox;

        [FindsBy(How = How.CssSelector, Using = "#footer-products > li:nth-child(4) > a")]
        public IWebElement FaxMachinesFooterLink;

        [FindsBy(How = How.ClassName, Using = "button-orange")]
        public IWebElement ViewAllProductsOrangeButton;

        [FindsBy(How = How.CssSelector, Using = "#footer-products > li:nth-child(3) > a")]
        public IWebElement LabelPrinterFooterLink;

        [FindsBy(How = How.CssSelector, Using = "#footer-products > li:nth-child(2) > a")]
        public IWebElement ScannerFooterLink;

        [FindsBy(How = How.CssSelector, Using = "#footer-products > li:nth-child(1) > a")]
        public IWebElement PrinterFooterLink;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > ul.slides.cf > li:nth-child(1) > div.left-content > p:nth-child(5) > a")]
        public IWebElement ViewColourLaserRangeButton;

        [FindsBy(How = How.CssSelector, Using = "#footer-websiteinfomation > li:nth-child(1) > a")]
        public IWebElement AccessibilityFooterLink;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(5) > a")]
        public IWebElement SiteMapLink;

        [FindsBy(How = How.CssSelector, Using = "#footer-websiteinfomation > li:nth-child(3) > a")]
        public IWebElement PrivacyPolicyFooterLink;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(5) > p:nth-child(4) > a")]
        public IWebElement TermsAndConditionsLink;
        
       [FindsBy(How = How.CssSelector, Using = "#footer-websiteinfomation > li:nth-child(4) > a")]
       public IWebElement TermsAndConditionsFooterLink;

       [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(5) > a")]
       public IWebElement BrotherAdminTeamLink;
       

        private const string SuppliesAndAccessoriesFooter = "#footer-products > li:nth-child(6) > a";

        private const string LatestPromotionsFooter = "//*[@id='footer-products']/li[8]/a";

        private const string FaxMachinesFooter = "#footer-products > li:nth-child(4) > a";

        private const string LabelPrinterFooter = "#footer-products > li:nth-child(3) > a";

        private const string ScannerFooter = "#footer-products > li:nth-child(2) > a";

        private const string PrinterFooter = "#footer-products > li:nth-child(1) > a";

        private const string ViewColourLaserRangeBtn = "#main > div > div > div:nth-child(3) > div > ul.slides.cf > li:nth-child(1) > div.left-content > p:nth-child(5) > a";

        private const string AccessibilityFooter = "#footer-websiteinfomation > li:nth-child(1) > a";

        private const string SiteMap = "#main > div > div > div:nth-child(5) > a";

        private const string PrivacyPolicyFooter = "#footer-websiteinfomation > li:nth-child(3) > a";

        private const string TermsAndConditions = "#main > div > div > div:nth-child(5) > p:nth-child(4) > a";

        private const string TermsAndConditionsFooter = "#footer-websiteinfomation > li:nth-child(4) > a";

        private const string BrotherAdminTeam = "#main > div > div > div:nth-child(5) > a";

        public void HoverAndClickBrotherNetwork()
        {
            BrotherNetwork.Click();
        }

        public void CheckPageExist()
        {
            AssertElementPresent(UsernameInputField, "login input field");
        }

        public void ClickLatestPromotionsLink()
        {
            WaitForElementToExistByXPath(LatestPromotionsFooter, 3, 3);
            MoveToElement(LatestPromotionsFooterLink);
            LatestPromotionsFooterLink.Click();
        }

        public void HasLatestPromotionsPageLoaded()
        {
            if (RegisterAndClaimButton == null)
            {
                throw new NullReferenceException("Latest promotions page has not loaded");
            }
            AssertElementPresent(RegisterAndClaimButton, "Register and claim button");
        }

        public void ClickSuppliesAndAccessoriesLink()
        {
            WaitForElementToExistByCssSelector(SuppliesAndAccessoriesFooter);
            MoveToElement(SuppliesAndAccessoriesFooterLink);
            SuppliesAndAccessoriesFooterLink.Click();
        }

        public void HasSuppliesAndAccessoriesPageLoaded()
        {
            if (EnterSuppliesCodeTextBox == null)
            {
                throw new NullReferenceException("Supplies and accessories page has not loaded");
            }
            AssertElementPresent(EnterSuppliesCodeTextBox, "Enter supplies code text box");
        }

        public void ClickFaxMachinesFooterLink()
        {
            WaitForElementToExistByCssSelector(FaxMachinesFooter);
            MoveToElement(FaxMachinesFooterLink);
            FaxMachinesFooterLink.Click();
        }

        public void HasFaxMachinesPageLoaded()
        {
            if (ViewAllProductsOrangeButton == null)
            {
                throw new NullReferenceException("Fax machines page has not loaded");
            }
            AssertElementPresent(ViewAllProductsOrangeButton, "View all products orange button");
        }

        public void ClickLabelPrinterFooterLink()
        {
            WaitForElementToExistByCssSelector(LabelPrinterFooter);
            MoveToElement(LabelPrinterFooterLink);
            LabelPrinterFooterLink.Click();
        }

        public void HasLabelPrintersPageLoaded()
        {
            if (ViewAllProductsOrangeButton == null)
            {
                throw new NullReferenceException("Label printers page has not loaded");
            }
            AssertElementPresent(ViewAllProductsOrangeButton, "View all products orange button");
        }

        public void ClickScannerFooterLink()
        {
            WaitForElementToExistByCssSelector(ScannerFooter);
            MoveToElement(ScannerFooterLink);
            ScannerFooterLink.Click();
        }

        public void HasScannersPageLoaded()
        {
            if (ViewAllProductsOrangeButton == null)
            {
                throw new NullReferenceException("Scanners page has not loaded");
            }
            AssertElementPresent(ViewAllProductsOrangeButton, "View all products orange button");
        }

        public void ClickPrinterFooterLink()
        {
            WaitForElementToExistByCssSelector(PrinterFooter);
            MoveToElement(PrinterFooterLink);
            PrinterFooterLink.Click();
        }

        public void HasPrintersPageLoaded()
        {
            WaitForElementToExistByCssSelector(ViewColourLaserRangeBtn);
            if (ViewColourLaserRangeButton == null)
            {
                throw new NullReferenceException("Printers page has not loaded");
            }
            AssertElementPresent(ViewColourLaserRangeButton, "Colour laser button");
        }

        public void ClickAccessibilityFooterLink()
        {
            WaitForElementToExistByCssSelector(AccessibilityFooter);
            MoveToElement(AccessibilityFooterLink);
            AccessibilityFooterLink.Click();
        }

        public void HasAccessibilityPageLoaded()
        {
            WaitForElementToExistByCssSelector(SiteMap);
            if (SiteMapLink == null)
            {
                throw new NullReferenceException("Accessibility page has not loaded");
            }
            AssertElementPresent(SiteMapLink, "Site map link");
        }

        public void ClickPrivacyPolicyLink()
        {
            WaitForElementToExistByCssSelector(PrivacyPolicyFooter);
            MoveToElement(PrivacyPolicyFooterLink);
            PrivacyPolicyFooterLink.Click();
        }

        public void HasPrivacyPolicyPageLoaded()
        {
            WaitForElementToExistByCssSelector(TermsAndConditions);
            if (TermsAndConditionsLink == null)
            {
                throw new NullReferenceException("Privacy policy page has not loaded");
            }
            AssertElementPresent(TermsAndConditionsLink, "Terms and conditions link");
        }

        public void ClickTermsAndConditionsLink()
        {
            WaitForElementToExistByCssSelector(TermsAndConditionsFooter);
            MoveToElement(TermsAndConditionsFooterLink);
            TermsAndConditionsFooterLink.Click();
        }

        public void HasTermsAndConditionsPageLoaded()
        {
            WaitForElementToExistByCssSelector(BrotherAdminTeam);
            if (BrotherAdminTeamLink == null)
            {
                throw new NullReferenceException("Terms and conditions page has not loaded");
            }
            AssertElementPresent(BrotherAdminTeamLink, "Brother admin team link");
        }
    }
}


