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
    public class LocalOfficeApprovalReportManageCustomerPage : BasePage
    {


        [FindsBy(How = How.CssSelector, Using = "#content_0_LocationManage_Location_InputStreet_Input")]
        public IWebElement CustomerStreetField;
        [FindsBy(How = How.CssSelector, Using = "#content_0_LocationManage_Location_InputTown_Input")]
        public IWebElement CustomerTownField;
        [FindsBy(How = How.CssSelector, Using = "#content_0_LocationManage_InputCostCentre_Input")]
        public IWebElement CustomerCostCentreField;
        [FindsBy(How = How.CssSelector, Using = "#content_0_LocationManage_Location_InputArea_Input")]
        public IWebElement CustomerAreaField;
        [FindsBy(How = How.CssSelector, Using = "#content_0_ButtonSave")]
        public IWebElement UpdateButton;
        


        public void EditCustomerStreet()
        {
            if (string.IsNullOrWhiteSpace(CustomerStreetField.GetAttribute("value")))
            {
                ClearAndType(CustomerStreetField, "Edited Street Name");
            }
            else
            {
                var street = CustomerStreetField.GetAttribute("value");
                ClearAndType(CustomerStreetField, string.Format("Edited {0}", street));
            }
        }

        public void EditCustomerTown()
        {
            if (string.IsNullOrWhiteSpace(CustomerTownField.GetAttribute("value")))
            {
                ClearAndType(CustomerTownField, "Edited Town Name");
            }
            else
            {
                var town = CustomerTownField.GetAttribute("value");
                ClearAndType(CustomerTownField, string.Format("Edited {0}", town));
            }
        }

        public void EditCustomerArea()
        {
            if (string.IsNullOrWhiteSpace(CustomerAreaField.GetAttribute("value")))
            {
                ClearAndType(CustomerAreaField, "Edited Town Name");
            }
            else
            {
                var area = CustomerAreaField.GetAttribute("value");
                ClearAndType(CustomerAreaField, string.Format("Edited {0}", area));
            }
        }


        public void EditCustomerCostCentre()
        {
            if (string.IsNullOrWhiteSpace(CustomerCostCentreField.GetAttribute("value")))
            {
                ClearAndType(CustomerCostCentreField, "Edited Town Name");
            }
            else
            {
                var costcentre = CustomerCostCentreField.GetAttribute("value");
                ClearAndType(CustomerCostCentreField, string.Format("Edited {0}", costcentre));
            }
        }

        public ReportProposalSummaryPage UpdateEditedCustomerInformation()
        {
            if(UpdateButton == null)
                throw new Exception("update button is not displayed");

            UpdateButton.Click();

            return GetInstance<ReportProposalSummaryPage>();
        }
        
        
    }
}
