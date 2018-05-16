using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using NUnit.Framework;

namespace Brother.Tests.Specs.UnitTests
{
    /// <summary>
    /// A simple test harness
    /// </summary>
    [TestFixture(Category = "Integration")]
    public class CountryServiceTests
    {
        private CountryService _countryService;

        public CountryServiceTests()
        {
            _countryService = new CountryService();    
        }

        [Test]
        public void CanGetValidCountryWithSingleCultureByCulture()
        {
            //Arrange
            var culture = "en-GB";

            //Act
            var country = _countryService.GetByCulture(culture);

            //Assert
            Assert.AreEqual(country.CountryIso, CountryIso.UnitedKingdom);
        }

        [Test]
        public void CanGetValidCountryWithMultipleCulturesByCulture()
        {
            //Arrange
            var culture = "fr-CH";

            //Act
            var country = _countryService.GetByCulture(culture);

            //Assert
            Assert.AreEqual(country.CountryIso, CountryIso.Switzerland);
        }
    }
}
