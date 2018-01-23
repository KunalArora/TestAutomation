using Brother.Tests.Common.Logging;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Brother.Tests.Specs.Helpers
{
    class PdfHelper : IPdfHelper, IILoggingService
    {
        public PdfHelper(ILoggingService loggingService) { LoggingService = loggingService; }
        public ILoggingService LoggingService { get; set; }

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


    }
}
