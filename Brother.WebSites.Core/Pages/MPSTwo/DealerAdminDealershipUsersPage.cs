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
    public class DealerAdminDealershipUsersPage : BasePage
    {

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
        
    }
}
