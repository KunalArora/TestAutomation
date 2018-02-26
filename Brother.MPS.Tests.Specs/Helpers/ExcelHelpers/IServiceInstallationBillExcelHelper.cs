
using System;
using System.IO;
namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public interface IServiceInstallationBillExcelHelper
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
        /// Verifies the detail tab of the service installation bill excel sheet
        /// </summary>
        /// <param name="excelFilePath">Downloaded Excel file path</param>
        /// <param name="startDate">Billing period start date</param>
        /// <param name="endDate">Billing period end date</param>
        void VerifyDetailWorksheet(string excelFilePath, string startDate, string endDate, string expectedServiceInstallationTotal);
    }
}
