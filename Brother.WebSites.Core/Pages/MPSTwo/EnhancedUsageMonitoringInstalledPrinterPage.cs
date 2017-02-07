using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class EnhancedUsageMonitoringInstalledPrinterPage : BasePage 
    {
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonLoadContract")]
        public IWebElement EnhancedUsageMonitoringLoadButton;
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/bie-admin/enhanced-usage-monitoring/installed-printer\"]")]
        public IWebElement EnhancedUsageMonitoringInstalledPrinterTab;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputContractNumber_Input")]
        public IWebElement EnhancedUsageMonitoringContractField;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/bie-admin/enhanced-usage-monitoring/printer-engine\"] span")]
        public IWebElement EnhancedUsageMonitoringPrinterEngineTab;
        [FindsBy(How = How.CssSelector, Using = "#content_1_proposalPanel")]
        public IWebElement EnhancedUsageMonitoringProposalInformation;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-searchable")]
        public IWebElement EnhancedUsageMonitoringContractPrinterInfo;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InstalledPrinterRepeater_ButtonNext")]
        public IWebElement EnhancedUsageMonitoringInstalledPrinterSaveButton;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InstalledPrinterRepeater_InputThreshold_0_Input_0")]
        public IWebElement EnhancedUsageMonitoringContractColourThreshold;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InstalledPrinterRepeater_InputThreshold_1_Input_1")]
        public IWebElement EnhancedUsageMonitoringContractMonoThreshold;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ComponentError_ErrorContainer")]
        public IWebElement EnhancedUsageMonitoringContractError;
        
        
        
        
        
        

        public void IsInstalledPrinterPageDisplayed()
        {
            if(EnhancedUsageMonitoringInstalledPrinterTab == null)
                throw new Exception("Enhanced Usage Monitoring Installed Printer Tab returned as null");
            AssertElementPresent(EnhancedUsageMonitoringInstalledPrinterTab, "Installed Printer screen is not displayed");
        }


        public void SearchForContract()
        {
            var contractRef = SpecFlow.GetContext("ProposalId");
            ClearAndType(EnhancedUsageMonitoringContractField, contractRef);
            EnhancedUsageMonitoringLoadButton.Click();
        }

        public void SearchForContract(string contractId)
        {
            ClearAndType(EnhancedUsageMonitoringContractField, contractId);
            EnhancedUsageMonitoringLoadButton.Click();
        }

        public void IsErrorMessageDisplayed()
        {
            if(EnhancedUsageMonitoringContractError == null)
                throw new Exception("Error message returned as null");

            TestCheck.AssertIsEqual(true, EnhancedUsageMonitoringContractError.Displayed, "Enhanced Usage Monitoring Contract Error is not displayed");
        }


        public EnhancedUsageMonitoringPrinterEnginePage NavigateToEnhancedUsageMonitoringPrinterEnginePage()
        {
            if(EnhancedUsageMonitoringPrinterEngineTab == null)
                throw new Exception("EnhancedUsage Monitoring Printer Engine Tab is returned as null");

            EnhancedUsageMonitoringPrinterEngineTab.Click();

            return GetInstance<EnhancedUsageMonitoringPrinterEnginePage>();
        }

        public void IsEnhancedUsageMonitoringProposalInformationDisplayed()
        {
            if(EnhancedUsageMonitoringProposalInformation==null)
                throw new Exception("Enhanced Usage Monitoring Proposal Information is returned as null");

            TestCheck.AssertIsEqual(true, EnhancedUsageMonitoringProposalInformation.Displayed, "");
        }

        public void IsEnhancedUsageMonitoringContractPrinterInfoDisplayed()
        {
            if (EnhancedUsageMonitoringContractPrinterInfo == null)
                throw new Exception("Enhanced Usage Monitoring Proposal Information is returned as null");

            TestCheck.AssertIsEqual(true, EnhancedUsageMonitoringContractPrinterInfo.Displayed, "");
        }
        
    }
}
