using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace Brother.WebSites.Core.Pages
{
    public static class PageObjectExtensions
    {
        public static void ClickSafely(this IPageObject pageObject)
        {
            //pageObject.SeleniumHelper.ClickSafely()
        }
    }
}
