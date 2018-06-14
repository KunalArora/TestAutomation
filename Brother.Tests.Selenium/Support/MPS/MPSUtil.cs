using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Globalization;
using TechTalk.SpecFlow;
using System.Linq;
using Brother.Tests.Common.Domain.Constants;
using System.Text.RegularExpressions;

namespace Brother.Tests.Selenium.Lib.Support.MPS
{
    public static class MpsUtil
    {
        private const string DATESTRING_BUK = "dd/MM/yyyy";
        private const string DATESTRING_BIG = "dd/MM/yyyy";
        private const string DATESTRING_BSW = "dd.MM.yyyy";
        

        /// <summary>
        /// Generates a unique Proposal Name
        /// </summary>
        /// <returns>Generated proposal Name as string</returns>
        public static string GenerateUniqueProposalName()
        {
            var generatedProposalName = "MPS_Smoke_" + SurName() + 
                "-" + DateTime.Now.ToString("MMdHHmmss");
            HelperClasses.SpecFlow.SetContext("GeneratedProposalName", generatedProposalName);
            Helper.MsgOutput(String.Format("The proposal generated is {0}", generatedProposalName));
            return generatedProposalName;
        }


        public static string GetSubdealerUniqueEmail()
        {
            var subdealerEmailAddress = "subdealer_" + FirstName() +
                DateTime.Now.ToString("MMdHHmmss")
                + "@mailinator.com";
            HelperClasses.SpecFlow.SetContext("GeneratedSubdealerEmailAddress", subdealerEmailAddress);
            Helper.MsgOutput(String.Format("The unique email generated is {0}", subdealerEmailAddress));
            return subdealerEmailAddress;
        }
       
        public static string GenerateUniqueEmail()
        {
            var generatedEmailAddress = FirstName() +
                DateTime.Now.ToString("yyyyMMdHHmmss")
                +"@mailinator.com";
            HelperClasses.SpecFlow.SetContext("GeneratedEmailAddress", generatedEmailAddress);
            Helper.MsgOutput(String.Format("The unique email generated is {0}", generatedEmailAddress));
            return generatedEmailAddress;
        }

        public static string GetProposalByPassValue()
        {
            return HelperClasses.SpecFlow.GetContext("BypassOption");

        }

        public static String GetContractType()
        {
            return HelperClasses.SpecFlow.GetContext("ContractType");
        }

        public static string CreatedProposal()
        {
            var createdProposal = HelperClasses.SpecFlow.GetContext("GeneratedProposalName");
            return createdProposal;
        }

        public static string DateTimeString(DateTime dateTime, string countryIso)
        {
            switch(countryIso)
            {
                case CountryIso.UnitedKingdom:
                    return dateTime.ToString(DATESTRING_BUK);
                case CountryIso.Germany:
                    return dateTime.ToString(DATESTRING_BIG);
                case CountryIso.Switzerland:
                    return dateTime.ToString(DATESTRING_BSW);
                default:
                    throw new Exception("Date time string of the country with this countryISO cannot be formulated: " + countryIso);
            }
            
        }

        public static string SubdealerEmail()
        {
            var createdProposal = HelperClasses.SpecFlow.GetContext("GeneratedSubdealerEmailAddress");
            return createdProposal;
        }

        public static string GeneratedLeadCodeRef()
        {
            var createdProposal = HelperClasses.SpecFlow.GetContext("GeneratedLeadCodeRef");
            return createdProposal;
        }

        public static string CreatedEmail()
        {
            var createdProposal = HelperClasses.SpecFlow.GetContext("GeneratedEmailAddress");
            return createdProposal;
        }


        public static string CopiedProposal()
        {
            return CreatedProposal() + " (1)";
        }

        public static string SomeDaysFromToday(string countryIso = CountryIso.UnitedKingdom)
        {
            var todayDate = DateTime.Now;
            var someDaysIntheFuture = todayDate.AddDays(30);

            return DateTimeString(someDaysIntheFuture, countryIso);
        }

