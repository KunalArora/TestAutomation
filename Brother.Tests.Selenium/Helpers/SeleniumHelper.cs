using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
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
        private IRuntimeSettings RuntimeSettings { get; set; }

        public SeleniumHelper(IWebDriver webDriver, ILoggingService loggingService, IRuntimeSettings runtimeSettings)
        {
            _webDriver = webDriver;
            LoggingService = loggingService;
            RuntimeSettings = runtimeSettings;
        }

        public IWebElement FindElementByCssSelector(string selector, int timeout)
        {
            LoggingService.WriteLogOnMethodEntry(selector, timeout);
            timeout = timeout < 0 ? RuntimeSettings.DefaultFindElementTimeout : timeout;
            IWebElement target = null;
            try {
                var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(d => { try { target = d.FindElement(By.CssSelector(selector)); return true; } catch { return false; } });
                return target;
            }
            catch (TimeoutException e)
            {
                throw new TimeoutException("selector=" + selector, e);
            }
        }

        public IWebElement FindElementByCssSelector(ISearchContext context, string selector, int timeout)
        {
            LoggingService.WriteLogOnMethodEntry(context, selector, timeout);
            timeout = timeout < 0 ? RuntimeSettings.DefaultFindElementTimeout : timeout;
            IWebElement target = null;
            try
            {
                var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(d => { try { target = context.FindElement(By.CssSelector(selector)); return true; } catch { return false; } });
                return target;
            }
            catch (TimeoutException e)
            {
                throw new TimeoutException(string.Format("context={0}, selector={1}",context,selector), e);
            }
        }

        public IWebElement FindElementByDataAttributeValue(string dataAttributeName,
            string dataAttributeValue, int timeout)
        {
            LoggingService.WriteLogOnMethodEntry(dataAttributeName, dataAttributeValue, timeout);
            timeout = timeout < 0 ? RuntimeSettings.DefaultFindElementTimeout : timeout;
            IWebElement target = null;
            var selector = string.Format(DATA_ATTRIBUTE_SELECTOR_PATTERN, dataAttributeName, dataAttributeValue);

            try
            {
                var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(d => { try { target = d.FindElement(By.CssSelector(selector)); return true; } catch { return false; } });
                return target;
            }
            catch (TimeoutException e)
            {
                throw new TimeoutException(string.Format("dataAttributeName={0}, dataAttributeValue={1}", dataAttributeName, dataAttributeValue), e);
            }

        }

        public IWebElement FindElementByDataAttributeValue(ISearchContext context, string dataAttributeName,
            string dataAttributeValue, int timeout)
        {
            LoggingService.WriteLogOnMethodEntry(context, dataAttributeName, dataAttributeValue, timeout);
            timeout = timeout < 0 ? RuntimeSettings.DefaultFindElementTimeout : timeout;
            IWebElement target = null;
            var selector = string.Format(DATA_ATTRIBUTE_SELECTOR_PATTERN, dataAttributeName, dataAttributeValue);

            try
            {
                var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(d => { try { target = context.FindElement(By.CssSelector(selector)); return true; } catch { return false; } });
                return target;
            }
            catch (TimeoutException e)
            {
                throw new TimeoutException(string.Format("context={0}, dataAttributeName={1}, dataAttributeValue={2}", context, dataAttributeName, dataAttributeValue), e);
            }

        }
        
        public void SelectFromDropdownByText(IWebElement element, string text)
        {
            LoggingService.WriteLogOnMethodEntry(element, text);
            new SelectElement(element).SelectByText(text);
        }
        
        public void WaitUntilElementAppears(string selector, int timeout)
        {
            LoggingService.WriteLogOnMethodEntry(selector, timeout);
            timeout = timeout < 0 ? RuntimeSettings.DefaultFindElementTimeout : timeout;
            try
            {
                var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(selector)));
            }
            catch (TimeoutException e)
            {
                throw new TimeoutException("selector="+ selector, e);
            }

        }

        public TResult WaitUntil<TResult>(Func<IWebDriver, TResult> conditions, int timeout)
        {
            LoggingService.WriteLogOnMethodEntry(conditions, timeout);
            timeout = timeout < 0 ? RuntimeSettings.DefaultFindElementTimeout : timeout;
            try
            {
                TResult res = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(conditions);
                return res;
            }
            catch (TimeoutException e)
            {
                throw new TimeoutException("conditions="+ conditions, e);
            }
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
            timeout = timeout < 0 ? RuntimeSettings.DefaultFindElementTimeout : timeout;
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
        public void ClearAndType(IWebElement element, string value, bool IsVerify = false, int timeOut = -1)
        {
            element.Clear();
            element.SendKeys(value);
            if (IsVerify == false) return;
            timeOut = timeOut < 0 ? value.Length : timeOut; // default T/O:  1s/charactor
            new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeOut)).Until(d => element.GetAttribute("value").Equals(value));
        }


        public ReadOnlyCollection<IWebElement> ActionsDropdownElement(string actionsButton)
        {
            LoggingService.WriteLogOnMethodEntry(actionsButton);
            var actionsElement = _webDriver.FindElements(By.CssSelector(actionsButton));
            return actionsElement;
        }

        public void ClickSafety(IWebElement element, int timeout, bool IsUntilUrlChanges)
        {
            LoggingService.WriteLogOnMethodEntry(element, timeout, IsUntilUrlChanges);
            timeout = timeout < 0 ? RuntimeSettings.DefaultFindElementTimeout : timeout;
            try
            {
                var url = string.Copy(_webDriver.Url);
                WaitUntil(d =>
                {
                    try
                    {
                        if (IsUntilUrlChanges && (_webDriver.Url != url)) return true;
                        element.Click();
                        return IsUntilUrlChanges == false;
                    }
                    catch
                    {
                        return false;
                    }
                }, timeout);
            }
            catch (TimeoutException e)
            {
                throw new TimeoutException(string.Format("element={0}, IsUntilUrlChanges={1}",element,IsUntilUrlChanges), e);
            }

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

        public void ClickRadioButtonSafely(IWebElement radioButtonElement, int timeout)
        {
            LoggingService.WriteLogOnMethodEntry(radioButtonElement, timeout);
            timeout = timeout < 0 ? RuntimeSettings.DefaultFindElementTimeout : timeout;
            WaitUntil(d =>
            {
                try
                {
                    if (radioButtonElement.Selected) return true;
                    radioButtonElement.Click();
                    return false;
                }
                catch
                {
                    return false;
                }
            }, timeout);
        }

        public void SetListFilter(IWebElement filterElement, string filterId, IList<IWebElement> rowElementListForExistCheck, int timeout=-1)
        {
            LoggingService.WriteLogOnMethodEntry(filterElement, filterId, rowElementListForExistCheck, timeout);
            var defaultMaxTimeout = Math.Max(RuntimeSettings.DefaultFindElementTimeout, RuntimeSettings.DefaultPageLoadTimeout);
            timeout = timeout < 0 ? defaultMaxTimeout : timeout;
            try
            {
                WaitUntil(d =>
                {
                    ClearAndType(filterElement, filterId, IsVerify: true);
                    var count = rowElementListForExistCheck.Count;
                    switch( count)
                    {
                        case 0:
                            // nothing to reload
                            _webDriver.Navigate().Refresh();
                            WaitUntil(dd => filterElement.Displayed , timeout);
                            return false;
                        case 1:
                            return true;
                        default:
                            LoggingService.WriteLog(LoggingLevel.WARNING, "not unique id={0} count={1}", filterId, count);
                            return true;

                    }
                }, timeout);
            }
            catch( TimeoutException e)
            {
                throw new TimeoutException(string.Format("not found item id={0}, filterElement.Displayed={1}, rowElementListForExistCheck.Count={2} ",filterId, filterElement.Displayed, rowElementListForExistCheck.Count), e);
            }
        }
    }
}
