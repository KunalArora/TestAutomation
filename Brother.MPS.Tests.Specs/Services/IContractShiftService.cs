using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Services
{
    public interface IContractShiftService
    {   
        /// <summary>
        ///  Can shift the contract to a previous date and also generate invoice bills and print counts using the API.
        /// </summary>
        /// <param name="contractId">Same as Proposal Id</param>
        /// <param name="timeoffset">The number of units to move the contract by. Must be zero or greater.</param>
        /// <param name="timeoffsetunit">Possible values are d, m or y (days, months or years)</param>
        /// <param name="generateprintcounts">Indicates whether to automatically generate print counts. Either true or false</param>
        /// <param name="generateinvoices">Indicates whether to automatically generate invoices. Either true or false</param>
        /// <param name="printvolume">Possible values are Any, Low, Mid, High and VeryHigh</param>
        void ContractTimeShiftCommand(int contractId, int timeoffset, string timeoffsetunit, bool generateprintcounts, bool generateinvoices, string printvolume);
    }
}
