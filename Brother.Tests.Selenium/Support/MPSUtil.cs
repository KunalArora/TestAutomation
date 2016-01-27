using System;
using System.Configuration;
using System.Globalization;
using System.Xml.Schema;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
            var generatedProposalName = "MPS_Smoke_" + SurName() + 
                "-" + DateTime.Now.ToString("MMdHHmmss");
            HelperClasses.SpecFlow.SetContext("GeneratedProposalName", generatedProposalName);
            return generatedProposalName;
        }

       
        public static string GenerateUniqueEmail()
        {
            var generatedEmailAddress = FirstName() +
                DateTime.Now.ToString("yyyyMMdHHmmss")
                +"@mailinator.com";
            HelperClasses.SpecFlow.SetContext("GeneratedEmailAddress", generatedEmailAddress);
            return generatedEmailAddress;
        }

        public static string CreatedProposal()
        {
            var createdProposal = HelperClasses.SpecFlow.GetContext("GeneratedProposalName");
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

        public static string SomeDaysFromToday()
        {
            var todayDate = DateTime.Now;
            var someDaysIntheFuture = todayDate.AddDays(30);

            return someDaysIntheFuture.ToString("dd/MM/yyyy");

        }

        public static string DateOfBirth()
        {
            var todayDate = DateTime.Now;
            var someDaysInthePast = todayDate.AddDays(-9000);

            return someDaysInthePast.ToString("dd/MM/yyyy");

        }

       

        public static string CustomerReference()
        {
            var todayDate = DateTime.Now;

            return "CT" + todayDate.ToString("MMdHHmmss");

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


        public static string PostCodeGB()
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
            var poundNumberFormatInfo = new NumberFormatInfo();
            poundNumberFormatInfo.CurrencySymbol = "£";

            return decimal.Parse(money, NumberStyles.Currency, poundNumberFormatInfo);
        }

        public static decimal GetEuroValue(string money)
        {
            var euroNumberFormatInfo = new NumberFormatInfo();
            euroNumberFormatInfo.CurrencySymbol = "€";

            return decimal.Parse(money, NumberStyles.Currency, euroNumberFormatInfo);
        }

        public static void ClickButtonThenNavigateToOtherUrl(IWebDriver driver, IWebElement element)
        {
            var previousUrl = driver.Url;
            element.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditionsEx.UrlChangeFrom(previousUrl));
        }

        public static void ClickButtonThenNavigateToSameUrl(IWebDriver driver, IWebElement element)
        {
            var previousUrl = driver.Url;
            element.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditionsEx.UrlNotChangeFrom(previousUrl));
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
    }
}
