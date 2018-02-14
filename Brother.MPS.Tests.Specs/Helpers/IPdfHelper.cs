using System;
using System.IO;

namespace Brother.Tests.Specs.Helpers
{
    public interface IPdfHelper
    {
        /// <summary>
        /// download pdf
        /// </summary>
        /// <param name="clickOnDownloadFunc">ex. element.click()</param>
        /// <param name="downloadTimeout">in sec. default(-1)=RuntimeSettings.DefaultDownloadTimeout</param>
        /// <param name="filter">target extension.</param>
        /// <param name="changeType">download trigger. recommend: WatcherChangeTypes.Renamed or WatcherChangeTypes.Changed</param>
        /// <returns>file path(full path)</returns>
        string Download(Func<IPdfHelper, bool> clickOnDownloadFunc, int downloadTimeout = -1, string filter = "*.pdf", WatcherChangeTypes changeType = WatcherChangeTypes.Renamed);
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
    }
}
