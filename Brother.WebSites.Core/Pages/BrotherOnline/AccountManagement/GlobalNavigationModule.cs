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
        private const string SideNavMenu = @".content-box.left-nav-container.cf .side-nav";
        private const string MyAccountMenuItem = "6d822e49-5b57-4c4c-8e2d-3f4a29b49b05";
        private const string PaymentMethodsMenuItem = "2cd6775a-02e4-4478-8818-de518fe73cf8";
        private const string BrotherOnlineGoHomeMenuItem = "110d559f-dea5-42ea-9c1c-8a5df7e70ef9";
        private const string MyBusinessDetailsMenuItem = "294daeb7-aaa8-4202-b845-d89121cf3b3d";
        private const string InstantInkMenuItem = "f200cbab-dac8-4dfd-a10f-9c1af427a95c";
        //private const string SideNavMenu = @".side-nav";
        private const string ProductList = @"#product-list";
        private const string BrotherHomePage = "#master-logo > a";
        private const string MyAccountButtons = ".conference-button[href*='']";
        private const string InstankInkButtons = ".dp-button-aqua[href*='']";
        private const string PartnerPortalButtons = ".dp-button-aqua[href*='']";
        private const string TopNavigationBar = "#primary-nav .wrapper .cf";
        private const string SignOutLink = "a[href='/sign-out']";
        private const string BackToBrotherOnlineButton = ".back-button-holder";
      

#region Menu Navigation (Private)

        private static IWebElement FindElement(ISearchContext driver, string element)
        {
            if (WaitForElementToExistByCssSelector(element, 5, 5))
            {
                MsgOutput(string.Format("Global Navigation Module: Found {0} element correctly", element));
                return driver.FindElement(By.CssSelector(element));
            }
            TestCheck.AssertFailTest(string.Format("Unable to locate Global Menu Navigation Item {0}", element));
            return null;
        }

        private static IWebElement GetSignOutLink(ISearchContext driver)
        {
            return FindElement(driver, SignOutLink);
        }

        private static IWebElement GetBackToBrotherOnlineButton(ISearchContext driver)
        {
            return FindElement(driver, BackToBrotherOnlineButton);
        }

        private static IWebElement MyAccountSideNavigationMenu(ISearchContext driver)
        {
            return FindElement(driver, SideNavMenu);
        }

        private static IWebElement ProductListNavigationMenu(ISearchContext driver)
        {
            return FindElement(driver, ProductList);
        }

        private static IWebElement TopNavigationMenu(ISearchContext driver)
        {
            return FindElement(driver, TopNavigationBar);
        }

        private static IWebElement MyAccountButtonSearch(ISearchContext driver, string searchString)
        {
            var button = MyAccountButtons.Replace("href*=''", string.Format("href*='{0}'", searchString.ToLower()));
            return FindElement(driver, button);
        }

        private static IWebElement PartnerPortalButtonSearch(ISearchContext driver, string searchString)
        {
            var button = PartnerPortalButtons.Replace("href*=''", string.Format("href*='{0}'", searchString.ToLower()));
            return FindElement(driver, button);
        }

        private static IWebElement InstantInkButtonSearch(ISearchContext driver, string searchString)
        {
            var button = InstankInkButtons.Replace("href*=''", string.Format("href*='{0}'", searchString.ToLower()));
            return FindElement(driver, button);
        }

        private static IWebElement FindLink(IEnumerable<IWebElement> links, string searchString)
        {
            if (links == null)
            {
                TestCheck.AssertFailTest("Unable to locate Navigation links");
            }

            foreach (var link in links)
            {
                if (link.TagName.Contains("a"))
                {
                    if (link.Text.ToLower().Contains(searchString.ToLower()))
                    {
                        
                        AssertElementPresent(link, "Navigation Link");
                        return link;
                    }
                }
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
                //MyAccountSideNavigationMenu(driver).FindElements(By.XPath(@"//*[contains(@id,'navigationcontainer_0_MenuItemsRepeater_listItem_')]"));
                MyAccountSideNavigationMenu(driver).FindElements(By.XPath(@"//*[contains(@id,'navigationcontainer_0_MenuItemsRepeater_LeftMenuLink')]"));
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
                TestController.CurrentDriver.Navigate().GoToUrl(string.Format("{0}?sc_lang={1}", currentUrl, language[1]));
            }
            else
            {
                var newUrl = string.Format("{0}{1}", currentUrl, url);
                TestController.CurrentDriver.Navigate().GoToUrl(newUrl);
            }
            //var newUrl = string.Format("{0}{1}", currentUrl, url);
            //TestController.CurrentDriver.Navigate().GoToUrl(newUrl);

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
            //var accountMenuItem = GetAccountMenuItem(driver, "BrotherOnlineHome");
            var brotherOnlineGoHomeMenuItem = driver.FindElement(By.Id(BrotherOnlineGoHomeMenuItem));
            if (brotherOnlineGoHomeMenuItem != null)
            {
                brotherOnlineGoHomeMenuItem.Click();
            }
            else
            {
                MsgOutput("Unable to obtain the account menu item for Brother Online Go Home");
            }
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
        public static MyPersonalDetailsPage MyPersonalDetailsMenuOptionClick(IWebDriver driver, IWebElement personalDetailsMenuItem)
        {
            personalDetailsMenuItem.Click();
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
        public static MyAddressDetailsPage MyAdressDetailsMenuOptionClick(IWebDriver driver, IWebElement addressdetalsmenuitem)
        {
            addressdetalsmenuitem.Click();
            return GetInstance<MyAddressDetailsPage>(driver, "", "");
        }

        public static MyAddressDetailsPage AddressBookButtonClick(IWebDriver driver, IWebElement button)
        {
            TestCheck.AssertIsNotNull(button, "Address Book");
            button.Click();
            return GetInstance<MyAddressDetailsPage>(driver, "", "");
        }
        
        // New method for retrieving the Menu Items for the My Account side nav 
        public static MyPaymentMethodsPage PaymentMethodsMenuClick(IWebDriver driver)
        {
            var button = driver.FindElement(By.Id(PaymentMethodsMenuItem));
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

        // NEW - override now that we have static ID's for menu items
        public static BusinessDetailsPage BusinessDetailsMenuClick(IWebDriver driver)
        {
            var menuItem = driver.FindElement(By.Id(MyBusinessDetailsMenuItem));
            TestCheck.AssertIsNotNull(menuItem, "Business Details Menu Item");
            menuItem.Click();
            return GetInstance<BusinessDetailsPage>(driver, "", "");
        }

        // NEW - override now that we have static ID's for menu items
        public static WelcomeBackPage MyAccountMenuItemClick(IWebDriver driver)
        {
            var menuItem = driver.FindElement(By.Id(MyAccountMenuItem));
            TestCheck.AssertIsNotNull(menuItem, "My Account Menu Item");
            menuItem.Click();
            return GetInstance<WelcomeBackPage>(driver, "", "");
        }

        public static IWebElement GetInstantInkMenuItem(IWebDriver driver)
        {
            var menuItem = driver.FindElement(By.Id(InstantInkMenuItem));
            return menuItem;
        }

#endregion MyAccount menu items
    }
}
