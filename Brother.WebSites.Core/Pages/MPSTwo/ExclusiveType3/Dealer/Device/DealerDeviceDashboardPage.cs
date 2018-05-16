using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Device
{
    public class DealerDeviceOverviewPage : BasePage, IPageObject
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


        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonBack")]
        public IWebElement ButtonBackElement;


        public void VerifyDeviceDetails(AdditionalDeviceProperties device, string agreementType, string agreementLength, string usageType)
        {
            LoggingService.WriteLogOnMethodEntry(device, agreementType, agreementLength, usageType);

            var DashboardContainerElement = SeleniumHelper.FindElementByCssSelector(ContainerSelector, RuntimeSettings.DefaultFindElementTimeout);
            var deviceDetailsRow  = SeleniumHelper.FindElementByCssSelector(DashboardContainerElement, ".row");
            var deviceDetailsTableBodyElement = SeleniumHelper.FindElementByCssSelector(deviceDetailsRow, ".table > tbody");

            var StatusElement = SeleniumHelper.FindElementByCssSelector(deviceDetailsTableBodyElement, StatusSelector);
            var DeviceStatus = StatusElement.GetAttribute("class");

            var DeliveryAddress = device.AddressNumber + " " + device.AddressStreet + ", " + device.AddressArea + ", " + device.AddressTown + ", " + device.AddressPostCode;
            var Contact = device.ContactFirstName + ", " + device.ContactLastName + ", " + device.Telephone + ", " + device.Email;
            var TodaysDate = MpsUtil.DateTimeString(DateTime.Now);

            //1st row
            TestCheck.AssertTextContains(device.Model, SeleniumHelper.FindElementByCssSelector(deviceDetailsTableBodyElement, ".model-name").Text, string.Format("Device model = {0} could not be verified", device.Model));
            TestCheck.AssertTextContains(device.SerialNumber, SeleniumHelper.FindElementByCssSelector(deviceDetailsTableBodyElement, ".serial-number").Text, string.Format("Device serial number = {0} could not be verified", device.SerialNumber));
            TestCheck.AssertIsEqual("responding", DeviceStatus, string.Format("Device status = {0} is not equal to responding", DeviceStatus));
            TestCheck.AssertTextContains(TodaysDate, SeleniumHelper.FindElementByCssSelector(deviceDetailsTableBodyElement, ".last-comm").Text, string.Format("Last Communication date does not match"));
            
            //2nd row
            TestCheck.AssertTextContains(device.VolumeMono.ToString(), SeleniumHelper.FindElementByCssSelector(deviceDetailsTableBodyElement, ".volume").Text, string.Format("Minimum Volume = {0} could not be verified", device.VolumeMono));
            TestCheck.AssertTextContains(device.MonoClickPrice, SeleniumHelper.FindElementByCssSelector(deviceDetailsTableBodyElement, ".click-rate").Text, string.Format("Click Rate = {0} could not be verified", device.MonoClickPrice));
            TestCheck.AssertTextContains(device.CoverageMono.ToString(), SeleniumHelper.FindElementByCssSelector(deviceDetailsTableBodyElement, ".coverage").Text, string.Format("Agreed coverage = {0} could not be verified", device.CoverageMono));
            TestCheck.AssertTextContains(TodaysDate, SeleniumHelper.FindElementByCssSelector(deviceDetailsTableBodyElement, ".Install-date").Text, string.Format("Install date does not match"));
            
            //3rd row
            TestCheck.AssertTextContains(device.DeviceLocation, SeleniumHelper.FindElementByCssSelector(deviceDetailsTableBodyElement, ".location").Text, string.Format("Device location = {0} could not be verified", device.DeviceLocation));
            TestCheck.AssertTextContains(device.CostCentre, SeleniumHelper.FindElementByCssSelector(deviceDetailsTableBodyElement, ".costcentre").Text, string.Format("Cost centre = {0} could not be verified", device.CostCentre));
            TestCheck.AssertTextContains(agreementLength, SeleniumHelper.FindElementByCssSelector(deviceDetailsTableBodyElement, ".duration").Text, string.Format("Duration = {0} could not be verified", agreementLength));
            
            //4th row
            TestCheck.AssertTextContains(DeliveryAddress, SeleniumHelper.FindElementByCssSelector(deviceDetailsTableBodyElement, ".address").Text, string.Format("Delivery address = {0} could not be verified", DeliveryAddress));
            
            //5th row
            TestCheck.AssertTextContains(Contact, SeleniumHelper.FindElementByCssSelector(deviceDetailsTableBodyElement, ".contact-details").Text, string.Format("Contact = {0} could not be verified", Contact));
        }

        public void VerifyPrintCount(AdditionalDeviceProperties device)
        {
            LoggingService.WriteLogOnMethodEntry(device);
            TestCheck.AssertTextContains(device.MonoPrintCount.ToString(), SeleniumHelper.FindElementByCssSelector("span.mono-total").Text, string.Format("Total Print Count(Mono) = {0} could not be verified", device.MonoPrintCount));
            TestCheck.AssertTextContains("0", SeleniumHelper.FindElementByCssSelector("span.mono-start").Text, string.Format("Start Print Count(Mono) = {0} could not be verified", 0));
            TestCheck.AssertTextContains(device.MonoPrintCount.ToString(), SeleniumHelper.FindElementByCssSelector("span.mono-month").Text, string.Format("Pages This Month(Mono) = {0} could not be verified", device.MonoPrintCount));

            TestCheck.AssertTextContains(device.IsMonochrome ? "-" : device.ColorPrintCount.ToString(), SeleniumHelper.FindElementByCssSelector("span.colour-total").Text, string.Format("Total Print Count(Colour) = {0} could not be verified", device.ColorPrintCount));
            TestCheck.AssertTextContains(device.IsMonochrome ? "-" : "0", SeleniumHelper.FindElementByCssSelector("span.colour-start").Text, string.Format("Start Print Count(Colour) = {0} could not be verified", 0));
            TestCheck.AssertTextContains(device.IsMonochrome ? "-" : device.ColorPrintCount.ToString(), SeleniumHelper.FindElementByCssSelector("span.colour-month").Text, string.Format("Pages This Month(Colour) = {0} could not be verified", device.ColorPrintCount));
        }
    }
}
