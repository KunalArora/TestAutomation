using System;
using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement
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
        [FindsBy(How = How.CssSelector, Using = ".js-mps-delete")]
        public IWebElement DeleteAgreementButtonElement;

        public bool VerifyCreatedAgreement(int agreementId, string agreementName)
        {
            LoggingService.WriteLogOnMethodEntry(agreementId, agreementName);

            // Wait for footer to load & then filter out the agreement
            SeleniumHelper.FindElementByCssSelector(DataTablesFooterSelector);
            ClearAndType(AgreementFilter, agreementId.ToString());
            try
            {
                SeleniumHelper.WaitUntil(d => AgreementListNameRowElement.First(element => element.Text == agreementName));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool VerifyAgreementNotPresent(int agreementId)
        {
            LoggingService.WriteLogOnMethodEntry(agreementId);

            ClearAndType(AgreementFilter, agreementId.ToString());
            var noMatchingRecords = SeleniumHelper.FindElementByCssSelector(".dataTables_empty");
            return noMatchingRecords.Displayed;
        }

        // Click Manage devices button for first agreement showing
        // TODO: Generalize it by taking agreementId as parameter in the future
        public void ClickOnManageDevicesButton()
        {
            LoggingService.WriteLogOnMethodEntry();

            SeleniumHelper.ClickSafety(ActionsButtonElement);
            SeleniumHelper.ClickSafety(ManageDevicesButtonElement);
        }

        // Click Manage devices button for first agreement showing
        public void ClickOnDeleteAgreementButton(int agreementId)
        {
            LoggingService.WriteLogOnMethodEntry(agreementId);

            SeleniumHelper.ClickSafety(ActionsButtonElement);
            var agreementIdAttribute = DeleteAgreementButtonElement.GetAttribute("data-agreement-id");
            if (agreementId.ToString() != agreementIdAttribute)
            {
                throw new Exception(string.Format("Selected agreement in list has id {0}; expected {1}", agreementIdAttribute, agreementId.ToString()));
            }
            SeleniumHelper.ClickSafety(DeleteAgreementButtonElement);

            SeleniumHelper.AcceptJavascriptAlert();

            var deleteSuccessAlert = SeleniumHelper.FindElementByCssSelector(".alert-success");
        }
    }
}
