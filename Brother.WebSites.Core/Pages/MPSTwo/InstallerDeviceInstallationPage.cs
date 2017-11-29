﻿using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;


namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class InstallerDeviceInstallationPage : BasePage, IPageObject
    {
        public static string _url = "/mps/web-installation/installation-devices";
        private const string _validationElementSelector = "[id*=\"content_0_DeviceInstallList_List_InputSerialNumber\"].js-mps-device-serial-number-input";
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

        private const string SerialNumber = @"A1T010001";
        private const string SerialNumberBig = @"A1T010002";
        private const string SerialNumberAut = @"A1T010003";
        private const string ExistingSerialNumber = @"A1T010001";
        private const string ExistingSerialNumberBig = @"A1T010002";
        private const string ExistingSerialNumberAut = @"A1T010003";
        private const string SerialNumberBnn = @"A1T010011";
        private const string SerialNumberBnf = @"A1T010012";
        private const string SerialNumberBnd = @"A1T010013";
        private const string SerialNumberBfr = @"A1T010014";
        private const string SerialNumberBit = @"A1T010015";
        private const string SerialNumberBes = @"A1T010016";
        private const string SerialNumberBir = @"F3Y112595";
        private const string SerialNumberBns = @"F3Y112595";
        private const string SerialNumberBbe = @"F3Y112595";
        private const string SerialNumberBnl = @"F3Y112595";
        private const string SerialNumberBpl = @"F3Y112595";
        private const string SerialNumberBsw = @"B8C742391";
        private const string SwapSerialNumberUk = @"F3Y112553";
        private const string SwapSerialNumberDe = @"F3Y112555";
        private const string SwapSerialNumberAt = @"F3Y112561";
        private const string SwapSerialNumberFr = @"F3Y111491";
        private const string SwapSerialNumberIt = @"F3Y111493";
        private const string SwapSerialNumberEs = @"F3Y111494";
        private const string SwapSerialNumberIr = @"F3Y112650";
        private const string SwapSerialNumberPl = @"F3Y112652";
        private const string SwapSerialNumberNl = @"F3Y112656";
        private const string SwapSerialNumberNs = @"F3Y112657";
        private const string SwapSerialNumberBe = @"F3Y112658";
        private const string SwapSerialNumberSw = @"F3Y112663";
         

        public override string DefaultTitle
        {
            get { return String.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_0_InputContractReference_Input")] 
        public IWebElement ContractReferenceFieldElement;
        [FindsBy(How = How.CssSelector, Using = "#content_0_ComponentIntroductionAlert")] 
        public IWebElement ContractReferencePageAlertElement;
        [FindsBy(How = How.CssSelector, Using = "#content_0_ButtonNext")] 
        public IWebElement NextButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".col-sm-8 .form-control-static")] 
        public IList<IWebElement> PinAndAddressElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"content_0_DeviceInstallList_List_InputSerialNumber\"].js-mps-device-serial-number-input")] 
        public IWebElement SerialNumberFieldElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"content_0_DeviceInstallList_List_InputSerialNumber\"].js-mps-device-serial-number-input")]
        public IList<IWebElement> SerialNumbersElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-ip-input[class*='js-mps-ip-']")] 
        public IList<IWebElement> IpAddressElements;
        [FindsBy(How = How.CssSelector, Using = "p.form-control-static")] 
        public IList<IWebElement> InstalledPinElements;
        [FindsBy(How = How.CssSelector, Using = "#content_0_DeviceInstallList_List_ButtonConnectDevice_0")] 
        public IWebElement WebInstallConnect;
        [FindsBy(How = How.CssSelector, Using = "[class*=\"js-mps-connect-device-to-\"]")] 
        public IWebElement ConnectButtonElement;
        [FindsBy(How = How.CssSelector, Using = "[class*=\"js-mps-connect-device-to-\"]")]
        public IList<IWebElement> ConnectButtonsElement;
        [FindsBy(How = How.CssSelector, Using = "[type=\"submit\"][id*=\"content_0_Button\"]")] 
        public IWebElement CompleteInstallationElement;
        [FindsBy(How = How.CssSelector, Using = "#content_0_InstallationSuccessfullyFinished")] 
        public IWebElement CompleteInstallationComfirmationElement;
        [FindsBy(How = How.CssSelector, Using = "#content_0_ButtonCompleteCloudInstallation")] 
        public IWebElement CompleteCloudInstallationComfirmationElement;
        [FindsBy(How = How.CssSelector, Using = "#content_0_InstallationSuccessfullyFinished")] 
        public IWebElement InstallationConfirmationMessageElement;
        [FindsBy(How = How.CssSelector, Using = "#content_0_InputTimeZone_Input")] 
        public IWebElement TimeZoneOptionsElements;
        [FindsBy(How = How.CssSelector, Using = "#content_0_ButtonRefresh")] 
        public IWebElement RefreshCloudInstallationElement;
        [FindsBy(How = How.CssSelector, Using = "#content_0_DeviceInstallList_List_CellConnectionStatusIcon_0")] 
        public IWebElement CloudInstallationConnectionStatusElements;
        [FindsBy(How = How.CssSelector, Using = "#content_0_DeviceInstallList_List_CellConnectionStatus_0 .glyphicon-ok")] 
        public IWebElement CloudInstallationConnectionStatusIconElements;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"content_0_DeviceInstallList_List_CellConnectionStatus_\"] .glyphicon-ok")]
        public IList<IWebElement> CloudInstallationMultipleConnectionStatusIconElements;
        [FindsBy(How = How.CssSelector, Using = "#content_0_DeviceInstallList_List_ButtonResetDevice_0")]
        public IWebElement ResetInstallationButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-pin-code")] 
        public IWebElement CloudInstallationWebInstallPinElements;
        [FindsBy(How = How.CssSelector, Using = "#WhereIsMySerialNumberModal .modal-header [type=\"button\"][data-dismiss=\"modal\"]")] 
        public IWebElement WhereIsMyDevicePopUpElements;
        [FindsBy(How = How.CssSelector, Using = "#content_0_DeviceInstallList_List_CellConnectionStatusIcon_0[data-original-title=\"Not connected\"]")]
        public IWebElement CloudInstallationNoConnectionStatusIconElements;
        [FindsBy(How = How.CssSelector, Using = ".has-success .glyphicon.glyphicon-ok")]
        public IWebElement InstallationSerialNumberCheckSuccessIconElement;
        [FindsBy(How = How.CssSelector, Using = ".has-error .glyphicon.glyphicon-remove")]
        public IWebElement InstallationSerialNumberCheckFailureIconElements;
        [FindsBy(How = How.CssSelector, Using = ".has-success .glyphicon.glyphicon-ok")]
        public IList<IWebElement> InstallationSerialNumberCheckSuccessIconElements;
        [FindsBy(How = How.CssSelector, Using = "#content_0_SwapOldDeviceInputMono")]
        public IWebElement SwapOldMonoElement;
        [FindsBy(How = How.CssSelector, Using = "#content_0_SwapOldDeviceInputColour")]
        public IWebElement SwapOldColourElement;
        [FindsBy(How = How.CssSelector, Using = "#content_0_SwapNewDeviceInputMono")]
        public IWebElement SwapNewMonoElement;
        [FindsBy(How = How.CssSelector, Using = "#content_0_SwapNewDeviceInputColour")]
        public IWebElement SwapNewColourElement;


        private const string InstallationDeviceInstallListSelector = ".js-mps-device-install-list-container";
        private const string InstallationTableSelector = ".js-mps-searchable";
        private const string InstallationSerialNumberSelector = "[id*=content_0_DeviceInstallList_List_InputSerialNumber_]";
        private const string InstallationModelSelector = "[id*=content_0_DeviceInstallList_List_CellModel_]";
        private const string InstallationSerialNumberValidSelector = ".has-success .glyphicon.glyphicon-ok";
        private const string InstallationConnectButtonSelector = "[id*=content_0_DeviceInstallList_List_ButtonConnectDevice_]";
        private const string InstallationIpAddressInput1 = "[id*=content_0_DeviceInstallList_List_InputIpPart1_]";
        private const string InstallationIpAddressInput2 = "[id*=content_0_DeviceInstallList_List_InputIpPart2_]";
        private const string InstallationIpAddressInput3 = "[id*=content_0_DeviceInstallList_List_InputIpPart3_]";
        private const string InstallationIpAddressInput4 = "[id*=content_0_DeviceInstallList_List_InputIpPart4_]";
        private const string InstallationPinCodeSelector = ".js-mps-pin-code";
        private const string RefreshButtonSelector = "#content_0_ButtonRefresh";
        private const string CompleteButtonSelector = "#content_0_ButtonCompleteCloudInstallation";
        private const string InstallationSuccessfullyFinishedSelector = "#content_0_InstallationSuccessfullyFinished";

        public void ResetSerialNumber(string serialNumber)
        {
            if (ContractReferencePageAlertElement == null)
                throw new Exception("Installer page is not displayed");
            AssertElementPresent(ContractReferencePageAlertElement, "Installer pager alert");

            MpsJobRunnerPage.RunResetSerialNumberJob(serialNumber);
        }
        public void EnterSerialNumber(string modelName, string serialNumber, int findElementTimeout ,IWebDriver installerDriver, string mainInstallerWindowHandle)
        {
            ClosePopUpModal();
 
            var deviceListElement = SeleniumHelper.FindElementByCssSelector(InstallationDeviceInstallListSelector, findElementTimeout);
            var tableElement = SeleniumHelper.FindElementByCssSelector(deviceListElement, InstallationTableSelector, findElementTimeout);

            var rows = SeleniumHelper.FindRowElementsWithinTable(tableElement);
            foreach (var row in rows)
            {
                ResetSerialNumber(serialNumber);
                var modelElement = SeleniumHelper.FindElementByCssSelector(row, InstallationModelSelector, findElementTimeout);
                var serialNumberElement = SeleniumHelper.FindElementByCssSelector(row, InstallationSerialNumberSelector, findElementTimeout);
                if(modelElement.Text.Equals(modelName))
                {
                    ClearAndType(serialNumberElement, serialNumber);
                    serialNumberElement.SendKeys(Keys.Tab);
                    SeleniumHelper.FindElementByCssSelector(row, InstallationSerialNumberValidSelector, findElementTimeout);
                    PopulateIpAddress(row, findElementTimeout);
                    ClickOnConnect(row, findElementTimeout, installerDriver);
                    RetryResetClickingHelper(findElementTimeout, serialNumber, mainInstallerWindowHandle);
                    break;
                }
            }
        }

        public void ClickOnConnect(IWebElement row, int findElementTimeout, IWebDriver driver)
        {
            var clickButtonElement = SeleniumHelper.FindElementByCssSelector(row, InstallationConnectButtonSelector, findElementTimeout);
            clickButtonElement.Click();

        }

        public void RetryResetClickingHelper(int findElementTimeout, string serialNumber, string mainInstallerWindowHandle)
        {
            var ResetButtonSelector = "[id*=content_0_DeviceInstallList_List_CellConnectionStatusIcon_]";

            var elementStatus = false;
            var retries = 0;
            var retryCount = 10;

            while ((!elementStatus) && (retries != retryCount))
            {
                try
                {
                    var refreshElement = SeleniumHelper.FindElementByCssSelector(RefreshButtonSelector, findElementTimeout);
                    refreshElement.Click();

                    var deviceListElement = SeleniumHelper.FindElementByCssSelector(InstallationDeviceInstallListSelector, findElementTimeout);
                    var tableElement = SeleniumHelper.FindElementByCssSelector(deviceListElement, InstallationTableSelector, findElementTimeout);

                    var rows = SeleniumHelper.FindRowElementsWithinTable(tableElement);
                    foreach (var row in rows)
                    {
                        var serialNumberElement = SeleniumHelper.FindElementByCssSelector(row, InstallationSerialNumberSelector, findElementTimeout);
                        if (serialNumberElement.GetAttribute("value") == serialNumber)
                        {
                            var isConnectedElement = SeleniumHelper.FindElementByCssSelector(row, ResetButtonSelector, findElementTimeout);
                            elementStatus = isConnectedElement.GetAttribute("data-original-title").Equals("Connected");
                            break;
                        }

                    }
                    SeleniumHelper.CloseBrowserTabsExceptMainWindow(mainInstallerWindowHandle);
                    retries++;
                }
                catch (WebDriverException)
                {
                    retries++;
                }
            }
        }

        public void PopulateIpAddress(IWebElement row, int findElementTimeout)
        {
            var ipAddressInput1Element = SeleniumHelper.FindElementByCssSelector(row, InstallationIpAddressInput1, findElementTimeout);
            var ipAddressInput2Element = SeleniumHelper.FindElementByCssSelector(row, InstallationIpAddressInput2, findElementTimeout);
            var ipAddressInput3Element = SeleniumHelper.FindElementByCssSelector(row, InstallationIpAddressInput3, findElementTimeout);
            var ipAddressInput4Element = SeleniumHelper.FindElementByCssSelector(row, InstallationIpAddressInput4, findElementTimeout);
             
            ClearAndType(ipAddressInput1Element, "1");
            ipAddressInput1Element.SendKeys(Keys.Tab);

            ClearAndType(ipAddressInput2Element, "1");
            ipAddressInput2Element.SendKeys(Keys.Tab);

            ClearAndType(ipAddressInput3Element, "1");
            ipAddressInput3Element.SendKeys(Keys.Tab);

            ClearAndType(ipAddressInput4Element, "1");
            ipAddressInput4Element.SendKeys(Keys.Tab);
        }

        public string RetrieveInstallationPin(int findElementTimeout)
        {
            return SeleniumHelper.FindElementByCssSelector(InstallationPinCodeSelector, findElementTimeout).GetAttribute("value");
        }

        public void CloudInstallationRefresh(int retryCount, int findElementTimeout)
        {
            RetryRefreshClickingHelper(RefreshButtonSelector, CompleteButtonSelector, retryCount, findElementTimeout);
        }

        public void RetryRefreshClickingHelper(string element, string elementToVerify, int retryCount, int findElementTimeout)
        {
            var elementStatus = false;
            var retries = 0;

            while((!elementStatus) && (retries!=retryCount))
            {
                try
                {
                    var searchElement = SeleniumHelper.FindElementByCssSelector(element, findElementTimeout);
                    searchElement.Click();
                    elementStatus = SeleniumHelper.FindElementByCssSelector(elementToVerify, findElementTimeout).Displayed;
                    retries++;
                }
                catch (WebDriverException)
                {
                    retries++;
                }
            }
        }

        public void ConfirmInstallationComplete(int findElementTimeout)
        {
            var InstallationSuccessfullyFinishedElement = SeleniumHelper.FindElementByCssSelector(InstallationSuccessfullyFinishedSelector, findElementTimeout);
            ScrollTo(InstallationSuccessfullyFinishedElement);
            TestCheck.AssertIsEqual(true, InstallationSuccessfullyFinishedElement.Displayed,
                                        "Complete Installation message not displayed");
        }
        
        public void IsInstallerScreenDisplayed()
        {
            if (ContractReferencePageAlertElement == null)
                throw new Exception("Installer page is not displayed");
            AssertElementPresent(ContractReferencePageAlertElement, "Installer pager alert");

            MpsJobRunnerPage.RunResetSerialNumberJob(SerialNumberUsed());
        }

        public void EnterContractReference()
        {
            var contractRef = SpecFlow.GetContext("ProposalId");
            ClearAndType(ContractReferenceFieldElement, contractRef);
        }

        public void ProceedOnInstaller()
        {
            NextButtonElement.Click();
        }

        public void ResetInstallation()
        {
            ResetInstallationButtonElement.Click();
        }

        public InstallerDeviceInstallationPage ResetInstallationAndStartAgain()
        {
            ResetInstallationButtonElement.Click();
            return GetInstance<InstallerDeviceInstallationPage>();
        }

        public void IsInstallationPinCloudInstallationDisplayed()
        {
            if (Method() == "Email") return;
            var pin = PinAndAddressElement.Last().Text;
            var ePin = SpecFlow.GetContext("InstallationPin");
            var message = String.Format(
                    "The installation pin {0} dispalyed on installer page does not match the pin {1} saved earlier", pin,
                    ePin);
            TestCheck.AssertIsEqual(true, pin.Equals(ePin), message);
        }

        public void VerifyTimeZoneIsDisplayed(string method)
        {
            SpecFlow.SetContext("InstallationMethod", method);
            if (method != "Web") return;
            var option = SelectOption(TimeZoneOptionsElements);
            TestCheck.AssertIsEqual(true, option.Any(), "Time Zone does not contain any options");
        }

        private string GetConnectionStatus()
        {
            return CloudInstallationConnectionStatusElements.GetAttribute("data-original-title");
        }

        private string SerialNumberUsed()
        {
            string serial = null;

            if (IsUKSystem())
            {
                serial = SerialNumber;
            }
            else if (IsGermanSystem())
            {
                serial = SerialNumberBig;
            }
            else if (IsAustriaSystem())
            {
                serial = SerialNumberAut;

            } else if (IsFranceSystem())
            {
                serial = SerialNumberBfr;
            }
            else if (IsItalySystem())
            {
                serial = SerialNumberBit;
            }
            else if (IsSpainSystem())
            {
                serial = SerialNumberBes;
            }
            else if (IsIrelandSystem())
            {
                serial = SerialNumberBir;
            }
            else if (IsBelgiumSystem())
            {
                serial = SerialNumberBbe;
            }
            else if (IsPolandSystem())
            {
                serial = SerialNumberBpl;
            }
            else if (IsNetherlandSystem())
            {
                serial = SerialNumberBnl;
            }
            else if (IsSwedenSystem())
            {
                serial = SerialNumberBns;
            }
            else if (IsFinlandSystem())
            {
                serial = SerialNumberBnf;
            }
            else if (IsDenmarkSystem())
            {
                serial = SerialNumberBnd;
            }
            else if (IsNorwaySystem())
            {
                serial = SerialNumberBnn;
            }
            else if (IsSwissSystem())
            {
                serial = SerialNumberBsw;
            }

            SpecFlow.SetContext("SerialNumber", serial);

            return serial;
        }

        private string SwapSerialNumberUsed()
        {
            string serial = null;

            if (IsUKSystem())
            {
                serial = SwapSerialNumberUk;
            }
            else if (IsGermanSystem())
            {
                serial = SwapSerialNumberDe;
            }
            else if (IsAustriaSystem())
            {
                serial = SwapSerialNumberAt;
            }
            else if (IsFranceSystem())
            {
                serial = SwapSerialNumberFr;
            }
            else if (IsItalySystem())
            {
                serial = SwapSerialNumberIt;
            }
            else if (IsSpainSystem())
            {
                serial = SwapSerialNumberEs;
            }
            if (IsIrelandSystem())
            {
                serial = SwapSerialNumberIr;
            }
            else if (IsPolandSystem())
            {
                serial = SwapSerialNumberPl;
            }
            else if (IsBelgiumSystem())
            {
                serial = SwapSerialNumberBe;
            }
            else if (IsSwedenSystem())
            {
                serial = SwapSerialNumberNs;
            }
            else if (IsNetherlandSystem())
            {
                serial = SwapSerialNumberNl;
            }
            else if (IsSwissSystem())
            {
                serial = SwapSerialNumberSw;
            }


            SpecFlow.SetContext("SwapSerialNumber", serial);

            return serial;
        }


        private string UsedSerialNumber()
        {
            string serial = null;

            if (IsUKSystem())
            {
                serial = ExistingSerialNumber;
            }
            else if (IsGermanSystem())
            {
                serial = ExistingSerialNumberBig;
            }
            else if (IsAustriaSystem())
            {
                serial = ExistingSerialNumberAut;
            }
            else if (IsFranceSystem())
            {
                serial = SerialNumberBfr;
            }
            else if (IsItalySystem())
            {
                serial = SerialNumberBit;
            }
            else if (IsSpainSystem())
            {
                serial = SerialNumberBes;
            }
            else if (IsIrelandSystem())
            {
                serial = SerialNumberBir;
            }
            else if (IsBelgiumSystem())
            {
                serial = SerialNumberBbe;
            }
            else if (IsPolandSystem())
            {
                serial = SerialNumberBpl;
            }
            else if (IsNetherlandSystem())
            {
                serial = SerialNumberBnl;
            }
            else if (IsSwedenSystem())
            {
                serial = SerialNumberBns;
            }
            else if (IsFinlandSystem())
            {
                serial = SerialNumberBnf;
            }
            else if (IsDenmarkSystem())
            {
                serial = SerialNumberBnd;
            }
            else if (IsNorwaySystem())
            {
                serial = SerialNumberBnn;
            }
            else if (IsSwissSystem())
            {
                serial = SerialNumberBsw;
            }
            SpecFlow.SetContext("UsedSerialNumber", serial);

            return serial;
        }

        private void CreateNewSerialNumber()
        {
            var serial = GetSavedUsedSerialNumber();

            serial = "U63783" + serial;

            SpecFlow.SetContext("JoinedSerialNumber", serial);
            MsgOutput(String.Format("New serial number is created as {0}", serial));
        }

        private void CreateNewSerialNumber(string serialNumber)
        {
            var serial = "U63783" + serialNumber;

            SpecFlow.SetContext("JoinedSerialNumber", serial);
            MsgOutput(String.Format("New serial number is created as {0}", serial));
        }

        private void CreateNewSwapSerialNumber()
        {
            var serial = GetSavedSwapSerialNumber();

            serial = "U63783" + serial;

            SpecFlow.SetContext("JoinedSerialNumber", serial);
            MsgOutput(String.Format("New swap serial number is created as {0}", serial));
        }

        private string GetSavedUsedSerialNumber()
        {
            return SpecFlow.GetContext("UsedSerialNumber");
        }

        private string GetSavedSwapSerialNumber()
        {
            SwapSerialNumberUsed();

            return SpecFlow.GetContext("SwapSerialNumber");
        }

        public void CloudInstallationProcess()
        {
            if (Method() == "Email") return;
            CreateNewSerialNumber();
            MpsJobRunnerPage.CreateNewVirtualDevice();
            WebDriver.Wait(DurationType.Second, 2);
            MpsJobRunnerPage.RegisterNewDevice();
            WebDriver.Wait(DurationType.Second, 2);
            MpsJobRunnerPage.ChangeDeviceStatus();
            WebDriver.Wait(DurationType.Second, 2);
            MpsJobRunnerPage.SetSupplyStatusForNewPrinter();
            WebDriver.Wait(DurationType.Second, 2);
            MpsJobRunnerPage.NotifyBocOfNewChanges();
            WebDriver.Wait(DurationType.Second, 2);
        }

        public void CloudInstallationProcess(string serial, string device)
        {
            if (Method() == "Email") return;
            CreateNewSerialNumber(serial);
            MpsJobRunnerPage.CreateNewVirtualDevice(device);
            WebDriver.Wait(DurationType.Second, 2);
            MpsJobRunnerPage.RegisterNewDevice();
            WebDriver.Wait(DurationType.Second, 2);
            MpsJobRunnerPage.ChangeDeviceStatus();
            WebDriver.Wait(DurationType.Second, 2);
            MpsJobRunnerPage.SetSupplyStatusForNewPrinter();
            WebDriver.Wait(DurationType.Second, 2);
            MpsJobRunnerPage.NotifyBocOfNewChanges();
            WebDriver.Wait(DurationType.Second, 2);
        }

        public void CloudInstallationProcess(string serial, string device, string number)
        {
            if (Method() == "Email") return;
            CreateNewSerialNumber(serial);
            MpsJobRunnerPage.CreateNewVirtualDevice(device, number);
            WebDriver.Wait(DurationType.Second, 2);
            MpsJobRunnerPage.RegisterNewDevice(number);
            WebDriver.Wait(DurationType.Second, 2);
            MpsJobRunnerPage.ChangeDeviceStatus(number);
            WebDriver.Wait(DurationType.Second, 2);
            MpsJobRunnerPage.SetSupplyStatusForNewPrinter(number);
            WebDriver.Wait(DurationType.Second, 2);
            MpsJobRunnerPage.NotifyBocOfNewChanges(number);
            WebDriver.Wait(DurationType.Second, 2);
        }

        public void SwapCloudInstallationProcess()
        {
            if (Method() == "Email") return;
            CreateNewSwapSerialNumber();
            MpsJobRunnerPage.CreateNewVirtualDevice();
            WebDriver.Wait(DurationType.Second, 2);
            MpsJobRunnerPage.RegisterNewDevice();
            WebDriver.Wait(DurationType.Second, 2);
            MpsJobRunnerPage.ChangeDeviceStatus();
            WebDriver.Wait(DurationType.Second, 2);
            MpsJobRunnerPage.SetSupplyStatusForNewPrinter();
            WebDriver.Wait(DurationType.Second, 2);
            MpsJobRunnerPage.NotifyBocOfNewChanges();
            WebDriver.Wait(DurationType.Second, 2);
        }
        

        public void EnterSerialNumber()
        {
            ClosePopUpModal();

            WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0, 0, 0, 15));
            var wait = new DefaultWait<IWebDriver>(TestController.CurrentDriver)
            {
                Timeout = new TimeSpan(0, 0, 0, 5)
            };
            var methodName = MethodBase.GetCurrentMethod();

            var retries = 0;
            var elementStatus = false;

            while ((!elementStatus) && (retries != 3))
            {
                try
                {
                    MsgOutput(String.Format("Retry count = [{0}]", retries));
                    
                    MpsJobRunnerPage.RunResetSerialNumberJob(SerialNumberUsed());

                    ClearAndType(SerialNumberFieldElement, SerialNumberUsed());

                    SerialNumberFieldElement.SendKeys(Keys.Tab);

                    WebDriver.Wait(DurationType.Second, 5);
                    

                    wait.Message = String.Format("{0}:: Timeout of [{1}] seconds trying to locate element {2}", methodName, wait.Timeout, 
                                                            InstallationSerialNumberCheckSuccessIconElement);
                    elementStatus = InstallationSerialNumberCheckSuccessIconElement.Displayed;

                    MsgOutput(String.Format("Element Status = [{0}]", elementStatus));
                    MsgOutput(String.Format("Timeout waited = [{0}]", wait.Timeout.TotalSeconds));
                    retries++;

                }
                catch (StaleElementReferenceException stale)
                {
                    MsgOutput(String.Format("Serial number check failed. Retrying [{0}] times", retries));
                    MsgOutput(String.Format("Exception was [{0}]", stale));

                    elementStatus = false;
                    retries++;
                    WebDriver.Wait(DurationType.Second, 5);
                }
                catch (WebDriverException timeoutException)
                {
                    MsgOutput(String.Format("Serial number check failed. Retrying [{0}] times", retries));

                    MsgOutput(String.Format("Exception was [{0}]", timeoutException));

                    elementStatus = false;
                    retries++;
                    WebDriver.Wait(DurationType.Second, 5);
                }
                
            }
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);

        }

        public void EnterSerialNumber(string serialNumber, string serialNumber1, string serialNumber2, string serialNumber3)
        {
            ClosePopUpModal();

            WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0, 0, 0, 15));

            String[] serialNumberContainer = 
                                        {
                                            serialNumber, 
                                            serialNumber1, 
                                            serialNumber2, 
                                            serialNumber3
                                        };

            for(var i = 0; i < SerialNumbersElement.Count; i++)
            {
                
                var wait = new DefaultWait<IWebDriver>(TestController.CurrentDriver)
                {
                    Timeout = new TimeSpan(0, 0, 0, 5)
                };
                var methodName = MethodBase.GetCurrentMethod();

                var retries = 0;
                var elementStatus = false;

                while ((!elementStatus) && (retries != 3))
                {
                    try
                    {
                        MpsJobRunnerPage.RunResetSerialNumberJob(serialNumberContainer[i]);

                        ClearAndType(SerialNumbersElement.ElementAt(i), serialNumberContainer[i]);

                        SerialNumbersElement.ElementAt(i).SendKeys(Keys.Tab);

                        WebDriver.Wait(DurationType.Second, 5);


                        wait.Message = String.Format("{0}:: Timeout of [{1}] seconds trying to locate element {2}", methodName, wait.Timeout,
                                                                InstallationSerialNumberCheckSuccessIconElements.ElementAt(i));
                        elementStatus = InstallationSerialNumberCheckSuccessIconElements.ElementAt(i).Displayed;

                        MsgOutput(String.Format("Element Status = [{0}]", elementStatus));
                        MsgOutput(String.Format("Timeout waited = [{0}]", wait.Timeout.TotalSeconds));
                        retries++;

                    }
                    catch (StaleElementReferenceException stale)
                    {
                        MsgOutput(String.Format("Serial number check failed. Retrying [{0}] times", retries));
                        MsgOutput(String.Format("Exception was [{0}]", stale));

                        elementStatus = false;
                        retries++;
                        WebDriver.Wait(DurationType.Second, 5);
                    }
                    catch (WebDriverException timeoutException)
                    {
                        MsgOutput(String.Format("Serial number check failed. Retrying [{0}] times", retries));

                        MsgOutput(String.Format("Exception was [{0}]", timeoutException));

                        elementStatus = false;
                        retries++;
                        WebDriver.Wait(DurationType.Second, 5);
                    }
                    catch (TargetInvocationException timeoutException)
                    {
                        MsgOutput(String.Format("Serial number check failed. Retrying [{0}] times", retries));

                        MsgOutput(String.Format("Exception was [{0}]", timeoutException));

                        elementStatus = false;
                        retries++;
                        WebDriver.Wait(DurationType.Second, 5);
                    }

                }
                
            }

            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);
        }

       
        public void EnterSingleSerialNumber(string serialNumber)
        {
            ClosePopUpModal();


            WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0, 0, 0, 15));
            var wait = new DefaultWait<IWebDriver>(TestController.CurrentDriver)
            {
                Timeout = new TimeSpan(0, 0, 0, 5)
            };
            var methodName = MethodBase.GetCurrentMethod();

            var retries = 0;
            var elementStatus = false;

            while ((!elementStatus) && (retries != 3))
            {
                try
                {
                    MpsJobRunnerPage.RunResetSerialNumberJob(serialNumber);

                    ClearAndType(SerialNumberFieldElement, serialNumber);

                    SerialNumberFieldElement.SendKeys(Keys.Tab);

                    WebDriver.Wait(DurationType.Second, 5);


                    wait.Message = String.Format("{0}:: Timeout of [{1}] seconds trying to locate element {2}", methodName, wait.Timeout,
                                                            InstallationSerialNumberCheckSuccessIconElement);
                    elementStatus = InstallationSerialNumberCheckSuccessIconElement.Displayed;

                    MsgOutput(String.Format("Element Status = [{0}]", elementStatus));
                    MsgOutput(String.Format("Timeout waited = [{0}]", wait.Timeout.TotalSeconds));
                    retries++;

                }
                catch (StaleElementReferenceException stale)
                {
                    MsgOutput(String.Format("Serial number check failed. Retrying [{0}] times", retries));
                    MsgOutput(String.Format("Exception was [{0}]", stale));

                    elementStatus = false;
                    retries++;
                    WebDriver.Wait(DurationType.Second, 5);
                }
                catch (WebDriverException timeoutException)
                {
                    MsgOutput(String.Format("Serial number check failed. Retrying [{0}] times", retries));

                    MsgOutput(String.Format("Exception was [{0}]", timeoutException));

                    elementStatus = false;
                    retries++;
                    WebDriver.Wait(DurationType.Second, 5);
                }

            }
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);

           


        }

        public void EnterReinstallSerialNumber()
        {
            try
            {
                ClosePopUpModal();
            }
            catch (WebDriverTimeoutException)
            {
                // Do nothing
            }
            

            WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0, 0, 0, 15));
            var wait = new DefaultWait<IWebDriver>(TestController.CurrentDriver)
            {
                Timeout = new TimeSpan(0, 0, 0, 5)
            };
            var methodName = MethodBase.GetCurrentMethod();

            var retries = 0;
            var elementStatus = false;

            while ((!elementStatus) && (retries != 3))
            {
                try
                {
                    //MpsJobRunnerPage.RunResetSerialNumberJob(SwapSerialNumberUsed());

                    ClearAndType(SerialNumberFieldElement, SwapSerialNumberUsed());

                    SerialNumberFieldElement.SendKeys(Keys.Tab);

                    WebDriver.Wait(DurationType.Second, 5);


                    wait.Message = String.Format("{0}:: Timeout of [{1}] seconds trying to locate element {2}", methodName, wait.Timeout,
                                                            InstallationSerialNumberCheckSuccessIconElement);
                    elementStatus = InstallationSerialNumberCheckSuccessIconElement.Displayed;

                    MsgOutput(String.Format("Element Status = [{0}]", elementStatus));
                    MsgOutput(String.Format("Timeout waited = [{0}]", wait.Timeout.TotalSeconds));
                    retries++;

                }
                catch (StaleElementReferenceException stale)
                {
                    MsgOutput(String.Format("Serial number check failed. Retrying [{0}] times", retries));
                    MsgOutput(String.Format("Exception was [{0}]", stale));

                    elementStatus = false;
                    retries++;
                    WebDriver.Wait(DurationType.Second, 5);
                }
                catch (WebDriverException timeoutException)
                {
                    MsgOutput(String.Format("Serial number check failed. Retrying [{0}] times", retries));

                    MsgOutput(String.Format("Exception was [{0}]", timeoutException));

                    elementStatus = false;
                    retries++;
                    WebDriver.Wait(DurationType.Second, 5);
                }

            }
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);



        }

        public void EnterSwapSerialNumber()
        {
            ClosePopUpModal();

            WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0, 0, 0, 15));
            var wait = new DefaultWait<IWebDriver>(TestController.CurrentDriver)
            {
                Timeout = new TimeSpan(0, 0, 0, 5)
            };
            var methodName = MethodBase.GetCurrentMethod();

            var retries = 0;
            var elementStatus = false;

            while ((!elementStatus) && (retries != 3))
            {
                try
                {
                    MpsJobRunnerPage.RunResetSerialNumberJob(SwapSerialNumberUsed());

                    ClearAndType(SerialNumberFieldElement, SwapSerialNumberUsed());

                    SerialNumberFieldElement.SendKeys(Keys.Tab);

                    WebDriver.Wait(DurationType.Second, 5);


                    wait.Message = String.Format("{0}:: Timeout of [{1}] seconds trying to locate element {2}",
                        methodName, wait.Timeout,
                        InstallationSerialNumberCheckSuccessIconElement);
                    elementStatus = InstallationSerialNumberCheckSuccessIconElement.Displayed;

                    MsgOutput(String.Format("Element Status = [{0}]", elementStatus));
                    MsgOutput(String.Format("Timeout waited = [{0}]", wait.Timeout.TotalSeconds));
                    retries++;

                }
                catch (StaleElementReferenceException stale)
                {
                    MsgOutput(String.Format("Serial number check failed. Retrying [{0}] times", retries));
                    MsgOutput(String.Format("Exception was [{0}]", stale));

                    elementStatus = false;
                    retries++;
                    WebDriver.Wait(DurationType.Second, 5);
                }
                catch (WebDriverException timeoutException)
                {
                    MsgOutput(String.Format("Serial number check failed. Retrying [{0}] times", retries));

                    MsgOutput(String.Format("Exception was [{0}]", timeoutException));

                    elementStatus = false;
                    retries++;
                    WebDriver.Wait(DurationType.Second, 5);
                }
                

            }
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);



        }

        public void EnterExistingSerialNumber()
        {
            ClosePopUpModal();

            WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0, 0, 0, 15));
            var wait = new DefaultWait<IWebDriver>(TestController.CurrentDriver)
            {
                Timeout = new TimeSpan(0, 0, 0, 5)
            };
            var methodName = MethodBase.GetCurrentMethod();

            var retries = 0;
            var elementStatus = false;

            while ((!elementStatus) && (retries != 3))
            {
                try
                {
                    MpsJobRunnerPage.RunResetSerialNumberJob(UsedSerialNumber());

                    ClearAndType(SerialNumberFieldElement, UsedSerialNumber());

                    SerialNumberFieldElement.SendKeys(Keys.Tab);

                    WebDriver.Wait(DurationType.Second, 5);


                    wait.Message = String.Format("{0}:: Timeout of [{1}] seconds trying to locate element {2}", methodName, wait.Timeout,
                                                            InstallationSerialNumberCheckSuccessIconElement);
                    elementStatus = InstallationSerialNumberCheckSuccessIconElement.Displayed;

                    MsgOutput(String.Format("Element Status = [{0}]", elementStatus));
                    MsgOutput(String.Format("Timeout waited = [{0}]", wait.Timeout.TotalSeconds));
                    retries++;

                }
                catch (StaleElementReferenceException stale)
                {
                    MsgOutput(String.Format("Serial number check failed. Retrying [{0}] times", retries));
                    MsgOutput(String.Format("Exception was [{0}]", stale));

                    elementStatus = false;
                    retries++;
                    WebDriver.Wait(DurationType.Second, 5);
                }
                catch (WebDriverException timeoutException)
                {
                    MsgOutput(String.Format("Serial number check failed. Retrying [{0}] times", retries));

                    MsgOutput(String.Format("Exception was [{0}]", timeoutException));

                    elementStatus = false;
                    retries++;
                    WebDriver.Wait(DurationType.Second, 5);
                }

            }
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);
        }


        private string Method()
        {
            return SpecFlow.GetContext("InstallationMethod");
        }

        private void ClosePopUpModal()
        {
            try
            {
                SerialNumberFieldElement.Click();

                WaitForElementToExistById("WhereIsMySerialNumberModal", 5);

                if (WhereIsMyDevicePopUpElements != null)
                    WhereIsMyDevicePopUpElements.Click();
            }
            catch (WebDriverTimeoutException )
            {
                //move on   
            
            }
            
        }


        public void IsSwapOldFieldMonoDisplayed()
        {
            if(SwapOldMonoElement == null)
                throw new Exception("Old Mono field is not null");

            TestCheck.AssertIsEqual(true, SwapOldMonoElement.Displayed, "Old Mono field is not displayed");
        }

        public void IsSwapOldFieldColourDisplayed()
        {
            if (SwapOldColourElement == null)
                throw new Exception("Old Colour field is not null");

            TestCheck.AssertIsEqual(true, SwapOldColourElement.Displayed, "Old Colour field is not displayed");
        }

        public void IsSwapNewFieldMonoEmpty()
        {
            if (SwapNewMonoElement == null)
                throw new Exception("new Mono field is not null");

            TestCheck.AssertIsEqual(true, SwapNewMonoElement.GetAttribute("value").Equals("0"), "new Mono field is not displayed");
        }

        public void IsSwapNewFieldColourEmpty()
        {
            if (SwapNewColourElement == null)
                throw new Exception("new Colour field is not null");

            TestCheck.AssertIsEqual(true, SwapNewColourElement.GetAttribute("value").Equals("0"), "new Colour field is not displayed");
        }


        public void EnterNewMonoSwapCount(string mono)
        {
            if (SwapNewMonoElement == null)
                throw new Exception("new Mono field is not null");

            ClearAndType(SwapNewMonoElement, mono);
        }

        public void EnterNewColourSwapCount(string colour)
        {
            if (SwapNewColourElement == null)
                throw new Exception("new Mono field is not null");

            ClearAndType(SwapNewColourElement, colour);
        }

        public void EnterIpAddress()
        {

            WaitForElementToBeClickableByCssSelector(".js-mps-ip-d", 3, 10);

            WebDriver.Wait(DurationType.Second, 3);

            if (Method() == "BOR") return;
            foreach (var ipAddressElement in IpAddressElements)
            {
                ipAddressElement.Click();
                try
                {
                    ClearAndType(ipAddressElement, "1");
                    ipAddressElement.SendKeys(Keys.Tab);
                }
                catch (InvalidElementStateException iese)
                {
                    MsgOutput(String.Format(".....retrying ip address input due error {0}", iese));
                    WebDriver.Wait(DurationType.Second, 3);
                    ClearAndType(ipAddressElement, "1");
                    ipAddressElement.SendKeys(Keys.Tab);
                }

            }
        }

        
        public void ConnectDevice()
        {

            try
            {
                switch (Method())
                {
                    case "Email":
                    case "":
                    case " ":
                        ConnectByEmail();
                        break;
                    case "BOR":
                        CloudInstallationProcess();
                        RefreshCloudInstallation();
                        break;
                    case "Web":
                        GetWebInstallationPin();
                        WebInstallConnect.Click();
                        WebDriver.Wait(DurationType.Second, 1);
                        ReturnToOriginWindow();
                        CloudInstallationProcess();
                        //WebDriver.Wait(DurationType.Second, 5);
                        //RefreshCloudInstallationElement.Click();
                        RefreshCloudInstallation();
                        break;
                }

            }
            catch (Exception exception)
            {
                throw new Exception(String.Format("Connect or Refresh button is not displayed because {0}", exception));
            }
            
        }

        public void ConnectByEmail()
        {
            if (ConnectButtonsElement.Count > 1)
            {
                foreach (var connectButton in ConnectButtonsElement)
                {
                    connectButton.Click();
                    WebDriver.Wait(DurationType.Second, 3);
                    ReturnToOriginWindow();
                    WebDriver.Wait(DurationType.Second, 2);
                }
            }
            else if (ConnectButtonsElement.Count == 1)
            {
                ConnectButtonElement.Click();
                WebDriver.Wait(DurationType.Second, 5);
                ReturnToOriginWindow();
            }
        }

        public void ConnectDeviceWithBor(string device, string serial)
        {
            try
            {
                CloudInstallationProcess(serial, device);
            }
            catch (Exception exception)
            {
                throw new Exception(String.Format("Connect or Refresh button is not displayed because {0}", exception));
            }
        }

        public void ConnectDeviceWithBor(string device, string serial, string number)
        {
            try
            {
                CloudInstallationProcess(serial, device, number);
            }
            catch (Exception exception)
            {
                throw new Exception(String.Format("Connect or Refresh button is not displayed because {0}", exception));
            }
        }

       
        public void ConnectSwapDevice()
        {
            try
            {
                switch (Method())
                {
                    case "Email":
                        ConnectButtonElement.Click();
                        WebDriver.Wait(DurationType.Second, 5);
                        ReturnToOriginWindow();
                        break;
                    case "BOR":
                        SwapCloudInstallationProcess();
                        //WebDriver.Wait(DurationType.Second, 5);
                        //RefreshCloudInstallationElement.Click();
                        RefreshCloudInstallation();
                        break;
                    case "Web":
                        GetWebInstallationPin();
                        WebInstallConnect.Click();
                        WebDriver.Wait(DurationType.Second, 1);
                        ReturnToOriginWindow();
                        SwapCloudInstallationProcess();
                       // WebDriver.Wait(DurationType.Second, 5);
                        //RefreshCloudInstallationElement.Click();
                        RefreshCloudInstallation();
                        break;
                }

            }
            catch (Exception exception)
            {
                throw new Exception(String.Format("Connect or Refresh button is not displayed because {0}", exception));
            }

        }

        public void RefreshCloudInstallation()
        {
            RetryClickingAction("#content_0_ButtonRefresh", "#content_0_DeviceInstallList_List_CellConnectionStatus_0 .glyphicon-ok", 15, 20);
        }

        public void RefreshCloudInstallationBeforeClickingOnCompleteInstallation()
        {
            RetryClickingAction("#content_0_ButtonRefresh", "#content_0_ButtonCompleteCloudInstallation", 30, 30);
        }

        public void RefreshCloudMultipleInstallation()
        {
            RetryMulyipleCloudAssertion("#content_0_ButtonRefresh", "[id*=\"content_0_DeviceInstallList_List_CellConnectionStatus_\"] .glyphicon-ok", 15, 30);
        }

       

        private void GetWebInstallationPin()
        {
            var webInstalPin = CloudInstallationWebInstallPinElements.GetAttribute("value");
            SpecFlow.SetContext("InstallationPin", webInstalPin);
        }

        public void CompleteDeviceConnection()
        {
            try
            {
                if (Method() == "Email")
                {
                    CompleteInstallationElement.Click();
                    MpsJobRunnerPage.RunRefreshPrintCountsFromEmailCommandJob(Locale);
                }
                else
                {
                    CompleteInstallationElement.Click();
                }
                
                WebDriver.Wait(DurationType.Second, 2);
            }
            catch (Exception)
            {
                throw new Exception("Complete Installation Button is not displayed");
            }
        }




        public void ModifyXmlAndSend(string model, string serial, string totalPrint, string colourPrint, string monoPrint, string emailAddress, string subject)
        {
            WebDriver.Wait(DurationType.Second, 10);
            if (Method() == "Email")
            {
                ActionsModule.ModifyXmlValues(model, serial, totalPrint, colourPrint, monoPrint);
                WebDriver.Wait(DurationType.Second, 10);
                ActionsModule.SendXml(emailAddress, subject);
            }
        }

        public void ConfirmInstallationSucceed()
        {
            if (Method() == "Email" || String.IsNullOrWhiteSpace(Method()))
            {
                TestCheck.AssertIsEqual(true, CompleteInstallationComfirmationElement.Displayed,
                "Installation not successful");
               // WaitForElementToBeClickableById("content_0_InstallationSuccessfullyFinished", 10);
                MpsJobRunnerPage.RunRefreshPrintCountsFromEmailCommandJob(Locale);
    //            CompleteInstallationComfirmationElement.Click();

            }
            else
            {
                //TestCheck.AssertIsEqual(true, CompleteCloudInstallationComfirmationElement.Displayed,
                //"Installation not successful");
                TestCheck.AssertIsEqual(true, CloudInstallationConnectionStatusIconElements.Displayed, "Device is not connect");
                //WaitForElementToBeClickableById("content_0_InstallationSuccessfullyFinished", 10);
//                CompleteCloudInstallationComfirmationElement.Click();
                MpsJobRunnerPage.NotifyBocOfNewChanges();
            }

            MpsJobRunnerPage.RunCompleteInstallationCommandJob(MpsUtil.CreatedProposal());
           
        }

        public void ConfirmInstallationSucceed(string number1, string number2, string number3, string number4)
        {
            if (Method() == "Email")
            {
                TestCheck.AssertIsEqual(true, CompleteInstallationComfirmationElement.Displayed,
                "Installation not successful");
                MpsJobRunnerPage.RunRefreshPrintCountsFromEmailCommandJob(Locale);
                // WaitForElementToBeClickableById("content_0_InstallationSuccessfullyFinished", 10);
                CompleteInstallationComfirmationElement.Click();

            }
            else
            {
                //TestCheck.AssertIsEqual(true, CompleteCloudInstallationComfirmationElement.Displayed,
                //"Installation not successful");
                TestCheck.AssertIsEqual(true, CloudInstallationConnectionStatusIconElements.Displayed, "Device is not connect");
                //WaitForElementToBeClickableById("content_0_InstallationSuccessfullyFinished", 10);
               // CompleteCloudInstallationComfirmationElement.Click();
                MpsJobRunnerPage.NotifyBocOfNewChanges(number1);
                MpsJobRunnerPage.NotifyBocOfNewChanges(number2);
                MpsJobRunnerPage.NotifyBocOfNewChanges(number3);
                MpsJobRunnerPage.NotifyBocOfNewChanges(number4);
            }

            MpsJobRunnerPage.RunCompleteInstallationCommandJob(MpsUtil.CreatedProposal());

        }

        public void ConfirmMultipleInstallationSucceed()
        {
                TestCheck.AssertIsEqual(true, CompleteCloudInstallationComfirmationElement.Displayed,
                "Installation not successful");
                TestCheck.AssertIsEqual(true, CloudInstallationConnectionStatusIconElements.Displayed, "Device is not connect");
                //WaitForElementToBeClickableById("content_0_InstallationSuccessfullyFinished", 10);
                CompleteCloudInstallationComfirmationElement.Click();
                MpsJobRunnerPage.NotifyBocOfNewChanges();
                MpsJobRunnerPage.RunCompleteInstallationCommandJob(MpsUtil.CreatedProposal());

        }

        public void IsInstallationReset()
        {
            //var serial = SerialNumberFieldElement.GetAttribute("value");
            //var emptySerial = String.IsNullOrWhiteSpace(serial);

            var connection = CloudInstallationNoConnectionStatusIconElements.Displayed;

            TestCheck.AssertIsEqual(true, connection, "Installation is not reset");
        }

        public void ConfirmCompleteMessageIsDisplayed()
        {
            TestCheck.AssertIsEqual(true, InstallationConfirmationMessageElement.Displayed, 
                                        "Complete Installation message not displayed");
        }

        public DealerContractsAcceptedPage _ReturnBackToContractAcceptedPage()
        {
            var currentUrl = Driver.Url;
            //var firstPart = currentUrl.Substring(0, 31);
            var firstPart = SetBrotherOnlineBaseUrl();
            var newUrl = firstPart + "/mps/dealer/contracts/accepted";
            Driver.Navigate().GoToUrl(newUrl);

            return GetInstance<DealerContractsAcceptedPage>();
        }
    }
}
