using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Brother.Tests.Selenium.Lib.Helpers
{
    public class SeleniumHelper : ISeleniumHelper
    {
        private IWebDriver _webDriver;

        public SeleniumHelper(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public IWebElement FindElementByCssSelector(string selector, int timeout)
        {
            IWebElement target = null;

            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(d => target = d.FindElement(By.CssSelector(selector)));

            return target;
        }

        public IWebElement FindElementByCssSelector(ISearchContext context, string selector, int timeout)
        {
            IWebElement target = null;

            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(d => target = context.FindElement(By.CssSelector(selector)));

            return target;
        }

        public void SelectFromDropdownByText(IWebElement element, string text)
        {
            new SelectElement(element).SelectByText(text);
        }
    }
}
