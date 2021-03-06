﻿using Brother.Tests.Common.ContextData;

namespace Brother.Tests.Specs.Resolvers
{
    public class DefaultUrlResolver : IUrlResolver
    {
        private readonly IContextData _contextData;

        private const string TEST_BASE_URL_FORMAT = "https://online65.{0}.cds.test.brother.eu.com";
        private const string TEST_CMS_URL_FORMAT = "http://online65.{0}.cms.test.brother.eu.com";
        private const string TEST_ATYOURSIDE_URL_FORMAT = "https://atyourside.{0}.cds.test.brother.eu.com";

        private const string UAT_BASE_URL_FORMAT = "https://online65.{0}.cds.uat.brother.eu.com";
        private const string UAT_CMS_URL_FORMAT = "https://online65.{0}.cms.uat.brother.eu.com";
        private const string UAT_ATYOURSIDE_URL_FORMAT = "https://atyourside.{0}.cds.uat.brother.eu.com";

        private const string PRD_BASE_URL_FORMAT = "https://atyourside.brother.{0}";
        private const string PRD_CMS_URL_FORMAT = "http://online65.{0}.cms.prod.brother.eu.com";
        private const string PRD_ATYOURSIDE_URL_FORMAT = "https://atyourside.brother.{0}";

        private const string DEV_BASE_URL_FORMAT = "http://online.brother.{0}.local";
        private const string DEV_CMS_URL_FORMAT = "http://online.brother.{0}.local";

        public DefaultUrlResolver(IContextData contextData)
        {
            _contextData = contextData;
        }

        /// <summary>
        /// Return base url without trailing slash for current environment and country
        /// If ContextData.BaseUrl is not null it overrides environment / country
        /// </summary>
        public string BaseUrl
        {
            get
            {
                if (_contextData.BaseUrl != null)
                {
                    return _contextData.BaseUrl;
                }

                switch (_contextData.Environment.ToUpper())
                {
                    case "TEST":
                        return string.Format(TEST_BASE_URL_FORMAT, _contextData.Country.DomainSuffix);
                    case "UAT":
                        return string.Format(UAT_BASE_URL_FORMAT, _contextData.Country.DomainSuffix);
                    case "PROD":
                        return string.Format(PRD_BASE_URL_FORMAT, _contextData.Country.DomainSuffix);
                    case "DEV":
                        return string.Format(DEV_BASE_URL_FORMAT, _contextData.Country.DomainSuffix);
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// Return CMS url without trailing slash for current environment and country
        /// </summary>
        public string CmsUrl
        {
            get
            {
                switch (_contextData.Environment.ToUpper())
                {
                    case "TEST":
                        return string.Format(TEST_CMS_URL_FORMAT, _contextData.Country.DomainSuffix);
                    case "UAT":
                        return string.Format(UAT_CMS_URL_FORMAT, _contextData.Country.DomainSuffix);
                    case "PROD":
                        return string.Format(PRD_CMS_URL_FORMAT, _contextData.Country.DomainSuffix);
                    case "DEV":
                        return string.Format(DEV_CMS_URL_FORMAT, _contextData.Country.DomainSuffix);
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// Return AtYourSide url without trailing slash for current environment and country
        /// </summary>
        public string AtYourSideUrl
        {
            get
            {
                switch (_contextData.Environment.ToUpper())
                {
                    case "TEST":
                        return string.Format(TEST_ATYOURSIDE_URL_FORMAT, _contextData.Country.DomainSuffix);
                    case "UAT":
                        return string.Format(UAT_ATYOURSIDE_URL_FORMAT, _contextData.Country.DomainSuffix);
                    case "PROD":
                        return string.Format(PRD_ATYOURSIDE_URL_FORMAT, _contextData.Country.DomainSuffix);
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
