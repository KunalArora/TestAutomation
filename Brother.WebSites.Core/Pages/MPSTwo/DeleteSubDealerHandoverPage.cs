using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DeleteSubDealerHandoverPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSave")]
        public IWebElement SubDealerDeleteButton;
        [FindsBy(How = How.CssSelector, Using = "#content_1_StaffHandoverPanel")]
        public IWebElement SubDealerHandoverElement;

        public void IsHandoverPageDisplayed()
        {
            if(SubDealerHandoverElement == null)
                throw new Exception("Sub dealer handover page is null");

            TestCheck.AssertIsEqual(true, SubDealerHandoverElement.Displayed, 
                                            "Sub dealer handover page is not displayed");
        }

        public DealerAdminDealershipUsersPage DeleteSubdealer()
        {
            if(SubDealerDeleteButton == null)
                throw new Exception("SubDealer Delete Button is null");

            SubDealerDeleteButton.Click();

            return GetInstance<DealerAdminDealershipUsersPage>();
        }
    }
}
