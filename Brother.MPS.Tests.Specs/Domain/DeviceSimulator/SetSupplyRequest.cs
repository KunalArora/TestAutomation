using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Domain.DeviceSimulator
{
    /// <summary>
    /// Represents a json request to the device simulator for setting supply items
    /// </summary>
    public class SetSupplyRequest
    {
        public string id { get; set; }
        public List<SetSupplyRequestItem> items { get; set; }
    }
}
