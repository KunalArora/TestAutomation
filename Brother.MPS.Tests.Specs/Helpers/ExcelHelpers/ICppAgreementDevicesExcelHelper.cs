using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using System.Collections.Generic;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public interface ICppAgreementDevicesExcelHelper : IExcelBaseHelper
    {
        IEnumerable<CppAgreementDeviceProperty> Parse(string excelFilePath);
        void AssertAreEqualProperties(
            Dictionary<string, string> expectSummaryPageValues, 
            Dictionary<string, string> expectDealerAgreementDevicesPageValues,
            Dictionary<string, string> expectDealerAgreementServiceRequestsPageValues,
            Dictionary<string, string> expectDealerAgreementConsumablesPageValues,
            IEnumerable<CppAgreementDeviceProperty> actualProps, int agreementId, Country country, string message);

    }
}
