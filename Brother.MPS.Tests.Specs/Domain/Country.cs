using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Domain
{
    public class Country
    {
        public string CountryIso { get; set; }
        public string Name { get; set; }
        public string BrotherCode { get; set; }
        public List<string> Cultures { get; set; }
        public string DomainSuffix { get; set; }
    }
}
