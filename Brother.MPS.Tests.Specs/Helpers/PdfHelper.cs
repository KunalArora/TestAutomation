﻿using iTextSharp.text.pdf;
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
            return System.IO.File.Exists(fileName);
        }

    }
}