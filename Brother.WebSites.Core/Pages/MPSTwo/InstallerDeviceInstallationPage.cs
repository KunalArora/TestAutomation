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
        [FindsBy(How = How.CssSelector, Using = ".js-mps-connect-device-to-email")]
        public IWebElement ConnectButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_0_ButtonCompleteEmailInstallation")]
        public IWebElement CompleteInstallationElement;
        [FindsBy(How = How.CssSelector, Using = "#content_0_InstallationSuccessfullyFinished")]
        public IWebElement CompleteInstallationComfirmationElement;
        
        
        



        public void IsInstallerScreenDisplayed()
        {
            if(ContractReferencePageAlertElement == null)
                throw new Exception("Installer page is not displayed");
            AssertElementPresent(ContractReferencePageAlertElement, "Installer pager alert");
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

            var message = String.Format("The installation pin {0} dispalyed on installer page does not match the pin {1} saved earlier", pin, ePin);

            TestCheck.AssertIsEqual(true, pin.Equals(ePin), message);
        }

        public void EnterSerialNumber()
        {
            ClearAndType(SerialNumberFieldElement, serialNumber);
            SerialNumberFieldElement.SendKeys(Keys.Tab);
            WebDriver.Wait(Helper.DurationType.Second, 3);
        }

        public void EnterIpAddress()
        {
            foreach (var ipAddressElement in IpAddressElements)
            {
                ipAddressElement.Click();
                ClearAndType(ipAddressElement, "1");
                ipAddressElement.SendKeys(Keys.Tab);
            }
        }

        public void ConnectDevice()
        {
            ConnectButtonElement.Click();
        }

        public void CompleteDeviceConnection()
        {
            CompleteInstallationElement.Click();
            WebDriver.Wait(Helper.DurationType.Second, 3);
        }

        public void ConfirmInstallationSucceed()
        {
            TestCheck.AssertIsEqual(true, CompleteInstallationComfirmationElement.Displayed, "Installation not successful");
        }
        

    }
}
