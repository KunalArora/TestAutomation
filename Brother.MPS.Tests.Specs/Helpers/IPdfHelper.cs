﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Helpers
{
    public interface IPdfHelper
    {
        /// <summary>
        /// simply check for the existence of the file in the download location.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        bool PdfExists(string filename);
        /// <summary>
        /// for now use the code in the ExtractTextFromPdf in Helper.Selenium.cs as the basis for matching the text
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        bool PdfContainsText(string filename, string searchText);
        /// <summary>
        /// delete a specific file which is no longer required
        /// </summary>
        /// <param name="filename"></param>
        void DeletePdf(string filename);
        /// <summary>
        /// Wait for a pdf file to be downloaded
        /// </summary>
        /// <param name="orglist"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        Task<string> WaitforNewfile(string[] orglist, string pattern = "*.pdf");
        /// <summary>
        /// List the file which is downloaded
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        string[] ListDownloadsFolder(string pattern = "*.pdf");
    }
}
