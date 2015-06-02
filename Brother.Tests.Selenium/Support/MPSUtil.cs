using System;
using System.Globalization;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Selenium.Lib.Support
{
    
    public class MpsUtil
    {

        /// <summary>
        /// Generates a unique Proposal Name
        /// </summary>
        /// <returns>Generated proposal Name as string</returns>
        public static string GenerateUniqueProposalName()
        {
            var generatedProposalName = "MPS_" + SurName()+ "-" + FirstName();
            return generatedProposalName;
        }

        public static string GenerateUniqueEmail()
        {
            var generatedEmailAddress = FirstName() +
                DateTime.Now.ToString("yyyyMMdHHmmss")
                +"@mailinator.com";
            return generatedEmailAddress;
        }

        public static string SomeDaysFromToday()
        {
            var todayDate = DateTime.Now;
            var someDaysIntheFuture = todayDate.AddDays(30);

            return someDaysIntheFuture.ToString("dd/MM/yyyy");

        }

        public static string CustomerReference()
        {
            var todayDate = DateTime.Now;

            return "CUST" + todayDate.ToString("yyyyMMdHHmmss");

        }

        public static string BankInternalReference()
        {
            var todayDate = DateTime.Now;

            return "INTER" + todayDate.ToString("yyyyMMdHHmmss");

        }

        public static string DealerProfileSample()
        {
            var todayDate = DateTime.Now;

            var profile= "Profile Dealer For now " + todayDate.ToString("yyyyMMdHHmmss");
            
            return profile;

        }

        
        /// <summary>
        /// Generates a unique Lead Code Reference
        /// </summary>
        /// <returns>Generated Lead Code Reference as string</returns>
        public static string GenerateUniqueLeadCodeRef()
        {
            var generatedLeadCodeRef = "Reference_"
                + DateTime.Now.ToString("yyyyMMdHHmmss");
            return generatedLeadCodeRef;
        }

        public static string PrinterUnderTest()
        {
            String[] printerName ={
                                        "DCP-8110DN",
                                        "DCP-8250DN",
                                        "HL-5450DN",
                                        //"HL-5450DNT",
                                        "HL-5470DW",
                                        //"HL-6180DW",
                                       // "HL-6180DWT",
                                        "MFC-8520DN",
                                        "MFC-8950DW",
                                        //"MFC-8950DWT",
                                        "MFC-8510DN",
                                        "DCP-L8400CDN",
                                        "DCP-L8450CDW",
                                        "HL-L8250CDN",
                                        "HL-L8350CDW",
                                        "HL-L9200CDWT",
                                        "MFC-L8650CDW",
                                        "MFC-L8850CDW",
                                        "MFC-L9550CDWT",
                                        "HL-S7000DN",
                                        "HL-3150CDW",
                                        "HL-3170CDW",
                                        "DCP-9020CDW",
                                        "MFC-9140CDN",
                                        "MFC-9330CDW",
                                        "MFC-9340CDW"
                                    };

            var generatedPrinterName = printerName[new Random().Next(22)];
            ScenarioContext.Current["GeneratedPrinterName"] = generatedPrinterName;
            return generatedPrinterName;
        }

        public static string CompanyName()
        {
            String[] companyName = {
                                    "Lila Schmidt", 
								    "Blue Hollow",
								    "Middle Mall",
								    "Little Brook Carrefour",
								    "Hidden Run",
								    "Lazy Mountain Walk",
								    "Iron Elk Concession",
								    "Lost Harbour",
								    "Silent Field",
								    "Rocky Bear Townline",
								    "Cotton Blossom Trail",
								    "Emerald Mews",
								    "Cozy Pike",
								    "Colonial Avenue",
								    "Rustic Parade",
								    "Fallen Pond Campus",
								    "Heather Spring Via",
								    "Stony Prairie Dell",
								    "Honey Pines",
								    "Wishing Bay"
								};

            var generatedCompanyName = companyName[new Random().Next(20)] + " Ltd";

            return generatedCompanyName;
            
        }

        public static string BusinessType()
        {
            String[] companyName = {
                                    "15",
                                    "16",
                                    "17",
                                    "18",
                                    "19",
                                    "20",
                                    "21",
                                    "22",
                                    "23",
                                    "24",
                                    "25",
                                    "26",
                                    "27",
                                    "28",
                                    "29",
                                    "30"
								};

            var generatedBusinessType = companyName[new Random().Next(15)];

            return generatedBusinessType;

        }

        public static string AccountNumber()
        {
            String[] companyName = {
                                    "41256325",
                                    "78596314",
                                    "78963524",
                                    "54896547",
                                    "12458963",
                                    "68754123",
                                    "58975462",
                                    "42547855",
                                    "87589643",
                                    "32589624",
                                    "47896532",
                                    "35478955",
                                    "65478545",
                                    "78596513",
                                    "32589654",
                                    "96583241",
                                    "58965874",
                                    "54896532",
                                    "32564857",
                                    "69854475"
								};

            var generatedAccountNumber = companyName[new Random().Next(19)];

            return generatedAccountNumber;

        }

        public static string VatNumber()
        {
            String[] companyName = {"999999999",
                                    "369852155",
                                    "547889956",
                                    "564557888",
                                    "963284555",
                                    "899254856",
                                    "789546212",
                                    "154245256",
                                    "852369456",
                                    "654799852",
                                    "357159258",
                                    "987321456",
                                    "321654987",
                                    "302589632",
                                    "901254875",
                                    "563201458",
                                    "632501478",
                                    "520145789",
                                    "302501449",
                                    "902586423"
								};

            var generatedVatNumber = companyName[new Random().Next(19)];

            return generatedVatNumber;

        }

        public static string CreditReformNumber()
        {
            String[] companyName = {"599999998",
                                    "869852154",
                                    "347889955",
                                    "064557889",
                                    "163284553",
                                    "099254850",
                                    "689546216",
                                    "854245257",
                                    "452369453",
                                    "554799850",
                                    "957159257",
                                    "787321451",
                                    "121654983",
                                    "702589636",
                                    "201254873",
                                    "663201454",
                                    "732501478",
                                    "320145781",
                                    "102501440",
                                    "702586420"
								};

            var generatedCreditReformNumber = companyName[new Random().Next(19)];

            return generatedCreditReformNumber;

        }

        public static string BankCodeNumber()
        {
            String[] companyName = {"415287",
                                    "011001",
                                    "201452",
                                    "365215",
                                    "658963",
                                    "325631",
                                    "789652",
                                    "325698",
                                    "455825",
                                    "214556",
                                    "945652",
                                    "145278",
                                    "658965",
                                    "789654",
                                    "123545",
                                    "475565",
                                    "012301",
                                    "025831",
                                    "102145",
                                    "789632"
								};

            var generatedCreditReformNumber = companyName[new Random().Next(19)];

            return generatedCreditReformNumber;

        }

        public static string PropertyNumber()
        {
            String[] propertyNumber = {
                                        "6980", 
								        "1431",
								        "39",
								        "8324",
								        "1614",
								        "7514",
								        "6163",
								        "6661",
								        "9711",
								        "6116",
								        "5483",
								        "4085",
								        "1634",
								        "1706",
								        "6262",
								        "5995",
								        "4655",
								        "3818",
								        "8935",
								        "4526"
								    };

            var generatedPropertyNumber = propertyNumber[new Random().Next(20)];

            return generatedPropertyNumber;

        }

        public static string PropertyStreet()
        {
            String[] companyAdd = {
                                    "Sleepy Path", 
								    "Blue Hollow",
								    "Middle Mall",
								    "Little Brook Carrefour",
								    "Hidden Run",
								    "Lazy Mountain Walk",
								    "Iron Elk Concession",
								    "Lost Harbour",
								    "Silent Field",
								    "Rocky Bear Townline",
								    "Cotton Blossom Trail",
								    "Emerald Mews",
								    "Cozy Pike",
								    "Colonial Avenue",
								    "Rustic Parade",
								    "Fallen Pond Campus",
								    "Heather Spring Via",
								    "Stony Prairie Dell",
								    "Honey Pines",
								    "Wishing Bay"
								};

            var generatedCompanyAdd = companyAdd[new Random().Next(20)];

            return generatedCompanyAdd;
        }

        public static string ContactTitle()
        {
            String[] contactTitle = {
                                        "Mr", 
								        "Mrs",
								       // "Ms",
                                        "Miss",
                                        //"Madam",
                                        //"Dr"
								    };

            var generatedContactTitle = contactTitle[new Random().Next(3)];

            switch (generatedContactTitle)
            {
                case "Mr":
                {
                    generatedContactTitle = "1";
                    break;
                }
                case "Mrs":
                {
                    generatedContactTitle = "2";
                    break;
                }
                case "Ms":
                {
                    generatedContactTitle = "3";
                    break;
                }
                case "Miss":
                {
                    generatedContactTitle = "4";
                    break; 
                }
                case "Madam":
                {
                    generatedContactTitle = "5";
                    break; 
                } 
                case "Dr":
                {
                    generatedContactTitle = "6";
                    break;
                }
                   
            }

            return generatedContactTitle;
        }

        public static string ContractLength()
        {
            String[] contractLength = {
                                        "3 years", 
								        "4 years",
								        "5 years"
								    };

            var generatedContractLength = contractLength[new Random().Next(3)];

            ScenarioContext.Current["GeneratedContractLength"] = generatedContractLength;

            switch (generatedContractLength)
            {
                case "3 years":
                {
                    generatedContractLength = "1";
                    break;
                }
                case "4 years":
                {
                    generatedContractLength = "2";
                    break;
                }
                case "5 years":
                {
                    generatedContractLength = "3";
                    break;
                }
            }

            return generatedContractLength;
        }

        public static string LeaseBillingCycle()
        {
            String[] leaseBillingCycle = {
                                        "3 Monthly", 
								        "4 Monthly"
								       // "6 Monthly"
								    };

            var generatedLeaseBillingCycle = leaseBillingCycle[new Random().Next(2)];
            ScenarioContext.Current["GeneratedLeaseBillingCycle"] = generatedLeaseBillingCycle;

            switch (generatedLeaseBillingCycle)
            {
                case "3 Monthly":
                    {
                        generatedLeaseBillingCycle = "6";
                        break;
                    }
                case "4 Monthly":
                    {
                        generatedLeaseBillingCycle = "7";
                        break;
                    }
                //case "6 Monthly":
                //    {
                //        generatedLeaseBillingCycle = "3";
                //        break;
                //    }
            }

            return generatedLeaseBillingCycle;
        }

        public static string PayPerClickBillingCycle()
        {
            String[] payPerBillingCycle = { 
								        "4 Monthly",
								        "6 Monthly"
								    };

            var generatedPayLeaseBillingCycle = payPerBillingCycle[new Random().Next(2)];
            ScenarioContext.Current["GeneratedPayLeaseBillingCycle"] = generatedPayLeaseBillingCycle;

            switch (generatedPayLeaseBillingCycle)
            {
                case "4 Monthly":
                    {
                        generatedPayLeaseBillingCycle = "8";
                        break;
                    }
                case "6 Monthly":
                    {
                        generatedPayLeaseBillingCycle = "9";
                        break;
                    }
            }

            return generatedPayLeaseBillingCycle;
        }

        public static string ContactPosition()
        {
            String[] contactPosition = {
                                        "Technician", 
								        "Director",
								        "Secretary",
								        "PA",
								        "Controller",
								        "CTO"
								    };

            var generatedContactPosition = contactPosition[new Random().Next(6)];

            return generatedContactPosition;
        }

        public static string PropertyTown()
        {
            String[] companyTown = {
                                    "Bayswater", 
								    "Belgravia",
								    "Bloomsbury",
								    "Clerkenwell",
								    "The City",
								    "Holborn",
								    "Mayfair",
								    "Paddington",
								    "Pimlico",
								    "Soho",
								    "St. John's Wood",
								    "Trafalgar Square",
								    "The West End",
								    "Westminster",
								    "Whitehall",
								    "Camden",
								    "Euston",
								    "Hampstead",
								    "Highgate",
								    "Kentish Town"
								};

            var generatedCompanyTown = companyTown[new Random().Next(20)];

            return generatedCompanyTown;
        }

        public static string CompanyTelephone()
        {
            String[] companyTelephone = {
                                            "07700 900300", 
								            "07700 900744",
								            "07700 900587",
								            "07700 900648",
								            "07700 900150",
								            "07700 900139",
								            "07700 900795",
								            "07700 900791",
								            "07700 900507",
								            "07700 900503",
								            "07700 900673",
								            "07700 900153",
								            "07700 900432",
								            "07700 900108",
								            "07700 900708",
								            "07700 900013",
								            "07700 900077",
								            "07700 900643",
								            "07700 900305",
								            "07700 900586"
								        };

            var generatedCompanyTelephone = companyTelephone[new Random().Next(20)];

            return generatedCompanyTelephone;
        }

        public static string SurName()
        {

            String[] lastName = {
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

            var surName = lastName[new Random().Next(20)];

            return surName;

        }

        public static string FirstName()
        {
            String[] name = {
                             "Aurelio",
				             "Emilie",
				             "Lashonda",
				             "Belkis",
				             "Jeffie",
				             "Ariana",
				             "Kassie",
				             "Randi",
				             "Omer",
				             "Shane",
				             "Delsie",
				             "Coleen",
				             "Sammie",
				             "Epifania",
				             "Brady",
				             "Lonna",
				             "Arnulfo",
				             "Roxanna",
				             "Mckenzie",
				             "Vada",
                             "Slater",
				             "Convest",
				             "Smarties",
				             "Graty",
				             "Bradon",
				             "Leonna",
				             "Argulfoh",
				             "Roxenne",
				             "McDonald",
				             "Misty"
				         };

            var firstName = name[new Random().Next(30)];

            return firstName;
        }

        public static string PostCode()
        {
                String[] zip = {
                                    "03189",
						            "03201",
						            "03400",
						            "03460",
						            "03500",
						            "03600",
						            "03610",
						            "03700",
						            "03710",
						            "03801",
						            "91111",
						            "08120",
						            "08170",
						            "08301",
						            "08370",
						            "08380",
						            "08397",
						            "08398",
						            "08401",
						            "08620"
					            };
                var postCode = zip[new Random().Next(20)];

            return postCode;
        }

        public static decimal GetValue(string money)
        {
            NumberFormatInfo poundNumberFormatInfo = new NumberFormatInfo();
            poundNumberFormatInfo.CurrencySymbol = "£";

            return decimal.Parse(money, NumberStyles.Currency, poundNumberFormatInfo);
        }
    }
}
