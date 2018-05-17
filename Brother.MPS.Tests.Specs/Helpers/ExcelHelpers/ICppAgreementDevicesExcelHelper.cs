using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using System.Collections.Generic;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public interface ICppAgreementDevicesExcelHelper : IExcelBaseHelper
    {
        IEnumerable<CppAgreementDeviceProperties> Parse(string excelFilePath);
        void AssertAreEqualProperties(
            Dictionary<string, string> expectSummaryPageValues, 
            Dictionary<string, string> expectDealerAgreementDevicesPageValues,
            Dictionary<string, string> expectDealerAgreementServiceRequestsPageValues,
            Dictionary<string, string> expectDealerAgreementConsumablesPageValues,
            IEnumerable<CppAgreementDeviceProperties> actualProps, int agreementId, Country country, string message);

    }
}
