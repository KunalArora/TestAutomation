using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public static class SearchContextExtenstions
    {
        public static IWebElement TryFindElement(this ISearchContext context, By by)
        {
            try
            {
                return context.FindElement(by);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static ReadOnlyCollection<IWebElement> TryFindElements(this ISearchContext driver, By by)
        {
            try
            {
                return driver.FindElements(by);
            }
            catch (Exception)
            {
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
            }
        }
    }

    
}
