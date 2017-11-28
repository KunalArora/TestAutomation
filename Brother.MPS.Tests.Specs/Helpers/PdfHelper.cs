using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Brother.Tests.Specs.Helpers
{
    class PdfHelper : IPdfHelper
    {
        public void DeletePdf(string fileName)
        {
            System.IO.File.Delete(fileName);
        }

        public bool PdfContainsText(string pdfFileName, string searchText)
        {
            using (var reader = new PdfReader(pdfFileName))
            {
                var page = 4; // 1 origin
                var strategy =new SimpleTextExtractionStrategy();
                var pageText =PdfTextExtractor.GetTextFromPage(reader, page, strategy);
                var trueIfExist = pageText.Contains(searchText);
                return trueIfExist;
            }
        }

        public bool PdfExists(string fileName)
        {
            return System.IO.File.Exists(fileName);
        }

    }
}
