using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Specs.Domain;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;

namespace Brother.Tests.Specs.Services
{
    public class CountryService : ICountryService
    {
        private List<Country> _countries = new List<Country>();

        public CountryService()
        {
            InitialiseCountries();
        }

        public Country GetByCountryIso(string countryIso)
        {
            return _countries.First(x => x.CountryIso.Equals(countryIso));
        }

        public Country GetByName(string name)
        {
            return _countries.First(x => x.Name.Equals(name));
        }

        public Country GetByBrotherCode(string brotherCode)
        {
            return _countries.First(x => x.BrotherCode.Equals(brotherCode));
        }

        private void InitialiseCountries()
        {

            _countries.Add(new Country
            {
                CountryIso = "GB",
                Name = "United Kingdom",
                BrotherCode = "BUK",
                Cultures = new List<string> { "en-GB" },
                DomainSuffix = "co.uk",
                PasswordCountryAbbreviation = "UK"
            });

            _countries.Add(new Country
            {
                CountryIso = "IE",
                Name = "Ireland",
                BrotherCode = "BIR",
                Cultures = new List<string> { "en-IE" },
                DomainSuffix = "ie"
            });

            _countries.Add(new Country
            {
                CountryIso = "AT",
                Name = "Austria",
                BrotherCode = "BAT",
                Cultures = new List<string> { "de-AT" },
                DomainSuffix = "at"
            });

            _countries.Add(new Country
            {
                CountryIso = "BE",
                Name = "Belgium",
                BrotherCode = "BBE",
                Cultures = new List<string> { "nl-BE", "fr-BE" },
                DomainSuffix = "fr"
            });

            _countries.Add(new Country
            {
                CountryIso = "CH",
                Name = "Switzerland",
                BrotherCode = "BSW",
                Cultures = new List<string> { "fr-CH", "de-CH" },
                DomainSuffix = "ch"
            });

            _countries.Add(new Country
            {
                CountryIso = "DE",
                Name = "Germany",
                BrotherCode = "BIG",
                Cultures = new List<string> { "de-DE" },
                DomainSuffix = "de"
            });

            _countries.Add(new Country
            {
                CountryIso = "DK",
                Name = "Denmark",
                BrotherCode = "BND",
                Cultures = new List<string> { "da-DK" },
                DomainSuffix = "dk"
            });

            _countries.Add(new Country
            {
                CountryIso = "ES",
                Name = "Spain",
                BrotherCode = "BES",
                Cultures = new List<string> { "es-ES" },
                DomainSuffix = "es"
            });

            _countries.Add(new Country
            {
                CountryIso = "FI",
                Name = "Finland",
                BrotherCode = "BNF",
                Cultures = new List<string> { "fi-FI" },
                DomainSuffix = "fi"
            });

            _countries.Add(new Country
            {
                CountryIso = "IT",
                Name = "Italy",
                BrotherCode = "BIT",
                Cultures = new List<string> { "it-IT" },
                DomainSuffix = "it"
            });

            _countries.Add(new Country
            {
                CountryIso = "NL",
                Name = "Netherlands",
                BrotherCode = "BNL",
                Cultures = new List<string> { "nl-NL" },
                DomainSuffix = "nl"
            });

            _countries.Add(new Country
            {
                CountryIso = "NO",
                Name = "Norway",
                BrotherCode = "BNN",
                Cultures = new List<string> { "nb-NO" },
                DomainSuffix = "no"
            });

            _countries.Add(new Country
            {
                CountryIso = "PL",
                Name = "Poland",
                BrotherCode = "BPL",
                Cultures = new List<string> { "pl-PL" },
                DomainSuffix = "pl"
            });

            _countries.Add(new Country
            {
                CountryIso = "SE",
                Name = "Sweden",
                BrotherCode = "BNS",
                Cultures = new List<string> { "sv-SE" },
                DomainSuffix = "se"
            });

        }
    }
}
