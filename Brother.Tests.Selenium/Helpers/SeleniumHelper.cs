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
        private const string DATA_ATTRIBUTE_SELECTOR_PATTERN = "[data-{0}='{1}']";
        private const string ATTRIBUTE_SELECTOR_PATTERN = "['{0}'='{1}']";

        public SeleniumHelper(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public IWebElement FindElementByCssSelector(string selector, int timeout)
        {
            IWebElement target = null;

            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(d => { try { target = d.FindElement(By.CssSelector(selector)); return true; } catch { return false; } });

            return target;
        }

        public IWebElement FindElementByCssSelector(ISearchContext context, string selector, int timeout)
        {
            IWebElement target = null;

            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(d => { try { target = context.FindElement(By.CssSelector(selector)); return true; } catch { return false; } });

            return target;
        }

        public IWebElement FindElementByDataAttributeValue(string dataAttributeName,
            string dataAttributeValue, int timeout)
        {
            IWebElement target = null;
            var selector = string.Format(DATA_ATTRIBUTE_SELECTOR_PATTERN, dataAttributeName, dataAttributeValue);

            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(d => target = d.FindElement(By.CssSelector(selector)));

            return target;
        }

        public IWebElement FindElementByDataAttributeValue(ISearchContext context, string dataAttributeName,
            string dataAttributeValue, int timeout)
        {
            IWebElement target = null;
            var selector = string.Format(DATA_ATTRIBUTE_SELECTOR_PATTERN, dataAttributeName, dataAttributeValue);

            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(d => target = context.FindElement(By.CssSelector(selector)));

            return target;            
        }
        
        public void SelectFromDropdownByText(IWebElement element, string text)
        {
            new SelectElement(element).SelectByText(text);
        }
        
        public void WaitUntilElementAppears(string selector, int timeout)
        {           
            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(selector)));
        }

        public TResult WaitUntil<TResult>(Func<IWebDriver, TResult> conditions, int timeout )
        {
            TResult res = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(conditions);
            return res;
        }


    }
}
