using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.RuntimeSettings;
using System;
using System.Collections.Generic;

namespace Brother.Tests.Specs.Resolvers
{
    public class DefaultUserResolver : IUserResolver
    {
        private readonly IContextData _contextData;
        private readonly IRuntimeSettings _runtimeSettings;
        private const string OLD_USERNAME_PATTERN = "MPS-{0}-{1}-{2}{3}@brother.co.uk";
        private const string USERNAME_PATTERN = "MPS-{0}-{1}-{2}{3}-Auto@brother.co.uk";
        private const string PASSWORD_PATTERN = "{0}{1}{2}";

        public DefaultUserResolver(IContextData contextData, IRuntimeSettings runtimeSettings)
        {
            _contextData = contextData;
            _runtimeSettings = runtimeSettings;
        }

        public string DealerUsername
        {
            get
            {
                return GetDealerUsername(_contextData.BusinessType, _contextData.DealerAccountType);
            }
        }

        public string DealerPassword
        {
            get
            {
                return GetDealerPassword(_contextData.BusinessType, _contextData.DealerAccountType);
            }
        }

        private string GetDealerUsername(BusinessType businessType, DealerAccountType? dealerAccountType)
        {

            if (_contextData.SpecificDealerUsername != null)
            {
                return _contextData.SpecificDealerUsername;
            }

            // keyName ex. 
            // DefaultType1DealerUsernameBUK
            // DefaultType3DealerUsernameBIG
            // DefaultType1And3DealerUsernameBSW
            var keyNameTypeX = dealerAccountType != null ? Enum.GetName(typeof(DealerAccountType), dealerAccountType) : Enum.GetName(typeof(BusinessType), businessType);
            var keyName = string.Format("Default{0}DealerUsername{1}", keyNameTypeX, _contextData.Country.BrotherCode);
            if (_runtimeSettings.DefaultDealerUsername.ContainsKey(keyName))
            {
                return _runtimeSettings.DefaultDealerUsername[keyName];
            }
            // return ex. MPS-BUK-UAT-Dealer1-Auto@brother.co.uk
            var loginPatternNumber = dealerAccountType != null ? (int)dealerAccountType : (int)businessType;
            return string.Format(USERNAME_PATTERN, _contextData.Country.BrotherCode, _contextData.Environment, "Dealer", loginPatternNumber);

        }

        private string GetDealerPassword(BusinessType businessType, DealerAccountType? dealerAccountType)
        {

            if (_contextData.SpecificDealerPassword != null)
            {
                return _contextData.SpecificDealerPassword;
            }
            // keyName ex. 
            // DefaultType1DealerPasswordBUK
            // DefaultType3DealerPasswordBIG
            // DefaultType1And3DealerPasswordBSW
            var keyNameTypeX = dealerAccountType != null ? Enum.GetName(typeof(DealerAccountType), dealerAccountType) : Enum.GetName(typeof(BusinessType), businessType);
            var keyName = string.Format("Default{0}DealerPassword{1}", keyNameTypeX, _contextData.Country.BrotherCode);
            if (_runtimeSettings.DefaultDealerPassword.ContainsKey(keyName))
            {
                return _runtimeSettings.DefaultDealerPassword[keyName];
            }
            var loginPatternNumber = (int)businessType; // note: probably there is no password for Type1And3 (ex. UKdealer13)
            return string.Format(PASSWORD_PATTERN, _contextData.Country.PasswordCountryAbbreviation, "dealer", loginPatternNumber);

        }

        public string LocalOfficeAdminUsername
        {
            get
            {
                var userName =  string.Format(USERNAME_PATTERN, _contextData.Country.BrotherCode, _contextData.Environment, "LOAdmin", "");
                return LocalOfficeAdminUsernameReplaceMap.ContainsKey(userName) ? LocalOfficeAdminUsernameReplaceMap[userName] : userName;
            }
        }

        private readonly Dictionary<string, string> LocalOfficeAdminUsernameReplaceMap = new Dictionary<string, string>()
        {
            {"MPS-BSW-UAT-LOAdmin-Auto@brother.co.uk", "MPS-BSW-UAT-LOAdmin-Auto2@brother.co.uk" },
            {"MPS-BSW-TEST-LOAdmin-Auto@brother.co.uk", "MPS-BSW-TEST-LOAdmin-Auto2@brother.co.uk" }
        };

        public string LocalOfficeAdminPassword 
        {
            get
            {
                return string.Format(PASSWORD_PATTERN, _contextData.Country.PasswordCountryAbbreviation, "admin", 1);
            }
        }

        public string LocalOfficeApproverUsername
        {
            get
            {
                if (_contextData.SpecificLocalOfficeApproverUsername != null)
                {
                    return _contextData.SpecificLocalOfficeApproverUsername;
                }

                return string.Format(USERNAME_PATTERN, _contextData.Country.BrotherCode, _contextData.Environment, "LOApprover", "");
            }
        }

        public string LocalOfficeApproverPassword
        {
            get
            {
                if (_contextData.SpecificLocalOfficeApproverPassword != null)
                {
                    return _contextData.SpecificLocalOfficeApproverPassword;
                }

                return string.Format(PASSWORD_PATTERN, _contextData.Country.PasswordCountryAbbreviation, "loapprover", 1);
            }
        }

        public string BIEAdminUsername 
        {
            get
            {
                // TODO: Change this to use new USERNAME_PATTERN once account has been prepared
                return string.Format(OLD_USERNAME_PATTERN, "BIE", _contextData.Environment, "BIEAdmin", ""); // "BIE" is hard-coded as only one account for Europe
            }
        }

        public string BIEAdminPassword
        {
            get 
            {
                return string.Format(PASSWORD_PATTERN, "BIE", "admin", 1); // "BIE" is hard-coded as only one account for Europe
            }
        }

        public string BankUsername
        {
            get
            {
                return string.Format(USERNAME_PATTERN, _contextData.Country.BrotherCode, _contextData.Environment, "Bank", "");
            }
        }
        public string BankPassword
        {
            get
            {
                // ex. DEbank1
                return string.Format(PASSWORD_PATTERN, _contextData.Country.PasswordCountryAbbreviation, "bank", 1);
            }
        }

        public string ServiceDeskUsername 
        {
            get
            {
                return string.Format(USERNAME_PATTERN, _contextData.Country.BrotherCode, _contextData.Environment, "ServiceDesk", "");
            } 
        }
       
        public string ServiceDeskPassword 
        {
            get
            {
                return string.Format(PASSWORD_PATTERN, _contextData.Country.PasswordCountryAbbreviation, "service", 1);
            }
        }

        public string InstallerUsername
        {
            get
            {
                return string.Format(USERNAME_PATTERN, _contextData.Country.BrotherCode, _contextData.Environment, "Installer", "");
            }
        }

        public string FinanceUsername
        {
            get
            {
                // ex. MPS-BUK-UAT-Finance1@brother.co.uk
                return string.Format(OLD_USERNAME_PATTERN, _contextData.Country.BrotherCode, _contextData.Environment, "Finance", 1);
            }
        }

        public string FinancePassword
        {
            get
            {
                // ex. UKfinance1
                return string.Format(PASSWORD_PATTERN, _contextData.Country.PasswordCountryAbbreviation, "finance", 1);
            }
        }
    }
}
