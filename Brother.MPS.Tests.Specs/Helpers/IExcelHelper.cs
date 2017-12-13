
using Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement;
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
        /// Write the device data in the excel file & return the Device ID of the edited device
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <param name="row"></param>
        /// <param name="mandatoryFieldValues"></param>
        /// <param name="nonMandatoryFieldValues"></param>
        /// <returns></returns>
        string EditExcelCustomerInformation(
            string excelFilePath, int row, CustomerInformationMandatoryFields mandatoryFieldValues, CustomerInformationNonMandatoryFields nonMandatoryFieldValues);
        
        /// <summary>
        /// Delete Excel file
        /// </summary>
        /// <param name="filePath"></param>
        void DeleteExcelFile(string filePath);
    }
}