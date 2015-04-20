using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories.Printers;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement.PaymentMethods;
using Brother.WebSites.Core.Pages.InstantInk;
using Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal;
using Brother.WebSites.Core.Pages.OmniJoin.Plans;
using OpenQA.Selenium;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    public class GlobalNavigationModule : BasePage
    {
        // Static Global Navigation class which services the Brother Online orders side navigation bar common
        // to Brother Online orders, and the global navigation such as the Brother Nav bar.
        private const string SideNavMenu = @".side-nav";
        private const string ProductList = @"#product-list";
        private const string BrotherHomePage = "#master-logo > a";
        private const string MyAccountButtons = ".conference-button[href*='']";
        private const string InstankInkButtons = ".dp-button-aqua[href*='']";
        private const string PartnerPortalButtons = ".dp-button-aqua[href*='']";
        private const string TopNavigationBar = "#primary-nav .wrapper .cf";
        private const string SignOutLink = "a[href*='sign-out']";
        private const string BackToBrotherOnlineButton = ".back-button-holder";


#region Menu Navigation (Private)

        private static IWebElement GetSignOutLink(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(SignOutLink));
        }

        private static IWebElement GetBackToBrotherOnlineButton(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(BackToBrotherOnlineButton));
        }

        private static IWebElement MyAccountSideNavigationMenu(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(SideNavMenu));
        }

        private static IWebElement ProductListNavigationMenu(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ProductList));
        }

        private static IWebElement TopNavigationMenu(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(TopNavigationBar));
        }

        private static IWebElement MyAccountButtonSearch(ISearchContext driver, string searchString)
        {
            var button = MyAccountButtons.Replace("href*=''", string.Format("href*='{0}'", searchString.ToLower()));
            return driver.FindElement(By.CssSelector(button));
        }

        private static IWebElement PartnerPortalButtonSearch(ISearchContext driver, string searchString)
        {
            var button = PartnerPortalButtons.Replace("href*=''", string.Format("href*='{0}'", searchString.ToLower()));
            return driver.FindElement(By.CssSelector(button));
        }

        private static IWebElement InstantInkButtonSearch(ISearchContext driver, string searchString)
        {
            var button = InstankInkButtons.Replace("href*=''", string.Format("href*='{0}'", searchString.ToLower()));
            return driver.FindElement(By.CssSelector(button));
        }

        private static IWebElement FindLink(IEnumerable<IWebElement> links, string searchString)
        {
            if (links == null)
            {
                TestCheck.AssertFailTest("Unable to locate Navigation links");
            }

            foreach (var link in links)
            {
                if (!link.TagName.Contains("a")) continue;
                if (!link.Text.ToLower().Contains(searchString.ToLower())) continue;
                AssertElementPresent(link, "Navigation Link");
                return link;
            }
            return null;
        }

        private static IWebElement GetAccountMenuItem(ISearchContext driver, string menuItemString)
        {
            // searches for the correct language string
            var menuItem = Navigation.ConvertMyAccountMenuItemForLocale(menuItemString);
            ReadOnlyCollection<IWebElement> navigationLinks;

            try
            {
                navigationLinks =
                MyAccountSideNavigationMenu(driver).FindElements(By.XPath(@"//*[contains(@id,'navigationcontainer')]"));
            }
            catch (NoSuchElementException notSuchElement)
            {
                Helper.MsgOutput("Unable to find Account Menu Item", notSuchElement.Message);
                return null;
            }
            return FindLink(navigationLinks, menuItem);
        }

        private static IWebElement GetProductListMenuItem(ISearchContext driver, string menuItemString)
        {
            // searches for the correct language string
            var menuItem = Navigation.ConvertProductMenuItemForLocale(menuItemString);
            ReadOnlyCollection<IWebElement> navigationLinks;
            try
            {
                navigationLinks =
                ProductListNavigationMenu(driver).FindElements(By.XPath(@"//*[starts-with(@id,'content_2_ProductsTabRepeater')]"));
            }
            catch (NoSuchElementException notSuchElement)
            {
                Helper.MsgOutput("Unable to find Product List Menu Item", notSuchElement.Message);
                return null;
            }
            return FindLink(navigationLinks, menuItem);
        }

        private static IWebElement GetTopNavigationMenuItem(ISearchContext driver, string menuItemString)
        {
            // searches for the correct language string
            var menuItem = Navigation.ConvertPrimaryNavMenuItemForLocale(menuItemString);
            ReadOnlyCollection<IWebElement> navigationLinks;
            try
            {
                navigationLinks =
                TopNavigationMenu(driver).FindElements(By.XPath(@"//*[starts-with(@id,'TopNavigationControl')]"));
            }
            catch (NoSuchElementException notSuchElement)
            {
                Helper.MsgOutput("Unable to find Top Nav Menu Item", notSuchElement.Message);
                return null;
            }
            return FindLink(navigationLinks, menuItem);
        }

        private static IWebElement GetMyAccountMenuButton(ISearchContext driver, string productString, string buttonNameString)
        {
            // searches for the correct language string
            var buttonName = Navigation.ConvertButtonNameForLocale(productString, buttonNameString);
            var button = MyAccountButtonSearch(driver, buttonName);
            if (button == null)
            {
                TestCheck.AssertFailTest(string.Format("Unable to locate button [{0}] in Product panel", buttonName));
            }
            return button;
        }

        private static IWebElement GetInstantInkMenuButton(ISearchContext driver, string productString, string buttonNameString)
        {
            string buttonName = Navigation.ConvertButtonNameForLocale(productString, buttonNameString);
            var button = InstantInkButtonSearch(driver, buttonName);
            if (button == null)
            {
                TestCheck.AssertFailTest(string.Format("Unable to locate button [{0}] in Instant Ink Product panel", buttonName));
            }
            return button;
        }

        private static IWebElement GetPartnerPortalMenuButton(ISearchContext driver, string productString, string buttonNameString)
        {
            string buttonName = Navigation.ConvertButtonNameForLocale(productString, buttonNameString);
            var button = PartnerPortalButtonSearch(driver, buttonName);
            if (button == null)
            {
                TestCheck.AssertFailTest(string.Format("Unable to locate button [{0}] in Partner Portal Product panel", buttonName));
            }
            return button;
        }

