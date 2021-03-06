﻿using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement;
using NUnit.Framework;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public class DevicesExcelHelper: ExcelBaseHelper, IDevicesExcelHelper
    {
        // Excel Properties
        private const int TOTAL_NUMBER_OF_COLUMNS = 25;

        // Devices Property Fields
        private const int AGREEMENT_ID_COL_NUM = 1;
        private const int MPS_DEVICE_ID_COL_NUM = 2;
        private const int BOC_DEVICE_ID_COL_NUM = 3;
        private const int MODEL_COL_NUM = 4;
        private const int CONNECTION_STATUS_COL_NUM = 5;
        private const int INSTALLATION_LINK_COL_NUM = 6;
        private const int DEVICE_STATUS_COL_NUM = 7;
        private const int REGISTRATION_PIN_COL_NUM = 8;
        private const int ADVANCED_INSTALLATION_LINK_COL_NUM = 25;

        // Mandatory Input Field column numbers
        private const int CUSTOMER_NAME_COL_NUM = 9;
        private const int CONTACT_FIRST_NAME_COL_NUM = 10;
        private const int PROPERTY_NUMBER_COL_NUM = 14;
        private const int PROPERTY_STREET_COL_NUM = 15;
        private const int PROPERTY_TOWN_COL_NUM = 17;
        private const int PROPERTY_POSTCODE_COL_NUM = 18;
            
        // Non-Mandatory Input Field column numbers
        private const int CONTACT_LAST_NAME_COL_NUM = 11;
        private const int TELEPHONE_COL_NUM = 12;
        private const int EMAIL_COL_NUM = 13;
        private const int PROPERTY_AREA_COL_NUM = 16;
        private const int DEVICE_LOCATION_COL_NUM = 19;
        private const int COST_CENTRE_COL_NUM = 20;
        private const int REFERENCE_1_COL_NUM = 21;
        private const int REFERENCE_2_COL_NUM = 22;
        private const int REFERENCE_3_COL_NUM = 23;
        private const int INSTALLATION_NOTES_COL_NUM = 24;

        private ILoggingService LoggingService { get; set; }

        public DevicesExcelHelper(
            IRuntimeSettings runtimeSettings,
            ILoggingService loggingService,
            IContextData contextData
            ): base(loggingService, runtimeSettings, contextData)
        {
            LoggingService = loggingService;
        }

        public void VerifyTotalNumberOfColumns(string excelFilePath)
        {
            LoggingService.WriteLogOnMethodEntry(excelFilePath);
            var fileInfo = new FileInfo(excelFilePath);

            Assert.True(fileInfo.Exists, string.Format("Excel sheet = {0} does not exist", excelFilePath));

            using (ExcelPackage pack = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet ws = pack.Workbook.Worksheets.First();

                if (ws.Dimension.Columns != TOTAL_NUMBER_OF_COLUMNS)
                {
                    TestCheck.AssertFailTest(string.Format("Number of columns in excel sheet = {0} could not be validated", excelFilePath));
                }
            }
        }

        public string EditExcelCustomerInformation(
            string excelFilePath, int row, CustomerInformationMandatoryFields mandatoryFieldValues, CustomerInformationOptionalFields optionalFieldValues = null)
        {
            LoggingService.WriteLogOnMethodEntry(excelFilePath, row, mandatoryFieldValues, optionalFieldValues);
            var fileInfo = new FileInfo(excelFilePath);

            Assert.True(fileInfo.Exists, string.Format("Excel sheet = {0} does not exist", excelFilePath));
 
            using (ExcelPackage pack = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet ws = pack.Workbook.Worksheets.First();
                    
                // Fill Mandatory fields
                ws.Cells[row, CUSTOMER_NAME_COL_NUM].Value = mandatoryFieldValues.CompanyName;                  
                ws.Cells[row, CONTACT_FIRST_NAME_COL_NUM].Value = mandatoryFieldValues.FirstName;
                ws.Cells[row, CONTACT_LAST_NAME_COL_NUM].Value = mandatoryFieldValues.LastName;
                ws.Cells[row, PROPERTY_NUMBER_COL_NUM].Value = mandatoryFieldValues.PropertyNumber;                
                ws.Cells[row, PROPERTY_STREET_COL_NUM].Value = mandatoryFieldValues.PropertyStreet;  
                ws.Cells[row, PROPERTY_TOWN_COL_NUM].Value = mandatoryFieldValues.PropertyTown;               
                ws.Cells[row, PROPERTY_POSTCODE_COL_NUM].Value = mandatoryFieldValues.PostCode;
                  
                if (optionalFieldValues != null)
                {
                    // Fill Non Mandatory fields
                    ws.Cells[row, TELEPHONE_COL_NUM].Value = optionalFieldValues.Telephone;
                    ws.Cells[row, EMAIL_COL_NUM].Value = optionalFieldValues.Email;
                    ws.Cells[row, PROPERTY_AREA_COL_NUM].Value = optionalFieldValues.PropertyArea;
                    ws.Cells[row, DEVICE_LOCATION_COL_NUM].Value = optionalFieldValues.DeviceLocation;
                    ws.Cells[row, COST_CENTRE_COL_NUM].Value = optionalFieldValues.CostCentre;
                    ws.Cells[row, REFERENCE_1_COL_NUM].Value = optionalFieldValues.Reference_1;
                    ws.Cells[row, REFERENCE_2_COL_NUM].Value = optionalFieldValues.Reference_2;
                    ws.Cells[row, REFERENCE_3_COL_NUM].Value = optionalFieldValues.Reference_3;
                    ws.Cells[row, INSTALLATION_NOTES_COL_NUM].Value = optionalFieldValues.InstallationNotes;
                }

                pack.Save();
                return ws.Cells[row, MPS_DEVICE_ID_COL_NUM].Value.ToString(); // Return Device ID
            }        
        }

        public AdditionalDeviceProperties GetDeviceDetails(string excelFilePath, int row)
        {
            LoggingService.WriteLogOnMethodEntry(excelFilePath, row);
            var fileInfo = new FileInfo(excelFilePath);

            Assert.True(fileInfo.Exists, string.Format("Excel sheet = {0} does not exist", excelFilePath));
            AdditionalDeviceProperties deviceProperties = new AdditionalDeviceProperties();
           
            using (ExcelPackage pack = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet ws = pack.Workbook.Worksheets.First();


                deviceProperties.DeviceIndex = row - 1;

                // Device Installation details
                deviceProperties.AgreementId = HandleNullCase(ws.Cells[row, AGREEMENT_ID_COL_NUM].Value);
                deviceProperties.MpsDeviceId = HandleNullCase(ws.Cells[row, MPS_DEVICE_ID_COL_NUM].Value);
                deviceProperties.BocDeviceId = HandleNullCase(ws.Cells[row, BOC_DEVICE_ID_COL_NUM].Value);
                deviceProperties.Model = HandleNullCase(ws.Cells[row, MODEL_COL_NUM].Value);
                deviceProperties.ConnectionStatus = HandleNullCase(ws.Cells[row, CONNECTION_STATUS_COL_NUM].Value);
                deviceProperties.InstallationLink = HandleNullCase(ws.Cells[row, INSTALLATION_LINK_COL_NUM].Value);
                deviceProperties.DeviceStatus = HandleNullCase(ws.Cells[row, DEVICE_STATUS_COL_NUM].Value);
                deviceProperties.RegistrationPin = HandleNullCase(ws.Cells[row, REGISTRATION_PIN_COL_NUM].Value);
                deviceProperties.AdvancedInstallationLink = HandleNullCase(ws.Cells[row, ADVANCED_INSTALLATION_LINK_COL_NUM].Value);

                // Customer details mandatory fields
                deviceProperties.CustomerName = HandleNullCase(ws.Cells[row, CUSTOMER_NAME_COL_NUM].Value);
                deviceProperties.ContactLastName = HandleNullCase(ws.Cells[row, CONTACT_LAST_NAME_COL_NUM].Value);
                deviceProperties.ContactFirstName = HandleNullCase(ws.Cells[row, CONTACT_FIRST_NAME_COL_NUM].Value);
                deviceProperties.AddressNumber = HandleNullCase(ws.Cells[row, PROPERTY_NUMBER_COL_NUM].Value);
                deviceProperties.AddressStreet = HandleNullCase(ws.Cells[row, PROPERTY_STREET_COL_NUM].Value);
                deviceProperties.AddressTown = HandleNullCase(ws.Cells[row, PROPERTY_TOWN_COL_NUM].Value);
                deviceProperties.AddressPostCode = HandleNullCase(ws.Cells[row, PROPERTY_POSTCODE_COL_NUM].Value);


                // Customer details Non Mandatory fields
                deviceProperties.Telephone = HandleNullCase(ws.Cells[row, TELEPHONE_COL_NUM].Value);
                deviceProperties.Email = HandleNullCase(ws.Cells[row, EMAIL_COL_NUM].Value);
                deviceProperties.AddressArea = HandleNullCase(ws.Cells[row, PROPERTY_AREA_COL_NUM].Value);
                deviceProperties.DeviceLocation = HandleNullCase(ws.Cells[row, DEVICE_LOCATION_COL_NUM].Value);
                deviceProperties.CostCentre = HandleNullCase(ws.Cells[row, COST_CENTRE_COL_NUM].Value);
                deviceProperties.Reference1 = HandleNullCase(ws.Cells[row, REFERENCE_1_COL_NUM].Value);
                deviceProperties.Reference2 = HandleNullCase(ws.Cells[row, REFERENCE_2_COL_NUM].Value);
                deviceProperties.Reference3 =  HandleNullCase(ws.Cells[row, REFERENCE_3_COL_NUM].Value);
                deviceProperties.InstallationNotes = HandleNullCase(ws.Cells[row, INSTALLATION_NOTES_COL_NUM].Value);
            }

            return deviceProperties;
        }

        public void VerifyDeviceStatusAndConnectionStatus(
           string excelFilePath, int deviceRowIndex, string resourceDeviceStatus, string resourceConnectionStatus)
        {
            LoggingService.WriteLogOnMethodEntry(excelFilePath, deviceRowIndex, resourceDeviceStatus, resourceConnectionStatus);
            var fileInfo = new FileInfo(excelFilePath);

            Assert.True(fileInfo.Exists, string.Format("Excel sheet = {0} does not exist", excelFilePath));
                     
            using (ExcelPackage pack = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet ws = pack.Workbook.Worksheets.First();

                TestCheck.AssertIsEqual(resourceDeviceStatus, ws.Cells[deviceRowIndex, DEVICE_STATUS_COL_NUM].Value.ToString(), string.Format(
                        "Installed device connection status could not be validated in Excel sheet = {0} for device id = {1}",
                        excelFilePath, ws.Cells[deviceRowIndex, MPS_DEVICE_ID_COL_NUM].Value.ToString()));

                TestCheck.AssertIsEqual(resourceConnectionStatus, ws.Cells[deviceRowIndex, CONNECTION_STATUS_COL_NUM].Value.ToString(), string.Format(
                        "Installed device status could not be validated in Excel sheet = {0} for device id = {1}",
                        excelFilePath, ws.Cells[deviceRowIndex, MPS_DEVICE_ID_COL_NUM].Value.ToString()));
            }          
        }

        public void ExportAndSaveInstallationDetails(string excelFilePath, AdditionalDeviceProperties device)
        {
            LoggingService.WriteLogOnMethodEntry(excelFilePath, device);
            var fileInfo = new FileInfo(excelFilePath);

            Assert.True(fileInfo.Exists, string.Format("Excel sheet = {0} does not exist", excelFilePath));

            using (ExcelPackage pack = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet ws = pack.Workbook.Worksheets.First();

                int rowIndex = GetNumberOfRows(excelFilePath);

                while (!(HandleNullCase(ws.Cells[rowIndex, MPS_DEVICE_ID_COL_NUM].Value) == device.MpsDeviceId))
                {
                    rowIndex--;
                    if (rowIndex < 2)
                    {
                        TestCheck.AssertFailTest(
                            string.Format(
                            "Information for device with device id {0} not present in the devices excel file {3}", device.MpsDeviceId, excelFilePath));
                    }
                }

                // Save Device Installation details       
                device.InstallationLink = HandleNullCase(ws.Cells[rowIndex, INSTALLATION_LINK_COL_NUM].Value);
                device.RegistrationPin = HandleNullCase(ws.Cells[rowIndex, REGISTRATION_PIN_COL_NUM].Value);
                device.AdvancedInstallationLink = HandleNullCase(ws.Cells[rowIndex, ADVANCED_INSTALLATION_LINK_COL_NUM].Value);
            }     
        }
    }
}
