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
        [FindsBy(How = How.CssSelector, Using = "#content_1_ComponentError_ErrorContainer")]
        public IWebElement EnhancedUsageMonitoringContractError;
        [FindsBy(How = How.CssSelector, Using = "input[id*=\"content_1_InstalledPrinterRepeater_InputEnabled_\"]")]
        public IList<IWebElement> EnhancedUsageMonitoringEnableCheckBox;
        [FindsBy(How = How.CssSelector, Using = "input[id*=\"content_1_InstalledPrinterRepeater_InputThreshold_\"]")]
        public IList<IWebElement> EnhancedUsageMonitoringThresholdField;
        [FindsBy(How = How.CssSelector, Using = "[checked=\"checked\"]")]
        public IList<IWebElement> EnhancedUsageMonitoringCheckEnabled;
        






        public void EnterThresholdValues(string threshold)
        {
            foreach (var item in EnhancedUsageMonitoringThresholdField)
            {
                ClearAndType(item, threshold);
            }
        }

        public void EnableAllCheckBoxes()
        {
            foreach (var checkbox in EnhancedUsageMonitoringEnableCheckBox)
            {
                checkbox.Click();
            }
            
        }

        public void IsCheckBoxUnChecked()
        {
            foreach (var item in EnhancedUsageMonitoringEnableCheckBox)
            {
                TestCheck.AssertIsNullOrEmpty(item.GetAttribute("checked"), "Check box is not checked");
            }
        }

        public void SaveChanges()
        {
            if(EnhancedUsageMonitoringInstalledPrinterSaveButton == null)
                throw new Exception("Save button cannot be found");

            EnhancedUsageMonitoringInstalledPrinterSaveButton.Click();
        }

        public void IsThresholdValuesSaved(string threshold)
        {
            foreach (var item in EnhancedUsageMonitoringThresholdField)
            {
                var value = item.GetAttribute("value");

                TestCheck.AssertIsEqual(true, value.Equals(threshold), 
                    string.Format("{0} is not equal to {1}", value, threshold));
            }
        }

        public void IsCheckBoxChecked()
        {
            foreach (var item in EnhancedUsageMonitoringCheckEnabled)
            {
                AssertElementPresent(item, "Check box is not checked");
            }
        }
        

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

            TestCheck.AssertIsEqual(true, EnhancedUsageMonitoringProposalInformation.Displayed, "Enhanced Usage Monitoring Proposal Information is not displayed");
        }

        public void IsEnhancedUsageMonitoringContractPrinterInfoDisplayed()
        {
            if (EnhancedUsageMonitoringContractPrinterInfo == null)
                throw new Exception("Enhanced Usage Monitoring Contract Printer Info is returned as null");

            TestCheck.AssertIsEqual(true, EnhancedUsageMonitoringContractPrinterInfo.Displayed, "Enhanced Usage Monitoring Contract Printer Info is not displayed");
        }
        
    }
}
