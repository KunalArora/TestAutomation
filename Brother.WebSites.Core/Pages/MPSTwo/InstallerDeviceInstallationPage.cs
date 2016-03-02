﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class InstallerDeviceInstallationPage : BasePage
    {
        public static string Url = "/";

        private const string serialNumber = @"A1T010001";
        private const string serialNumberBIG = @"A1T010002";
        private const string serialNumberAUT = @"A1T010003";
        private const string existingSerialNumber = @"A1T010004";
        private const string existingSerialNumberBIG = @"A1T010005";
        private const string existingSerialNumberAUT = @"A1T010006";
        private const string serialNumberBFR = @"A1T010007";
        private const string serialNumberBIT = @"A1T010008";
        private const string serialNumberBES = @"A1T010009";

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

        [FindsBy(How = How.CssSelector, Using = "[class*=\"js-mps-ip-\"]")] 
        public IList<IWebElement> IpAddressElements;

        [FindsBy(How = How.CssSelector, Using = "p.form-control-static")] 
        public IList<IWebElement> InstalledPinElements;

        [FindsBy(How = How.CssSelector, Using = "#content_0_DeviceInstallList_List_ButtonConnectDevice_0")] 
        public IWebElement WebInstallConnect;

        [FindsBy(How = How.CssSelector, Using = "[class*=\"js-mps-connect-device-to-\"]")] 
        public IWebElement ConnectButtonElement;

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
        public IWebElement RefreshCloudInstallationElements;

        [FindsBy(How = How.CssSelector, Using = "#content_0_DeviceInstallList_List_CellConnectionStatusIcon_0")] 
        public IWebElement CloudInstallationConnectionStatusElements;

        [FindsBy(How = How.CssSelector, Using = "#content_0_DeviceInstallList_List_CellConnectionStatus_0[class=\" green\"]")] 
        public IWebElement CloudInstallationConnectionStatusIconElements;

        

        

        


        public void IsInstallerScreenDisplayed()
        {
            if (ContractReferencePageAlertElement == null)
                throw new Exception("Installer page is not displayed");
            AssertElementPresent(ContractReferencePageAlertElement, "Installer pager alert");

            MPSJobRunnerPage.RunResetSerialNumberJob(SerialNumberUsed());
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
                serial = serialNumber;
            }
            else if (IsGermanSystem())
            {
                serial = serialNumberBIG;
            }
            else if (IsAustriaSystem())
            {
                serial = serialNumberAUT;

            } else if (IsFranceSystem())
            {
                serial = serialNumberBFR;
            }
            else if (IsItalySystem())
            {
                serial = serialNumberBIT;
            }

            SpecFlow.SetContext("SerialNumber", serial);

            return serial;
        }


        private string UsedSerialNumber()
        {
            string serial = null;

            if (IsUKSystem())
            {
                serial = existingSerialNumber;
            }
            else if (IsGermanSystem())
            {
                serial = existingSerialNumberBIG;
            }
            else if (IsAustriaSystem())
            {
                serial = existingSerialNumberAUT;
            }

            SpecFlow.SetContext("UsedSerialNumber", serial);

            return serial;
        }

        private void CreateNewSerialNumber()
        {
            var serial = GetSavedUsedSerialNumber();

            serial = "U63783" + serial;

            SpecFlow.SetContext("JoinedSerialNumber", serial);
        }

        private string GetSavedUsedSerialNumber()
        {
            return SpecFlow.GetContext("UsedSerialNumber");
        }

        public void CloudInstallationProcess()
        {
            if (Method() == "Email") return;
            CreateNewSerialNumber();
            MPSJobRunnerPage.CreateNewVirtualDevice();
            WebDriver.Wait(DurationType.Second, 2);
            MPSJobRunnerPage.RegisterNewDevice();
            WebDriver.Wait(DurationType.Second, 2);
            MPSJobRunnerPage.ChangeDeviceStatus();
            WebDriver.Wait(DurationType.Second, 2);
            MPSJobRunnerPage.SetSupplyStatusForNewPrinter();
            WebDriver.Wait(DurationType.Second, 2);
            MPSJobRunnerPage.NotifyBocOfNewChanges();
            WebDriver.Wait(DurationType.Second, 2);
        }
        

        public void EnterSerialNumber()
        {
            MPSJobRunnerPage.RunResetSerialNumberJob(SerialNumberUsed());

            WebDriver.Wait(DurationType.Second, 2);

            ClearAndType(SerialNumberFieldElement, SerialNumberUsed());
           
            SerialNumberFieldElement.SendKeys(Keys.Tab);

            WebDriver.Wait(DurationType.Second, 2);
        }

        public void EnterExistingSerialNumber()
        {
            MPSJobRunnerPage.RunResetSerialNumberJob(UsedSerialNumber());

            WebDriver.Wait(DurationType.Second, 2);

            ClearAndType(SerialNumberFieldElement, UsedSerialNumber());

            SerialNumberFieldElement.SendKeys(Keys.Tab);

            WebDriver.Wait(DurationType.Second, 2);
        }


        private string Method()
        {
            return SpecFlow.GetContext("InstallationMethod");
        }

        public void EnterIpAddress()
        {
            if (Method() == "BOR") return;
            foreach (var ipAddressElement in IpAddressElements)
            {
                ipAddressElement.Click();
                ClearAndType(ipAddressElement, "1");
                ipAddressElement.SendKeys(Keys.Tab);
                WebDriver.Wait(DurationType.Second, 1);
            }
        }

        public void ConnectDevice()
        {
            try
            {
                if (Method() == "Email")
                {
                    ConnectButtonElement.Click();
                    WebDriver.Wait(DurationType.Second, 5);
                    ReturnToOriginWindow();
                }
                else if (Method() == "BOR")
                {
                    CloudInstallationProcess();
                    WebDriver.Wait(DurationType.Second, 5);
                    RefreshCloudInstallationElements.Click();
                }
                else if (Method() == "Web")
                {
                    OpenLinkInADifferentWindow(WebInstallConnect);
                    WebDriver.Wait(DurationType.Second, 3);
                    ReturnToOriginWindow();
                    GetInstallationFromUrl();
                    WebDriver.Wait(DurationType.Second, 3);
                    CloudInstallationProcess();
                    WebDriver.Wait(DurationType.Second, 5);
                    RefreshCloudInstallationElements.Click();
                }

            }
            catch (Exception exception)
            {
                throw new Exception(String.Format("Connect or Refresh button is not displayed because {0}", exception));
            }
            
        }

        private void GetInstallationFromUrl()
        {
            var webInstallUrl = SpecFlow.GetContext("WebInstallUrl");
            var installationPin = webInstallUrl.Substring(36, 30);
            SpecFlow.SetContext("InstallationPin", installationPin);
        }

        public void CompleteDeviceConnection()
        {
            try
            {
                if (Method() != "Email") return;
                CompleteInstallationElement.Click();
                WebDriver.Wait(DurationType.Second, 2);
            }
            catch (Exception)
            {
                throw new Exception("Complete Installation Button is not displayed");
            }
        }

        public void ConfirmInstallationSucceed()
        {
            if (Method() == "Email")
            {
                TestCheck.AssertIsEqual(true, CompleteInstallationComfirmationElement.Displayed,
                "Installation not successful");
                WebDriver.Wait(DurationType.Second, 3);
                CompleteInstallationComfirmationElement.Click();
            }
            else
            {
                TestCheck.AssertIsEqual(true, CompleteCloudInstallationComfirmationElement.Displayed,
                "Installation not successful");
                TestCheck.AssertIsEqual(true, CloudInstallationConnectionStatusIconElements.Displayed, "Device is not connect");
                WebDriver.Wait(DurationType.Second, 3);
                CompleteCloudInstallationComfirmationElement.Click();
            }
           
        }

        public void ConfirmCompleteMessageIsDisplayed()
        {
            TestCheck.AssertIsEqual(true, InstallationConfirmationMessageElement.Displayed, 
                                        "Complete Installation message not displayed");
        }
    }
}
