using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CustomerRootPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "div.logged-in";
        private const string _url = "/";

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        


    }
}
