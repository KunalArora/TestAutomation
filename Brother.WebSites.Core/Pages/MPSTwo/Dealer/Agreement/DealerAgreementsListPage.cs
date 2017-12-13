
using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement
{
    public class DealerAgreementsListPage: BasePage, IPageObject
    {
        private const string _validationElementSelector = ".mps-dataTables-footer";
        private const string _url = "/mps/dealer/agreements/list";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        // Selectors
        private const string DataTablesFooterSelector = ".mps-dataTables-footer";

        // WebElements
        [FindsBy(How = How.CssSelector, Using = ".js-mps-filter-search-field")]
        public IWebElement AgreementFilter;
        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_List_AgreementNameRow_]")]
        public IList<IWebElement> AgreementListNameRowElement;
        [FindsBy(How = How.CssSelector, Using = "button.btn.btn-primary.btn-xs.dropdown-toggle")]
        public IWebElement ActionsButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-manage-devices")]
        public IWebElement ManageDevicesButtonElement;

        public bool VerifyCreatedAgreement(int agreementId, string agreementName, int findElementTimeout)
        {
            // Wait for footer to load & then filter out the agreement
            SeleniumHelper.FindElementByCssSelector(DataTablesFooterSelector, findElementTimeout);
            ClearAndType(AgreementFilter, agreementId.ToString());
            try
            {
                SeleniumHelper.WaitUntil(d => AgreementListNameRowElement.First(element => element.Text == agreementName), findElementTimeout);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Click Manage devices button for first device showing
        // TODO: Generalize it by taking agreementId as parameter in the future
        public void ClickOnManageDevicesButton(int findElementTimeout)
        {
            SeleniumHelper.ClickSafety(ActionsButtonElement, findElementTimeout);
            SeleniumHelper.ClickSafety(ManageDevicesButtonElement, findElementTimeout);
        }

    }
}
