using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
