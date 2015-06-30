using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class ConvertProposalTermAndType : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }


        [FindsBy(How = How.CssSelector, Using = "#content_1_InputUsageType_Label")]
        private IWebElement usageTypeElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/proposals/convert/summary\"] span")]
        private IWebElement SummaryTabElement;




        public void IsConvertTypeAndTypeDisplayed()
        {
            if (usageTypeElement == null)
                throw new Exception("Term and type page for convert proposal is not displayed");

            AssertElementPresent(usageTypeElement, "Term and type is not displayed");
        }


        public ConvertProposalSummaryPage NavigateToSummaryPageUsingTab()
        {
            SummaryTabElement.Click();
            return GetInstance<ConvertProposalSummaryPage>(Driver);
        }



    }
}
