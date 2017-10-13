﻿using Brother.Tests.Selenium.Lib.Helpers;

namespace Brother.WebSites.Core.Pages
{
    public interface IPageObject
    {
        string ValidationElementSelector { get; }
        string PageUrl { get; }
        ISeleniumHelper SeleniumHelper { get; set; }
    }
}