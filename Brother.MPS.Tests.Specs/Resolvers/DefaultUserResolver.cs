﻿using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.RuntimeSettings;
using System;

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
            string loginPatternNumber;

            if (_contextData.SpecificDealerUsername != null)
            {
                return _contextData.SpecificDealerUsername;
            }

            switch (businessType) {
                case BusinessType.Type1:
                    // Only Type1
                    if (_contextData.Country.CountryIso.Equals(CountryIso.Switzerland))
                    {
                        loginPatternNumber = "2";
                    }
                    else
                    {
                        loginPatternNumber = "1";
                    }
                    break;
                case BusinessType.Type3:
                    // Only Type3
                    if (_runtimeSettings.DefaultType3DealerUsername != null)
                    {
                        return _runtimeSettings.DefaultType3DealerUsername;
                    }
                    loginPatternNumber = "3";
                    break;
                default:
                    throw new Exception(string.Format("Invalid business type = {0} specifed in DefaultUserResolver.GetDealerUsername", businessType));
            }

            return string.Format(USERNAME_PATTERN, _contextData.Country.BrotherCode, _contextData.Environment, "Dealer", loginPatternNumber);
        }

        public string GetDealerPassword(BusinessType businessType)
        {
            string loginPatternNumber;

            if (_contextData.SpecificDealerPassword != null)
            {
                return _contextData.SpecificDealerPassword;
            }

            switch (businessType)
            {
                case BusinessType.Type1:
                    if (_contextData.Country.CountryIso.Equals(CountryIso.Switzerland))
                    {
                        loginPatternNumber = "2";
                    }
                    else
                    {
                        loginPatternNumber = "1";
                    }
                    break;
                case BusinessType.Type3:
                    if (_runtimeSettings.DefaultType3DealerPassword != null)
                    {
                        return _runtimeSettings.DefaultType3DealerPassword;
                    }
                    loginPatternNumber = "3";
                    break;
                default:
                    throw new Exception(string.Format("Invalid business type = {0} specifed in DefaultUserResolver.GetDealerPassword", businessType));
            }

            return string.Format(PASSWORD_PATTERN, _contextData.Country.PasswordCountryAbbreviation, "dealer", loginPatternNumber);
        }

        public string LocalOfficeAdminUsername
        {
            get
            {
                return string.Format(USERNAME_PATTERN, _contextData.Country.BrotherCode, _contextData.Environment, "LOAdmin", "");
            }
        }
        public string LocalOfficeAdminPassword 
        {
            get
            {
                switch (_contextData.Environment.ToUpper())
                {
                    case "UAT":
                        return string.Format(PASSWORD_PATTERN, _contextData.Country.PasswordCountryAbbreviation,"loadmin", 1);
                    default:
                        return string.Format(PASSWORD_PATTERN, _contextData.Country.PasswordCountryAbbreviation,"admin", 1);
                }
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

        public string BIEAdminUsername { get; set; }
        public string BIEAdminPassword { get; set; }
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
