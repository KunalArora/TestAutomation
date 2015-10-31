using System;
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

        public override string DefaultTitle
        {
            get { return string.Empty; }
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

        [FindsBy(How = How.CssSelector, Using = "[class*=\"js-mps-ip-a\"]")] 
        public IWebElement IpElement;

        [FindsBy(How = How.CssSelector, Using = "[class*=\"js-mps-connect-device-to-\"]")] 
        public IWebElement ConnectButtonElement;

        [FindsBy(How = How.CssSelector, Using = "[type=\"submit\"][id*=\"content_0_Button\"]")] 
        public IWebElement CompleteInstallationElement;

        [FindsBy(How = How.CssSelector, Using = "#content_0_InstallationSuccessfullyFinished")] 
        public IWebElement CompleteInstallationComfirmationElement;

       [FindsBy(How = How.CssSelector, Using = "#content_0_InputTimeZone_Input")] 
        public IWebElement TimeZoneOptionsElements;

        private const string GermanUrl = @"online.de.";
        private const string EnglandUrl = @"online.uk.";






        public void IsInstallerScreenDisplayed()
        {
            if (ContractReferencePageAlertElement == null)
                throw new Exception("Installer page is not displayed");
            AssertElementPresent(ContractReferencePageAlertElement, "Installer pager alert");

            MPSJobRunnerPage.RunResetSerialNumberJob(GetUrl().Contains(EnglandUrl) ? serialNumber : serialNumberBIG);
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
            var pin = PinAndAddressElement.Last().Text;
            var ePin = SpecFlow.GetContext("InstallationPin");

            var message =
                String.Format(
                    "The installation pin {0} dispalyed on installer page does not match the pin {1} saved earlier", pin,
                    ePin);

            TestCheck.AssertIsEqual(true, pin.Equals(ePin), message);
        }

        public void VerifyTimeZoneIsDisplayed(string method)
        {
            if (method != "Web") return;
            var option = SelectOption(TimeZoneOptionsElements);
            TestCheck.AssertIsEqual(true, option.Any(), "Time Zone does not contain any options");
        }

        public void EnterSerialNumber(string country)
        {
            if (country.Equals("United Kingdom"))
            {
                MPSJobRunnerPage.RunResetSerialNumberJob(serialNumber);

                WebDriver.Wait(DurationType.Second, 5);

                ClearAndType(SerialNumberFieldElement, serialNumber);
            }
            else if (country.Equals("Germany"))
            {
                MPSJobRunnerPage.RunResetSerialNumberJob(serialNumberBIG);

                WebDriver.Wait(DurationType.Second, 5);

                ClearAndType(SerialNumberFieldElement, serialNumberBIG);
            }

            
            WebDriver.Wait(DurationType.Second, 5);

            SerialNumberFieldElement.SendKeys(Keys.Tab);

            WebDriver.Wait(DurationType.Second, 5);
        }


        private IWebElement IpAddress()
        {
            return GetElementByCssSelector("[class*=\"js-mps-ip-a\"]");
        }

        public void EnterIpAddress()
        {
            if (InstalledPinElements == null && TimeZoneOptionsElements == null)
            { foreach (var ipAddressElement in IpAddressElements)
                {
                    ipAddressElement.Click();
                    ClearAndType(ipAddressElement, "1");
                    ipAddressElement.SendKeys(Keys.Tab);
                    WebDriver.Wait(DurationType.Second, 2);
                }
            }
                WebDriver.Wait(DurationType.Second, 5);
        }

        public void ConnectDevice()
        {
            try
            {
                if (InstalledPinElements == null && TimeZoneOptionsElements == null)
                {
                    ConnectButtonElement.Click();
                    WebDriver.Wait(DurationType.Second, 5);
                }
            }
            catch (Exception)
            {
                throw new Exception("ConnectButtonElement is not displayed");
            }
            
           
        }

        public void CompleteDeviceConnection()
        {
            try
            {
                if (InstalledPinElements == null && TimeZoneOptionsElements == null)
                {
                    CompleteInstallationElement.Click();
                    WebDriver.Wait(DurationType.Second, 5);
                }
            }
            catch (Exception)
            {
                throw new Exception("CompleteInstallationElement is not displayed");
            }
            
            
        }

        public void ConfirmInstallationSucceed()
        {
            if (InstalledPinElements == null && TimeZoneOptionsElements == null)
            {
                TestCheck.AssertIsEqual(true, CompleteInstallationComfirmationElement.Displayed,
                "Installation not successful");
            }
           
        }
        

    }
}
