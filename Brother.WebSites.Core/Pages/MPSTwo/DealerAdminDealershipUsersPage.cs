using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerAdminDealershipUsersPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "#content_1_StaffListActions_ActionList_Button_0";
        private const string _url = "/mps/dealer/admin/dealership-users/existing-users";

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

        private const string EmailSelector = "[id*=\"content_1_StaffList_ListContainer_StaffEmail_\"]";
        private const string AccessPermissionSelector = "[id*=\"content_1_StaffList_ListContainer_StaffPermission_\"]";

        [FindsBy(How = How.CssSelector, Using = ".js-mps-searchable")]
        public IWebElement SubDealerListTable;
        [FindsBy(How = How.CssSelector, Using = "#content_1_StaffListActions_ActionList_Button_0")]
        public IWebElement SubDealerCreateButton;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"content_1_StaffList_ListContainer_StaffEmail_\"]")]
        public IList<IWebElement> SubDealerNameList;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-alert ")]
        public IWebElement SubDealerSuccessMessageElement;




        public void IsSubdealerEdited()
        {
            if (SubDealerSuccessMessageElement == null)
                throw new Exception("Subdealer cannot be edited");

            TestCheck.AssertIsEqual(true, SubDealerSuccessMessageElement.Displayed, "subdealer was not edited");
        }


        public void IsDealershipUserPageDisplayed()
        {
            if(SubDealerCreateButton == null)
                throw new Exception("Subdealer page returned as null");
            if (SubDealerListTable == null)
                throw new Exception("Subdealer list returned as null");

            AssertElementPresent(SubDealerCreateButton, "Subdealer create button is not displayed");
            AssertElementPresent(SubDealerListTable, "Subdealer list table is not displayed");

        }

        public DealerAdminDealershipUsersCreationPage StartSubDealerCreation()
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, SubDealerCreateButton);

            return GetInstance<DealerAdminDealershipUsersCreationPage>();
        }

        public void IsSubdealerCreated()
        {
            var list = new List<string>();
            var email = SpecFlow.GetContext("GeneratedSubdealerEmailAddress");

            foreach (var element in SubDealerNameList)
            {
                var elementText = element.Text;
                list.Add(elementText);
            }

            TestCheck.AssertIsEqual(true, list.Contains(email), String.Format("{0} is not on the list of created subdealers", email));
        }

        public DeleteSubDealerHandoverPage BeginDeleteSubDealerProcess()
        {
            ActionsModule.DeleteSubdealer(Driver);

            return GetInstance<DeleteSubDealerHandoverPage>();
        }

        public DealerAdminDealershipUsersCreationPage BeginEditSubDealer()
        {
            ActionsModule.EditSubdealer(Driver);

            return GetInstance<DealerAdminDealershipUsersCreationPage>();
        }

        public void IsSubdealerDeleted()
        {
            var list = new List<string>();
            var email = SpecFlow.GetContext("GeneratedSubdealerEmailAddress");

            foreach (var element in SubDealerNameList)
            {
                var elementText = element.Text;
                list.Add(elementText);
            }

            TestCheck.AssertIsEqual(false, list.Contains(email), String.Format("{0} is not deleted on the list of created subdealers", email));
        }

        public void ClickOnAddButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.ClickSafety(SubDealerCreateButton);
        }

        public void VerifySubDealer(string subDealerEmail)
        {
            LoggingService.WriteLogOnMethodEntry(subDealerEmail);

            var IsPresent = false;
            if (SeleniumHelper.IsElementDisplayed(SubDealerSuccessMessageElement) == false)
            {
                throw new Exception("Sub dealer success message is not displayed");
            }

            var SubDealerListTableRows = SeleniumHelper.FindRowElementsWithinTable(SubDealerListTable);
            foreach (var row in SubDealerListTableRows)
            {
                var emailElement = SeleniumHelper.FindElementByCssSelector(row, EmailSelector);
                var accessPermissionElement = SeleniumHelper.FindElementByCssSelector(row, AccessPermissionSelector);
                if(emailElement.Text == subDealerEmail && accessPermissionElement.Text == "Restricted")
                {
                    IsPresent = true;
                }
            }
            if(IsPresent == false)
            {
                throw new Exception("Sub dealer is not present in the staff list");
            }
        }
        
    }
}
