using System;
using System.IO;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public interface IExcelBaseHelper
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
        /// Return the number of rows in an excel file
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <returns></returns>
        int GetNumberOfRows(string excelFilePath, int worksheetIndex = 1);

        /// <summary>
        /// Delete Excel file
        /// </summary>
        /// <param name="filePath"></param>
        void DeleteExcelFile(string filePath);

        /// <summary>
        /// convert excel file to table
        /// </summary>
        /// <param name="excelFilePath">ex. "c:/hoge/fuga.xlsx"</param>
        /// <param name="worksheetNumber">0..*</param>
        /// <returns>excel file by table format.
        /// excel top row is key names. key names are remove space. ex. "Dealer Number" => "DealerNumber"
        /// </returns>
        Table ParseExcelFileToTable(string excelFilePath, int worksheetNumber = 1);
    }
}
