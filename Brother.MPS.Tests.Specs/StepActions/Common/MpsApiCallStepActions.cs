using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
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
        private readonly IRunCommandService _runCommandService;

        public MpsApiCallStepActions(
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
            _runCommandService = runCommandService;
        }

        public void UpdateAndNotifyBOCForPrintCounts() // For Type 3
        {
            WriteLogOnMethodEntry();
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

                        _deviceSimulatorService.SetPrintCounts(device.BocDeviceId, product.MonoPrintCount, product.ColorPrintCount);
                        _deviceSimulatorService.NotifyBocOfDeviceChanges(device.BocDeviceId);
                    }
                }
            }

            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.AgreementId); // Note: Used for updating CMPS database to reflect print count changes on UI
        }
    }
}