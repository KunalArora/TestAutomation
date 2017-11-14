using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Brother.Tests.Selenium.Lib.Helpers;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerSetInstallationTypePage : BasePage, IPageObject
    {
        public static string Url = "/mps/dealer/contracts/manage-devices/set-installation-type";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string _validationElementSelector = ".active a[href=\"/mps/dealer/contracts/manage-devices/set-installation-type\"]";

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

        [FindsBy(How = How.CssSelector, Using = ".active a[href*=\"/set-installation-type\"]")]
        public IWebElement InstallationTypeTabElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputInstallationChoiceTool_Input")]
        public IWebElement BORToolElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputInstallationChoiceWeb_Input")]
        public IWebElement WebInstallElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonNext")]
        public IWebElement NextElement;


        public void IsInstallationTypeTabDisplayed()
        {
            if(InstallationTypeTabElement == null)
                throw new Exception("Installation Type tab not displayed");

            AssertElementPresent(InstallationTypeTabElement, "Installtion Type tab");
        }

        public void SetBORInstallationType()
        {
            BORToolElement.Click();
        }

        public void SetWebInstallationType()
        {
            WebInstallElement.Click();
        }

        public void SetInstallationType(string type)
        {
            switch (type)
            {
                case "BOR" :
                    SetBORInstallationType();
                    break;
                case "Web" :
                    SetWebInstallationType();
                    break;
            }
        }

        public DealerSendInstallationEmailPage ProccedToDealerSendInstallationEmailPage()
        {
           MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, NextElement);
           
            return GetInstance<DealerSendInstallationEmailPage>(Driver);
        }

    }
}
