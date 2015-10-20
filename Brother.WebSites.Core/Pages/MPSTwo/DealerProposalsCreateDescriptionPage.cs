using System;
using System.Collections.Generic;
using System.ComponentModel;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsCreateDescriptionPage : BasePage
    {
        public static string URL = "/mps/dealer/proposals/create/description?new=true";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string contractSelector = @"#content_1_InputContractType_Input";
        private const string customertab = @"a[href='/mps/dealer/proposals/create/customer-information']";

        [FindsBy(How = How.Id, Using = "content_1_ComponentIntroductionAlert")]
        public IWebElement PromptText;
        [FindsBy(How = How.Id, Using = "content_1_InputLeadCodeReference_Input")]
        public IWebElement LeadCodeRef;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputContractType_Input")]
        public IWebElement ContractTypeSelector;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputUsageType_Input")]
        public IWebElement UsageTypeSelector;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalName_Input")]
        public IWebElement ProposalNameField;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement NextButton;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/proposals/create/customer-information']")]
        public IWebElement CustomerInformationTab;
        [FindsBy(How = How.CssSelector, Using = "#MpsAppContent .mps-tabs-main li")]
        public IList<IWebElement> ProposalCreationTabs;
        

        


        public void IsPromptTextDisplayed()
        {
            if (PromptText == null) throw new
                NullReferenceException("Unable to locate text on New Proposal Process Screen");
           
            AssertElementPresent(PromptText, "Leading Instruction");
        }

        public void SetServerName(string refe)
        {
           SpecFlow.SetContext("servername", refe); 
        }

        public String GetServerName()
        {
            return SpecFlow.GetContext("servername");
        }

        public void EnterLeadCodeRef(string leadCodeRef)
        {
            if (leadCodeRef.Equals(string.Empty))
            {
                leadCodeRef = MpsUtil.GenerateUniqueLeadCodeRef();
                try
                {
                    SpecFlow.SetContext("GeneratedLeadCodeReference", leadCodeRef);
                }
                catch
                {
                    throw new NullReferenceException("Session cannot store leadCodeRef");
                }
            }

            LeadCodeRef.Clear();
            LeadCodeRef.SendKeys(leadCodeRef);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        private IWebElement ContractTypeSelectorDropdown()
        {
            return GetElementByCssSelector(contractSelector, 10);
        }


        private IWebElement CustomerTabElement()
        {
            return GetElementByCssSelector(customertab, 10);
        }

        public void CustomerTabNotDisplayed()
        {
            TestCheck.AssertIsEqual(5, ProposalCreationTabs.Count, "");
        }

        public void CustomerTabIsDisplayed()
        {
            TestCheck.AssertIsEqual(6, ProposalCreationTabs.Count, "");
        }


        public void SelectingContractType(string contract)
        {
            if (IsElementPresent(ContractTypeSelectorDropdown()))
                SelectContractType(contract);

        }

        public void SelectContractType(string contract)
        {
            var selectable = "";

            switch (contract)
            {
                case "AIC":
                    selectable = "1";
                    break;
                case "Purchase & Click with Service":
                    selectable = "3";
                    break;
                case "Lease & Click with Service":
                    selectable = "2";
                    break;
                case "Easy Print Pro & Service":
                    selectable = "3";
                    break;
                case "Leasing & Service":
                    selectable = "2";
                    break;
                default:
                    throw new InvalidEnumArgumentException(String.Format("{0} is not a valid contract type", contract));
            }

            if (!ContractTypeSelector.Displayed) return;
            SelectFromDropdownByValue(ContractTypeSelector, selectable);
            SpecFlow.SetContext("CreateContractType", contract);
        }

        public void SelectingContractUsageType(string contract)
        {
            if (IsElementPresent(ContractTypeSelectorDropdown()))
                SelectContractUsageType(contract);

        }

        public void SelectContractUsageType(string usage)
        {
            var selectable = "";

            switch (usage)
            {
                case "Minimum Volume":
                    selectable = "1";
                    break;
                case "Pay As You Go":
                    selectable = "2";
                    break;
                default:
                    throw new InvalidEnumArgumentException(String.Format("{0} is not a valid contract type", usage));
            }

            if (UsageTypeSelector.Displayed)
            {
                SelectFromDropdownByValue(UsageTypeSelector, selectable);
                SpecFlow.SetContext("CreateUsageType", usage);
            }
        }

        public void EnterProposalName(string proposalName)
        {
            if (proposalName.Equals(string.Empty))
            {
                proposalName = MpsUtil.GenerateUniqueProposalName();
                try
                {
                    SpecFlow.SetContext("GeneratedProposalName", proposalName);
                }
                catch
                {
                    throw new NullReferenceException("Session cannot store proposalName");
                }

            }

            ProposalNameField.Clear();
            ProposalNameField.SendKeys(proposalName);
            WebDriver.Wait(DurationType.Millisecond, 100);
        }

        public DealerProposalsCreateCustomerInformationPage ClickNextButton()
        {
            ScrollTo(NextButton);
            NextButton.Click();

            return GetTabInstance<DealerProposalsCreateCustomerInformationPage>(Driver);
        }

        public DealerProposalsCreateTermAndTypePage ClickNextButtonGermany()
        {
            ScrollTo(NextButton);
            NextButton.Click();

            return GetTabInstance<DealerProposalsCreateTermAndTypePage>(Driver);
        }
    }
}
