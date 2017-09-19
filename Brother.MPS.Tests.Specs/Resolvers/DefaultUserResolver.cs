using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Specs.ContextData;

namespace Brother.Tests.Specs.Resolvers
{
    public class DefaultUserResolver :IUserResolver
    {
        private readonly IContextData _contextData;
        private const string USERNAME_PATTERN = "MPS-{0}-{1}-{2}{3}@brother.co.uk";
        private const string PASSWORD_PATTERN = "{0}{1}1";

        public DefaultUserResolver(IContextData contextData)
        {
            _contextData = contextData;
        }

        public string DealerUsername
        {
            get
            {
                return string.Format(USERNAME_PATTERN, _contextData.Country.BrotherCode, _contextData.Environment, "Dealer", "1");
            }
        }

        public string DealerPassword
        {
            get
            {
                return string.Format(PASSWORD_PATTERN, MapCountryIsoToPasswordCountryAbbreviation(_contextData.Country.CountryIso), "dealer");
            }
        }

        public string LocalOfficeAdminUsername { get; set; }
        public string LocalOfficeAdminPassword { get; set; }
        public string LocalOfficeApproverUsername { get; set; }
        public string LocalOfficeApproverPassword { get; set; }
        public string BIEAdminUsername { get; set; }
        public string BIEAdminPassword { get; set; }
        public string BankUsername { get; set; }
        public string BankPassword { get; set; }
        public string ServiceDeskUsername { get; set; }
        public string ServiceDeskPassword { get; set; }

        private string MapCountryIsoToPasswordCountryAbbreviation(string countryIso)
        {
            if (countryIso.ToUpper() == "GB") return "UK";
            return countryIso;
        }
    }
}
