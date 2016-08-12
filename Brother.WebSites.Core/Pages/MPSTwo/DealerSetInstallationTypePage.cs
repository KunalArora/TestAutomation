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

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerSetInstallationTypePage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }


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
