using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Common.Domain.SpecFlowTableMappings
{
    public class Country
    {
        private string _passwordCountryAbbreviation = string.Empty;

        public string CountryIso { get; set; }
        public string Name { get; set; }
        public string BrotherCode { get; set; }
        public List<string> Cultures { get; set; }
        public string DomainSuffix { get; set; }

        public string PasswordCountryAbbreviation
        {
            get
            {
                return _passwordCountryAbbreviation == string.Empty ? CountryIso : _passwordCountryAbbreviation;
            }
            set
            {
                _passwordCountryAbbreviation = value;
            }
        }
    }
}
