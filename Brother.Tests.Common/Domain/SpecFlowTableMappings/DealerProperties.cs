using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Common.Domain.SpecFlowTableMappings
{
    public class DealerProperties
    {
        public string DealerEmail { get; set; }
        public string DealerPassword { get; set; }
        public string DealerFirstName { get; set; }
        public string DealerLastName { get; set; }
        public string DealerOwnerFirstName { get; set; }
        public string DealerOwnerLastName { get; set; }
        public string DealerOwnerName
        {
            get
            {
                return DealerOwnerFirstName + " " + DealerOwnerLastName;
            }
        }
        public string DealerCeoFirstName { get; set; }
        public string DealerCeoLastName { get; set; }
        public string DealerCeoName
        {
            get
            {
                return DealerCeoFirstName + " " + DealerCeoLastName;
            }
        }
        public string DealershipName { get; set; }
        public string DealerSapId { get; set; }
        public string DealerBankName { get; set; }
        public string DealerBankAccountNumber { get; set; }
        public string DealerBankSortCode { get; set; }
        public string DealerBrotherSalesPerson { get; set; }

        public string DiscountForType3 { get; set; }
        public string BillingDateForType3 { get; set; }
    }
}
