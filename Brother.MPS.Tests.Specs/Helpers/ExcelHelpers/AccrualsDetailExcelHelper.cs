using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public class AccrualsDetailExcelHelper : ExcelBaseHelper, IAccrualsDetailExcelHelper
    {
        public AccrualsDetailExcelHelper(ILoggingService loggingService, IRuntimeSettings runtimeSettings, IContextData contextData) : base(loggingService, runtimeSettings, contextData)
        {
        }
    }
}
