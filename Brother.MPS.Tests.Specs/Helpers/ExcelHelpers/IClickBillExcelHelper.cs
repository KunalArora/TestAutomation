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
        /// <param name="startDate">Billing period start date</param>
        /// <param name="endDate">Billing period end date</param>
        /// <param name="expectedClickRateTotal">Expected value of click rate total (picked from UI)</param>
        void VerifySummaryWorksheet(string excelFilePath, string startDate, string endDate, string expectedClickRateTotal);

        /// <summary>
        /// Verifies the click charges tab of the click rate excel sheet
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <param name="startDate">Billing period start date</param>
        /// <param name="endDate">Billing period end date</param>
        /// <param name="isFirstBillingPeriod">True if this period is the first billing period, otherwise false</param>
        void VerifyClickChargesWorksheet(string excelFilePath, string startDate, string endDate, bool isFirstBillingPeriod);

    }
}
