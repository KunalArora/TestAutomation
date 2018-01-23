using Brother.WebSites.Core.Pages.Base;
using Brother.Tests.Selenium.Lib.Helpers;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsConvertProductsPage : DealerProposalsCreateProductsPage, IPageObject
    {
        private const string _url = "/mps/dealer/proposals/convert/products";
        private const string _validationElementSelector = ".mps-product-configuration";

        public new string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public new string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

    }
}
