using System;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.UnitTestProvider;

namespace Brother.Tests.Selenium.Lib.Support.SpecFlow
{
    [Binding]
    public class Initialise
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Helper.MsgOutput("Starting Test Run........");

            // Clear old snapshots
            Helper.MsgOutput("Purging old snapshots");
            Helper.PurgeSnapshots();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Helper.MsgOutput("........Ending Test Run");
        }

        [BeforeStep]
        public static void BeforeStep()
        {
            Helper.MsgOutput("Step start time ", DateTime.Now.TimeOfDay.ToString());
        }

        [AfterStep]
        public static void AfterStep()
        {
            if (ScenarioContext.Current.TestError == null)
            {
                return;
            }

            Helper.MsgOutput(string.Format("This step caused the following error [{0}]", ScenarioContext.Current.TestError.Message));
            Helper.TakeSnapshot();
            Helper.MsgOutput(string.Format("[AfterStep] SnapShot Taken : Location = [{0}]", Helper.CurrentSnapShot));
        }

        [BeforeFeature]
        public static void BeforeFeatureHeadless()
        {
            #if DEBUG
                BeforeFeatureHeadlessAndInteractive();
            #else
                TestController.HeadlessRunning();
            #endif
        }

        private static void IgnoreThisTest(string why)
        {
             var testRunTimeSetting = new NUnitRuntimeProvider();

             Helper.MsgOutput(why);
                testRunTimeSetting.TestIgnore(why);
        }


        public static void BeforeFeatureHeadlessAndInteractive()
        {
            #if DEBUG
                TestController.Test_Setup();
                Helper.MsgOutput("Feature start - Starting Selenium");
            #endif
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Helper.MsgOutput("Feature end - Tearing Down");
            TestController.Test_Teardown();
        }

        [BeforeScenario()]
        public void BeforeScenario()
        {
            var testRunTimeSetting = new NUnitRuntimeProvider();
            var mpsFeatureTag = Helper.CheckFeatureEnv("MPS");

            // First check the Runtime environment for a valid value
            if (!CheckForValidRunTimeEnv(Helper.GetRunTimeEnv()))
            {
                IgnoreThisTest("Test skipped as Run Time Environment is Invalid!");
            }

            // Now check if this Scenario has Tagging present, and use this level in the first instance
            if ((ScenarioContext.Current.ScenarioInfo.Tags.Length > 0) && (!ScenarioContext.Current.ScenarioInfo.Tags.Contains("SMOKE")))
            {
                Helper.MsgOutput("Scenario Tags present - using these to determine Runtime Environment");

                // Use ScenarioContext override tag
                // if the run time environment does not match, do not run test
                if (!Helper.CheckScenarioEnv(Helper.GetRunTimeEnv()))
                {
                    IgnoreThisTest("Test skipped as Run Time Environment invalid for this test - Scenario Tags did not match Run Time Environment");
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
                            IgnoreThisTest("Test skipped as Run Time Environment invalid for this test");
                        }
                        else
                        {
                            Helper.MsgOutput("Using Feature Tags to determine Runtime Environment");
                        }
                        break;
                }
            }


            if (mpsFeatureTag)
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
           

            if (Helper.IsSmokeTest())
            {
                if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("SMOKE"))
                {
                    Helper.MsgOutput("!!!!SMOKE TEST IN PROGRESS!!!!");
                }
                else
                {
                    Helper.MsgOutput("Skipping test for Smoke Test run");
                    testRunTimeSetting.TestIgnore("Test skipped as NO Smoke Tag present and this is a Smoke Test Run"); 
                }
            }

            if (!ScenarioContext.Current.ContainsKey("CurrentDriver"))
            {
                ScenarioContext.Current.Add("CurrentDriver", TestController.CurrentDriver);
            }
            else
            {
                TestController.CurrentDriver = (IWebDriver)ScenarioContext.Current["CurrentDriver"];
            }
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
                return;
            }

            // Close and re-launch current driver so we start the next test from a clean sheet
            Helper.MsgOutput("Scenario Failed! - Restarting Driver");
            WebDriver.ClearWebDriverPackage();
            TestController.Test_Teardown();
            WebDriver.Wait(Helper.DurationType.Second, 3);
            BeforeFeatureHeadless();
        }

        private static bool CheckForValidRunTimeEnv(string runTimeEnv)
        {
            return (runTimeEnv.Equals(Helper.RunTimeLive)) || (runTimeEnv.Equals(Helper.RunTimeTest)) || (runTimeEnv.Equals(Helper.RunTimeUat)) || (runTimeEnv.Equals(Helper.RunTimeDev));
        }
    }
}
