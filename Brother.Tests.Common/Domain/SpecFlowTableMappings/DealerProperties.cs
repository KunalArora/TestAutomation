using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Common.Domain.SpecFlowTableMappings
{
    public class DealerProperties
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerName
        {
            get
            {
                return OwnerFirstName + " " + OwnerLastName;
            }
        }
        public string CeoFirstName { get; set; }
        public string CeoLastName { get; set; }
        public string CeoName
        {
            get
            {
                return CeoFirstName + " " + CeoLastName;
            }
        }
        public string DealershipName { get; set; }
        public string SapId { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankSortCode { get; set; }
        public string BrotherSalesPerson { get; set; }
        public string DiscountForType3 { get; set; }
        public string BillingDateForType3 { get; set; }
    }
}
