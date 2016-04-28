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
    public class LocalOfficeApproverDeviceManagementPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/local-office/manage-devices/contracts\"]")]
        public IWebElement LOApproverDeviceManagementContractElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-manage-devices")]
        public IWebElement ManageDevicesElement;



        public void IsLOApproverDeviceManagementPageDisplayed()
        {
            if(LOApproverDeviceManagementContractElement == null)
                throw new Exception("LO Approver Device Management screen not opened");

            AssertElementPresent(LOApproverDeviceManagementContractElement, "Lo approver device management page is not displayed");
        }

       





        public ManageDevicesPage NavigateToManageDevicesPage()
        {
            MPSJobRunnerPage.RunCompleteInstallationCommandJob();

            ActionsModule.ClickOnSpecificActionsElement(Driver);

            ScrollTo(ManageDevicesElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ManageDevicesElement);
            
            return GetInstance<ManageDevicesPage>(Driver);
        }
    }
}
