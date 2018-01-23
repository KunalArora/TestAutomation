using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Reflection;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BaseSummaryPage : BasePage
    {
        /**
         * 
         * Contract Details
         * 
         **/
        // Proposal Name
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelProposalName")]
        public IWebElement SummaryTable_LabelProposalName;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ProposalName")]
        public IWebElement SummaryTable_ProposalName;
        // Contract Type
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelContractType")]
        public IWebElement SummaryTable_LabelContractType;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ContractType")]
        public IWebElement SummaryTable_ContractType;

        // Contract Term
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelContractTerm")]
        public IWebElement SummaryTable_LabelContractTerm;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ContractTerm")]
        public IWebElement SummaryTable_ContractTerm;
        // Usage Type
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelUsageType")]
        public IWebElement SummaryTable_LabelUsageType;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_UsageType")]
        public IWebElement SummaryTable_UsageType;

        // Customer Name
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelCustomerName")]
        public IWebElement SummaryTable_LabelCustomerName;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerName")]
        public IWebElement SummaryTable_CustomerName;
        // Lead Code Reference
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelLeadCodeReference")]
        public IWebElement SummaryTable_LabelLeadCodeReference;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LeadCodeReference")]
        public IWebElement SummaryTable_LeadCodeReference;

        // Usage Billing Frequency
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelUsageBillingFrequency")]
        public IWebElement SummaryTable_LabelUsageBillingFrequency;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_UsageBillingFrequency")]
        public IWebElement SummaryTable_UsageBillingFrequency;

        /**
         * 
         * Dealer Details TBD
         * 
         **/


        /**
         * 
         * Customer Details TBD
         * 
         **/


        /**
         * 
         * Customer Requirements TBD
         * 
         **/

        /**
         * 
         * Contract Totals
         * 
         **/
        // Hardware
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_HardwareTotalName")]
        public IWebElement SummaryTable_HardwareTotalName;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_HardwareTotalQuantity")]
        public IWebElement SummaryTable_HardwareTotalQuantity;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_HardwareTotalLineCost")]
        public IWebElement SummaryTable_HardwareTotalLineCost;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_HardwareTotalLineMargin")]
        public IWebElement SummaryTable_HardwareTotalLineMargin;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_HardwareTotalLinePrice")]
        public IWebElement SummaryTable_HardwareTotalLinePrice;

        // Accessories
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_AccessoryTotalName")]
        public IWebElement SummaryTable_AccessoryTotalName;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_AccessoryTotalQuantity")]
        public IWebElement SummaryTable_AccessoryTotalQuantity;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_AccessoryTotalLineCost")]
        public IWebElement SummaryTable_AccessoryTotalLineCost;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_AccessoryTotalLineMargin")]
        public IWebElement SummaryTable_AccessoryTotalLineMargin;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_AccessoryTotalLinePrice")]
        public IWebElement SummaryTable_AccessoryTotalLinePrice;

        // Delivery
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeliveryTotalName")]
        public IWebElement SummaryTable_DeliveryTotalName;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeliveryTotalQuantity")]
        public IWebElement SummaryTable_DeliveryTotalQuantity;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeliveryTotalLineCost")]
        public IWebElement SummaryTable_DeliveryTotalLineCost;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeliveryTotalLineMargin")]
        public IWebElement SummaryTable_DeliveryTotalLineMargin;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeliveryTotalLinePrice")]
        public IWebElement SummaryTable_DeliveryTotalLinePrice;

        // Installation
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_InstallationTotalName")]
        public IWebElement SummaryTable_InstallationTotalName;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_InstallationTotalQuantity")]
        public IWebElement SummaryTable_InstallationTotalQuantity;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_InstallationTotalLineCost")]
        public IWebElement SummaryTable_InstallationTotalLineCost;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_InstallationTotalLineMargin")]
        public IWebElement SummaryTable_InstallationTotalLineMargin;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_InstallationTotalLinePrice")]
        public IWebElement SummaryTable_InstallationTotalLinePrice;

        // Service Packs
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ServicePackTotalName")]
        public IWebElement SummaryTable_ServicePackTotalName;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ServicePackTotalQuantity")]
        public IWebElement SummaryTable_ServicePackTotalQuantity;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ServicePackTotalLineCost")]
        public IWebElement SummaryTable_ServicePackTotalLineCost;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ServicePackTotalLineMargin")]
        public IWebElement SummaryTable_ServicePackTotalLineMargin;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ServicePackTotalLinePrice")]
        public IWebElement SummaryTable_ServicePackTotalLinePrice;

        // Device Totals (Net)
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelDeviceTotals")]
        public IWebElement SummaryTable_LabelDeviceTotals;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelDeviceTotalsNet")]
        public IWebElement SummaryTable_LabelDeviceTotalsNet;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeviceTotalsTotalCostNet")]
        public IWebElement SummaryTable_DeviceTotalsTotalCostNet;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeviceTotalsTotalMarginNet")]
        public IWebElement SummaryTable_DeviceTotalsTotalMarginNet;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeviceTotalsTotalPriceNet")]
        public IWebElement SummaryTable_DeviceTotalsTotalPriceNet;

        // Device Totals (Gross)
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelDeviceTotalsGross")]
        public IWebElement SummaryTable_LabelDeviceTotalsGross;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeviceTotalsTotalCostGross")]
        public IWebElement SummaryTable_DeviceTotalsTotalCostGross;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeviceTotalsTotalMarginGross")]
        public IWebElement SummaryTable_DeviceTotalsTotalMarginGross;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DeviceTotalsTotalPriceGross")]
        public IWebElement SummaryTable_DeviceTotalsTotalPriceGross;

        // Mono Click
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_MonoTotalName")]
        public IWebElement SummaryTable_MonoTotalName;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_MonoTotalVolume")]
        public IWebElement SummaryTable_MonoTotalVolume;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_MonoTotalLineCost")]
        public IWebElement SummaryTable_MonoTotalLineCost;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_MonoTotalLineMargin")]
        public IWebElement SummaryTable_MonoTotalLineMargin;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_MonoTotalLinePrice")]
        public IWebElement SummaryTable_MonoTotalLinePrice;

        // Colour Click
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ColourTotalName")]
        public IWebElement SummaryTable_ColourTotalName;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ColourTotalVolume")]
        public IWebElement SummaryTable_ColourTotalVolume;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ColourTotalLineCost")]
        public IWebElement SummaryTable_ColourTotalLineCost;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ColourTotalLineMargin")]
        public IWebElement SummaryTable_ColourTotalLineMargin;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ColourTotalLinePrice")]
        public IWebElement SummaryTable_ColourTotalLinePrice;

        // Consumables Totals
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelConsumableTotals")]
        public IWebElement SummaryTable_LabelConsumableTotals;
        // Consumables Totals (Net)
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelConsumableTotalsNet")]
        public IWebElement SummaryTable_LabelConsumableTotalsNet;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalMarginNet")]
        public IWebElement SummaryTable_ConsumableTotalsTotalMarginNet;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalPriceNet")]
        public IWebElement SummaryTable_ConsumableTotalsTotalPriceNet;
        // Consumables Totals (Gross)
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelConsumableTotalsGross")]
        public IWebElement SummaryTable_LabelConsumableTotalsGross;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalMarginGross")]
        public IWebElement SummaryTable_ConsumableTotalsTotalMarginGross;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ConsumableTotalsTotalPriceGross")]
        public IWebElement SummaryTable_ConsumableTotalsTotalPriceGross;

        // Other Fees and Charges
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelChargesTotal")]
        public IWebElement SummaryTable_LabelChargesTotal;
        // Other Fees and Charges (Net)
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelChargesTotalNet")]
        public IWebElement SummaryTable_LabelChargesTotalNet;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ChargesTotalMarginNet")]
        public IWebElement SummaryTable_ChargesTotalMarginNet;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ChargesTotalPriceNet")]
        public IWebElement SummaryTable_ChargesTotalPriceNet;
        // Other Fees and Charges (Gross)
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelChargesTotalGross")]
        public IWebElement SummaryTable_LabelChargesTotalGross;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ChargesTotalMarginGross")]
        public IWebElement SummaryTable_ChargesTotalMarginGross;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ChargesTotalPriceGross")]
        public IWebElement SummaryTable_ChargesTotalPriceGross;

        // Contract Total Based On Minimum Volume Per Device
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelGrandTotal")]
        public IWebElement SummaryTable_LabelGrandTotal;
        // Contract Total Based On Minimum Volume Per Device (Net)
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelGrandTotalNet")]
        public IWebElement SummaryTable_LabelGrandTotalNet;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_GrandTotalMarginNet")]
        public IWebElement SummaryTable_GrandTotalMarginNet;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_GrandTotalPriceNet")]
        public IWebElement SummaryTable_GrandTotalPriceNet;
        // Contract Total Based On Minimum Volume Per Device (Gross)
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_LabelGrandTotalGross")]
        public IWebElement SummaryTable_LabelGrandTotalGross;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_GrandTotalMarginGross")]
        public IWebElement SummaryTable_GrandTotalMarginGross;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_GrandTotalPriceGross")]
        public IWebElement SummaryTable_GrandTotalPriceGross;




    }

    public class SummaryValue : Dictionary<string, string>
    {
        public string SummaryTable_ContractTerm { get { return GetValue(MethodBase.GetCurrentMethod().Name); } set { SetValue(MethodBase.GetCurrentMethod().Name, value); } }
        public string SummaryTable_DeviceTotalsTotalPriceNet { get { return GetValue(MethodBase.GetCurrentMethod().Name); } set { SetValue(MethodBase.GetCurrentMethod().Name, value); } }
        public string SummaryTable_ConsumableTotalsTotalPriceNet { get { return GetValue(MethodBase.GetCurrentMethod().Name); } set { SetValue(MethodBase.GetCurrentMethod().Name, value); } }

        private void SetValue(string name, string value)
        {
            this[name.Replace("set_","")]= value;
        }

        private string GetValue(string name)
        {
            return this[name.Replace("get_", "")];
        }

        public static SummaryValue Parse(DealerProposalsSummaryPage page)
        {
            var value = new SummaryValue();
            value.SummaryTable_ContractTerm = page.SummaryTable_ContractTerm.Text;
            value.SummaryTable_DeviceTotalsTotalPriceNet = page.SummaryTable_DeviceTotalsTotalPriceNet.Text;
            value.SummaryTable_ConsumableTotalsTotalPriceNet = page.SummaryTable_ConsumableTotalsTotalPriceNet.Text;

            var modelElementList = page.SeleniumHelper.FindElementsByCssSelector("div[class*=\"panel panel-default mps-qa-printer mps-qa-printer-\"]");
            foreach ( var modelElement in modelElementList)
            {
                var elemStrong = modelElement.FindElement(By.ClassName("panel-heading")).FindElement(By.TagName("strong"));
                var modelName = elemStrong.Text; // ex. MFC-L8650CDW
                var tdElementList = modelElement.FindElements(By.TagName("td"));
                foreach( var tdElement in tdElementList)
                {
                    var idString = tdElement.GetAttribute("id"); // ex. content_1_SummaryTable_RepeaterModels_RepeaterInstallationPacks_3_InstallationPackUnitCost_0
                    var idArr = idString.Split('_');
                    if (idArr.Length < 2) continue;
                    var itemName = idArr[idArr.Length - 2]; // ex. InstallationPackUnitCost
                    var dictKey = string.Format("{0}.{1}", modelName, itemName);// key ex. MFC-L8650CDW.InstallationPackUnitCost
                    value.Add(dictKey, tdElement.Text); 
                }
            }
            return value;
        }

        public string GetModel(string key)
        {
            return key.Split('.')[0];
        }
    }

}
