using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Brother.Tests.Specs.Helpers
{
    public class PageParseHelper : IPageParseHelper
    {
        public SummaryPageValue ParseSummaryPageValues(BankProposalsSummaryPage page)
        {
            const string selectorCustomerAddress = "#MpsAppContent > div > div.tab-pane.active.container-fluid > div.row > div > div.col-sm-6.mps-bank-summary-left > div > div.panel-body.table-responsive > table > tbody > tr:nth-child(1) > td";
            const string selectorCustomerBillingAddress = "#MpsAppContent > div > div.tab-pane.active.container-fluid > div.row > div > div.col-sm-6.mps-bank-summary-left > div > div.panel-body.table-responsive > table > tbody > tr:nth-child(2) > td";
            const string selectorCustomerCreditFormNumber = "#MpsAppContent > div > div.tab-pane.active.container-fluid > div.row > div > div.col-sm-6.mps-bank-summary-left > div > div.panel-body.table-responsive > table > tbody > tr:nth-child(3) > td";
            const string selectorCustomerBank = "#MpsAppContent > div > div.tab-pane.active.container-fluid > div.row > div > div.col-sm-6.mps-bank-summary-left > div > div.panel-body.table-responsive > table > tbody > tr:nth-child(4) > td";
            const string selectorCustomerLegalForm = "#MpsAppContent > div > div.tab-pane.active.container-fluid > div.row > div > div.col-sm-6.mps-bank-summary-left > div > div.panel-body.table-responsive > table > tbody > tr:nth-child(5) > td";
            const string selectorCustomerCreditCheck = "#MpsAppContent > div > div.tab-pane.active.container-fluid > div.row > div > div.col-sm-6.mps-bank-summary-left > div > div.panel-body.table-responsive > table > tbody > tr:nth-child(6) > td";
            const string selectorDealerBrotherCustomerNumber = "#MpsAppContent > div > div.tab-pane.active.container-fluid > div.row > div > div.col-sm-6.mps-bank-summary-right > div:nth-child(1) > div.panel-body.table-responsive > table > tbody > tr:nth-child(1) > td > span";
            const string selectorDealerAddress = "#MpsAppContent > div > div.tab-pane.active.container-fluid > div.row > div > div.col-sm-6.mps-bank-summary-right > div:nth-child(1) > div.panel-body.table-responsive > table > tbody > tr:nth-child(2) > td";

            var SeleniumHelper = page.SeleniumHelper;
            var value = ParseSummaryPageValues(SeleniumHelper, "BankSummaryTable");

            // add custom parse below...

            //
            // Customer details (de:Kundendetails)
            //
            var prefix = "CustomerDetails";
            // de:Kundendetails>Adresse
            var tdCustomerAddress = SeleniumHelper.FindElementByCssSelector(selectorCustomerAddress);
            value.Add(prefix + "Address", ParseToStrongKeyAndBrValueList(tdCustomerAddress).Value);
            // de:Kundendetails>Rechnungsadresse
            var tdCustomerBillingAddress = SeleniumHelper.FindElementByCssSelector(selectorCustomerBillingAddress);
            value.Add(prefix + "BillingAddress", ParseToStrongKeyAndBrValueList(tdCustomerBillingAddress).Value);
            // Creditreform number (de:Creditreform Nummer)
            var tdCustomerCreditformNumber = SeleniumHelper.FindElementByCssSelector(selectorCustomerCreditFormNumber);
            value.Add(prefix + "CreditreformNumber", tdCustomerCreditformNumber.FindElement(By.TagName("span")).Text);
            // Bank
            var tdCustomerBank = SeleniumHelper.FindElementByCssSelector(selectorCustomerBank);
            var bankSpanList = tdCustomerBank.FindElements(By.TagName("span"));
            value.Add(prefix + "BankName", bankSpanList[0].Text); // Bank
            value.Add(prefix + "BankCode", bankSpanList[1].Text); // de:Bankleitzahl 
            value.Add(prefix + "BankNumber", bankSpanList[2].Text); // de:Kontonummer 
            value.Add(prefix + "IBAN", bankSpanList[3].Text); // de:IBAN  
            value.Add(prefix + "BIC", bankSpanList[4].Text); // de:BIC  
            // de:Rechtsform
            var tdCustomerLegalForm = SeleniumHelper.FindElementByCssSelector(selectorCustomerLegalForm);
            value.Add(prefix + "LegalForm", tdCustomerLegalForm.FindElement(By.TagName("span")).Text);
            // de:Bonitätsprüfung
            var tdCustomerCreditCheck = SeleniumHelper.FindElementByCssSelector(selectorCustomerCreditCheck);
            value.Add(prefix + "CreditCheck", tdCustomerCreditCheck.FindElement(By.TagName("span")).Text);

            //
            // Dealer Details (de:Händler Details)
            //
            prefix = "DealerDetails";
            // Brother customer number (de:Brother Kundennummer )
            var spanDealerBrotherCustomerNumber = SeleniumHelper.FindElementByCssSelector(selectorDealerBrotherCustomerNumber);
            value.Add(prefix + "BrotherCustomerNumber", spanDealerBrotherCustomerNumber.Text);
            // de:Adresse
            var tdDealerAddress = SeleniumHelper.FindElementByCssSelector(selectorDealerAddress);
            value.Add(prefix + "Address", ParseToStrongKeyAndBrValueList(tdDealerAddress).Value);

            //
            // Contract details (de:Vertragsdetails) 
            // custom parse unnecessary
            //
            // Reference information:
            // content_1_BankSummaryTable_ContractDetailsContractNumber             noch nicht gesetzt 
            // content_1_BankSummaryTable_LabelContractDetailsDuration              5 Jahre
            // content_1_BankSummaryTable_ContractDetailsStartDate                  11.04.2018
            // content_1_BankSummaryTable_ContractDetailsBillingFrequencyLeasing    Monatlich
            // content_1_BankSummaryTable_ContractDetailsBillingFrequencyClick      Halbjährlich
            // content_1_BankSummaryTable_ContractDetailsContractValue              2.959,66 €
            // content_1_BankSummaryTable_ContractDetailsLeasingFactor              1,66700%
            // content_1_BankSummaryTable_ContractDetailsBillingRate                49,33 €
            // content_1_BankSummaryTable_ContractDetailsSumOfRates                 2.959,80 €
            //
            return value;

        }

        private static KeyValuePair<string, string> ParseToStrongKeyAndBrValueList(IWebElement tdAddress)
        {
            var strong = tdAddress.FindElement(By.TagName("strong"));
            var key = strong.Text;
            var brValue = tdAddress.Text.Substring(key.Length + 2); // remove key string and first CRLF
            return new KeyValuePair<string, string>(key, brValue.Trim());
        }

        public SummaryPageValue ParseSummaryPageValues(ISeleniumHelper SeleniumHelper, string targetPrefix = "SummaryTable")
        {
            var value = new SummaryPageValue();

            var main = SeleniumHelper.FindElementByCssSelector("#main");
            var tdElementListMain = main.FindElements(By.TagName("td"));
            foreach (var tdElement in tdElementListMain)
            {
                var idString = tdElement.GetAttribute("id"); // ex. content_1_SummaryTable_ProposalName
                var idArr = idString.Split('_');
                if (idArr.Length < 2) continue;
                var itemName = idArr[idArr.Length - 1]; // ex. ProposalName
                var prefix = idArr[idArr.Length - 2]; // ex. SummaryTable
                if (targetPrefix.Equals(prefix) == false) { continue; }
                var dictKey = string.Format("{0}.{1}", prefix, itemName);// key ex. SummaryTable.ProposalName
                value.Add(dictKey, tdElement.Text);
            }

            var modelElementList = SeleniumHelper.FindElementsByCssSelector("div[class*=\"panel panel-default mps-qa-printer mps-qa-printer-\"]");
            foreach (var modelElement in modelElementList)
            {
                var elemStrong = modelElement.FindElement(By.ClassName("panel-heading")).FindElement(By.TagName("strong"));
                var modelName = elemStrong.Text; // ex. MFC-L8650CDW
                var tdElementList = modelElement.FindElements(By.TagName("td"));
                foreach (var tdElement in tdElementList)
                {
                    var idString = tdElement.GetAttribute("id"); // ex. content_1_SummaryTable_RepeaterModels_RepeaterInstallationPacks_3_InstallationPackUnitCost_0
                    var idArr = idString.Split('_');
                    if (idArr.Length < 2) continue;
                    var itemName = idArr[idArr.Length - 2]; // ex. InstallationPackUnitCost
                    var dictKey = string.Format("{0}.{1}", modelName, itemName);// key ex. MFC-L8650CDW.InstallationPackUnitCost
                    value.Add(dictKey, tdElement.Text);
                }
            }

            //Parsing the billing dates
            try
            {
                var billingDatesList = main.FindElement(By.CssSelector(".mps-billing-dates-container"));
                var billingDatesBodyElement = billingDatesList.FindElement(By.TagName("tbody"));
                var billingDatesBodyTrElements = billingDatesBodyElement.FindElements(By.TagName("tr"));
                var prefix = "BillingDates";
                value.Add(prefix + ".Count", billingDatesBodyTrElements.Count.ToString());
                var tdElementListBillingDates = billingDatesList.FindElements(By.TagName("td"));
                foreach (var tdElement in tdElementListBillingDates)
                {
                    var idString = tdElement.GetAttribute("id"); // ex. content_0_BillingDatesList_BillingDates_CellStartDate_0
                    var idArr = idString.Split('_');
                    if (idArr.Length < 2) continue;
                    var rowNo = Int32.Parse(idArr[idArr.Length - 1] + 1).ToString(); // ex. 1
                    var itemName = idArr[idArr.Length - 2]; // ex. CellStartDate
                    var dictKey = string.Format("{0}.{1}.{2}", prefix, rowNo, itemName);// key ex. BillingDates.1.CellStartDate
                    value.Add(dictKey, tdElement.Text);
                }
            }
            catch (NoSuchElementException)
            {
                //ignore
            }

            //PArsing the proposal start date
            try
            {
                var dateElement = main.FindElement(By.Id("content_1_InputEnvisagedStartDate_Input"));
                value.Add("InputEnvisagedStartDate", dateElement.GetAttribute("value")); 
            }
            catch (NoSuchElementException)
            {
                // ignored
            }

            return value;
        }


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
        public CustomerInformationPageValue ParseCustomerInformationPageValues(ISeleniumHelper SeleniumHelper)
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
                var idKey = regexEnd.Replace(regexStart.Replace(id, ""), "");
                var key = idKey.Replace("_", ".");
                value.Add(key, element.GetAttribute("value"));
            }
            var selectList = main.FindElements(By.TagName("select"));
            foreach (var element in selectList)
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

        public ClickPricePageValue ParseClickPricePageValues(ISeleniumHelper SeleniumHelper)
        {
            var value = new ClickPricePageValue();
            var clickPriceGroupList = SeleniumHelper.FindElementsByCssSelector("[id*=_LineItems_ClickPriceGroup_]");
            foreach (var clickPriceGroupElement in clickPriceGroupList)
            {
                var model = clickPriceGroupElement.GetAttribute("data-model"); // MFC-L8650CDW
                var inputElementList = clickPriceGroupElement.FindElements(By.TagName("input"));
                foreach (var inputElement in inputElementList)
                {
                    var idString = inputElement.GetAttribute("id"); // ex. content_1_LineItems_InputMonoCoverage_0
                    var idArr = idString.Split('_');
                    if (idArr.Length < 2) continue;
                    var itemName = idArr[idArr.Length - 2]; // ex. InputMonoCoverage
                    var dictKey = string.Format("{0}.{1}", model, itemName);// key ex. MFC-L8650CDW.InputMonoCoverage
                    value.Add(dictKey, inputElement.GetAttribute("value"));
                }
                var spanElementList = clickPriceGroupElement.FindElements(By.TagName("span"));
                var monoPriceElement = spanElementList.FirstOrDefault(e => e.GetAttribute("data-click-price-mono") != null);
                var colourPriceElement = spanElementList.FirstOrDefault(e => e.GetAttribute("data-click-price-colour") != null);
                if (monoPriceElement != null && monoPriceElement.Displayed) { value.Add(string.Format("{0}.ClickPriceMono", model), monoPriceElement.Text); }
                if (colourPriceElement != null && colourPriceElement.Displayed) { value.Add(string.Format("{0}.ClickPriceColour", model), colourPriceElement.Text); }
            }

            return value;
        }

    }

    public class SummaryPageValue : Dictionary<string, string>
    {
        public string GetModel(string key)
        {
            return key.Split('.')[0];
        }
    }
    public class CustomerInformationPageValue : Dictionary<string, string>
    {
        // For the future
    }

    public class ClickPricePageValue : Dictionary<string, string>
    {
        // For the future
    }


}
