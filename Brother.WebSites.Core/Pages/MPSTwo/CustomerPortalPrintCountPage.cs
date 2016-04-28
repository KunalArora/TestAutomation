using System;
using System.Collections;
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
    public class CustomerPortalPrintCountPage : BasePage
    {
        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".alert.alert-info")]
        public IList<IWebElement> ContractInfo;
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/customer/print-counts\"]")]
        public IWebElement PrintCountTab;
        [FindsBy(How = How.CssSelector, Using = "#content_1_PrintCountList_Contracts_List_0_CellTotalCount_0")]
        public IWebElement FirstPrintCountTotal;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"CellTotalCount\"]")]
        public IList<IWebElement> PrintCountTotal;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"CellColourCount\"]")]
        public IList<IWebElement> PrintCountColour;
        [FindsBy(How = How.CssSelector, Using = "[id*=\"CellMonoCount\"]")]
        public IList<IWebElement> PrintCountMono;
        



        private string GetContractId()
        {
            return SpecFlow.GetContext("SummaryPageContractId");
        }

        public void IsCustomerPrintCountDisplayed()
        {
            if(PrintCountTab == null)
                throw new Exception("Print Count tab not displayed");
            if (FirstPrintCountTotal == null)
                throw new Exception("Print Count tab not displayed");

            AssertElementPresent(PrintCountTab, "Print count is not displayed as Print Count tab is not displayed");
            AssertElementPresent(FirstPrintCountTotal, "Print count is not displayed as First Print Count Total is not displayed");
        }

        private List<String> StringContainer(IEnumerable<IWebElement> element)
        {
            return element.Select(info => info.Text).ToList();
        }

        public void IsContractIdDisplayedOnCustomerPrintCountPage()
        {
            var infoContainer = StringContainer(ContractInfo);

            TestCheck.AssertIsEqual(true, infoContainer.Contains(GetContractId()),
                             String.Format("Contract Id is not displayed. The information displayed was {0}", infoContainer));
        }


        public void VerifyPrintCountTotalDisplayedIsCorrect()
        {
            if(PrintCountTotal == null)
                throw new Exception("Print Count was not updated");

            var infoContainer = StringContainer(PrintCountTotal);

            TestCheck.AssertIsEqual(true, infoContainer.Contains("1000"),
                            String.Format("Print Count total did not match the expected {0}", infoContainer));
        }

        public void VerifyPrintCountColourDisplayedIsCorrect()
        {
            if (PrintCountColour == null)
                throw new Exception("Print Count was not updated");

            var infoContainer = StringContainer(PrintCountColour);

            TestCheck.AssertIsEqual(true, infoContainer.Contains("900"),
                                    String.Format("Print Count Colour did not match the expected {0}", infoContainer));
        }

        public void VerifyPrintCountMonoDisplayedIsCorrect()
        {
            if (PrintCountMono == null)
                throw new Exception("Print Count was not updated");

            var infoContainer = StringContainer(PrintCountMono);

            TestCheck.AssertIsEqual(true, infoContainer.Contains("100"),
                                    String.Format("Mono Print Count did not match the expected {0}", infoContainer));
        }

    }
}
