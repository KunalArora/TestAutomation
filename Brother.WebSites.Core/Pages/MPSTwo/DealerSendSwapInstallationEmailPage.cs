using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerSendSwapInstallationEmailPage: BasePage, IPageObject
    {
        public static string Url = "/mps/dealer/contracts/manage-devices/send-swap-device-installation-email";

        private const string _validationElementSelector = ".active a[href=\"/mps/dealer/contracts/manage-devices/send-swap-device-installation-email\"]";

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
                return Url;
            }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_1_InputInstallerEmailAddress_Input")]
        public IWebElement EmailFieldElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-val-btn-next")]
        public IWebElement SendEmailButton;

        public void EnterInstallerEmailAndProceed(string installerId)
        {
            LoggingService.WriteLogOnMethodEntry(installerId);
            ClearAndType(EmailFieldElement, installerId);
            SendEmailButton.Click(); // Send Email button
        }
    }
}
