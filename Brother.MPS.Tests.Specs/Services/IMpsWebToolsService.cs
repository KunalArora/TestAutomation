using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Models;

namespace Brother.Tests.Specs.Services
{
    public interface IMpsWebToolsService
    {
        void RecycleSerialNumber(string serialNumber);
        void SetCustomerSapId(int customerId, string sapId);
        void SetPersonSapId(int personId, string sapId);
        void RemoveConsumableOrderById(int orderId);
        void RemoveConsumableOrderByInstalledPrinter(string serialNumber);
        void SetConsumableOrderStatus(int orderId, int statusId);
        void RegisterCustomer(string idIsMailAddress, string password = "password", string firstName = "John", string lastName = "Doe", string maxmind = CountryIso.UnitedKingdom, string culture = "en-GB");
        string DownloadSilentDeviceReport();
        SwapRequestDetail GetSwapRequestDetail(int installedPrinterId);
        void DeleteDealership(string dealershipEmail);
        void RemoveProductionSmokeTests();
        void AddMpsRole(string emailAddress, string role);
    }
}
