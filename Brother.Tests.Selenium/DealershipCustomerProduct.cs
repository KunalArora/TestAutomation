//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Brother.Tests.Selenium.Lib
{
    using System;
    using System.Collections.Generic;
    
    public partial class DealershipCustomerProduct
    {
        public System.Guid DealershipId { get; set; }
        public System.Guid BusinessApplicationId { get; set; }
        public System.Guid DealershipCustomerUserId { get; set; }
        public Nullable<System.DateTime> DateCancelled { get; set; }
        public Nullable<System.DateTime> SubscriptionExpiredEmailSent { get; set; }
        public Nullable<System.DateTime> SubscriptionRenewalDueEmailSent { get; set; }
        public System.Guid msrepl_tran_version { get; set; }
    
        public virtual DealershipCustomer DealershipCustomer { get; set; }
    }
}