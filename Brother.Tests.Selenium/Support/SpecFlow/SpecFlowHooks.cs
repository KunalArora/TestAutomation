using System;
using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.UnitTestProvider;

namespace Brother.Tests.Selenium.Lib.Support.SpecFlow
{
    [Binding]
    public class Initialise
    {
        private bool IsStagingTest { get; set; }
        
    #region "Before And After Test Run Tags"

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Helper.MsgOutput("Starting Test Run........");

            Helper.MsgOutput(string.Format("Team City Env Var value = {0}", Environment.GetEnvironmentVariable("ANT")));
            Helper.MsgOutput(string.Format("Team City Env Var value = {0}", Environment.GetEnvironmentVariable("AutoTestRunTimeEnv")));
            // Clear old snapshots
            Helper.MsgOutput("Purging old snapshots");
            Helper.PurgeSnapshots();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Helper.MsgOutput("........Ending Test Run");
        }

#endregion "Before And After Test Run Tags"

#region "Before And After Step Tags"

        [BeforeStep]
        public static void BeforeStep()
        {
            Helper.MsgOutput(string.Format("[BeforeStep] The current page is [{0}]", TestController.CurrentDriver.Title));
        }

        [AfterStep]
        public static void AfterStep()
        {
            // No Error - move on
            if (ScenarioContext.Current.TestError == null)
            {
                Helper.MsgOutput("Test Step completed");
                return;
            }

            Helper.MsgOutput(string.Format("This step caused the following error [{0}]", ScenarioContext.Current.TestError.Message));
            Helper.TakeSnapshot("After Step Error Detected");
            Helper.MsgOutput(string.Format("[AfterStep] SnapShot Taken : Location = [{0}]", Helper.CurrentSnapShot));
            Helper.MsgOutput(string.Format("[AfterStep] The current page is [{0}]", TestController.CurrentDriver.Title));
            WebDriver.DeleteAllCookies();
        }

#endregion "Before And After Step Tags"

        #region "Before And After Feature Tags"

        [BeforeFeature]
        public static void BeforeFeatureHeadless()
        {
//            #if DEBUG
                BeforeFeatureHeadlessAndInteractive();
//            #else
//                TestController.HeadlessRunning();
//            #endif
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Helper.MsgOutput("Feature end - Tearing Down");
            TestController.Test_Teardown();
        }

        #endregion "Before And After Feature Tags"

        #region "Before and After Scenario Tags"

        [BeforeScenario("STAGING")]
        public void BeforeScenarioStaging()
        {
            IsStagingTest = true;
            if (!Helper.CheckForStagingTestFlag())
            {
                IgnoreThisTest("Skipping this test as Staging flag is not set");
            }
            Helper.MsgOutput("Staging Scenario Found");
        }

        [BeforeScenario("MPS")]
        public void BeforeScenarioMps()
        {
            Helper.MsgOutput("MPS Test found");
        }

        [BeforeScenario()]
        public void BeforeScenario()
        {
            if (TestController.CurrentDriver == null)
            {
                Helper.MsgOutput("***Current Web Driver is NULL - something went wrong in its creation***");
                return;
            }

            Helper.MsgOutput("*************COOKIE INFORMATION for this session******************");
            WebDriver.ShowAllCookies();
            Helper.MsgOutput("*************END COOKIE INFORMATION*******************************");


            // First check the Runtime environment for a valid value. If the Environment variable contains an invalid Test Environment
            // then END TEST RUN
            if (!CheckForValidRunTimeEnv(Helper.GetRunTimeEnv()))
            {
                Helper.MsgOutput("********************************************************************");
                Helper.MsgOutput("** CRITICAL ERROR : Test Environment is invalid for this test run **");
                Helper.MsgOutput("********************************************************************");
                Helper.MsgOutput(string.Format("RunTime Environment = {0}", Helper.GetRunTimeEnv()));
                IgnoreThisTest("Skipping Test - Run Time Environment is Invalid!");
                return;
            }

            if (Helper.CheckForStagingTestFlag() && !IsStagingTest)
            {
                IgnoreThisTest("Skipping this test as it is not a Staging test");
                IsStagingTest = false;
                return;
            }

            // Now check if this Scenario has Tagging present, and use this level in the first instance
            if ((ScenarioContext.Current.ScenarioInfo.Tags.Length > 0) && (!ScenarioContext.Current.ScenarioInfo.Tags.Contains("SMOKE") && (!ScenarioContext.Current.ScenarioInfo.Tags.Contains("STAGING"))))
            {
                Helper.MsgOutput("Scenario Tags present - using these to determine Runtime Environment");

                // Use ScenarioContext override tag
                // if the run time environment does not match, do not run test
                if (!Helper.CheckScenarioEnv(Helper.GetRunTimeEnv()))
                {
                    IgnoreThisTest(string.Format("Test skipped - Test Environment Mismatch for this test - Target [{0}]", Helper.GetRunTimeEnv()));
                }
            }
            else
            {
                switch (FeatureContext.Current.FeatureInfo.Tags.Length)
                {
                    case (0):
                        IgnoreThisTest("Test skipped - NO Feature Tags present - skipping all Scenarios under this Feature");
                        break;

                    default:
                        if (!Helper.CheckFeatureEnv(Helper.GetRunTimeEnv()))
                        {
                            IgnoreThisTest(string.Format("Test skipped - Test Environment Mismatch for this test - Target [{0}]", Helper.GetRunTimeEnv()));
                        }
                        else
                        {
                            Helper.MsgOutput("Using Feature Tags to determine Runtime Environment");
                        }
                        break;
                }
            }

            DoMpsTestEval(Helper.CheckFeatureEnv("MPS"));
            DoSmokeTestEval(Helper.IsSmokeTest());
            SetCurrentDriver();
        }

