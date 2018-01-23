
namespace Brother.Tests.Specs.Helpers
{
    public interface IAgreementHelper
    {
        string GenerateAgreementName();
        string GenerateAgreementName(string pattern, string[] args);
        string GenerateReference();
        string GenerateSerialNumber(int deviceIndex);
    }
}