        public static string DateOfBirth(string countryIso)
        {
            var todayDate = DateTime.Now;
            var someDaysInthePast = todayDate.AddDays(-9000);

            return DateTimeString(someDaysInthePast, countryIso);
        }

        public static DateTime StringToDateTimeFormat(string date, string countryIso)
        {
            switch (countryIso)
            {
                case CountryIso.UnitedKingdom:
                    return DateTime.ParseExact(date, DATESTRING_BUK, null);
                case CountryIso.Switzerland:
                    return DateTime.ParseExact(date, DATESTRING_BSW, null);
                default:
                    throw new Exception("Date time format for the country with this countryISO cannot be formulated: " + countryIso);
            }
        }

        public static string CustomerReference()
        {
            var todayDate = DateTime.Now;
            var time = "CT" + todayDate.ToString("MMdHHmmss");
            HelperClasses.SpecFlow.SetContext("GeneratedCustomerReference", time);
            return time;

        }

        public static string BankInternalReference()
        {
            var todayDate = DateTime.Now;

            return "R" + todayDate.ToString("MMdHHmmss");

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
            var generatedLeadCodeRef = "Ref_"
                + DateTime.Now.ToString("MMdHHmmss");

            HelperClasses.SpecFlow.SetContext("GeneratedLeadCodeRef", generatedLeadCodeRef);

            return generatedLeadCodeRef;
        }


