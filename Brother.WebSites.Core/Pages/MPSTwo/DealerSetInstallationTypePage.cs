using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

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
            WriteLogOnMethodEntry();
            if (InstallationTypeTabElement == null)
                throw new Exception("Installation Type tab not displayed");

            AssertElementPresent(InstallationTypeTabElement, "Installtion Type tab");
        }

        public void SetBORInstallationType()
        {
            WriteLogOnMethodEntry();
            BORToolElement.Click();
        }

        public void SetWebInstallationType()
        {
            WriteLogOnMethodEntry();
            WebInstallElement.Click();
        }

        public void SetInstallationType(string type)
        {
            WriteLogOnMethodEntry(type);
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
            WriteLogOnMethodEntry();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, NextElement);
           
            return GetInstance<DealerSendInstallationEmailPage>(Driver);
        }

    }
}
