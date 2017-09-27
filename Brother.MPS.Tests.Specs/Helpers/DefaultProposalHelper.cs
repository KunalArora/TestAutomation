using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Helpers
{
    public class DefaultProposalHelper : IProposalHelper
    {
        private const string PROPOSAL_NAME_PATTERN = "MPS_Smoke_{0}-{1}";

        public string GenerateProposalName()
        {
            return GenerateProposalName(PROPOSAL_NAME_PATTERN, new string[] { surname(), DateTime.Now.ToString("MMdHHmmss")});
        }

        public string GenerateProposalName(string pattern, string[] args)
        {
            return string.Format(pattern, args);
        }

        private string surname()
        {
            return availableSurnames[new Random().Next(availableSurnames.Length)];
        }

        #region value arrays

        private String[] availableSurnames = {
                                 "Kush",
							     "Stoltz",
							     "Prisco",
							     "Hemmingway",
							     "Lambright",
							     "Babin",
							     "Conatser",
							     "Jefferys",
							     "Strandberg",
							     "Farrand",
							     "Hartgrove",
							     "Lacey",
							     "Peralez",
							     "Schloss",
							     "Triche",
							     "Mackson",
							     "Segal",
							     "Salazar",
							     "Ross",
							     "Bessler"
						        };

        #endregion
    }
}
