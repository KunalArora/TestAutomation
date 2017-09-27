using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Helpers
{
    public interface IProposalHelper
    {
        string GenerateProposalName();
        string GenerateProposalName(string pattern, string[] args);
    }
}
