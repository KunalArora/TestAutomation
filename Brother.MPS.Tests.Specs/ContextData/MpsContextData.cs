﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.ContextData
{
    public class MpsContextData : IContextData
    {
        public string Country { get; set; }
        public string CountryIso { get; set; }
        public string CountryBrotherCode { get; set; }
        public string Culture { get; set; }
        public string BaseUrl { get; set; }
        public string Environment { get; set; }
        public string EnvironmentName { get; set; }
    }
}
