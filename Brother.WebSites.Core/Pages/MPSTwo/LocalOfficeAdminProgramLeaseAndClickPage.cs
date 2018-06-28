using Brother.Tests.Common.Logging;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminProgramLeaseAndClickPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "#content_1_ButtonSave";
        private const string _url = "/mps/local-office/programs/lease-and-click/program-settings";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }


        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSave")]
        public IWebElement SaveButton;

        private const string ProgramEnabledInputButtonSelector = "#content_1_InputProgramEnabled_Input";

        public void ClickOnProgramEnabledButton()
        {
            LoggingService.WriteLogOnMethodEntry();

            var ProgramEnabledInputButtonElement = SeleniumHelper.FindElementByCssSelector(ProgramEnabledInputButtonSelector);
            if((SeleniumHelper.IsElementSelected(ProgramEnabledInputButtonElement)))
            {
                LoggingService.WriteLog(LoggingLevel.WARNING, "Program enabled checkbox is already enabled when it should be disabled");
                return;
            }
            SeleniumHelper.ClickSafety(ProgramEnabledInputButtonElement);
        }

        public void DisableProgram()
        {
            LoggingService.WriteLogOnMethodEntry();

            var ProgramEnabledInputButtonElement = SeleniumHelper.FindElementByCssSelector(ProgramEnabledInputButtonSelector);
            if(!(SeleniumHelper.IsElementSelected(ProgramEnabledInputButtonElement)))
            {
                LoggingService.WriteLog(LoggingLevel.WARNING, "Program enabled checkbox is already disabled when it should be enabled");
                return;
            }
            SeleniumHelper.ClickSafety(ProgramEnabledInputButtonElement);
        }
    }
}
