using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Brother.Tests.Selenium.Lib.Helpers
{
    public interface ISeleniumHelper
    {
        /// <summary>
        /// find element by css selector
        /// </summary>
        /// <param name="selector">css selector</param>
        /// <param name="timeout">in sec. -1=use default value</param>
        /// <param name="isWaitforDisplayed">T= wait for element.displayed == true</param>
        /// <param name="isWaitforEnabled">T= wait for element.enabled == true</param>
        /// <returns>element if exist (and displayed,enabled), otherwise throw exception</returns>
        IWebElement FindElementByCssSelector(string selector, int timeout = -1, bool isWaitforDisplayed = false, bool isWaitforEnabled = false);
        /// <summary>
        /// find element by css selector
        /// </summary>
        /// <param name="context">search root element</param>
        /// <param name="selector">css selector</param>
        /// <param name="timeout">in sec. -1=use default value</param>
        /// <param name="isWaitforDisplayed">T= wait for element.displayed == true</param>
        /// <param name="isWaitforEnabled">T= wait for element.enabled == true</param>
        /// <returns>element if exist (and displayed,enabled), otherwise throw exception</returns>
        IWebElement FindElementByCssSelector(ISearchContext context, string selector, int timeout = -1, bool isWaitforDisplayed = false, bool isWaitforEnabled = false);
        /// <summary>
        /// Attempts to find an element which has a data-* attribute of dataAttributeName
        /// and value dataAttributeValue
        /// </summary>
        /// <param name="dataAttributeName">The name of the data-* attribute without the prefix "data-" e.g. for data-myattribute
        /// just use "myattribute"</param>
        /// <param name="dataAttributeValue">The value to match</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        IWebElement FindElementByDataAttributeValue(string dataAttributeName, string dataAttributeValue, int timeout = -1);
        /// <summary>
        /// set check box
        /// </summary>
        /// <param name="element">target</param>
        /// <param name="select">T=check</param>
        void SetCheckBox(IWebElement element, bool select);

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
        IWebElement FindElementByDataAttributeValue(ISearchContext context, string dataAttributeName, string dataAttributeValue, int timeout = -1);
        
        /// <summary>
        /// Wait until an element appears
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="timeout"></param>
        void WaitUntilElementAppears(string selector, int timeout = -1);
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
        TResult WaitUntil<TResult>(Func<IWebDriver, TResult> conditions, int timeout = -1);
 
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
        void ClickSafety(IWebElement element, int IsWaitForAnotherPageDefaultFindElementTimeout = -1, bool IsUntilUrlChanges = false);
        
        /// <summary>
        /// Accept Javascript alert 
        /// </summary>
        /// <param name="timeout"></param>
        void AcceptJavascriptAlert(int timeout = -1);

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
        /// Clicks the radio button & ensures that it has been clicked properly
        /// </summary>
        /// <param name="radioButtonElement"></param>
        void ClickRadioButtonSafely(IWebElement radioButtonElement, int timeout = -1);

        /// <summary>
        /// filter proposal/contract helper
        /// </summary>
        /// <param name="filterElement">input field</param>
        /// <param name="filterString">id set to filter element</param>
        /// <param name="rowElementListForExistCheck">check until list count==1</param>
        /// <param name="timeout">in sec. -1 is default from RuntimeSettings.DefaultXXXTimeout</param>
        void SetListFilter(IWebElement filterElement, string filterString, IList<IWebElement> rowElementListForExistCheck, int timeout = -1, string waitSelector = null);
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterElement">The filter element where Proposal/Contract/Aggrement Id is inserted</param>
        /// <param name="filterId">Proposal/Contract/Aggrement Id</param>
        /// <param name="rowElementListForExistCheck">Row Elements of the Proposals List</param>
        /// <param name="timeout">Find Element Timeout</param>
        /// <param name="dataAttibuteName">proposal-id or contract-id. default=null </param>
        /// <param name="waitSelector">Selector to wait for before the Proposals/Contracts/Aggrements List is loaded before entering the Id in filterelement. default=null </param>
        /// <returns>target element when dataAttibuteName != null othewise N/A</returns>
        IWebElement SetListFilter(IWebElement filterElement, int filterId, IList<IWebElement> rowElementListForExistCheck, int timeout = -1, string dataAttibuteName=null, string waitSelector=null);

        /// <summary>
        /// Returns true if element with this selector is not present, returns false if its present
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        bool IsElementNotPresent(string selector, int timeout = -1);
    }
}
