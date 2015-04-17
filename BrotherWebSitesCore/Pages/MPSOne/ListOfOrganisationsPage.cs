using System;
using BrotherWebSitesCore.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BrotherWebSitesCore.Pages.MPSOne
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
