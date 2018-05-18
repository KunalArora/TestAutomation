using Brother.Tests.Common.Logging;
using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement;
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
        private ILoggingService LoggingService { get; set; }

        public PageParseHelper(ILoggingService loggingService)
        {
            LoggingService = loggingService;
        }

        public SummaryPageValue ParseSummaryPageValues(BankProposalsSummaryPage page)
        {
            LoggingService.WriteLogOnMethodEntry(page);
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
            LoggingService.WriteLogOnMethodEntry(SeleniumHelper, targetPrefix);
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


        /// <summary>
        /// parse values
        /// </summary>
        /// <param name="SeleniumHelper">in</param>
        /// <returns>
        /// for example keys:
        /// ID(in)                                                               KEY(returns)
        /// content_1_PersonManage_InputCustomerName                             InputCustomerName
        /// content_1_PersonManage_CustomerLocation_InputStreet_Input            CustomerLocation.InputStreet
        /// content_1_PersonManage_CustomerLocation_InputNumber_Input
        /// content_1_PersonManage_CustomerLocation_InputPostCode_Input
        /// content_1_PersonManage_CustomerLocation_InputTown_Input
        /// content_1_PersonManage_CustomerLocation_InputArea_Input
        /// content_1_PersonManage_InputCustomerCostCentre_Input                 InputCustomerCostCentre
        /// content_1_PersonManage_InputCustomerCompanyRegistrationNumber_Input  InputCustomerCompanyRegistrationNumber
        /// content_1_PersonManage_InputCustomerVatRegistrationNumber_Input
        /// content_1_PersonManage_InputCustomerCreditReformNumber_Input
        /// content_1_PersonManage_InputCustomerAuthorisedSignatory_Input
        /// 
        /// content_1_PersonManage_InputPersonFirstName_Input
        /// content_1_PersonManage_InputPersonLastName_Input
        /// content_1_PersonManage_InputPersonPosition_Input
        /// content_1_PersonManage_InputPersonTelephone_Input
        /// content_1_PersonManage_InputPersonMobile_Input
        /// content_1_PersonManage_InputPersonEmail_Input
        /// 
        /// content_1_PersonManage_InputBankAccountNumber_Input
        /// content_1_PersonManage_InputBankSortCode_Input
        /// content_1_PersonManage_InputBankIban_Input
        /// content_1_PersonManage_InputBankBic_Input
        /// content_1_PersonManage_InputBankName_Input
        /// </returns>
        public CustomerInformationPageValue ParseCustomerInformationPageValues(ISeleniumHelper SeleniumHelper)
        {
            LoggingService.WriteLogOnMethodEntry(SeleniumHelper);
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
            LoggingService.WriteLogOnMethodEntry(SeleniumHelper);
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


        /// <summary>
        /// parse values
        /// </summary>
        /// <param name="dealerAgreementDevicesPage">in</param>
        /// <returns>
        ///for exmaple:
        ///{[Devices.0.Choice, False]}
        ///{[Devices.0.Model, HL-5470DW]}
        ///{[Devices.0.InstalledPrinterId, 163004]}
        ///{[Devices.0.SerialNo, GB1732801]}
        ///{[Devices.0.Status, Installed<br />Type: Cloud<br />Status: Responding]}
        ///{[Devices.0.StatusIcon, glyphicon glyphicon-cloud js-mps-tooltip]}
        ///{[Devices.0.Address, Wishing Bay_180510154544 Ltd, 4526 Wishing Bay, Rose maple hill, Kentish Town, HA2 9EF]}
        ///{[Devices.0.MeterRead.0.Date, 08/03/2018 7:47 AM]}
        ///{[Devices.0.MeterRead.0.Colour, -]}
        ///{[Devices.0.MeterRead.0.Mono, 2100]}
        ///{[Devices.0.MeterRead.0.Total, 2100]}
        ///{[Devices.0.MeterRead.1.Date, 08/03/2018 7:46 AM]}
        ///{[Devices.0.MeterRead.1.Colour, -]}
        ///{[Devices.0.MeterRead.1.Mono, -]}
        ///{[Devices.0.MeterRead.1.Total, -]}
        ///{[Devices.0.MeterRead.Count, 2]}
        ///{[Devices.1.Choice, False]}
        ///{[Devices.1.Model, HL-5470DW]}
        ///{[Devices.1.InstalledPrinterId, 163005]}
        ///{[Devices.1.SerialNo, GB1732802]}
        ///{[Devices.1.Status, Installed<br />Type: Cloud<br />Status: Responding]}
        ///{[Devices.1.StatusIcon, glyphicon glyphicon-cloud js-mps-tooltip]}
        ///{[Devices.1.Address, Wishing Bay_180510154544 Ltd, 4526 Wishing Bay, Rose maple hill, Kentish Town, HA2 9EF]}
        ///{[Devices.1.MeterRead.0.Date, 08/03/2018 7:47 AM]}
        ///{[Devices.1.MeterRead.0.Colour, -]}
        ///{[Devices.1.MeterRead.0.Mono, 2100]}
        ///{[Devices.1.MeterRead.0.Total, 2100]}
        ///{[Devices.1.MeterRead.1.Date, 08/03/2018 7:47 AM]}
        ///{[Devices.1.MeterRead.1.Colour, -]}
        ///{[Devices.1.MeterRead.1.Mono, -]}
        ///{[Devices.1.MeterRead.1.Total, -]}
        ///{[Devices.1.MeterRead.Count, 2]}
        ///{[Devices.Count, 2]}
        /// </returns>
        public DealerAgreementDeviceValue ParseDealerAgreementDevicesPage(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage);
            var value = new DealerAgreementDeviceValue();
            var deviceTbodySelector = "#DataTables_Table_0 > tbody";
            var mrTbodySelector = "#MeterReadingModal > div > div > div.js-mps-print-counts-list > div.modal-body > table > tbody";
            var mrCloseSelector = "#MeterReadingModal > div > div > div.js-mps-print-counts-list > div.modal-header > button";
            var SeleniumHelper = dealerAgreementDevicesPage.SeleniumHelper;

            int rowDevices = 0;
            var prefixDevices = "Devices";
            SeleniumHelper
                .FindElementByCssSelector(deviceTbodySelector)
                .FindElements(By.TagName("tr"))
                .All(tr => 
                {
                    // Devices
                    var inputChoice = IgnoreThrow( ()=>tr.FindElement(By.CssSelector("input[id*='_Devices_Choice_']")), "Checkbox row={0}",rowDevices);
                    var tdModel = IgnoreThrow(() => tr.FindElement(By.CssSelector("td[id*='_Devices_ModelCell_']")), "Model row={0}", rowDevices);
                    var tdSerial = IgnoreThrow(() => tr.FindElement(By.CssSelector("td:nth-child(3)")), "SerialNumber row={0}", rowDevices);
                    var spanStatusIcon = IgnoreThrow(() => tr.FindElement(By.CssSelector("span[id*='_Devices_StatusIcon_']")), "StatusIcon row={0}", rowDevices);
                    var tdAddress = IgnoreThrow(() => tr.FindElement(By.CssSelector("td:nth-child(5)")), "Address row={0}", rowDevices);
                    IgnoreThrow(() => value.Add(string.Format(prefixDevices+".{0}.Choice", rowDevices), inputChoice.Selected.ToString()), "Checkbox.value row={0}", rowDevices); // ex. False
                    IgnoreThrow(() => value.Add(string.Format(prefixDevices+".{0}.Model", rowDevices), TrimAll(tdModel.Text)), "Model.value row={0}", rowDevices); // ex. HL-5470DW
                    IgnoreThrow(() => value.Add(string.Format(prefixDevices+".{0}.InstalledPrinterId", rowDevices), tdModel.GetAttribute("installed-printer-id")), "InstalledPrinterId.value row={0}", rowDevices); // ex. 162941
                    IgnoreThrow(() => value.Add(string.Format(prefixDevices+".{0}.SerialNo", rowDevices), TrimAll(tdSerial.Text)), "SerialNo.value row={0}", rowDevices); // ex. GB1732591
                    IgnoreThrow(() => value.Add(string.Format(prefixDevices+".{0}.Status", rowDevices), spanStatusIcon.GetAttribute("data-original-title")), "Status.value row={0}", rowDevices); // ex. "Installed<br />Type: Cloud<br />Status: Responding"
                    IgnoreThrow(() => value.Add(string.Format(prefixDevices+".{0}.StatusIcon", rowDevices), spanStatusIcon.GetAttribute("class")), "StatusIcon.value row={0}", rowDevices); // ex. "glyphicon glyphicon-cloud js-mps-tooltip"
                    IgnoreThrow(() => value.Add(string.Format(prefixDevices+".{0}.Address", rowDevices), TrimAll(tdAddress.Text)), "Address.value row={0}", rowDevices); // ex. "Fallen Pond_180510103153 Ltd, 5995 Fallen Pond Campus, Piccadily, Camden, PR9 9GL"


                    // Devices > Meter Read
                    SeleniumHelper.ClickSafety(tr.FindElement(By.TagName("button")));
                    SeleniumHelper.ClickSafety(tr.FindElement(By.CssSelector(".js-mps-view-print-count")));
                    var mrTable = SeleniumHelper.FindElementByCssSelector(mrTbodySelector);
                    var mrClose = SeleniumHelper.FindElementByCssSelector(mrCloseSelector);

                    string prefixMeterRead = string.Format(prefixDevices + ".{0}.MeterRead", rowDevices);
                    int rowMeterRead = 0;                    
                    mrTable.FindElements(By.TagName("tr")).All(mtr =>
                    {
                        var tdDate = IgnoreThrow(() => mtr.FindElement(By.CssSelector(".mps-print-count-date")), "PrintCount.Date row=({0},{1})", rowDevices,rowMeterRead);
                        var tdColour = IgnoreThrow(() => mtr.FindElement(By.CssSelector(".mps-print-count-colour")), "PrintCount.Colour row=({0},{1})", rowDevices, rowMeterRead);
                        var tdMono = IgnoreThrow(() => mtr.FindElement(By.CssSelector(".mps-print-count-mono")), "PrintCount.Mono row=({0},{1})", rowDevices, rowMeterRead);
                        var tdTotal = IgnoreThrow(() => mtr.FindElement(By.CssSelector(".mps-print-count-total")), "PrintCount.Total row=({0},{1})", rowDevices, rowMeterRead);
                        IgnoreThrow(() => value.Add(string.Format(prefixMeterRead + ".{0}.Date", rowMeterRead), tdDate.Text.Trim()), "PrintCount.Date.value row=({0},{1})", rowDevices, rowMeterRead); // ex. 08/03/2018 2:33 AM
                        IgnoreThrow(() => value.Add(string.Format(prefixMeterRead + ".{0}.Colour", rowMeterRead), tdColour.Text.Trim()), "PrintCount.Colour.value row=({0},{1})", rowDevices, rowMeterRead); // ex. -
                        IgnoreThrow(() => value.Add(string.Format(prefixMeterRead + ".{0}.Mono", rowMeterRead), tdMono.Text.Trim()), "PrintCount.Mono.value row=({0},{1})", rowDevices, rowMeterRead); // ex. 2100
                        IgnoreThrow(() => value.Add(string.Format(prefixMeterRead + ".{0}.Total", rowMeterRead), tdTotal.Text.Trim()), "PrintCount.Total.value row=({0},{1})", rowDevices, rowMeterRead); // ex. 2100

                        rowMeterRead++;
                        return true;
                    });
                    value.Add(prefixMeterRead + ".Count", rowMeterRead.ToString());
                    SeleniumHelper.ClickSafety(mrClose);

                    rowDevices++;
                    return true;
                });
            value.Add(prefixDevices+".Count",rowDevices.ToString());

            return value;
        }

        /// <summary>
        /// parse values
        /// </summary>
        /// <param name="dealerAgreementServiceRequestsPage">in</param>
        /// <returns>
        /// ex.
        /// {[ServiceRequests.0.Model, HL-5470DW]}
        /// {[ServiceRequests.0.SerialNumber, GB1733572]}
        /// {[ServiceRequests.0.Status, Closed]}
        /// {[ServiceRequests.0.RequestType, Machine not printing]}
        /// {[ServiceRequests.0.Subject, Minor issue]}
        /// {[ServiceRequests.0.RaisedDate, 09/03/2018]}
        /// {[ServiceRequests.0.ClosedDate, 09/03/2018]}
        /// {[ServiceRequests.1.Model, HL-5470DW]}
        /// {[ServiceRequests.1.SerialNumber, GB1733571]}
        /// {[ServiceRequests.1.Status, Closed]}
        /// {[ServiceRequests.1.RequestType, General machine use]}
        /// {[ServiceRequests.1.Subject, Minor issue]}
        /// {[ServiceRequests.1.RaisedDate, 09/03/2018]}
        /// {[ServiceRequests.1.ClosedDate, 09/03/2018]}
        /// {[ServiceRequests.Count, 2]}
        /// </returns>
        public DealerAgreementServiceRequestsValue ParseDealerAgreementServiceRequestsPage(DealerAgreementServiceRequestsPage dealerAgreementServiceRequestsPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementServiceRequestsPage);
            var value = new DealerAgreementServiceRequestsValue();
            var SeleniumHelper = dealerAgreementServiceRequestsPage.SeleniumHelper;

            var prefix = "ServiceRequests";
            var rowDevices = 0;
            SeleniumHelper
                .FindElementsByCssSelector("tr[id*='_ServiceRequests_Row_']")
                .All(tr =>
                {
                    // ex.
                    //  Model       SerialNumber Status  RequestType    Subject     Date Raised  Date Closed
                    //  HL-5470DW	GB1733262	 Closed	 Print Quality	Major issue	09/03/2018	 09/03/2018
                    var tdModel = IgnoreThrow(() => tr.FindElement(By.CssSelector("td:nth-child(2)")), "Model row={0}", rowDevices);
                    var tdSerialNumber = IgnoreThrow(() => tr.FindElement(By.CssSelector("td:nth-child(3)")), "SerialNumber row={0}", rowDevices);
                    var tdStatus = IgnoreThrow(() => tr.FindElement(By.CssSelector("td:nth-child(4)")), "Status row={0}", rowDevices);
                    var tdRequestType = IgnoreThrow(() => tr.FindElement(By.CssSelector("td:nth-child(5)")), "RequestType row={0}", rowDevices);
                    var tdSubject = IgnoreThrow(() => tr.FindElement(By.CssSelector("td:nth-child(6)")), "Subject row={0}", rowDevices);
                    var tdRaisedDate = IgnoreThrow(() => tr.FindElement(By.CssSelector("td[id*='_ServiceRequests_DateRaisedRow_']")), "RaisedDate row={0}", rowDevices);
                    var tdClosedDate = IgnoreThrow(() => tr.FindElement(By.CssSelector("td[id*='_ServiceRequests_DateClosedRow_']")), "ClosedDate row={0}", rowDevices);
                    IgnoreThrow(() => value.Add(string.Format(prefix + ".{0}.Model", rowDevices), tdModel.Text), "Model.value row={0}", rowDevices); // HL-5470DW
                    IgnoreThrow(() => value.Add(string.Format(prefix + ".{0}.SerialNumber", rowDevices), tdSerialNumber.Text), "SerialNumber.value row={0}", rowDevices); // GB1733262
                    IgnoreThrow(() => value.Add(string.Format(prefix + ".{0}.Status", rowDevices), tdStatus.Text), "Status.value row={0}", rowDevices); // Closed
                    IgnoreThrow(() => value.Add(string.Format(prefix + ".{0}.RequestType", rowDevices), tdRequestType.Text), "RequestType.value row={0}", rowDevices); // Print Quality
                    IgnoreThrow(() => value.Add(string.Format(prefix + ".{0}.Subject", rowDevices), tdSubject.Text), "Subject.value row={0}", rowDevices); // Major issue
                    IgnoreThrow(() => value.Add(string.Format(prefix + ".{0}.RaisedDate", rowDevices), tdRaisedDate.Text), "RaisedDate.value row={0}", rowDevices); // 09/03/2018
                    IgnoreThrow(() => value.Add(string.Format(prefix + ".{0}.ClosedDate", rowDevices), tdClosedDate.Text), "ClosedDate.value row={0}", rowDevices); // 09/03/2018

                    rowDevices++;
                    return true;
                });
            value.Add(prefix + ".Count", rowDevices.ToString());
            return value;
        }

        /// <summary>
        /// parse values
        /// </summary>
        /// <param name="dealerAgreementConsumablesPage">in</param>
        /// <returns>
        /// ex.
        /// {[Consumables.0.Model, HL-5470DW]}
        /// {[Consumables.0.SerialNumber, GB1733572]}
        /// {[Consumables.0.OrderId, 0004858417]}
        /// {[Consumables.0.OrderDate, 11/05/2018]}
        /// {[Consumables.0.ItemName, Black]}
        /// {[Consumables.0.SkuOrder, TN3380P]}
        /// {[Consumables.0.Status, In Progress]}
        /// {[Consumables.0.OrderMethod, Manual]}
        /// {[Consumables.1.Model, HL-5470DW]}
        /// {[Consumables.1.SerialNumber, GB1733571]}
        /// {[Consumables.1.OrderId, 0004858416]}
        /// {[Consumables.1.OrderDate, 11/05/2018]}
        /// {[Consumables.1.ItemName, Black]}
        /// {[Consumables.1.SkuOrder, TN3380P]}
        /// {[Consumables.1.Status, In Progress]}
        /// {[Consumables.1.OrderMethod, Manual]}
        /// {[Consumables.Count, 2]}
        /// </returns>
        public DealerAgreementConsumablesValue ParseDealerAgreementConsumablesPage(DealerAgreementConsumablesPage dealerAgreementConsumablesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementConsumablesPage);
            var value = new DealerAgreementConsumablesValue();
            var tbodySelector = "#DataTables_Table_0 > tbody";
            var SeleniumHelper = dealerAgreementConsumablesPage.SeleniumHelper;

            var prefix = "Consumables";
            var rowDevices = 0;
            SeleniumHelper
                .FindElementByCssSelector(tbodySelector)
                .FindElements(By.TagName("tr"))
                .All(tr =>
                {
                    // ex.
                    // Model      Serial No Order Id   Order Date  Item Name SKU Order  Status      Order Method
                    // HL-5470DW  GB1733262	0004858395 09/03/2018  Black     TN3380P    In Progress	Manual	
                    var tdModel = IgnoreThrow(() => tr.FindElement(By.CssSelector("td:nth-child(1)")), "Model row={0}", rowDevices);
                    var tdSerialNumber = IgnoreThrow(() => tr.FindElement(By.CssSelector("td:nth-child(2)")), "SerialNumber row={0}", rowDevices);
                    var tdOrderId = IgnoreThrow(() => tr.FindElement(By.CssSelector("td:nth-child(3)")), "OrderId row={0}", rowDevices);
                    var tdOrderDate = IgnoreThrow(() => tr.FindElement(By.CssSelector("td[id*='_Consumables_OrderDateRow_']")), "OrderDate row={0}", rowDevices);
                    var tdItemName = IgnoreThrow(() => tr.FindElement(By.CssSelector("td:nth-child(5)")), "ItemName row={0}", rowDevices);
                    var tdSkuOrder = IgnoreThrow(() => tr.FindElement(By.CssSelector("td:nth-child(6)")), "SkuOrder row={0}", rowDevices);
                    var tdStatus = IgnoreThrow(() => tr.FindElement(By.CssSelector("td:nth-child(7)")), "Status row={0}", rowDevices);
                    var tdOrderMethod = IgnoreThrow(() => tr.FindElement(By.CssSelector("td:nth-child(8)")), "OrderMethod row={0}", rowDevices);
                    IgnoreThrow(() => value.Add(string.Format(prefix + ".{0}.Model", rowDevices), tdModel.Text), "Model.value row={0}", rowDevices); // HL-5470DW
                    IgnoreThrow(() => value.Add(string.Format(prefix + ".{0}.SerialNumber", rowDevices), tdSerialNumber.Text), "SerialNumber.value row={0}", rowDevices); // GB1733262
                    IgnoreThrow(() => value.Add(string.Format(prefix + ".{0}.OrderId", rowDevices), tdOrderId.Text), "OrderId.value row={0}", rowDevices); // 0004858395
                    IgnoreThrow(() => value.Add(string.Format(prefix + ".{0}.OrderDate", rowDevices), tdOrderDate.Text), "OrderDate.value row={0}", rowDevices); // 09/03/2018
                    IgnoreThrow(() => value.Add(string.Format(prefix + ".{0}.OrderDate-data-sort", rowDevices), tdOrderDate.GetAttribute("data-sort")), "OrderDate-data-sort.value row={0}", rowDevices); // 2018-03-09T03:57:32Z
                    IgnoreThrow(() => value.Add(string.Format(prefix + ".{0}.ItemName", rowDevices), tdItemName.Text), "ItemName.value row={0}", rowDevices); // Black
                    IgnoreThrow(() => value.Add(string.Format(prefix + ".{0}.SkuOrder", rowDevices), tdSkuOrder.Text), "SkuOrder.value row={0}", rowDevices); // TN3380P
                    IgnoreThrow(() => value.Add(string.Format(prefix + ".{0}.Status", rowDevices), tdStatus.Text), "Status.value row={0}", rowDevices); // In Progress
                    IgnoreThrow(() => value.Add(string.Format(prefix + ".{0}.OrderMethod", rowDevices), tdOrderMethod.Text), "OrderMethod.value row={0}", rowDevices); // Manual
                    rowDevices++;
                    return true;
                });
            value.Add(prefix + ".Count", rowDevices.ToString());
            return value;
        }

        /// <summary>
        /// parse values
        /// </summary>
        /// <param name="dic">in. example.
        /// {[ServiceRequests.0.Model, HL-5470DW]}
        /// {[ServiceRequests.0.SerialNumber, GB1734802]}
        /// {[ServiceRequests.0.Status, Closed]}
        /// {[ServiceRequests.0.RequestType, Other faults]}
        /// {[ServiceRequests.0.Subject, Major issue]}
        /// {[ServiceRequests.0.RaisedDate, 12/03/2018]}
        /// {[ServiceRequests.0.ClosedDate, 12/03/2018]}
        /// {[ServiceRequests.1.Model, HL-5470DW]}
        /// {[ServiceRequests.1.SerialNumber, GB1734801]}
        /// {[ServiceRequests.1.Status, Closed]}
        /// {[ServiceRequests.1.RequestType, Machine not printing]}
        /// {[ServiceRequests.1.Subject, Minor issue]}
        /// {[ServiceRequests.1.RaisedDate, 12/03/2018]}
        /// {[ServiceRequests.1.ClosedDate, 12/03/2018]}
        /// {[ServiceRequests.Count, 2]}
        /// </param>
        /// <param name="prefix">prefix key. ex."ServiceRequests"</param>
        /// <param name="count">count of arrays.if -1(def) get ${prefix}.Count from dic. ex. dic['ServiceRequests.Count'] </param>
        /// <returns>arrays. ex.
        /// dicArray	Count = 2	System.Collections.Genericr.List<System.Collections.Generic.Dictionary<string, string>>
        /// [0]	Count = 7	System.Collections.Generic.Dictionary<string, string>
        /// [0]	{[Model, HL-5470DW]}	System.Collections.Generic.KeyValuePair<string, string>
        /// [1]	{[SerialNumber, GB1734862]}	System.Collections.Generic.KeyValuePair<string, string>
        /// [2]	{[Status, Closed]}	System.Collections.Generic.KeyValuePair<string, string>
        /// [3]	{[RequestType, Changing supplies]}	System.Collections.Generic.KeyValuePair<string, string>
        /// [4]	{[Subject, Critical issue]}	System.Collections.Generic.KeyValuePair<string, string>
        /// [5]	{[RaisedDate, 12/03/2018]}	System.Collections.Generic.KeyValuePair<string, string>
        /// [6]	{[ClosedDate, 12/03/2018]}	System.Collections.Generic.KeyValuePair<string, string>
        /// Raw View		
        /// [1]	Count = 7	System.Collections.Generic.Dictionary<string, string>
        /// [0]	{[Model, HL-5470DW]}	System.Collections.Generic.KeyValuePair<string, string>
        /// [1]	{[SerialNumber, GB1734861]}	System.Collections.Generic.KeyValuePair<string, string>
        /// [2]	{[Status, Closed]}	System.Collections.Generic.KeyValuePair<string, string>
        /// [3]	{[RequestType, Print Quality]}	System.Collections.Generic.KeyValuePair<string, string>
        /// [4]	{[Subject, Critical issue]}	System.Collections.Generic.KeyValuePair<string, string>
        /// [5]	{[RaisedDate, 12/03/2018]}	System.Collections.Generic.KeyValuePair<string, string>
        /// [6]	{[ClosedDate, 12/03/2018]}	System.Collections.Generic.KeyValuePair<string, string>
        /// Raw View
        /// </returns>
        public List<Dictionary<string,string>> ToList(Dictionary<string, string> dic, string prefix, int count =-1)
        {
            LoggingService.WriteLogOnMethodEntry(dic,prefix,count);
            prefix = prefix + ".";
            count = count >= 0 ? count : int.Parse(dic[prefix+"Count"]);
            var regex = new Regex("^"+Regex.Escape(prefix));
            var dicArray = new List<Dictionary<string,string>>(count);
            for (int cnt = 0; cnt < count; cnt++) { dicArray.Add(new Dictionary<string, string>()); };
            dic.Where(kvp => kvp.Key.StartsWith(prefix))
                .All(kvp =>
               {
                   var keyarr = regex.Replace(kvp.Key, "").Split('.');
                   int idx;
                   if (int.TryParse(keyarr[0], out idx) == false) { return true; } // skip if false.
                   var list = keyarr.ToList();
                   list.RemoveAt(0);
                   var key = string.Join(".", list);
                   dicArray[idx].Add(key, kvp.Value);

                   return true;
               });
            return dicArray;
        }

        private string TrimAll(string text)
        {
            return text.Replace("\r", "").Replace("\n", "").Trim();
        }

        private T IgnoreThrow<T>(Func<T> p, string format=null, params object[] args )
        {
            try
            {
                return p();
            }
            catch (Exception e)
            {
                if( format != null)
                {
                    var message = string.Format(format, args);
                    LoggingService.WriteLog(LoggingLevel.WARNING, (object)message, e);
                }
                return default(T);
            }
        }
        private void IgnoreThrow(Action p, string format=null, params object[] args)
        {
            try
            {
                p();
            }
            catch (Exception e)
            {
                if( format != null)
                {
                    var message = string.Format(format, args);
                    LoggingService.WriteLog(LoggingLevel.WARNING, (object)message, e);
                }
            }
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

    public class DealerAgreementDeviceValue : Dictionary<string, string>
    {
        // For the future
    }

    public class DealerAgreementServiceRequestsValue : Dictionary<string, string>
    {
        // For the future
    }

    public class DealerAgreementConsumablesValue : Dictionary<string, string>
    {
        // For the future
    }


}
