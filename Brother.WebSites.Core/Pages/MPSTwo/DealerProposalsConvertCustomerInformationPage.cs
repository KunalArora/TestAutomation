using Brother.Tests.Selenium.Lib.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsConvertCustomerInformationPage : DealerCustomersManagePage, IPageObject
    {
        private const string _url = "/mps/dealer/proposals/convert/customer-information";
        private const string _validationElementSelector = ".js-mps-val-btn-next"; // #content_1_ButtonNext

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get { return _url; }
        }

        [FindsBy(How = How.CssSelector, Using = "input[type=\"submit\"]#content_1_ButtonNext")]
        public IWebElement nextButtonElement;

        [FindsBy(How = How.Id, Using = "content_1_InputCustomerChoiceNew")]
        public IWebElement CreateNewCustomerElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement NextButton;

    }

    public class CustomerInformationPageValue : Dictionary<string, string>
    {
        // for example:
        // ID                                                                   KEY
        // content_1_PersonManage_InputCustomerName                             InputCustomerName
        // content_1_PersonManage_CustomerLocation_InputStreet_Input            CustomerLocation.InputStreet
        // content_1_PersonManage_CustomerLocation_InputNumber_Input
        // content_1_PersonManage_CustomerLocation_InputPostCode_Input
        // content_1_PersonManage_CustomerLocation_InputTown_Input
        // content_1_PersonManage_CustomerLocation_InputArea_Input
        // content_1_PersonManage_InputCustomerCostCentre_Input                 InputCustomerCostCentre
        // content_1_PersonManage_InputCustomerCompanyRegistrationNumber_Input  InputCustomerCompanyRegistrationNumber
        // content_1_PersonManage_InputCustomerVatRegistrationNumber_Input
        // content_1_PersonManage_InputCustomerCreditReformNumber_Input
        // content_1_PersonManage_InputCustomerAuthorisedSignatory_Input
        // 
        // content_1_PersonManage_InputPersonFirstName_Input
        // content_1_PersonManage_InputPersonLastName_Input
        // content_1_PersonManage_InputPersonPosition_Input
        // content_1_PersonManage_InputPersonTelephone_Input
        // content_1_PersonManage_InputPersonMobile_Input
        // content_1_PersonManage_InputPersonEmail_Input
        // 
        // content_1_PersonManage_InputBankAccountNumber_Input
        // content_1_PersonManage_InputBankSortCode_Input
        // content_1_PersonManage_InputBankIban_Input
        // content_1_PersonManage_InputBankBic_Input
        // content_1_PersonManage_InputBankName_Input

        public static CustomerInformationPageValue Parse(ISeleniumHelper SeleniumHelper)
        {
            var value = new CustomerInformationPageValue();
            var main = SeleniumHelper.FindElementByCssSelector("#main");
            var inputList = main.FindElements(By.TagName("input"));
            var targetPrefix = "PersonManage";
            var regexStart = new Regex("^content_.+_PersonManage_");
            var regexEnd = new Regex("_Input$");
            foreach (var element in inputList)
            {
                var id = element.GetAttribute("id");
                var idArr = id.Split('_');
                if (element.GetAttribute("type") == "hidden") { continue; }
                if (regexStart.IsMatch(id) == false) { continue; }
                //if (targetPrefix.Equals(idArr[2]) == false) { continue; }
                var idKey = regexEnd.Replace(regexStart.Replace(id, ""),"");
                var key = idKey.Replace("_", ".");
                value.Add(key, element.GetAttribute("value"));
            }
            var selectList = main.FindElements(By.TagName("select"));
            foreach( var element in selectList)
            {
                var id = element.GetAttribute("id");
                var idArr = id.Split('_');
                if (targetPrefix.Equals(idArr[2]) == false) { continue; }
                var idKey = regexEnd.Replace(regexStart.Replace(id, ""), "");
                var key = idKey.Replace("_", ".");
                value.Add(key, new SelectElement(element).SelectedOption.Text);
            }
            return value;
        }
    }

}
