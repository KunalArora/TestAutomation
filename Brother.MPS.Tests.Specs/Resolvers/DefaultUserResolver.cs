using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Enums;

namespace Brother.Tests.Specs.Resolvers
{
    public class DefaultUserResolver : IUserResolver
    {
        private readonly IContextData _contextData;
        private const string TYPE1_USERNAME_PATTERN = "MPS-{0}-{1}-{2}{3}@brother.co.uk";
        private const string TYPE1_PASSWORD_PATTERN = "{0}{1}1";
        private const string TYPE3_USERNAME_PATTERN = "MPS-{0}-{1}-{2}{3}@brother.co.uk";
        private const string TYPE3_PASSWORD_PATTERN = "{0}{1}9";
        private const string TYPE1AND3_USERNAME_PATTERN = "MPS-{0}-{1}-T3-{2}{3}@brother.co.uk";
        private const string TYPE1AND3_PASSWORD_PATTERN = "{0}{1}3";

        public DefaultUserResolver(IContextData contextData)
        {
            _contextData = contextData;
        }

        public string DealerUsername
        {
            get
            {
                return GetDealerUsername(_contextData.BusinessType);
            }
        }

        public string DealerPassword
        {
            get
            {
                return GetDealerPassword(_contextData.BusinessType);
            }
        }

        public string GetDealerUsername(BusinessType businessType)
        {
            string pattern;
            string loginPatternNumber;

            switch (businessType) {
                case BusinessType.Type1:
                    // Only Type1
                    pattern = TYPE1_USERNAME_PATTERN;
                    loginPatternNumber = "1";
                    break;
                case BusinessType.Type3:
                    // Only Type3
                    pattern = TYPE3_USERNAME_PATTERN;
                    loginPatternNumber = "9";
                    break;
                default:
                    // Both Type1 & Type3
                    // For default case, instead of throwing an exception, use a login id which is handling both Type1 & Type3
                    pattern = TYPE1AND3_USERNAME_PATTERN;
                    loginPatternNumber = "3";
                    break;
            }
            return string.Format(pattern, _contextData.Country.BrotherCode, _contextData.Environment, "Dealer", loginPatternNumber);
        }

        public string GetDealerPassword(BusinessType businessType)
        {
            string pattern;

            switch (businessType)
            {
                case BusinessType.Type1:
                    pattern = TYPE1_PASSWORD_PATTERN;
                    break;
                case BusinessType.Type3:
                    pattern = TYPE3_PASSWORD_PATTERN;
                    break;
                default:
                    pattern = TYPE1AND3_PASSWORD_PATTERN;
                    break;
            }

            return string.Format(pattern, _contextData.Country.PasswordCountryAbbreviation, "dealer");
        }

        public string LocalOfficeAdminUsername { get; set; }
        public string LocalOfficeAdminPassword { get; set; }

        public string LocalOfficeApproverUsername
        {
            get
            {
                return string.Format(TYPE1_USERNAME_PATTERN, _contextData.Country.BrotherCode, _contextData.Environment, "LOApprover", "");
            }
        }

        public string LocalOfficeApproverPassword
        {
            get
            {
                return string.Format(TYPE1_PASSWORD_PATTERN, _contextData.Country.PasswordCountryAbbreviation, "loapprover");
            }
        }

        public string BIEAdminUsername { get; set; }
        public string BIEAdminPassword { get; set; }
        public string BankUsername { get; set; }
        public string BankPassword { get; set; }
        public string ServiceDeskUsername { get; set; }
        public string ServiceDeskPassword { get; set; }

    }
}
