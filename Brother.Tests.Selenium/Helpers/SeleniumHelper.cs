using Brother.Tests.Common.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace Brother.Tests.Selenium.Lib.Helpers
{
    public class SeleniumHelper : ISeleniumHelper
    {
        private IWebDriver _webDriver;
        private const string DATA_ATTRIBUTE_SELECTOR_PATTERN = "[data-{0}='{1}']";
        private const string ATTRIBUTE_SELECTOR_PATTERN = "['{0}'='{1}']";

        private ILoggingService LoggingService { get; set; }

        public SeleniumHelper(IWebDriver webDriver, ILoggingService loggingService)
        {
            _webDriver = webDriver;
            LoggingService = loggingService;
        }

        public IWebElement FindElementByCssSelector(string selector, int timeout)
        {
            LoggingService.WriteLogOnMethodEntry(selector, timeout);
            IWebElement target = null;

            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(d => { try { target = d.FindElement(By.CssSelector(selector)); return true; } catch { return false; } });

            return target;
        }

        public IWebElement FindElementByCssSelector(ISearchContext context, string selector, int timeout)
        {
            LoggingService.WriteLogOnMethodEntry(context, selector, timeout);
            IWebElement target = null;

            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(d => { try { target = context.FindElement(By.CssSelector(selector)); return true; } catch { return false; } });

            return target;
        }

        public IWebElement FindElementByDataAttributeValue(string dataAttributeName,
            string dataAttributeValue, int timeout)
        {
            LoggingService.WriteLogOnMethodEntry(dataAttributeName, dataAttributeValue, timeout);
            IWebElement target = null;
            var selector = string.Format(DATA_ATTRIBUTE_SELECTOR_PATTERN, dataAttributeName, dataAttributeValue);

            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(d => { try { target = d.FindElement(By.CssSelector(selector)); return true; } catch { return false; } });

            return target;
        }

        public IWebElement FindElementByDataAttributeValue(ISearchContext context, string dataAttributeName,
            string dataAttributeValue, int timeout)
        {
            LoggingService.WriteLogOnMethodEntry(context, dataAttributeName, dataAttributeValue, timeout);
            IWebElement target = null;
            var selector = string.Format(DATA_ATTRIBUTE_SELECTOR_PATTERN, dataAttributeName, dataAttributeValue);

            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(d => { try { target = context.FindElement(By.CssSelector(selector)); return true; } catch { return false; } } );

            return target;            
        }
        
        public void SelectFromDropdownByText(IWebElement element, string text)
        {
            LoggingService.WriteLogOnMethodEntry(element, text);
            new SelectElement(element).SelectByText(text);
        }
        
        public void WaitUntilElementAppears(string selector, int timeout)
        {
            LoggingService.WriteLogOnMethodEntry(selector, timeout);
            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(selector)));
        }

        public TResult WaitUntil<TResult>(Func<IWebDriver, TResult> conditions, int timeout )
        {
            LoggingService.WriteLogOnMethodEntry(conditions, timeout);
            TResult res = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(conditions);
            return res;
        }

        public List<IWebElement> FindRowElementsWithinTable(ISearchContext context)
        {
            LoggingService.WriteLogOnMethodEntry(context);
            List<IWebElement> tableRows = context.FindElements(By.TagName("tr")).ToList();
            return tableRows;
        }

        public List<IWebElement> FindElementsByCssSelector(ISearchContext context, string selector)
        {
            LoggingService.WriteLogOnMethodEntry(context, selector);
            var elements = context.FindElements(By.CssSelector(selector)).ToList();
            return elements;
        }

        public List<IWebElement> FindElementsByCssSelector( string selector)
        {
            LoggingService.WriteLogOnMethodEntry(selector);
            var elements = _webDriver.FindElements(By.CssSelector(selector)).ToList();
            return elements;
        }

        public string SelectDropdownElementTextByIndex(IWebElement element, int index)
        {
            LoggingService.WriteLogOnMethodEntry(element, index);
            var selectElement = new SelectElement(element);
            var selectElementOption = selectElement.Options;
            string result = selectElementOption.ElementAt(index).Text;
            return result;
        }

        public void AcceptJavascriptAlert(int timeout)
        {
            LoggingService.WriteLogOnMethodEntry(timeout);
            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout));
            IAlert alert = webDriverWait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
        }

        public void ClearAndType(IWebElement element, string value)
        {
            LoggingService.WriteLogOnMethodEntry(element, value);
            element.Clear();
            element.SendKeys(value);
        }

        public ReadOnlyCollection<IWebElement> ActionsDropdownElement(string actionsButton)
        {
            LoggingService.WriteLogOnMethodEntry(actionsButton);
            var actionsElement = _webDriver.FindElements(By.CssSelector(actionsButton));
            return actionsElement;
        }

        public void ClickSafety(IWebElement element, int defaultFindElementTimeout, bool IsUntilUrlChanges)
        {
            LoggingService.WriteLogOnMethodEntry(element, defaultFindElementTimeout, IsUntilUrlChanges);
            var url= _webDriver.Url;
            WaitUntil(d => { try { element.Click(); return IsUntilUrlChanges == false || _webDriver.Url != url; } catch { return false; } }, defaultFindElementTimeout);
        }

        public void CloseBrowserTabsExceptMainWindow(string mainWindowHandle)
        {
            LoggingService.WriteLogOnMethodEntry(mainWindowHandle);
            var browserTabs = _webDriver.WindowHandles.ToList(); 

            if (browserTabs.Count <= 1) return;

            foreach(var browserTab in browserTabs)
            {
                if (!(browserTab.Equals(mainWindowHandle)))
                {
                    _webDriver.SwitchTo().Window(browserTab);
                    _webDriver.Close();

                }

            }
            _webDriver.SwitchTo().Window(mainWindowHandle);
        }

        // Check if WebElement has an attribute 'readonly'
        // If an input field is readonly
        public bool IsReadOnly(IWebElement element)
        {
            LoggingService.WriteLogOnMethodEntry(element);
            if (element.GetAttribute("readonly") == null)
            {
                return false;
            }
            return true;
        }

        // Check if all of the elements are present or not
        public bool IsExistAllElements(params IWebElement[] elements)
        {
            LoggingService.WriteLogOnMethodEntry(elements);
            foreach (var element in elements)
            {
                if (element == null)
                    return false;
            }
            return true;
        }

        public List<string> GetAllValuesOfDropdown(IWebElement dropdownElement)
        {
            LoggingService.WriteLogOnMethodEntry(dropdownElement);
            var options = new SelectElement(dropdownElement).Options;
            List<string> values = new List<string>();
            foreach (var option in options){ values.Add(option.Text); }
            return values;
        }

        public bool IsElementDisplayed(IWebElement element)
        {
            LoggingService.WriteLogOnMethodEntry(element);
            try
            {
                return element.Displayed;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementDisplayed(ISearchContext context, string selector)
        {
            LoggingService.WriteLogOnMethodEntry(context, selector);
            try
            {
                return context.FindElement(By.CssSelector(selector)).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
