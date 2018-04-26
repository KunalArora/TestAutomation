using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public class CPPAgreementExcelHelper: ExcelBaseHelper, ICPPAgreementExcelHelper
    {
        private ILoggingService LoggingService { get; set; }

        public CPPAgreementExcelHelper(
            IRuntimeSettings runtimeSettings,
            ILoggingService loggingService
            ): base(loggingService, runtimeSettings)
        {
            LoggingService = loggingService;
        }

        public void VerifyAgreementDetails(string excelFilePath)
        {
            LoggingService.WriteLogOnMethodEntry(excelFilePath);
        }
    }
}
