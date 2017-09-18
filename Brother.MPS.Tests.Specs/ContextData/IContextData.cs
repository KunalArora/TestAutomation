using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.ContextData
{
    public interface IContextData
    {
        string Country { get; set; }
        string CountryIso { get; set; }
        string CountryBrotherCode { get; set; }
        string Culture { get; set; }
        string BaseUrl { get; set; }
        string EnvironmentName { get; set; }
        string Environment { get; set; }
    }
}
