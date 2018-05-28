using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Helpers;
using System.Globalization;

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



        public ILoggingService LoggingService { get; set; }

        public ISeleniumHelper SeleniumHelper { get; set; }

        public IRuntimeSettings RuntimeSettings { get; set; }

        public ITranslationService TranslationService { get; set; }
        
        public CultureInfo CultureInfo { get; set; }
    }
}
