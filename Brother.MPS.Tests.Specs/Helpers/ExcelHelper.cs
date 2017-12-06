using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Specs.Configuration;
using Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Helpers
{
    public class ExcelHelper: IExcelHelper
    {
        // Mandatory Input Field column numbers
        private const int CUSTOMER_NAME_COL_NUM = 9;
        private const int CONTACT_FIRST_NAME_COL_NUM = 10;
        private const int PROPERTY_NUMBER_COL_NUM = 14;
        private const int PROPERTY_STREET_COL_NUM = 15;
        private const int PROPERTY_TOWN_COL_NUM = 19;
        private const int PROPERTY_POSTCODE_COL_NUM = 21;

        // Non-Mandatory Input Field column numbers
        private const int CONTACT_LAST_NAME_COL_NUM = 11;
        private const int TELEPHONE_COL_NUM = 12;
        private const int EMAIL_COL_NUM = 13;
        private const int PROPERTY_AREA_COL_NUM = 18;
        private const int COUNTRY_COL_NUM = 20;
        private const int DEVICE_LOCATION_COL_NUM = 22;
        private const int COST_CENTRE_COL_NUM = 23;
        private const int REFERENCE_1_COL_NUM = 24;
        private const int REFERENCE_2_COL_NUM = 25;
        private const int REFERENCE_3_COL_NUM = 26;
        private const int INSTALLATION_NOTES_COL_NUM = 27;

        private IRuntimeSettings _runtimeSettings;

        public ExcelHelper(
            IRuntimeSettings runtimeSettings
            )
        {
            _runtimeSettings = runtimeSettings;
        }

        public string GetDownloadedExcelFilePath()
        {
            var fileList = ListDownloadsFolder();
            var task = WaitforNewfile(fileList);
            if (task.Wait(new TimeSpan(0, 0, _runtimeSettings.DefaultDownloadTimeout)))
            {
                return task.Result;
            }
            else
            {
                throw new Exception("Download Excel Timeout");
            }
        }

        public void OpenExcel(string excelFilePath)
        {
            System.Diagnostics.Process.Start(excelFilePath);
        }

        public int GetNumberOfRows(string excelFilePath)
        {
            var fileInfo = new FileInfo(excelFilePath);
            if (fileInfo.Exists)
            {
                using (ExcelPackage pack = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet ws = pack.Workbook.Worksheets.First();

                    int rowCount = ws.Dimension.Rows;
                    return rowCount;
                }
            }
            else
            {
                throw new Exception(string.Format("Excel sheet = {0} does not exist", excelFilePath));
            }
        }

        public void EditExcelCustomerInformation(
            string excelFilePath, int row, CustomerInformationMandatoryFields mandatoryFieldValues, CustomerInformationNonMandatoryFields nonMandatoryFieldValues = null)
        {
            var fileInfo = new FileInfo(excelFilePath);
            if (fileInfo.Exists)
            {
                using (ExcelPackage pack = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet ws = pack.Workbook.Worksheets.First();
                    
                    // Fill Mandatory fields
                    ws.Cells[row, CUSTOMER_NAME_COL_NUM].Value = mandatoryFieldValues.CompanyName;                  
                    ws.Cells[row, CONTACT_FIRST_NAME_COL_NUM].Value = mandatoryFieldValues.FirstName;                  
                    ws.Cells[row, PROPERTY_NUMBER_COL_NUM].Value = mandatoryFieldValues.PropertyNumber;                
                    ws.Cells[row, PROPERTY_STREET_COL_NUM].Value = mandatoryFieldValues.PropertyStreet;  
                    ws.Cells[row, PROPERTY_TOWN_COL_NUM].Value = mandatoryFieldValues.PropertyTown;               
                    ws.Cells[row, PROPERTY_POSTCODE_COL_NUM].Value = mandatoryFieldValues.PostCode;
                  
                    if (nonMandatoryFieldValues != null)
                    {
                        // Fill Non Mandatory fields
                        ws.Cells[row, CONTACT_LAST_NAME_COL_NUM].Value = nonMandatoryFieldValues.LastName;
                        ws.Cells[row, TELEPHONE_COL_NUM].Value = nonMandatoryFieldValues.Telephone;
                        ws.Cells[row, EMAIL_COL_NUM].Value = nonMandatoryFieldValues.Email;
                        ws.Cells[row, PROPERTY_AREA_COL_NUM].Value = nonMandatoryFieldValues.PropertyArea;
                        ws.Cells[row, COUNTRY_COL_NUM].Value = nonMandatoryFieldValues.Country;
                        ws.Cells[row, DEVICE_LOCATION_COL_NUM].Value = nonMandatoryFieldValues.DeviceLocation;
                        ws.Cells[row, COST_CENTRE_COL_NUM].Value = nonMandatoryFieldValues.CostCentre;
                        ws.Cells[row, REFERENCE_1_COL_NUM].Value = nonMandatoryFieldValues.Reference_1;
                        ws.Cells[row, REFERENCE_2_COL_NUM].Value = nonMandatoryFieldValues.Reference_2;
                        ws.Cells[row, REFERENCE_3_COL_NUM].Value = nonMandatoryFieldValues.Reference_3;
                        ws.Cells[row, INSTALLATION_NOTES_COL_NUM].Value = nonMandatoryFieldValues.InstallationNotes;
                    }

                    pack.Save();
                }
            }
            else
            {
                throw new Exception(string.Format("Excel sheet = {0} does not exist", excelFilePath));
            }
        }

        public void DeleteExcelFile(string filePath)
        {
            try 
            { 
                System.IO.File.Delete(filePath); 
            }
            catch
            {
                Console.WriteLine(string.Format("Excel File = {0} could not be deleted", filePath));
            }
        }

        # region private methods

        private async Task<string> WaitforNewfile(string[] orglist, string pattern = "*.xlsx")
        {
            // note: FileWatcher is not detecting file...
            for (int safetycount = 0; safetycount < 1000; safetycount++)
            {
                var newlist = ListDownloadsFolder(pattern);
                var difflist = newlist.Except(orglist);
                if (difflist.Count() > 0)
                {
                    return difflist.First();
                }
                await Task.Delay(new TimeSpan(0, 0, 1));
            }
            throw new Exception("Safety Count RetryOut");
        }

        private string[] ListDownloadsFolder(string pattern = "*.xlsx")
        {
            try
            {
                string[] files = System.IO.Directory.GetFiles(TestController.DownloadPath, pattern, System.IO.SearchOption.AllDirectories);
                return files;
            }
            catch
            {
                return new string[0];
            }
        }
        # endregion
    }
}
