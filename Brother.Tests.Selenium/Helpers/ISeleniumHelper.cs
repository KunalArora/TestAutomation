using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
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
        void WaitUntilElementAppears(string selector, int timeout);
        void SelectFromDropdownByText(IWebElement element, string text);
        TResult WaitUntil<TResult>(Func<IWebDriver, TResult> conditions, int timeout);
        List<IWebElement> FindRowElementsWithinTable(ISearchContext context);
        string SelectDropdownElementTextByIndex(IWebElement element, int index);
        void ClickSafety(IWebElement element, int defaultFindElementTimeout);
        void AcceptJavascriptAlert(int timeout);
        ReadOnlyCollection<IWebElement> ActionsDropdownElement(string actionsButton);
    }
}
