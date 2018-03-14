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

        public IWebElement FindElementByCssSelector(string selector, int timeout, bool isWaitforDisplayed = false, bool isWaitforEnabled = false)
        {
            //LoggingService.WriteLogOnMethodEntry(selector, timeout);
            return FindElementByCssSelector(_webDriver, selector, timeout, isWaitforDisplayed, isWaitforEnabled);
        }

        public IWebElement FindElementByCssSelector(ISearchContext context, string selector, int timeout, bool isWaitforDisplayed = false, bool isWaitforEnabled = false)
        {
            LoggingService.WriteLogOnMethodEntry(context, selector, timeout,isWaitforDisplayed,isWaitforEnabled);
            timeout = timeout < 0 ? RuntimeSettings.DefaultFindElementTimeout : timeout;
            try
            {
                IWebElement target = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout))
                    .Until(d => { try
                        {
                            var element = context.FindElement(By.CssSelector(selector));
                            var isDisplayed = isWaitforDisplayed == false || element.Displayed;
                            var isEnabled = isWaitforEnabled == false || element.Enabled;
                            return element != null && isDisplayed && isEnabled ? element : null;
                        }
                        catch { return null; } });
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

        public void ClearAndType(IWebElement element, string value, bool IsVerify = false, int timeOut = -1)
        {
            LoggingService.WriteLogOnMethodEntry(element,value,IsVerify,timeOut);
            try
            {
                timeOut = timeOut < 0 ? value.Length : timeOut; // default T/O:  1s/charactor
                if(IsVerify)
                {
                    new WebDriverWait(_webDriver, TimeSpan.FromSeconds(RuntimeSettings.DefaultFindElementTimeout)).Until(d => element.Displayed);
                }
                element.Clear();
                element.SendKeys(value);
                if (IsVerify == false) return;
                new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeOut)).Until(d => element.GetAttribute("value").Equals(value));
            }
            catch (TimeoutException e)
            {
                throw new TimeoutException(string.Format("element.Displayed={0}, value=[{1}], GetAttribute(value)=[{2}]", element.Displayed, value, element.GetAttribute("value")), e);
            }
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

        public IWebElement SetListFilter(IWebElement filterElement, int filterId, IList<IWebElement> rowElementListForExistCheck, int timeout = -1, string dataAttributeName= "proposal-id", string waitSelector=null)
        {
            LoggingService.WriteLogOnMethodEntry(filterElement, filterId, rowElementListForExistCheck, timeout, dataAttributeName, waitSelector);
            var defaultMaxTimeout = Math.Max(RuntimeSettings.DefaultFindElementTimeout, RuntimeSettings.DefaultPageLoadTimeout);
            timeout = timeout < 0 ? defaultMaxTimeout : timeout;
            try
            {
                bool isTyped = false;
                IWebElement waitSelectorElement = null;
                var resultElement = WaitUntil(d =>
                {
                    if( isTyped == false)
                    {
                        waitSelectorElement = (waitSelector != null) ? FindElementByCssSelector(waitSelector, timeout) : null;
                        ClearAndType(filterElement, filterId.ToString(), IsVerify: true);
                        isTyped = true;
                    }
                    var count = rowElementListForExistCheck.Count;
                    switch (count)
                    {
                        case 0:
                            // nothing to reload
                            LoggingService.WriteLog(LoggingLevel.DEBUG, "SetListFilter reload id={0}, filterElement(value)={1}", filterId, filterElement.GetAttribute("value"));
                            _webDriver.Navigate().Refresh();
                            WaitUntil(d2 => IgnoreThrow(() => ((waitSelectorElement == null || waitSelectorElement.Displayed) && filterElement.Displayed), true), timeout);
                            waitSelectorElement = null;
                            isTyped = false;
                            return null;
                        case 1:
                            return dataAttributeName != null ? FindElementByDataAttributeValue(dataAttributeName, filterId.ToString(), 1) : rowElementListForExistCheck.First();
                        default:
                            // now filtering by browser...
                            return null;
                    }
                }, timeout);
                return resultElement;
            }
            catch( TimeoutException e)
            {
                throw new TimeoutException(string.Format("not found item id={0}, filterElement.Displayed={1}, rowElementListForExistCheck.Count={2} ",filterId, filterElement.Displayed, rowElementListForExistCheck.Count), e);
            }
        }

        private T IgnoreThrow<T>( Func<T> function , T valueIfThrows)
        {
            try
            {
                return function();
            }
            catch
            {
                return valueIfThrows;
            }
        }

        public void SetListFilter(IWebElement filterElement, string filterId, IList<IWebElement> rowElementListForExistCheck, int timeout = -1, string waitSelector = null)
        {
            LoggingService.WriteLogOnMethodEntry(filterElement, filterId, rowElementListForExistCheck, timeout);
            var defaultMaxTimeout = Math.Max(RuntimeSettings.DefaultWaitForItemTimeout, RuntimeSettings.DefaultPageLoadTimeout);
            timeout = timeout < 0 ? defaultMaxTimeout : timeout;
            try
            {
                var resultElement = WaitUntil(d =>
                {
                    if (waitSelector != null)
                    {
                        FindElementByCssSelector(waitSelector, timeout);
                    }
                    ClearAndType(filterElement, filterId.ToString(), IsVerify: true);
                    var count = rowElementListForExistCheck.Count;
                    switch (count)
                    {
                        case 0:
                            // nothing to reload
                            LoggingService.WriteLog(LoggingLevel.DEBUG, "SetListFilter reload id={0}, filterElement(value)={1}", filterId, filterElement.GetAttribute("value"));
                            _webDriver.Navigate().Refresh();
                            return false;
                        case 1:
                            return true;
                        default:
                            LoggingService.WriteLog(LoggingLevel.WARNING, "not unique id={0} count={1}", filterId, count);
                            return true;

                    }
                }, timeout);
                
            }
            catch (TimeoutException e)
            {
                throw new TimeoutException(string.Format("not found item id={0}, filterElement.Displayed={1}, rowElementListForExistCheck.Count={2} ", filterId, filterElement.Displayed, rowElementListForExistCheck.Count), e);
            }
        }

        public bool IsElementNotPresent(string selector, int timeout)
        {
            LoggingService.WriteLogOnMethodEntry(selector, timeout);
            bool notPresent;
            timeout = timeout < 0 ? RuntimeSettings.DefaultElementNotPresentTimeout : timeout;
            try
            {
                var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds((int)timeout)).Until(d => { try { d.FindElement(By.CssSelector(selector)); return true; } catch { return false; } });
                notPresent = false;
            }
            catch
            {
                notPresent = true;
            }

            return notPresent;
        }

        public void SetCheckBox(IWebElement element, bool selected)
        {
            LoggingService.WriteLogOnMethodEntry(element, selected);
            if (element.Selected == selected) { return; }
            WaitUntil(d => element.Displayed && element.Enabled,RuntimeSettings.DefaultFindElementTimeout);
            element.Click();
        }

    }
}