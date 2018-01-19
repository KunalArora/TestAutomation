using Brother.Tests.Common.Logging;
using Brother.Tests.Selenium.Lib.Helpers;

namespace Brother.WebSites.Core.Pages
{
    /// <summary>
    /// TODO: if possible migrate all BasePage properties to PageObjectBase
    /// </summary>
    public class PageObjectBase : IPageObject
    {
        protected string _validationElementSelector = string.Empty;
        protected string _url = string.Empty;

        public virtual string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public virtual string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        public ILoggingService LoggingService { get; set; }
    }
}
