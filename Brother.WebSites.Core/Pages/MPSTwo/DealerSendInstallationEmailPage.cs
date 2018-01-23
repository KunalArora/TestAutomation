using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerSendInstallationEmailPage : BasePage, IPageObject
    {
        public static string Url = "/mps/dealer/contracts/manage-devices/send-installation-email";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string _validationElementSelector = ".active a[href=\"/mps/dealer/contracts/manage-devices/send-installation-email\"]";

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
                return Url;
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        private const string NextButtonSelector = "#content_1_ButtonNext";

        [FindsBy(How = How.CssSelector, Using = ".active a[href*=\"/send-installation-email\"]")]
        public IWebElement SendCommunicationEmailElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputInstallerEmailAddress_Input")]
        public IWebElement EmailFieldElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSend")]
        public IWebElement NextButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".col-sm-9 .form-control-static")]
        public IList<IWebElement> PinLabelElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_EmailSendSuccess")]
        public IWebElement SentConfirmationElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonNext")]
        public IWebElement FinishInstallationElement;
        
        
        


        public void IsSendCommunicationScreenDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (SendCommunicationEmailElement == null)
                throw new Exception("Send communication email is not displayed");

            AssertElementPresent(SendCommunicationEmailElement, "Communication email screen");
        }

        public void ArePinAndLabelFieldPopulated()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, PinLabelElement.Count.Equals(2) , "Pin and/or Reference not generated");
            SpecFlow.SetContext("ProposalId", PinLabelElement.First().Text);
            SpecFlow.SetContext("InstallationPin", PinLabelElement.Last().Text);
            
        }


        public void IsDeviceModelDisplayedOnSwapConfirmationPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            var aContainer = new List<String>();
            var serialNumber = SpecFlow.GetContext("SerialNumber");

            foreach (var item in PinLabelElement)
            {
                var itemText = item.Text;
                aContainer.Add(itemText);
            }

            var message = String.Format("Expect {0} but got {1}", serialNumber, aContainer);

            TestCheck.AssertIsEqual(true, aContainer.Any(x => x.Contains(serialNumber)), message);
        }

        public void IsPinFieldPopulated()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, PinLabelElement.Count.Equals(1), "Pin and/or Reference not generated");
            SpecFlow.SetContext("ProposalId", PinLabelElement.First().Text);

        }

        public void SendInstallationRequest()
        {
            LoggingService.WriteLogOnMethodEntry();
            NextButtonElement.Click();
            ConfirmInstallationEmailSent();

        }

        public DealerManageDevicesPage SendPcbSwapInstallationRequest()
        {
            LoggingService.WriteLogOnMethodEntry();
            return SendSwapInstallationRequest();

        }

        public DealerManageDevicesPage SendSwapInstallationRequest()
        {
            LoggingService.WriteLogOnMethodEntry();
            NextButtonElement.Click();
            return GetTabInstance<DealerManageDevicesPage>();
        }

        public string EnterInstallerEmail()
        {
            LoggingService.WriteLogOnMethodEntry();
            string emailId = "steve.walters@brother.co.uk";
            ClearAndType(EmailFieldElement, emailId);
            return emailId;
        }

        public void ConfirmInstallationEmailSent()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, SentConfirmationElement.Displayed, "Installation email not");
            
        }

        public DealerManageDevicesPage CompleteInstallation()
        {
            LoggingService.WriteLogOnMethodEntry();
            FinishInstallationElement.Click();
            return GetTabInstance<DealerManageDevicesPage>(Driver);
        }
        
        public string EnterInstallerEmailAndProceed()
        {
            LoggingService.WriteLogOnMethodEntry();
            int findElementTimeout = RuntimeSettings.DefaultFindElementTimeout;
            string emailId = EnterInstallerEmail();
            NextButtonElement.Click(); // Send Email button
            var _nextButtonElement = SeleniumHelper.FindElementByCssSelector(NextButtonSelector, findElementTimeout);
            _nextButtonElement.Click(); // Next button
            return emailId;
        }

    }
}
