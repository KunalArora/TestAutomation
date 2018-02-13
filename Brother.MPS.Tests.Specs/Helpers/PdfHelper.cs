using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Selenium.Lib.Support;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.IO;

namespace Brother.Tests.Specs.Helpers
{
    class PdfHelper : IPdfHelper
    {
        public PdfHelper(ILoggingService loggingService, IRuntimeSettings runtimeSettings) {
            LoggingService = loggingService;
            RuntimeSettings = runtimeSettings;
        }
        private ILoggingService LoggingService { get; set; }
        private IRuntimeSettings RuntimeSettings { get; set; }


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
                throw new Exception("download pdf timeout");
            }
            var fullPath = System.IO.Path.Combine(fsWatcher.Path, changedResult.Name);
            return fullPath;
        }

    }
}
