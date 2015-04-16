using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline;
using Brother.Tests.Selenium.Lib.Properties;
using BrotherWebSitesCore.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Pages.MPSOne
{
    public class ListOfOrganisationsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }


        [FindsBy(How = How.Id, Using = "customer-information")]
        public IWebElement OrganisationHeader;

        public void IsOrganisationHeaderAvailable()
        {
            if (OrganisationHeader == null)
            {
                throw new Exception("Unable to locate Organisation Header on page");
            }
            AssertElementPresent(OrganisationHeader, "Organisation Header");
        }

    }
}
