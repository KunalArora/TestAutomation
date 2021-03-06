﻿using Brother.Tests.Common.Logging;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Xml;
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
        private static string _abbreviate = "uk";

        private const string DefaultSeleniumFolder = "C:\\TestAutomation\\SnapShots";
        private const int MaxFileNameSize = 245;
        public static string CreditCardType { get; set; }

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

        public static string Abbrev
        {
            get { return _abbreviate.ToLower(); }
            set { _abbreviate = value; }
        }

       #region Properties set by MPS assembly

       public static string OutputPath = string.Empty;
       public static string EnvironmentUnderTest = string.Empty;
       public static ILoggingService LoggingService;

       #endregion

       // Countries lookup
        private static readonly Dictionary<string, string> _countries = new Dictionary<string, string>
        {
            {"Belgium", "be"},
            {"Czech Republic", "cz"},
            {"Denmark", "dk"},
            {"Finland", "fi"},
            {"France", "fr"},
            {"Germany", "de"},
            {"Hungary", "hu"},
   	        {"Ireland", "ie"},
            {"Netherlands", "nl"},
            {"Poland", "pl"},  
            {"Portugal", "pt"},  
            {"Norway", "no"},
	        {"United Kingdom", "uk"},
            {"Russia", "ru"},
            {"Romania", "ro"},
            {"Slovakia", "sk"},
            {"Slovenia", "si"},
            {"Spain", "es"},
            {"Sweden", "se"},
            {"Switzerland", "ch"},
            {"Italy", "it"},
            {"Bulgaria", "bg"},
            {"Austria", "at"},
            {"Estonia", "ee"},
            {"Iceland", "is"},
            {"Latvia", "lv"},
        };



        private static readonly Dictionary<string, string> _BrotherAbbrev = new Dictionary<string, string>
        {
            {"Belgium", "BBE"},
            {"Czech", "BCZ"},
            {"Denmark", "BND"},
            {"Finland", "BNF"},
            {"France", "BFR"},
            {"Germany", "BIG"},
            {"Hungary", "BHR"},
   	        {"Ireland", "BIR"},
            {"Netherlands", "BNL"},
            {"Poland", "BPL"},  
            {"Portugal", "BPT"},  
            {"Norway", "BNN"},
	        {"United Kingdom", "BUK"},
            {"Russia", "BRU"},
            {"Romania", "BRO"},
            {"Slovakia", "BSK"},
            {"Slovenia", "BSI"},
            {"Spain", "BES"},
            {"Sweden", "BNS"},
            {"Switzerland", "BSW"},
            {"Italy", "BIT"},
            {"Bulgaria", "BBG"},
            {"Austria", "BAT"},

        };

        private static readonly List<string> _CountriesUsingAtYourSideLogin = new List<string> { "United Kingdom" };

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

        public static bool CountryIsUsingAtYourSideLogin(string country)
        {
            //return _CountriesUsingAtYourSideLogin.Contains(country);
            if (GetRunTimeEnv() == "PROD")
            {
                return _CountriesUsingAtYourSideLogin.Contains(country);
            }
            else
            {
                return false;
            }
        }

        public static bool CurrentCountryIsUsingAtYourSideLogin()
        {
            return CountryIsUsingAtYourSideLogin(GetCountry());
        }

        public static void SetCountry(string country)
        {
            string locale;
            SpecFlow.SetContext("CountryOfTest", country);
            Locale = _countries.TryGetValue(country, out locale) ? locale : String.Empty;
            if (Locale.Equals(string.Empty))
            {
                MsgOutput(String.Format("Inputted country inputted is {0}", country));
                TestCheck.AssertFailTest(string.Format("Invalid Locale {0} - unable to proceed", Locale));

            }
            MsgOutput("Setting Country to ", Locale);
        }

        public static string GetCountry()
        {
            return SpecFlow.GetContext("CountryOfTest");
        }

        public static void SetMpsCountryAbbreviation(string country)
        {
            string abbr;
            Abbrev = _BrotherAbbrev.TryGetValue(country, out abbr) ? abbr : String.Empty;
            if (Abbrev.Equals(string.Empty))
            {
                MsgOutput(String.Format("Inputted country inputted is {0}", country));
                TestCheck.AssertFailTest(string.Format("Invalid Locale {0} - unable to proceed", Abbrev));

            }
            MsgOutput("Setting Country Abbreviation to ", Abbrev);
        }

        public static string GetRunTimeEnv()
        {
            //MPS command line override
            if (EnvironmentUnderTest != string.Empty)
            {
                return EnvironmentUnderTest;
            }
            return GetSpecialEnvironmentVariable("AutoTestRunTimeEnv") ?? RunTimeDefault;
        }

        // So that tests can be executed via Team City using Team City parameters, some calls to GetEnvironmentVariable
        // need to have the Target omitted so the Environment settings are used via the calling process
        // It is necessary to revert to the old method when running tests from a local machine
        public static string GetSpecialEnvironmentVariable(string envVar)
        {
            var isOnBuildMachine = Environment.MachineName;
            return isOnBuildMachine.ToUpper().Equals("PRDAT169V") || isOnBuildMachine.ToUpper().Equals("PRDAT204V") || isOnBuildMachine.ToUpper().Equals("BRO43DBS01DOP")
                ? Environment.GetEnvironmentVariable(envVar)
                : Environment.GetEnvironmentVariable(envVar, EnvironmentVariableTarget.Machine);
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
            var isStagingTest = GetSpecialEnvironmentVariable("IsStagingTest");
            return isStagingTest != null && isStagingTest.Equals("TRUE");
        }

        public static bool IsSmokeTest()
        {
            var isSmokeTest = GetSpecialEnvironmentVariable("SmokeTestSet");
            return isSmokeTest != null && isSmokeTest.Equals("TRUE");
        }

        public static String MpsRunCondition()
        {
            return GetSpecialEnvironmentVariable("MpsTagRunner");
        }

        public static bool IsMpsSwitchOn()
        {
            var isMpsOn = GetSpecialEnvironmentVariable("MpsTagRunner");
            return isMpsOn != null && isMpsOn.Equals("ONLY");
        }

        public static bool CheckFeatureEnv(string env)
        {
            return FeatureContext.Current.FeatureInfo.Tags.Contains(env);
            /*if (FeatureContext.Current.FeatureInfo.Tags.Contains("PROD"))
            {
                SetRunTimeEnv("PROD");
                return true;
            }
            else
            {
                SetRunTimeEnv("TEST");
                return FeatureContext.Current.FeatureInfo.Tags.Contains(env);
            }*/
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
            Trace.WriteLine(String.Format("@@TESTMSG @ {0} - {1}", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss.FFF"), message));
#else
            Console.WriteLine("@@TESTMSG @ {0} - {1}", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss.FFF"), message);
#endif
        }

        public static void MsgOutput(string msgPrefix, string message)
        {
#if DEBUG
            Trace.WriteLine(String.Format("{0} @ {1} --> {2} -", msgPrefix, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss.FFF"), message));
#else
            Console.WriteLine("{0} @ {1} --> {2} -", msgPrefix, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss.FFF"), message);
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
            if (GetRunTimeEnv().Contains("PROD") && UseCdServerDomain().Contains("web"))
            {
                if (baseUrl.Contains("online"))
                {
                    //return baseUrl.Replace("online", string.Format("{0}.online", UseCdServerDomain()));
                    return baseUrl.Replace("online", string.Format("www.{0}", UseCdServerDomain()));
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
            //return deviceSeed;
            return Environment.GetEnvironmentVariable(GetRunTimeEnv().Equals(RunTimeUat) ? "AutoTest_DeviceSeed_QAS" : "AutoTest_DeviceSeed_DV2", EnvironmentVariableTarget.Machine);
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


        public static void CopyFileToNewLocation(string sourcePath, string targetPath, string srcFileName, string targetFileName)
        {
            var sourceFile = Path.Combine(sourcePath, srcFileName);
            var destFile = Path.Combine(targetPath, targetFileName);

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            File.Copy(sourceFile, destFile, true);
        }

        public static void DeleteFileFromDirectory(string fileFullPath)
        {
            if (!File.Exists(fileFullPath)) return;
            try
            {
                File.Delete(fileFullPath);
            }
            catch (IOException e)
            {
                MsgOutput(String.Format("File was not deleted because {0}", e.Message));
            }
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
            // command line specified path trumps all
            if (!string.IsNullOrWhiteSpace(OutputPath))
            {
                return OutputPath;
            }

            // Check if we are running on the build machine
            var snapshotLocation = DefaultSeleniumFolder;

            var isOnBuildMachine = Environment.MachineName;

            var driveLetter = "C";
            if (isOnBuildMachine.ToUpper().Equals("PRDAT169V") || isOnBuildMachine.ToUpper().Equals("PRDAT204V"))
            {
                driveLetter = "E";
            }
            else if (isOnBuildMachine.ToLower().Equals("bro43dbs01dop"))
            {
                driveLetter = "D";
            }

            snapshotLocation = DefaultSeleniumFolder.Replace("C", driveLetter);
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

        public static void PurgeDownloads(string filePath)
        {
            var dirInfo = new DirectoryInfo(filePath);

            var snapShotCount = 0;
            var snapShots = dirInfo.GetFiles("*.pdf", SearchOption.TopDirectoryOnly);
            foreach (var snapShot in snapShots)
            {
                try
                {
                    snapShot.Delete();
                    snapShotCount++;
                }
                catch (IOException fileDeleteException)
                {
                    MsgOutput(string.Format("Unable to delete download {0} due to {1}", snapShot.Name, fileDeleteException.Message));
                }
            }
            MsgOutput(string.Format("Successfully Deleted {0} contract(s)", snapShotCount));
        }

        public static void PurgeDirectoryForAnyExtension(string filePath, string extension)
        {
            var dirInfo = new DirectoryInfo(filePath);

            var extensionString = String.Format("*.{0}", extension);

            var snapShotCount = 0;
            var snapShots = dirInfo.GetFiles(extensionString, SearchOption.TopDirectoryOnly);
            foreach (var snapShot in snapShots)
            {
                try
                {
                    snapShot.Delete();
                    snapShotCount++;
                }
                catch (IOException fileDeleteException)
                {
                    MsgOutput(string.Format("Unable to delete download {0} due to {1}", snapShot.Name, fileDeleteException.Message));
                }
            }
            MsgOutput(string.Format("Successfully Deleted {0} contract(s)", snapShotCount));
        }

        public static bool IsFileDownloaded(string path, string extension)
        {
            var fileExist = false;
            var dirInfo = new DirectoryInfo(path);

            var extensionString = String.Format("*.{0}", extension);

            var fileCount = new List<String>();
            var fileContainer = dirInfo.GetFiles(extensionString, SearchOption.TopDirectoryOnly);

            foreach (var file in fileContainer)
            {
                fileCount.Add(file.ToString());
            }

            if (fileCount.Count > 0)
            {
                fileExist = true;
            }

            return fileExist;

        }

        public static void TakeSnapshot(string additionalInformation)
        {
            var snapshotLocation = SnapShotDirectory();
            const string DRIVER_INSTANCE_PREFIX = "__driverInstance_";

            if (!Directory.Exists(snapshotLocation))
            {
                Directory.CreateDirectory(snapshotLocation);
            }
            
            TakeDriverSnapshot(TestController.CurrentDriver, null, snapshotLocation, additionalInformation);

            foreach (var item in ScenarioContext.Current)
            {
                if (item.Key.StartsWith(DRIVER_INSTANCE_PREFIX))
                {
                    var driver = (IWebDriver) item.Value;
                    var driverName = item.Key.Replace(DRIVER_INSTANCE_PREFIX, "");

                    TakeDriverSnapshot(driver, driverName, snapshotLocation, additionalInformation);
                    SaveDriverPageSource(driver, driverName, snapshotLocation);
                }
            }

        }

        public static void TakeDriverSnapshot(IWebDriver driver, string driverName, string snapshotDirectory, string additionalInformation)
        {
            var driverSnapshotLocation = snapshotDirectory + "\\" + GenerateSnapshotFileName(driverName);

            try
            {
                CurrentSnapShot = driverSnapshotLocation;
                MsgOutput(string.Format("Taking Snapshot ->[{0}]<-", additionalInformation));
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(driverSnapshotLocation, ImageFormat.Jpeg);
                MsgOutput("Snapshot Location", driverSnapshotLocation);
                TestController.ExtentLogScreenshotLocation(driverSnapshotLocation);
            }
            catch (PathTooLongException pathTooLong)
            {
                TestCheck.AssertFailTest(string.Format("Snapshot path length was too long - [{0}]", pathTooLong));
            }            
        }

        public static void SavePageSource()
        {
            var outputPath = SnapShotDirectory();

            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            outputPath += "\\" + GenerateHtmlFileName();

            File.WriteAllText(outputPath, TestController.CurrentDriver.PageSource);
        }

        public static void SaveDriverPageSource(IWebDriver driver, string driverName, string snapshotDirectory)
        {
            var driverSnapshotLocation = snapshotDirectory + "\\" + GenerateHtmlFileName(driverName);

            try
            {
                File.WriteAllText(driverSnapshotLocation, driver.PageSource);
            }
            catch (PathTooLongException pathTooLong)
            {
                TestCheck.AssertFailTest(string.Format("Page source path length was too long - [{0}]", pathTooLong));
            }
        }

        public static string GenerateSnapshotFileName(string driverName = null)
        {
            return GenerateFileNameFromCurrentTest("jpg", driverName);
        }

        public static string GenerateHtmlFileName(string driverName = null)
        {
            return GenerateFileNameFromCurrentTest("htm", driverName);
        }

        public static string GenerateFileNameFromCurrentTest(string extension, string driverName)
        {
            var testClassFull = TestContext.CurrentContext.Test.ClassName;
            Type objectType = (from asm in AppDomain.CurrentDomain.GetAssemblies()
                               from type in asm.GetTypes()
                               where type.IsClass && type.FullName == testClassFull
                               select type).Single();

            var testMethod = TestContext.CurrentContext.Test.MethodName;
            var testNamespace = objectType.Namespace;
            var testClass = testClassFull.Replace(objectType.Namespace + ".", "");
            var timestamp = string.Format("{0:yyyyMMdd-HHmmss}", DateTime.Now);

            var fileName = string.Format("{0}.{1}_{2}.{3}", testClass, testMethod, timestamp, extension);

            fileName = driverName != null ? string.Format("{0}-{1}", driverName, fileName) : fileName;

            return fileName;
        }
    }
}
