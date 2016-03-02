using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerContractsSummaryPage : BasePage
    {
        public static string Url = "/mps/dealer/contracts/summary";

        public override string DefaultTitle
        {
            get { return string.Empty; }
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


        public void ClickCancelButton()
        {
            ScrollTo(CancelButtonElement);
            CancelButtonElement.Click();
        }

        public DealerContractsPage ClickSignButton()
        {
            ScrollTo(SignButtonElement);
            WebDriver.Wait(DurationType.Second, 3);
            SignButtonElement.Click();
            
            return GetTabInstance<DealerContractsPage>(Driver);
        }

        public DealerContractsAwaitingAcceptancePage ClickSignButtonToNavigateToAwaitingAcceptance()
        {
            StoreValuesFromSummaryPage();
            ScrollTo(SignButtonElement);
            WebDriver.Wait(DurationType.Second, 5);
            SignButtonElement.Click();
            
            return GetTabInstance<DealerContractsAwaitingAcceptancePage>(Driver);
        }

        public void ClickReSignButton()
        {
            ScrollTo(ResignButtonElement);
            ResignButtonElement.Click();
            WebDriver.Wait(DurationType.Second, 3);
        }

        public DealerContractsPage ClickFinalReSignButton()
        {
            ScrollTo(FinalResignButtonElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, FinalResignButtonElement);

            WebDriver.Wait(DurationType.Second, 3);

            return GetTabInstance<DealerContractsPage>(Driver);
        }

        public void TickResignInformationCheckbox()
        {
            ResignInformationCheckboxElement.Click();
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void IsContractSummaryPageDisplayed()
        {
            if (SignButtonElement == null)
                throw new Exception("Contract Summary not displayed");
            AssertElementPresent(SignButtonElement, "Is Contract Summary displayed");
        }

        public DealerContractsPage DealerSignsApprovedProposal()
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, SignButtonElement);
            WebDriver.Wait(DurationType.Second, 3);

            return GetInstance<DealerContractsPage>(Driver);
        }

        private void StoreValuesFromSummaryPage()
        {
            SpecFlow.SetContext("SummaryCustomerEmail", SummaryCustomerEmailElement.Text);
            SpecFlow.SetContext("SummaryCustomerOrCompanyName", SummaryCustomerOrCompanyNameElement.Text);
            SpecFlow.SetContext("SummaryContractTerm", SummaryContractTermElement.Text);
            SpecFlow.SetContext("SummaryContractType", SummaryContractTypeElement.Text);
            SpecFlow.SetContext("SummaryMonoClickRate", SummaryMonoClickRateElement.Text);
            SpecFlow.SetContext("SummaryColourClickRate", SummaryColourClickRateElement.Text);
        }

        public DealerContractsAwaitingAcceptancePage DealerSignsApprovedProposalTAwaitingAcceptancePage()
        {
            StoreValuesFromSummaryPage();

            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, SignButtonElement);
            WebDriver.Wait(DurationType.Second, 3);

            
            return GetInstance<DealerContractsAwaitingAcceptancePage>(Driver);
        }

        public DealerClosedProposalPage CloseProposal()
        {
            ScrollTo(SummaryCloseProposalElement);
            SummaryCloseProposalElement.Click();
            ClickAcceptOnConfrimation(Driver);
            return GetInstance<DealerClosedProposalPage>(Driver);
        }

        public void ClickAcceptOnConfrimation(IWebDriver driver)
        {
            WebDriver.Wait(DurationType.Millisecond, 3000);
            ClickAcceptOnJsAlert(driver);
        }

        

    }
}
