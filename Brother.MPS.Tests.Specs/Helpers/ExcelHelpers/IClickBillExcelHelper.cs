using System;
using System.IO;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public interface IClickBillExcelHelper
    {
        /// <summary>
        /// download excel
        /// </summary>
        /// <param name="clickOnDownloadFunc">ex. element.click()</param>
        /// <param name="downloadTimeout">in sec. default(-1)=RuntimeSettings.DefaultDownloadTimeout</param>
        /// <param name="filter">target extension.</param>
        /// <param name="changeType">download trigger. recommend: WatcherChangeTypes.Renamed or WatcherChangeTypes.Changed</param>
        /// <returns>file path(full path)</returns>
        string Download(Func<bool> clickOnDownloadFunc, int downloadTimeout = -1, string filter = "*.xlsx", WatcherChangeTypes changeType = WatcherChangeTypes.Renamed);

        /// <summary>
        /// Delete Excel file
        /// </summary>
        /// <param name="filePath"></param>
        void DeleteExcelFile(string filePath);

        /// <summary>
        /// Verifies the summary tab of the click rate excel sheet
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <param name="startDate"></param> Billing period start date
        /// <param name="endDate"></param> Billing perios end date
        /// <param name="expectedClickRateTotal"></param>
        void VerifySummaryWorksheet(string excelFilePath, string startDate, string endDate, string expectedClickRateTotal);

        /// <summary>
        /// Verifies the click charges tab of the click rate excel sheet
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="isFirstBillingPeriod"></param>
        void VerifyClickChargesWorksheet(string excelFilePath, string startDate, string endDate, bool isFirstBillingPeriod);

    }
}