#endregion
        
#region Navigation  (Public)


        public static LaserPrintersPage NavigateToLaserPrintersSite(IWebDriver driver, string url)
        {
            var currentUrl = TestController.CurrentDriver.Url;
            if (url.Contains("?sc_lang")) // language specific site
            {
                var language = url.Split('=');

                // set the language for the site
                TestController.CurrentDriver.Navigate()
                    .GoToUrl(string.Format("{0}?sc_lang={1}", currentUrl, language[1]));
            } 
            var newUrl = string.Format("{0}{1}", currentUrl, url);
            TestController.CurrentDriver.Navigate().GoToUrl(newUrl);
            return GetInstance<LaserPrintersPage>(driver, "", "");
        }

        // Notes: 
        //
        // The Left hand menu on the Welcome Back page can be accessed using calls to 
        // GetProductNavidationMenu()

        // When in My Account, the left hand menu list (orders, Invoices etc)
        //GetMyAccountMenuItem()
        
        /// <summary>
        /// Retrieves a Product Menu Item (left hand menu present in Welcome Back page)
        /// </summary>
        /// <param name="menuItem">string representing the name of the Menu Item, e.g "My Account"</param>
        /// <returns>IWebElement</returns>
        public static IWebElement GetProductNavigationMenu(string menuItem)
        {
            return GetProductListMenuItem(TestController.CurrentDriver, menuItem);
        }

        /// <summary>
        /// Retrieves a Menu Button whilst the My Account Product menu item is selected
        /// e.g My Sign In preferences, Invoices, Address Book
        /// </summary>
        /// <param name="product">string representing Product Name, e.g. MyAccount</param>
        /// <param name="button">string representing the Button, e.g. PersonalDetails</param>
        /// <returns>IWebElement</returns>
        public static IWebElement GetMyAccountInfoButton(string product, string button)
        {
            return GetMyAccountMenuButton(TestController.CurrentDriver, product, button);
        }

        /// <summary>
        /// Retrieves the Menu Items from the My Account menu list (when in MY Account)
        /// </summary>
        /// <param name="menuItem">string which represents the menu item, e.g. "SignInDetails", "PaymentMethods"</param>
        /// <returns>IWebElement</returns>
        public static IWebElement GetMyAccountMenuItem(string menuItem)
        {
            return GetAccountMenuItem(TestController.CurrentDriver, menuItem);
        }

        // Specific To Instant Ink
        public static IWebElement GetInstantInkMenuButton(string button)
        {
            return GetInstantInkMenuButton(TestController.CurrentDriver, "InstantInk", button);
        }

        // Specific To Partner Portal
        public static IWebElement GetPartnerPortalInfoButton(string product, string button)
        {
            return GetPartnerPortalMenuButton(TestController.CurrentDriver, product, button);
        }

        // Top Navigation Menu 
        public static IWebElement GetPrimaryNavigationMenuItem(string menuItem)
        {
            return GetTopNavigationMenuItem(TestController.CurrentDriver, menuItem);
        }

        public static void IsSignOutLinkAvailable(IWebDriver driver)
        {
            if (GetSignOutLink(driver) == null)
            {
                throw new Exception("Unable to locate link on page");
            }
            AssertElementPresent(GetSignOutLink(driver), "Sign Out Link");
        }

        // Clicks the Sign Out link and returns back to the Registration Page
        public static HomePage ClickSignOutLink(IWebDriver driver)
        {
            GetSignOutLink(driver).Click();
            return GetInstance<HomePage>(driver, "", "");
        }

        public static WelcomeBackPage BrotherOnlineGoHome(IWebDriver driver)
        {
            GetAccountMenuItem(driver, "BrotherOnlineHome").Click();
            return GetInstance<WelcomeBackPage>(driver, "", "");
        }

        public static WelcomeBackPage BackToBrotherOnlineButtonClick(IWebDriver driver)
        {
            var backToBrotherOnlineButton = GetBackToBrotherOnlineButton(driver);
            AssertElementPresent(backToBrotherOnlineButton, "Back to Brother Online Button");
            backToBrotherOnlineButton.Click();
            return GetInstance<WelcomeBackPage>(driver, "", "");
        }

        public static ManagePlanPage ManageOmniJoinPlanButtonClick(IWebDriver driver, IWebElement button)
        {
            TestCheck.AssertIsNotNull(button, "Manage OJ Plan Button");
            button.Click();
            return GetInstance<ManagePlanPage>(driver, "", "");
        }

        public static PartnerPortalPage PartnerPortalButtonClick(IWebDriver driver, IWebElement button)
        {
            TestCheck.AssertIsNotNull(button, "Partner Portal Button");
            button.Click();
            return GetInstance<PartnerPortalPage>(driver, "", "");
        }

        public static StatusMonitorPage StatusMonitorButtonClick(IWebDriver driver, IWebElement button)
        {
            TestCheck.AssertIsNotNull(button, "Status Monitor Button");
            button.Click();
            return GetInstance<StatusMonitorPage>(driver, "", "");
        }

