using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Xml;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Selenium.Lib.Support.HelperClasses
{
    public abstract class Helper
    {
        public static string OrpActivationCode { get; set; }
        public static int OrpNumLicenses { get; set; }
        public static int OrpLicenseTerm { get; set; }
        public static Guid OrpDealerId { get; set; }
        public static string OrpDealerEmail { get; set; }
        public static string OrpComment { get; set; }
        public static string OrpCustomerEmailAddress { get; set; }
        // Runtime environment constants
        public const string RunTimeLive = @"PROD";
        public const string RunTimeTest = @"TEST";
        public const string RunTimeUat = @"UAT";
        public const string RunTimeDev = @"DEV";
        public const string RunTimeDefault = @"TEST";

        public const string BrotherEmail = @"BrotherEmail";
        public const string MailinatorEmail = @"MailinatorEmail";

        private static string _pwd = @"Abcd1234";
        private const string _defaultFirstName = @"Otto";
        private const string _defaultLastName = @"Tiest";
        private const string ProductInfoFile = @"ProductInfo.xml";
        private const string _supportingFilesLocation = @"\Brother.Tests.Selenium\Supporting Files\";
        private static string _currentDomain;

        public static string CurrentDomain
        {
            get { return _currentDomain; } 
            set { _currentDomain = value; }
        }

        public static string CurrentDeviceSerialNumber { get; set; }
        public static string CurrentDeviceModelNumber { get; set; }

        /// <summary>
        /// Enum DurationType
        /// </summary>
        public enum DurationType { Millisecond, Second, Minute }

        public static string SupportingFilesLocation
        {
            get { return _supportingFilesLocation; }
        }

        private static string _locale = "uk"; // default locale

        private const string DefaultSeleniumFolder = "C:\\TestAutomation\\SnapShots";
        private const int MaxFileNameSize = 245;
        public static string CreditCardType  { get; set; }

        public static string Password
        {
            get { return _pwd; } 
            set { _pwd = value; }
        }

        public static string CurrentSnapShot { get; set; }
        private static string ProductInfoFilePath { get; set; }

        public static string DefaultFirstName
        {
            get { return _defaultFirstName; }
        }

        public static string DefaultLastName
        {
            get { return _defaultLastName; }
        }

        public static string Locale
        {
            get { return _locale.ToLower(); }
            set { _locale = value; }
        }

        // Countries lookup
        private static readonly Dictionary<string, string> _countries = new Dictionary<string, string>
        {
            {"Belgium", "be"},
            {"Czech", "cz"},
            {"Denmark", "dk"},
            {"Finland", "fi"},
            {"France", "fr"},
            {"Germany", "de"},
            {"Hungary", "hr"},
   	        {"Ireland", "ie"},
            {"Netherlands", "nl"},
            {"Norway", "no"},
	        {"Poland", "pl"},  
            {"Portugal", "pt"},  
	        {"United Kingdom", "uk"},
            {"Russia", "ru"},
            {"Romania", "ro"},
            {"Slovakia", "sk"},
            {"Slovenia", "si"},
            {"Spain", "es"},
            {"Switzerland", "ch"},
            {"Italy", "it"},
            {"Bulgaria", "bg"},
            {"Austria", "at"},

        };

        public static string CountryLookup(string locale)
        {
            foreach (KeyValuePair<string, string> country in _countries)
            {
                if (country.Value.Equals(locale))
                {
                    return country.Key;
                }
            }
            return String.Empty;
        }

        public static void SetCountry(string country)
        {
            string locale;
            Locale = _countries.TryGetValue(country, out locale) ? locale : String.Empty;
            if (Locale.Equals(string.Empty))
            {
                TestCheck.AssertFailTest(string.Format("Invalid Locale {0} - unable to proceed", Locale));
            }
            MsgOutput("Setting Country to ", Locale);
        }

        public static string GetRunTimeEnv()
        {
            return Environment.GetEnvironmentVariable("AutoTestRunTimeEnv", EnvironmentVariableTarget.Machine) ?? RunTimeDefault;
        }

       public static bool SetRunTimeEnv(string runTimeEnv)
        {
            Environment.SetEnvironmentVariable("AutoTestRunTimeEnv", runTimeEnv, EnvironmentVariableTarget.Machine);
            var environmentVariable = Environment.GetEnvironmentVariable("AutoTestRunTimeEnv", EnvironmentVariableTarget.Machine);
            return environmentVariable != null && environmentVariable.Equals(runTimeEnv);
        }

        public static bool CheckScenarioEnv(string env)
        {
            return ScenarioContext.Current.ScenarioInfo.Tags.Contains(env);
        }

        public static bool CheckForStagingTestFlag()
        {
            var isSmokeTest = Environment.GetEnvironmentVariable("IsStagingTest", EnvironmentVariableTarget.Machine);
            return isSmokeTest != null && isSmokeTest.Equals("TRUE");
        }

        public static bool IsSmokeTest()
        {
            var isSmokeTest = Environment.GetEnvironmentVariable("SmokeTestSet", EnvironmentVariableTarget.Machine);
            return isSmokeTest != null && isSmokeTest.Equals("TRUE");
        }

        public static String MpsRunCondition()
        {
            return Environment.GetEnvironmentVariable("MpsTagRunner", EnvironmentVariableTarget.Machine);
        }
        
        public static bool CheckFeatureEnv(string env)
        {
            return FeatureContext.Current.FeatureInfo.Tags.Contains(env);
        }

        //public static string CurrentBaseUrlAsHttps()
        //{
        //    var baseUrl = BasePage.BaseUrl;
        //    return baseUrl.ToLower().Replace("http", "https");
        //}

        public static string UrlAsHttps(string url)
        {
            return url.ToLower().Replace("http", "https");
        }

       public static void MsgOutput(string message)
        {
            #if DEBUG
                Trace.WriteLine(String.Format("@@TESTMSG - {0}", message));
            #else
                Console.WriteLine("@@TESTMSG - {0}", message);
                Console.WriteLine("##teamcity[{0}]", message);
            #endif
        }

        public static void MsgOutput(string msgPrefix, string message)
        {
            #if DEBUG
                Trace.WriteLine(String.Format("{0} --> {1} -", msgPrefix, message));
            #else
                Console.WriteLine("{0} --> {1} -", msgPrefix, message);
            #endif
        }

        public static string GetVisaCcInfo(string infoItem, bool valid)
        {
            return GetProductInfoItem(valid ? "ValidVisaCCDetails" : "InvalidVisaCCDetails", infoItem);
        }
        
        public static string GetMasterCardCcInfo(string infoItem, bool valid)
        {
            return GetProductInfoItem(valid ? "ValidMasterCardCCDetails" : "InvalidMasterCardCCDetails", infoItem);
        }

        public static string GetProductInfoItem(string tagName, string attribute)
        {
            // check for a specific 
            var itemValue = String.Empty;
            ProductInfoFilePath = GetProductInfoFile();
            if (ProductInfoFilePath != String.Empty)
            {
                itemValue = ReadItemFromFile(tagName, attribute);
            }
            // Write back used value and increment
            if (attribute != null && (attribute.Equals("SerialNumber") && itemValue != String.Empty))
            {
                UpdateSerialNumber(IncrementValue(itemValue));
            }
            return itemValue;
        }

        public static string CheckForCdServer(string baseUrl)
        {
            if (Helper.GetRunTimeEnv().Contains("PROD") && UseCdServerDomain().Contains("web"))
            {
                if (baseUrl.Contains("online"))
                {
                    return baseUrl.Replace("online", string.Format("{0}.online", UseCdServerDomain()));
                }

                if (baseUrl.Contains("www."))
                {
                    return baseUrl.Replace("www.", string.Format("www.{0}.", UseCdServerDomain()));
                }

                if (baseUrl.Contains("webconferencing"))
                {
                    return baseUrl.Replace("webconferencing", string.Format("{0}.webconferencing", UseCdServerDomain()));
                }
            }
            return baseUrl;
        }

        public static string UseCdServerDomain()
        {
            return Environment.GetEnvironmentVariable("AutoTest_UseCDServer", EnvironmentVariableTarget.Machine) ?? string.Empty;
        }

        public static bool SetCdServerDmain(string domain)
        {
            Environment.SetEnvironmentVariable("AutoTest_UseCDServer", domain, EnvironmentVariableTarget.Machine);
            if (Environment.GetEnvironmentVariable("AutoTest_UseCDServer", EnvironmentVariableTarget.Machine) == domain)
            {
                return true;
            }
            return false;
        }

        public static string GetDeviceCodeSeed()
        {
            var deviceSeed = Environment.GetEnvironmentVariable(GetRunTimeEnv().Equals(RunTimeUat) ? "AutoTest_DeviceSeed_QAS" : "AutoTest_DeviceSeed_DV2", EnvironmentVariableTarget.Machine);
            TestCheck.AssertIsNotNull(deviceSeed, "Device Code Seed");
            UpdateSerialNumber(IncrementValue(deviceSeed));
            return deviceSeed;
        }

        private static string ReadItemFromFile(string tagName, string attribute)
        {
            var settings = new XmlReaderSettings();
            var txtReader = new XmlTextReader(ProductInfoFilePath);
            var reader = XmlReader.Create(txtReader, settings);
            var itemValue = String.Empty;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == tagName)
                {
                    itemValue = reader.GetAttribute(attribute);
                }
            }
            reader.Close();
            return itemValue;
        }

        public static void UpdateSerialNumber(string serialNumber)
        {
            try
            {
                Environment.SetEnvironmentVariable(GetRunTimeEnv().Equals(RunTimeUat) ? "AutoTest_DeviceSeed_QAS" : "AutoTest_DeviceSeed_DV2", serialNumber, EnvironmentVariableTarget.Machine);
            }
            catch (SecurityException securityException)
            {
                TestCheck.AssertFailTest(string.Format("Permission denied setting Device Seed [{0}]", securityException.Message));
            }
            catch (ArgumentNullException argumentNullException)
            {
               TestCheck.AssertFailTest(string.Format("Error setting Environment Variable for Device Seed [{0}]", argumentNullException.Message));
            }
            TestCheck.AssertIsEqual(serialNumber, Environment.GetEnvironmentVariable(GetRunTimeEnv().Equals(RunTimeUat) ? "AutoTest_DeviceSeed_QAS" : "AutoTest_DeviceSeed_DV2", EnvironmentVariableTarget.Machine), "Update Device Serial Number seed");
        }

        private static string GetProductInfoFile()
        {
            var info1 = Directory.GetCurrentDirectory();
            var info2 = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());

            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
            if (directoryInfo == null) return String.Empty;

            var productInfoFile = directoryInfo.FullName + SupportingFilesLocation + ProductInfoFile;

            return productInfoFile;
        }

        // Code to increment Alphanumberic number
        private static string IncrementValue(string itemValue)
        {
            byte[] asciiValues = Encoding.ASCII.GetBytes(itemValue);
            var stringLength = asciiValues.Length;
            var isAllZed = true;
            var isAllNine = true;
            //Check if all has ZZZ.... then do nothing just return empty string.
            for (var i = 0; i < stringLength - 1; i++)
            {
                if (asciiValues[i] == 90) continue;
                isAllZed = false;
                break;
            }
            if (isAllZed && asciiValues[stringLength - 1] == 57)
            {
                asciiValues[stringLength - 1] = 64;
            }

            // Check if all has 999... then make it A0
            for (var i = 0; i < stringLength; i++)
            {
                if (asciiValues[i] == 57) continue;
                isAllNine = false;
                break;
            }
            if (isAllNine)
            {
                asciiValues[stringLength - 1] = 47;
                asciiValues[0] = 65;
                for (var i = 1; i < stringLength - 1; i++)
                {
                    asciiValues[i] = 48;
                }
            }

            for (var i = stringLength; i > 0; i--)
            {
                if (i - stringLength == 0)
                {
                    asciiValues[i - 1] += 1;
                }
                if (asciiValues[i - 1] == 58)
                {
                    asciiValues[i - 1] = 48;
                    if (i - 2 == -1)
                    {
                        break;
                    }
                    asciiValues[i - 2] += 1;
                }
                else if (asciiValues[i - 1] == 91)
                {
                    asciiValues[i - 1] = 65;
                    if (i - 2 == -1)
                    {
                        break;
                    }
                    asciiValues[i - 2] += 1;

                }
                else
                {
                    break;
                }

            }
            itemValue = Encoding.ASCII.GetString(asciiValues);
            return itemValue;
        }

        // Standard address for Address based forms
        private static readonly Dictionary<string, string> _address = new Dictionary<string, string>
        {
            {"FirstName", "AutoTest"},
	        {"LastName", "AutoTest"},    
	        {"PostCode", "M34 5JE"},
	        {"HouseNumber", "22"},
	        {"HouseName", "Phantom House"},
	        {"Address1", "Phantom Street"},
	        {"Address2", "Phantom Road"},
	        {"CityTown", "Manchester"},
	        {"UKCounty", "Cheshire"},
            {"IECounty", "KILKENNY"},
	        {"PhoneNumber", "01234 678910"}
        };

        public static string GetAddressInfo(string key)
        {
            string addressInfo;
            return _address.TryGetValue(key, out addressInfo) ? addressInfo : String.Empty;
        }

        private static string SnapShotDirectory()
        {
            // Check if we are running on the build machine
            var snapshotLocation = DefaultSeleniumFolder;

            var isOnBuildMachine = Environment.MachineName;
            if (isOnBuildMachine.ToUpper().Equals("PRDAT169V") || isOnBuildMachine.ToUpper().Equals("PRDAT204V"))
            {
                // switch to E: drive on CI box
                snapshotLocation = DefaultSeleniumFolder.Replace('C', 'E');
            }
            return snapshotLocation;
        }

        public static void PurgeSnapshots()
        {
            var snapshotLocation = SnapShotDirectory();
            var dirInfo = new DirectoryInfo(snapshotLocation);

            var snapShotCount = 0;
            var snapShots = dirInfo.GetFiles("*.jpg", SearchOption.TopDirectoryOnly);
            foreach (var snapShot in snapShots)
            {
                if (snapShot.LastWriteTime < DateTime.Now.AddDays(-10))
                {
                    try
                    {
                        snapShot.Delete();
                        snapShotCount++;
                    }
                    catch (IOException fileDeleteException)
                    {
                        MsgOutput(string.Format("Unable to delete snap shot {0} due to {1}", snapShot.Name, fileDeleteException.Message));
                    }
                }
            }
            MsgOutput(string.Format("Successfully Deleted {0} old SnapShots", snapShotCount));
        }

        public static void TakeSnapshot(string additionalInformation)
        {
            if (!Directory.Exists(SnapShotDirectory()))
            {
                Directory.CreateDirectory(SnapShotDirectory());
            }

            var testName = TestContext.CurrentContext.Test.Name;
            if (testName.Contains("null"))
            {
                // Scenario outline used as the test name which will prove invalid as a file name
                testName =
                    testName.Replace("(", "__")
                        .Replace(")", "__")
                        .Replace("\"", "")
                        .Replace(",null", "")
                        .Replace("/", "_")
                        .Replace(",", "_")
                        .Replace("\\", "_")
                        .Replace(".", "$")
                        .Replace("?", "")
                        .Replace(":", "$");
            }
           
            var snapShot = String.Format("{0}{1}.jpg", testName, DateTime.Now.TimeOfDay.ToString().Replace(@"/", "_").Replace(" ", "").Replace(":", "_").Replace(".", "_"));
            //var snapShot = String.Format("{0}{1}.jpg", ScenarioContext.Current.ScenarioInfo.Title.Replace(" ", ""), DateTime.Now.TimeOfDay.ToString().Replace(@"/", "_").Replace(" ", "").Replace(":", "_"));
            var snapshotLocation = SnapShotDirectory();
            snapshotLocation += "\\" + snapShot;

            if (snapshotLocation.Length > MaxFileNameSize)
            {
                // snapshot length too long so we'll have to shorten it
                snapshotLocation = snapshotLocation.Substring(0, MaxFileNameSize - 4);
                snapshotLocation = string.Format(snapshotLocation + "{0}", ".jpg");
                MsgOutput("Trimming Snapshot as length is too long (large scenario description)......");
            }

            try
            {
                CurrentSnapShot = snapshotLocation;
                MsgOutput(string.Format("Taking Snapshot ->[{0}]<-", additionalInformation));
                ((ITakesScreenshot)TestController.CurrentDriver).GetScreenshot().SaveAsFile(snapshotLocation, ImageFormat.Jpeg);
                MsgOutput("Snapshot Location", snapshotLocation);
            }
            catch (PathTooLongException pathTooLong)
            {
                TestCheck.AssertFailTest(string.Format("Snapshot length was too long - [{0}]", pathTooLong));
            }
        }
    }
}
