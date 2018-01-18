using Brother.Tests.Common.ContextData;
using Brother.Tests.Specs.Services;

namespace Brother.Tests.Specs.StepActions.Common
{
    public class MpsApiCallStepActions
    {
        private readonly IContextData _contextData;
        private readonly IDeviceSimulatorService _deviceSimulatorService;
        private readonly IRunCommandService _runCommandService;

        public MpsApiCallStepActions(IContextData contextData, IDeviceSimulatorService deviceSimulatorService, IRunCommandService runCommandService)
        {
            _contextData = contextData;
            _deviceSimulatorService = deviceSimulatorService;
            _runCommandService = runCommandService;
        }

        public void UpdateAndNotifyBOCForPrintCounts() // For Type 3
        {
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