using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CustomerConsumablesDevicesPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "div.tab-content";
        private const string _url = "/mps/customer/consumables/devices";

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        // ex. <div class="alert alert-info">Contract Reference: 142227 - Purchase + Click with Service</div>
        [FindsBy(How = How.CssSelector, Using = "div.alert.alert-info")]
        public IList<IWebElement> ContractReferenceElement;

        // ex. content_1_ContractDevicesList_Contracts_List_0_CellSerialNo_0
        [FindsBy(How = How.CssSelector, Using = "[id*='_CellSerialNo_']")]
        public IList<IWebElement> CellSerialNo;

        // ex. content_1_ContractDevicesList_Contracts_List_0_CellModel_0
        [FindsBy(How = How.CssSelector, Using = "[id*='_CellModel_']")]
        public IList<IWebElement> CellModel;

        // ex. content_1_ContractDevicesList_Contracts_List_0_Cell_BU_0
        [FindsBy(How = How.CssSelector, Using = "[id*='_Cell_BU_']")]
        public IList<IWebElement> Cell_BU;
        // ex. content_1_ContractDevicesList_Contracts_List_0_Cell_DR_0
        [FindsBy(How = How.CssSelector, Using = "[id*='_Cell_DR_']")]
        public IList<IWebElement> Cell_DR;
        // ex. content_1_ContractDevicesList_Contracts_List_0_Cell_WU_0
        [FindsBy(How = How.CssSelector, Using = "[id*='_Cell_WU_']")]
        public IList<IWebElement> Cell_WU;

        // ex. content_1_ContractDevicesList_Contracts_List_0_Cell_BW_0
        [FindsBy(How = How.CssSelector, Using = "[id*='_Cell_BW_']")]
        public IList<IWebElement> Cell_BW;
        // ex. content_1_ContractDevicesList_Contracts_List_0_Cell_C_0
        [FindsBy(How = How.CssSelector, Using = "[id*='_Cell_C_']")]
        public IList<IWebElement> Cell_C;
        // ex. content_1_ContractDevicesList_Contracts_List_0_Cell_M_0
        [FindsBy(How = How.CssSelector, Using = "[id*='_Cell_M_']")]
        public IList<IWebElement> Cell_M;
        // ex. content_1_ContractDevicesList_Contracts_List_0_Cell_Y_0
        [FindsBy(How = How.CssSelector, Using = "[id*='_Cell_Y_']")]
        public IList<IWebElement> Cell_Y;

        // ex. content_1_ContractDevicesList_Contracts_List_0_ReplenishModeIcon_0
        [FindsBy(How = How.CssSelector, Using = "[id*='_ReplenishModeIcon_']")]
        public IList<IWebElement> ReplenishModeIcon;


    }


    public class CustomerConsumablesDeviceItem 
    {
        [IgnoreParse]
        public string ContractId { get; set; }
        public string CellSerialNo { get; set; }
        public string CellModel { get; set; }
        public string Cell_BU { get; set; }
        public string Cell_DR { get; set; }
        public string Cell_WU { get; set; }
        public string Cell_BW { get; set; }
        public string Cell_C { get; set; }
        public string Cell_M { get; set; }
        public string Cell_Y { get; set; }
        //public string ReplenishModeIcon { get; set; }

    }

 
}
