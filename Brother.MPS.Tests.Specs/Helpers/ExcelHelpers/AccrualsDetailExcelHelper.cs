using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public class AccrualsDetailExcelHelper : ExcelBaseHelper, IAccrualsDetailExcelHelper
    {
        public AccrualsDetailExcelHelper(ILoggingService loggingService, IRuntimeSettings runtimeSettings) : base(loggingService, runtimeSettings)
        {
        }
    }
}
