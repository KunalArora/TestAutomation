using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories
{
    public class OriginalSuppliesPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return MainSitePageTitles.Default["BrotherOriginalSuppliesPage"].ToString(); }
        }

        [FindsBy(How = How.CssSelector, Using = "#results > article:nth-child(2) > div.price-listings-info > p:nth-child(6) > a")]
        public IWebElement AddToBasketLc1100BkButton;

        [FindsBy(How = How.CssSelector, Using = "#supplies-select-category")]
        public IWebElement SuppliesCategoryList;

        [FindsBy(How = How.CssSelector, Using = ".category-results")]
        public IWebElement CategoryResultsList;

        [FindsBy(How = How.CssSelector, Using = "#results")]
        public IWebElement ResultsList;

        [FindsBy(How = How.CssSelector, Using = "#results > article")]
        public IWebElement ResultsArticleList;

        [FindsBy(How = How.CssSelector, Using = "#results > article > div.cf.feature-listings-info > h3")]
        public IWebElement HRefsOfArticleList;

        private IWebElement GetCategoryLink(string linkToSearchFor)
        {
            const string cssSelector = @"#results > article > div.cf.feature-listings-info > h3";
            
            var resultsArticleList = ResultsList.FindElements(By.CssSelector(cssSelector));

            if (resultsArticleList == null) return null;
            foreach (var articleItem in resultsArticleList)
            {
                try
                {
                    var productItemLink = articleItem.FindElement(By.PartialLinkText(linkToSearchFor));
                    return productItemLink;
                }
                catch (NoSuchElementException noSuchElement)
                {
                    TestCheck.AssertFailTest(string.Format("Unable to locate Product item link [{0}]", noSuchElement));
                }
            }
            return null;
        }

        public InkJetCartridgePage InkJetCartridgeItemClick(string itemName)
        {
            var productLink = GetCategoryLink(itemName);
            productLink.Click();
            return GetInstance<InkJetCartridgePage>(Driver);
        }

        public void IsSuppliesCategoryListAvailable()
        {
            if (SuppliesCategoryList == null)
            {
                throw new NullReferenceException("Unable to locate drop down list on page");
            }
            AssertElementPresent(SuppliesCategoryList, "Supplies Category List");
        }

        public void IsAddToBasketButtonAvailable()
        {
            if (AddToBasketLc1100BkButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(AddToBasketLc1100BkButton, "Add To Basket Button");
        }

        public void AddToBasketButtonClick()
        {
            AddToBasketLc1100BkButton.Click();
        }

        //public int GetBasketItemsCount()
        //{
        //    Wait(DurationType.Second, 3); // wait for basket to get updated
        //    var value = Basket.Text;

        //    return Convert.ToInt32(value);
        //}

        //public string GetBasketInformationItem()
        //{
        //    MoveToElement(ProductInformationList);
        //    var error = "Error!";
        //    WaitUpTo(50, () => IsElementPresent(ProductInformationList), "Basket");
        //    if (!IsElementPresent(ProductInformationList)) return error;
        //    var itemPresent = ProductInformationList.Text;
        //    return itemPresent ?? error;
        //}

        //public BasketPage GoToBasketButtonClick()
        //{
        //    GoToBasketButton.Click();
        //    return GetInstance<BasketPage>(Driver);
        //}

        //public string GetItemPrice()
        //{
        //    return ItemPrice.Text;
        //}
    }
}
