using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminAdministrationDealerPage : BasePage, IPageObject
    {

        private string _validationElementSelector = ".js-mps-dealership-list-container";
        private const string _url = "/mps/local-office/admin/dealers/dealerships";

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

        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/admin/dealers/dealerships\"]")]
        public IWebElement LOAdminDealershipTabElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipListFilter_InputFilterBy")]
        public IWebElement LOAdminDealershipFilterElement;
        [FindsBy(How = How.CssSelector, Using = "[class=\"js-mps-delete-remove\"] .js-mps-filter-ignore button")]
        public IWebElement ActionButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-dealership-users")]
        public IWebElement OpenDealershipUserButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipListViewActions_ActionList_Button_0")]
        public IWebElement CreateDealerButtonElement;

        [FindsBy(How = How.CssSelector, Using = ".js-mps-filter-search-field")]
        public IWebElement FilterElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=_DealershipList_List_Row_]:not(.hidden)")]
        public IList<IWebElement> List_Row;

        private const string DealerCreationSuccessAlertSelector = ".alert-success.js-mps-alert";
        private const string DealerNameSelector = "#content_1_DealershipList_List_Name_";
        private const string DealerSapIdSelector = "#content_1_DealershipList_List_SapId_";
        private const string DealerEmailSelector = "#content_1_DealershipList_List_Email_";
        private const string DealerOwnerSelector = "#content_1_DealershipList_List_Owner_";
        private const string DealerCeoSelector = "#content_1_DealershipList_List_CEO_";
        private const string ListActionsSelector = "#content_1_DealershipList_List_Actions_";
        private const string ListActionsEditSelector = ".js-mps-edit";
        private const string ListActionsDealershipUsersSelector = ".js-mps-dealership-users";

        public void NavigateToDealership()
        {
            if(LOAdminDealershipTabElement == null)
                throw new Exception("Dealership tab is not displayed");

            LOAdminDealershipTabElement.Click();
        }

        public void SearchForDealership(string dealership)
        {
            if(LOAdminDealershipFilterElement == null)
                throw new Exception("Can't see LOAdmin Dealership Filter Element");
            try
            {
                ClearAndType(LOAdminDealershipFilterElement, dealership);
            }
            catch (StaleElementReferenceException stale)
            {
                WebDriver.Wait(DurationType.Second, 5);
                ClearAndType(LOAdminDealershipFilterElement, dealership);
            }
            
        }

        public LocalOfficeAdminExistingDealershipUsersPage NavigateToDealershipUsersPage()
        {
            if(ActionButtonElement == null)
                throw new Exception("Can't find Action Button Element");
            if(OpenDealershipUserButtonElement == null)
                throw new Exception("Can't find Dealership User Button Element");

            ActionButtonElement.Click();
            OpenDealershipUserButtonElement.Click();

            return GetInstance<LocalOfficeAdminExistingDealershipUsersPage>();

        }

        public void VerifyDealerCreationSuccessfulMessage()
        {
            LoggingService.WriteLogOnMethodEntry();

            var DealerCreationSuccessAlertElement = SeleniumHelper.FindElementByCssSelector(DealerCreationSuccessAlertSelector);
            TestCheck.AssertIsEqual(SeleniumHelper.IsElementDisplayed(DealerCreationSuccessAlertElement), true, "Dealer creation is not successful");
        }

        public string VerifyDealerDetails(string dealershipName, string dealerEmail, string ownerName, string ceoName)
        {
            LoggingService.WriteLogOnMethodEntry(dealershipName, dealerEmail, ownerName, ceoName);

            var element = SeleniumHelper.SetListFilter(FilterElement, null, dealerEmail, List_Row);
            var elementRowId = element.GetAttribute("id");
            string[] splitElementRowString = elementRowId.Split('_');
            var elementRowNo = splitElementRowString.Last();

            var DealershipNameElement = SeleniumHelper.FindElementByCssSelector(element, (DealerNameSelector + elementRowNo));
            TestCheck.AssertIsEqual(dealershipName, DealershipNameElement.Text, "Dealership name does not match");

            var DealerEmailElement = SeleniumHelper.FindElementByCssSelector(element, (DealerEmailSelector + elementRowNo));
            TestCheck.AssertIsEqual(dealerEmail, DealerEmailElement.Text, "Dealer email does not match");

            var DealerOwnerElement = SeleniumHelper.FindElementByCssSelector(element, (DealerOwnerSelector + elementRowNo));
            TestCheck.AssertIsEqual(ownerName, DealerOwnerElement.Text, "Dealer owner does not match");

            var DealerCeoElement = SeleniumHelper.FindElementByCssSelector(element, (DealerCeoSelector + elementRowNo));
            TestCheck.AssertIsEqual(ceoName, DealerCeoElement.Text, "Dealer ceo does not match");

            var ActionsElement = SeleniumHelper.FindElementByCssSelector(element, (ListActionsSelector + elementRowNo));
            SeleniumHelper.ClickSafety(ActionsElement);
            var EditActionElement = SeleniumHelper.FindElementByCssSelector(ActionsElement, ListActionsEditSelector);
            var DealershipUsersActionElement = SeleniumHelper.FindElementByCssSelector(ActionsElement, ListActionsDealershipUsersSelector);

            TestCheck.AssertIsEqual(SeleniumHelper.IsElementDisplayed(EditActionElement), true, "Edit action element is not displayed");
            TestCheck.AssertIsEqual(SeleniumHelper.IsElementDisplayed(DealershipUsersActionElement), true, "Dealership users action element is not displayed");

            var DealerSapIdElement = SeleniumHelper.FindElementByCssSelector(element, (DealerSapIdSelector + elementRowNo));
            TestCheck.AssertIsNotEqual('-', DealerSapIdElement.Text, "Dealer Sap Id is null");
            return DealerSapIdElement.Text;
        }

        public void NavigateToEditDealershipPage(string dealerEmail)
        {
            LoggingService.WriteLogOnMethodEntry(dealerEmail);

            var element = SeleniumHelper.SetListFilter(FilterElement, null, dealerEmail, List_Row);
            var elementRowId = element.GetAttribute("id");
            var elementRowNo = elementRowId.Substring(elementRowId.Length - 2);

            var ActionsElement = SeleniumHelper.FindElementByCssSelector(element, (ListActionsSelector + elementRowNo));
            SeleniumHelper.ClickSafety(ActionsElement);
            var EditActionElement = SeleniumHelper.FindElementByCssSelector(ActionsElement, ListActionsEditSelector);
            SeleniumHelper.ClickSafety(EditActionElement);
        }

        public void VerifyUpdatedDealerDetails(string dealershipName, string dealerEmail, string dealerSapId, string dealerOwnerName, string dealerCeoName)
        {
            LoggingService.WriteLogOnMethodEntry(dealershipName, dealerEmail, dealerSapId, dealerOwnerName, dealerCeoName);

            var element = SeleniumHelper.SetListFilter(FilterElement, null, dealerEmail, List_Row);
            var elementRowId = element.GetAttribute("id");
            var elementRowNo = elementRowId.Substring(elementRowId.Length - 2);

            var DealershipNameElement = SeleniumHelper.FindElementByCssSelector(element, (DealerNameSelector + elementRowNo));
            TestCheck.AssertIsEqual(dealershipName, DealershipNameElement.Text, "Dealership name does not match");

            var DealerSapIdEement = SeleniumHelper.FindElementByCssSelector(element, (DealerSapIdSelector + elementRowNo));
            TestCheck.AssertIsEqual(dealerSapId, DealerSapIdEement.Text, "Dealer sap Id does not match");

            var DealerEmailElement = SeleniumHelper.FindElementByCssSelector(element, (DealerEmailSelector + elementRowNo));
            TestCheck.AssertIsEqual(dealerEmail, DealerEmailElement.Text, "Dealer email does not match");

            var DealerOwnerElement = SeleniumHelper.FindElementByCssSelector(element, (DealerOwnerSelector + elementRowNo));
            TestCheck.AssertIsEqual(dealerOwnerName, DealerOwnerElement.Text, "Dealer owner does not match");

            var DealerCeoElement = SeleniumHelper.FindElementByCssSelector(element, (DealerCeoSelector + elementRowNo));
            TestCheck.AssertIsEqual(dealerCeoName, DealerCeoElement.Text, "Dealer ceo does not match");
        }
    }
}
