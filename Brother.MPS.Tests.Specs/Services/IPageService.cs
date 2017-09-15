using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Specs.Services
{
    public interface IPageService
    {
        SignInAtYourSidePage LoadAtYourSideSignInPage(string server = null);
        TPage GetPageObject<TPage>(int? timeout = null) where TPage : BasePage, IPageObject, new();
        TPage LoadUrl<TPage>(string url, int timeout, string validationElementSelector = null, bool addToContextAsCurrentPage = false) where TPage : BasePage, IPageObject, new();
    }
}