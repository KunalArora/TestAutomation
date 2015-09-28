using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerSetCommunicationMethodPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/dealer/contracts/manage-devices/set-communication-method\"]")]
        public IWebElement SetCommunicationTabElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputCommunicationChoiceCloud")]
        public IWebElement CloudCommunicationElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputCommunicationChoiceEmail")]
        public IWebElement EmailCommunicationTabElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonNext")]
        public IWebElement ProceedElement;


        public void IsSetCommunicationTabDisplayed()
        {
            if(SetCommunicationTabElement == null)
                throw new Exception("Set Communication Screen not displayed");

            AssertElementPresent(SetCommunicationTabElement, "Set communication screen");
        }

        public void SetCloudCommunicationMethod()
        {
            CloudCommunicationElement.Click();
        }

        public void SetEmailCommunicationMethod()
        {
            EmailCommunicationTabElement.Click();
        }

        public void SetCommunicationMethod(string method)
        {
            switch (method)
            {
                case  "Cloud" :
                    SetCloudCommunicationMethod();
                    break;

                case "Email" :
                    SetEmailCommunicationMethod();
                    break;
            }
        }

        public DealerSetInstallationTypePage ProceedToNextPage()
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ProceedElement);
            
            return GetTabInstance<DealerSetInstallationTypePage>(Driver);
        }


        public DealerSendInstallationEmailPage ProceedToNextPageForEmail()
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ProceedElement);

            return GetTabInstance<DealerSendInstallationEmailPage>(Driver);
        }

    }
}
