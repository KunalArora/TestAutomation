using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerContractsAcceptedPage : BasePage
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

            ActionsModule.ClickOnSpecificActionsElement(Driver);
            
            ScrollTo(ManageDevicesElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ManageDevicesElement);
            MpsJobRunnerPage.RunCreateCustomerAndPersonCommandJob();
            return GetInstance<DealerManageDevicesPage>(Driver);
        }

        public DealerManageDevicesPage NavigateToManageDevicesPageToConfirmThatInstallationRequestAvailability()
        {
            MpsJobRunnerPage.RunCompleteInstallationCommandJob(MpsUtil.CreatedProposal());
            MpsJobRunnerPage.RunRefreshPrintCountsFromMedioCommandJob(MpsUtil.CreatedProposal(), Locale);
            MpsJobRunnerPage.RunRefreshPrintCountsFromEmailCommandJob(Locale);
            WebDriver.Wait(DurationType.Second,  10);
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ScrollTo(ManageDevicesElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ManageDevicesElement);

            return GetInstance<DealerManageDevicesPage>();
        }
    
    }
}
