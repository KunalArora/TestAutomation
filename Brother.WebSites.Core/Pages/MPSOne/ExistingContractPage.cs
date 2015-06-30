using System;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSOne
{
    public class ExistingContractPage : BasePage
    {
        public static string Url = "/";
        

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["HomePage"].ToString(); }
        }

        [FindsBy(How = How.Id, Using = "contract-search")] 
        public IWebElement ContractHeader;
        [FindsBy(How = How.CssSelector, Using = ".active .organisation")]
        public IList<IWebElement> ExistingOrganisations;
        [FindsBy(How = How.CssSelector, Using = ".active .contract-number")]
        public IList<IWebElement> ExistingContractId;
        [FindsBy(How = How.Id, Using = "content_0_interface_0_fullwidthcontent_0_ddlStatusC")]
        public IWebElement ContractStatusSelector;
        [FindsBy(How = How.CssSelector, Using = ".my-contract-search-container .contract-input-search")]
        public IWebElement ContractSearchBox;
        [FindsBy(How = How.CssSelector, Using = ".my-contract-header label")]
        public IWebElement ContractHeaderLabel;
        [FindsBy(How = How.CssSelector, Using = ".active .contract-number")]
        public IList<IWebElement> SearchedContractId;
        [FindsBy(How = How.CssSelector, Using = ".active .organisation")]
        public IList<IWebElement> SearchedContractOrganisation;
        [FindsBy(How = How.CssSelector, Using = ".active .my-contract-status")]
        public IList<IWebElement> SearchedContractStatus;
        [FindsBy(How = How.ClassName, Using = "rows")]
        public IWebElement ContractRows;



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
            WebDriver.Wait(Helper.DurationType.Second, 2);
            var transStatus = StatusTransform(status);
            AssertElementContainsText(SearchedContractStatus.ElementAtOrDefault(0), status, "Contract Status Searched For");
        }

        public ContractConfirmationPage ClickTheFirstContractOnTheList(string country)
        {
            //IsContractHeaderAvailable();
            ExistingOrganisations.ElementAt(0).Click();
            SpecFlow.SetContext("TheFirstContractId", ExistingContractId.ElementAt(0).Text);
            var title = WelcomeBackPage.ValidateCountryTitle(country);
            return GetInstance<ContractConfirmationPage>(Driver, BasePage.BaseUrl, title);
        }

        public void SearchForContractElement(string value)
        {
            ClearAndType(ContractSearchBox, value);
            WebDriver.Wait(Helper.DurationType.Second, 2);
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
