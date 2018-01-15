
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement;
namespace Brother.Tests.Specs.Helpers
{
    public interface IExcelHelper
    {
        /// <summary>
        /// Get downloaded excel file path
        /// </summary>
        /// <returns></returns>
        string GetDownloadedExcelFilePath();

        /// <summary>
        /// Open an Excel file
        /// </summary>
        /// <param name="excelFilePath"></param>
        void OpenExcel(string excelFilePath);
        
        /// <summary>
        /// Return the number of rows in an excel file
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <returns></returns>
        int GetNumberOfRows(string excelFilePath);

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
        /// <param name="row"></param>
        /// <returns></returns>
        AdditionalDeviceProperties GetDeviceDetails(string excelFilePath, int row);

        /// <summary>
        /// Delete Excel file
        /// </summary>
        /// <param name="filePath"></param>
        void DeleteExcelFile(string filePath);
    }
}