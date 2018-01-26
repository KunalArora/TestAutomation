using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminSystemSettingsGeneralSettingsPage: BasePage, IPageObject
    {
        private const string _validationElementSelector = "#content_1_MpsICFEmail_Input";
        private const string _url = "/mps/local-office/admin/system-settings/general-settings";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }



        private const string SaveSuccessMessageSelector = "#content_1_ComponentSuccessMessage";

        [FindsBy(How = How.CssSelector, Using = "#content_1_MpsConsumableOrderEnableManualOrdering_Input")]
        public IWebElement ConsumableOrderEnableManualOrderingCheckboxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSave")]
        public IWebElement SaveButtonElement;

        public void EnableConsumableOrderManualOrdering()
        {
            if(!ConsumableOrderEnableManualOrderingCheckboxElement.Selected)
            {
                SeleniumHelper.ClickSafety(ConsumableOrderEnableManualOrderingCheckboxElement, RuntimeSettings.DefaultFindElementTimeout);
                SeleniumHelper.ClickSafety(SaveButtonElement, RuntimeSettings.DefaultFindElementTimeout);
                SeleniumHelper.FindElementByCssSelector(SaveSuccessMessageSelector, RuntimeSettings.DefaultFindElementTimeout);
            }
        }
    }
}
