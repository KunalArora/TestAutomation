using System;
using System.IO;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public interface ICPPAgreementExcelHelper
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
        /// Verify the agreement details in the report tab of CPP Agreement report excel
        /// </summary>
        /// <param name="excelFilePath"></param>
        void VerifyAgreementDetails(string excelFilePath);
    }
}
