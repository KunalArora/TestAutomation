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

        [When(@"the toner ink levels of the above devices become low")]
        public void WhenTheTonerInkLevelsOfTheAboveDevicesBecomeLow()
        {
            _mpsApiCall.UpdateAndNotifyBOCForConsumableOrder();
        }

        [When(@"I automatically raise a consumable order for above devices")]
        public void WhenIAutomaticallyRaiseAConsumableOrderForAboveDevices()
        {
            _mpsApiCall.UpdateAndNotifyBOCForConsumableOrderWithReplaceCountAndRemLife();
            _mpsApiCall.UpdateMPSForConsumableOrder();
        }

        [When(@"the agreement start date gets shifted ""(.*)"" days behind")]
        public void WhenTheAgreementStartDateGetsShiftedDaysBehind(int agreementShiftDays)
        {
            _mpsApiCall.ShiftAgreementStartDateBy(agreementShiftDays);
        }
    }
}
