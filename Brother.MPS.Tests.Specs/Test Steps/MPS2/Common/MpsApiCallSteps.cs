using Brother.Tests.Specs.StepActions.Common;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Common
{
    [Binding]
    public class MpsApiCallSteps
    {
        private readonly MpsApiCallStepActions _mpsApiCall;

        public MpsApiCallSteps(MpsApiCallStepActions mpsApiCall)
        {
            _mpsApiCall = mpsApiCall;
        }

        [When(@"the print counts of the devices are updated")]
        public void WhenThePrintCountsOfTheDevicesAreUpdated()
        {
            _mpsApiCall.UpdateAndNotifyBOCForPrintCounts();
        }
    }
}
