using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Common.Domain.Enums;

namespace Brother.Tests.Specs.Resolvers
{
    public interface IUserResolver
    {
        string DealerUsername { get; }
        string DealerPassword { get; }
        string LocalOfficeAdminUsername { get; }
        string LocalOfficeAdminPassword { get; }
        string LocalOfficeApproverUsername { get; }
        string LocalOfficeApproverPassword { get; }
        string BIEAdminUsername { get; }
        string BIEAdminPassword { get; }
        string BankUsername { get; }
        string BankPassword { get; }
        string ServiceDeskUsername { get; }
        string ServiceDeskPassword { get; }
        string InstallerUsername { get; }

        string GetDealerUsername(BusinessType businessType);
        string GetDealerPassword(BusinessType businessType);
    }
}
