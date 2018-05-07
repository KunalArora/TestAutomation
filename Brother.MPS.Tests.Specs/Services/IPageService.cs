using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using OpenQA.Selenium;

namespace Brother.Tests.Specs.Services
{
    public interface IPageService
    {
        SignInAtYourSidePage LoadAtYourSideSignInPage(IWebDriver driver = null, string server = null);
        TPage GetPageObject<TPage>(int? timeout = null, IWebDriver driver = null) where TPage : BasePage, IPageObject, new();
        TPage LoadUrl<TPage>(string url, int timeout, string validationElementSelector = null, bool addToContextAsCurrentPage = false, IWebDriver driver = null) where TPage : BasePage, IPageObject, new();
        TPage Refresh<TPage>(TPage pageObject, int timeout) where TPage : BasePage, IPageObject;
    }
}