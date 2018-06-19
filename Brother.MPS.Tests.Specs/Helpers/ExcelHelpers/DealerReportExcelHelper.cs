using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using System.Collections.Generic;
using TechTalk.SpecFlow.Assist;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public class DealerReportExcelHelper : ExcelBaseHelper, IDealerReportExcelHelper
    {
        private ILoggingService LoggingService { get; set; }

        public DealerReportExcelHelper(
            ILoggingService loggingService, 
            IRuntimeSettings runtimeSettings, 
            IContextData contextData) : base(loggingService, runtimeSettings, contextData)
        {
            LoggingService = loggingService;
        }

        public IEnumerable<DealerReportProperties> Parse(string excelFilePath)
        {
            LoggingService.WriteLogOnMethodEntry(excelFilePath);
            var table = ParseExcelFileToTable(excelFilePath);
            var properties = table.CreateSet<DealerReportProperties>();
            return properties;
        }

    }
}
