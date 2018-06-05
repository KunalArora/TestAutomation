using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Helpers
{
    class PdfHelper : IPdfHelper
    {
        public PdfHelper(ILoggingService loggingService, IRuntimeSettings runtimeSettings, ITranslationService translationService) {
            LoggingService = loggingService;
            RuntimeSettings = runtimeSettings;
            TranslationService = translationService;
        }
        private ILoggingService LoggingService { get; set; }
        private IRuntimeSettings RuntimeSettings { get; set; }
        private ITranslationService TranslationService { get; set; }

        public void DeletePdfErrorIgnored(string fileName)
        {
            LoggingService.WriteLogOnMethodEntry(fileName);
            try {
                File.Delete(fileName);
            }
            catch (Exception e)
            {
                LoggingService.WriteLog(LoggingLevel.WARNING, (object)("can't delete file=" + fileName), e);
            }
        }

        public bool PdfContainsText(string pdfFileName, string searchText)
        {
            LoggingService.WriteLogOnMethodEntry(pdfFileName, searchText);
            return RetryUntil(() => doPdfContainsText(pdfFileName, searchText), "PdfContainsText exception occured");
        }

        private bool doPdfContainsText(string pdfFileName, string searchText)
        {
            LoggingService.WriteLogOnMethodEntry(pdfFileName, searchText);
            using (var reader = new PdfReader(pdfFileName))
            {
                var strategy = new SimpleTextExtractionStrategy();
                for (var page =1; page <= reader.NumberOfPages; page++)
                {
                    var pageText = PdfTextExtractor.GetTextFromPage(reader, page, strategy);
                    var trueIfExist = pageText.Contains(searchText);
                    if (trueIfExist)
                    {
                        return trueIfExist;
                    }
                }
            }
            return false;
        }

        private T RetryUntil<T>(Func<T> p, string warningMessage="exception occured retry")
        {
            Exception ioe = null;
            int cntmax = RuntimeSettings.DefaultRetryCount;
            for (int cnt = 1; cnt <= cntmax; cnt++)
            {
                try
                {
                    return p();
                }
                catch (Exception e)
                {
                    ioe = e;
                    if (cnt != cntmax)
                    {
                        LoggingService.WriteLog(LoggingLevel.WARNING, (object)string.Format("{0} ({1}/{2})", warningMessage, cnt, cntmax), e);
                        Task.Delay(1000);
                    }
                }
            }
            throw ioe;
        }


        public bool PdfExists(string fileName)
        {
            LoggingService.WriteLogOnMethodEntry(fileName);
            return System.IO.File.Exists(fileName);
        }

        public string Download(Func<IPdfHelper, bool> clickOnDownloadFunc, int downloadTimeout = -1, string filter = "*.pdf", WatcherChangeTypes changeType = WatcherChangeTypes.Renamed)
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
            if (clickOnDownloadFunc(this) == false)
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

        private string GetLatestFile(string cpath, string filter, int downloadTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(cpath, filter, downloadTimeout);
            var ext = "."+filter.Replace("*.", "");
            var dateTimeNow = DateTime.Now;
            var minTime = dateTimeNow.AddSeconds(-(downloadTimeout*1.5)); // 1.5=safety factor.
            var files = System.IO.Directory.GetFiles(TestController.DownloadPath, filter, System.IO.SearchOption.AllDirectories);
            var fileList = files
                .Select(f => new System.IO.FileInfo(System.IO.Path.Combine(cpath, f)));
            var fileLatest = fileList
                .Where(fi => fi.Extension.Equals(ext, StringComparison.OrdinalIgnoreCase))
                .Where(fi => fi.LastAccessTime > minTime)
                .OrderByDescending(fi => fi.CreationTime)
                .FirstOrDefault();
            Assert.NotNull(fileLatest, "file not found DateTime.Now={0}, files=[{1}]", 
                dateTimeNow, 
                fileList.Select(fi=>string.Format("{0} {1},",fi.Name,fi.LastAccessTime)));
            return fileLatest.FullName;
        }

        public void AssertAreEqualOverusageValues(string pdfFile, IEnumerable<PrinterProperties> PrintersProperties, string Culture)
        {
            LoggingService.WriteLogOnMethodEntry(pdfFile, PrintersProperties, Culture);
            string monoOverusageText = TranslationService.GetOverusageText(TranslationKeys.OverusageText.MonoText, Culture);
            string colourOverusageText = TranslationService.GetOverusageText(TranslationKeys.OverusageText.ColourText, Culture);
            var products = PrintersProperties;

            Assert.True(PdfExists(pdfFile), "pdf file does not exist={0}", pdfFile);
            foreach (var product in products)
            {
                var searchTextArray = new List<string>();
                if (product.VolumeMono != 0 && product.monoOverusage > 0)
                {
                    string expected = product.monoOverusage.ToString("N0", new CultureInfo(Culture));
                    searchTextArray.Add(product.Model + "\n" + product.SerialNumber + "\n" + monoOverusageText + " " + expected);
                }
                if (product.VolumeColour != 0 && product.colorOverusage > 0)
                {
                    string expected = product.colorOverusage.ToString("N0", new CultureInfo(Culture));
                    searchTextArray.Add(product.Model + "\n" + product.SerialNumber + "\n" + colourOverusageText + " " + expected);
                }
                searchTextArray.ForEach(expected =>
                {
                    Assert.True(PdfContainsText(pdfFile, expected), "String not found in pdf. pdfFile=[{0}], expected=[{1}]", pdfFile, expected);
                });
            }
        }

        public void AssertAreEqualAdditionalCharges(string pdfFile, IList<Dictionary<string, string>> expectedList, CultureInfo cultureInfo)
        {
            LoggingService.WriteLogOnMethodEntry(pdfFile, expectedList,cultureInfo);
            Assert.True(PdfExists(pdfFile), "pdf file does not exist={0}", pdfFile);
            foreach( var expected in expectedList)
            {
                // ex. "01/05/2018 - 31/05/2018 Consumables Return Management Fee £10.31\n" in PDF(UK)
                var totalPrice = double.Parse(expected["CustomerPrice"], cultureInfo);
                var expectedString = string.Format(cultureInfo, "{0} {1:C2}", expected["ChargeType"], totalPrice);
                Assert.True(PdfContainsText(pdfFile, expectedString), "String not found in pdf. pdfFile=[{0}], expected=[{1}]", pdfFile, expected);
            }
        }
    }
}
