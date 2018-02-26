using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement;
using System;
using System.IO;

namespace Brother.Tests.Specs.Helpers
{
    public interface IDevicesExcelHelper
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
        /// Verify the total number of columns in an excel file
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <returns></returns>
        void VerifyTotalNumberOfColumns(string excelFilePath);

        /// <summary>
        /// Write the device data in the excel file & return the Device ID of the edited device (in Type 3)
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <param name="row"></param>
        /// <param name="mandatoryFieldValues"></param>
        /// <param name="optionalFieldValues"></param>
        /// <returns></returns>
        string EditExcelCustomerInformation(
            string excelFilePath, int row, CustomerInformationMandatoryFields mandatoryFieldValues, CustomerInformationOptionalFields optionalFieldValues);

        /// <summary>
        /// Retrieve the device details for a particular device row in excel (in Type 3)
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <param name="row">Row number of which device details are required</param>
        /// <returns></returns>
        AdditionalDeviceProperties GetDeviceDetails(string excelFilePath, int row);

        /// <summary>
        /// Verify that the device status & connection status of the device in excel sheet given the device row number
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <param name="deviceRow">Device row number</param>
        /// <param name="resourceInstalledPrinterStatus">Translated value of Installed Printer status</param>
        /// <param name="resourceDeviceConnectionStatus">Translated value of Device Connection status</param>
        void VerifyDeviceStatusAndConnectionStatus(
           string excelFilePath, int deviceRow, string resourceInstalledPrinterStatus, string resourceDeviceConnectionStatus);

        /// <summary>
        /// Delete Excel file
        /// </summary>
        /// <param name="filePath"></param>
        void DeleteExcelFile(string filePath);
    }
}