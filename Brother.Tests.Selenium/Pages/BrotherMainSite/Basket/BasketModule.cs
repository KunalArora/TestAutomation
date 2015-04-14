using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace Brother.Tests.Selenium.Lib.Pages.BrotherMainSite.Basket
{
    public static class BasketModule
    {
        // Static Basket class which services the popup basket module common to many pages
        private const string BasketIconId = "#primary-nav > div > ul > li.nav-basket > a";
        private const string ProductInformationListId = ".product-info";
        private const string GoToBasketButtonId = "#primary-nav > div > ul > li.nav-basket > div > div.sections.add-to-basket > a";
        private const string ItemPriceId = ".cf .price";
        private const string PriceString = @"PRICE";
        private const string RemoveFromBasketButton = ".remove-from-basket-button";
        private const string BasketNavigationIcon = "#primary-nav .cf .nav-basket";

        private static IWebElement BasketNavigation(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(BasketNavigationIcon));
        }

        private static IWebElement BasketIcon(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(BasketIconId));
        }

        private static IWebElement ProductInformationList(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(ProductInformationListId));
        }

        private static IWebElement GoToBasketButton(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(GoToBasketButtonId));
        }

        private static IWebElement RemoveFromBasket(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(RemoveFromBasketButton));
        }

        private static IWebElement ItemPrice(ISearchContext driver)
        {
            var priceElements = driver.FindElements(By.CssSelector(ItemPriceId));

            try
            {
                if (priceElements.Count <= 1) return priceElements[0];
                // we have the two price element page so we need to eliminate one of them
                foreach (var priceElement in priceElements)
                {
                    if (priceElement.Text != PriceString)
                    {
                        return priceElement;
                    }
                }
            }
            catch (NoSuchElementException noSuchElement)
            {
                Helper.MsgOutput("Unable to locate Price element on page", noSuchElement.Message);
            }
            return priceElements[0];
        }

        public static void ClearBasket(IWebDriver driver)
        {
            WebDriver.Wait(Helper.DurationType.Second, 3); // wait for basket to get updated
            SeleniumHelper.MoveToElement(driver, BasketIcon(driver));
            WebDriver.Wait(Helper.DurationType.Second, 2);
            SeleniumHelper.WaitForElementToExistByCssSelector(RemoveFromBasketButton, 3, 5);
            RemoveFromBasket(driver).Click();
            Assert.AreEqual(0, GetBasketItemsCount(driver), "Basket is not empty");
        }

        public static int GetBasketItemsCount(IWebDriver driver)
        {
            WebDriver.Wait(Helper.DurationType.Second, 3); // wait for basket to get updated
            return Convert.ToInt32(BasketIcon(driver).Text);
        }

        public static string GetBasketInformationItem(IWebDriver driver)
        {
            SeleniumHelper.MoveToElement(driver, ProductInformationList(driver));
            const string error = "Error!";
            SeleniumHelper.WaitUpTo(50, () => SeleniumHelper.IsElementPresent(ProductInformationList(driver)), "Basket");
            if (!SeleniumHelper.IsElementPresent(ProductInformationList(driver))) return error;
            return ProductInformationList(driver).Text ?? error;
        }

        public static BasketPage GoToBasketButtonClick(IWebDriver driver)
        {
            GoToBasketButton(driver).Click();
            return BasePage.GetInstance<BasketPage>(driver, "", "");
        }

        public static BasketPage BasketIconClick(IWebDriver driver)
        {
            BasketIcon(driver).Click();
            return BasePage.GetInstance<BasketPage>(driver, "", "");
        }

        public static string GetItemPrice(IWebDriver driver)
        {
            return ItemPrice(driver).Text.Contains(PriceString) ? ItemPrice(driver).Text.Remove(0, PriceString.Length) : ItemPrice(driver).Text;
        }
    }
}
