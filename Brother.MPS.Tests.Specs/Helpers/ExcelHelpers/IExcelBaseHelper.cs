using System;
using System.IO;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public interface IExcelBaseHelper
    {
        string Download(Func<bool> clickOnDownloadFunc, int downloadTimeout = -1, string filter = "*.xlsx", WatcherChangeTypes changeType = WatcherChangeTypes.Renamed);
        void DeleteExcelFile(string filePath);
    }
}
