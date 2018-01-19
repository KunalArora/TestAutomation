using Brother.Tests.Common.Logging;
using Brother.Tests.Selenium.Lib.Helpers;

namespace Brother.WebSites.Core.Pages
{
    public interface IPageObject : IILoggingService
    {
        string ValidationElementSelector { get; }
        string PageUrl { get; }
        ISeleniumHelper SeleniumHelper { get; set; }
    }
}
