using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Common.Domain;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;

namespace Brother.Tests.Specs.Services
{
    public interface ICountryService
    {
        Country GetByCountryIso(string countryIso);
        Country GetByName(string name);
        Country GetByBrotherCode(string brotherCode);
    }
}
