using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Device
{
    public class DealerDeviceDashboardPage : BasePage, IPageObject
    {
        private string _validationElementSelector = ".js-mps-device-data-container";
        private const string _url = "/mps/dealer/device/{reportingId}/dashboard"; // TODO: Replace reportingId with dynamic parameter

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        private const string ContainerSelector = ".tab-pane.active.container-fluid";
        private const string StatusSelector = "#content_1_DeviceDataSummary_StatusIconCell";

        public void VerifyDeviceDetails(AdditionalDeviceProperties device, string agreementType, string agreementLength, string usageType)
        {
            LoggingService.WriteLogOnMethodEntry(device, agreementType, agreementLength, usageType);

            var DashboardContainerElement = SeleniumHelper.FindElementByCssSelector(ContainerSelector, RuntimeSettings.DefaultFindElementTimeout);
            var DashboardContainerRows = SeleniumHelper.FindRowElementsWithinTable(DashboardContainerElement);
            var StatusElement = SeleniumHelper.FindElementByCssSelector(DashboardContainerRows[0], StatusSelector);
            var DeviceStatus = StatusElement.GetAttribute("class");

            var DeliveryAddress = device.AddressNumber + " " + device.AddressStreet + ", " + device.AddressTown + ", " + device.AddressPostCode;

            TestCheck.AssertTextContains(device.Model, DashboardContainerRows[0].Text, string.Format("Device model = {0} could not be verified", device.Model));
            TestCheck.AssertTextContains(device.SerialNumber, DashboardContainerRows[0].Text, string.Format("Device serial number = {0} could not be verified", device.SerialNumber));
            TestCheck.AssertIsEqual("responding", DeviceStatus, string.Format("Device status = {0} is not equal to responding", DeviceStatus));

            TestCheck.AssertTextContains(device.VolumeMono.ToString(), DashboardContainerRows[1].Text, string.Format("Minimum Volume = {0} could not be verified", device.VolumeMono));
            TestCheck.AssertTextContains(device.MonoClickPrice, DashboardContainerRows[1].Text, string.Format("Click Rate = {0} could not be verified", device.MonoClickPrice));
            TestCheck.AssertTextContains(device.CoverageMono.ToString(), DashboardContainerRows[1].Text, string.Format("Agreed coverage = {0} could not be verified", device.CoverageMono));
            
            TestCheck.AssertTextContains(device.DeviceLocation, DashboardContainerRows[2].Text, string.Format("Device location = {0} could not be verified", device.DeviceLocation));
            TestCheck.AssertTextContains(device.CostCentre, DashboardContainerRows[2].Text, string.Format("Cost centre = {0} could not be verified", device.CostCentre));
            TestCheck.AssertTextContains(agreementLength, DashboardContainerRows[2].Text, string.Format("Duration = {0} could not be verified", agreementLength));
        
            TestCheck.AssertTextContains(DeliveryAddress, DashboardContainerRows[3].Text, string.Format("Delivery address = {0} could not be verified", DeliveryAddress));

        }
    }
}
