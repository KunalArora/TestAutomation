using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerContractsSummaryPage : BasePage, IPageObject
    {
        public static string Url = "/mps/dealer/contracts/summary";
        private const string _validationElementSelector = ".js-mps-contract-summary-sign-proposal"; // Sign button

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

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

        public ISeleniumHelper SeleniumHelper
        {
            get; set;
        }

        [FindsBy(How = How.Id, Using = "content_1_ButtonCancel")]
        public IWebElement CancelButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSign")]
        public IWebElement SignButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonReSignProcess")]
        public IWebElement ResignButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonReSignContractSubmit")]
        public IWebElement FinalResignButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_mpsCheckboxReSignContract_Label")]
        public IWebElement ResignInformationCheckboxElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonCancel")]
        public IWebElement SummaryCloseProposalElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerEmail")]
        public IWebElement SummaryCustomerEmailElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_CustomerName")]
        public IWebElement SummaryCustomerOrCompanyNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ContractTerm")]
        public IWebElement SummaryContractTermElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_ContractType")]
        public IWebElement SummaryContractTypeElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_MonoClickRate_0")]
        public IWebElement SummaryMonoClickRateElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_ColourClickRate_0")]
        public IWebElement SummaryColourClickRateElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterInstallationPacks_0_InstallationPackUnitPrice_0")]
        public IWebElement SummaryInstallationUnitPriceElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_RepeaterModels_RepeaterServicePacks_0_ServicePackUnitPrice_0")]
        public IWebElement SummaryServicePackUnitPriceElement;
        


        public void ClickCancelButton()
        {
            WriteLogOnMethodEntry();
            ScrollTo(CancelButtonElement);
            CancelButtonElement.Click();
        }

        public DealerContractsPage ClickSignButton()
        {
            WriteLogOnMethodEntry();
            ScrollTo(SignButtonElement);
            WebDriver.Wait(DurationType.Second, 3);
            SignButtonElement.Click();
            
            return GetTabInstance<DealerContractsPage>(Driver);
        }

        public DealerContractsAwaitingAcceptancePage ClickSignButtonToNavigateToAwaitingAcceptance()
        {
            WriteLogOnMethodEntry();
            StoreValuesFromSummaryPage();
            ScrollTo(SignButtonElement);
            WebDriver.Wait(DurationType.Second, 5);
            SignButtonElement.Click();
            
            return GetTabInstance<DealerContractsAwaitingAcceptancePage>(Driver);
        }

        public void ClickReSignButton()
        {
            WriteLogOnMethodEntry();
            ScrollTo(ResignButtonElement);
            ResignButtonElement.Click();
            WebDriver.Wait(DurationType.Second, 3);
        }

        public DealerContractsPage ClickFinalReSignButton()
        {
            WriteLogOnMethodEntry();
            ScrollTo(FinalResignButtonElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, FinalResignButtonElement);

            WebDriver.Wait(DurationType.Second, 3);

            return GetTabInstance<DealerContractsPage>(Driver);
        }

        public void TickResignInformationCheckbox()
        {
            WriteLogOnMethodEntry();
            ResignInformationCheckboxElement.Click();
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void IsContractSummaryPageDisplayed()
        {
            WriteLogOnMethodEntry();
            if (SignButtonElement == null)
                throw new Exception("Contract Summary not displayed");
            AssertElementPresent(SignButtonElement, "Is Contract Summary displayed");
        }

        public DealerContractsPage DealerSignsApprovedProposal()
        {
            WriteLogOnMethodEntry();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, SignButtonElement);
            WebDriver.Wait(DurationType.Second, 3);

            return GetInstance<DealerContractsPage>(Driver);
        }

        private void StoreValuesFromSummaryPage()
        {
            WriteLogOnMethodEntry();
            SpecFlow.SetContext("SummaryCustomerEmail", SummaryCustomerEmailElement.Text);
            SpecFlow.SetContext("SummaryCustomerOrCompanyName", SummaryCustomerOrCompanyNameElement.Text);
            SpecFlow.SetContext("SummaryContractTerm", SummaryContractTermElement.Text);
            SpecFlow.SetContext("SummaryContractType", SummaryContractTypeElement.Text);
            SpecFlow.SetContext("SummaryMonoClickRate", SummaryMonoClickRateElement.Text);
            SpecFlow.SetContext("SummaryColourClickRate", SummaryColourClickRateElement.Text);
        }

        public void IsSpecialPricingMonoClickPriceDisplayed()
        {
            WriteLogOnMethodEntry();
            var mono = SummaryMonoClickRateElement.Text;
            var monoD = SpecFlow.GetContext("SpecialPriceMonoClickPrice");

            TestCheck.AssertIsEqual(true, mono.Contains(monoD), string.Format("{0} does not contain {1}", mono, monoD));
        }

        public void IsSpecialPricingColourClickPriceDisplayed()
        {
            WriteLogOnMethodEntry();
            var colour = SummaryColourClickRateElement.Text;
            var colourD = SpecFlow.GetContext("SpecialPriceColourClickPrice");

            TestCheck.AssertIsEqual(true, colour.Contains(colourD), string.Format("{0} does not contain {1}", colour, colourD));
        }

        public void IsSpecialPricingInstallationUnitPriceDisplayed()
        {
            WriteLogOnMethodEntry();
            var install = SummaryInstallationUnitPriceElement.Text;
            var installD = SpecFlow.GetContext("SpecialPriceInstallation");

            TestCheck.AssertIsEqual(true, install.Contains(installD), string.Format("{0} does not contain {1}", install, installD));
        }


        public void IsSpecialPricingServicePackUnitPriceDisplayed()
        {
            WriteLogOnMethodEntry();
            var servicePack = SummaryServicePackUnitPriceElement.Text;
            var servicePackD = SpecFlow.GetContext("SpecialPriceServicePack");

            TestCheck.AssertIsEqual(true, servicePack.Contains(servicePackD), string.Format("{0} does not contain {1}", servicePack, servicePackD));
        }

        public DealerContractsAwaitingAcceptancePage DealerSignsApprovedProposalTAwaitingAcceptancePage()
        {
            WriteLogOnMethodEntry();
            StoreValuesFromSummaryPage();

            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, SignButtonElement);
            WebDriver.Wait(DurationType.Second, 3);

            
            return GetInstance<DealerContractsAwaitingAcceptancePage>(Driver);
        }

        public DealerClosedProposalPage CloseProposal()
        {
            WriteLogOnMethodEntry();
            ScrollTo(SummaryCloseProposalElement);
            SummaryCloseProposalElement.Click();
            ClickAcceptOnConfrimation();
            return GetInstance<DealerClosedProposalPage>(Driver);
        }

        public void ClickAcceptOnConfrimation()
        {
            WriteLogOnMethodEntry();
            ClickAcceptOnJsAlert();
        }

        

    }
}
