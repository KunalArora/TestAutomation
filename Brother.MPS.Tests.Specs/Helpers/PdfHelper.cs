using Brother.Tests.Common.Logging;
using Brother.Tests.Selenium.Lib.Support;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Brother.Tests.Specs.Helpers
{
    class PdfHelper : IPdfHelper
    {
        public PdfHelper(ILoggingService loggingService) { LoggingService = loggingService; }
        private ILoggingService LoggingService { get; set; }

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

        public async Task<string> WaitforNewfile(string[] orglist, string pattern = "*.pdf")
        {
            LoggingService.WriteLogOnMethodEntry(orglist, pattern);
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
            throw new Exception("safety count retryout");
        }

        public string[] ListDownloadsFolder(string pattern = "*.pdf")
        {
            LoggingService.WriteLogOnMethodEntry(pattern);
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
    }
}
