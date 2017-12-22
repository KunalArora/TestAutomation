using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Brother.WebSites.Core.Pages
{
    public static class PageObjectExtensions
    {
        private static Regex REGEX_DIGITONLY = new Regex(@"[^0-9.,]");

        public static IEnumerable<string> CollectDigitOnly(this IList<IWebElement> ellist)
        {
            var ans = ellist.Select(d => d.CollectDigitOnly());
            return ans;
        }
        public static string CollectDigitOnly(this IWebElement element)
        {
            return element.Text.CollectDigitOnly();
        }

        public static string CollectDigitOnly(this string text)
        {
            return REGEX_DIGITONLY.Replace(text, "");
        }

        public static IList<CustomerConsumablesDeviceItem> CreateElementValueList(this CustomerConsumablesDevicesPage page) 
        {
            const string divAlertInfoListSelector = "div.alert.alert-info";
            const string tbodyListSelector = "tbody.js-mps-searchable";
            var resultList = new List<CustomerConsumablesDeviceItem>();
            var seleniumHelper = page.SeleniumHelper;
            var divAlertInfoList = seleniumHelper.FindElementsByCssSelector(divAlertInfoListSelector);
            var tbodyList = seleniumHelper.FindElementsByCssSelector(tbodyListSelector);
            for( int idx = 0; idx < divAlertInfoList.Count; idx ++)
            {
                var divAlertInfo = divAlertInfoList[idx];
                var contractId = CollectDigitOnly(divAlertInfo);
                var tbody = tbodyList[idx];
                var trList = seleniumHelper.FindElementsByCssSelector(tbody, "tr");
                foreach( var tr in trList)
                {
                    var newItem = new CustomerConsumablesDeviceItem();
                    var tdList = seleniumHelper.FindElementsByCssSelector(tr, "td");
                    foreach( var td in tdList)
                    {
                        var tdId = td.GetAttribute("id");
                        if (tdId.Contains("_CellSerialNo_"))
                        {
                            newItem.CellSerialNo = td.Text;
                        }
                        else if (tdId.Contains("_CellModel_"))
                        {
                            newItem.CellModel = td.Text;
                        }
                        else if (tdId.Contains("_Cell_BU_"))
                        {
                            newItem.Cell_BU = td.Text;
                        }
                        else if (tdId.Contains("_Cell_DR_"))
                        {
                            newItem.Cell_DR = td.Text;
                        }
                        else if (tdId.Contains("_Cell_WU_"))
                        {
                            newItem.Cell_WU = td.Text;
                        }
                        else if (tdId.Contains("_Cell_BW_"))
                        {
                            newItem.Cell_BW = td.Text;
                        }
                        else if (tdId.Contains("_Cell_C_"))
                        {
                            newItem.Cell_C = td.Text;
                        }
                        else if (tdId.Contains("_Cell_M_"))
                        {
                            newItem.Cell_M = td.Text;
                        }
                        else if (tdId.Contains("_Cell_Y_"))
                        {
                            newItem.Cell_Y = td.Text;
                        }
                    }
                    newItem.ContractId = contractId;
                    resultList.Add(newItem);
                }
            }
            return resultList;

        }


    }
}
