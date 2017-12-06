using System;

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

        public string SelectPrinter()
        {
            return "DCP-8110DN";
        }

        public string SelectPrinter(string countryIso)
        {
            //TODO: hit MPS db to get valid models for country?
            return "DCP-8110DN";
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