#endregion NAVIGATION

#region MyAccount menu items

        public static MyPersonalDetailsPage PersonalDetailsButtonClick(IWebDriver driver, IWebElement button)
        {
            TestCheck.AssertIsNotNull(button, "Personal Details Button");
            button.Click();
            return GetInstance<MyPersonalDetailsPage>(driver, "", "");
        }
        
        public static MySignInDetailsPage MySignInDetailsMenuOptionClick(IWebDriver driver, IWebElement signInDetailsMenuItem)
        {
            signInDetailsMenuItem.Click();
            return GetInstance<MySignInDetailsPage>(driver, "", "");
        }

        public static MySignInDetailsPage SignInPreferencesButtonClick(IWebDriver driver, IWebElement button)
        {
            TestCheck.AssertIsNotNull(button, "Sign In Preferences Button");
            button.Click();
            return GetInstance<MySignInDetailsPage>(driver, "", "");
        }

        public static MyPaymentMethodsPage PaymentMethodsMenuClick(IWebDriver driver, IWebElement button)
        {
            TestCheck.AssertIsNotNull(button, "Payment Method Menu");
            button.Click();
            return GetInstance<MyPaymentMethodsPage>(driver, "", "");
        }

        public static MyOrdersPage OrdersMenuClick(IWebDriver driver, IWebElement button)
        {
            TestCheck.AssertIsNotNull(button, "Orders Menu");
            button.Click();
            return GetInstance<MyOrdersPage>(driver, "", "");
        }

        public static WelcomeBackPage MyAccountMenuItemClick(IWebDriver driver, IWebElement menuItem)
        {
            TestCheck.AssertIsNotNull(menuItem, "My Account Menu Item");
            menuItem.Click();
            return GetInstance<WelcomeBackPage>(driver, "", "");
        }

#endregion MyAccount menu items
    }
}
