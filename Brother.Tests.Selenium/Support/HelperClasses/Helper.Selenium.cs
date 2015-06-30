﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Brother.Tests.Selenium.Lib.Support.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public abstract class SeleniumHelper : Helper
    {
        public IWebDriver Driver { get; set; }
        private const string ResultLoader = "results-loading";

        private const int ElementSearchTimeout = 60;

        public static void AcceptCookieLaw(IWebDriver driver)
        {
            try
            {
                WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0,0,10));
                if (!WaitForElementToExistByCssSelector("#AcceptCookieLawHyperLink", 5, 3))
                {
                    MsgOutput(
                        "Accept Cookie Button was not found and may have already been dismissed during this test session");
                }
                else
                {
                    var acceptCookieLawButton = driver.FindElement(By.CssSelector("#AcceptCookieLawHyperLink"));
                    acceptCookieLawButton.Click();
                }
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                MsgOutput(string.Format("AcceptCookieLaw : {0} [This error can be ignored]", elementNotVisible));
            }
            catch (WebDriverException timeOutDriverException)
            {
                MsgOutput(string.Format("Driver timed out whilst looking for Accept Cookie Law request button"));
            }
            WebDriver.SetWebDriverImplicitTimeout(WebDriver.ImplicitWaitDefaultTimeout);
        }
        
        /// <summary>
        /// Removes all browser cookies
        /// </summary>
        public void DeleteAllCookies()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
        }

        
        public string GetUrl()
        {
            return Driver.Url;
        }


        /// <summary>
        /// Clears the field and types in new data
        /// </summary>
        /// <param name="element">Element to clear</param>
        /// <param name="value">Value to enter</param>
        /// <returns>Void</returns>
        public void ClearAndType(IWebElement element, string value)
        {
            element.Clear(); 
            element.SendKeys(value);
        }

        public bool WaitForElementToExistById(string element)
        {
            var elementStatus = false;
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(ElementSearchTimeout));
                elementStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(element))).Displayed;
            }
            catch (WebDriverException elementSearchTimeout)
            {
                MsgOutput(elementSearchTimeout.Message);
                throw new WebDriverTimeoutException(string.Format("Timeout searching for Element [{0}]. Timeout after [{1}]", element, ElementSearchTimeout));
            }
            return elementStatus;
        }

        public bool WaitForElementToExistByClassName(string element)
        {
            var elementStatus = false;
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(ElementSearchTimeout));
                elementStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(element))).Displayed;
            }
            catch (WebDriverException elementSearchTimeout)
            {
                MsgOutput(elementSearchTimeout.Message);
                throw new WebDriverTimeoutException(string.Format("Timeout searching for Element [{0}]. Timeout after [{1}]", element, ElementSearchTimeout));
            }
            return elementStatus;
        }

        public bool WaitForElementToExistByName(string element)
        {
            var elementStatus = false;
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(ElementSearchTimeout));
                elementStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.Name(element))).Displayed;
            }
            catch (WebDriverException elementSearchTimeout)
            {
                throw new WebDriverTimeoutException(string.Format("Timeout searching for Element [{0}]. Timeout after [{1}]", element, ElementSearchTimeout));
            }
            return elementStatus;
        }

        public bool WaitForElementToExistByTagName(string element)
        {
            var elementStatus = false;
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(ElementSearchTimeout));
                elementStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(element))).Displayed;
            }
            catch (WebDriverException elementSearchTimeout)
            {
                throw new WebDriverTimeoutException(string.Format("Timeout searching for Element [{0}]. Timeout after [{1}]", element, ElementSearchTimeout));
            }
            return elementStatus;
        }

        public static bool WaitForElementToExistByCssSelector(string element)
        {
            return WaitForElementToExistByCssSelector(element, 5, 10);
        }

        public static bool WaitForElementToExistByCssSelector(string element, int retryCount, int timeOut)
        {
            WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0, 0, 0, timeOut));
            var wait = new DefaultWait<IWebDriver>(TestController.CurrentDriver);
            wait.Timeout = new TimeSpan(0, 0, 0, timeOut);
            var methodName = System.Reflection.MethodBase.GetCurrentMethod();
            wait.Message = string.Format("{0}:: Timeout of [{1}] seconds trying to locate element {2}", methodName, wait.Timeout, element);
            var retries = 0;
            var elementStatus = false;

            while ((!elementStatus) && (retries != retryCount))
            {
                try
                {
                    var searchElement = wait.Until(dr => dr.FindElement(By.CssSelector(element)));
                    elementStatus = searchElement.Displayed;
                    MsgOutput(string.Format("Element Status = [{0}]", elementStatus));
                    MsgOutput(string.Format("Retry count = [{0}]", retries));
                    retries++;
                }
                catch (StaleElementReferenceException staleElement)
                {
                    MsgOutput(string.Format("Element [{0}] Not Found. Retrying [{1}] times", element, staleElement));
                    retries++;
                }
                catch (WebDriverException timeOutException)
                {
                    MsgOutput(string.Format("Element [{0}] Not Found after [{1}] seconds", element, wait.Timeout.Seconds));
                    retries++;
                }
            }
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);
            return elementStatus;
        }

        public static bool WaitForElementToExistByXPath(string element, int retryCount, int timeOut)
        {
            var timeOutSeconds = timeOut;
            WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0, 0, 0, timeOut));
            var wait = new DefaultWait<IWebDriver>(TestController.CurrentDriver);
            wait.Timeout = new TimeSpan(0, 0, 0, timeOut);
            var methodName = System.Reflection.MethodBase.GetCurrentMethod();
            wait.Message = string.Format("{0}:: Timeout of [{1}] seconds trying to locate element {2}", methodName, wait.Timeout, element);
            var retries = 0;
            var elementStatus = false;

            while ((!elementStatus) && (retries != retryCount))
            {
                try
                {
                    var searchElement = wait.Until(dr => dr.FindElement(By.XPath(element)));
                    elementStatus = searchElement.Displayed;
                    retries++;
                }
                catch (StaleElementReferenceException staleElement)
                {
                    MsgOutput(string.Format("Element Not Found. Retrying [{0}] times", staleElement.Message));
                    retries++;
                }
                catch (WebDriverException timeOutException)
                {
                    MsgOutput(string.Format("Element Not Found after [{0}] seconds", wait.Timeout.Seconds));
                    retries++;
                }
            }
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);
            return elementStatus;
        }

        public bool WaitForElementTextToExist(string elementSearch, string textToExist, int timeOut)
        {
            WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0, 0, 0, timeOut));
            var wait = new DefaultWait<IWebDriver>(Driver);
            wait.Timeout = new TimeSpan(0, 0, 0, timeOut);
            var methodName = System.Reflection.MethodBase.GetCurrentMethod();
            wait.Message = string.Format("{0}:: Timeout of [{1}] seconds trying to locate element {2}", methodName, wait.Timeout, elementSearch);

            MsgOutput(string.Format("Waiting for text [{0}] to exist on control [{1}]", textToExist, elementSearch));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

            // we need to reset the Default global timeouts after override
            if (wait.Until(d => d.FindElement(By.CssSelector(elementSearch)).Text.Contains(textToExist)))
            {
                WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);
                MsgOutput(string.Format("Text [{0}] exists on control [{1}]", textToExist, elementSearch));
                return true;
            }
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);
            MsgOutput(string.Format("Text [{0}] DOES NOT exist on control [{1}]", textToExist, elementSearch));
            return false;
        }

        public void WaitForLoaderToDisappear()
        {
            try
            {
                while (!WaitForElementToExistByClassName(ResultLoader))
                {
                    return;
                }
            }
            catch (NullReferenceException nullReference)
            {
                throw new Exception(string.Format("The element being referenced is null. Exception was [{0}]", nullReference.Message));
            }
            catch (NoSuchElementException noSuchElementException)
            {
                throw new Exception(string.Format("The element being referenced does not exist. Exception was [{0}]", noSuchElementException.Message));
            }
            catch (WebDriverTimeoutException webDriverTimeoutException)
            {
                throw new Exception(string.Format("The element being referenced is still displayed [{0}]", webDriverTimeoutException.Message));
            }
        }

        private IList<IWebElement> FindElementsByCssSelector(string elementName)
        {
            return Driver.FindElements(By.CssSelector(elementName));
        }

        private IWebElement FindElementByCssSelector(string elementName)
        {
            return Driver.FindElement(By.CssSelector(elementName));
        }

        /// <summary>
        /// Finds the element.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <returns>IWebElement.</returns>
        /// <exception cref="System.NotImplementedException">Not Implemented</exception>
        private IWebElement FindElement(string elementName)
        {
            return Driver.FindElement(By.Name(elementName));
        }

        /// <summary>
        /// Gets the element.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <returns>IWebElement.</returns>
        public IWebElement GetElement(string elementName)
        {
            var element = FindElement(elementName);
            if (element == null)
            {
                throw new SpecFlowSeleniumException("No element named \"" + elementName + "\" have been found in html page. You should check the accessor.");
            }

            return element;
        }

        /// <summary>
        /// Hovers the specified element name.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        internal void Hover(string elementName)
        {
            var action = new Actions(Driver);
            action.MoveToElement(GetElement(elementName)).Build().Perform();
            Wait(DurationType.Second, 2);
        }

        /// <summary>
        /// Moves to a specified element on the current page
        /// </summary>
        /// <param name="element">Element to move to</param>
        /// <returns>Void</returns>
        public void MoveToElement(IWebElement element)
        {
            try
            {
                if (Driver == null)
                {
                    return;
                }
                var action = new Actions(Driver);
                Actions result = action.MoveToElement(element);
            }
            catch (ElementNotVisibleException elementNotVisibleException)
            {
                TestCheck.AssertFailTest(string.Format("Element is not visible [{0}]", elementNotVisibleException.Message));
            }
        }


        /// <summary>
        /// Moves to a specified element on the current page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element">Element to move to</param>
        /// <returns>Void</returns>
        public static void MoveToElement(IWebDriver driver, IWebElement element)
        {
            try
            {
                if (driver == null)
                {
                    return;
                }
                var action = new Actions(driver);
                action.MoveToElement(element).Build().Perform();
            }
            catch (ElementNotVisibleException elementNotVisibleException)
            {
                TestCheck.AssertFailTest(string.Format("Element is not visible [{0}] ", elementNotVisibleException.Message));
            }
        }

        /// <summary>
        /// Select a value from a dropdown by visible text
        /// </summary>
        /// <param name="element">Select from a selector</param>
        /// <param name="text"></param>
        /// <returns>Void</returns>
        public static void SelectFromDropdown(IWebElement element, string text)
        {
            new SelectElement(element).SelectByText(text);
        }


        /// <summary>
        /// Get the number of items in a Drop Down List
        /// </summary>
        /// <param name="element">Select from a selector</param>
        /// <param name="text"></param>
        /// <returns>int - number of list items</returns>
        public static int GetDropdownListItemCount(IWebElement element, string text)
        {
            var itemsInList = new SelectElement(element);
            var list = itemsInList.Options;
            return list.Count;
        }

        /// <summary>
        /// Select a value from a dropdown by value
        /// </summary>
        /// <param name="element">Select from a selector</param>
        /// <param name="text"></param>
        /// <returns>Void</returns>
        public static void SelectFromDropdownByValue(IWebElement element, string text)
        {
            new SelectElement(element).SelectByValue(text);
            
        }

        /// <summary>
        /// Select a value from a dropdown by index
        /// </summary>
        /// <param name="element">Select from a selector</param>
        /// <param name="value"></param>
        /// <returns>Void</returns>
        public static void SelectFromDropDownByIndex(IWebElement element, int value)
        {
            new SelectElement(element).SelectByIndex(value);
        }

        /// <summary>
        /// Scrolls to a specified element on the current page
        /// </summary>
        /// <param name="element">Element to move to</param>
        /// <returns>Void</returns>
        public void ScrollTo(IWebElement element)
        {
            try
            {
                ((IJavaScriptExecutor) Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
            catch (ElementNotVisibleException elementNotVisibleException)
            {
               TestCheck.AssertFailTest(string.Format("Element is not accessible [{0}]", elementNotVisibleException.Message));
            }
            catch (StaleElementReferenceException ex)
            {
                TestCheck.AssertFailTest(string.Format("Element is not accessible [{0}]", ex.Message));
            }
            catch (WebDriverException ex)
            {
                TestCheck.AssertFailTest(string.Format("Timeout scrolling to element [{0}]", ex.Message));
            }
        }

        /// <summary>
        /// Scrolls to a specified element on the current page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element">Element to move to</param>
        /// <returns>Void</returns>
        public static void ScrollTo(IWebDriver driver, IWebElement element)
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
            catch (ElementNotVisibleException elementNotVisibleException)
            {
                TestCheck.AssertFailTest(string.Format("Element is not visible [{0}]", elementNotVisibleException.Message));
            }
            catch (Exception ex)
            {
                TestCheck.AssertFailTest(string.Format("Element is not accessible [{0}]", ex.Message));
            }
        }

        /// <summary>
        /// Scrolls to a specified location on the current page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="xCoord"></param>
        /// <param name="yCoord"></param>
        /// <returns>Void</returns>
        public static void ScrollToLocation(IWebDriver driver, int xCoord, int yCoord)
        {
            try
            {
                var script = string.Format("window.scrollBy({0}, {1})", xCoord, yCoord);
                ((IJavaScriptExecutor)driver).ExecuteScript(script);
            }
            catch (ElementNotVisibleException elementNotVisibleException)
            {
                TestCheck.AssertFailTest(string.Format("Element is not visible [{0}]", elementNotVisibleException.Message));
            }
        }

        /// <summary>
        /// Evals the script.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="script">The script.</param>
        /// <returns>``0.</returns>
        public static T EvalScript<T>(string script)
        {
            var js = (IJavaScriptExecutor)TestController.CurrentDriver;
            return (T)js.ExecuteScript(script);
        }

        /// <summary>
        /// Runs the script.
        /// </summary>
        /// <param name="script">The script.</param>
        public static object RunScript(string script)
        {
            var js = (IJavaScriptExecutor)TestController.CurrentDriver;
            return js.ExecuteScript(script);
        }

        public IWebElement GetElementByCssSelector(string elementName)
        {
            IWebElement element = null;
            try
            {
                MsgOutput(string.Format("Looking for Element {0} by Css Selector", elementName));
                element = FindElementByCssSelector(elementName);
                if (element == null)
                {
                    throw new SpecFlowSeleniumException("No element named \"" + elementName +
                                                        "\" have been found in html page. You should check the accessor.");
                }
            }
            catch (NoSuchElementException elementNotFound)
            {
                MsgOutput(string.Format("Element not found", elementNotFound.Message));
            }
            catch (WebDriverTimeoutException timeoutException)
            {
                MsgOutput(string.Format("Element not found", timeoutException.Message));
            }
            return element;
        }

        public IList<IWebElement> GetElementsByCssSelector(string elementName)
        {
            IList<IWebElement> element = null;
            try
            {
                MsgOutput(string.Format("Looking for Elements {0} by Css Selector", elementName));
                element = FindElementsByCssSelector(elementName);
                if (element == null)
                {
                    throw new SpecFlowSeleniumException("No element named \"" + elementName +
                                                        "\" have been found in html page. You should check the accessor.");
                }
            }
            catch (NoSuchElementException elementNotFound)
            {
                MsgOutput(string.Format("Element not found", elementNotFound.Message));
            }
            catch (WebDriverTimeoutException timeoutException)
            {
                MsgOutput(string.Format("Element not found", timeoutException.Message));
            }
            return element;
        }

        public IWebElement GetElementByCssSelector(string elementName, int timeOut)
        {
            IWebElement element = null;
            var implicitTimeout = WebDriver.ImplicitWaitDefaultTimeout;
            var defaultTimeout = WebDriver.DefaultTimeout;
            WebDriver.SetPageLoadTimeout(new TimeSpan(0, 0, 0, timeOut));
            WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0, 0, 0, timeOut));
            try
            {
                MsgOutput(string.Format("Looking for Element {0} by Css Selector. Waiting for {1} seconds", elementName, timeOut));
                element = FindElementByCssSelector(elementName);
            }
            catch (NoSuchElementException elementNotFound)
            {
                MsgOutput(string.Format("Element not found", elementNotFound.Message));
            }
            catch (WebDriverTimeoutException timeoutException)
            {
                MsgOutput(string.Format("Element not found", timeoutException.Message));
            }
            WebDriver.SetPageLoadTimeout(defaultTimeout);
            WebDriver.SetWebDriverImplicitTimeout(implicitTimeout);

            return element;
        }

        public IList<IWebElement> GetElementsByCssSelector(string elementName, int timeOut)
        {
            IList<IWebElement> element = null;
            var implicitTimeout = WebDriver.ImplicitWaitDefaultTimeout;
            var defaultTimeout = WebDriver.DefaultTimeout;
            WebDriver.SetPageLoadTimeout(new TimeSpan(0, 0, 0, timeOut));
            WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0, 0, 0, timeOut));
            try
            {
                MsgOutput(string.Format("Looking for Elements {0} by Css Selector. Waiting for {1} seconds", elementName, timeOut));
                element = FindElementsByCssSelector(elementName);
            }
            catch (NoSuchElementException elementNotFound)
            {
                MsgOutput(string.Format("Element not found", elementNotFound.Message));
            }
            catch (WebDriverTimeoutException timeoutException)
            {
                MsgOutput(string.Format("Element not found", timeoutException.Message));
            }
            WebDriver.SetPageLoadTimeout(defaultTimeout);
            WebDriver.SetWebDriverImplicitTimeout(implicitTimeout);

            return element;
        }

        /// <summary>
        /// Scrolls to a specified element on the current page, given its name
        /// </summary>
        /// <param name="elementName">Element to move to</param>
        /// <returns>Void</returns>
        public void ScrollTo(string elementName)
        {
            var capabilities = ((RemoteWebDriver)Driver).Capabilities;

            if (!capabilities.BrowserName.Equals("chrome")) return;

            var element = GetElement(elementName);

            try
            {
                var javaScriptExecutor = Driver as IJavaScriptExecutor;
                if (javaScriptExecutor != null)
                {
                    javaScriptExecutor.ExecuteScript(String.Format("window.scrollTo(0, {0});", element.Location.Y));
                }
            }
            catch (ElementNotVisibleException elementNotVisibleException)
            {
                TestCheck.AssertFailTest(string.Format("Element is not visible [{0}]", elementNotVisibleException.Message));
            }
        }

        /// <summary>
        /// Fills the form.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="valueName">Name of the value.</param>
        internal void FillForm(Table table, string fieldName, string valueName)
        {
            if (table.Rows == null || (table.Rows != null && table.Rows.Count == 0))
                throw new SpecFlowSeleniumException("Table row shouldn't be null or empty");
            foreach (var row in table.Rows)
            {
                GetElement(row[fieldName]).SendKeys(row[valueName]);
            }
        }

        /// <summary>
        /// Selects all (Ctrl+a).
        /// </summary>
        internal void SelectAll()
        {
            var copy = new Actions(Driver);
            copy.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control);
            copy.Build().Perform();
        }

        /// <summary>
        /// Copies selected value (Ctrl+c)
        /// </summary>
        internal void Copy()
        {
            var copy = new Actions(Driver);
            copy.KeyDown(Keys.Control).SendKeys("c").KeyUp(Keys.Control);
            copy.Build().Perform();
        }
        
        /// <summary>
        /// Pastes clipboard (Ctrl+v)
        /// </summary>
        internal void Paste()
        {
            var copy = new Actions(Driver);
            copy.KeyDown(Keys.Control).SendKeys("v").KeyUp(Keys.Control);
            copy.Build().Perform();
        }


        public static void WaitUpTo(int milliseconds, Func<bool> condition, string description)
        {
            var timeElapsed = 0;
            try
            {
                while (!condition() && timeElapsed < milliseconds)
                {
                    Thread.Sleep(100); timeElapsed += 100;
                }
            }
            catch (StaleElementReferenceException staleElement)
            {
                MsgOutput("ERROR: Locating element", staleElement.Message);
                if (staleElement.InnerException != null)
                {
                    MsgOutput("Inner exception was ", staleElement.InnerException.Message);
                }
                TestCheck.AssertFailTest(string.Format("Stale element detected [{0}]",staleElement.Message));
            }

            if (timeElapsed >= milliseconds || !condition())
            {
                throw new AssertionException("Timed out while waiting for: " + description);
            }
        }


        /// <summary>
        /// Returns True if current driver is Firefox
        /// </summary>
        public bool IsFireFoxBrowser()
        {
             var capabilities = ((RemoteWebDriver)Driver).Capabilities;

            return capabilities.BrowserName.Equals("firefox");
        }

        /// <summary>
        /// Returns True if current driver is Headless (PhantomJS)
        /// </summary>
        public bool IsPhantomJsBrowser()
        {
            var capabilities = ((RemoteWebDriver)Driver).Capabilities;

            return capabilities.BrowserName.Equals("phantomjs");
        }

        /// <summary>
        /// Dismisses the HTTPS warning dialog
        /// </summary>
        public void DismissAlert()
        {
            try
            {
                Driver.SwitchTo().Alert().Accept();
            }
            catch (NoAlertPresentException noAlertPresent)
            {
                MsgOutput("This page does not have any alerts present", noAlertPresent.Message);
            }
        }

        private IWebElement GetFieldControl(string field)
        {
            var form = GetForm(Driver);
            return form.FindElement(By.Id(field));
        }

        private IWebElement GetForm(IWebDriver browser)
        {
            try
            {
                return browser.FindElements(By.TagName("form")).First();
            }
            catch (NotFoundException notFoundException)
            {
                MsgOutput(notFoundException.Message);
            }
            return null;
        }

        public string GetTextBoxValue(string field)
        {
            var control = GetFieldControl(field);

            return control.GetAttribute("value");
        }

        public static bool IsElementClickable(IWebElement element)
        {
            try
            {
                MoveToElement(TestController.CurrentDriver, element);
                element.Click();
            }
            catch (InvalidOperationException elementNotClickable)
            {
                MsgOutput(elementNotClickable.Message);
                MsgOutput(string.Format("Element was not clickable on screen at location {0} {1}", element.Location.X, element.Location.Y));
                return false;
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                MsgOutput(elementNotVisible.Message);
                MsgOutput(string.Format("Element was not clickable on screen at location {0} {1}", element.Location.X, element.Location.Y));
                return false;
            }
            return true;
        }

        public static bool IsElementPresent(IWebElement element)
        {
            try
            {
                var b = element.Displayed;
                return true;
            }
            catch (NullReferenceException nullReferenceException)
            {
                MsgOutput(string.Format("Element was NULL [{0}]", nullReferenceException.Message));
                return false;
            }
            catch (NoSuchElementException noSuchElement)
            {
                MsgOutput(string.Format("Element was not present [{0}]", noSuchElement.Message));
                return false;
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                MsgOutput(string.Format("Element was not present [{0}]", elementNotVisible.Message));
                return false;
            }
            catch (InvalidElementStateException invalidElement)
            {
                MsgOutput(string.Format("Element : [{0}] was a invalid Eeement [{1}]", element.TagName, invalidElement));
                return false;
            }
        }

        public static void AssertElementPresent(IWebElement element, string elementDescription)
        {
            try
            {
                WaitUpTo(120, () => IsElementPresent(element), elementDescription); 
                if (!IsElementPresent(element))
                {
                    throw new AssertionException(String.Format("AssertElementPresent Failed: Could not find '{0}'",
                        elementDescription));
                }
            }
            catch (WebDriverException timeOutDriverException)
            {
                MsgOutput(string.Format("AssertElementPresent timeout searching for element [{0}]. Timeout period was [{1}]", elementDescription, 120));
                MsgOutput("Exception was ", timeOutDriverException.Message);
                TestCheck.AssertFailTest(string.Format("Element [{0}] not found", elementDescription));
            }
        }

        public static void AssertElementPresent(IWebElement element, string elementDescription, int timeOut)
        {
            try
            {
                WaitUpTo(timeOut, () => IsElementPresent(element), elementDescription);
                if (!IsElementPresent(element))
                {
                    throw new AssertionException(string.Format("AssertElementPresent Failed: Could not find '{0}'",
                        elementDescription));
                }
            }
            catch (WebDriverException timeOutDriverException)
            {
                MsgOutput(string.Format("AssertElementPresent timeout searching for element [{0}]. Timeout period was [{1}]", elementDescription, timeOut));
                MsgOutput("Exception was ", timeOutDriverException.Message);
            }
        }

        public static bool IsElementPresent(ISearchContext context, By searchBy)
        {
            try
            {
                return context.FindElement(searchBy).Displayed;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Waits the specified duration.
        /// </summary>
        /// <param name="durationType">Type of the duration.</param>
        /// <param name="duration">The duration.</param>
        internal void Wait(DurationType durationType, int duration)
        {
            switch (durationType)
            {
                case DurationType.Millisecond:
                    Thread.Sleep(TimeSpan.FromMilliseconds(duration));
                    break;
                case DurationType.Second:
                    Thread.Sleep(TimeSpan.FromSeconds(duration));
                    break;
                case DurationType.Minute:
                    Thread.Sleep(TimeSpan.FromMinutes(duration));
                    break;
            }
        }

        public static void AssertElementPresent(ISearchContext context, By searchBy, string elementDescription)
        {
            if (!IsElementPresent(context, searchBy)) throw new AssertionException(String.Format("AssertElementPresent Failed: Could not find '{0}'", elementDescription));
        }

        public static void AssertElementsPresent(IWebElement[] elements, string elementDescription)
        {
            if (elements.Length == 0) throw new AssertionException(String.Format("AssertElementsPresent Failed: Could not find '{0}'", elementDescription));
        }

        public static void AssertElementText(IWebElement element, string expectedValue, string elementDescription)
        {
            AssertElementPresent(element, elementDescription);
             var actualtext = element.Text;
            if (actualtext != expectedValue)
            {
                throw new AssertionException(String.Format("AssertElementText Failed: Value for '{0}' did not match expectations. Expected: [{1}], Actual: [{2}]", elementDescription, expectedValue, actualtext));
            }
        }

        public static void AssertElementValue(IWebElement element, string expectedValue, string elementDescription)
        {
            AssertElementPresent(element, elementDescription);
            var actualValue = element.GetAttribute("value");
            if (actualValue != expectedValue)
            {
                throw new AssertionException(String.Format("AssertElementValue Failed: Value for '{0}' did not match expectations. Expected: [{1}], Actual: [{2}]", elementDescription, expectedValue, actualValue));
            }
        }

        public static void AssertElementIsChecked(IWebElement element, string expectedValue, string elementDescription)
        {
            AssertElementPresent(element, elementDescription);
            var actualValue = element.GetAttribute("checked");
            if (actualValue != expectedValue)
            {
                throw new AssertionException(String.Format("AssertElementValue Failed: Value for '{0}' did not match expectations. Expected: [{1}], Actual: [{2}]", elementDescription, expectedValue, actualValue));
            }
        }

        public static bool AssertElementContainsText(IWebElement element, string expectedValue, string elementDescription)
        {
            AssertElementPresent(element, elementDescription);
            var actualtext = element.Text;
            if (actualtext.Contains(expectedValue)) return true;
            MsgOutput(string.Format("ElementContainsText Failed: Value for '{0}' did not contain expected value. Expected: [{1}], Actual: [{2}]", elementDescription, expectedValue, actualtext));
            return false;
        }

        public static bool AssertElementNotContainsText(IWebElement element, string expectedValue, string elementDescription)
        {
            AssertElementPresent(element, elementDescription);
            var actualtext = element.Text;
            if (actualtext != null && !actualtext.Contains(expectedValue)) return true;
            MsgOutput(string.Format(
                    "ElementNotContainsText Failed: Value for '{0}' did not contain expected value. Expected: [{1}], Actual: [{2}]",
                    elementDescription, expectedValue, actualtext));
            return false;
        }

        public static void AssertItemIsSelected(IWebElement element, string expectedValue, string elementDescription)
        {
            var selectedValue = new SelectElement(element);
            var actualtext = selectedValue.SelectedOption.Text;
            CheckTextForComparison(element, actualtext, expectedValue);
        }

        private static void CheckTextForComparison(IWebElement element, string actualText, string expectedValue)
        {
            if (actualText != expectedValue)
            {
                throw new AssertionException(String.Format("CheckTextForComparison: Value for '{0}' did not match expectations. Expected: [{1}], Actual: [{2}]", element, expectedValue, actualText));
            }
        }
    }
   
}
