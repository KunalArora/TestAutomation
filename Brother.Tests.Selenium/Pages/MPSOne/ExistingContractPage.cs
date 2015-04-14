﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.AccountManagement;
using Brother.Tests.Selenium.Lib.Properties;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace Brother.Tests.Selenium.Lib.Pages.MPSOne
{
    public class ExistingContractPage : BasePage
    {
        public static string Url = "/";
        

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["HomePage"].ToString(); }
        }

        [FindsBy(How = How.Id, Using = "contract-search")] 
        private IWebElement ContractHeader;
        [FindsBy(How = How.CssSelector, Using = ".active .organisation")] 
        private IList<IWebElement> ExistingOrganisations;
        [FindsBy(How = How.CssSelector, Using = ".active .contract-number")] 
        private IList<IWebElement> ExistingContractId;
        [FindsBy(How = How.Id, Using = "content_0_interface_0_fullwidthcontent_0_ddlStatusC")]
        private IWebElement ContractStatusSelector;
        [FindsBy(How = How.CssSelector, Using = ".my-contract-search-container .contract-input-search")]
        private IWebElement ContractSearchBox;
        [FindsBy(How = How.CssSelector, Using = ".my-contract-header label")]
        private IWebElement ContractHeaderLabel;
        [FindsBy(How = How.CssSelector, Using = ".active .contract-number")]
        private IList<IWebElement> SearchedContractId;
        [FindsBy(How = How.CssSelector, Using = ".active .organisation")]
        private IList<IWebElement> SearchedContractOrganisation;
        [FindsBy(How = How.CssSelector, Using = ".active .my-contract-status")]
        private IList<IWebElement> SearchedContractStatus;
        [FindsBy(How = How.ClassName, Using = "rows")]
        private IWebElement ContractRows;



        public void IsContractHeaderAvailable()
        {
            if (ContractHeader == null)
            {
                throw new Exception("Unable to locate Contract Header on page");
            }
            AssertElementPresent(ContractHeader, "Contract Header");
        }

        public void IsContractLabelAvailable()
        {
            if (ContractHeaderLabel == null)
            {
                throw new Exception("Unable to locate Contract Label on page");
            }
            AssertElementPresent(ContractHeaderLabel, "Contract Header label");
        }

        public void VerifyContractsAreDisplayed()
        {
            if (ContractRows == null)
            {
                throw new Exception("Contract List section is blank");
            }
            AssertElementPresent(ContractRows, "Contract Rows");
        }

        public void VerifyTheCorrectContractElementIsReturned(string element, string value)
        {
            WaitForLoaderToDisappear();

            switch (element)
            {
                case "Id" :
                {
                    AssertElementContainsText(SearchedContractId.ElementAtOrDefault(0), value, "Contract Id Searched For");
                    break;
                }
                case "Name" :
                {
                    AssertElementContainsText(SearchedContractOrganisation.ElementAtOrDefault(0), value, "Organisation Name Searched For");
                    break;
                }
            }
        }

        public void VerifyTheCorrectStatusIsReturned(string status)
        {
            WaitForLoaderToDisappear();
            Wait(Helper.DurationType.Second, 2);
            var transStatus = StatusTransform(status);
            AssertElementContainsText(SearchedContractStatus.ElementAtOrDefault(0), status, "Contract Status Searched For");
        }

        public ContractConfirmationPage ClickTheFirstContractOnTheList(string country)
        {
            //IsContractHeaderAvailable();
            ExistingOrganisations.ElementAt(0).Click();
            ScenarioContext.Current["TheFirstContractId"] = ExistingContractId.ElementAt(0).Text;
            var title = WelcomeBackPage.ValidateCountryTitle(country);
            return GetInstance<ContractConfirmationPage>(Driver, BasePage.BaseUrl, title);
        }

        public void SearchForContractElement(string value)
        {
            ClearAndType(ContractSearchBox, value);
            Wait(Helper.DurationType.Second, 2);
        }

        public void SearchForMultipleCriteria(string organisation, string status)
        {
            ClearAndType(ContractSearchBox, organisation); 
            WaitForLoaderToDisappear();
            ReturnSelectorToOriginalPoint();
            SelectContractStatus(status);
            WaitForLoaderToDisappear();
        }

        public void VerifyMultipleCriteriaResult(string organisation, string status)
        {
            WaitForLoaderToDisappear();
            AssertElementContainsText(SearchedContractOrganisation.ElementAtOrDefault(0), organisation, "Returned Contract Orgnaisation");
            VerifyTheCorrectStatusIsReturned(status);
        }

        private void ReturnSelectorToOriginalPoint()
        {
            SelectFromDropDownByIndex(ContractStatusSelector, 0);
            WaitForLoaderToDisappear();
        }

        private void SelectContractStatus(string status)
        {
            var transStatus = ContractStatusTransform(status);
            SelectFromDropdownByValue(ContractStatusSelector, transStatus);
        }

        public void ClearAndSelectStatus(string status)
        {
            ContractSearchBox.Clear();
            SelectContractStatus(status);
        }

        private static String StatusTransform(string status) 
	    {
		    var transformedStatus = "";
		
		    switch (status) 
		    {
				    case "Contract created" :
				    transformedStatus = "Contrato creado";
				    break;
				
				    case "Generated" :
				    transformedStatus = "Generado";
				    break;
				
				    case "Signed" :
				    transformedStatus = "Firmado";
				    break;
				
				    case "Activated" :
				    transformedStatus = "Activado";
				    break;
				
				    case "Terminated" :
				    transformedStatus = "Terminado";
				    break;
				
				    case "Completed" :
				    transformedStatus = "Completo";
				    break;
				
				    default:
					    throw new Exception(String.Format("{0} is not configured", status));
		    }
		    return transformedStatus;
	    }

        private static String ContractStatusTransform(string status)
	    {
		    var transformedStatus = "";
		
		    switch (status) 
		    {
				    case "Contract created" :
				    transformedStatus = "E0001";
				    break;
				
				    case "Generated" :
				    transformedStatus = "E0002";
				    break;
				
				    case "Signed" :
				    transformedStatus = "E0003";
				    break;
				
				    case "Activated" :
				    transformedStatus = "E0004";
				    break;
				
				    case "Terminated" :
				    transformedStatus = "E0005";
				    break;
				
				    case "Completed" :
				    transformedStatus = "E0006";
				    break;
				
				    default:
					    throw new Exception(String.Format("{0} is not configured", status));
		    }
		
		    return transformedStatus;
	    }
        
    }
}
