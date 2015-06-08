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
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_InputStartDate_Input")]
        private IWebElement StartDateElement;
        [FindsBy(How = How.Id, Using = "content_1_InputContractReference_Input")]
        private IWebElement ContractReferenceElement;
        [FindsBy(How = How.Id, Using = "content_1_InputSentByPost_Input")]
        private IWebElement SentByPostElement;
        [FindsBy(How = How.Id, Using = "content_1_InputStartDateConfirmed_Input")]
        private IWebElement ServiceContractSignedElement;
        [FindsBy(How = How.Id, Using = "content_1_InputTermsAndConditionsSigned_Input")]
        private IWebElement TermsAndConditionsSignedElement;
        [FindsBy(How = How.Id, Using = "content_1_InputMachinesHandedOver_Input")]
        private IWebElement MachinesHandedOverElement;
        [FindsBy(How = How.Id, Using = "content_1_InputResellerInvoicing_Input")]
        private IWebElement ResellerInvoicingElement;
        [FindsBy(How = How.Id, Using = "content_1_InputBrotherInvoicing_Input")]
        private IWebElement BrotherInvoicingElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSave")]
        private IWebElement SaveButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonBack")]
        private IWebElement BackButtonElement;
    }
}