        public static string PrinterUnderTest()
        {
            String[] printerName ={
                                        "DCP-8110DN",
                                        "DCP-8250DN",
                                        "HL5450DN",
                                        //"HL5450DNT",
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
								    "Little Brook",
								    "Hidden Run",
								    "Lazy Mountain",
								    "Iron Elk",
								    "Lost Harbour",
								    "Silent Field",
								    "Rocky Bear",
								    "Cotton Blossom",
								    "Emerald Mews",
								    "Cozy Pike",
								    "Colonial Avenue",
								    "Rustic Parade",
								    "Fallen Pond",
								    "Heather Spring",
								    "Stony Prairie",
								    "Honey Pines",
								    "Wishing Bay"
								};

            var generatedCompanyName = companyName[new Random().Next(20)] + "_" + DateTime.Now.ToString("yyMMdHHmmss") + " Ltd";
            HelperClasses.SpecFlow.SetContext("GeneratedCompanyName", generatedCompanyName);

            Helper.MsgOutput(String.Format("The company generated is {0}", generatedCompanyName));
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

        public static string ServiceRequestType()
        {
            String[] companyName = {
                                    "Changing supplies",
                                    "Print Quality",
                                    "Machine not printing",
                                    "Software/driver issues",
                                    "General machine use",
                                    "Paper Jam",
                                    "Other faults",
								};

            var generatedServiceRequestType = companyName[new Random().Next(6)];

           HelperClasses.SpecFlow.SetContext("ServiceRequestType", generatedServiceRequestType);
            return generatedServiceRequestType;

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

        public static string VatNumberGb()
        {
            String vatNumberGb = "GB980780684";

            var generatedVatNumber = vatNumberGb;

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

        public static string GermanPostCodeNumber()
        {
            String[] companyName = {"51528",
                                    "01100",
                                    "20145",
                                    "36521",
                                    "65896",
                                    "32563",
                                    "78965",
                                    "32569",
                                    "45582",
                                    "21455",
                                    "94565",
                                    "14527",
                                    "65896",
                                    "78965",
                                    "12354",
                                    "47556",
                                    "01230",
                                    "02583",
                                    "10214",
                                    "78963"
								};

            var generatedGermanPostCodeNumber = companyName[new Random().Next(19)];

            return generatedGermanPostCodeNumber;

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

            var firstName = name[new Random().Next(25)];

            return firstName;
        }

        public static string PostCode()
        {
                String[] zip = {
                                    "03042",
						            "03116",
						            "03055",
						            "01968",
						            "01979",
						            "03130",
						            "04916",
						            "14401",
						            "14612",
						            "15926",
						            "16269",
						            "16303",
						            "16321",
						            "17268",
						            "17326",
						            "17033",
						            "17109",
						            "25926",
						            "19417",
						            "23999"
					            };
                var postCode = zip[new Random().Next(20)];

            return postCode;
        }

        public static string PostCodeFr()
        {
            String[] zip = {
                                    "25310",
                                    "54800",
                                    "60480",
                                    "80100",
                                    "80132",
                                    "91150",
                                    "95690",
                                    "51800",
                                    "81100",
                                    "81120",
                                    "81090",
                                    "81130",
                                    "81140",
                                    "81150",
                                    "81160",
                                    "81170",
                                    "81190",
                                    "81200",
                                    "81210",
                                    "81220",
                                    "81230"
					            };
            var postCode = zip[new Random().Next(20)];

            return postCode;
        }

        public static string PostCodeIt()
        {
            String[] zip = {
                                    "00120",
                                    "01100",
                                    "60480",
                                    "02100",
                                    "03100",
                                    "04100",
                                    "07100",
                                    "13900",
                                    "15100",
                                    "18100",
                                    "26900",
                                    "28100",
                                    "29100",
                                    "31100",
                                    "33170",
                                    "43100",
                                    "63100",
                                    "67100",
                                    "75100",
                                    "81100",
                                    "82100"
					            };
            var postCode = zip[new Random().Next(20)];

            return postCode;
        }

        public static string PostCodeSp()
        {
            String[] zip = {
                                    "30001",
                                    "25220",
                                    "18412",
                                    "28520",
                                    "29100",
                                    "29679",
                                    "30153",
                                    "35520",
                                    "41092",
                                    "48001",
                                    "48330",
                                    "03610",
                                    "08003",
                                    "13500",
                                    "21400",
                                    "25220",
                                    "25589",
                                    "03600",
                                    "48820",
                                    "35572",
                                    "35017"
					            };
            var postCode = zip[new Random().Next(20)];

            return postCode;
        }

        public static string PostCodeIr()
        {
            String[] zip = {
                                    "DUBLIN1",
                                    "DUBLIN2",
                                    "DUBLIN3",
                                    "DUBLIN4",
                                    "DUBLIN5",
                                    "DUBLIN6",
                                    "DUBLIN7",
                                    "DUBLIN8",
                                    "DUBLIN9",
                                    "DUBLIN10"
					            };
            var postCode = zip[new Random().Next(9)];

            return postCode;
        }

        public static string PostCodeNs()
        {
            String[] zip = {
                                    "186 00",
                                    "186 01",
                                    "186 03",
                                    "186 21",
                                    "186 22",
                                    "186 23",
                                    "186 24",
                                    "186 25",
                                    "186 26",
                                    "186 30",
                                    "186 31",
                                    "186 32",
                                    "186 33",
                                    "186 34",
                                    "186 35",
                                    "186 36",
                                    "186 37",
                                    "186 38",
                                    "186 39",
                                    "186 40"

					            };
            var postCode = zip[new Random().Next(20)];

            return postCode;
        }

        public static string PostCodePl()
        {
            String[] zip = {
                                    "50-066",
                                    "50-067",
                                    "50-068",
                                    "50-069",
                                    "50-070",
                                    "50-071",
                                    "50-072",
                                    "50-073",
                                    "50-074",
                                    "50-075",
                                    "50-076",
                                    "50-077",
                                    "50-078",
                                    "50-079",
                                    "50-080",
                                    "50-082",
                                    "50-083",
                                    "50-084",
                                    "50-085",
                                    "50-086",
                                    "50-087"
					            };
            var postCode = zip[new Random().Next(20)];

            return postCode;
        }

        public static string PostCodeNl()
        {
            String[] zip = {
                                    "3000 VB",
                                    "2520 FB",
                                    "1841 AK",
                                    "2852 GJ",
                                    "2910 AK",
                                    "2967 FB",
                                    "3015 VB",
                                    "3552 GJ",
                                    "4109 AK",
                                    "4800 VB",
                                    "4833 FB",
                                    "0361 GJ",
                                    "0800 AK",
                                    "1350 VB",
                                    "2140 FB",
                                    "2522 AK",
                                    "2558 GJ",
                                    "0360 FB",
                                    "4882 GJ",
                                    "3557 VB",
                                    "3501 AK"
					            };
            var postCode = zip[new Random().Next(20)];

            return postCode;
        }

        public static string PostCodeBe()
        {
            String[] zip = {
                                    "3000",
                                    "2522",
                                    "1841",
                                    "2852",
                                    "2910",
                                    "2967",
                                    "3015",
                                    "3552",
                                    "4109",
                                    "4800",
                                    "4833",
                                    "0361",
                                    "0800",
                                    "1350",
                                    "2140",
                                    "2522",
                                    "2558",
                                    "0360",
                                    "4882",
                                    "3557",
                                    "3501"
					            };
            var postCode = zip[new Random().Next(20)];

            return postCode;
        }

        public static string PostCodeSw()
        {
            String[] zip = {
                                    "4820",
                                    "3001",
                                    "3002",
                                    "8520",
                                    "2100",
                                    "2679",
                                    "3153",
                                    "3520",
                                    "4092",
                                    "4001",
                                    "4010",
                                    "0610",
                                    "3003",
                                    "1500",
                                    "2400",
                                    "2220",
                                    "2589",
                                    "3000",
                                    "4003",
                                    "3572",
                                    "3517"
					            };
            var postCode = zip[new Random().Next(20)];

            return postCode;
        }

        public static string PostCodeDk()
        {
            String[] zip = {
                                    "3000",
                                    "3050",
                                    "3060",
                                    "3070",
                                    "3100",
                                    "3120",
                                    "3160",
                                    "3520",
                                    "4000",
                                    "4010",
                                    "4020",
                                    "4030",
                                    "4050",
                                    "4060",
                                    "4070",
                                    "4100",
                                    "4130",
                                    "4160",
                                    "4170",
                                    "4180",
                                    "4210"
					            };
            var postCode = zip[new Random().Next(20)];

            return postCode;
        }

        public static string PostCodeFi()
        {
            String[] zip = {
                                    "00100",
                                    "80100",
                                    "04250",
                                    "04430",
                                    "33210",
                                    "55100",
                                    "68600",
                                    "14240",
                                    "84100"
					            };
            var postCode = zip[new Random().Next(8)];

            return postCode;
        }

        public static string PostCodeNo()
        {
            String[] zip = {    
                                    "3000",
                                    "2522",
                                    "1841",
                                    "2852",
                                    "2910",
                                    "2967",
                                    "3015",
                                    "3552",
                                    "4109",
                                    "4800",
                                    "4833",
                                    "0361",
                                    "0800",
                                    "1350",
                                    "2140",
                                    "2522",
                                    "2558",
                                    "0360",
                                    "4882",
                                    "3557",
                                    "3501"
					            };
            var postCode = zip[new Random().Next(20)];

            return postCode;
        }

        public static string PostCodeGb()
        {
            String[] zip = {
                                    "M1 6FT",
						            "SW11 6TY",
						            "B45 8DE",
						            "CH2 3PD",
						            "L2 7PQ",
						            "LS2 7LY",
						            "FY3 9GZ",
						            "BD23 1UD",
						            "S1 2FB",
						            "DH1 1AL",
						            "E1 6TE",
						            "KA6 7TZ",
						            "DD10 8TB",
						            "DE3 9FB",
						            "NN1 2PN",
						            "PR9 9GL",
						            "M23 4QR",
						            "WA5 7TB",
						            "SK23 7AH",
						            "HA2 9EF"
					            };
            var postCode = zip[new Random().Next(20)];

            return postCode;
        }

        public static decimal GetValue(string money)
        {
            if (money.Contains(" "))
            {
                money = money.Replace(" ", "");
            }
            var currencyNumberFormatInfo = GetNumberFormatInfo(money);

            return decimal.Parse(money, NumberStyles.Currency, currencyNumberFormatInfo);
        }



        private static NumberFormatInfo GetNumberFormatInfo(string money)
        {
            NumberFormatInfo numberFormatInfo = null;

            if (money.Contains("zł"))
            {
                numberFormatInfo = new NumberFormatInfo { CurrencySymbol = "zł" }; 
  
            } else if (money.Contains("£"))
            {
                numberFormatInfo = new NumberFormatInfo { CurrencySymbol = "£" };
            }
            else if (money.Contains("€"))
            {
                numberFormatInfo = new NumberFormatInfo { CurrencySymbol = "€" };
            }
            else if (money.Contains("CHF"))
            {
                numberFormatInfo = new NumberFormatInfo { CurrencySymbol = "CHF" };
            }
            else if (money.Contains("kr."))
            {
                numberFormatInfo = new NumberFormatInfo { CurrencySymbol = "kr." };
            }
            else if ((money.Contains("kr") && TestController.CurrentDriver.Url.Contains(".se.brother"))
                || (money.Contains("kr") && TestController.CurrentDriver.Url.Contains(".no.brother")))
            {
                numberFormatInfo = new NumberFormatInfo { CurrencySymbol = "kr", CurrencyGroupSeparator = " "};
            }
            else if (money.Contains("kr"))
            {
                numberFormatInfo = new NumberFormatInfo { CurrencySymbol = "kr" };
            }
            
            return numberFormatInfo;

        }

        /// <summary>
        /// Use this function only when CultureInfo.NumberFormat.CurrencySymbol are different depending on Windows OS
        /// </summary>
        /// <param name="countryIso"></param>
        /// <returns></returns>
        public static string GetCurrencySymbol(string countryIso)
        {
            string currencySymbol;
            switch (countryIso)
            {
                case CountryIso.UnitedKingdom:
                    currencySymbol = "£";
                    break;

                case CountryIso.Switzerland:
                    currencySymbol = "CHF";
                    break;
                
                // TODO Add currency symbols for more countries

                default:
                    currencySymbol = "€";
                    break;
            }
            return currencySymbol;
        }
        

        public static decimal GetEuroValue(string money)
        {
            return GetValue(money);
        }

        public static void ClickButtonThenNavigateToOtherUrl(IWebDriver driver, IWebElement element)
        {
            var previousUrl = driver.Url;
            element.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditionsEx.UrlChangeFrom(previousUrl));
        }

        
        public static void ClickButtonThenNavigateToSameUrl(IWebDriver driver, IWebElement element)
        {
            var previousUrl = driver.Url;
            element.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditionsEx.UrlNotChangeFrom(previousUrl));
        }

        public static void JsClickButtonThenNavigateToDifferentUrl(IWebDriver driver, IWebElement element)
        {
            var previousUrl = driver.Url;
            SeleniumHelper.ClickOnElementByJavaScript(driver, element);
            //var tryCount = 0;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditionsEx.UrlChangeFrom(previousUrl));

            //WebDriver.Wait(Helper.DurationType.Second, 5);
            //var newurl = driver.Url;
            
            //while (previousUrl.Equals(newurl) && tryCount < 3)
            //{
            //    if (tryCount == 3)
            //    {
            //        element.Click();
            //    }

            //    WebDriver.Wait(Helper.DurationType.Second, 1);
            //    newurl = driver.Url;
            //    tryCount++;
            //}
        }

        public static string DefaultMargins()
        {
            String[] margins =
            {
                "0",
                "5",
                "10",
                "15",
                "20",
                "25"
            };
            var margin = margins[new Random().Next(6)];
            return margin;
        }

        public static string Area()
        {
            String[] areas =
            {
                "Guide Bridge",
                "Rose maple hill",
                "Piccadily",
                "Euston",
                "Victoria",
                "Oxford",
                "Hogwarts"
            };
            var area = areas[new Random().Next(7)];
            return area;
        }

        public static string DeviceLocation()
        {
            String[] locations =
            {
                "Floor 1",
                "Floor 2",
                "Floor 3",
                "Floor 4",
                "Floor 5",
                "Floor 6",
                "Floor 7"
            };
            var location = locations[new Random().Next(7)];
            return location;
        }

        public static string CostCentre()
        {
            String[] costCentres =
            {
                "Dept. A",
                "Dept. B",
                "Dept. C",
                "Dept. D",
                "Dept. E",
                "Dept. F",
                "Dept. G"
            };
            var costCentre = costCentres[new Random().Next(7)];
            return costCentre;
        }

        public static string InstallationNotes()
        {
            String[] notes =
            {
                "Nothing Special",
                "Please install all devices in 1 day",
                "Handle devices delicately",
            };
            var note = notes[new Random().Next(3)];
            return note;
        }

        public static string ServiceRequestSubject()
        {
            String[] notes =
            {
                "Major issue",
                "Critical issue",
                "Minor issue",
            };
            var note = notes[new Random().Next(3)];
            return note;
        }

        public static string ServiceRequestDescription()
        {
            String[] notes =
            {
                "Not printing",
                "Machine making noise",
                "Ink is leaking",
            };
            var note = notes[new Random().Next(3)];
            return note;
        }

        public static string ServiceRequestReplyMessage()
        {
            String[] notes =
            {
                "Service Request Canceled...Closing....",
                "Invalid Service Request..Closing...",
                "Problem Solved...Closing",
            };
            var note = notes[new Random().Next(3)];
            return note;
        }

        public static string ContractEndDate(string contractStartDate, int contractTermInYears)
        {
            DateTime startDate = DateTime.ParseExact(contractStartDate, DATESTRING_BUK, CultureInfo.InvariantCulture);
            DateTime endDate = startDate.AddYears(contractTermInYears).AddDays(-1); // End Date = Start Date + Contract Term (in years) - 1 day
            return endDate.ToString(DATESTRING_BUK);
        }

        public static string SubtractDaysFromDate(string date, int daysToSubtract)
        {
            DateTime dt = DateTime.ParseExact(date, DATESTRING_BUK, CultureInfo.InvariantCulture);
            DateTime result = dt.AddDays(-daysToSubtract);
            return result.ToString(DATESTRING_BUK);
        }

        public static string DealershipName(string env, string countryIso)
        {
            string name = "";
            switch(countryIso)
            {
                case CountryIso.Switzerland:
                    name = env + " BSW FR Dealer 3";
                    break;
                default:
                    name = env + " BUK GB Dealer 3";
                    break;
            }
            return name;
        }

        public static string CompaniesHouseNumber()
        {
            string houseNumber = "22222";
            return houseNumber;
        }

        public static string CompanyTaxNumber()
        {
            string taxNumber = "33333";
            return taxNumber;
        }

        public static string CreditLicenceNumber()
        {
            string creditLicenceNumber = "44444";
            return creditLicenceNumber;
        }

        public static string RegisteredCity()
        {
            string registeredCity = "D Registered City";
            return registeredCity;
        }

        public static string BankName()
        {
            string bankName = "D Bank Name";
            return bankName;
        }

        public static string BankAccountNumber()
        {
            string bankAccountNumber = "55555";
            return bankAccountNumber;
        }

        public static string BrotherSalesPerson()
        {
            string brotherSalesPerson = "D Brother Sales Person";
            return brotherSalesPerson;
        }

        public static string OwnerFirstName(string env, string countryIso)
        {
            string name = "";
            switch (countryIso)
            {
                case CountryIso.Switzerland:
                    name = env + " BSW FR Owner first name test";
                    break;
                default:
                    name = env + " BUK GB Owner first name test";
                    break;
            }
            return name;
        }

        public static string CeoFirstName(string env, string countryIso)
        {
            string name = "";
            switch (countryIso)
            {
                case CountryIso.Switzerland:
                    name = env + " BSW FR Ceo first name test";
                    break;
                default:
                    name = env + " BUK GB Ceo first name test";
                    break;
            }
            return name;
        }
    }
}