        [AfterScenario()]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.ContainsKey("CurrentDriver"))
            {
                ScenarioContext.Current.Remove("CurrentDriver");
            }

            if (ScenarioContext.Current.TestError == null)
            {
                // Clear the session
                WebDriver.DeleteAllCookies();
                return;
            }

            // Close and re-launch current driver so we start the next test from a clean sheet
            Helper.MsgOutput("Scenario Failed! - Restarting Driver");
            WebDriver.ClearWebDriverPackage();
            TestController.Test_Teardown();
            WebDriver.Wait(Helper.DurationType.Second, 3);
            BeforeFeatureHeadless();
        }

        #endregion "Before and After Scenario Tags"

        #region "Utility Methods"

        private static void SetCurrentDriver()
        {
            if (!ScenarioContext.Current.ContainsKey("CurrentDriver"))
            {
                ScenarioContext.Current.Add("CurrentDriver", TestController.CurrentDriver);
            }
            else
            {
                TestController.CurrentDriver = (IWebDriver)ScenarioContext.Current["CurrentDriver"];
            }    
        }

        private static bool CheckForValidRunTimeEnv(string runTimeEnv)
        {
            return (runTimeEnv.Equals(Helper.RunTimeLive)) || (runTimeEnv.Equals(Helper.RunTimeTest)) || (runTimeEnv.Equals(Helper.RunTimeUat)) || (runTimeEnv.Equals(Helper.RunTimeDev));
        }

        private static void IgnoreThisTest(string why)
        {
            var testRunTimeSetting = new NUnitRuntimeProvider();

            Helper.MsgOutput(why);
            testRunTimeSetting.TestIgnore(why);
        }

        public static void BeforeFeatureHeadlessAndInteractive()
        {
//            #if DEBUG
                TestController.Test_Setup();
                Helper.MsgOutput("Feature start - Starting Selenium");
//            #endif
        }

        private static void DoSmokeTestEval(bool smokeTest)
        {
            if (!smokeTest) return;
            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("SMOKE"))
            {
                Helper.MsgOutput("!!!!SMOKE TEST IN PROGRESS!!!!");
            }
            else
            {
                Helper.MsgOutput("Skipping test for Smoke Test run");
                IgnoreThisTest("Test skipped as NO Smoke Tag present and this is a Smoke Test Run");
            }
        }

        private static void DoMpsTestEval(bool runMps)
        {
            if (runMps)
            {
                if (Helper.MpsRunCondition().Equals("ONLY")
                    || Helper.MpsRunCondition().Equals("ALL"))
                {
                    Helper.MsgOutput("!!!!MPS TESTS IN PROGRESS!!!!");
                }
                else if (Helper.MpsRunCondition().Equals("OFF")
                    || Helper.MpsRunCondition().Equals(string.Empty))
                {
                    IgnoreThisTest("Test skipped as All MPS tests are switched off for this run");
                }
            }
            else
            {
                if (Helper.MpsRunCondition().Equals("ONLY")
                    || Helper.MpsRunCondition().Equals(string.Empty))
                {
                    IgnoreThisTest("Test skipped as ONLY MPS tests are switched ON for this run");
                    Helper.MsgOutput("!!!!Check if MpsTagRunner value is empty!!!!");
                }
                else if (Helper.MpsRunCondition().Equals("OFF")
                           || Helper.MpsRunCondition().Equals("ALL"))
                {
                    Helper.MsgOutput("!!!!TESTS RUN IN PROGRESS!!!!");
                }
            }
        }

        #endregion "Utility Methods"
    }
}
