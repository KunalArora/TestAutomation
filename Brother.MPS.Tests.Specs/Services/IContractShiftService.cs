using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Services
{
    public interface IContractShiftService
    {
        void ContractTimeShiftCommand(int contractId, int timeoffset, string timeoffsetunit, bool generateprintcounts, bool generateinvoices, string printvolume);
    }
}
