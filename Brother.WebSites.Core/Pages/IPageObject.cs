using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Helpers;

namespace Brother.WebSites.Core.Pages
{
    public interface IPageObject
    {
        string ValidationElementSelector { get; }
        string PageUrl { get; }

        // note: Simple common properties implement to BasePage class.
        ISeleniumHelper SeleniumHelper { get; set; }
        ILoggingService LoggingService { get; set; }
        IRuntimeSettings RuntimeSettings { get; set; }
        ITranslationService TranslationService { get; set; }
        string Culture { get; set; }
    }
}
