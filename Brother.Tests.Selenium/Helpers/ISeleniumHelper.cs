using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Brother.Tests.Selenium.Lib.Helpers
{
    public interface ISeleniumHelper
    {
        IWebElement FindElementByCssSelector(string selector, int timeout);
        IWebElement FindElementByCssSelector(ISearchContext context, string selector, int timeout);
        void SelectFromDropdownByText(IWebElement element, string text);
    }
}
