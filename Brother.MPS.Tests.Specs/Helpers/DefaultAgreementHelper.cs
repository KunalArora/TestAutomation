using System;

namespace Brother.Tests.Specs.Helpers
{
	public class DefaultAgreementHelper: IAgreementHelper
	{
		private const string AGREEMENT_NAME_PATTERN = "MPS_Smoke_{0}-{1}";

		public string GenerateAgreementName()
		{
			return GenerateAgreementName(AGREEMENT_NAME_PATTERN, new string[] { surname(), DateTime.Now.ToString("MMdHHmmss")});
		}

		public string GenerateAgreementName(string pattern, string[] args)
		{
			return string.Format(pattern, args);
		}

		public string GenerateReference()
		{
			return (new Random().Next(10000000, 99999999).ToString());
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

