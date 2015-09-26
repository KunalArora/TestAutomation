using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerContractsApprovedPage : BasePage
    {
        public static string URL = "/mps/dealer/contracts";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-manage-devices")]
        public IWebElement ManageDevicesElement;





        public DealerManageDevicesPage NavigateToManageDevicesPage()
        {
            if (ManageDevicesElement == null)
                throw new Exception("Manage Device Element is not displayed");

            WebDriver.Wait(DurationType.Second, 30);
            
            ScrollTo(ActionsModule.SpecificActionsDropdownElement());
            ActionsModule.ClickOnSpecificActionsElement();
            
            ScrollTo(ManageDevicesElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ManageDevicesElement);
            WebDriver.Wait(DurationType.Second, 30);
            return GetInstance<DealerManageDevicesPage>(Driver);
        }
    
    }
}
