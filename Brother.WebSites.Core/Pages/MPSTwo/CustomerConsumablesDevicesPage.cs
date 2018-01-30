using Brother.WebSites.Core.Pages.Base;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class CustomerConsumablesDevicesPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "table.mps-order-consumables-container";
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

        
        public override string DefaultTitle
        {
            get { return string.Empty; }
        }



    }


    public class CustomerConsumablesDeviceItem 
    {
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

    }

 
}
