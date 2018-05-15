﻿using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using NUnit.Framework;
using OfficeOpenXml;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public class ExcelBaseHelper
    {
        private readonly ILoggingService LoggingService;
        private readonly IRuntimeSettings RuntimeSettings;

        public ExcelBaseHelper(ILoggingService loggingService, IRuntimeSettings runtimeSettings)
        {
            LoggingService = loggingService;
            RuntimeSettings = runtimeSettings;
        }

        public string Download(Func<bool> clickOnDownloadFunc, int downloadTimeout = -1, string filter = "*.xlsx", WatcherChangeTypes changeType = WatcherChangeTypes.Renamed)
        {
            LoggingService.WriteLogOnMethodEntry(clickOnDownloadFunc, downloadTimeout, filter, changeType);
            downloadTimeout = downloadTimeout < 0 ? RuntimeSettings.DefaultDownloadTimeout : downloadTimeout;
            FileSystemWatcher fsWatcher = new FileSystemWatcher();
            fsWatcher.Path = TestController.DownloadPath;
            fsWatcher.Filter = filter;
            fsWatcher.IncludeSubdirectories = false;
            fsWatcher.NotifyFilter = NotifyFilters.Attributes |
                                     NotifyFilters.CreationTime |
                                     NotifyFilters.DirectoryName |
                                     NotifyFilters.FileName |
                                     NotifyFilters.LastAccess |
                                     NotifyFilters.LastWrite |
                                     NotifyFilters.Security |
                                     NotifyFilters.Size;
            fsWatcher.EnableRaisingEvents = true;
            if (clickOnDownloadFunc() == false)
            {
                TestCheck.AssertFailTest("download pdf prefunction error " + clickOnDownloadFunc);
            }
            var changedResult = fsWatcher.WaitForChanged(changeType, downloadTimeout * 1000);
            if (changedResult.TimedOut)
            {
                var altFullpath = GetLatestFile(fsWatcher.Path, filter, downloadTimeout);
                LoggingService.WriteLog(LoggingLevel.WARNING, "FileSystemWatcher listen timeout. alternate={0}", altFullpath);
                return altFullpath;
            }
            var fullPath = System.IO.Path.Combine(fsWatcher.Path, changedResult.Name);
            return fullPath;
        }

        public int GetNumberOfRows(string excelFilePath, int worksheetIndex = 1) // For first worksheet, worksheetIndex = 1, for second worksheet, worksheetIndex = 2 and so on..
        {
            LoggingService.WriteLogOnMethodEntry(excelFilePath, worksheetIndex);
            var fileInfo = new FileInfo(excelFilePath);
            Assert.True(fileInfo.Exists, string.Format("Excel sheet = {0} does not exist", excelFilePath));
            
            int rowCount = 0;
            
            using (ExcelPackage pack = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet ws = pack.Workbook.Worksheets[worksheetIndex];

                rowCount = ws.Dimension.Rows;
            }

            return rowCount;
        }

        public string HandleNullCase(Object variable)
        {
            LoggingService.WriteLogOnMethodEntry(variable);
            if (variable != null)
            {
                return variable.ToString();
            }
            else
            {
                return "";
            }
        }

        public void DeleteExcelFile(string filePath)
        {
            LoggingService.WriteLogOnMethodEntry(filePath);
            try
            {
                System.IO.File.Delete(filePath);
            }
            catch
            {
                Console.WriteLine(string.Format("Excel File = {0} could not be deleted", filePath));
            }
        }

        // converts excel serial date to standard date format
        public string FormatExcelSerialDate(string SerialDate)
        {
            LoggingService.WriteLogOnMethodEntry(SerialDate);
            DateTime dt = DateTime.FromOADate(Convert.ToInt32(Math.Floor(Convert.ToDouble(SerialDate))));
            return MpsUtil.DateTimeString(dt);
        }

        #region private methods

        private string GetLatestFile(string cpath, string filter, int downloadTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(cpath, filter, downloadTimeout);
            var ext = "." + filter.Replace("*.", "");
            var minTime = DateTime.Now.AddSeconds(-(downloadTimeout * 1.5)); // 1.5=safety factor.
            var files = System.IO.Directory.GetFiles(TestController.DownloadPath, filter, System.IO.SearchOption.AllDirectories);
            var fileLatest = files
                .Select(f => new System.IO.FileInfo(System.IO.Path.Combine(cpath, f)))
                .Where(fi => fi.Extension.Equals(ext, StringComparison.OrdinalIgnoreCase))
                .Where(fi => fi.LastAccessTime > minTime)
                .OrderByDescending(fi => fi.CreationTime)
                .FirstOrDefault();
            return fileLatest.FullName;
        }

        # endregion
    }
}
