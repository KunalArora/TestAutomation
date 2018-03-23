using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using System.Collections.Generic;
using System.Linq;

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

        public Country GetByCulture(string culture)
        {
            return _countries.First(x => x.Cultures.Any(c => c == culture));
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
                PasswordCountryAbbreviation = "UK",
                AtYourSideEnabled = true,
                LogicSettings = new LogicSettings
                {
                    IsNextDealerProposalsCreateTermAndTypePage = false
                }
            });

            _countries.Add(new Country
            {
                CountryIso = "IE",
                Name = "Ireland",
                BrotherCode = "BIR",
                Cultures = new List<string> { "en-IE" },
                DomainSuffix = "ie",
                LogicSettings = new LogicSettings
                {
                    IsNextDealerProposalsCreateTermAndTypePage = false
                }
            });

            _countries.Add(new Country
            {
                CountryIso = "AT",
                Name = "Austria",
                BrotherCode = "BAT",
                Cultures = new List<string> { "de-AT" },
                DomainSuffix = "at",
                LogicSettings = new LogicSettings
                {
                    IsNextDealerProposalsCreateTermAndTypePage = true,
                }
            });

            _countries.Add(new Country
            {
                CountryIso = "BE",
                Name = "Belgium",
                BrotherCode = "BBE",
                Cultures = new List<string> { "nl-BE", "fr-BE" },
                DomainSuffix = "fr",
                LogicSettings = new LogicSettings
                {
                    IsNextDealerProposalsCreateTermAndTypePage = false
                }
            });

            _countries.Add(new Country
            {
                CountryIso = "CH",
                Name = "Switzerland",
                BrotherCode = "BSW",
                Cultures = new List<string> { "fr-CH", "de-CH" },
                DomainSuffix = "ch",
                LogicSettings = new LogicSettings
                {
                    IsNextDealerProposalsCreateTermAndTypePage = false
                }
            });

            _countries.Add(new Country
            {
                CountryIso = "DE",
                Name = "Germany",
                BrotherCode = "BIG",
                Cultures = new List<string> { "de-DE" },
                DomainSuffix = "de",
                LogicSettings = new LogicSettings
                {
                    IsNextDealerProposalsCreateTermAndTypePage = true,
                }
            });

            _countries.Add(new Country
            {
                CountryIso = "DK",
                Name = "Denmark",
                BrotherCode = "BND",
                Cultures = new List<string> { "da-DK" },
                DomainSuffix = "dk",
                LogicSettings = new LogicSettings
                {
                    IsNextDealerProposalsCreateTermAndTypePage = false
                }
            });

            _countries.Add(new Country
            {
                CountryIso = "ES",
                Name = "Spain",
                BrotherCode = "BES",
                Cultures = new List<string> { "es-ES" },
                DomainSuffix = "es",
                LogicSettings = new LogicSettings
                {
                    IsNextDealerProposalsCreateTermAndTypePage = false
                }
            });

            _countries.Add(new Country
            {
                CountryIso = "FI",
                Name = "Finland",
                BrotherCode = "BNF",
                Cultures = new List<string> { "fi-FI" },
                DomainSuffix = "fi",
                LogicSettings = new LogicSettings
                {
                    IsNextDealerProposalsCreateTermAndTypePage = false
                }
            });

            _countries.Add(new Country
            {
                CountryIso = "IT",
                Name = "Italy",
                BrotherCode = "BIT",
                Cultures = new List<string> { "it-IT" },
                DomainSuffix = "it",
                LogicSettings = new LogicSettings
                {
                    IsNextDealerProposalsCreateTermAndTypePage = false
                }
            });

            _countries.Add(new Country
            {
                CountryIso = "NL",
                Name = "Netherlands",
                BrotherCode = "BNL",
                Cultures = new List<string> { "nl-NL" },
                DomainSuffix = "nl",
                LogicSettings = new LogicSettings
                {
                    IsNextDealerProposalsCreateTermAndTypePage = false
                }
            });

            _countries.Add(new Country
            {
                CountryIso = "NO",
                Name = "Norway",
                BrotherCode = "BNN",
                Cultures = new List<string> { "nb-NO" },
                DomainSuffix = "no",
                LogicSettings = new LogicSettings
                {
                    IsNextDealerProposalsCreateTermAndTypePage = false
                }
            });

            _countries.Add(new Country
            {
                CountryIso = "PL",
                Name = "Poland",
                BrotherCode = "BPL",
                Cultures = new List<string> { "pl-PL" },
                DomainSuffix = "pl",
                LogicSettings = new LogicSettings
                {
                    IsNextDealerProposalsCreateTermAndTypePage = false
                }
            });

            _countries.Add(new Country
            {
                CountryIso = "SE",
                Name = "Sweden",
                BrotherCode = "BNS",
                Cultures = new List<string> { "sv-SE" },
                DomainSuffix = "se",
                LogicSettings = new LogicSettings
                {
                    IsNextDealerProposalsCreateTermAndTypePage = false
                }
            });

        }
    }
}
