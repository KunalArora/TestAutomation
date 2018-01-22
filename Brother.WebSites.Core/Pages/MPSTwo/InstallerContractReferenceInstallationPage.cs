using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class InstallerContractReferenceInstallationPage : BasePage, IPageObject
    {
        public static string _url_contract_reference = "/mps/web-installation/installation-contract-reference";
        private const string _validationElementSelectorContactReference = "#content_0_InputContractReference_Input";


        private const string ContractReferenceSelector = "#content_0_InputContractReference_Input";
        private const string NextButtonSelector = ".js-mps-val-btn-next";

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelectorContactReference;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url_contract_reference;
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        public void PopulateContractReference(int proposalId)
        {
            WriteLogOnMethodEntry(proposalId);
            int findElementTimeout = RuntimeSettings.DefaultFindElementTimeout;
            var contractReferenceElement = SeleniumHelper.FindElementByCssSelector(ContractReferenceSelector, findElementTimeout);
            ClearAndType(contractReferenceElement, proposalId.ToString());
        }

        public void ProceedOnInstaller()
        {
            WriteLogOnMethodEntry();
            int findElementTimeout = RuntimeSettings.DefaultFindElementTimeout;
            var nextButtonElement = SeleniumHelper.FindElementByCssSelector(NextButtonSelector, findElementTimeout);
            nextButtonElement.Click();
        }

    }
}
