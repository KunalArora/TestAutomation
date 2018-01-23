using Brother.Tests.Common.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Brother.Tests.Selenium.Lib.Helpers
{
    public interface ISeleniumHelper
    {
        IWebElement FindElementByCssSelector(string selector, int timeout);
        IWebElement FindElementByCssSelector(ISearchContext context, string selector, int timeout);
        /// <summary>
        /// Attempts to find an element which has a data-* attribute of dataAttributeName
        /// and value dataAttributeValue
        /// </summary>
        /// <param name="dataAttributeName">The name of the data-* attribute without the prefix "data-" e.g. for data-myattribute
        /// just use "myattribute"</param>
        /// <param name="dataAttributeValue">The value to match</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        IWebElement FindElementByDataAttributeValue(string dataAttributeName, string dataAttributeValue, int timeout);
        /// <summary>
        /// Attempts to find an element in the given search context which has a data-* attribute of dataAttributeName
        /// and value dataAttributeValue
        /// </summary>
        /// <param name="context">Context to search (IWebElement)</param>
        /// <param name="dataAttributeName">The name of the data-* attribute without the prefix "data-" e.g. for data-myattribute
        /// just use "myattribute"</param>
        /// <param name="dataAttributeValue">The value to match</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        IWebElement FindElementByDataAttributeValue(ISearchContext context, string dataAttributeName, string dataAttributeValue, int timeout);
        
        /// <summary>
        /// Wait until an element appears
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="timeout"></param>
        void WaitUntilElementAppears(string selector, int timeout);
        List<IWebElement> FindElementsByCssSelector(ISearchContext context, string selector);
        List<IWebElement> FindElementsByCssSelector(string selector);
        
        /// <summary>
        /// Select dropdown item using text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        void SelectFromDropdownByText(IWebElement element, string text);

        /// <summary>
        /// Wait until a certain condition becomes true
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="conditions"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        TResult WaitUntil<TResult>(Func<IWebDriver, TResult> conditions, int timeout);
 
        /// <summary>
        /// Return all row elements within a table element
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        List<IWebElement> FindRowElementsWithinTable(ISearchContext context);

        /// <summary>
        /// Select dropdown element text by index
        /// </summary>
        /// <param name="element"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        string SelectDropdownElementTextByIndex(IWebElement element, int index);

        /// <summary>
        /// Click element safely
        /// </summary>
        /// <param name="element"></param>
        /// <param name="defaultFindElementTimeout"></param>
        /// <param name="IsUntilUrlChanges"></param>
        void ClickSafety(IWebElement element, int IsWaitForAnotherPageDefaultFindElementTimeout, bool IsUntilUrlChanges=false);
        
        /// <summary>
        /// Accept Javascript alert 
        /// </summary>
        /// <param name="timeout"></param>
        void AcceptJavascriptAlert(int timeout);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionsButton"></param>
        /// <returns></returns>
        ReadOnlyCollection<IWebElement> ActionsDropdownElement(string actionsButton);
        
        /// <summary>
        /// Return true if an element is ReadOnly else false
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        bool IsReadOnly(IWebElement element);
        
        /// <summary>
        /// Return true if all the elements exist else false
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        bool IsExistAllElements(params IWebElement[] elements);
        
        /// <summary>
        /// Close browser tabs except the main window
        /// </summary>
        /// <param name="mainWindowHandle"></param>
        void CloseBrowserTabsExceptMainWindow(string mainWindowHandle);

        /// <summary>
        /// Get all the values of a dropdown list
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <returns></returns>
        List<string> GetAllValuesOfDropdown(IWebElement dropdownElement);

        /// <summary>
        /// Return true if element exists & is displayed, otherwise false
        /// </summary>
        /// <param name="element"></param>
        bool IsElementDisplayed(IWebElement element);

        /// <summary>
        /// Return true if element with this selector exists within the context, otherwise false
        /// </summary>
        /// <param name="context"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        bool IsElementDisplayed(ISearchContext context, string selector);

        /// <summary>
        /// Logging Service
        /// </summary>
        ILoggingService LoggingService {get;}
    }
}
