using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

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

        public void DeletePdf(string fileName)
        {
            LoggingService.WriteLogOnMethodEntry(fileName);
            System.IO.File.Delete(fileName);
        }

        public bool PdfContainsText(string pdfFileName, string searchText)
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

        public bool PdfExists(string fileName)
        {
            LoggingService.WriteLogOnMethodEntry(fileName);
            return System.IO.File.Exists(fileName);
        }

        public string Download(Func<IPdfHelper, bool> clickOnDownloadFunc, int downloadTimeout = -1, string filter = "*.pdf", WatcherChangeTypes changeType = WatcherChangeTypes.Renamed)
        {
            LoggingService.WriteLogOnMethodEntry(clickOnDownloadFunc, downloadTimeout);
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
                throw new Exception("download pdf prefunction error " + clickOnDownloadFunc);
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
            LoggingService.WriteLogOnMethodEntry(filter);
            var ext = "."+filter.Replace("*.", "");
            var minTime = DateTime.Now.AddSeconds(-(downloadTimeout*1.5)); // 1.5=safety factor.
            var files = System.IO.Directory.GetFiles(TestController.DownloadPath, filter, System.IO.SearchOption.AllDirectories);
            var fileLatest = files
                .Select(f => new System.IO.FileInfo(System.IO.Path.Combine(cpath, f)))
                .Where(fi => fi.Extension.Equals(ext, StringComparison.OrdinalIgnoreCase))
                .Where(fi => fi.LastAccessTime > minTime)
                .OrderByDescending(fi => fi.CreationTime)
                .FirstOrDefault();
            return fileLatest.FullName;
        }

        public void AssertAreEqualOverusageValues(string pdfFile, IEnumerable<PrinterProperties> PrintersProperties, string Culture)
        {
            LoggingService.WriteLogOnMethodEntry(pdfFile);
            string monoOverusageText = TranslationService.GetOverusageText(TranslationKeys.OverusageText.MonoText, Culture);
            string colourOverusageText = TranslationService.GetOverusageText(TranslationKeys.OverusageText.ColourText, Culture);
            var products = PrintersProperties;

            if (PdfExists(pdfFile) == false)
            {
                throw new Exception("pdf file does not exist=" + pdfFile);
            }
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
                    if (PdfContainsText(pdfFile, expected) == false)
                    {
                        throw new Exception(string.Format("String not found in pdf. pdfFile=[{0}], expected=[{1}]", pdfFile, expected));
                    }
                });
            }
        }

    }
}
