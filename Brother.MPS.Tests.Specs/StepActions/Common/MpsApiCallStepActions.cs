using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Common
{
    public class MpsApiCallStepActions : StepActionBase
    {
        private readonly IContextData _contextData;
        private readonly IDeviceSimulatorService _deviceSimulatorService;
        private readonly IContractShiftService _agreementShiftService;

        public MpsApiCallStepActions(
            IContractShiftService agreementShiftService,
            IDeviceSimulatorService deviceSimulatorService,
            IRunCommandService runCommandService,
            IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            ILoggingService loggingService,
            IRuntimeSettings runtimeSettings)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _contextData = contextData;
            _deviceSimulatorService = deviceSimulatorService;
            _agreementShiftService = agreementShiftService;
        }

        public void UpdateAndNotifyBOCForPrintCounts() // For Type 3
        {
            LoggingService.WriteLogOnMethodEntry();
            var products = _contextData.PrintersProperties;
            var devices = _contextData.AdditionalDeviceProperties;

            foreach (var product in products)
            {
                product.TotalPageCount = product.MonoPrintCount + product.ColorPrintCount;
                foreach(var device in devices)
                {
                    if (device.Model.Equals(product.Model))
                    {
                        device.MonoPrintCount = product.MonoPrintCount;
                        device.ColorPrintCount = product.ColorPrintCount;

                        _deviceSimulatorService.SetPrintCounts(device.BocDeviceId, device.MonoPrintCount, device.ColorPrintCount);
                        _deviceSimulatorService.NotifyBocOfDeviceChanges(device.BocDeviceId);
                    }
                }
            }
        }

        public void UpdateAndNotifyBOCForConsumableOrder() // For Type 3
        {
            LoggingService.WriteLogOnMethodEntry();
            var products = _contextData.PrintersProperties;
            var devices = _contextData.AdditionalDeviceProperties; 
            
            foreach (var product in products)
            {
                foreach(var device in devices)
                {
                    if (device.Model.Equals(product.Model))
                    {
                        // Save consumable order status to Additional Device Properties as well for convenience
                        device.TonerInkBlackStatus = product.TonerInkBlackStatus;
                        device.TonerInkCyanStatus = product.TonerInkCyanStatus;
                        device.TonerInkMagentaStatus = product.TonerInkMagentaStatus;
                        device.TonerInkYellowStatus = product.TonerInkYellowStatus;

                        _deviceSimulatorService.RaiseConsumableOrder(
                            device.BocDeviceId, device.TonerInkBlackStatus, device.TonerInkCyanStatus, device.TonerInkMagentaStatus, device.TonerInkYellowStatus);
                        _deviceSimulatorService.NotifyBocOfDeviceChanges(device.BocDeviceId);
                    }
                }
            }
        }

        public void ShiftAgreementStartDateBy(int agreementShiftDays)
        {
            LoggingService.WriteLogOnMethodEntry(agreementShiftDays);

            _contextData.StartDate = MpsUtil.SubtractDaysFromDate(_contextData.StartDate, agreementShiftDays);
            _contextData.EndDate = MpsUtil.SubtractDaysFromDate(_contextData.EndDate, agreementShiftDays);

            _agreementShiftService.ContractTimeShiftCommand(_contextData.AgreementId, agreementShiftDays, "d", false, true, "Any");
        }
    }
}
