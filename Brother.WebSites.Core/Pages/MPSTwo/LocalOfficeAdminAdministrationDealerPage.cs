using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminAdministrationDealerPage : BasePage
    {

        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/admin/dealers/dealerships\"]")]
        public IWebElement LOAdminDealershipTabElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_DealershipListFilter_InputFilterBy")]
        public IWebElement LOAdminDealershipFilterElement;
        


        public void NavvigateToDealership()
        {
            if(LOAdminDealershipTabElement == null)
                throw new Exception("Dealership tab is not displayed");

            LOAdminDealershipTabElement.Click();
        }

        
        
    }
}
