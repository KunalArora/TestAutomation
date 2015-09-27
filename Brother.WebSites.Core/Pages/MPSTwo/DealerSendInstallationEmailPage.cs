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
    public class DealerSendInstallationEmailPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/dealer/contracts/manage-devices/send-installation-email\"]")]
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
            if(SendCommunicationEmailElement == null)
                throw new Exception("Send communication email is not displayed");

            AssertElementPresent(SendCommunicationEmailElement, "Communication email screen");
        }

        public void ArePinAndLabelFieldPopulated()
        {
            
                TestCheck.AssertIsEqual(true, PinLabelElement.Count.Equals(2) , "Pin and/or Reference not generated");
            
        }

        public void IsPinFieldPopulated()
        {

            TestCheck.AssertIsEqual(true, PinLabelElement.Count.Equals(1), "Pin and/or Reference not generated");

        }

        public void SendInstallationRequest()
        {
            NextButtonElement.Click();
            ConfirmInstallationEmailSent();

        }

        public void EnterInstallaterEmail()
        {
            ClearAndType(EmailFieldElement, "sayo.afolabi@brother.co.uk");
            WaitForElementToExistById("content_1_ButtonSend", 5);
        }

        public void ConfirmInstallationEmailSent()
        {
            TestCheck.AssertIsEqual(true, SentConfirmationElement.Displayed, "Installation email not");
            
        }

        public DealerManageDevicesPage CompleteInstallation()
        {
            FinishInstallationElement.Click();
            return GetTabInstance<DealerManageDevicesPage>(Driver);
        }
        

    }
}
