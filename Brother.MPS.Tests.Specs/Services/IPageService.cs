using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Specs.Services
{
    public interface IPageService
    {
        SignInAtYourSidePage LoadAtYourSideSignInPage(string server = null);
        TPage GetPageObject<TPage>() where TPage : BasePage, new();
    }
}