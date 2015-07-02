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
    class LocalOfficeApproverContractsMaintenancePage: BasePage
    {
        public static string Url = "/mps/local-office/contracts/maintenance";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_InputStartDate_Input")]
        public IWebElement StartDateElement;
        [FindsBy(How = How.Id, Using = "content_1_InputContractReference_Input")]
        public IWebElement ContractReferenceElement;
        [FindsBy(How = How.Id, Using = "content_1_InputSentByPost_Input")]
        public IWebElement SentByPostElement;
        [FindsBy(How = How.Id, Using = "content_1_InputStartDateConfirmed_Input")]
        public IWebElement ServiceContractSignedElement;
        [FindsBy(How = How.Id, Using = "content_1_InputTermsAndConditionsSigned_Input")]
        public IWebElement TermsAndConditionsSignedElement;
        [FindsBy(How = How.Id, Using = "content_1_InputMachinesHandedOver_Input")]
        public IWebElement MachinesHandedOverElement;
        [FindsBy(How = How.Id, Using = "content_1_InputResellerInvoicing_Input")]
        public IWebElement ResellerInvoicingElement;
        [FindsBy(How = How.Id, Using = "content_1_InputBrotherInvoicing_Input")]
        public IWebElement BrotherInvoicingElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSave")]
        public IWebElement SaveButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonBack")]
        public IWebElement BackButtonElement;
    }
}
