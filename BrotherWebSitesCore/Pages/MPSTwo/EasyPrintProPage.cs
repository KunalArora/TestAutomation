using System;
using BrotherWebSitesCore.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BrotherWebSitesCore.Pages.MPSTwo
{
    public class EasyPrintProPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }


        [FindsBy(How = How.CssSelector, Using = "#content_1_InputProgramEnabled_Input")]
        private IWebElement ContractActivationElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSave")]
        private IWebElement ContractActivationSubmitElement;
        


        public void IsLeasingContractLinkAvailable()
        {
            if (ContractActivationElement == null)
                throw new Exception("Unable to locate contract activation");

            AssertElementPresent(ContractActivationElement, "Enable contract checkbox");
        }

        public void EnableContractType()
        {
            if (ContractActivationElement == null)
                throw new Exception("Unable to locate contract activation");
            if (ContractActivationSubmitElement == null)
                throw new Exception("Unable to locate contract activation submit button");

            var isContractActivated = ContractActivationElement.Selected;

            if (isContractActivated) return;
            ContractActivationElement.Click();
            ContractActivationSubmitElement.Click();
        }

    }
}
