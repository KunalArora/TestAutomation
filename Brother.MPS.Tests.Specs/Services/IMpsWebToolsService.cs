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
        void RegisterCustomer(string idIsMailAddress, string password = "password", string firstName = "John", string lastName = "Doe", string maxmind = "GB");
    }
}
