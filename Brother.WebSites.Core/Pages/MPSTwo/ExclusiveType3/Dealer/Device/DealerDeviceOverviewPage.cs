using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Device
{
    public class DealerDeviceOverviewPage : BasePage, IPageObject
    {
        private string _validationElementSelector = ".js-mps-device-data-container";
        private const string _url = "/mps/dealer/device/{reportingId}/overview";

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
        private const string TotalSilentDaysSelector = "#totalSilentDays";
        private const string MostRecentServiceRequestSelector = "#mostRecentServiceRequest";
        private const string TotalServiceRequestsSelector = "#totalServiceRequests";


        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonBack")]
        public IWebElement ButtonBackElement;

        // ex.   {"InstalledPrinterId":165116,"CommunicationMethod":1,"BlackTonerCount":null,"BlackLatest":null,"BlackTonerRemainingLife":"45","BlackTonerReplaceCount":4,"CyanTonerCount":null,"CyanLatest":null,"CyanTonerRemainingLife":"73","CyanTonerReplaceCount":4,"MagentaTonerCount":null,"MagentaLatest":null,"MagentaTonerRemainingLife":"73","MagentaTonerReplaceCount":4,"YellowTonerCount":null,"YellowLatest":null,"YellowTonerRemainingLife":"59","YellowTonerReplaceCount":4,"HasData":true}
        [FindsBy(How = How.CssSelector, Using = "#consumablesGraphData")]
        public IWebElement ConsumablesGraphDataElement;

        [FindsBy(How = How.CssSelector, Using = "span.black-replace-count")]
        public IWebElement BlackReplaceCountElement;
        [FindsBy(How = How.CssSelector, Using = "span.black-total")]
        public IWebElement BlackTotalElement;
        [FindsBy(How = How.CssSelector, Using = "span.black-date")]
        public IWebElement BlackDateElement;

        [FindsBy(How = How.CssSelector, Using = "span.cyan-replace-count")]
        public IWebElement CyanReplaceCountElement;
        [FindsBy(How = How.CssSelector, Using = "span.cyan-total")]
        public IWebElement CyanTotalElement;
        [FindsBy(How = How.CssSelector, Using = "span.cyan-date")]
        public IWebElement CyanDateElement;

        [FindsBy(How = How.CssSelector, Using = "span.magenta-replace-count")]
        public IWebElement MagentaReplaceCountElement;
        [FindsBy(How = How.CssSelector, Using = "span.magenta-total")]
        public IWebElement MagentaTotalElement;
        [FindsBy(How = How.CssSelector, Using = "span.magenta-date")]
        public IWebElement MagentaDateElement;

        [FindsBy(How = How.CssSelector, Using = "span.yellow-replace-count")]
        public IWebElement YellowReplaceCountElement;
        [FindsBy(How = How.CssSelector, Using = "span.yellow-total")]
        public IWebElement YellowTotalElement;
        [FindsBy(How = How.CssSelector, Using = "span.yellow-date")]
        public IWebElement YellowDateElement;

        [FindsBy(How = How.CssSelector, Using = "#serviceRequestGraphData")]
        public IWebElement ServiceRequestGraphDataElement;

        [FindsBy(How = How.CssSelector, Using = "#silentGraphData")]
        public IWebElement SilentGraphDataElement;

        
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
            var TodaysDate = MpsUtil.DateTimeString(DateTime.Now, RegionInfo.TwoLetterISORegionName);

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

        public void VerifyConsumableBlack(AdditionalDeviceProperties device, Dictionary<string, string> consumableJson, string bocTonerInkReplaceCount, string bocTonerInkLife, string latestDate)
        {
            LoggingService.WriteLogOnMethodEntry(device, consumableJson, bocTonerInkReplaceCount, bocTonerInkLife, latestDate);
            var message = " mismatch BOCSim.id=" + device.BocDeviceId;
            TestCheck.AssertIsEqual(bocTonerInkReplaceCount, BlackReplaceCountElement.Text, "BlackReplaceCountElement" + message);
            TestCheck.AssertIsEqual(device.TonerInkBlackOrderCount.ToString(), BlackTotalElement.Text, "BlackTotalElement" + message);
            TestCheck.AssertIsEqual((BlackTotalElement.Text != "0" ? latestDate : ""), BlackDateElement.Text, "BlackDateElement" + message);
            TestCheck.AssertIsEqual(bocTonerInkLife.Replace(" %", ""), consumableJson["BlackTonerRemainingLife"], "TonerRemainingLife" + message);
        }

        public void VerifyConsumableCyan(AdditionalDeviceProperties device, Dictionary<string, string> consumableJson, string bocTonerInkReplaceCount, string bocTonerInkLife, string latestDate)
        {
            LoggingService.WriteLogOnMethodEntry(device, consumableJson, bocTonerInkReplaceCount, bocTonerInkLife, latestDate);
            var message = " mismatch BOCSim.id=" + device.BocDeviceId;
            TestCheck.AssertIsEqual(bocTonerInkReplaceCount, CyanReplaceCountElement.Text, "CyanReplaceCountElement"+ message);
            TestCheck.AssertIsEqual(device.TonerInkCyanOrderCount.ToString(), CyanTotalElement.Text, "CyanTotalElement"+ message);
            TestCheck.AssertIsEqual((CyanTotalElement.Text!="0" ? latestDate: "") , CyanDateElement.Text, "CyanDateElement"+ message);
            TestCheck.AssertIsEqual(bocTonerInkLife.Replace(" %", ""), consumableJson["CyanTonerRemainingLife"], "TonerRemainingLife"+ message);
        }

        public void VerifyConsumableMagenta(AdditionalDeviceProperties device,  Dictionary<string, string> consumableJson, string bocTonerInkReplaceCount, string bocTonerInkLife, string latestDate)
        {
            LoggingService.WriteLogOnMethodEntry(device, consumableJson, bocTonerInkReplaceCount, bocTonerInkLife, latestDate);
            var message = " mismatch BOCSim.id=" + device.BocDeviceId;
            TestCheck.AssertIsEqual(bocTonerInkReplaceCount, MagentaReplaceCountElement.Text, "MagentaReplaceCountElement" + message);
            TestCheck.AssertIsEqual(device.TonerInkMagentaOrderCount.ToString(), MagentaTotalElement.Text, "MagentaTotalElement" + message);
            TestCheck.AssertIsEqual((MagentaTotalElement.Text != "0" ? latestDate : ""), MagentaDateElement.Text, "MagentaDateElement" + message);
            TestCheck.AssertIsEqual(bocTonerInkLife.Replace(" %", ""), consumableJson["MagentaTonerRemainingLife"], "TonerRemainingLife" + message);
        }

        public void VerifyConsumableYellow(AdditionalDeviceProperties device,  Dictionary<string, string> consumableJson, string bocTonerInkReplaceCount, string bocTonerInkLife, string latestDate)
        {
            LoggingService.WriteLogOnMethodEntry(device, consumableJson, bocTonerInkReplaceCount, bocTonerInkLife, latestDate);
            var message = " mismatch BOCSim.id=" + device.BocDeviceId;
            TestCheck.AssertIsEqual(bocTonerInkReplaceCount, YellowReplaceCountElement.Text, "YellowReplaceCountElement" + message);
            TestCheck.AssertIsEqual(device.TonerInkYellowOrderCount.ToString(), YellowTotalElement.Text, "YellowTotalElement" + message);
            TestCheck.AssertIsEqual((YellowTotalElement.Text != "0" ? latestDate : ""), YellowDateElement.Text, "YellowDateElement" + message);
            TestCheck.AssertIsEqual(bocTonerInkLife.Replace(" %", ""), consumableJson["YellowTonerRemainingLife"], "TonerRemainingLife" + message);
        }

        public void VerifyServiceRequest(AdditionalDeviceProperties device, Dictionary<string, string> serviceRequestJson, string latestDate)
        {
            LoggingService.WriteLogOnMethodEntry(device, serviceRequestJson, latestDate);
            var message = " mismatch BOCSim.id=" + device.BocDeviceId;
            int openRequest = (device.OpenServiceRequest - device.ClosedServiceRequest);
            string serviceRequestTotal = device.OpenServiceRequest != 0 ? device.TotalServiceRequest.ToString() : null; 
            TestCheck.AssertIsEqual(openRequest.ToString(), serviceRequestJson["TotalOpen"], "OpenServiceRequest" + message);
            TestCheck.AssertIsEqual(device.ClosedServiceRequest.ToString(), serviceRequestJson["TotalClosed"], "ClosedServiceRequest" + message);
            TestCheck.AssertIsEqual(serviceRequestTotal, serviceRequestJson["Total"], "TotalServiceRequestChart" + message);
            if(device.IsMonochrome == false)
            {
                var TotalServiceRequestsElement = SeleniumHelper.FindElementByCssSelector(TotalServiceRequestsSelector);
                var MostRecentServiceRequestElement = SeleniumHelper.FindElementByCssSelector(MostRecentServiceRequestSelector);
                TestCheck.AssertIsEqual(device.TotalServiceRequest.ToString(), TotalServiceRequestsElement.Text, "TotalServiceRequest" + message);
                TestCheck.AssertTextContains(latestDate, MostRecentServiceRequestElement.Text, "MostRecentServiceRequest" + message);
            }
        }

        public void VerifySilentDetails(AdditionalDeviceProperties device, Dictionary<string, object> silentJson, int agreementShiftDays)
        {
            LoggingService.WriteLogOnMethodEntry(device, silentJson, agreementShiftDays);
            var message = " mismatch BOCSim.id=" + device.BocDeviceId;
            TestCheck.AssertIsEqual(agreementShiftDays.ToString(), (string)silentJson["TotalSilentDays"], "TotalSilentDaysChart" + message);
            if(device.IsMonochrome == false)
            {
                var TotalSilentDaysElement = SeleniumHelper.FindElementByCssSelector(TotalSilentDaysSelector);
                TestCheck.AssertIsEqual(agreementShiftDays.ToString(), TotalSilentDaysElement.Text, "TotalSilentDays" + message);
            }
        }
    }
}
