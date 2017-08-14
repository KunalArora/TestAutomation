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
    public class LocalOfficeAdminAdministrationDealerPage : BasePage
    {

        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/admin/dealers/dealerships\"]")]
        public IWebElement LOAdminDealershipTabElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipListFilter_InputFilterBy")]
        public IWebElement LOAdminDealershipFilterElement;
        [FindsBy(How = How.CssSelector, Using = "[class=\"js-mps-delete-remove\"] .js-mps-filter-ignore button")]
        public IWebElement ActionButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-dealership-users")]
        public IWebElement OpenDealershipUserButtonElement;
        
        
        


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
        
    }
}
